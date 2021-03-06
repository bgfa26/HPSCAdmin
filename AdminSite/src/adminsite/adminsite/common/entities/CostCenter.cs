﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    /// <summary>
    /// Objeto para almacenar la informacion de los centros de costo
    /// </summary>
    public class CostCenter
    {
        public int fk_ou { get; set; }
        public string fk_acp { get; set; }
        public OrganizationalUnit organizationalUnit { get; set; }

        public CostCenter(int fk_ou, string fk_acp)
        {
            this.fk_ou = fk_ou;
            this.fk_acp = fk_acp;
        }

        public CostCenter(OrganizationalUnit organizationalUnit, string fk_acp)
        {
            this.organizationalUnit = organizationalUnit;
            this.fk_acp = fk_acp;
        }
    }
}