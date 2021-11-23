using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Domain.Repositories;
using GamingWorld.API.Shared.Persistence.Contexts;
using GamingWorld.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Business.Persistence.Repositories
{
    public class ParticipantRepository : BaseRepository, IParticipantRepository
    {
        public ParticipantRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Participant>> ListAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public Task<IEnumerable<Participant>> ListByTypeAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(Participant participant)
        {
            await _context.Participants.AddAsync(participant);
        }

        public async Task<Participant> FindByIdAsync(int id)
        {
            return await _context.Participants.FindAsync(id);
        }

        public void Update(Participant participant)
        {
            _context.Participants.Update(participant);
        }

        public Participant FindById(int id)
        {
            return _context.Participants.Find(id);
        }

        public void Remove(Participant participant)
        {
            _context.Participants.Remove(participant);
        }
    }
}