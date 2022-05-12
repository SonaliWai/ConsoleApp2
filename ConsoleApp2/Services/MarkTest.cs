using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Services
{
    public class MarkTest
    {
        public void Select()
        {
            using (var Context = new SampleStoreContext2())
            {
                var marks = Context.marks.Include("subject").Include("student").ToList();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ----------------------------------------------------------------------------");
                Console.WriteLine("| markId | Std id | Student name | Sub id  |   Subject title      |   marks  |");
                Console.WriteLine(" ----------------------------------------------------------------------------");
                Console.ResetColor();

                foreach (var m in marks)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"| {m.mark_id,(-6)} |  {m.student.student_id,(-5)} | {m.student.student_name,(-12)} |   {m.subject.subject_id,(-5)} | {m.subject.subject_title,(-20)} |    {m.mark,(-5)} |");

                }
                Console.WriteLine(" ----------------------------------------------------------------------------");
                Console.ResetColor();
            }
        }



        public void Add()
        {
            var context = new SampleStoreContext2();
            var mark = new Mark
            {

                student_id = 2,
                subject_id = 2,
                mark = 10,

            };

            context.marks.Add(mark);
            context.SaveChanges();

            context.Dispose();
        }

        public void Delete()
        {
            Console.WriteLine("enter delete mark id : >>  ");
            var markIdText = Console.ReadLine();
            var markIdToBeDeleted = int.Parse(markIdText);

            using var context = new SampleStoreContext2();

            var m = context.marks.FirstOrDefault(xyz => xyz.mark_id == markIdToBeDeleted);

            if (m == null)
            {
                Console.WriteLine($"mark with id = {markIdToBeDeleted} not found");
                return;
            }

            context.marks.Remove(m);
            context.SaveChanges();

            context.Dispose();
        }

        public void Update()
        {
            Console.WriteLine("Enter the mark Id to be updated ");
            var markIdText = Console.ReadLine();
            var markIdToBeUpdated = int.Parse(markIdText);

            using var context = new SampleStoreContext2();

            var m = context.marks.FirstOrDefault(xyz => xyz.mark_id == markIdToBeUpdated);

            if (m == null)
            {
                Console.WriteLine($"mark with id = {markIdToBeUpdated} not found");
                return;
            }

            m.student_id = 1;
            m.subject_id = 1;
            m.mark = 23;


            context.marks.Update(m);
            context.SaveChanges();
        }

    }
}
