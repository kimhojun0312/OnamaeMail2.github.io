using System;
using System.Web.UI.WebControls;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data;
using System.Drawing;

namespace OnamaeMail
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //처음일 때
            {
                ddlYear.Text = Convert.ToString(DateTime.Now.Year);
                ddlMonth.Text = Convert.ToString(DateTime.Now.Month);
                ddlDay.Text = Convert.ToString(DateTime.Now.Day);
                Offer();
                
            }
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            if(rdoIN.Checked == false)
            {
                Intro();
            }
            else
            {
                Offer();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string[] KW = new string[6];
            if(rdoIN.Checked == true)
            {
                KW[0] = txtKey1.Text;
                KW[1] = txtKey2.Text;
                if(ddlPeople.Text == "選択なし")
                {
                    KW[2] = "";
                }
                else
                {
                    KW[2] = ddlPeople.Text + "名";
                }
                if(ddlPay.Text == "選択なし")
                {
                    KW[3] = "";
                }
                else
                {
                    KW[3] = ddlPay.Text;
                }
               
                KW[4] = txtKey5.Text;
                KW[5] = txtKey6.Text;
            }
            else
            {
                if(ddlTeam.Text == "選択なし")
                {
                    KW[0] = "";
                }
                else if (ddlTeam.Text == "弊社社員")
                {
                    KW[0] = "弊社";
                }
                else if (ddlTeam.Text == "契約社員")
                {
                    KW[0] = ddlTeam.Text;
                }
                else if (ddlTeam.Text == "個人事業主")
                {
                    KW[0] = ddlTeam.Text;
                }
                
                KW[1] = txtKey2.Text;
                KW[2] = txtKey3.Text;
                if (ddlPay.Text == "選択なし")
                {
                    KW[3] = "";
                }
                else
                {
                    KW[3] = ddlPay.Text;
                }
                KW[4] = txtKey5.Text;
                KW[5] = txtKey6.Text;
            }
            

            Keyword keyword = new Keyword();
            DateTime startDay = CurrentTime(ddlYear.Text,ddlMonth.Text,ddlDay.Text);
            if (rdoIN.Checked == true)
            {
                if (rdoOK.Checked == true)
                {
                    GVList.DataSource = keyword.SearchKeyword("案件", KW, "true",startDay, Session["ID"].ToString(), Session["PWD"].ToString());
                    GVList.DataBind();
                }
                else if (rdoNG.Checked == true)
                {
                    GVList.DataSource = keyword.SearchKeyword("案件", KW, "false",startDay, Session["ID"].ToString(), Session["PWD"].ToString());
                    GVList.DataBind();
                }
            }
            else if (rdoOUT.Checked == true)
            {
                GVList.DataSource = keyword.SearchKeyword("人材", KW, "true", startDay, Session["ID"].ToString(), Session["PWD"].ToString());
                GVList.DataBind();
            }
            
            
        }
        protected void GVList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string title = GVList.Rows[index].Cells[3].Text;

                searchDetail(title);

                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "<script>$('#myModal').modal('show');</script>", false);
            }
        }
        private void searchDetail(string key)
        {
            using (var client = new ImapClient())
            {
                using (var cancel = new CancellationTokenSource())
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("日付", typeof(DateTime));
                    dt.Columns.Add("メールアドレス", typeof(string));
                    dt.Columns.Add("件名", typeof(string));

                    client.Connect("mail6.onamae.ne.jp", 993, true, cancel.Token);
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.Authenticate(Session["ID"].ToString(), Session["PWD"].ToString(), cancel.Token);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly, cancel.Token);

                    // let's try searching for some messages...
                    var query = SearchQuery.All;
                    foreach (var uid in inbox.Search(query, cancel.Token))
                    {
                        var message = inbox.GetMessage(uid, cancel.Token);
                        bool isHave = Convert.ToString(message.Subject).Contains(key);
                        if (isHave == true)
                        {
                            Keyword keyword = new Keyword();
                            string[] company = keyword.SearchCPName(Convert.ToString(message.TextBody));
                            txtCPName.Text = company[0];
                            txtManager.Text = company[1];
                            txtSign.Text = company[2];

                            string[] Result = keyword.MailInfo(company[3], company[4]);
                            txtResult1.Text = Result[0];
                            txtResult2.Text = Result[1];
                            txtResult3.Text = Result[2];
                            txtResult4.Text = Result[3];
                            txtResult5.Text = Result[4];
                            txtResult6.Text = Result[5];
                        }
                    }
                    client.Disconnect(true, cancel.Token);
                }
            }
        }
        private DateTime CurrentTime(string StartYear, string StartMonth, string StartDay)
        {
            return Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
        }
        private void Offer()
        {
            lblKey1.Visible = true;
            lblKey2.Visible = true;
            lblKey3.Visible = true;
            lblKey4.Visible = true;
            lblKey5.Visible = true;
            lblKey6.Visible = true;

            txtKey1.Visible = true;
            txtKey2.Visible = true;
            txtKey3.Visible = false;
            ddlPay.Visible = true;
            ddlPeople.Visible = true;
            txtKey5.Visible = true;
            txtKey6.Visible = false;

            lblKey1.Text = "案件名　　";
            lblKey2.Text = "業務内容　";
            lblKey3.Text = "募集人数　";
            lblKey4.Text = "　　　　　　　　　　　　　単価　　　";
            lblKey4a.Text = "万円以上";
            lblKey4a.Visible = true;
            lblPeople.Visible = true;
            lblKey5.Text = "必須スキル";
            lblKey6.Text = "外国人　　";

            lbResult1.Text = "案件名：　　";
            lbResult2.Text = "業務内容：";
            lbResult3.Text = "募集人数：　";
            lbResult4.Text = "必須スキル：";
            lbResult5.Text = "単価：　";
            lbResult6.Text = "外国人：　　";

            txtKey1.Text = "";
            txtKey2.Text = "";
            txtKey3.Text = "";
            txtKey5.Text = "";
            txtKey6.Text = "";

            rdoOK.Visible = true;
            rdoNG.Visible = true;

            ddlTeam.Visible = false;
        }
        public void Intro()
        {
            lblKey1.Visible = true;
            lblKey2.Visible = true;
            lblKey3.Visible = true;
            lblKey4.Visible = true;
            lblKey5.Visible = true;
            lblKey6.Visible = true;

            txtKey1.Visible = false;
            ddlTeam.Visible = true;
            txtKey2.Visible = true;
            txtKey3.Visible = true;
            ddlPay.Visible = true;
            txtKey5.Visible = true;
            txtKey6.Visible = true;
            lblPeople.Visible = false;
            ddlPeople.Visible = false;

            lblKey1.Text = "所属：　　　";
            lblKey2.Text = "　　　　　　　　　　　　　最寄り駅：　";
            lblKey3.Text = "移動可能日：";
            lblKey4.Text = "希望単価：　";
            lblKey4a.Text = "万円以下";
            lblKey5.Text = "スキル：　　";
            lblKey6.Text = "その他：　　";

            lbResult1.Text = "所属：　　　";
            lbResult2.Text = "最寄り駅：";
            lbResult3.Text = "スキル：　　"; 
            lbResult4.Text = "希望単価：　";
            lbResult5.Text = "移動可能日：";
            lbResult6.Text = "その他：　　";

            txtKey1.Text = "";
            txtKey2.Text = "";
            txtKey3.Text = "";
            txtKey5.Text = "";
            txtKey6.Text = "";
            rdoOK.Visible = false;
            rdoNG.Visible = false;
            lblKey4a.Visible = true;
            lblPeople.Visible = false;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("Login.aspx"));
        }
    }
}