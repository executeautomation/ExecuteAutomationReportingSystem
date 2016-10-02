using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EARS.Utilities
{
    public class Settings
    {

        public static string  ReportingConnString { get; set; }

        public static SqlConnection ReportingConn { get; set; }

    }
}