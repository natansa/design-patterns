using Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade.Interface;
using Gof.Patterns.Comportamentais.Command.Solucao.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Gof.Patterns.Comportamentais.Command.Solucao.Funcionalidade
{
    public class Compra : ICompra
    {
        private readonly IMemoryCache _cache;
        private readonly ICollection<Produto> _produtos;

        public Compra(IMemoryCache cache)
        {
            _produtos = cache.Get<ICollection<Produto>>(nameof(Produto));

            if (_produtos == null)
            {
                _produtos = new List<Produto>();
                cache.Set(nameof(Produto), _produtos);
            }

            _cache = cache;
        }

        public void Adicionar(Produto produto)
        {
            _cache.Remove(nameof(Produto));
            _produtos.Add(produto);
            _cache.Set(nameof(Produto), _produtos);
        }

        public decimal ObterValorTotal()
        {
            return _produtos.Sum(produto => produto.Valor);
        }

        public int ObterQuantidadeTotal()
        {
            return _produtos.Count();
        }
    }
}