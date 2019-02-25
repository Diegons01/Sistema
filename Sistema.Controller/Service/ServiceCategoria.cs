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
        private Model2019 _model;

        public List<Categoria> ListCategoria()
        {
            _model = new Model2019();
            return _model.Categoria.ToList();
        }

        public void Create(Categoria categoria)
        {
            _model = new Model2019();

            _model.Categoria.Add(categoria);
            _model.SaveChanges();
        }

        public Categoria FindCategoria(int id)
        {
            _model = new Model2019();
            return _model.Categoria.FirstOrDefault(x => x.Id == id);
        }

        public void update()
        {
            _model.SaveChanges();
        }

        public void Delete(Categoria categoria)
        {
            _model = new Model2019();
            var obj = _model.Categoria.FirstOrDefault(x => x.Id == categoria.Id);

            _model.Categoria.Remove(obj);
            _model.SaveChanges();
        }
    }
}
