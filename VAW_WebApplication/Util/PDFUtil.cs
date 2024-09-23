using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace VAW_WebApplication.Util
{
    public class PDFUtil
    {
        public PDFUtil()
        {
        }
        public string SavePDF(HttpPostedFileBase pdfFile)
        {
            if (pdfFile != null && pdfFile.ContentLength > 0)
            {
                // Path to the "Documents" folder
                //string documentFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyApplication", "Documents");
                string documentFolder = HttpContext.Current.Server.MapPath("~/Documents");

                // Create the directory if it doesn't exist
                if (!Directory.Exists(documentFolder))
                {
                    Directory.CreateDirectory(documentFolder);
                }

                // Generate a unique file name (optional)
                string fileName = Path.GetFileName(pdfFile.FileName);
                string pdfFilePath = Path.Combine(documentFolder, fileName);

                // Save the file
                try
                {
                    pdfFile.SaveAs(pdfFilePath);
                    //ViewBag.Message = $"PDF uploaded successfully: {fileName}";
                    return pdfFilePath;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                //ViewBag.Message = "Please select a PDF file.";
                //return "Please select a PDF file";
                return String.Empty;
            }
        }
    }
}