using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.ProjectOxford.Vision;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using FluentData;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GetAIDetection
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([BlobTrigger("photosharing/{name}")] CloudBlockBlob blob,
            string name,
            TextWriter log)
        {
            log.WriteLine(blob.Uri.AbsoluteUri);
            HttpClient client = new HttpClient();
            string address = "https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Adult,Description,Faces,Color,ImageType,Tags,Categories&subscription-key=f882bab6c3f3436faffa5d3ff537aaf7";
           
            var body = new bodyContent { url = blob.Uri.AbsoluteUri };
            string jsonInput = JsonConvert.SerializeObject(body);
            StringContent request =
                new StringContent(jsonInput, Encoding.UTF8,"application/json");
            request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var t = client.PostAsync(address,request);
            
            var result = t.Result;
            var t2 = result.Content.ReadAsStringAsync();
            var json = t2.Result;
            IDbContext context = new DbContext().ConnectionStringName("PhotoSharingContext",
            new SqlServerProvider());
            

            int rowsAffected = context.Sql(@"update Photos set CVJson = @0 where AzurePath = @1")
            .Parameters(json, blob.Uri.AbsoluteUri.ToString())
            .Execute();
           

            log.WriteLine(rowsAffected);
        }
    }
    public class bodyContent
    {
        public string url { get; set; }
    }
}
