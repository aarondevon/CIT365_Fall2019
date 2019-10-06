using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MegaDesk_Sawyer
{
    public partial class AddQuote : Form
    {
        public DeskQuote deskQuote = new DeskQuote();
        public AddQuote()
        {
            InitializeComponent();
        }

        public static void LoadDeskMaterialCombo(ComboBox cbo)
        {
            cbo.DataSource = Enum.GetValues(typeof(DeskMaterial))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            cbo.DisplayMember = "Description";
            cbo.ValueMember = "value";
        }

        public static void LoadRushCombo(ComboBox cbo)
        {
            cbo.DataSource = Enum.GetValues(typeof(RushDays))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            cbo.DisplayMember = "Description";
            cbo.ValueMember = "value";
        }

        private void AddQuote_Load(object sender, EventArgs e)
        {
            LoadDeskMaterialCombo(DeskMaterial);
            LoadRushCombo(Rush);
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            this.Close();
        }
        private void CreateQuote_Click(object sender, EventArgs e)
        {
            //if (numericWidth.Value >= deskQuote.getDesk().GetMinWidth() && numericWidth.Value <= 96)
            //{
            DisplayQuote displayQuote = new DisplayQuote(deskQuote, (MainMenu)Tag);

            deskQuote.FirstName = textBoxFirstName.Text;
            deskQuote.LastName = textBoxLastName.Text;
            deskQuote.getDesk().Depth = (int)numericWidth.Value;
            deskQuote.getDesk().Width = (int)numericDepth.Value;
            deskQuote.getDesk().Drawers = (int)numericDrawers.Value;
            deskQuote.getDesk().Material = DeskMaterial.Text;
            deskQuote.RushDays = Rush.Text;
                
            displayQuote.Show();
            this.Close();
            //}



        }

        //private void numericWidth_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if ((int)numericWidth.Value >= 24 && (int)numericWidth.Value <= 96)
        //    {
        //        labelWidthValidation.Text = "";
        //    }
        //    labelWidthValidation.Text = "Min width 24\" Max Width 96\"";
        //}
    }
    public enum DeskMaterial
    {
        [Description("Declined")]
        Declined = -1,
        [Description("Oak")]
        Oak = 0,
        [Description("Laminate")]
        Laminate = 1,
        [Description("Pine")]
        Pine = 2,
        [Description("Rosewood")]
        Rosewood = 3,
        [Description("Veneer")]
        Veneer = 4
    }

    public enum RushDays
    {
        [Description("No Rush")]
        Declined = -1,
        [Description("3")]
        Three = 0,
        [Description("5")]
        Five = 1,
        [Description("7")]
        Seven = 2,
    }
}
