using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCFWebClient
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        ServiceReference1.Product product = new ServiceReference1.Product();
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetPanel(true, false);
            }
        }

        private void SetPanel(bool pSearch, bool pUpdate)
        {
            panSearch.Visible = pSearch;
            panUpdate.Visible = pUpdate;
        }
       

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                product.ProdId = txtSearch.Text.Trim();
                ds = new DataSet();
                ds = client.SearchProduct(product);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblProdId.Text = ds.Tables[0].Rows[0]["pid"].ToString();
                    txtPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                    txtBrand.Text = ds.Tables[0].Rows[0]["Brand"].ToString();
                    SetPanel(false, true);

                }
                else
                {
                    lblSearchResult.Text = "Please Enter Product ID !";
                    lblSearchResult.ForeColor = System.Drawing.Color.White;
                }

            }
            else
            {
                lblSearchResult.Text = "Please Enter product ID !";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetPanel(true, false);
            lblMsg.Text = "";
        }
        protected void bntUpdated_Click(object sender, EventArgs e)
        {
            product.ProdId = lblProdId.Text.Trim();
            product.Price = txtPrice.Text;
            product.Brand = txtBrand.Text;

            string result = client.UpdateProduct(product);
            lblSearchResult.Text = result;
            SetPanel(true, false);
            product.ProdId = "";
            product.Price = "";
            product.Brand = "";
        }
    }
}