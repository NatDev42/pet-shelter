using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pet_shelter
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            welcome.InnerHtml = (string)Session["i"];
            Session["i"] = (int)Session["i"] + 1;
        }
    }
}