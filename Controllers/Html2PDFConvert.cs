using iText.Html2pdf;
using iText.Kernel.Pdf;
using System;
using System.IO;
//using HtmlAgilityPack;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Geom;
using iText.Layout.Renderer;
using System.Net.Http;
using iTextSharp.text;
using HtmlAgilityPack;

namespace WebApplication1.Controllers
{
    public class Html2PDFConvert
    {
        public static void HTML2PDF(string mainpath)
        {
            try
            {
                var filePath = mainpath + "\\PDFVersion_" + DateTime.Now.Ticks.ToString() + ".pdf";

                string htmlContent;
                using (var sr = new StreamReader(mainpath + "\\input.html"))
                {
                    htmlContent = sr.ReadToEnd();
                }

                var doc = new HtmlDocument();
                doc.LoadHtml(htmlContent);

                var inputElement1 = doc.DocumentNode.SelectSingleNode("//input[@id='retailer-sig1-imgsrc']");
                var inputElement2 = doc.DocumentNode.SelectSingleNode("//input[@id='retailer-sig-imgsrc']");

                string inputValue1 = inputElement1?.GetAttributeValue("value", "");
                string inputValue2 = inputElement2?.GetAttributeValue("value", "");

                if (inputElement1 != null && inputElement2 != null)
                {
                    string imgTag1 = $"<img style='border: 1px solid black;' src='data:image/Bmp;base64,{inputValue1}'>";
                    string imgTag2 = $"<img style='border: 1px solid black;' src='data:image/Bmp;base64,{inputValue2}'>";
                    var parentDiv1 = inputElement1.ParentNode;
                    parentDiv1.InnerHtml = imgTag1;
                    var parentDiv2 = inputElement2.ParentNode;
                    parentDiv2.InnerHtml = imgTag2;
                    //htmlContent = htmlContent.Replace(inputElement1.OuterHtml, imgTag1);
                    //htmlContent = htmlContent.Replace(inputElement2.OuterHtml, imgTag2);
                }

                using (FileStream pdfDest = File.Open(filePath, FileMode.OpenOrCreate))
                {
                    ConverterProperties converterProperties = new ConverterProperties();
                    converterProperties.SetBaseUri(mainpath);
                    HtmlConverter.ConvertToPdf(doc.DocumentNode.OuterHtml, pdfDest, converterProperties);
                };
                //using (var sr = new StreamReader(mainpath + "\\input.html"))
                //{
                //    string htmlContent = sr.ReadToEnd();
                //    var doc = new HtmlDocument();
                //    doc.LoadHtml(htmlContent);
                //    //string[] nodeNamesToRemove = { "small", "input[@type='hidden']" };
                //    //var smallNodes = doc.DocumentNode.SelectNodes("//small");

                //    ////foreach (var nodeName in nodeNamesToRemove)
                //    ////{
                //    ////var nodes = doc.DocumentNode.SelectNodes("//" + nodeName);
                //    //    if (smallNodes != null)
                //    //    {
                //    //        foreach (var node in smallNodes)
                //    //        {
                //    //            node.Remove();
                //    //        }
                //    //    }
                //    //}

                //    //string updatedHtml = doc.DocumentNode.OuterHtml;
                //    var inputElement1 = doc.DocumentNode.SelectSingleNode("//input[@id='retailer-sig1-imgsrc']");
                //    var inputElement2 = doc.DocumentNode.SelectSingleNode("//input[@id='retailer-sig-imgsrc']");

                //    string inputValue1 = inputElement1.GetAttributeValue("value", "");
                //    string inputValue2 = inputElement2.GetAttributeValue("value", "");
                //    string imgTag1 = $"<img style='border: 1px solid black;' src='data:image/Bmp;base64,{inputValue1}'>";
                //    string imgTag2 = $"<img style='border: 1px solid black;' src='data:image/Bmp;base64,{inputValue2}'>";
                //    htmlContent = htmlContent.Replace(inputElement1.OuterHtml, imgTag1);
                //    htmlContent = htmlContent.Replace(inputElement2.OuterHtml, imgTag2);

                //    using (FileStream pdfDest = File.Open(filePath, FileMode.OpenOrCreate))
                //    {
                //        ConverterProperties converterProperties = new ConverterProperties();
                //        HtmlConverter.ConvertToPdf(htmlContent, pdfDest, converterProperties);
                //    };

                //    //PageSize pageSize = PageSize.A4;
                //    //float marginLeft = 36;
                //    //float marginRight = 36;
                //    //float marginTop = 36;
                //    //float marginBottom = 36;

                //    //// Create a PdfWriter
                //    //PdfWriter writer = new PdfWriter(filePath, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0));

                //    //// Create a PdfDocument
                //    //PdfDocument pdf = new PdfDocument(writer);
                //    ////htmlContent = htmlContent.Replace(updatedHtml, imgTag1);
                //    //using (Document document = new Document(pdf, pageSize))
                //    //{
                //    //    document.SetMargins(marginLeft, marginRight, marginTop, marginBottom);

                //    //    ConverterProperties converterProperties = new ConverterProperties();
                //    //    HtmlConverter.ConvertToPdf(htmlContent, pdf, converterProperties);
                //    //};
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading HTML file: {ex.Message}");
            }
            //            var filePath = mainpath + "\\PDFVersion_" + DateTime.Now.Ticks.ToString() + ".pdf";
            //            using (FileStream htmlSource = File.Open((mainpath + "\\input.html"), FileMode.Open))
            //            using (FileStream cssSource = File.Open((mainpath + "\\Style.css"), FileMode.Open))
            //            using (FileStream pdfDest = File.Open(filePath, FileMode.OpenOrCreate))
            //            {

            //.               htmlSource.readt
            //                ConverterProperties converterProperties = new ConverterProperties();
            //                ////converterProperties.SetBaseUri(mainpath+"\\Style.css");
            //                ////converterProperties.SetCssApplierFactory();
            //                HtmlConverter.ConvertToPdf(htmlSource, pdfDest, converterProperties);
            //            };

            // Define page size and margins
            
        }
    }
}