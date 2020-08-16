using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UFService
    {
        public List<UF> Listar()
        {
            using (var db = new ContextoEF())
            {
                return db.UF.ToList();
            }
        }
        public UF Obter(int ID)
        {
            using (var db = new ContextoEF())
            {
                return db.UF.FirstOrDefault(x => x.ID == ID);
            }
        }
    }
}
