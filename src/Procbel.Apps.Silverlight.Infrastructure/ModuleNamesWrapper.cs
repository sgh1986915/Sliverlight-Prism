using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Infrastructure
{
    /// <summary>
    /// Exposes ModuleNames' constants as properties - needed in XAML files, as we cannot use static/constants there.
    /// </summary>
    public class ModuleNamesWrapper
    {
        public static string ContactsModule
        {
            get
            {
                return ModuleNames.ContactsModule;
            }
        }

        public static string OpportunitiesModule
        {
            get
            {
                return ModuleNames.OpportunitiesModule;
            }
        }

        public static string CompaniesModule
        {
            get
            {
                return ModuleNames.CompaniesModule;
            }
        }

        public static string DashboardModule
        {
            get
            {
                return ModuleNames.DashboardModule;
            }
        }
        //JLSF
        public static string InicioModule
        {
            get
            {
                return ModuleNames.InicioModule;
            }
        }

        public static string IncidenciasModule
        {
            get
            {
                return ModuleNames.IncidenciasModule;
            }
        }

        public static string VentasModule
        {
            get
            {
                return ModuleNames.VentasModule;
            }
        }



        public static string ComprasModule
        {
            get
            {
                return ModuleNames.ComprasModule;
            }
        }

        public static string ProduccionModule
        {
            get
            {
                return ModuleNames.ProduccionModule;
            }
        }


        public static string ActivitiesModule
        {
            get
            {
                return ModuleNames.ActivitiesModule;
            }
        }


        public static string LogisticaModule
        {
            get
            {
                return ModuleNames.LogisticaModule;
            }
        }

        public static string RecursosHumanosModule
        {
            get
            {
                return ModuleNames.RecursosHumanosModule;
            }
        }

        public static string MantenimientoModule
        {
            get
            {
                return ModuleNames.MantenimientoModule;
            }
        }

        public static string InventarioModule
        {
            get
            {
                return ModuleNames.InventarioModule;
            }
        }

        public static string CalidadModule
        {
            get
            {
                return ModuleNames.CalidadModule;
            }
        }
    }
}
