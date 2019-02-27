using System.Linq;
using System.Collections.Generic;
using Dados.EntityFramework;
using Sistema.Model.Entities;

namespace Sistema.Controller.Service
{
    public class ServiceProduto
    {
        private Model2019 _dadosEF = new Model2019();

        public void Create(Produto produto)
        {
            _dadosEF.Produto.Add(produto);
            _dadosEF.SaveChanges();
        }

        public void Update()
        {
            _dadosEF.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            var obj = _dadosEF.Produto.Find(produto.Id);
            _dadosEF.Produto.Remove(obj);
            _dadosEF.SaveChanges();
        }

        public Produto FindProtudo(Produto produto)
        {
            return _dadosEF.Produto.Find(produto.Id);
        }

        public List<Produto> ListProdutos()
        {
            var list = from Produto p in _dadosEF.Produto.ToList()
                       join Cor cor in _dadosEF.Cor on p.CorId equals cor.Id
                       join Categoria cat in _dadosEF.Categoria on p.CategoriaId equals cat.Id
                       select p;

            return list.ToList();
        }       
    }
}
