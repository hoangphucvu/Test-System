using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
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
            string sqlConnectionString = @"Data Source=.; persist security info=True; " +
                                     "Initial Catalog=TestSystemManagementDB;" +
                                     "Integrated Security=SSPI";
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                OleDbCommand command = new OleDbCommand("Select * from [Sheet1$]", connection);
                connection.Open();
                DbDataReader dr = command.ExecuteReader();

                SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString);
                bulkCopy.DestinationTableName = "TestDetails";
                bulkCopy.WriteToServer(dr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return new JsonResult { Data = new { Message = "ok" } };
        }

        public JsonResult UploadTextFile(string file)
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

            try
            {
                SQLConnection.Open();
                while ((line = sourceFileReader.ReadLine()) != null)
                {
                    string query = "Insert into " + tableName +
                               " Values ('" + line.Replace(filedelimiter, "','") + "')";
                    SqlCommand command = new SqlCommand(query, SQLConnection);
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
                SQLConnection.Close();
            }
            return new JsonResult { Data = new { Message = "ok" } };
        }

        public JsonResult UploadWordFile(string file)
        {
            Application word = new Application();
            Document docs = new Document();

            object fileName = file;
            // Define an object to pass to the API for missing parameters
            object missing = System.Type.Missing;
            docs = word.Documents.Open(ref fileName,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            string tableName = "TestDetails";
            string totaltext = "";
            string filedelimiter = ",";
            SqlConnection SQLConnection = new SqlConnection();
            SQLConnection.ConnectionString = "Data Source=.; persist security info=True; " +
                                             "Initial Catalog=TestSystemManagementDB;" +
                                             "Integrated Security=SSPI";
            try
            {
                SQLConnection.Open();
                for (int i = 0; i <= docs.Paragraphs.Count - 1; i++)
                {
                    totaltext = docs.Paragraphs[i + 1].Range.Text;
                    string query = "Insert into " + tableName +
                              "(Question,AnswerA,AnswerB,AnswerC,AnswerD,CorrectAnswer,TypeOfQuestion,Point,TestChildSubjectId,UserId,ResultId) Values ('"
                              + totaltext.Replace(filedelimiter, "','") + "')";
                    SqlCommand command = new SqlCommand(query, SQLConnection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ((_Document)docs).Close();
                ((_Application)word).Quit();
                SQLConnection.Close();
            }

            return new JsonResult { Data = new { Message = "ok" } };
        }
    }
}