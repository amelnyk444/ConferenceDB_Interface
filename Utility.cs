using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceDB_Interface
{
    static class Utility
    {
        static Utility()
        {
            _connectionString = null;
            UserName = null;
            _userName = null;
            _password = null;
            _confId = -1;
            _sectID = -1;
            _speechID = -1;
        }

        public static string _connectionString;
        public static string UserName
        {
            get { return _userName; }
            set { if ("Reader" == value) { _password = "1237"; _userName = value; } _userName = value; }
        }
        public static string _userName;
        public static string _password;
        public static int _confId;
        public static int _sectID;
        public static int _speechID;
        public static string CreateConnectionString()
        {
            if ("Reader" == _userName) { _password = "1237"; }
            _connectionString = "Data Source=DESKTOP-QREAK8S;" + "Initial Catalog=Conference_DB;" +"User id="+_userName+";" +"Password="+_password+";";
            return _connectionString;
        }
    }
}
