using ASP.Net_Project.Models.Test;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ASP.Net_Project.Controllers
{
    public class MidtermController : Controller
    {
        // GET: Midterm
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TakeTest()
        {
            return View(GetQuestionList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeTest(string fake)
        {
            List<TestQuestion> questions = GetQuestionList();

            foreach(TestQuestion q in questions)
            {
                q.Answer = Request.QueryString[q.ID.ToString()];
            }
            if (ModelState.IsValid)
            {
                TempData["TestData"] = questions;
                return RedirectToAction("DisplayResults");
            }
            else
                return View(questions);

        }

        [HttpGet]
        public ActionResult DisplayResults()
        {
            return View((List<TestQuestion>)TempData["TestData"]);
        }

        public List<TestQuestion> GetQuestionList()
        {
            List<TestQuestion> questions = new List<TestQuestion>();
            string json_path = Server.MapPath("/JSON/Midterm.json").ToString();
            var serial = new JavaScriptSerializer();
            var reader = new StreamReader(json_path);
            List< json_container> list = new List<json_container>();

            string content = reader.ReadToEnd();
            reader.Close();

            if(content != null)
            {
                list = serial.Deserialize<List<json_container>>(content);
                foreach(json_container t in list)
                {
                    TestQuestion quest = null;

                    switch(t.type.ToString())
                    {
                        case "TrueFalseQuestion":
                            quest = new TrueFalseQuestion();
                            break;

                        case "ShortAnswerQuestion":
                            quest = new ShortAnswerQuestion();
                            break;

                        case "LongAnswerQuestion":
                            quest = new LongAnswerQuestion();
                            break;

                        case "MultipleChoiceQuestion":
                            quest = new MultipleChoiceQuestion();
                            

                            ((MultipleChoiceQuestion)quest).Choices = t.choices;
                            
                            break;
                    }

                    quest.ID = (int)t.id;
                    quest.Question = t.question.ToString();
                    questions.Add(quest);
                } 
            }
            return questions;
        }
    }

    public class json_container
    {
        public int id { get; set; }
        public string type { get; set; }
        public string question { get; set; }
        public List<string> choices { get; set; }
    }
}