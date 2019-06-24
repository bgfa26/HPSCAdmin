using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common
{
    public class ResultDB
    {
        public string tag { get; set; }
        public string value { get; set; }

        public ResultDB(string _tag, string _value)
        {
            this.tag = _tag;
            this.value = _value;
        }
    }
}