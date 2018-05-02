using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Constants
{

    public class DbAWSConnectionInfo : IDbAWSConnectionInfo
    {
        private readonly string dbPassword = "password321";

        public string getDbPassword() {
            return dbPassword
        }
    }
}
