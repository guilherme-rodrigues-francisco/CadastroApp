using CadastroApp.Application.Interfaces;

namespace CadastroApp.Application.Services;

public class ClienteService
{
    private readonly IClienteRepository _clienteRepository;
    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
}
