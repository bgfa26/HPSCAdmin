﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace adminsite.model.statistics {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StatisticsResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StatisticsResources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("adminsite.model.statistics.StatisticsResources", typeof(StatisticsResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a GET_TOTAL_HOURS_PER_ORGANIZATIONAL_UNIT.
        /// </summary>
        internal static string GetHoursPerOUStoredProcedure {
            get {
                return ResourceManager.GetString("GetHoursPerOUStoredProcedure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a GET_TOTAL_HOUR_PER_DAY.
        /// </summary>
        internal static string GetTotalHoursPerDayStoredProcedure {
            get {
                return ResourceManager.GetString("GetTotalHoursPerDayStoredProcedure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a GET_TOTAL_HOURS_BY_MONTH.
        /// </summary>
        internal static string GetTotalHoursPerMonthStoredProcedure {
            get {
                return ResourceManager.GetString("GetTotalHoursPerMonthStoredProcedure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a GET_ALL_ACCOUNTS_COURSES_PERMITS_BY_MONTH.
        /// </summary>
        internal static string GetTotalHoursPerOrganizationalUnit {
            get {
                return ResourceManager.GetString("GetTotalHoursPerOrganizationalUnit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a GET_YEARS_BY_MONTH.
        /// </summary>
        internal static string GetYearsByMonthStoredProcedure {
            get {
                return ResourceManager.GetString("GetYearsByMonthStoredProcedure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a @month.
        /// </summary>
        internal static string month {
            get {
                return ResourceManager.GetString("month", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a @year.
        /// </summary>
        internal static string year {
            get {
                return ResourceManager.GetString("year", resourceCulture);
            }
        }
    }
}
