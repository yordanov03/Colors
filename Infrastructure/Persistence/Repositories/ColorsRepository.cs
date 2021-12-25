using Application.Features.Colors;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class ColorsRepository : IColorsRepository
    {
        private readonly PeopleAndColorsDbContext _db;

        public ColorsRepository(PeopleAndColorsDbContext db)
        {
            this._db = db;
        }
        public async Task<List<Color>> GetAllColors(CancellationToken cancellationToken)
        => await this._db.Colors.ToListAsync(cancellationToken);

        public Task Save(Color entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
