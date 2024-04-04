using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace gostinka
{
    internal class User
    {

        public string Login;
        public string Mail;
        public string Phone;
        private static User _instance;

        public static User Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new User();
                }
                return _instance;
                    }
        }

        public void InitUser(string Login, string Mail, string Phone)
        {
            Instance.Login = Login;
            Instance.Mail = Mail;
            Instance.Phone = Phone;
        }

        public void InitUser(string Login)
        {
            DataBaseClass database = new DataBaseClass();
            string[] strings = database.GetUserData(Login);
            InitUser(strings[0], strings[1], strings[2]);
        }

    }
}
