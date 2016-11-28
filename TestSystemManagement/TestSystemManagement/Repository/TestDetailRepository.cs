﻿using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
            TestDetail testDetail = new TestDetail();
            try
            {
                var data = File.ReadAllLines(file);
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Trim() != string.Empty)
                    {
                        testDetail.Question = data[i];
                        i++;
                        testDetail.AnswerA = data[i];
                        i++;
                        testDetail.AnswerB = data[i];
                        i++;
                        testDetail.AnswerC = data[i];
                        i++;
                        testDetail.AnswerD = data[i];
                        i++;
                        testDetail.CorrectAnswer = data[i];
                        testDetail.Point = 0.25;
                        _db.TestDetails.Add(testDetail);
                        _db.SaveChanges();
                        i++;
                    }
                }
            }
            catch (Exception exception)
            {
                return new JsonResult { Data = false };
            }

            return new JsonResult { Data = true };
        }

        public JsonResult UploadWordFile(string file)
        {
            //Creating the instance of Word Application
            //Application word = new Application();
            //Document doc = new Document();

            //object fileName = file;
            //// Define an object to pass to the API for missing parameters
            //object missing = System.Type.Missing;
            //doc = word.Documents.Open(ref fileName,
            //        ref missing, ref missing, ref missing, ref missing,
            //        ref missing, ref missing, ref missing, ref missing,
            //        ref missing, ref missing, ref missing, ref missing,
            //        ref missing, ref missing, ref missing);

            //TestDetail testDetail = new TestDetail();
            //for (int i = 0; i < doc.Paragraphs.Count; i++)
            //{
            //    string textValue = doc.Paragraphs[i + 1].Range.Text.Trim();
            //    if (textValue != string.Empty)
            //    {
            //        testDetail.Question = textValue;
            //        i++;
            //        testDetail.AnswerA = textValue;
            //        i++;
            //        testDetail.AnswerB = textValue;
            //        i++;
            //        testDetail.AnswerC = textValue;
            //        i++;
            //        testDetail.AnswerD = textValue;
            //        i++;
            //        testDetail.CorrectAnswer = textValue;
            //        testDetail.Point = 0.25;
            //        _db.TestDetails.Add(testDetail);
            //        _db.SaveChanges();
            //        i++;
            //    }
            //}
            object filename = file;

            //Initiating Application Class

            Application app = new Application();

            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            TestDetail testDetail = new TestDetail();
            object readOnly = false;

            object isVisible = true;

            object missing = System.Reflection.Missing.Value;

            //Reating the word document and adding it to textbox
            try

            {
                doc = app.Documents.Open(ref filename, ref missing, ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
                var stringData = doc.Content.Text;
                var arrayData = stringData.Split('\r');
                for (int i = 0; i < arrayData.Length; i++)
                {
                    if (arrayData[i] != string.Empty)
                    {
                        testDetail.Question = arrayData[i];
                        i++;
                        testDetail.AnswerA = arrayData[i];
                        i++;
                        testDetail.AnswerB = arrayData[i];
                        i++;
                        testDetail.AnswerC = arrayData[i];
                        i++;
                        testDetail.AnswerD = arrayData[i];
                        i++;
                        testDetail.CorrectAnswer = arrayData[i];
                        testDetail.Point = 0.25;
                        _db.TestDetails.Add(testDetail);
                        _db.SaveChanges();
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = false };
            }
            return new JsonResult { Data = true };
        }
    }
}