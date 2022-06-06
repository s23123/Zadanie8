using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeSortOfDoctors>> GetDoctors();
        Task AddDoctor(SomeSortOfDoctors someSortOfDoctors);
        Task UpdateDoctor(SomeSortOfDoctors someSortOfDoctors);
    }
}
