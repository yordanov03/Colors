using Application.Contracts;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Colors
{
    public interface IColorsRepository : IRepository<Color>
    {
        Task<List<Color>> GetAllColors(CancellationToken cancellationToken);
        Task<Color> GetColorByName(string color, CancellationToken cancellationToken);
    }
}
