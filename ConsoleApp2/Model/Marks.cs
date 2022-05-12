using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Model
{
    [Table("Mark", Schema = "marks")]
    internal class Mark
    {
        [Key]
        public int mark_id { get; set; }

        public int student_id { get; set; }
        [ForeignKey("student_id")]
        public Student student { get; set; }
        public int subject_id { get; set; }
        [ForeignKey("subject_id")]
        public Subject subject { get; set; }

        public int mark { get; set; }

    }
}
