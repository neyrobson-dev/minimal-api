using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicoes
{
    public class VeiculoServico : IVeiculoServico
    {

        private readonly DbContexto _contexto;
        public VeiculoServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo? BuscarPorId(int id)
        {
            return _contexto.Veiculos.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> Todos(int? pagina = 1, string nome = null, string marca = null)
        {
            var query = _contexto.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => x.Nome.ToLower().Contains(nome.ToLower()));
            }

            if (!string.IsNullOrEmpty(marca))
            {
                query = query.Where(x => x.Marca.ToLower().Contains(marca.ToLower()));
            }

            int itensPerPagina = 10;

            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * itensPerPagina).Take(itensPerPagina);
            }

            return query.ToList();
        }
    }
}
