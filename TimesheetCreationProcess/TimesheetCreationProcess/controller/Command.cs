using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetCreationProcess.controller
{
    /// <summary>
    /// Clase abstracta Command, todos los comandos deben heredar de ella
    /// </summary>
    abstract public class Command
    {
        /// <summary>
        /// Metodo que se encarga de ejecutar una accion.
        /// </summary>
        abstract public void Execute();
    }
}
