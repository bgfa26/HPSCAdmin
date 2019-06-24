using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace adminsite.common
{
    public class ParameterDB
    {
        public string tag { get; set; }
        public SqlDbType dataType { get; set; }
        public string value { get; set; }
        public bool itsOutput { get; set; }

        public ParameterDB()
        {
        }

        public ParameterDB(string _tag, SqlDbType _dataType, string _value, bool _itsOutput)
        {
            this.tag = _tag;
            this.dataType = _dataType;
            this.value = _value;
            this.itsOutput = _itsOutput;
        }
        public ParameterDB(string _tag, SqlDbType _dataType, bool _itsOutput)
        {
            this.tag = _tag;
            this.dataType = _dataType;
            this.itsOutput = _itsOutput;
        }
    }
}