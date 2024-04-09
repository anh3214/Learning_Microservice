using Platform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Domain
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<PlatformModel> GetAllPlatforms();

        PlatformModel GetPlatformById(Guid id);

        void CreatePlatform(PlatformModel platObj);
    }
}
