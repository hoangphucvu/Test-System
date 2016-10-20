using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Mvc;
using TestSystemManagement.Core;
using TestSystemManagement.Repository.Interfaces;
using TestSystemManagement.Repository.Models;

namespace TestSystemManagement.Repository.Repository
{
    [AllowCrossSite]
    public class TestDetailRepository : ITestDetailRepository
    {
        private readonly TestSystemManagementEntities db = new TestSystemManagementEntities();

        public JsonResult UploadExcelFile(string file)
        {
            string connectionString =
                string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0};Extended Properties = Excel 8.0",
                    file);
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand("Select * from [Sheet1$]", connection);
            connection.Open();
            DbDataReader dr = command.ExecuteReader();
            string sqlConnectionString = @"Data Source=.; persist security info=True; " +
                                                 "Initial Catalog=TestSystemManagementDB;" +
                                                 "Integrated Security=SSPI";
            SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString);
            bulkCopy.DestinationTableName = "TestDetails";
            bulkCopy.WriteToServer(dr);
            return new JsonResult { Data = new { Message = "ok" } };
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

        public JsonResult UploadWordFile(string file)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = file;
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            string totaltext = "";

            string tableName = "TestDetails";
            //provide the file delimiter such as comma,pipe
            string filedelimiter = ",";
            SqlConnection SQLConnection = new SqlConnection();
            SQLConnection.ConnectionString = "Data Source=.; persist security info=True; " +
                                             "Initial Catalog=TestSystemManagementDB;" +
                                             "Integrated Security=SSPI";

            SQLConnection.Open();
            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                totaltext += " \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString();
                string query = "Insert into " + tableName +
                          " Values ('" + totaltext.Replace(filedelimiter, "','") + "')";
                SqlCommand command = new SqlCommand(query, SQLConnection);
                command.ExecuteNonQuery();
            }
            SQLConnection.Close();
            return new JsonResult { Data = new { Message = "ok" } };
        }
    }
}