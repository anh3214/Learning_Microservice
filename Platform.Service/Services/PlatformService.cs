using AutoMapper;
using Platform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service.Services
{
    public class PlatformService
    {
        private IPlatformRepo _platformRepo;
        private IMapper _mapper;

        public PlatformService(IPlatformRepo platformRepo, IMapper mapper) 
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        public IEnumerable<PlatformDto> GetAllPlatform()
        {
            try
            {
                var platforms = _platformRepo.GetAllPlatforms();
                return _mapper.Map<IEnumerable<PlatformModel>, IEnumerable<PlatformDto>>(platforms);
            }catch (Exception ex)
            {
                throw;
            }
        }

    }
}
