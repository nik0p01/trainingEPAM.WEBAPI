using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.DAL.Entities
{
    public class Student
    {
        public Student()
        {
            AttendingLectures = new HashSet<AttendingLecture>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(60)]
        public string FullName { get; set; }

        public string EMail { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<AttendingLecture> AttendingLectures { get; set; }
    }
}
