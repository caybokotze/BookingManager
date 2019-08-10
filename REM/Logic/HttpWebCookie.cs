using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using REM.Interfaces;

namespace REM.Logic
{
    public class HttpWebCookie : IWebCookie
    {
        public void Dump(object init)
        {

        }

        public void Timeout()
        {
            throw new NotImplementedException();
        }

        public void CarrySession()
        {
            throw new NotImplementedException();
        }

        public void AddSession(object init)
        {
            string jsonObject = JsonConvert.SerializeObject(init);
            HttpCookie cookie = new HttpCookie("" + init.GetType().Name + "", jsonObject)
            {
                Expires = DateTime.Now.AddHours(1)
            };
            
        }

        public void EndSession()
        {
            throw new NotImplementedException();
        }
    }
}