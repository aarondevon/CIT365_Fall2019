﻿using System;
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

        public string getDate()

        {
            return DateTime.Now.ToString("MM.dd.yyy");
        }

        public int DeskSurfaceArea()
        { 
            return desk.Width * desk.Depth;
        }

        public int PriceDeskSurfaceArea()
        {
            int deskSurfaceArea = DeskSurfaceArea();

            if (deskSurfaceArea > 1000)
            {
                return deskSurfaceArea * 1;
            }
            
            return 0;
        }

        public int PriceDrawers()
        {
            return desk.Drawers * 50;
        }

        public int GetTotal()
        {
            return BaseDeskPrice + PriceDeskSurfaceArea() + PriceDrawers();
        }

        public Desk getDesk()
        {
            return desk;
        }

    }
}