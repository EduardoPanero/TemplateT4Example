namespace TemplateT4Example.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        Location = c.String(maxLength: 50, unicode: false),
                        TeacherID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TeacherID)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.StudentsClasses",
                c => new
                    {
                        ClassID = c.Int(nullable: false),
                        Class_ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassID, t.Class_ClassID })
                .ForeignKey("dbo.Students", t => t.ClassID, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_ClassID, cascadeDelete: true)
                .Index(t => t.ClassID)
                .Index(t => t.Class_ClassID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Classes", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.StudentsClasses", "Class_ClassID", "dbo.Classes");
            DropForeignKey("dbo.StudentsClasses", "ClassID", "dbo.Students");
            DropIndex("dbo.StudentsClasses", new[] { "Class_ClassID" });
            DropIndex("dbo.StudentsClasses", new[] { "ClassID" });
            DropIndex("dbo.Teachers", new[] { "Email" });
            DropIndex("dbo.Teachers", new[] { "Username" });
            DropIndex("dbo.Students", new[] { "Email" });
            DropIndex("dbo.Students", new[] { "Username" });
            DropIndex("dbo.Classes", new[] { "SubjectID" });
            DropIndex("dbo.Classes", new[] { "TeacherID" });
            DropTable("dbo.StudentsClasses");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
