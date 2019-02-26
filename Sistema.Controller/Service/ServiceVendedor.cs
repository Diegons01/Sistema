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
        private Model2019 model;

        public void Create(Vendedor vendedor)
        {
            model = new Model2019();
            model.Vendedor.Add(vendedor);
            model.SaveChanges();
        }

        public void Delete(Vendedor vendedor)
        {
            model = new Model2019();

            var obj = model.Vendedor.Find(vendedor.Id);

            model.Vendedor.Remove(obj);
            model.SaveChanges();
        }

        public void Update()
        {
            //model = new Model2019();
            //var obj = model.Vendedor.FirstOrDefault(x => x.Id == vendedor.Id);

            //obj.Nome = vendedor.Nome;
            //obj.Email = vendedor.Email;
            //obj.Telefone = vendedor.Telefone;
            //obj.Salario = vendedor.Salario;
            model.SaveChanges();
        }

        public List<Vendedor> ListVendedores()
        {
            model = new Model2019();

            var list = from vendedor in model.Vendedor.ToList()
                       join categoria in model.Categoria.ToList() on vendedor.CategoriaId equals categoria.Id
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
            model = new Model2019();
            return model.Vendedor.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
