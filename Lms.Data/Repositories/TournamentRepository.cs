using Lms.Core.Entities;
using Lms.Core.Repositories;
using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly LmsApiContext db;

        public TournamentRepository(LmsApiContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Tournament?> FindAsync(int tournamentID)
        {
            return await db.Tournament.FindAsync(tournamentID);
        }

        public void Add(Tournament booking)
        {
            ArgumentNullException.ThrowIfNull(booking, nameof(booking));
            db.Tournament.Add(booking);
        }

        public void Remove(Tournament attending)
        {
            ArgumentNullException.ThrowIfNull(attending, nameof(attending));
            db.Remove(attending);
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await db.Tournament.ToListAsync();
        }

        public async Task<Tournament?> GetAsync(int tournamentID)
        {
            ArgumentNullException.ThrowIfNull(tournamentID, nameof(tournamentID));
            return await db.Tournament.FirstOrDefaultAsync(m => m.Id == tournamentID);
        }

        public Task<bool> AnyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Tournament tournament)
        {
            db.Tournament.Update(tournament);
        }
    }
}
//        public LmsApiContext context;

//        public TournamentRepository(LmsApiContext context)
//        {
//            this.context = context;
//        }

//        public void Add(Tournament tournament)
//        {
//            context.Tournament.Add(tournament);
//        }

//        public Task<bool> AnyAsync(int id)
//        {
//            //return context.Tournament.Find(id);
//            return (Task<bool>)context.Tournament
//           .Where(tournament => tournament.Id == id)
//           .Select(tournament => tournament);
//        }

//        public async Task<IEnumerable<Tournament>> GetAllAsync()
//        {
//            return await context.Tournament.ToListAsync();
//            //Queryable<T> query = dbSet;

//            //if (filter != null)
//            //    query = query.Where(filter);

//            //if (includeProperties != null)
//            //    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
//            //        query = query.Include(includeProperty);

//            //if (orderBy != null)
//            //    return await orderBy(query).ToListAsync();

//            //return await query.ToListAsync();
//            //return context.Tournament.ToListAsync();
//            //var coins = await GetAllAsync(c => c.GameId == gameId && c.CurrencyId == partnerCurrencyId,
//            //includeProperties: nameof(Coin.Value));
//        }

//        public Task<Tournament> GetAsync(int id)
//        {
//            return (Task<Tournament>)context.Tournament
//                      .Where(tournament => tournament.Id == id)
//                      .Select(tournament => tournament);
//        }

//        public void Remove(Tournament tournament)
//        {
//            context.Tournament.Remove(tournament);              
//        }

//        public void Update(Tournament tournament)
//        {
//            context.Tournament.Update(tournament);
//        }
//    }
//}
