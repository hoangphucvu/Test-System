namespace TestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectCode = c.Guid(nullable: false),
                        UserId = c.String(),
                        TestDate = c.DateTime(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestSubjects",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 50),
                        SubjectCode = c.Guid(nullable: false),
                        SecretCode = c.String(nullable: false, maxLength: 10),
                        NoOfEasyQuestion = c.Int(nullable: false),
                        NoOfMediumQuestion = c.Int(nullable: false),
                        NoOfHardQuestion = c.Int(nullable: false),
                        TestDate = c.DateTime(nullable: false),
                        TestTime = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Result_Id = c.Int(),
                        TestMap_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Results", t => t.Result_Id)
                .ForeignKey("dbo.TestMaps", t => t.TestMap_Id)
                .Index(t => t.Result_Id)
                .Index(t => t.TestMap_Id);
            
            CreateTable(
                "dbo.TestChildSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestChildSubjectId = c.Guid(nullable: false),
                        SubjectCode = c.Guid(nullable: false),
                        TestChildSubjectName = c.String(nullable: false, maxLength: 10),
                        TestSubject_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestSubjects", t => t.TestSubject_Id)
                .Index(t => t.TestSubject_Id);
            
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
                        UserAnswer = c.String(maxLength: 100),
                        CorrectAnswer = c.String(maxLength: 100),
                        TypeOfQuestion = c.Int(nullable: false),
                        Point = c.Double(nullable: false),
                        UserId = c.String(),
                        TestChildSubjectId = c.Guid(nullable: false),
                        TestChildSubject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestChildSubjects", t => t.TestChildSubject_Id)
                .Index(t => t.TestChildSubject_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        TestMap_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestMaps", t => t.TestMap_Id)
                .Index(t => t.TestMap_Id);
            
            CreateTable(
                "dbo.TestMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        SubjectCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersResults",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Result_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Result_Id })
                .ForeignKey("dbo.Users", t => t.Users_Id, cascadeDelete: true)
                .ForeignKey("dbo.Results", t => t.Result_Id, cascadeDelete: true)
                .Index(t => t.Users_Id)
                .Index(t => t.Result_Id);
            
            CreateTable(
                "dbo.UsersTestDetails",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        TestDetail_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.TestDetail_Id })
                .ForeignKey("dbo.Users", t => t.Users_Id, cascadeDelete: true)
                .ForeignKey("dbo.TestDetails", t => t.TestDetail_Id, cascadeDelete: true)
                .Index(t => t.Users_Id)
                .Index(t => t.TestDetail_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "TestMap_Id", "dbo.TestMaps");
            DropForeignKey("dbo.TestSubjects", "TestMap_Id", "dbo.TestMaps");
            DropForeignKey("dbo.TestSubjects", "Result_Id", "dbo.Results");
            DropForeignKey("dbo.TestChildSubjects", "TestSubject_Id", "dbo.TestSubjects");
            DropForeignKey("dbo.TestDetails", "TestChildSubject_Id", "dbo.TestChildSubjects");
            DropForeignKey("dbo.UsersTestDetails", "TestDetail_Id", "dbo.TestDetails");
            DropForeignKey("dbo.UsersTestDetails", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.UsersResults", "Result_Id", "dbo.Results");
            DropForeignKey("dbo.UsersResults", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersTestDetails", new[] { "TestDetail_Id" });
            DropIndex("dbo.UsersTestDetails", new[] { "Users_Id" });
            DropIndex("dbo.UsersResults", new[] { "Result_Id" });
            DropIndex("dbo.UsersResults", new[] { "Users_Id" });
            DropIndex("dbo.Users", new[] { "TestMap_Id" });
            DropIndex("dbo.TestDetails", new[] { "TestChildSubject_Id" });
            DropIndex("dbo.TestChildSubjects", new[] { "TestSubject_Id" });
            DropIndex("dbo.TestSubjects", new[] { "TestMap_Id" });
            DropIndex("dbo.TestSubjects", new[] { "Result_Id" });
            DropTable("dbo.UsersTestDetails");
            DropTable("dbo.UsersResults");
            DropTable("dbo.TestMaps");
            DropTable("dbo.Users");
            DropTable("dbo.TestDetails");
            DropTable("dbo.TestChildSubjects");
            DropTable("dbo.TestSubjects");
            DropTable("dbo.Results");
        }
    }
}
