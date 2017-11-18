using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CsQuery;
using CsQuery.ExtensionMethods.Internal;
using CsQuery.Implementation;
using HtmlAgilityPack;

namespace TreeBuilderOfSites
{
    public class BLL
    {
        public Dictionary<ElementEntity, string> AllUrl = new Dictionary<ElementEntity, string>();
        ElementEntity FirstObj;
        public string domein { get; set; }

        public BLL( )
        {
        }

        public IEnumerable<HtmlNode> ParseElemsA(string url)
        {
            try
            {
                var doc = new HtmlWeb().Load(url);
                var linkTags = doc.DocumentNode.Descendants("link");
                var linkedPages = doc.DocumentNode.Descendants("a");
                return linkedPages;
            }
            catch (Exception e)
            {
                throw new Exception("Url is not correct", e);
            }
        }

        public string ParseTag(HtmlNode node)
        {
            string tag = node.InnerText;
            tag = tag.ToUpper();
            return tag;
        }

        public string ParseHref(HtmlNode node)
        {
            try
            {
                Uri root = new Uri(domein);
                string href = node.GetAttributeValue("href", null);
                if (href.StartsWith("javascript", StringComparison.InvariantCultureIgnoreCase)); // ignore javascript on buttons using a tags
                else
                {
                    Uri urlNext = new Uri(href, UriKind.RelativeOrAbsolute);
                    if (!urlNext.IsAbsoluteUri)
                    {
                        urlNext = new Uri(root, urlNext);
                    }
                    href = urlNext.ToString();
                }

                if (href.IsNullOrEmpty()) return null;
                if (href == "/") href = domein;
                if (!href.Contains(domein))
                {
                    if (href.First() == '/')
                        href = href.Remove(0, 1);
                    href = domein + href;
                }
                if (href.Replace(domein, "").Contains("http"))
                    return null;
                if (href.Contains("forum")) return null;
                return href;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ElementEntity creator(HtmlNode node)
        {
            ElementEntity objElEntity = new ElementEntity();
            objElEntity.url = ParseHref(node);
            objElEntity.tag = ParseTag(node);
            return objElEntity;
        }

        public void recursAdd(string url)
        {
            if (!url.Contains("docx") || url.Contains("xmlx")) 
                foreach (var elA in ParseElemsA(url))
            {
                if (!AllUrl.ContainsValue(elA.GetAttributeValue("href", null)))
                {
                    var urlEd = ParseHref(elA);

                    if (urlEd.IsNullOrEmpty()||ParseTag(elA).IsNullOrEmpty()) continue;

                    AllUrl.Add(creator(elA), elA.GetAttributeValue("href", null));
                    recursAdd(urlEd);
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
                    if (!url.IsNullOrEmpty())
                        key.generals.Add(
                            AllUrl.Keys.Select(entity => entity)
                            .Where(k => k.url == url)
                            .FirstOrDefault()
                            );
                }
            }
        }

        public void setParent()
        {
            foreach (var key in AllUrl.Keys)
            {
                key.parent = AllUrl.Keys
                    .Where(entity => entity.generals.Contains(key)
                ).FirstOrDefault(); 
            }
        }
    }   
}
