using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Http;

namespace PhotoSharingApplication.Controllers
{
    public class FirstController : ApiController
    {
			PhotoSharingContext cont = new PhotoSharingContext();
       [HttpGet]
		public List<Photo> DoAdd ()
		{
			var cust = new Custumer() { Name = "Børge", Age = 23 };
			
			return cont.Photos.ToList();
		}

		[HttpDelete]
		public HttpStatusCode Delete(int id)
		{
			var succes = cont.Photos.SingleOrDefault(x => x.PhotoID == id);
			if (succes != null)
			{
				return HttpStatusCode.OK;
			}

			return HttpStatusCode.NotFound ;
		}



	}

	[DataContract]
	public class Custumer
	{
		[DataMember]
		public string  Name { get; set; }
		[DataMember]
		public int Age { get; set; }
	}
}
