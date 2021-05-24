
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using grad2021.Models;

namespace grad2021.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            var departments = new Department[]{
                //new Department { DepartmentName = "الرياضيات والفيزيقا الهندسية", DepartmentDescription = "" },
                //new Department { DepartmentName = "الهندسة المدنية", DepartmentDescription = "" },
                //new Department { DepartmentName = "الهندسة الكهربية", DepartmentDescription = "" },
                //new Department { DepartmentName = "الهندسة المعمارية", DepartmentDescription = "" },
                //new Department { DepartmentName = "الهندسة الميكانيكية", DepartmentDescription = "" }
            };
            foreach (Department d in departments) { context.Departments.Add(d); }
            context.SaveChanges();

            var academicYears = new AcademicYear[] { };
            foreach (AcademicYear d in academicYears) { context.AcademicYears.Add(d); }
            context.SaveChanges();

            var branches = new Branch[] { };
            foreach (Branch d in branches) { context.Branches.Add(d); }
            context.SaveChanges();

            var courses = new Course[] { };
            foreach (Course c in courses) { context.Courses.Add(c); }
            context.SaveChanges();

            var courseEnrollments = new CourseEnrollment[] { };
            foreach (CourseEnrollment ce in courseEnrollments) { context.CourseEnrollments.Add(ce); }
            context.SaveChanges();

            var departmentCodes = new DepartmentCode[] { };
            foreach (DepartmentCode dc in departmentCodes) { context.DepartmentCodes.Add(dc); }
            context.SaveChanges();

            var instructors = new Instructor[] { };
            foreach (Instructor i in instructors) { context.Instructors.Add(i); }
            context.SaveChanges();

            var instructorEnrollments = new InstructorEnrollment[] { };
            foreach (InstructorEnrollment id in instructorEnrollments) { context.InstructorEnrollments.Add(id); }
            context.SaveChanges();

            var instructorProfessions = new InstructorProfession[] { };
            foreach (InstructorProfession id in instructorProfessions) { context.InstructorProfessions.Add(id); }
            context.SaveChanges();

            var students = new Student[] { };
            foreach (Student s in students) { context.Students.Add(s); }
            context.SaveChanges();

            var studentEnrollments = new StudentEnrollment[] { };
            foreach (StudentEnrollment s in studentEnrollments) { context.StudentEnrollments.Add(s); }
            context.SaveChanges();

            var studentCourses = new StudentCourse[] { };
            foreach (StudentCourse s in studentCourses) { context.StudentCourses.Add(s); }
            context.SaveChanges();

            //var StudentDepartmentChoices = new StudentDepartmentChoice[] { };
            //foreach (StudentDepartmentChoice sdc in StudentDepartmentChoices) { context.StudentDepartmentChoices.Add(sdc); }
            //context.SaveChanges();

        }
    }
}