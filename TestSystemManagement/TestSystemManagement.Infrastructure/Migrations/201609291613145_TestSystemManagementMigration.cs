namespace TestSystemManagement.Infrastructure.Migrations
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
                        SubjectCode = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(nullable: false),
                        TestDate = c.DateTime(nullable: false),
                        Total = c.Double(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TestDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 255),
                        AnswerA = c.String(nullable: false, maxLength: 100),
                        AnswerB = c.String(nullable: false, maxLength: 100),
                        AnswerC = c.String(nullable: false, maxLength: 100),
                        AnswerD = c.String(nullable: false, maxLength: 100),
                        CorrectAnswer = c.String(maxLength: 100),
                        TypeOfQuestion = c.Int(nullable: false),
                        Point = c.Double(nullable: false),
                        TestChildSubject_Id = c.Int(),
                        User_Id = c.Int(),
                        TestMap_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestChildSubjects", t => t.TestChildSubject_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.TestMaps", t => t.TestMap_Id)
                .Index(t => t.TestChildSubject_Id)
                .Index(t => t.User_Id)
                .Index(t => t.TestMap_Id);
            
            CreateTable(
                "dbo.TestChildSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestChildSubjectId = c.String(maxLength: 20),
                        SubjectCode = c.String(nullable: false, maxLength: 50),
                        TestChildSubjectName = c.String(nullable: false, maxLength: 50),
                        TestSubject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestSubjects", t => t.TestSubject_Id)
                .Index(t => t.TestSubject_Id);
            
            CreateTable(
                "dbo.TestSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 50),
                        SubjectCode = c.String(nullable: false, maxLength: 50),
                        SecretCode = c.String(nullable: false, maxLength: 10),
                        NoOfEasyQuestion = c.Int(nullable: false),
                        NoOfMediumQuestion = c.Int(nullable: false),
                        NoOfHardQuestion = c.Int(nullable: false),
                        TestDate = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        AccessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        SubjectCode = c.String(maxLength: 50),
                        Result_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Results", t => t.Result_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Result_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TestDetailResults",
                c => new
                    {
                        TestDetail_Id = c.Int(nullable: false),
                        Result_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestDetail_Id, t.Result_Id })
                .ForeignKey("dbo.TestDetails", t => t.TestDetail_Id, cascadeDelete: true)
                .ForeignKey("dbo.Results", t => t.Result_Id, cascadeDelete: true)
                .Index(t => t.TestDetail_Id)
                .Index(t => t.Result_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestMaps", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TestDetails", "TestMap_Id", "dbo.TestMaps");
            DropForeignKey("dbo.TestMaps", "Result_Id", "dbo.Results");
            DropForeignKey("dbo.TestDetails", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Results", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TestChildSubjects", "TestSubject_Id", "dbo.TestSubjects");
            DropForeignKey("dbo.TestDetails", "TestChildSubject_Id", "dbo.TestChildSubjects");
            DropForeignKey("dbo.TestDetailResults", "Result_Id", "dbo.Results");
            DropForeignKey("dbo.TestDetailResults", "TestDetail_Id", "dbo.TestDetails");
            DropIndex("dbo.TestDetailResults", new[] { "Result_Id" });
            DropIndex("dbo.TestDetailResults", new[] { "TestDetail_Id" });
            DropIndex("dbo.TestMaps", new[] { "User_Id" });
            DropIndex("dbo.TestMaps", new[] { "Result_Id" });
            DropIndex("dbo.TestChildSubjects", new[] { "TestSubject_Id" });
            DropIndex("dbo.TestDetails", new[] { "TestMap_Id" });
            DropIndex("dbo.TestDetails", new[] { "User_Id" });
            DropIndex("dbo.TestDetails", new[] { "TestChildSubject_Id" });
            DropIndex("dbo.Results", new[] { "User_Id" });
            DropTable("dbo.TestDetailResults");
            DropTable("dbo.TestMaps");
            DropTable("dbo.Users");
            DropTable("dbo.TestSubjects");
            DropTable("dbo.TestChildSubjects");
            DropTable("dbo.TestDetails");
            DropTable("dbo.Results");
        }
    }
}
