namespace WEBAPI.BL.Entities
{
    public class AttendingLectureBL
    {
        public int ID { get; set; }
        public bool Atended { get; set; }
        public virtual HomeWorkBL Student { get; set; }
        public virtual LectureBL Lecture { get; set; }
        public virtual HomeWorkBL HomeWork { get; set; }

    }
}
