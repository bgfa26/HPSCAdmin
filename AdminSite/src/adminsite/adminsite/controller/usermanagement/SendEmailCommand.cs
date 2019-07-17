using adminsite.common.entities;
using adminsite.model.emailservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.usermanagement
{
    /// <summary>
    /// Clase que hereda de la clase abstracta Command usada para realizar el proceso de obtener la informacion de un empleado
    /// </summary>
    public class SendEmailCommand : Command
    {
        Employee employee;
        private string hexCode;
        private static Random random = new Random();

        public SendEmailCommand(Employee employee)
        {
            this.employee = employee;
        }


        /// <summary>
        /// Metodo que genera un codigo aleatorio
        /// </summary>
        /// <returns>Retorna un string</returns>
        /// <param name="digits">Cantidad de digitos que tendrá el codigo generado</param>
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

        /// <summary>
        /// Metodo que retorna el codigo hexadecimal generado
        /// </summary>
        /// <returns>Retorna un string</returns>
        public string GetHexCode()
        {
            return hexCode;
        }
    }
}