using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCFWebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtProdId.Text = "";
                txtName.Text = "";
                txtPrice.Text = "";
                txtBrand.Text = "";
                txtWarranty.Text = "";
                txtDesc.Text = "";
                lblMsg.Text = "";
                txtProdId.Focus();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtProdId.Text != "") || (txtName.Text != "") || (txtPrice.Text != "") || (txtBrand.Text != "") || (txtDesc.Text != "") || (txtWarranty.Text != ""))
            {
                try
                {
                    ServiceReference1.Product product = new ServiceReference1.Product();
                    product.ProdId = txtProdId.Text;
                    product.Name = txtName.Text;
                    product.Price = txtPrice.Text;
                    product.Warranty= txtWarranty.Text;
                    product.Description = txtDesc.Text;
                    product.Brand = txtBrand.Text;

                    ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                    lblMsg.Text = "Employee ID: " + product.ProdId + ", " + client.AddProduct(product);
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Employee ID must be unique! ";
                }


            }
            else
            {

                lblMsg.Text = "All fields are mandatory! ";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void bntReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtProdId.Text = "";
            txtName.Text = "";
            txtBrand.Text = "";
            txtWarranty.Text = "";
            txtDesc.Text = "";
            txtPrice.Text = "";
            lblMsg.Text = "";
            txtProdId.Focus();
        }
    }
}