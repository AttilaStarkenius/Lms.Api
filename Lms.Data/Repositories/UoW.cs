using Lms.Core.Repositories;
using Lms.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    public class UoW : IUoW
    {
        private readonly LmsApiContext db;

        public IGameRepository GameRepository { get; private set; }
        public ITournamentRepository TournamentRepository { get; private set; }

        public UoW(LmsApiContext db)
        {
            this.db = db;
            GameRepository = new GameRepository(db);
            TournamentRepository = new TournamentRepository(db);
        }

        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
