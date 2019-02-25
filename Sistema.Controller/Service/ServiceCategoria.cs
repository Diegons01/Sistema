using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados.EntityFramework;
using Sistema.Model.Entities;

namespace Sistema.Controller.Service
{
    public class ServiceCategoria
    {
        private Model2019 model;

        public List<Categoria> ListCategoria()
        {
            model = new Model2019();
            return model.Categoria.ToList();
        }

        public void Create(Categoria categoria)
        {
            model = new Model2019();

            model.Categoria.Add(categoria);
            model.SaveChanges();
        }
    }
}
