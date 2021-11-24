using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Domain.Repositories;
using GamingWorld.API.Shared.Persistence.Contexts;
using GamingWorld.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Business.Persistence.Repositories
{
    public class TournamentRepository : BaseRepository, ITournamentRepository
    {
        public TournamentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tournament>> ListAsync()
        {
            return await _context.Tournaments.ToListAsync();
        }

        public Task<IEnumerable<Tournament>> ListByTypeAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(Tournament tournament)
        {
            await _context.Tournaments.AddAsync(tournament);
        }
        
        public Tournament FindById(int id)
        {
            return _context.Tournaments.Find(id);
        }
        
        public async Task<Tournament> ListWithParticipantsById(int id)
        {
            return await _context.Tournaments.Include(t=> t.Participants).ThenInclude(u=>u.User).FirstOrDefaultAsync(t=>t.Id==id);
        }

        public async Task<Tournament> FindByIdAsync(int id)
        {
            return await _context.Tournaments.FindAsync(id);
        }

        public void Update(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
        }

        public void Remove(Tournament tournament)
        {
            _context.Tournaments.Remove(tournament);
        }
    }
}