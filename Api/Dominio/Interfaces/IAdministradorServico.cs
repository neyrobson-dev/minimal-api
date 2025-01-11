using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO);
        List<Administrador> Todos(int? pagina = 1, string email = null, string perfil = null);
        Administrador? BuscarPorId(int id);
        Administrador Incluir(Administrador administrador);
    }
}
