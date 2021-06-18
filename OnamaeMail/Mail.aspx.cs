using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.Threading;
using System.Data;

namespace OnamaeMail
{
    public partial class Mail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //처음일 때
            {
                ddlYear.Text = Convert.ToString(DateTime.Now.Year);
                ddlMonth.Text = Convert.ToString(DateTime.Now.Month);
                ddlDay.Text = Convert.ToString(DateTime.Now.Day);

                ddlSYear.Text = Convert.ToString(DateTime.Now.Year);
                ddlSMonth.Text = Convert.ToString(DateTime.Now.Month);
                ddlSDay.Text = Convert.ToString(DateTime.Now.Day);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int StartYear = Convert.ToInt32(ddlSYear.Text);
            int StartMonth = Convert.ToInt32(ddlSMonth.Text);
            int StartDay = Convert.ToInt32(ddlSDay.Text);

            int EndYear = Convert.ToInt32(ddlYear.Text);
            int EndMonth = Convert.ToInt32(ddlMonth.Text);
            int EndDay = Convert.ToInt32(ddlDay.Text);

            DateTime StartTime = Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
            DateTime EndTime = Convert.ToDateTime(EndYear + "-" + EndMonth + "-" + (EndDay + 1));

            if (StartTime > EndTime)
            {
                lbWarnning.Text = "日付をもう一度確認して下さい。";
            }
            else
            { 
                lbWarnning.Text = "";
                search();
            }
            
        }

        protected void btnKeyword_Click(object sender, EventArgs e)
        {
            int StartYear = Convert.ToInt32(ddlSYear.Text);
            int StartMonth = Convert.ToInt32(ddlSMonth.Text);
            int StartDay = Convert.ToInt32(ddlSDay.Text);

            int EndYear = Convert.ToInt32(ddlYear.Text);
            int EndMonth = Convert.ToInt32(ddlMonth.Text);
            int EndDay = Convert.ToInt32(ddlDay.Text);

            DateTime StartTime = Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
            DateTime EndTime = Convert.ToDateTime(EndYear + "-" + EndMonth + "-" + (EndDay + 1));

            if (StartTime > EndTime)
            {
                lbWarnning.Text = "日付をもう一度確認して下さい。";
            }
            else
            {
                lbWarnning.Text = "";
                searchKeyword(ddlKeyword.Text, txtKeyword.Text);
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int StartYear = Convert.ToInt32(ddlSYear.Text);
            int StartMonth = Convert.ToInt32(ddlSMonth.Text);
            int StartDay = Convert.ToInt32(ddlSDay.Text);

            int EndYear = Convert.ToInt32(ddlYear.Text);
            int EndMonth = Convert.ToInt32(ddlMonth.Text);
            int EndDay = Convert.ToInt32(ddlDay.Text);

            DateTime StartTime = Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
            DateTime EndTime = Convert.ToDateTime(EndYear + "-" + EndMonth + "-" + (EndDay + 1));

            if (StartTime > EndTime)
            {
                lbWarnning.Text = "日付をもう一度確認して下さい。";
            }
            else
            {
                lbWarnning.Text = "";
                searchUnread();
            }
            
        }

        protected void btnunread_Click(object sender, EventArgs e)
        {
            int StartYear = Convert.ToInt32(ddlSYear.Text);
            int StartMonth = Convert.ToInt32(ddlSMonth.Text);
            int StartDay = Convert.ToInt32(ddlSDay.Text);

            int EndYear = Convert.ToInt32(ddlYear.Text);
            int EndMonth = Convert.ToInt32(ddlMonth.Text);
            int EndDay = Convert.ToInt32(ddlDay.Text);

            DateTime StartTime = Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
            DateTime EndTime = Convert.ToDateTime(EndYear + "-" + EndMonth + "-" + (EndDay + 1));

            if (StartTime > EndTime)
            {
                lbWarnning.Text = "日付をもう一度確認して下さい。";
            }
            else
            {
                lbWarnning.Text = "";
                searchKeywordUnread(ddlKeyword.Text,txtKeyword.Text);
            }
        }


        public void search()
        {
            int StartYear = Convert.ToInt32(ddlSYear.Text);
            int StartMonth = Convert.ToInt32(ddlSMonth.Text);
            int StartDay = Convert.ToInt32(ddlSDay.Text);

            int EndYear = Convert.ToInt32(ddlYear.Text);
            int EndMonth = Convert.ToInt32(ddlMonth.Text);
            int EndDay = Convert.ToInt32(ddlDay.Text);

            DateTime StartTime = Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
            DateTime EndTime = Convert.ToDateTime(EndYear + "-" + EndMonth + "-" + (EndDay + 1));

            using (var client = new ImapClient())
            {
                using (var cancel = new CancellationTokenSource())
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("日付", typeof(DateTime));
                    dt.Columns.Add("メールアドレス", typeof(string));
                    dt.Columns.Add("件名", typeof(string));
                    dt.Columns.Add("内容", typeof(string));

                    client.Connect("mail6.onamae.ne.jp", 993, true, cancel.Token);
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.Authenticate("kimhojun@triton-sys.co.jp", "rlaghwns1!", cancel.Token);

                    // The Inbox folder is always available...
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly, cancel.Token);

                    // let's try searching for some messages...
                    var query = SearchQuery.All;
                    foreach (var uid in inbox.Search(query, cancel.Token))
                    {
                        var message = inbox.GetMessage(uid, cancel.Token);

                        int result1 = DateTime.Compare(StartTime, message.Date.DateTime);
                        int result2 = DateTime.Compare(EndTime, message.Date.DateTime);

                        if (result1 < 0 && result2 > 0)
                        {
                            DataRow dr = dt.NewRow();
                            dr["日付"] = message.Date.DateTime;
                            dr["メールアドレス"] = message.From;
                            dr["件名"] = message.Subject;
                            dr["内容"] = message.TextBody;
                            dt.Rows.Add(dr);
                            inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                            inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                        }
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    client.Disconnect(true, cancel.Token);
                }
            }
        }

