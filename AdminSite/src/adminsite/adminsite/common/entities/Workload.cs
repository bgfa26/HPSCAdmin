﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common.entities
{
    public class Workload
    {
        public int id { get; set; }
        public int day1 { get; set; }
        public int day2 { get; set; }
        public int day3 { get; set; }
        public int day4 { get; set; }
        public int day5 { get; set; }
        public int day6 { get; set; }
        public int day7 { get; set; }
        public int day8 { get; set; }
        public int day9 { get; set; }
        public int day10 { get; set; }
        public int day11 { get; set; }
        public int day12 { get; set; }
        public int day13 { get; set; }
        public int day14 { get; set; }
        public int day15 { get; set; }
        public int day16 { get; set; }
        public Timesheet timesheet { get; set; }
        public AccountCoursePermit accountCoursePermit { get; set; }

        public Workload() { }

        public Workload(int id, int day1, int day2, int day3, int day4, int day5, int day6, int day7, int day8, int day9,
                        int day10, int day11, int day12, int day13, int day14, int day15, int day16, Timesheet timesheet,
                        AccountCoursePermit accountCoursePermit)
        {
            this.id = id;
            this.day1 = day1;
            this.day2 = day2;
            this.day3 = day3;
            this.day4 = day4;
            this.day5 = day5;
            this.day6 = day6;
            this.day7 = day7;
            this.day8 = day8;
            this.day9 = day9;
            this.day10 = day10;
            this.day11 = day11;
            this.day12 = day12;
            this.day13 = day13;
            this.day14 = day14;
            this.day15 = day15;
            this.day16 = day16;
            this.timesheet = timesheet;
            this.accountCoursePermit = accountCoursePermit;
        }

        public Workload(int day1, int day2, int day3, int day4, int day5, int day6, int day7, int day8, int day9,
                        int day10, int day11, int day12, int day13, int day14, int day15, int day16, Timesheet timesheet,
                        AccountCoursePermit accountCoursePermit)
        {
            this.day1 = id;
            this.day2 = id;
            this.day3 = id;
            this.day4 = id;
            this.day5 = id;
            this.day6 = id;
            this.day7 = id;
            this.day8 = id;
            this.day9 = id;
            this.day10 = id;
            this.day11 = id;
            this.day12 = id;
            this.day13 = id;
            this.day14 = id;
            this.day15 = id;
            this.day16 = id;
            this.timesheet = timesheet;
            this.accountCoursePermit = accountCoursePermit;
        }

        public int TotalHoursPerACP()
        {
            return (this.day1 + this.day2 + this.day3 + this.day4 + this.day5 + this.day6 + this.day7 + this.day8 +
                    this.day9 + this.day10 + this.day11 + this.day12 + this.day13 + this.day14 + this.day15 + this.day16);
        }
    }
}