using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CidadeService
    {

        public List<Cidade> Listar(int codigoUF)
        {
            using (var db = new ContextoEF())
            {
                return db.Cidades.Where(x => x.UF.ID == codigoUF).ToList();
            }
        }
        public Cidade Obter(int ID)
        {
            using (var db = new ContextoEF())
            {
                return db.Cidades.FirstOrDefault(x => x.ID == ID);
            }
        }
    }
}
