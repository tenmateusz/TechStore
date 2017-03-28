using ITStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITStore.Controllers
{
    public class PostController : Controller
    {
        private IPostRespository respository;


        public PostController(IPostRespository postRespository)
        {
            respository = postRespository;
        }

        public ViewResult List()
        {
            return View(respository.Posts);
        }
    }
}