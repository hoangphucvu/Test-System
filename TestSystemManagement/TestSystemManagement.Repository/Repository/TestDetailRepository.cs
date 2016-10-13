using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TestSystemManagement.Repository.Interfaces;
using TestSystemManagement.Repository.Models;

namespace TestSystemManagement.Repository.Repository
{
    public class TestDetailRepository : ITestDetailRepository
    {
        private readonly TestSystemManagementEntities _context = new TestSystemManagementEntities();

        public JsonResult UploadExcelFile()
        {
            throw new NotImplementedException();
        }

        public JsonResult UploadTextFile(string file)
        {
            try
            {
                string tableName = "TestDetails";
                //provide the file delimiter such as comma,pipe
                string filedelimiter = ",";
                SqlConnection SQLConnection = new SqlConnection();
                SQLConnection.ConnectionString = "Data Source=.; persist security info=True; " +
                                                 "Initial Catalog=TestSystemManagementDB;" +
                                                 "Integrated Security=SSPI";
                System.IO.StreamReader sourceFileReader = new StreamReader(file);

                string line = "";

                SQLConnection.Open();
                while ((line = sourceFileReader.ReadLine()) != null)
                {
                    string query = "Insert into " + tableName +
                               " Values ('" + line.Replace(filedelimiter, "','") + "')";
                    SqlCommand command = new SqlCommand(query, SQLConnection);
                    command.ExecuteNonQuery();
                }
                sourceFileReader.Close();
                SQLConnection.Close();
            }
            catch (IOException Exception)
            {
                Console.Write(Exception);
            }
            return new JsonResult { Data = new { Message = "ok" } };
        }

        public JsonResult UploadWordFile()
        {
            throw new NotImplementedException();
        }
    }
}