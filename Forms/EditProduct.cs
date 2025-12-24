using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PointixApp.Forms
{
    public partial class EditProduct : Form
    {
        private readonly Product product;
        private readonly Inventory inventory;
        private Mediator mediator;
        private readonly AppDbContext context;
        private readonly AuthModel _authmodel;
        public EditProduct()
        {
            InitializeComponent();
        }
        public EditProduct(AppDbContext _context,Product product,Inventory inventory,AuthModel authmodel)
        {
            ManageLanguages.EquipLanguage(this);
            InitializeComponent();
            this.product = product; 
            this.inventory = inventory;
            this.context = _context;
            this._authmodel = authmodel;
            this.mediator = new Mediator(context,authmodel);

        }
        private void iconButton8_Click(object sender, EventArgs e)
        {
            try
            {
                DateOnly dateOnly = DateOnly.FromDateTime(dateTimePicker1.Value);

                if (textBox1.Text == "Notes" || string.IsNullOrWhiteSpace(textBox1.Text))
                    textBox1.Text = "";

                var error = mediator.InventoryService
                    .EditProduct
                    (_authmodel, product.ProductId, ProductName.Text,
                    Convert.ToInt32(proqua.Text), Convert.ToInt32(minquapro.Text),
                    Convert.ToDouble(proprice.Text), dateOnly, textBox1.Text);

                if (error == null)
                {
                    if(ManageLanguages.Language == "en")
                        ExceptionHandler.ShowSuccess("Success", "Product edited successfully");
                    else
                        ExceptionHandler.ShowSuccess("Success", "تم تعديل المنتج بنجاح!");
                }

                this.Close();

                inventory.RefreshDataGridView(mediator.InventoryService.GetProducts());

            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Editing Error", ex);
            }
        }
        private void EditProduct_Load(object sender, EventArgs e)
        {
            ProductName.Text = product.ProductName;
            proprice.Text = product.Price.ToString();
            proqua.Text = product.Quantity.ToString();
            minquapro.Text = product.MinmumQuantity.ToString();
            dateTimePicker1.Value = product.ExpireDate.ToDateTime(new TimeOnly());
        }
    }
}
