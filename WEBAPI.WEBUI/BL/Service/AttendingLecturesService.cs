using AutoMapper;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.WEBUI.BL.Service
{
    public class AttendingLecturesService : IAttendingLecturesService
    {
        private readonly IAttendingLectureRepository _attendingLectureRepository;
        private readonly ILogger<AttendingLecturesService> _logger;
        private readonly IMapper _mapper;
        public AttendingLecturesService(IEducationRepository educationRepository, ILogger<AttendingLecturesService> logger, IMapper mapper)
        {
            _attendingLectureRepository = educationRepository.GetAttendingLectureRepository();
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<AttendingLectureBL> GetAttendingLectures()
        {
            var lisAttendingLecture = new List<AttendingLectureBL>();
            _attendingLectureRepository.GetAttendingLectures().ToList().ForEach(a => lisAttendingLecture.Add(_mapper.Map<AttendingLectureBL>(a)));
            return lisAttendingLecture;

        }

        public AttendingLectureBL GetAttendingLectureByID(int attendingLectureId)
        {

            return _mapper.Map<AttendingLectureBL>(_attendingLectureRepository.GetAttendingLectureByID(attendingLectureId));
        }

        public void InsertAttendingLecture(AttendingLectureBL attendingLecture)
        {
            _attendingLectureRepository.InsertAttendingLecture(_mapper.Map<AttendingLecture>(attendingLecture));
            _attendingLectureRepository.Save();
        }

        public void DeleteAttendingLecture(int attendingLectureId)
        {
            _attendingLectureRepository.DeleteAttendingLecture(attendingLectureId);
            _attendingLectureRepository.Save();
        }

        public void UpdateAttendingLecture(AttendingLectureBL attendingLecture)
        {

            _attendingLectureRepository.UpdateAttendingLecture(_mapper.Map<AttendingLecture>(attendingLecture));
            _attendingLectureRepository.Save();
        }






    }
}
