using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka.Models
{
    public class SQLUposleniciRepository : IUposleniciRepository
    {
        private readonly AppDbContext context;

        public SQLUposleniciRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Uposlenici Delete(int id)
        {
           Uposlenici uposlenik = context.Uposlenici.Find(id);
            if(uposlenik != null)
            {
                context.Uposlenici.Remove(uposlenik);
                context.SaveChanges();
            }
            return uposlenik;
        }

        public Uposlenici DodajUposlenika(Uposlenici uposlenik)
        {
            context.Uposlenici.Add(uposlenik);
            context.SaveChanges();
            return uposlenik;
        }

        public Uposlenici Update(Uposlenici uposlenikUpdate)
        {
           var uposlenik = context.Uposlenici.Attach(uposlenikUpdate);
            uposlenik.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return uposlenikUpdate;
        }

        public IEnumerable<Uposlenici> vratiSveUposlenike()
        {
            return context.Uposlenici;
        }

        public Uposlenici vratiUposlenika(int id)
        {
           return context.Uposlenici.Find(id);
        }
    }
}
