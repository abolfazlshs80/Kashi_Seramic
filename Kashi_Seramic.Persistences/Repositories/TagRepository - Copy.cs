 using Kashi_Seramic.Persistences;
using Microsoft.EntityFrameworkCore;
using Pr_Signal_ir.Application.Contracts.Persistence;

using Pr_Signal_ir.Persistence;
using Pr_Signal_ir.Persistence.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Persistences.Repositories
{
    public class SliderRepository : GenericRepository<Slider>, Application.Contracts.Persistence.ISliderRepository
    {
        private readonly AppDbContext _dbContext;

        public SliderRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Slider> GetSliderWithDetails(int id)
        {
            return await _dbContext.Sliders.FirstOrDefaultAsync(A => A.Id == id);
        }

        public async Task<List<Slider>> GetSliderWithDetails()
        {
            return await _dbContext.Sliders.ToListAsync();
        }
    }
}
