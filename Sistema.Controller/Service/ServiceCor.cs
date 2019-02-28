using System.Collections.Generic;
using System.Linq;
using Dados.EntityFramework;
using Sistema.Model.Entities;

namespace Sistema.Controller.Service
{
    public class ServiceCor
    {
        Model2019 _dadosEF = new Model2019();

        public void Create(Cor cor)
        {
            _dadosEF.Cor.Add(cor);
            _dadosEF.SaveChanges();
        }

        public void Update()
        {
            _dadosEF.SaveChanges();
        }

        public void Delete(Cor cor)
        {
            Cor obj = FindCor(cor);

            _dadosEF.Cor.Remove(obj);
            _dadosEF.SaveChanges();
       }

        public List<Cor> ListCor()
        {
            return _dadosEF.Cor.ToList();                
        }

        public Cor FindCor(Cor cor)
        {
            return _dadosEF.Cor.Find(cor.Id);
        }
    }
}
