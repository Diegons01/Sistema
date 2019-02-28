using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados.EntityFramework;
using Sistema.Model.Entities;

namespace Sistema.Controller.Service
{
    public class ServiceVendedor
    {
        private Model2019 _dadosEF = new Model2019();

        public void Create(Vendedor vendedor)
        {
            _dadosEF.Vendedor.Add(vendedor);
            _dadosEF.SaveChanges();
        }

        public void Delete(Vendedor vendedor)
        {
            var obj = _dadosEF.Vendedor.Find(vendedor.Id);

            _dadosEF.Vendedor.Remove(obj);
            _dadosEF.SaveChanges();
        }

        public void Update()
        {
            _dadosEF.SaveChanges();
        }

        public List<Vendedor> ListVendedores()
        {
            var list = from vendedor in _dadosEF.Vendedor.ToList()
                       join categoria in _dadosEF.Categoria.ToList() on vendedor.CategoriaId equals categoria.Id
                       select vendedor;

            return list.ToList();
        }

        public Vendedor Find(int id)
        {
            return _dadosEF.Vendedor.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
