using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;

namespace Flock
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        internal static string CopyrightNotice
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                AssemblyCopyrightAttribute notice = AssemblyDescriptionAttribute.GetCustomAttribute(
                        assembly, typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute;
                if (notice != null)
                {
                    return notice.Copyright;
                }
                else
                {
                    return string.Empty;
                }
            }
        }


        internal static string Version
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(assembly.Location);
                if (info != null)
                {
                    return string.Format("{0}.{1}.{2}", info.ProductMajorPart,
                        info.ProductMinorPart, info.ProductBuildPart);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
