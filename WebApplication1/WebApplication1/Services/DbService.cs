using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _mainDbContext;
        public DbService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task AddDoctor(SomeSortOfDoctors someSortOfDoctors)
        {
            var addDoctor = new Doctor() { FirstName = someSortOfDoctors.FirstName, LastName = someSortOfDoctors.LastName, Email = someSortOfDoctors.Email };
            await _mainDbContext.AddAsync(addDoctor);
            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SomeSortOfDoctors>> GetDoctors()
        {
            var doctors = await _mainDbContext.Doctors
                .Select(e => new SomeSortOfDoctors
                {
                    IdDoctor = e.IdDoctor,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email
                }).ToListAsync();

            return doctors;
        }

        public async Task UpdateDoctor(SomeSortOfDoctors someSortOfDoctors)
        {
            var doctorExists = await _mainDbContext.Doctors.AnyAsync(e => e.IdDoctor == someSortOfDoctors.IdDoctor);

            if (!doctorExists)
            {
                throw new System.Exception($"Doktor o id nie istnieje");
            }
            var updateDoctor = await _mainDbContext.Doctors.SingleOrDefaultAsync(e => e.IdDoctor == someSortOfDoctors.IdDoctor);
            updateDoctor.FirstName = someSortOfDoctors.FirstName;
            updateDoctor.LastName = someSortOfDoctors.LastName;
            updateDoctor.Email = someSortOfDoctors.Email;
            await _mainDbContext.SaveChangesAsync();

            
        }
    }
}
