﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    public class OrganizationalUnit
    {
        public int id { get; set; }
        public string name { get; set; }
        public int overseer { get; set; }

        public OrganizationalUnit(int id, string name, int overseer)
        {
            this.id = id;
            this.name = name;
            this.overseer = overseer;
        }

        public OrganizationalUnit(int id, int overseer)
        {
            this.id = id;
            this.overseer = overseer;
        }
    }
}