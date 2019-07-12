using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class SQLLijekRepository : ILijekRepository
    {
        private readonly AppDbContext context;

        public SQLLijekRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Lijek> Lijekovi => context.Lijekovi.Include(c => c.Kategorija);

        public Lijek Add(Lijek lijek)
        {
            context.Lijekovi.Add(lijek);
            context.SaveChanges();
            return lijek;
        }

        public Lijek Delete(int id)
        {
            Lijek lijek = context.Lijekovi.Find(id);
            if (lijek != null)
            {
                context.Lijekovi.Remove(lijek);
                context.SaveChanges();
            }
            return lijek;
        }

        public Lijek Update(Lijek lijek)
        {
            var l = context.Lijekovi.Attach(lijek);
            l.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return lijek;
        }

        public Lijek VratiLijek(int lijekId) => context.Lijekovi.FirstOrDefault(p => p.LijekId == lijekId);

    }
}
