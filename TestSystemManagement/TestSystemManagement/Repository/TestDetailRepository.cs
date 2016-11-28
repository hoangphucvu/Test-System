using Newtonsoft.Json;
using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.Mvc;
using TestSystemManagement.Config;
using TestSystemManagement.Interfaces;
using TestSystemManagement.Models;
using Word = Microsoft.Office.Interop.Word;

namespace TestSystemManagement.Repository
{
    public class TestDetailRepository : ITestDetailRepository
    {
        private readonly TestSystemManagementEntities _db = new TestSystemManagementEntities();

        public JsonResult ImportTextQuestion(string testDetail)
        {
            dynamic data = JsonConvert.DeserializeObject(testDetail);
            TestDetail testDetails = new TestDetail();
            try
            {
                foreach (var item in data)
                {
                    testDetails.Question = item.Question;
                    testDetails.AnswerA = item.AnswerA;
                    testDetails.AnswerB = item.AnswerB;
                    testDetails.AnswerC = item.AnswerC;
                    testDetails.AnswerD = item.AnswerD;
                    testDetails.CorrectAnswer = string.Join(",", item.CorrectAnswer);
                    testDetails.TestChildSubjectId = item.TestChildSubjectId;
                    testDetails.Point = 0.25;
                    testDetails.TypeOfQuestion = Convert.ToInt32(item.TypeOfQuestion);
                    _db.TestDetails.Add(testDetails);
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return new JsonResult { Data = false };
            }

            return new JsonResult { Data = true };
        }

        public JsonResult UploadExcelFile(string file)
        {
            if (file != null)
            {
                var connectionString = new StringBuilder();
                connectionString.AppendFormat(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0};Extended Properties = Excel 8.0", file);
                var sqlConnectionString = Helper.ConnectionString;
                OleDbConnection connection = new OleDbConnection(connectionString.ToString());
                try
                {
                    var command = new OleDbCommand("Select * from [Sheet1$]", connection);
                    connection.Open();
                    DbDataReader dr = command.ExecuteReader();
                    var bulkCopy = new SqlBulkCopy(sqlConnectionString) { DestinationTableName = Helper.TableDetails };
                    if (dr != null) bulkCopy.WriteToServer(dr);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
                return new JsonResult { Data = true };
            }

            return new JsonResult { Data = false };
        }

        public JsonResult UploadTextFile(string file)
        {
            var data = File.ReadAllLines("D:\\Data\\import.txt");
            foreach (var docs in data)
            {
                var text = docs.TrimEnd();
                System.Diagnostics.Debug.Write(text);
            }
            //provide the file delimiter such as comma,pipe
            const string filedelimiter = "!";
            //var sqlConnection = new SqlConnection { ConnectionString = Helper.ConnectionString };
            //var sourceFileReader = new StreamReader(file);
            //try
            //{
            //    sqlConnection.Open();
            //    string line;

            //    while ((line = sourceFileReader.ReadLine()) != null)
            //    {
            //        var query = $"Insert into {Helper.TableDetails} Values ('{line.Replace(filedelimiter, "','")}')";
            //        var command = new SqlCommand(query, sqlConnection);
            //        command.ExecuteNonQuery();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    sourceFileReader.Close();
            //    sqlConnection.Close();
            //}
            return new JsonResult { Data = true };
        }

        public JsonResult UploadWordFile(string file)
        {
            //Creating the instance of Word Application
            var data = File.ReadAllLines("D:\\Data\\import.docx");
            foreach (var docs in data)
            {
                var text = docs.TrimEnd();
                System.Diagnostics.Debug.Write(text);
            }
            return new JsonResult { Data = true };
        }
    }
}