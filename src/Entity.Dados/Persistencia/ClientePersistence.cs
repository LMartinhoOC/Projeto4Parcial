using Entity.Dados.Context;
using Entity.Dados.Interface;
using Entity.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dados.Persistencia
{
    public class ClientePersistence : IClientePersistence
    {
        private readonly BaseDadosContext _contexto;

        public ClientePersistence(BaseDadosContext contexto)
        {
            this._contexto = contexto;     
        }

        public void AtualizarCliente(Cliente cliente)
        {
            this._contexto.Entry(cliente).State = EntityState.Modified;
            this._contexto.SaveChanges();
        }

        public void DeletarCliente(Cliente cliente)
        {
            this._contexto.Clientes.Remove(cliente);
            this._contexto.SaveChanges();
        }

        public void InserirCliente(Cliente cliente)
        {
            this._contexto.Clientes.Add(cliente);
            this._contexto.SaveChanges();
        }

        public Cliente ObterClientePorId(int id)
        {
            return this._contexto
                .Clientes
                .AsNoTracking()
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public List<Cliente> ObterClientes()
        {
            return this._contexto
                .Clientes
                .AsNoTracking()
                .ToList();
        }
    }
}
