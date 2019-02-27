using System.Collections.Generic;
using System.Linq;
using Dados.EntityFramework;
using Sistema.Model.Entities;

namespace Sistema.Controller.Service
{
    public class ServiceCor
    {
        Model2019 _dadosEF = new Model2019();

        public List<Cor> ListCor()
        {
            return _dadosEF.Cor.ToList();                
        }
    }
}
