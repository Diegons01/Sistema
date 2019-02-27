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
        private Model2019 _dadosEF;

        public void Create(Vendedor vendedor)
        {
            _dadosEF = new Model2019();
            _dadosEF.Vendedor.Add(vendedor);
            _dadosEF.SaveChanges();
        }

        public void Delete(Vendedor vendedor)
        {
            _dadosEF = new Model2019();

            var obj = _dadosEF.Vendedor.Find(vendedor.Id);

            _dadosEF.Vendedor.Remove(obj);
            _dadosEF.SaveChanges();
        }

        public void Update()
        {
            //model = new Model2019();
            //var obj = model.Vendedor.FirstOrDefault(x => x.Id == vendedor.Id);

            //obj.Nome = vendedor.Nome;
            //obj.Email = vendedor.Email;
            //obj.Telefone = vendedor.Telefone;
            //obj.Salario = vendedor.Salario;
            _dadosEF.SaveChanges();
        }

        public List<Vendedor> ListVendedores()
        {
            _dadosEF = new Model2019();

            var list = from vendedor in _dadosEF.Vendedor.ToList()
                       join categoria in _dadosEF.Categoria.ToList() on vendedor.CategoriaId equals categoria.Id
                       select vendedor;

            return list.ToList();

            //foreach (Vendedor item in obj)
            //{
            //    Categoria cat = serviceCategoria.FindCategoria(item.CategoriaId);
            //    item.Categoria = cat;

            //    vendedores.Add(item);
            //}

            //return new Model2019().Vendedor.ToList();            
        }

        public Vendedor Find(int id)
        {
            _dadosEF = new Model2019();
            return _dadosEF.Vendedor.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
