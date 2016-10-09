namespace TestSystemManagement.Repository.Migrations
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
                    TestDate = c.DateTime(),
                    Total = c.Double(),
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
                    Question = c.String(),
                    AnswerA = c.String(),
                    AnswerB = c.String(),
                    AnswerC = c.String(),
                    AnswerD = c.String(),
                    CorrectAnswer = c.String(),
                    TypeOfQuestion = c.Int(),
                    Point = c.Double(),
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
                    TestChildSubjectId = c.String(),
                    SubjectCode = c.String(),
                    TestChildSubjectName = c.String(),
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
                    SubjectName = c.String(),
                    SubjectCode = c.String(),
                    SecretCode = c.String(),
                    NoOfEasyQuestion = c.Int(),
                    NoOfMediumQuestion = c.Int(),
                    NoOfHardQuestion = c.Int(),
                    TestDate = c.DateTime(),
                    FinishTime = c.DateTime(),
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
                    AccessLevel = c.Int(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TestMaps",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(),
                    SubjectCode = c.String(),
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
                    TestDetail_Id = c.Int(),
                    Result_Id = c.Int(),
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