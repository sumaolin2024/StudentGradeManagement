using System;
using System.Web;

namespace StudentGradeMS
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                System.Diagnostics.Debug.WriteLine("Application Error: " + ex.Message);
            }
        }
    }
}
