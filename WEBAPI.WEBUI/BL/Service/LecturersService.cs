using AutoMapper;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.WEBUI.BL.Service
{
    public class LecturersService : ILecturersService
    {

        private readonly ILecturerRepository _lecturerRepository;
        private readonly ILogger<LecturersService> _logger;
        private readonly IMapper _mapper;
        public LecturersService(IEducationRepository educationRepository, ILogger<LecturersService> logger, IMapper mapper)
        {
            _lecturerRepository = educationRepository.GetLecturerRepository();
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<LecturerBL> GetLecturers()
        {
            var lisLecturer = new List<LecturerBL>();
            _lecturerRepository.GetLecturers().ToList().ForEach(a => lisLecturer.Add(_mapper.Map<LecturerBL>(a)));
            return lisLecturer;

        }

        public LecturerBL GetLecturerByID(int lecturerID)
        {

            return _mapper.Map<LecturerBL>(_lecturerRepository.GetLecturers().Where(s => s.ID == lecturerID).FirstOrDefault());
        }

        public void InsertLecturer(LecturerBL lecturer)
        {
            _lecturerRepository.InsertLecturer(_mapper.Map<Lecturer>(lecturer));
            _lecturerRepository.Save();

        }

        public void DeleteLecturer(int lecturerID)
        {
            _lecturerRepository.DeleteLecturer(lecturerID);
            _lecturerRepository.Save();

        }

        public void UpdateLecturer(LecturerBL lecturer)
        {

            _lecturerRepository.UpdateLecturer(_mapper.Map<Lecturer>(lecturer));
            _lecturerRepository.Save();

        }

    }
}
