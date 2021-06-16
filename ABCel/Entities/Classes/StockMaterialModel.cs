using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCel.Entities.Classes
{
    public class StockMaterialModel : MaterialModel
    {
        public double Price { get; set; }
        public int Limit { get; set; }

    }
}
