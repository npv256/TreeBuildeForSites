using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsQuery;
using CsQuery.Implementation;
using HtmlAgilityPack;

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

        public IEnumerable<HtmlNode> ParseElemsA(string url)
        {
            var doc = new HtmlWeb().Load(url);
            var linkTags = doc.DocumentNode.Descendants("link");
            var linkedPages = doc.DocumentNode.Descendants("a");
            return linkedPages;
        }

        public string ParseTag(HtmlNode node)
        {
            string tag = node.InnerText;
            return tag;
        }

        public string ParseHref(HtmlNode node)
        {
            string href = node.GetAttributeValue("href", null);
            if (href == null) return href = "";
            if (href == "/") href = domein;
            if (!href.Contains(domein))
                href = domein + href;
            if (href.Replace(domein,"").Contains("http"))
                href = domein;
            return href;
        }

        public ElementEntity  creator(HtmlNode node)
        {
            ElementEntity objElEntity = new ElementEntity();
            objElEntity.url = ParseHref(node);
            objElEntity.tag = ParseTag(node);
            return objElEntity;
        }

        public void recursAdd(string url)
        {
            foreach (var elA in ParseElemsA(url))
            {
                if (!AllUrl.ContainsValue(ParseHref(elA)))
                {
                    AllUrl.Add(creator(elA), ParseHref(elA));
                    recursAdd(ParseHref(elA));
                    //foreach (var elemA in ParseElemsA(url))
                    //{
                    //    var url1 = ParseHref(elemA);
                    //    var En = AllUrl.Keys.Select(entity => entity).Where(k => k.url == url1);
                    //    ElementEntity s =  En.First();
                    //}
                }
            }
        }

        public void setGenerals()
        {
            foreach (var key in AllUrl.Keys)
            {
                foreach (var elemA in ParseElemsA(key.url))
                {
                    var url = ParseHref(elemA);

                    key.generals.Add(AllUrl.Keys.Select(entity => entity).Where(k => k.url == url).FirstOrDefault());
                    //key.generals.Add(AllUrl.Keys.Where(entity =>entity.url==ParseHref(elemA)).First()
                    //    );
                    
                    //    //AllUrl.Keys.Select(entity => entity)
                    //    //.Where(entity => entity.url == ParseHref(elemA))
                    //    //.First());
                }
            }
        }

        //public ElementEntity getParrent(ElementEntity objElementEntity)
        //{

        //    return AllUrl.Keys.Select(entity => entity)
        //        .Where()

        //public void setParent()
        //{
        //    foreach (var elUrl in AllUrl)
        //    {
        //        elUrl.Key.parent
        //    }
        //}

        
    }
}
