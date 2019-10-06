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
            labelWidth.Text = this.deskQuote.getDesk().Width.ToString();
            labelDepth.Text = this.deskQuote.getDesk().Depth.ToString();
            labelDeskTopArea.Text = this.deskQuote.DeskSurfaceArea().ToString();
        }
    }
}
