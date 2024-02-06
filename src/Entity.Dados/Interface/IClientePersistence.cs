using Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dados.Interface
{
    public interface IClientePersistence
    {
        List<Cliente> ObterClientes();
        Cliente ObterClientePorId(int id);
        void InserirCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
        void DeletarCliente(Cliente cliente);
    }
}
