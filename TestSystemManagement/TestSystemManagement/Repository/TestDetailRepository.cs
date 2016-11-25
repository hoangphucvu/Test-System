using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Mime;
using System.Text;
using System.Web.Mvc;
using TestSystemManagement.Config;
using TestSystemManagement.Interfaces;
using TestSystemManagement.Models;

namespace TestSystemManagement.Repository
{
    public class TestDetailRepository : ITestDetailRepository
    {
        private readonly TestSystemManagementEntities _db = new TestSystemManagementEntities();

        public JsonResult ImportTextQuestion(string testDetail)
        {
            dynamic data = JsonConvert.DeserializeObject(testDetail);
            TestDetail testDetails = new TestDetail();
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
            return new JsonResult { Data = false };
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
            //provide the file delimiter such as comma,pipe
            const string filedelimiter = ",";
            var sqlConnection = new SqlConnection { ConnectionString = Helper.ConnectionString };
            var sourceFileReader = new StreamReader(file);
            try
            {
                sqlConnection.Open();
                string line;

                while ((line = sourceFileReader.ReadLine()) != null)
                {
                    var query = $"Insert into {Helper.TableDetails} Values ('{line.Replace(filedelimiter, "','")}')";
                    var command = new SqlCommand(query, sqlConnection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sourceFileReader.Close();
                sqlConnection.Close();
            }
            return new JsonResult { Data = true };
        }

        public JsonResult UploadWordFile(string file)
        {
            var word = new Application();
            object fileName = file;
            const string filedelimiter = ",";
            // Define an object to pass to the API for missing parameters
            var missing = Type.Missing;
            var docs = word.Documents.Open(ref fileName,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing);

            var sqlConnection = new SqlConnection { ConnectionString = Helper.ConnectionString };
            try
            {
                sqlConnection.Open();
                for (var i = 0; i < docs.Paragraphs.Count - 1; i++)
                {
                    var totaltext = docs.Paragraphs[i + 1].Range.Text;
                    var query = $"Insert into {Helper.TableDetails} Values ('{totaltext.Replace(filedelimiter, "','")}')";
                    var command = new SqlCommand(query, sqlConnection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                docs.Close();
                word.Quit();
                sqlConnection.Close();
            }

            return new JsonResult { Data = true };
        }
    }
}