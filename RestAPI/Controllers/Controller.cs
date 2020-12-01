﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Web.UI.WebControls;

namespace RestAPI
{
    public class Controller
    {
        private List<Nachricht> _MSGLIST;
        public List<Nachricht> MSGLIST { get => _MSGLIST; set => _MSGLIST = value; }
        public Controller()
        {
            MSGLIST = new List<Nachricht>();
        }

        public string SendMSG(string URL, string txt, ref ListBox lb)
        {
            WebRequest Req = WebRequest.Create(URL + "api/Haupt?valueTXT=" + txt);
            Req.Method = "GET";
            WebResponse Res = Req.GetResponse();
            Stream Response = Res.GetResponseStream();
            StreamReader SR = new StreamReader(Response);
            string Text = SR.ReadToEnd();
            lb.Items.Add("Gesendet: " + txt);
            //lb.Items.Add("HTTP-Code: " + Response.);
            return Text;
        }
    }
}