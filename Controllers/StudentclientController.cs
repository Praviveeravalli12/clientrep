using Newtonsoft.Json;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Collections.Specialized;
using Studclient.Models;
namespace Studclient.Controllers
{
    public class StudentclientController : Controller
    {
        // GET: Studentclient
        public ActionResult Index()
        {
            IEnumerable<Studdetails> empdata = null;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "http://localhost:50217/api/";

                var json = webClient.DownloadString("Students");
                var list = JsonConvert.DeserializeObject<List<Studdetails>>(json);
                empdata = list.ToList();
                return View(empdata);
            }
        }

        // GET: Studentclient/Details/5
        public ActionResult Details(int id)
        {
            Studdetails empdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "http://localhost:50217/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                empdata = JsonConvert.DeserializeObject<Studdetails>(json);
            }
            return View(empdata);
        }

        // GET: Studentclient/Create
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Studdetails model)
        {

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "http://localhost:50217/api/";
                    var url = "Students/POST";

                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);
                    var response = webClient.UploadString(url, data);
                    JsonConvert.DeserializeObject<Studdetails>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Studentclient/Edit/5
        public ActionResult Edit(int id)
        {
            Studdetails empdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "http://localhost:50217/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                empdata = JsonConvert.DeserializeObject<Studdetails>(json);
            }
            return View(empdata);
        }

        // POST: Studentclient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Studdetails model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "http://localhost:50217/api/Students/" + id;
                    //var url = "Values/Put/" + id;
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);

                    var response = webClient.UploadString(webClient.BaseAddress, "PUT", data);

                    Studdetails modeldata = JsonConvert.DeserializeObject<Studdetails>(response);

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
     


        // GET: Studentclient/Delete/5
        public ActionResult Delete(int id)
        {
    Studdetails detail1;
    using (WebClient webClient = new WebClient())
    {
        webClient.BaseAddress = "http://localhost:50217/api/";
        var json = webClient.DownloadString("Students/" + id);
        detail1 = JsonConvert.DeserializeObject<Studdetails>(json);
    }
    return View(detail1);
}
[HttpPost]
public ActionResult Delete(int id, Studdetails model)
{

    try
    {
        using (WebClient webClient = new WebClient())
        {
            NameValueCollection nv = new NameValueCollection();
            string url = "http://localhost:50217/api/Students/" + id;


            var response = Encoding.ASCII.GetString(webClient.UploadValues(url, "DELETE", nv));

        }
    }
    catch (Exception ex)
    {
        throw ex;
    }
    return RedirectToAction("Index");
}
    }
}
