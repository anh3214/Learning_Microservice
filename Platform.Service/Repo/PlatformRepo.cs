using Platform.Domain;
using Platform.Domain;
using Platform.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service.Repo
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(PlatformModel platObj)
        {
            if(platObj is null)
                throw new ArgumentNullException(nameof(platObj));


            _context.Platforms.Add(platObj);
        }

        public IEnumerable<PlatformModel> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public PlatformModel GetPlatformById(Guid id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
