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
        // Find the reference to this code.
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
            try
            {
                int width = Convert.ToInt32(textBoxWidth.Text);
                int depth = Convert.ToInt32(textBoxDepth.Text);
                int drawers = Convert.ToInt32((textBoxDrawers.Text));
                if (validWidth(width) && validDepth(depth) && validDrawers(drawers))
                {
                    DisplayQuote displayQuote = new DisplayQuote(deskQuote, (MainMenu)Tag);

                    deskQuote.FirstName = textBoxFirstName.Text;
                    deskQuote.LastName = textBoxLastName.Text;
                    deskQuote.getDesk().Width = width;
                    deskQuote.getDesk().Depth = depth;
                    deskQuote.getDesk().Drawers = drawers;
                    deskQuote.getDesk().Material = DeskMaterial.Text;
                    deskQuote.RushDays = Rush.Text;

                    displayQuote.Show();
                    this.Close();
                }
                else
                {
                    if (!validWidth(width))
                    {
                        labelWidth.Text = "Range 24-96:";
                        labelWidth.ForeColor = Color.DarkRed;
                    }
                    if (!validDepth(depth))
                    {
                        labelDepth.Text = "Range 12-48:";
                        labelDepth.ForeColor = Color.DarkRed;
                    }
                    if (!validDrawers(drawers))
                    {
                        labelDrawers.Text = "Range 0-7:";
                        labelDrawers.ForeColor = Color.DarkRed;
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private bool validWidth(int width)
        {
            if (width >= deskQuote.getDesk().GetMinWidth() && width <= deskQuote.getDesk().GetMaxWidth())
            {
                return true;
            }

            return false;
        }

        private bool validDepth(int depth)
        {
            if (depth >= deskQuote.getDesk().GetMinDepth() && depth <= deskQuote.getDesk().GetMaxDepth())
            {
                return true;
            }

            return false;
        }

        private bool validDrawers(int drawers)
        {
            if (drawers >= deskQuote.getDesk().GetMinDrawers() && drawers <= deskQuote.getDesk().GetMaxDrawers())
            {
                return true;
            }

            return false;
        }


        private void textBoxWidth_KeyUp(object sender, KeyEventArgs e)
        {
            int width; 
            
            if (Int32.TryParse(textBoxWidth.Text, out width))
            {
                if (validWidth(width))
                {
                    labelWidth.Text = "Width:";
                    labelWidth.ForeColor = Color.Black;
                }
                else
                {
                    labelWidth.Text = "Invalid Width:";
                    labelWidth.ForeColor = Color.DarkRed;
                }
            }
        }
    }

    public enum DeskMaterial
    {
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
