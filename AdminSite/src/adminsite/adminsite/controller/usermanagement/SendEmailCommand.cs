﻿using adminsite.common;
using adminsite.model.emailservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{
    public class SendEmailCommand : Command
    {
        Employee employee;
        private string hexCode;
        private static Random random = new Random();

        public SendEmailCommand(Employee employee)
        {
            this.employee = employee;
        }

        private static string GenerateCode(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = string.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

        public override void Execute()
        {
            try
            {
                hexCode = GenerateCode(6);
                EmailService emailService = new EmailService();
                emailService.SendVerificationCode(employee, hexCode);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetHexCode()
        {
            return hexCode;
        }
    }
}