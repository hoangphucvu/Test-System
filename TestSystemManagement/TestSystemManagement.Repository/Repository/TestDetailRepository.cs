using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using TestSystemManagement.Core;
using TestSystemManagement.Repository.Config;
using TestSystemManagement.Repository.Interfaces;
using TestSystemManagement.Repository.Models;

namespace TestSystemManagement.Repository.Repository
{
    [AllowCrossSite]
    public class TestDetailRepository : ITestDetailRepository
    {
        private TestSystemManagementEntities _db = new TestSystemManagementEntities();

        public JsonResult ImportTextQuestion(object[] testDetail)
        {
            TestDetail testDetailData = new TestDetail();
            int i = 0;
            if (testDetail != null)
            {
                while (i < testDetail.Length)
                {
                    testDetailData.Question = testDetail[i].ToString();
                    i++;
                    testDetailData.AnswerA = testDetail[i].ToString();
                    i++;
                    testDetailData.AnswerB = testDetail[i].ToString();
                    i++;
                    testDetailData.AnswerC = testDetail[i].ToString();
                    i++;
                    testDetailData.AnswerD = testDetail[i].ToString();
                    i++;
                    testDetailData.CorrectAnswer = testDetail[i].ToString();
                    i++;
                    testDetailData.TypeOfQuestion = ((IConvertible)testDetail[i]).ToInt32(null);
                    i++;
                    testDetailData.Point = ((IConvertible)testDetail[i]).ToDouble(null);
                    i++;
                    _db.TestDetails.Add(testDetailData);
                    _db.SaveChanges();
                }
                return new JsonResult { Data = true };
            }

            return new JsonResult { Data = false };
        }

        public JsonResult UploadExcelFile(string file)
        {
            if (file != null)
            {
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {file};Extended Properties = Excel 8.0";
                var sqlConnectionString = Helper.ConnectionString;
                OleDbConnection connection = new OleDbConnection(connectionString);
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
                    //const string columnNames = "Question,AnswerA,AnswerB,AnswerC,AnswerD,CorrectAnswer,TypeOfQuestion,Point,TestChildSubjectId,UserId,ResultId";
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