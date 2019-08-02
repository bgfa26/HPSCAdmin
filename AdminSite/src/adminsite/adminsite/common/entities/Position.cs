using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    /// <summary>
    /// Objeto para almacenar la informacion de los cargos de la empresa
    /// </summary>
    public class Position
    {
        public int id { get; set; }
        public string name { get; set; }

        public Position(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}