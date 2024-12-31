using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.Dominio.DTOs;

namespace MinimalApi.Dominio.Servicoes
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            return _contexto.Administradores.Where(x => x.Email == loginDTO.Email && x.Senha == loginDTO.Senha).FirstOrDefault();
        }

        public Administrador BuscarPorId(int id)
        {
            return _contexto.Administradores.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Administrador> Todos(int? pagina = 1, string email = null, string perfil = null)
        {
            var query = _contexto.Administradores.AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(email.ToLower()));
            }

            if (!string.IsNullOrEmpty(perfil))
            {
                query = query.Where(x => x.Perfil.ToLower().Contains(perfil.ToLower()));
            }

            int itensPerPagina = 10;

            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * itensPerPagina).Take(itensPerPagina);
            }

            return query.ToList();
        }

        public void Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();
        }
    }
}
