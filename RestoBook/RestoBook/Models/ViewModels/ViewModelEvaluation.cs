using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models.ViewModels
{
    public class ViewModelEvaluation
    {
        public int nbDelicieux { get; set; }
        public int percentDelicieux { get; set; }
        public int nbBon { get; set; }
        public int percentBon { get; set; }
        public int nbAcceptable { get; set; }
        public int percentAcceptable { get; set; }
        public int nbPassable { get; set; }
        public int percentPassable { get; set; }
        public int nbMauvais { get; set; }
        public int percentMauvais { get; set; }
    }
}
