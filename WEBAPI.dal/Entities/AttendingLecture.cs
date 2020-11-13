using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.DAL.Entities
{
    public class AttendingLecture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public bool Atended { get; set; }
        public virtual Student Student { get; set; }
        public virtual Lecture Lecture { get; set; }
        public virtual HomeWork HomeWork { get; set; }

    }
}
