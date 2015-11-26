namespace MSAAssessmentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                        DueDate = c.DateTime(nullable: false, precision: 0),
                        Percentage = c.Int(),
                        MyWeightedMark = c.Int(),
                        CurrentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(unicode: false),
                        FirstMidName = c.String(unicode: false),
                        EnrollmentDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Assignments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "StudentID" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropIndex("dbo.Assignments", new[] { "CourseID" });
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
