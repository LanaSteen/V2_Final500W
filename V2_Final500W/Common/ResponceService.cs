using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace V2_Final500W.Common
{
    public class ResponceService : ControllerBase
    {
        private readonly UniversityDbContext _context;
        public string GetResponce(int? id)
        {
            var resp = _context.Responces.Any(e => e.StatusCode == id).ToString();
            return resp;
        }
    }
}

