using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using REM.Connections;

namespace REM.Logic
{
    public enum ErrorNames
    {
        EntityRuleBroken,
        FileNotFoundException,
        HttpTimeout,
        TrialExpired,
        EventListenerConnectionLost

    }

    public class Log
    {
        public static void Add(ErrorNames error, string qualifiedDirective)
        {
            try
            {
                ApplicationDbContext Db = new ApplicationDbContext();
                
            }
            catch
            {
                try
                {
                    string fileName = HttpContext.Current.Server.MapPath("\\logfile.txt");
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine("{0}, {1}, {2}, {3}, {4}", DateTime.Now, error.ToString(), qualifiedDirective, "ExceptionName", "UserID");
                    }

                }
                catch
                {

                }
            }
        }

        public static void Add(ErrorNames error, string qualifiedDirective, Exception e)
        {

        }

        public static void Add(ErrorNames error, string qualifiedDirective, Exception e, string userId)
        {

        }
    }
}