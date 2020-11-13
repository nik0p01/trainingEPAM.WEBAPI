using AutoMapper;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.WEBUI.BL.Service
{
    public class LecturesService : ILecturesService
    {

        private readonly ILectureRepository _lectureRepository;
        private readonly ILogger<LecturesService> _logger;
        private readonly IMapper _mapper;
        public LecturesService(IEducationRepository educationRepository, ILogger<LecturesService> logger, IMapper mapper)
        {
            _lectureRepository = educationRepository.GetLectureRepository();
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<LectureBL> GetLectures()
        {

            var lisLecture = new List<LectureBL>();
            _lectureRepository.GetLectures().ToList().ForEach(a => lisLecture.Add(_mapper.Map<LectureBL>(a)));
            return lisLecture;

        }

        public LectureBL GetLectureByID(int lectureID)
        {
            return _mapper.Map<LectureBL>(_lectureRepository.GetLectures().Where(s => s.ID == lectureID).FirstOrDefault());
        }

        public void InsertLecture(LectureBL lecture)
        {

            _lectureRepository.InsertLecture(_mapper.Map<Lecture>(lecture));
            _lectureRepository.Save();
        }

        public void DeleteLecture(int lectureID)
        {
            _lectureRepository.DeleteLecture(lectureID);
            _lectureRepository.Save();
        }

        public void UpdateLecture(LectureBL lecture)
        {

            _lectureRepository.UpdateLecture(_mapper.Map<Lecture>(lecture));
            _lectureRepository.Save();
        }


    }
}
