using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Services
{
    public class StudentTest
    {
        public void Select()
        {
            using (var Context = new SampleStoreContext2())
            {
                var stds = Context.Students.Include("course").ToList();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" -------------------------------------------------------------------------");
                Console.WriteLine("| stdId |  student name   | std rollno | std address |    course title    |");
                Console.WriteLine(" -------------------------------------------------------------------------");
                Console.ResetColor();
                foreach (var std in stds)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"| {std.student_id,(-5)} | {std.student_name,(-15)} | {std.student_rollno,(-10)} |  {std.student_address,(-10)} | {std.course.course_title,(-18)} |");
                }
                Console.WriteLine(" -------------------------------------------------------------------------");
                Console.ResetColor();
            }
        }

        public void Add()
        {
            var context = new SampleStoreContext2();
            var std = new Student
            {

                student_name = "full stack",
                student_rollno = 32,
                student_address = "full stack developer",
                course_id = 2,

            };

            context.Students.Add(std);
            context.SaveChanges();

            context.Dispose();
        }

        public void Delete()
        {
            Console.WriteLine("enter delete student id : >>  ");
            var studentIdText = Console.ReadLine();
            var studentIdToBeDeleted = int.Parse(studentIdText);

            using var context = new SampleStoreContext2();

            var std = context.Students.FirstOrDefault(xyz => xyz.student_id == studentIdToBeDeleted);

            if (std == null)
            {
                Console.WriteLine($"student with id = {studentIdToBeDeleted} not found");
                return;
            }

            context.Students.Remove(std);
            context.SaveChanges();

            context.Dispose();
        }

        public void Update()
        {
            Console.WriteLine("Enter the student Id to be updated ");
            var studentIdText = Console.ReadLine();
            var studentIdToBeUpdated = int.Parse(studentIdText);

            using var context = new SampleStoreContext2();

            var std = context.Students.FirstOrDefault(xyz => xyz.student_id == studentIdToBeUpdated);

            if (std == null)
            {
                Console.WriteLine($"student with id = {studentIdToBeUpdated} not found");
                return;
            }

            std.student_name = "text";
            std.student_rollno = 2;
            std.student_address = "text";
            std.course_id = 2;


            context.Students.Update(std);
            context.SaveChanges();
        }
    }
}
