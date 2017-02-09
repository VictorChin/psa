using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoSharingApplication.Controllers
{
    public class FirstController : ApiController
    {
        PhotoSharingContext psc = new PhotoSharingContext();
        [HttpGet]
        public List<Photo> DoAdd()
        {

            return (psc.Photos.ToList());
        }

        [HttpPost]
        public HttpStatusCode DeletePhoto(int id)
        {
            var selectedPhoto = psc.Photos.FirstOrDefault(x => x.PhotoID == id);
            if (selectedPhoto != null)
            {
                psc.Photos.Remove(selectedPhoto);
                psc.SaveChanges();
                return HttpStatusCode.OK;
            }
            else return HttpStatusCode.NotFound;
        }

        public class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool Gay { get; set; }
        }
    }
}
