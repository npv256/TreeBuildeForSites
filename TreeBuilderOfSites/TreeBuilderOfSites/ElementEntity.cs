using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBuilderOfSites
{
    public class ElementEntity
    {
        public ElementEntity()
        {
            
        } 

        public string url { get; set; }

        public string tag { get; set; }

        public ElementEntity parent { get; set; }

        public List<ElementEntity> generals { get; set; }
    }
}
