using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Platform.Domain;
using Platform.Service.Services;

namespace Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private PlatformService _platformService;

        public PlatformsController(PlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public IEnumerable<PlatformDto> GetPlatform()
        {
            var platform = _platformService.GetAllPlatform();
            return platform;
        }

    }
}
