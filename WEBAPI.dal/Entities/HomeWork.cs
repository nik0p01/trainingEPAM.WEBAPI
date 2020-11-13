using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.DAL.Entities
{
    public class HomeWork
    {
        [Key]
        [ForeignKey("AttendingLecture")]
        public new int ID { get; set; }
        public byte CourseGrade { get; set; }
        public virtual AttendingLecture AttendingLecture { get; set; }
    }
}