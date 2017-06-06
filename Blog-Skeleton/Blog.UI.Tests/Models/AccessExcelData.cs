using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Blog.UI.Tests.Models;
using Dapper;

namespace Blog.UI.Tests.Models
{

    public class AccessExcelData
    {

        public static string fileName;

        public static string TestDataFileConnection()
        {
            // var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\DataDrivenTests\\");
            var path = @"C:\Users\Petya\Documents\Visual Studio 2017\Projects\Blog\Blog-Skeleton-TeamProject\Blog-Skeleton\Blog.UI.Tests\DataDrivenTests\";
            //    var path = ConfigurationManager.AppSettings["TestDataSheetPath"];

            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", path + fileName);
            return con;
        }

        public static RegistrationUser GetRegistrationTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key = '{0}'", keyName);
                var value = connection.Query<RegistrationUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}