using grad2021.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace grad2021.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentCode> DepartmentCodes { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorEnrollment> InstructorEnrollments { get; set; }
        public DbSet<InstructorProfession> InstructorProfessions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<grad2021.Models.Selection> Selection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AcademicYear>().ToTable("AcademicYear");
            //modelBuilder.Entity<Branch>().ToTable("Branch");
            //modelBuilder.Entity<Course>().ToTable("Course");
            //modelBuilder.Entity<CourseEnrollment>().ToTable("CourseEnrollment");
            //modelBuilder.Entity<Department>().ToTable("Department");
            //modelBuilder.Entity<DepartmentCode>().ToTable("DepartmentCode");
            //modelBuilder.Entity<Instructor>().ToTable("Instructor");
            //modelBuilder.Entity<InstructorEnrollment>().ToTable("InstructorEnrollment");
            //modelBuilder.Entity<InstructorProfession>().ToTable("InstructorProfession");
            //modelBuilder.Entity<Student>().ToTable("Student");
            //modelBuilder.Entity<StudentEnrollment>().ToTable("StudentEnrollment");
            //modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse");


            //Key Management: HasKey, HasAlternateKey, (HasOne, WithMany, HasForeignKey)

            modelBuilder.Entity<AcademicYear>()
                .HasKey(ay => ay.AcademicYearID);

            modelBuilder.Entity<Branch>()
                .HasKey(b => b.BranchName);
            modelBuilder.Entity<Branch>()
                 .HasOne(bh => bh.Department)
                 .WithMany(bw => bw.Branches)
                 .HasForeignKey(bf => bf.DepartmentName);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseName);
            //modelBuilder.Entity<Course>()
            //    .HasAlternateKey(ce => new { ce.CourseCode, ce.DepartmentCodeValue });
            modelBuilder.Entity<Course>()
                 .HasOne(ch => ch.DepartmentCode)
                 .WithMany(cw => cw.Courses)
                 .HasForeignKey(cf => cf.DepartmentCodeValue);

            modelBuilder.Entity<CourseEnrollment>()
                .HasKey(ce => new { ce.CourseName, ce.BranchName });
            modelBuilder.Entity<CourseEnrollment>()
                 .HasOne(ceh => ceh.Course)
                 .WithMany(cew => cew.CourseEnrollments)
                 .HasForeignKey(dcf => dcf.CourseName);
            modelBuilder.Entity<CourseEnrollment>()
                 .HasOne(ceh => ceh.Branch)
                 .WithMany(cew => cew.CourseEnrollments)
                 .HasForeignKey(dcf => dcf.BranchName);

            modelBuilder.Entity<Department>()
                .HasKey(d => d.DepartmentName);

            modelBuilder.Entity<DepartmentCode>()
                .HasKey(dc => dc.DepartmentCodeValue);
            modelBuilder.Entity<DepartmentCode>()
                 .HasOne(dch => dch.Department)
                 .WithMany(dcw => dcw.DepartmentCodes)
                 .HasForeignKey(dcf => dcf.DepartmentName);

            modelBuilder.Entity<Instructor>()
                .HasKey(i => i.InstructorNatId);
            //modelBuilder.Entity<Instructor>()
            //    .HasAlternateKey(i => i.InstructorName);
            modelBuilder.Entity<Instructor>()
                 .HasOne(p => p.Department)
                 .WithMany(b => b.Instructors)
                 .HasForeignKey(s => s.DepartmentName);

            modelBuilder.Entity<InstructorEnrollment>()
                .HasKey(ie => ie.InstructorEnrollmentID);
            //modelBuilder.Entity<InstructorEnrollment>()
            //    .HasAlternateKey(ie => new { ie.InstructorNatId, ie.AcademicYearID, ie.CourseEnrollmentID });
            modelBuilder.Entity<InstructorEnrollment>()
                 .HasOne(p => p.Instructor)
                 .WithMany(b => b.InstructorEnrollments)
                 .HasForeignKey(s => s.InstructorNatId)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InstructorEnrollment>()
                 .HasOne(pa => pa.AcademicYear)
                 .WithMany(ba => ba.InstructorEnrollments)
                 .HasForeignKey(sa => sa.AcademicYearID)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InstructorEnrollment>()
                 .HasOne(pc => pc.CourseEnrollment)
                 .WithMany(bc => bc.InstructorEnrollments)
                 .HasForeignKey(ce => new { ce.CourseName, ce.BranchName })
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InstructorProfession>()
                .HasKey(ie => ie.InstructorProfessionID);
            //modelBuilder.Entity<InstructorProfession>()
            //    .HasAlternateKey(ie => new { ie.InstructorNatId, ie.ProfessionDegree });
            modelBuilder.Entity<InstructorProfession>()
                 .HasOne(p => p.Instructor)
                 .WithMany(b => b.InstructorProfessions)
                 .HasForeignKey(s => s.InstructorNatId);

            modelBuilder.Entity<Selection>()
                .HasKey(ie => ie.SelectionID);
            modelBuilder.Entity<Selection>()
                .HasOne(ie => ie.StudentEnrollment)
                 .WithMany(b => b.Selections)
                 .HasForeignKey(ie => new { ie.StudentNatId, ie.AcademicYearID })
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Selection>()
                .HasOne(ie => ie.CurrentBranch)
                 .WithMany(b => b.CurrentBranches)
                 .HasForeignKey(s => s.CurrentBranchName)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Selection>()
                .HasOne(ie => ie.SelectionBranch)
                 .WithMany(b => b.SelectionBranches)
                 .HasForeignKey(s => s.SelectionBranchName)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasKey(ie => ie.StudentNatId);

            modelBuilder.Entity<StudentEnrollment>()
                .HasKey(ie => new { ie.StudentNatId, ie.AcademicYearID });
            //modelBuilder.Entity<StudentEnrollment>()
            //    .HasAlternateKey(ie => new { ie.StudentNatId, ie.FirstSemesterStartDate });
            modelBuilder.Entity<StudentEnrollment>()
                 .HasOne(p => p.Student)
                 .WithMany(b => b.StudentEnrollments)
                 .HasForeignKey(s => s.StudentNatId);
            modelBuilder.Entity<StudentEnrollment>()
                 .HasOne(p => p.AcademicYear)
                 .WithMany(b => b.StudentEnrollments)
                 .HasForeignKey(s => s.AcademicYearID);
            modelBuilder.Entity<StudentEnrollment>()
                 .HasOne(p => p.Branch)
                 .WithMany(b => b.StudentEnrollments)
                 .HasForeignKey(s => s.BranchName);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(ie => ie.StudentCourseID);
            modelBuilder.Entity<StudentCourse>()
                 .HasOne(p => p.StudentEnrollment)
                 .WithMany(b => b.StudentCourses)
                 .HasForeignKey(s => new { s.StudentNatId, s.AcademicYearID });
            modelBuilder.Entity<StudentCourse>()
                 .HasOne(p => p.CourseEnrollment)
                 .WithMany(b => b.StudentCourses)
                 .HasForeignKey(s => new { s.CourseName, s.BranchName });

            // adding intial data

            modelBuilder.Entity<AcademicYear>().HasData(new AcademicYear { AcademicYearID = 2021 });
            modelBuilder.Entity<AcademicYear>().HasData(new AcademicYear { AcademicYearID = 2022 });
            modelBuilder.Entity<AcademicYear>().HasData(new AcademicYear { AcademicYearID = 2023 });

            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الرياضيات والفيزيقا الهندسية", DepartmentDescription = "وصف قسم الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الهندسة المدنية", DepartmentDescription = "وصف قسم الهندسة المدنية" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الهندسة الكهربية", DepartmentDescription = "وصف قسم الهندسة الكهربية" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الهندسة المعمارية", DepartmentDescription = "وصف قسم الهندسة المعمارية" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الهندسة الميكانيكية", DepartmentDescription = "وصف قسم الهندسة الميكانيكية" });

            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الهندسة المدنية", DepartmentName = "الهندسة المدنية", BranchDescription = "وصف قسم الهندسة المدنية", FullCapacity = 2 }); ;
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الهندسة المعمارية", DepartmentName = "الهندسة المعمارية", BranchDescription = "وصف قسم الهندسة المعمارية", FullCapacity = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الرياضيات والفيزيقا الهندسية", DepartmentName = "الرياضيات والفيزيقا الهندسية", BranchDescription = "وصف قسم الرياضيات والفيزيقا الهندسية", FullCapacity = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة القوى والآلات الكهربية", DepartmentName = "الهندسة الكهربية", BranchDescription = "وصف شعبة هندسة القوى والآلات الكهربية", FullCapacity = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", DepartmentName = "الهندسة الكهربية", BranchDescription = "وصف شعبة هندسة الإلكترونيات والاتصالات الكهربية", FullCapacity = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة الحاسبات والنظم", DepartmentName = "الهندسة الكهربية", BranchDescription = "وصف شعبة هندسة الحاسبات والنظم", FullCapacity = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الهندسة الميكانيكية", DepartmentName = "الهندسة الميكانيكية", BranchDescription = "وصف قسم الهندسة الميكانيكية", FullCapacity = 1 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة الإنتاج والتصميم الميكانيكي", DepartmentName = "الهندسة الميكانيكية", BranchDescription = "وصف شعبة هندسة الإنتاج والتصميم الميكانيكي", FullCapacity = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الهندسة الصناعية", DepartmentName = "الهندسة الميكانيكية", BranchDescription = "وصف شعبة الهندسة الصناعية", FullCapacity = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة القوى الميكانيكية", DepartmentName = "الهندسة الميكانيكية", BranchDescription = "وصف شعبة هندسة القوى الميكانيكية", FullCapacity = 2 });

            //modelBuilder.Entity<Level>().HasData(new Level { LevelName = "الإعدادية" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelName = "الأولى" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelName = "الثانية" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelName = "الثالثة" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelName = "الرابعة" });

            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "إعدادي_هندسة_لائحة2017", BranchName = "الرياضيات والفيزيقا الهندسية", LevelName = "الإعدادية" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "أولى_هندسة_القوى_والآلات_الكهربية_لائحة2017", BranchName = "هندسة القوى والآلات الكهربية", LevelName = "الأولى" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثانية_هندسة_القوى_والآلات_الكهربية_لائحة2017", BranchName = "هندسة القوى والآلات الكهربية", LevelName = "الثانية" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثالثة_هندسة_القوى_والآلات_الكهربية_لائحة2017", BranchName = "هندسة القوى والآلات الكهربية", LevelName = "الثالثة" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "رابعة_هندسة_القوى_والآلات_الكهربية_لائحة2017", BranchName = "هندسة القوى والآلات الكهربية", LevelName = "الرابعة" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "أولى_هندسة_الإلكترونيات_والاتصالات_الكهربية_لائحة2017", BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", LevelName = "الأولى" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثانية_هندسة_الإلكترونيات_والاتصالات_الكهربية_لائحة2017", BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", LevelName = "الثانية" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثالثة_هندسة_الإلكترونيات_والاتصالات_الكهربية_لائحة2017", BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", LevelName = "الثالثة" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "رابعة_هندسة_الإلكترونيات_والاتصالات_الكهربية_لائحة2017", BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", LevelName = "الرابعة" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "أولى_هندسة_الحاسبات_والنظم_لائحة2017", BranchName = "هندسة الحاسبات والنظم", LevelName = "الأولى" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثانية_هندسة_الحاسبات_والنظم_لائحة2017", BranchName = "هندسة الحاسبات والنظم", LevelName = "الثانية" });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثالثة_هندسة_الحاسبات_والنظم_لائحة2017", BranchName = "هندسة الحاسبات والنظم", LevelName = "الثالثة", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "رابعة_هندسة_الحاسبات_والنظم_لائحة2017", BranchName = "هندسة الحاسبات والنظم", LevelName = "الرابعة", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "أولى_الهندسة_الميكانيكية_لائحة2017", BranchName = "الهندسة الميكانيكية", LevelName = "الأولى", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثانية_الهندسة_الميكانيكية_لائحة2017", BranchName = "الهندسة الميكانيكية", LevelName = "الثانية", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثالثة_الهندسة_الميكانيكية_لائحة2017", BranchName = "الهندسة الميكانيكية", LevelName = "الثالثة", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "رابعة_هندسة_الإنتاج_والتصميم_الميكانيكي_لائحة2017", BranchName = "هندسة الإنتاج والتصميم الميكانيكي", LevelName = "الرابعة", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "رابعة_الهندسة_الصناعية_لائحة2017", BranchName = "الهندسة الصناعية", LevelName = "الرابعة", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "رابعة_هندسة_القوى_الميكانيكية_لائحة2017", BranchName = "هندسة القوى الميكانيكية", LevelName = "الرابعة", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "أولى_الهندسة_المدنية_لائحة2017", BranchName = "الهندسة المدنية", LevelName = "الأولى", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثانية_الهندسة_المدنية_لائحة2017", BranchName = "الهندسة المدنية", LevelName = "الثانية", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثالثة_الهندسة_المدنية_لائحة2017", BranchName = "الهندسة المدنية", LevelName = "الثالثة", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "رابعة_الهندسة_المدنية_لائحة2017", BranchName = "الهندسة المدنية", LevelName = "الرابعة", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "أولى_الهندسة_المعمارية_لائحة2017", BranchName = "الهندسة المعمارية", LevelName = "الأولى", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثانية_الهندسة_المعمارية_لائحة2017", BranchName = "الهندسة المعمارية", LevelName = "الثانية", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "ثالثة_الهندسة_المعمارية_لائحة2017", BranchName = "الهندسة المعمارية", LevelName = "الثالثة", RegulationID = 2017 });
            //modelBuilder.Entity<Level>().HasData(new Level { LevelID = "رابعة_الهندسة_المعمارية_لائحة2017", BranchName = "الهندسة المعمارية", LevelName = "الرابعة", RegulationID = 2017 });

            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "ريض", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "فيز", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "ميك", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "عام", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "هند", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "مدن", DepartmentName = "الهندسة المدنية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "عمر", DepartmentName = "الهندسة المعمارية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "كھع", DepartmentName = "الهندسة الكهربية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "كهق", DepartmentName = "الهندسة الكهربية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "كهت", DepartmentName = "الهندسة الكهربية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "كهح", DepartmentName = "الهندسة الكهربية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "تمج", DepartmentName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "صنع", DepartmentName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "قوى", DepartmentName = "الهندسة الميكانيكية" });

            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "حساب التفاضل", CourseCode = "001", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "خواص المادة ومبادئ الديناميكا الحرارية", CourseCode = "001", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "جيولوجيا ھندسية", CourseCode = "102", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "مجالات كھربية ومغناطيسية ٢", CourseCode = "203", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "ھندسة الاتصالات والالكترونيات", CourseCode = "215", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "اختبارات كھربية", CourseCode = "305", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "البرمجيات الھندسية", CourseCode = "207", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "التشييد ونظم البناء", CourseCode = "126", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "الأساسات", CourseCode = "222", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "ميكانيكا الھياكل", CourseCode = "213", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "إدارة ھندسية", CourseCode = "216", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "ھندسة ميكانيكية 1", CourseCode = "105", DepartmentCodeValue = "قوى" });


            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "حساب التفاضل", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "ھندسة الاتصالات والالكترونيات", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "اختبارات كھربية", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "مجالات كھربية ومغناطيسية ٢", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "إدارة ھندسية", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "ميكانيكا الھياكل", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "خواص المادة ومبادئ الديناميكا الحرارية", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "ھندسة ميكانيكية 1", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "الأساسات", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });

            modelBuilder.Entity<Instructor>().HasData(new Instructor { InstructorName = "محمد عبد السلام", InstructorNatId = 2983423493422, DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<Instructor>().HasData(new Instructor { InstructorName = "إبراهيم فايق", InstructorNatId = 7567456456646, DepartmentName = "الهندسة الكهربية" });
            modelBuilder.Entity<Instructor>().HasData(new Instructor { InstructorName = "فايز السيد", InstructorNatId = 435345345345, DepartmentName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<Instructor>().HasData(new Instructor { InstructorName = "أحمد السيد", InstructorNatId = 435345345390, DepartmentName = "الهندسة المدنية" });

            modelBuilder.Entity<InstructorEnrollment>().HasData(new InstructorEnrollment { InstructorEnrollmentID = 1, InstructorNatId = 2983423493422, AcademicYearID = 2023, CourseName = "حساب التفاضل", BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<InstructorEnrollment>().HasData(new InstructorEnrollment { InstructorEnrollmentID = 2, InstructorNatId = 7567456456646, AcademicYearID = 2023, CourseName = "ھندسة الاتصالات والالكترونيات", BranchName = "هندسة القوى والآلات الكهربية" });
            modelBuilder.Entity<InstructorEnrollment>().HasData(new InstructorEnrollment { InstructorEnrollmentID = 3, InstructorNatId = 7567456456646, AcademicYearID = 2023, CourseName = "اختبارات كھربية", BranchName = "هندسة القوى والآلات الكهربية" });
            modelBuilder.Entity<InstructorEnrollment>().HasData(new InstructorEnrollment { InstructorEnrollmentID = 4, InstructorNatId = 435345345345, AcademicYearID = 2023, CourseName = "إدارة ھندسية", BranchName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<InstructorEnrollment>().HasData(new InstructorEnrollment { InstructorEnrollmentID = 5, InstructorNatId = 435345345345, AcademicYearID = 2023, CourseName = "ميكانيكا الھياكل", BranchName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<InstructorEnrollment>().HasData(new InstructorEnrollment { InstructorEnrollmentID = 6, InstructorNatId = 435345345345, AcademicYearID = 2023, CourseName = "خواص المادة ومبادئ الديناميكا الحرارية", BranchName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<InstructorEnrollment>().HasData(new InstructorEnrollment { InstructorEnrollmentID = 7, InstructorNatId = 435345345345, AcademicYearID = 2023, CourseName = "ھندسة ميكانيكية 1", BranchName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<InstructorEnrollment>().HasData(new InstructorEnrollment { InstructorEnrollmentID = 8, InstructorNatId = 435345345345, AcademicYearID = 2023, CourseName = "الأساسات", BranchName = "الهندسة المدنية" });

            //DateTime dt1 = new(2015, 12, 31);
            //DateTime dt2 = new(2000, 8, 31);
            //DateTime dt3 = new(2020, 4, 31);

            modelBuilder.Entity<InstructorProfession>().HasData(new InstructorProfession { InstructorProfessionID = 1, InstructorNatId = 2983423493422, ProfessionDegree = grad2021.Models.ProfessionDegree.أستاذ, PromotionDate = DateTime.Today });
            modelBuilder.Entity<InstructorProfession>().HasData(new InstructorProfession { InstructorProfessionID = 2, InstructorNatId = 7567456456646, ProfessionDegree = grad2021.Models.ProfessionDegree.أستاذ_مساعد, PromotionDate = DateTime.Today });
            modelBuilder.Entity<InstructorProfession>().HasData(new InstructorProfession { InstructorProfessionID = 3, InstructorNatId = 435345345345, ProfessionDegree = grad2021.Models.ProfessionDegree.مدرس, PromotionDate = DateTime.Today });
            modelBuilder.Entity<InstructorProfession>().HasData(new InstructorProfession { InstructorProfessionID = 4, InstructorNatId = 435345345390, ProfessionDegree = grad2021.Models.ProfessionDegree.مدرس, PromotionDate = DateTime.Today });

            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "إيمان محمود رشوان", StudentNatId = 535340593458, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "إحسان محمود رشوان", StudentNatId = 535340593459, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "أميرة محمود رشوان", StudentNatId = 789654564, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "حسن محمود رشوان", StudentNatId = 976546345334, Gender = grad2021.Models.Gender.ذكر });

            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 535340593458, AcademicYearID = 2023, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 535340593459, AcademicYearID = 2023, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 789654564, AcademicYearID = 2023, LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة القوى والآلات الكهربية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 976546345334, AcademicYearID = 2023, LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة الميكانيكية" });

            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse { StudentCourseID = 1, StudentNatId = 535340593458, AcademicYearID = 2023, CourseName = "حساب التفاضل", BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse { StudentCourseID = 2, StudentNatId = 535340593459, AcademicYearID = 2023, CourseName = "حساب التفاضل", BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse { StudentCourseID = 3, StudentNatId = 789654564, AcademicYearID = 2023, CourseName = "ھندسة الاتصالات والالكترونيات", BranchName = "هندسة القوى والآلات الكهربية", FinalExamMark = 70 });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse { StudentCourseID = 4, StudentNatId = 789654564, AcademicYearID = 2023, CourseName = "اختبارات كھربية", BranchName = "هندسة القوى والآلات الكهربية", FinalExamMark = 10 });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse { StudentCourseID = 5, StudentNatId = 976546345334, AcademicYearID = 2023, CourseName = "إدارة ھندسية", BranchName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse { StudentCourseID = 6, StudentNatId = 976546345334, AcademicYearID = 2023, CourseName = "ميكانيكا الھياكل", BranchName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<StudentCourse>().HasData(new StudentCourse { StudentCourseID = 7, StudentNatId = 976546345334, AcademicYearID = 2023, CourseName = "خواص المادة ومبادئ الديناميكا الحرارية", BranchName = "الهندسة الميكانيكية" });

            modelBuilder.Entity<Selection>().HasData(new Selection { SelectionID = 1, StudentNatId = 535340593458, SelectionNo = 1, AcademicYearID = 2023, CurrentBranchName = "الرياضيات والفيزيقا الهندسية", SelectionBranchName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<Selection>().HasData(new Selection { SelectionID = 2, StudentNatId = 535340593458, SelectionNo = 2, AcademicYearID = 2023, CurrentBranchName = "الرياضيات والفيزيقا الهندسية", SelectionBranchName = "الهندسة المدنية" });
            modelBuilder.Entity<Selection>().HasData(new Selection { SelectionID = 3, StudentNatId = 535340593459, SelectionNo = 1, AcademicYearID = 2023, CurrentBranchName = "الرياضيات والفيزيقا الهندسية", SelectionBranchName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<Selection>().HasData(new Selection { SelectionID = 4, StudentNatId = 535340593459, SelectionNo = 2, AcademicYearID = 2023, CurrentBranchName = "الرياضيات والفيزيقا الهندسية", SelectionBranchName = "الهندسة المدنية" });


            //Calculated Column Entities

            //modelBuilder.Entity<Mark>()
            //.Property(c => c.TotalMark)
            //.HasComputedColumnSql("[MidTermMark] + [CourseWorkMark] + [OralExamMark] + [FinalExamMark] + [MerciMark]");
        }
    }
}