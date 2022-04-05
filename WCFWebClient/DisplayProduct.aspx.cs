using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCFWebClient
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
                ds = client.GetProduct();
                grdProducts.DataSource = ds;
                grdProducts.DataBind();
            }

        }
    }
}