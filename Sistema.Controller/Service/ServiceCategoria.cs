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
        private Model2019 _dadosEF;

        public List<Categoria> ListCategoria()
        {
            _dadosEF = new Model2019();
            return _dadosEF.Categoria.ToList();
        }

        public void Create(Categoria categoria)
        {
            _dadosEF = new Model2019();

            _dadosEF.Categoria.Add(categoria);
            _dadosEF.SaveChanges();
        }

        public Categoria FindCategoria(int id)
        {
            _dadosEF = new Model2019();
            return _dadosEF.Categoria.FirstOrDefault(x => x.Id == id);
        }

        public void update()
        {
            _dadosEF.SaveChanges();
        }

        public void Delete(Categoria categoria)
        {
            _dadosEF = new Model2019();
            var obj = _dadosEF.Categoria.FirstOrDefault(x => x.Id == categoria.Id);

            _dadosEF.Categoria.Remove(obj);
            _dadosEF.SaveChanges();
        }
    }
}
