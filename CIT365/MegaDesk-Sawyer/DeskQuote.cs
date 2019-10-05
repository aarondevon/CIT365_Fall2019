using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Sawyer
{
    public class DeskQuote
    {
        private string lastName = "";

        Desk desk = new Desk();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BaseDeskPrice { get; set; } = 200;

        public int DeskSurfaceArea()
        {
            int width = desk.Width = 5;
            int depth = desk.Depth = 6;
            return width * depth;
        }

    }
}