using PointixApp.DataLayer;
using PointixApp.Factories;
using PointixApp.Patterns;
using PointixApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointixApp.Forms
{
    public partial class AddProduct : Form
    {
        private Mediator mediator;
        private readonly AuthModel authmodel;
        private readonly AppDbContext context;
        private readonly Inventory inventory;
        public AddProduct()
        {
            InitializeComponent();
        }
        public AddProduct(AuthModel _authModel, AppDbContext _context, Inventory _inventory)
        {
            ManageLanguages.EquipLanguage(this);
            InitializeComponent();
            this.context = _context;
            this.authmodel = _authModel;
            this.mediator = new Mediator(context, authmodel);
            this.inventory = _inventory;
        }
        private void iconButton8_Click(object sender, EventArgs e)
        {
            try
            {
                DateOnly dateOnly = DateOnly.FromDateTime(dateTimePicker1.Value);

                if(NotesTextBox.Text == "Notes" || string.IsNullOrWhiteSpace(NotesTextBox.Text))
                    NotesTextBox.Text = "";

                var error = mediator.InventoryService
                    .AddProduct(authmodel, ProductName.Text, Convert.ToInt32(proqua.Text)
                    , Convert.ToInt32(minquapro.Text), Convert.ToDouble(proprice.Text), dateOnly,NotesTextBox.Text);
                if (error == null)
                {
                    if(ManageLanguages.Language == "en")
                        ExceptionHandler.ShowSuccess("Success", "Product Adding successfully");
                    else
                        ExceptionHandler.ShowSuccess("Success", "تم اضافة المنتج بنجاح!");
                }

                this.Close();

                inventory.RefreshDataGridView(mediator.InventoryService.GetProducts());
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Adding Error",ex);
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
