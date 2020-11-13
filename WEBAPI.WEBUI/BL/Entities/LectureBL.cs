namespace WEBAPI.BL.Entities
{
    public class LectureBL
    {

        public int ID { get; set; }
        public string Title { get; set; }

        public virtual LecturerBL Lecturer { get; set; }

    }
}
