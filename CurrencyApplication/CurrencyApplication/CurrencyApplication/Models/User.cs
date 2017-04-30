using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyApplication.Models
{
    class User
    {
        string text = string.Empty;
        public string getText()
        {
            return this.text;
        }

        public void setText(string tex)
        {
            this.text = tex;
        }
    }
}
