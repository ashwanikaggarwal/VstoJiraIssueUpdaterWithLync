using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tharindu.JiraRest
{
    public class NamedEntity<T>
    {       
        public NamedEntity()
        {
            this.Value = default(T);
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public T Value { get; set; }
    }
}
