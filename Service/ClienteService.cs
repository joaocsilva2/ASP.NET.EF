using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service
{
    public class ClienteService
    {
        public void Salvar(Cliente cliente)
        {
            try
            {
                using (var db = new ContextoEF())
                {
                    if(cliente.ID != 0)
                    {
                        db.Clientes.Attach(cliente);
                        db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.Clientes.Add(cliente);
                    }
                    db.SaveChanges();
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                using (var db = new ContextoEF())
                {
                    var clientes = db.Clientes.ToList();

                    lista = clientes;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + " " + ex.InnerException);
            }
            return lista;
        }

        public Cliente ListarPorID(int ID)
        {
            Cliente cliente = new Cliente();
            try
            {
                using (var db = new ContextoEF())
                {
                    cliente = db.Clientes.FirstOrDefault(c => c.ID == ID);
                }
            }
            catch
            {
                throw new Exception();
            }
            return cliente;

        }

        public void Excluir(int ID)
        {
            try
            {
                using (var db = new ContextoEF())
                {
                    var cli = db.Clientes.FirstOrDefault(c => c.ID == ID);
                    if(cli != null)
                    {
                        db.Clientes.Remove(cli);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }

    }
}
