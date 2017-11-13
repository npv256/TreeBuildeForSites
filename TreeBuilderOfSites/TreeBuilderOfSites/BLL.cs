using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsQuery;
using CsQuery.Implementation;

namespace TreeBuilderOfSites
{
   public class BLL
    {
        Dictionary<string,string> AllUrl = new Dictionary<string, string>();
        ElementEntity FirstObj;
        public BLL()
        {
            
        }

        public CQ ParseElemsA(string url)
        {
            string HtmlText = string.Empty;
            HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            HtmlText = strm.ReadToEnd();
            CQ dom = HtmlText;
            var aElems = dom["a"];
            return aElems;
        }

        public string ParseTag(CQ elem)
        {
            string tag = elem.Text();
            return tag;
        }

        public string ParseHref(CQ elem)
        {
            string href = elem.Attr("href");
            return href;
        }

        public void createrFirst(string url)
        { 
            FirstObj = new ElementEntity();
            FirstObj.url = url;
            FirstObj.tag = ParseElemsA(url).First().Text();
            FirstObj.parent = null;
            AllUrl.Add(FirstObj.url,FirstObj.tag);

           
           
            

        }

    }
}
