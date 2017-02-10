using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class bodyContent
    {
        public string url { get; set; }
    }
    class Program
    {
      

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string address = "https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Adult,Description,Faces,Color,ImageType,Tags,Categories&subscription-key=f882bab6c3f3436faffa5d3ff537aaf7";
            
            var body = new bodyContent { url = "https://images.trvl-media.com/media/content/shared/images/travelguides/destination/180102/Place-Massena-59151.jpg" };
            string jsonInput = JsonConvert.SerializeObject(body);
            StringContent request =
                new StringContent(jsonInput, Encoding.UTF8,"application/json");
            request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var t = client.PostAsync(address,request);
            
            var result = t.Result;
            var json = result.Content.ReadAsStringAsync();
            var analysisResult = JsonConvert.DeserializeObject<AnalysisResult>(json.Result);

            Console.WriteLine(analysisResult.Faces);

            //VisionServiceClient vsc =
            //    new VisionServiceClient("f882bab6c3f3436faffa5d3ff537aaf7");
            //IEnumerable<VisualFeature> target =
            //    new List<VisualFeature> {
            //        VisualFeature.Adult,
            //        VisualFeature.Description,
            //        VisualFeature.Faces,
            //        VisualFeature.Color,
            //        VisualFeature.ImageType,
            //        VisualFeature.Tags,
            //        VisualFeature.Categories
            //    };
            //var task =
            //    vsc.AnalyzeImageAsync
            //    ("https://s3-us-west-1.amazonaws.com/powr/defaults/image-slider2.jpg", target);

            //var result = task.Result;
            


        }
    }
}
