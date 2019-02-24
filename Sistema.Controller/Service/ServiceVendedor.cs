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

        public void SalvarVendedor(Vendedor vendedor)
        {
            model = new Model2019();

            model.Vendedor.Add(vendedor);
            model.SaveChanges();
        }
    }
}
