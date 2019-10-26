using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TerkwazNetTask.Context;
using TerkwazNetTask.Models;

namespace TerkwazNetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IConfiguration _config;

        public BlogController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/Blog
        [HttpGet]
        public JsonResult Get()
        {
            //Blog blog1 = new Blog()
            //{
            //    Key = 1,
            //    Author = "Muhamad",
            //    Title = "Terkwaz 1",
            //    SubtTitle = "Terkwaz Business Solutions 1",
            //    ImageUrl = "Blablabla 1",
            //    Body = "AAAAaaaaAaaAaaa 1",
            //    CreationDate = DateTime.Now
            //};
            //Blog blog2 = new Blog()
            //{
            //    Key = 2,
            //    Author = "Omar",
            //    Title = "Terkwaz 2",
            //    SubtTitle = "Terkwaz Business Solutions 2",
            //    ImageUrl = "Blablabla 2",
            //    Body = "AAAAaaaaAaaAaaa 2",
            //    CreationDate = DateTime.Now
            //};
            //Blog blog3 = new Blog()
            //{
            //    Key = 3,
            //    Author = "Ahmad",
            //    Title = "Terkwaz 3",
            //    SubtTitle = "Terkwaz Business Solutions 3",
            //    ImageUrl = "Blablabla 3",
            //    Body = "AAAAaaaaAaaAaaa 3",
            //    CreationDate = DateTime.Now
            //};

            //blogs.Add(blog1);
            //blogs.Add(blog2);
            //blogs.Add(blog3);
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
                optionsBuilder.UseSqlServer(_config.GetValue<string>("ConnectionString:BlogsDB"));
                var context = new BlogContext(optionsBuilder.Options);

                return new JsonResult(context.blogs);
            }
            catch(Exception ex)
            {
                return new JsonResult(null);
            }
            
        }

        // GET: api/Blog/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
                optionsBuilder.UseSqlServer(_config.GetValue<string>("ConnectionString:BlogsDB"));
                var context = new BlogContext(optionsBuilder.Options);

                Blog blog = context.blogs.SingleOrDefault(a => a.Key == id);

                return new JsonResult(blog);

            }
            catch(Exception ex)
            {
                return new JsonResult(null);
            }


        }

        // POST: api/Blog
        [HttpPost]
        public void Post([FromBody] Blog blog)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
                optionsBuilder.UseSqlServer(_config.GetValue<string>("ConnectionString:BlogsDB"));
                var context = new BlogContext(optionsBuilder.Options);

                context.blogs.Add(blog);
                context.SaveChanges();
            }catch(Exception ex)
            {

            }
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]  Blog blog)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
                optionsBuilder.UseSqlServer(_config.GetValue<string>("ConnectionString:BlogsDB"));
                var context = new BlogContext(optionsBuilder.Options);

                context.blogs.ForEachAsync(a =>
                {
                    if (a.Key == id)
                    {
                        a.Author = blog.Author;
                        a.Title = blog.Title;
                        a.SubtTitle = blog.SubtTitle;
                        a.ImageUrl = blog.ImageUrl;
                        a.Body = blog.Body;
                        a.CreationDate = blog.CreationDate;
                    }
                });
                context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
                optionsBuilder.UseSqlServer(_config.GetValue<string>("ConnectionString:BlogsDB"));
                var context = new BlogContext(optionsBuilder.Options);

                context.blogs.Remove(context.blogs.Where(a => a.Key == id).FirstOrDefault());
                context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
