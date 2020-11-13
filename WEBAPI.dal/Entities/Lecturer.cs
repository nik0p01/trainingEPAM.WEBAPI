using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI.DAL.Entities
{
    public class Lecturer
    {
        public Lecturer()
        {
            Lectures = new HashSet<Lecture>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(60)]
        public string FullName { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
