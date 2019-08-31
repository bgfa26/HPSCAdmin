using Nager.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace adminsite.common.entities
{
    public class Holiday
    {
        public string name { get; set; }
        public DateTime date { get; set; }

        public Holiday(){}

        public Holiday(string name, DateTime date)
        {
            this.name = name;
            this.date = date;
        }

        public List<Holiday> getHolidaysNameVenezuela()
        {
            int year = DateTime.Now.Year;
            List<Holiday> holidays = new List<Holiday>();
            string path = HttpContext.Current.Server.MapPath(@"~/site/employees/holiday.xml");
            XmlTextReader reader = new XmlTextReader(path);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text: //Display the text in each element.
                        string name = reader.Value.Split(';')[0];
                        string dateString = year + "/" + reader.Value.Split(';')[1];
                        DateTime date = Convert.ToDateTime(dateString);
                        Holiday holiday = new Holiday(name, date);
                        holidays.Add(holiday);
                        break;
                }
            }
            holidays = GetHolyWeekAndCarnival(holidays);
            return holidays;
        }



        protected List<Holiday> GetHolyWeekAndCarnival(List<Holiday> holidays)
        {
            DateTime postCarnivalWed = new DateTime();
            var publicHolidays = DateSystem.GetPublicHoliday(DateTime.Now.Year, "VE");
            foreach (var publicHoliday in publicHolidays)
            {
                if (publicHoliday.LocalName.Equals("Carnaval"))
                {
                    Holiday holiday = new Holiday(publicHoliday.LocalName, publicHoliday.Date);
                    holidays.Add(holiday);
                    postCarnivalWed = publicHoliday.Date.AddDays(1);
                }
            }
            Holiday holyThursday = new Holiday("Jueves santo", postCarnivalWed.AddDays(43));
            Holiday holyFriday = new Holiday("Viernes santo", postCarnivalWed.AddDays(44));
            holidays.Add(holyThursday);
            holidays.Add(holyFriday);
            return holidays;
        }
    }
}