using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gostinka
{
    internal class DataPointItem
    {
        public double Key { get; set; }
        public string Value { get; set; }

        public DataPointItem(double key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
