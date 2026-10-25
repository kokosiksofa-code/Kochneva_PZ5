using Naptki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naptki.Models;

namespace Naptki
{
    internal class Helper
    {
        private static BeveragePlantDBEntities _context;
        public static BeveragePlantDBEntities GetContext()
        {
            if (_context == null)
            {
                _context = new BeveragePlantDBEntities();
            }
            return _context;
        }
    }
}
