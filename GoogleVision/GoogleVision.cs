using Google.Cloud.Vision.V1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleVision
{
    public class GoogleVisionCN
    {
        public void detectarTexto()
        {
            try
            {
                String pathJson = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivos\\friendly-storm-402818-50a65a800956.json");
                String pathImg = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivos\\prueba.jpeg");
                Image image = Image.FromFile(pathImg);
                var client = ImageAnnotatorClient.Create();
                IReadOnlyList<EntityAnnotation> textAnnotations = client.DetectText(image);
                foreach (EntityAnnotation text in textAnnotations)
                {
                    Console.WriteLine($"Description: {text.Description}");
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
