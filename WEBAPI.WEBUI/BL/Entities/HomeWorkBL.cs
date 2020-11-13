namespace WEBAPI.BL.Entities
{
    public class HomeWorkBL
    {
        public int ID { get; set; }
        public byte CourseGrade { get; set; }
        public virtual AttendingLectureBL AttendingLectureDTO { get; set; }
    }
}