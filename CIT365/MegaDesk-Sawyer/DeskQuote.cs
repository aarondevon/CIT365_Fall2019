using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Sawyer
{
    public class DeskQuote
    {
        private Desk desk = new Desk();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BaseDeskPrice { get; set; } = 200;

        public int DeskSurfaceArea()
        { 
            return desk.Width * desk.Depth;
        }

        public Desk getDesk()
        {
            return desk;
        }

    }
}