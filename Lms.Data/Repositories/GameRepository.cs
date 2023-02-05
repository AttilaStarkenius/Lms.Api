using Bogus.DataSets;
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
    public class GameRepository : IGameRepository
    {
        private readonly LmsApiContext db;

        public GameRepository(LmsApiContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<Game?> FindAsync(int gameID)
        {
            return await db.Game.FindAsync(gameID);
        }
        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await db.Game.ToListAsync();
        }


        public void Add(Game booking)
        {
            ArgumentNullException.ThrowIfNull(booking, nameof(booking));
            db.Game.Add(booking);
        }

        public void Remove(Game attending)
        {
            ArgumentNullException.ThrowIfNull(attending, nameof(attending));
            db.Remove(attending);
        }

        //public async Task<IEnumerable<Game>> GetAllAsync()
        //{
        //    return await db.Game.ToListAsync();
        //}

        public async Task<Game?> GetAsync(int gameID)
        {
            ArgumentNullException.ThrowIfNull(gameID, nameof(gameID));
            return await db.Game.FirstOrDefaultAsync(m => m.Id == gameID);
        }

        public Task<bool> AnyAsync(int gameID)
        {
            throw new NotImplementedException();
        }

        public void Update(Game game)
        {
            db.Game.Update(game);
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
