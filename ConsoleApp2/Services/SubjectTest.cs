using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Services
{
    public class SubjectTest
    {
        public void Select()
        {
            using (var Context = new SampleStoreContext2())
            {
                var subs = Context.subjects.Include("course").ToList();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" ----------------------------------------------------------------------------------------");
                Console.WriteLine("| subId |        sub title     |  sub code  |   sub description    |   sub  Course       |");
                Console.WriteLine(" ----------------------------------------------------------------------------------------");
                Console.ResetColor();
                foreach (var subject in subs)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"| {subject.subject_id,(-5)} | {subject.subject_title,(-20)} | {subject.subject_code,(-10)} | {subject.subject_description,(-20)} | {subject.course.course_title,(-20)}|");
                }
                Console.WriteLine(" ----------------------------------------------------------------------------------------");
                Console.ResetColor();

            }
        }

        public void Add()
        {
            var context = new SampleStoreContext2();
            var sub = new Subject
            {

                subject_title = "full stack",
                subject_code = "CC0032",
                subject_description = "full stack developer",
                course_id = 2,

            };

            context.subjects.Add(sub);
            context.SaveChanges();

            context.Dispose();
        }

        public void Delete()
        {
            Console.WriteLine("enter delete subject id : >>  ");
            var subjectIdText = Console.ReadLine();
            var subjectIdToBeDeleted = int.Parse(subjectIdText);

            using var context = new SampleStoreContext2();

            var sub = context.subjects.FirstOrDefault(xyz => xyz.subject_id == subjectIdToBeDeleted);

            if (sub == null)
            {
                Console.WriteLine($"subject with id = {subjectIdToBeDeleted} not found");
                return;
            }

            context.subjects.Remove(sub);
            context.SaveChanges();

            context.Dispose();
        }

        public void Update()
        {
            Console.WriteLine("Enter the subject Id to be updated ");
            var subjectIdText = Console.ReadLine();
            var subjectIdToBeUpdated = int.Parse(subjectIdText);

            using var context = new SampleStoreContext2();

            var sub = context.subjects.FirstOrDefault(xyz => xyz.subject_id == subjectIdToBeUpdated);

            if (sub == null)
            {
                Console.WriteLine($"subject with id = {subjectIdToBeUpdated} not found");
                return;
            }

            sub.subject_title = "text";
            sub.subject_title = "text";
            sub.subject_description = "text";
            sub.course_id = 2;


            context.subjects.Update(sub);
            context.SaveChanges();
        }
    }
}
