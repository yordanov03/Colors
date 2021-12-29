using Application.Features.Colors;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class ColorsRepository : DataRepository<Color>, IColorsRepository
    {
        private readonly ILogger <ColorsRepository>_logger;
        public ColorsRepository(
            PeopleAndColorsDbContext db,
            ILogger<ColorsRepository> logger) : base(db)
        {
            this._logger = logger;
        }

        public async Task<List<Color>> GetAllColors(CancellationToken cancellationToken)
        => await this.Data.Colors.ToListAsync(cancellationToken);

        public async Task<Color> GetColorByName(string color, CancellationToken cancellationToken)
        {
            var colorToFind = this.Data.Colors.FirstOrDefault(c => c.Name == color);

            if (colorToFind == null)
            {
                this._logger.LogDebug("No such colors exists in db");
                throw new InvalidColorException($"{color} is not a valid color");
            }

            return await this.Data.Colors.FirstOrDefaultAsync(c => c.Name == color, cancellationToken);
        }
    }
}
