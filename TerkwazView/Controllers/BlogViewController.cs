using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TerkwazView.Models;

namespace TerkwazView.Controllers
{
    public class BlogViewController : Controller
    {
        // GET: BlogView
        public async Task<ActionResult> IndexAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://localhost:44342/api/blog");
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                List<Blog> blogs = JsonConvert.DeserializeObject<List<Blog>>(content);
                return View(blogs);
            }
            return View(new ErrorViewModel());
        }

        // GET: BlogView/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://localhost:44342/api/blog/"+id);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                Blog blog = JsonConvert.DeserializeObject<Blog>(content);
                return View(blog);
            }
            return View(new ErrorViewModel());
        }

        // GET: BlogView/Create
        public ActionResult  Create()
        {

            return View();
        }

        // POST: BlogView/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Blog newBlog)
        {
            try
            {
                // TODO: Add insert logic here


                string jsonBlog = JsonConvert.SerializeObject(newBlog);
                var httpContent = new StringContent(jsonBlog, Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage responseMessage = await httpClient.PostAsync("https://localhost:44342/api/blog", httpContent);
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                
                    return RedirectToAction(nameof(Index));
                }
                return View(new ErrorViewModel());
            }
            catch
            {
                return View(new ErrorViewModel());
            }
        }

        // GET: BlogView/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync("https://localhost:44342/api/blog/" + id);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                Blog blog = JsonConvert.DeserializeObject<Blog>(content);
                                               
                return View(blog);
            }
            return View(new ErrorViewModel());
        }

        // POST: BlogView/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Blog blog)
        {
            try
            {

                string jsonBlog = JsonConvert.SerializeObject(blog);
                var httpContent = new StringContent(jsonBlog, Encoding.UTF8, "application/json");

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage responseMessage = await httpClient.PutAsync("https://localhost:44342/api/blog/" + id, httpContent);
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    return RedirectToAction(nameof(Index));
                }
                return View(new ErrorViewModel());
            }
            catch
            {
                return View(new ErrorViewModel());
            }
        }

        // GET: BlogView/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.DeleteAsync("https://localhost:44342/api/blog/" + id);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(new ErrorViewModel());
        }

        // POST: BlogView/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}