﻿using adminsite.common.entities;
using adminsite.model.acp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.controller.acp
{
    public class DeleteACPCommand : Command
    {
        AccountCoursePermit acpToDelete;
        int result;
        public DeleteACPCommand(AccountCoursePermit acpToDelete)
        {
            this.acpToDelete = acpToDelete;
        }

        public override void Execute()
        {
            try
            {
                DAOAccountCoursePermit dao = new DAOAccountCoursePermit();
                result = dao.DeleteAccountCoursePermit(acpToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo que retorna el resultado obtenido en la BD
        /// </summary>
        /// <returns>Retorna un entero</returns>
        public int GetResult()
        {
            return result;
        }
    }
}