        public void searchKeyword(string ct ,string keyword) 
        {
            int StartYear = Convert.ToInt32(ddlSYear.Text);
            int StartMonth = Convert.ToInt32(ddlSMonth.Text);
            int StartDay = Convert.ToInt32(ddlSDay.Text);

            int EndYear = Convert.ToInt32(ddlYear.Text);
            int EndMonth = Convert.ToInt32(ddlMonth.Text);
            int EndDay = Convert.ToInt32(ddlDay.Text);

            DateTime StartTime = Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
            DateTime EndTime = Convert.ToDateTime(EndYear + "-" + EndMonth + "-" + (EndDay + 1));

            using (var client = new ImapClient())
            {
                using (var cancel = new CancellationTokenSource())
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("日付", typeof(DateTime));
                    dt.Columns.Add("メールアドレス", typeof(string));
                    dt.Columns.Add("件名", typeof(string));
                    dt.Columns.Add("内容", typeof(string));

                    client.Connect("mail6.onamae.ne.jp", 993, true, cancel.Token);
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.Authenticate("kimhojun@triton-sys.co.jp", "rlaghwns1!", cancel.Token);

                    // The Inbox folder is always available...
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly, cancel.Token);

                    // let's try searching for some messages...
                    var query = SearchQuery.All;
                    foreach (var uid in inbox.Search(query, cancel.Token))
                    {
                        var message = inbox.GetMessage(uid, cancel.Token);


                        int result1 = DateTime.Compare(StartTime, message.Date.DateTime);
                        int result2 = DateTime.Compare(EndTime, message.Date.DateTime);

                        if (result1 < 0 && result2 > 0 && ct == "メールアドレス")
                        {
                            bool isHave = Convert.ToString(message.From).Contains(keyword);
                            if (isHave == true)
                            {
                                DataRow dr = dt.NewRow();
                                dr["日付"] = message.Date.DateTime;
                                dr["メールアドレス"] = message.From;
                                dr["件名"] = message.Subject;
                                dr["内容"] = message.TextBody;
                                dt.Rows.Add(dr);
                                inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                                inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                            }   
                        }
                        else if (result1 < 0 && result2 > 0 && ct == "件名")
                        {
                            bool isHave = Convert.ToString(message.Subject).Contains(keyword);
                            if (isHave == true)
                            {
                                DataRow dr = dt.NewRow();
                                dr["日付"] = message.Date.DateTime;
                                dr["メールアドレス"] = message.From;
                                dr["件名"] = message.Subject;
                                dr["内容"] = message.TextBody;
                                dt.Rows.Add(dr);
                                inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                                inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                            }
                        }
                        else if (result1 < 0 && result2 > 0 && ct == "内容")
                        {
                            bool isHave = Convert.ToString(message.TextBody).Contains(keyword);
                            if (isHave == true)
                            {
                                DataRow dr = dt.NewRow();
                                dr["日付"] = message.Date.DateTime;
                                dr["メールアドレス"] = message.From;
                                dr["件名"] = message.Subject;
                                dr["内容"] = message.TextBody;
                                dt.Rows.Add(dr);
                                inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                                inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 s
                            }
                        }
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    client.Disconnect(true, cancel.Token);
                }
            }
        }

        
        public void searchUnread()
        {
            int StartYear = Convert.ToInt32(ddlSYear.Text);
            int StartMonth = Convert.ToInt32(ddlSMonth.Text);
            int StartDay = Convert.ToInt32(ddlSDay.Text);

            int EndYear = Convert.ToInt32(ddlYear.Text);
            int EndMonth = Convert.ToInt32(ddlMonth.Text);
            int EndDay = Convert.ToInt32(ddlDay.Text);

            DateTime StartTime = Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
            DateTime EndTime = Convert.ToDateTime(EndYear + "-" + EndMonth + "-" + (EndDay + 1));

            using (var client = new ImapClient())
            {
                using (var cancel = new CancellationTokenSource())
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("日付", typeof(DateTime));
                    dt.Columns.Add("メールアドレス", typeof(string));
                    dt.Columns.Add("件名", typeof(string));
                    dt.Columns.Add("内容", typeof(string));

                    client.Connect("mail6.onamae.ne.jp", 993, true, cancel.Token);
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.Authenticate("kimhojun@triton-sys.co.jp", "rlaghwns1!", cancel.Token);

                    // The Inbox folder is always available...
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly, cancel.Token);

                    // let's try searching for some messages...
                    var query = SearchQuery.All;
                    foreach (var uid in inbox.Search(SearchQuery.NotSeen))
                    {
                        var message = inbox.GetMessage(uid);
                        inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                        inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                        int result1 = DateTime.Compare(StartTime, message.Date.DateTime);
                        int result2 = DateTime.Compare(EndTime, message.Date.DateTime);

                        if (result1 < 0 && result2 > 0)
                        {
                            DataRow dr = dt.NewRow();
                            dr["日付"] = message.Date.DateTime;
                            dr["メールアドレス"] = message.From;
                            dr["件名"] = message.Subject;
                            dr["内容"] = message.TextBody;
                            dt.Rows.Add(dr);
                        }
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    client.Disconnect(true, cancel.Token);
                }
            }
        }

        public void searchKeywordUnread(string ct, string keyword)
        {
            int StartYear = Convert.ToInt32(ddlSYear.Text);
            int StartMonth = Convert.ToInt32(ddlSMonth.Text);
            int StartDay = Convert.ToInt32(ddlSDay.Text);

            int EndYear = Convert.ToInt32(ddlYear.Text);
            int EndMonth = Convert.ToInt32(ddlMonth.Text);
            int EndDay = Convert.ToInt32(ddlDay.Text);

            DateTime StartTime = Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
            DateTime EndTime = Convert.ToDateTime(EndYear + "-" + EndMonth + "-" + (EndDay + 1));

            using (var client = new ImapClient())
            {
                using (var cancel = new CancellationTokenSource())
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("日付", typeof(DateTime));
                    dt.Columns.Add("メールアドレス", typeof(string));
                    dt.Columns.Add("件名", typeof(string));
                    dt.Columns.Add("内容", typeof(string));

                    client.Connect("mail6.onamae.ne.jp", 993, true, cancel.Token);
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    client.Authenticate("kimhojun@triton-sys.co.jp", "rlaghwns1!", cancel.Token);

                    // The Inbox folder is always available...
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly, cancel.Token);

                    // let's try searching for some messages...
                    var query = SearchQuery.All;
                    foreach (var uid in inbox.Search(SearchQuery.NotSeen))
                    {
                        var message = inbox.GetMessage(uid);
                        inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                        

                        int result1 = DateTime.Compare(StartTime, message.Date.DateTime);
                        int result2 = DateTime.Compare(EndTime, message.Date.DateTime);

                        if (result1 < 0 && result2 > 0 && ct == "メールアドレス")
                        {
                            bool isHave = Convert.ToString(message.From).Contains(keyword);
                            if (isHave == true)
                            {
                                DataRow dr = dt.NewRow();
                                dr["日付"] = message.Date.DateTime;
                                dr["メールアドレス"] = message.From;
                                dr["件名"] = message.Subject;
                                dr["内容"] = message.TextBody;
                                dt.Rows.Add(dr);
                                inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                            }
                        }
                        else if (result1 < 0 && result2 > 0 && ct == "件名")
                        {
                            bool isHave = Convert.ToString(message.Subject).Contains(keyword);
                            if (isHave == true)
                            {
                                DataRow dr = dt.NewRow();
                                dr["日付"] = message.Date.DateTime;
                                dr["メールアドレス"] = message.From;
                                dr["件名"] = message.Subject;
                                dr["内容"] = message.TextBody;
                                dt.Rows.Add(dr);
                                inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                            }
                        }
                        else if (result1 < 0 && result2 > 0 && ct == "内容")
                        {
                            bool isHave = Convert.ToString(message.TextBody).Contains(keyword);
                            if (isHave == true)
                            {
                                DataRow dr = dt.NewRow();
                                dr["日付"] = message.Date.DateTime;
                                dr["メールアドレス"] = message.From;
                                dr["件名"] = message.Subject;
                                dr["内容"] = message.TextBody;
                                dt.Rows.Add(dr);
                                inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                            }
                        }
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    client.Disconnect(true, cancel.Token);
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://webmail6.onamae.ne.jp/?_task=mail&_mbox=INBOX");
        }

       
    }
}