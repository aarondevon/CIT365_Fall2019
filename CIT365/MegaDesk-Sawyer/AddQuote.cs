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
    public partial class AddQuote : Form
    {
        DeskQuote deskQuote = new DeskQuote();
        public AddQuote()
        {
            InitializeComponent();
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            this.Close();
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

        private void AddQuote_Load(object sender, EventArgs e)
        {
            LoadDeskMaterialCombo(DeskMaterial);
        }

        private void CreateQuote_Click(object sender, EventArgs e)
        { 
            DisplayQuote displayQuote = new DisplayQuote();
            textBoxFirstName.Text = deskQuote.BaseDeskPrice.ToString();
            
            displayQuote.Show();
        }
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
}
