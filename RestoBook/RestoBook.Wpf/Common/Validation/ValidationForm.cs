using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestoBook.Common.Validation
{
    class ValidationForm
    {
        public static void ValidationInput(string text,string nom)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show(string.Concat("Saisir une valeur", nom));
                return;
            }
        }
    }
}
