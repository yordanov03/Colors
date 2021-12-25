using Application.Features.Colors;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class ColorsRepository : DataRepository<Color>, IColorsRepository
    {
        public ColorsRepository(PeopleAndColorsDbContext db) : base(db)
        {
        }

        public async Task<List<Color>> GetAllColors(CancellationToken cancellationToken)
        => await this.Data.Colors.ToListAsync(cancellationToken);

        public async Task<Color> GetColorByName(string color, CancellationToken cancellationToken)
        => await this.Data.Colors.FirstOrDefaultAsync(c => c.Name == color);
    }
}
