using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Limilabs.Mail;
using Limilabs.Client.IMAP;
using System.Data;

namespace OnamaeMail
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (Imap imap = new Imap())
            {

                imap.ConnectSSL("mail6.onamae.ne.jp");
                try
                {
                    imap.UseBestLogin(txtLogin.Text + "@triton-sys.co.jp", txtPwd.Text);
                    Session["ID"] = txtLogin.Text + "@triton-sys.co.jp";
                    Session["PWD"] = txtPwd.Text;

                    Response.Redirect(string.Format("Search.aspx"));
                }
                catch 
                {
                    lbWarning.Text = "IDまたはパスワードに誤りがあります。";
                }


            }
        }
    }
}