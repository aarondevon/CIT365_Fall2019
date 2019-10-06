using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Sawyer
{
    public partial class DisplayQuote : Form
    {
        private DeskQuote deskQuote;
        public DisplayQuote()
        {
            InitializeComponent();
        }

        public DisplayQuote(DeskQuote deskQuote)
        {
            InitializeComponent();
            this.deskQuote = deskQuote;
        }



        private void DisplayQuote_Load(object sender, EventArgs e)
        {
            //textBoxFirstName.Text = this.deskQuote.FirstName;
            labelCustomerValue.Text = $"{deskQuote.FirstName} {deskQuote.LastName}";
            labelDateValue.Text = $"{deskQuote.getDate()}";
            labelBasePriceValue.Text = $"${this.deskQuote.BaseDeskPrice}";
            labelAreaPriceValue.Text = $"${this.deskQuote.PriceDeskSurfaceArea()}";
            labelDrawersValue.Text = $"${this.deskQuote.getDesk().Drawers * 50}";
            labelTotalValue.Text = $"${this.deskQuote.GetTotal()}";
        }
    }
}
