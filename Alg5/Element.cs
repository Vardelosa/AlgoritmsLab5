using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg5
{
    public class Element
    {
        public string Value { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Element(string t, string n, string v)
        {
            Type = t;
            Name = n;
            Value = v;
        }
        public override string ToString()
        {
            string s = "Type: "+Type+"  Name: "+Name+"  Value: "+Value+"\n";
            return s;
        }
        public string Memory { get; set; }
    }
}
