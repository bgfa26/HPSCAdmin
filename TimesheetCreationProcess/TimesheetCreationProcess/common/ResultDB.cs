using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetCreationProcess.common
{
    /// <summary>
    /// Objeto para almacenar la respuesta dada por la BD
    /// </summary>
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
