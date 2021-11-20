using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Profiles.Persistence.Context;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Publications.Persistence.Repositories
{
    public class PublicationRepository : BaseRepository, IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _context.Publications.ToListAsync();
        }

        public async Task<IEnumerable<Publication>> ListByTypeAsync()
        {
            return await _context.Publications.ToListAsync();
        }

        public async Task AddAsync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindByIdAsync(int id)
        {
            return await _context.Publications.FindAsync(id);
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }

        public void Remove(Publication publication)
        {
            _context.Publications.Remove(publication);
        }
    }
}