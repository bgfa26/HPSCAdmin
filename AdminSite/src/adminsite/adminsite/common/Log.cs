using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.common
{
    public class Log
    {
        /// <summary>
        /// Metodo que escribe mensajes de error en un log
        /// </summary>
        /// <param name="_class">Clase en la que ocurrio el error</param>
        /// <param name="ex">excepcion que ocurrio</param>
        public static void WriteError(string _class, Exception ex)
        {
            if (_class != null && ex != null && _class != "")
            {
                XmlConfigurator.Configure();
                ILog log = LogManager.GetLogger(_class);
                log.Error("*******************************************************");
                log.Error("Mensaje: " + ex.Message);
                log.Error("Origen: " + ex.Source);
                log.Error("Metodo: " + ex.TargetSite);
                log.Error("StackTrace: " + ex.StackTrace);
                log.Error("InnerException: " + ex.InnerException);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}