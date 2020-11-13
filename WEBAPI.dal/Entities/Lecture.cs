using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.DAL.Entities
{
    public class Lecture
    {
        public Lecture()
        {
            AttendingLectures = new HashSet<AttendingLecture>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }

        public virtual Lecturer Lecturer { get; set; }
        public virtual ICollection<AttendingLecture> AttendingLectures { get; set; }
    }
}
