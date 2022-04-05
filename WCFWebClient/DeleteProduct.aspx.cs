using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCFWebClient
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridData();
            }
        }

        public void BindGridData()
        {
            DataSet ds = new DataSet();
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            ds = client.GetProduct();
            grdProducts.DataSource = ds;
            grdProducts.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            ServiceReference1.Product product = new ServiceReference1.Product();
            product.ProdId = txtSearch.Text.Trim();
            string result = client.DeleteProduct(product);

            if (result == "Record Deleted Successfully!")
            {
                BindGridData();
                lblSearchResult.Text = "Product Id : " + txtSearch.Text.Trim() + "Deleted Successfully!";
            }
            else
            {
                lblSearchResult.Text = "Product Id: " + txtSearch.Text.Trim() + "Not Found!";
            }
        }
    }
}