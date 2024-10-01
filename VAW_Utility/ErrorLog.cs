using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VAW_Utility
{
    public class ErrorLog
    {

        public void WriteErrorLog(Exception ex)
        {
            try
            {
                string webPageName = Path.GetFileName(HttpContext.Current.Request.Path);
                string errorLogFilename = "VAWErrorLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

                string path = HttpContext.Current.Server.MapPath("ErrorLogFiles/" + errorLogFilename);

                if (File.Exists(path))
                {
                    using (StreamWriter stwriter = new StreamWriter(path, true))
                    {
                        stwriter.WriteLine("-------------------Error Log Start-----------as on " + DateTime.Now.ToString("hh:mm tt"));
                        stwriter.WriteLine("WebPage Name :" + webPageName);
                        stwriter.WriteLine("Message:" + ex.ToString());
                        stwriter.WriteLine("-------------------End----------------------------");
                    }
                }
                else
                {
                    StreamWriter stwriter = File.CreateText(path);
                    stwriter.WriteLine("-------------------Error Log Start-----------as on " + DateTime.Now.ToString("hh:mm tt"));
                    stwriter.WriteLine("WebPage Name :" + webPageName);
                    stwriter.WriteLine("Message: " + ex.ToString());
                    stwriter.WriteLine("-------------------End----------------------------");
                    stwriter.Close();
                }
            }
            catch (Exception exc)
            {

            }
        }

        public void WriteErrorLog_InReg(Exception ex)
        {
            try
            {
                string webPageName = Path.GetFileName(HttpContext.Current.Request.Path);
                string errorLogFilename = "VAWErrorLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

                string path = HttpContext.Current.Server.MapPath("../ErrorLogFiles/" + errorLogFilename);

                if (File.Exists(path))
                {
                    using (StreamWriter stwriter = new StreamWriter(path, true))
                    {
                        stwriter.WriteLine("-------------------Error Log Start-----------as on " + DateTime.Now.ToString("hh:mm tt"));
                        stwriter.WriteLine("WebPage Name :" + webPageName);
                        stwriter.WriteLine("Message:" + ex.ToString());
                        stwriter.WriteLine("-------------------End----------------------------");
                    }
                }
                else
                {
                    StreamWriter stwriter = File.CreateText(path);
                    stwriter.WriteLine("-------------------Error Log Start-----------as on " + DateTime.Now.ToString("hh:mm tt"));
                    stwriter.WriteLine("WebPage Name :" + webPageName);
                    stwriter.WriteLine("Message: " + ex.ToString());
                    stwriter.WriteLine("-------------------End----------------------------");
                    stwriter.Close();
                }
            }
            catch (Exception exc)
            {

            }
        }
    }
}
