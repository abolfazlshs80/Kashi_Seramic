

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface ISliderRepository : IGenericRepository<Slider>
    {
        Task<Slider> GetSliderWithDetails(int id);
        Task<List<Slider>> GetSliderWithDetails();
   

    }
}
