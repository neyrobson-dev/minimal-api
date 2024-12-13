using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;

namespace minimalApi.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}
