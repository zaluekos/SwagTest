using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagDriver
{
    public interface IDriverFactory
    {
        public IDriverManager CreateDriverManager(string browserName);
    }
}
