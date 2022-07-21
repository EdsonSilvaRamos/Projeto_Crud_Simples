using System.Collections.Generic;
using System.ServiceModel;
using WCFServiceHost.Dependencias;
using WebForm.DTOs;

namespace WCFServiceHost
{

    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormatAttribute]
        IList<Clientes> RetornaClientes();

        [OperationContract]
        [ReferencePreservingDataContractFormatAttribute]
        Clientes RetornaClientePor(int id);

        [OperationContract]
        Clientes AdicionaCliente(Clientes clientes);

        [OperationContract]
        Clientes AtualizaCliente(ClienteEnderecoDTO clienteEnderecoDTO);

        [OperationContract]
        Clientes ExcluiClientePor(int id);
    }
}
