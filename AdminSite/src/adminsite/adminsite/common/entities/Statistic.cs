using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    public class Statistic : IEquatable<Statistic>
    {
        public string title { get; set; }
        public double value { get; set; }

        public Statistic(string title, double value)
        {
            this.title = title;
            this.value = value;
        }

        public bool Equals(Statistic other)
        {
            return this.title.Equals(other.title);
        }
    }
}