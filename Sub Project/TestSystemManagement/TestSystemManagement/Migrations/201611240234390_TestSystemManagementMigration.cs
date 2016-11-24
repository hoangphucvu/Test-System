namespace TestSystemManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestSystemManagementMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectCode = c.String(),
                        UserId = c.String(),
                        TestDate = c.DateTime(nullable: false),
                        Total = c.Double(nullable: false),
                        TestDetailId = c.String(),
                        TestMapId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestChildSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestChildSubjectId = c.String(),
                        SubjectCode = c.String(),
                        TestChildSubjectName = c.String(),
                        TestSubjectId = c.String(),
                        TestDetailId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        AnswerA = c.String(),
                        AnswerB = c.String(),
                        AnswerC = c.String(),
                        AnswerD = c.String(),
                        CorrectAnswer = c.String(),
                        TypeOfQuestion = c.Int(nullable: false),
                        Point = c.Double(nullable: false),
                        TestChildSubjectId = c.String(),
                        UserId = c.String(),
                        ResultId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        SubjectCode = c.String(),
                        TestDetailId = c.String(),
                        ResultId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        SubjectCode = c.String(),
                        SecretCode = c.String(),
                        NoOfEasyQuestion = c.Int(nullable: false),
                        NoOfMediumQuestion = c.Int(nullable: false),
                        NoOfHardQuestion = c.Int(nullable: false),
                        TestDate = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                        TestChildSubjectId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        AccessLevel = c.Int(nullable: false),
                        TestDetailId = c.String(),
                        ResultId = c.String(),
                        TestMapId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.TestSubjects");
            DropTable("dbo.TestMaps");
            DropTable("dbo.TestDetails");
            DropTable("dbo.TestChildSubjects");
            DropTable("dbo.Results");
        }
    }
}
