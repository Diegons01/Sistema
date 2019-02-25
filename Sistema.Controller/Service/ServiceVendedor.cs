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
            //return new Model2019().Vendedor.ToList();
            return model.Vendedor.ToList();
        }
        
        public Vendedor Find(int id)
        {
            model = new Model2019();
            return model.Vendedor.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
