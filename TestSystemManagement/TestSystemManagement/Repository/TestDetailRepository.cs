using Microsoft.Office.Interop.Word;
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
            var testDetails = new TestDetail();
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
                return new JsonResult {Data = false};
            }

            return new JsonResult {Data = true};
        }

        public JsonResult UpdateTextQuestion(int id, string testDetail)
        {
            dynamic data = JsonConvert.DeserializeObject(testDetail);
            var testDetails = new TestDetail();
            try
            {
                foreach (var item in data)
                {
                    testDetails.Id = id;
                    testDetails.Question = item.Question;
                    testDetails.AnswerA = item.AnswerA;
                    testDetails.AnswerB = item.AnswerB;
                    testDetails.AnswerC = item.AnswerC;
                    testDetails.AnswerD = item.AnswerD;
                    testDetails.CorrectAnswer = string.Join(",", item.CorrectAnswer);
                    testDetails.TestChildSubjectId = item.TestChildSubjectId;
                    testDetails.Point = 0.25;
                    testDetails.TypeOfQuestion = Convert.ToInt32(item.TypeOfQuestion);
                    _db.Entry(testDetails).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return new JsonResult {Data = false};
            }

            return new JsonResult {Data = true};
        }

        public JsonResult DeleteQuestion(string id)
        {
            var questionId = int.Parse(id);
            try
            {
                var questionRemove = _db.TestDetails.SingleOrDefault(data => data.Id == questionId);
                _db.TestDetails.Remove(questionRemove);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return new JsonResult {Data = false};
            }

            return new JsonResult {Data = true};
        }

        public JsonResult QuestionDetailSearch(string id)
        {
            if (string.IsNullOrEmpty(id)) return new JsonResult {Data = false};
            var questionId = int.Parse(id);
            var result = _db.TestDetails.SingleOrDefault(x => x.Id.Equals(questionId));
            return new JsonResult {Data = result};
        }

        public JsonResult QuestionSearch(string id)
        {
            if (string.IsNullOrEmpty(id)) return new JsonResult {Data = false};
            var result = _db.TestDetails.Where(x => x.TestChildSubjectId.Equals(id)).ToList();
            return new JsonResult {Data = result};
        }

        public JsonResult UploadExcelFile(string file)
        {
            if (file == null) return new JsonResult {Data = false};
            var connectionString = new StringBuilder();
            connectionString.AppendFormat(
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0};Extended Properties = Excel 8.0", file);
            var sqlConnectionString = Helper.ConnectionString;
            var connection = new OleDbConnection(connectionString.ToString());
            try
            {
                var command = new OleDbCommand("Select * from [Sheet1$]", connection);
                connection.Open();
                DbDataReader dr = command.ExecuteReader();
                var bulkCopy = new SqlBulkCopy(sqlConnectionString) {DestinationTableName = Helper.TableDetails};
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
            return new JsonResult {Data = true};
        }

        public JsonResult UploadTextFile(string file)
        {
            var testDetail = new TestDetail();
            try
            {
                var data = File.ReadAllLines(file);
                for (var i = 0; i < data.Length; i++)
                {
                    if (data[i].Trim() == string.Empty) continue;
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
            catch (Exception exception)
            {
                return new JsonResult {Data = false};
            }

            return new JsonResult {Data = true};
        }

        public JsonResult UploadWordFile(string file)
        {
            var app = new Application();
            var testDetail = new TestDetail();
            object readOnly = false;
            object isVisible = true;
            object filename = file;
            object missing = System.Reflection.Missing.Value;

            try

            {
                var doc = app.Documents.Open(ref filename, ref missing, ref readOnly, ref missing, ref missing,
                    ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
                var stringData = doc.Content.Text;
                var arrayData = stringData.Split('\r');
                for (var i = 0; i < arrayData.Length; i++)
                {
                    if (arrayData[i] == string.Empty) continue;
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
            catch (Exception ex)
            {
                return new JsonResult {Data = false};
            }
            return new JsonResult {Data = true};
        }

        public JsonResult DownloadQuestion(List<TestDetail> testDetail)
        {
            //Create an instance for word app
            Application winword = new Microsoft.Office.Interop.Word.Application();

            //Set animation status for word application
            winword.ShowAnimation = false;

            //Set status for word application is to be visible or not.
            winword.Visible = false;

            //Create a missing variable for missing value
            object missing = System.Reflection.Missing.Value;

            //Create a new document
            Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            //Add header into the document
            foreach (Section section in document.Sections)
            {
                //Get the header range and add the header details.
                Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                headerRange.Font.ColorIndex = WdColorIndex.wdBlue;
                headerRange.Font.Size = 10;
                headerRange.Text = "Đề Thi Tổng Hợp";
            }
            //document.Content.SetRange(0, 0);
            //document.Content.Text = "This is test document " + Environment.NewLine;

            ////Add paragraph with Heading 1 style
            //Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            //object styleHeading1 = "Heading 1";
            //para1.Range.set_Style(ref styleHeading1);
            //para1.Range.Text = "Para 1 text";
            //para1.Range.InsertParagraphAfter();

            ////Add paragraph with Heading 2 style
            //Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
            //object styleHeading2 = "Heading 2";
            //para2.Range.set_Style(ref styleHeading2);
            //para2.Range.Text = "Para 2 text";
            //para2.Range.InsertParagraphAfter();
            foreach (var docx in testDetail)
            {
                Paragraph para = document.Content.Paragraphs.Add(ref missing);
                object styleHeading = "Heading 2";
                para.Range.set_Style(ref styleHeading);
                para.Range.Text = docx.Question;
                para.Range.InsertParagraphAfter();
                para.Range.Text = docx.AnswerA;
                para.Range.InsertParagraphAfter();
                para.Range.Text = docx.AnswerB;
                para.Range.InsertParagraphAfter();
                para.Range.Text = docx.AnswerC;
                para.Range.InsertParagraphAfter();
                para.Range.Text = docx.AnswerD;
                para.Range.InsertParagraphAfter();
            }
            object filename = @"E:\Source Code\Study\Test-System\DB Design\dethi.docx";
            document.SaveAs2(ref filename);
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;
            return new JsonResult {Data = true};
        }
    }
}