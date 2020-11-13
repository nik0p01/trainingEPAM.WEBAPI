namespace WEBAPI.DAL.Repository
{
    public interface IEducationRepository
    {


        IStudentRepository GetStudentRepository();
        ILecturerRepository GetLecturerRepository();
        ILectureRepository GetLectureRepository();
        IHomeWorkRepository GetHomeWorkRepository();
        IAttendingLectureRepository GetAttendingLectureRepository();

        void EnsureDeleted();
        void EnsureCreated();

    }
}
