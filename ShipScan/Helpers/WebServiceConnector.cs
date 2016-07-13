using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Configuration;

namespace ShipScan.Helpers
{
    class WebServiceConnector
    {
        public static SCANSHIP.Screen InitializeWebService()
        {
            StatefullServiceClass context = new StatefullServiceClass();
            context.Url = "http://localhost/AcumaticaQA/(W(1))/Soap/SCANSHIP.asmx";
            context.Login("admin", "123");

            return context;
        }
    }
}
