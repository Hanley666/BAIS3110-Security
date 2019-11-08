using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Hello");
            Response.Write(Request.QueryString["name"]);
            Response.Write("<br><br>");
            Response.Write("Message=<br>");
            Response.Write(aMessage.Text);
            Response.Write("<br>");

            if(Page.IsPostBack)
            {
                if(aMessage.Text.Contains("<script>"))
                {
                    Regex.Replace(aMessage.Text, "<script>", "&nbsp");
                    Regex.Replace(aMessage.Text, "</script>", "&nbsp");
                }
                Regex.Replace(aMessage.Text, "<b>", "&lt;b&gt;");
                Regex.Replace(aMessage.Text, "</b>", "&lt;/b&gt;");
                Regex.Replace(aMessage.Text, "<i>", "&lt;i&gt;");
                Regex.Replace(aMessage.Text, "</i>", "&lt;/i&gt;");
                Regex.Replace(aMessage.Text, "<u>", "&lt;u&gt;");
                Regex.Replace(aMessage.Text, "</u>", "&lt;/u&gt;");

            }

            if (Request.QueryString["name"] != null)
            {
                Regex reg = new Regex(@"^[a-zA-Z'.]{1,40}$");
                Response.Write(reg.IsMatch(Request.QueryString["name"]));

                if (!Regex.IsMatch(Request.QueryString["name"], @"^[a-zA-Z'.]{1,40}$"))
                    Response.Redirect("Default.aspx");
            }



        }
    }
}