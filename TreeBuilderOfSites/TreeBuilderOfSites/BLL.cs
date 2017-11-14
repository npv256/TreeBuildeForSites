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
       public Dictionary<ElementEntity, string> AllUrl = new Dictionary<ElementEntity, string>();
        ElementEntity FirstObj;
        private string domein { get; set; }

        public BLL(string url)
        {
            domein = url;

        }

        public List<IDomObject> ParseElemsA(string url)
        {
            string HtmlText = string.Empty;
            HttpWebResponse myHttpWebresponse = null;
            try
            {
                HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            }
            catch (Exception)
            {
                return new List<IDomObject>();
            }
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            HtmlText = strm.ReadToEnd();
            CQ dom = HtmlText;
            var aElems = dom["a"];
            return aElems.ToList();
        }

        public string ParseTag(CQ elem)
        {
            string tag = elem.Text();
            return tag;
        }

        public string ParseHref(CQ elem)
        {
            string href = elem.Attr("href");
            if (href == null) return href = "";
            if (href == "/") href = domein;
            if (!href.Contains(domein))
                href = domein + href;
            if (href.Replace(domein,"").Contains("http"))
                href = domein;
            return href;
        }

        public ElementEntity  creator(CQ objCQ)
        {
            ElementEntity objElEntity = new ElementEntity();
            objElEntity.url = ParseHref(objCQ);
            objElEntity.tag = ParseTag(objCQ);
            return objElEntity;
        }

        public void recursAdd(string url)
        {

            foreach (var elA in ParseElemsA(url))
            {
                if (!AllUrl.ContainsValue(ParseHref(elA.Cq())))
                {
                    AllUrl.Add(creator(elA.Cq()), ParseHref(elA.Cq()));
                    recursAdd(ParseHref(elA.Cq()));
                }
            }
        }

        public void editObj(ElementEntity obj)
        {
            ElementEntity objElEntity = obj;
            foreach (var el in AllUrl)
            {
                if (el.Key.generals.Find(entity => entity.url == objElEntity.url) != null)
                    objElEntity.parent = el.Key;
            }

            foreach (var elA in ParseElemsA(objElEntity.url))
            {
                if (AllUrl.ContainsValue(elA.Cq().Attr("href")))
                {
                    objElEntity.generals.Add(AllUrl.Keys.Where(entity => entity.url == elA.Cq().Attr("href")).First());
                }
                else
                {
                    objElEntity.generals.Add(creator(elA.Cq()));
                }
            }
        }
    }
}
