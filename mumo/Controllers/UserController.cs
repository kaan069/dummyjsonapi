using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using System.Text;
//using System.Web.HttpUtility.HtmlDecode;

namespace webapi.Controllers
{
    public class UserController : Controller
    {
        //[HttpGet]
        public IActionResult GetAllUser()
        {
            var url = "https://dummyjson.com/users";
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                return new JsonResult(content);
            }
        }

        //public IActionResult GetAllUser()
        //{
        //    var u = "https://dummyjson.com/users";
        //    using var client = new HttpClient();
        //    var res = client.Get(u);
        //    //res.Wait();
        //    var content = res.Result;
        //    var taskResult = content.Content.ReadAsString();
        //    //taskResult();

        //    return Json(taskResult.Result);
        //}
        public IActionResult GetUser(int id)
        {
            ViewBag.Id = id;
            var k = $"https://dummyjson.com/user/{id}";
            using var client = new HttpClient();
            var res = client.GetAsync(k);
            res.Wait();
            var content = res.Result;
            var taskResult = content.Content.ReadAsStringAsync();
            taskResult.Wait();
            return Json(taskResult.Result);
        }
        public IActionResult Search(string id)
        {
            ViewBag.Id = id;
            var k = $"https://dummyjson.com/users/search?q={id}";
            using var client = new HttpClient();
            var res = client.GetAsync(k);
            res.Wait();
            var content = res.Result;
            var taskResult = content.Content.ReadAsStringAsync();
            taskResult.Wait();
            return Json(taskResult.Result); 
        }
        public IActionResult Filter(string id)
        {
            ViewBag.Id = id;
            var k = $"https://dummyjson.com/users/filter?key=hair.color&value={id}";
            using var client = new HttpClient();
            var res = client.GetAsync(k);
            res.Wait();
            var content = res.Result;
            var taskResult = content.Content.ReadAsStringAsync();
            taskResult.Wait();
            return Json(taskResult.Result);
        }
        public IActionResult LimitandSkip(string id, int age)
        {
            ViewBag.Id = id;
            var k = $"https://dummyjson.com/users?limit=5&skip=10&select={id},{age}";
            using var client = new HttpClient();
            var res = client.GetAsync(k);
            res.Wait();
            var content = res.Result;
            var taskResult = content.Content.ReadAsStringAsync();
            taskResult.Wait();
            return Json(taskResult.Result);
        }
        [HttpPost]
        public IActionResult AddUser(string firstName, string email, string password)
        {
            var url = "https://dummyjson.com/users/add";
            var client = new HttpClient();
            var user = new { firstName = firstName, email = email, password = password };
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, content).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            return Content(result);
        }
        public IActionResult UpdateUser()
        {
            return Json("");
        }
        public IActionResult DeleteUser(string id)
        {
            var k = $"https://dummyjson.com/users/{id}";
            using var client = new HttpClient();
            var res = client.DeleteAsync(k);
            res.Wait();
            var content = res.Result;
            var taskResult = content.Content.ReadAsStringAsync();
            taskResult.Wait();
            return Json(taskResult.Result);
        }

        //public IActionResult Filter(string color)
        //{
        //    var l = $"https://dummyjson.com/users/filter?key=hair.color&value={color}";
        //    using var client = new HttpClient();
        //    var res = client.GetAsync(l);
        //    res.Wait();
        //    var content = res.Result;
        //    var taskResult = content.Content.ReadAsStringAsync();
        //    taskResult.Wait();
        //    return Json(taskResult.Result);
        //}

        //public IActionResult FSearch(string kaan)
        //{
        //    var l = $"https://dummyjson.com/users/search?q={kaan}";
        //    using var client = new HttpClient();
        //    var res = client.GetAsync(l);
        //    res.Wait();
        //    var content = res.Result;
        //    var taskResult = content.Content.ReadAsStringAsync();
        //    taskResult.Wait();
        //    return Json(taskResult.Result);
        //}

        //}

        //    // GET api/<UserController>/5
        //    [HttpGet("{id}", Name = "Get")]
        //    public IActionResult GetSingleUser()
        //    {
        //        var u = "https://dummyjson.com/users";
        //        using var client = new HttpClient();
        //        var res = client.GetAsync(u);
        //        res.Wait();
        //        var content = res.Result;
        //        var taskResult = content.Content.ReadAsStringAsync();
        //        taskResult.Wait();

        //        taskResult.Find(u => u.Id == id);

        //        return Json(taskResult.Result);
        //    }
        //    public IActionResult SearchUser()
        //    {

        //    }
        //    [HttpDelete("{id}")]
        //    public IActionResult Delete(int id)
        //    {
        //        return Json();
        //    }
        //
    }
}

