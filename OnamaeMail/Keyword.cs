using System;
using System.Web.UI.WebControls;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data;

namespace OnamaeMail
{
    public class Keyword
    {
        public string[] SearchCPName(string list)
        {
            string[] company = new string[5]; 
            string Mail = list.Replace(" ", ""); //줄 바꿈 제거
            string body = Mail.Replace("　", ""); //띄어쓰기 제거
            company[4] = body;

            bool CPNameA = body.Contains("デジタルハーツ");
            bool CPNameB = body.Contains("株式会社Ｎ");
            bool CPNameC = body.Contains("株式会社アウトソーシングテクノロジー");　//안건
            bool CPNameD = body.Contains("株式会社スマートテックエンタテイメント");
            bool CPNameE = body.Contains("株式会社アウトソーシングテクノロジー"); //소개
            bool CPNameF = body.Contains("フューチャー・アンティークス株式会社");
            bool CPNameG = body.Contains("株式会社Miraie");
            bool CPNameH = body.Contains("アヴァント株式会社");

            if (CPNameA == true)
            {
                company[0] = "デジタルハーツ";
                company[1] = "寺田　泰明";
                company[2] = "株式会社デジタルハーツ　エンタープライズ事業本部 \r\n"
                             + "寺田　泰明\r\n"
                             + "〒164-1441 東京都新宿区西新宿3 - 20 - 2 東京オペラシティビル41F\r\n"
                             + "TEL：03-5333-1246\r\n"
                             + "sales-support@digitalhearts.com\r\n";
                company[3] = "A";
            }
            if (CPNameB == true)
            {
                company[0] = "株式会社 Ｎ";
                company[1] = "萩原寿夫";
                company[2] = "株式会社 Ｎ\r\n"
                            + "案件推進局　萩原寿夫　hisao@ngen.co.jp\r\n"
                            + "〒150-0002 渋谷区渋谷3-8-10 JS渋谷ビル9階\r\n";
                company[3] = "B";
            }
            if (CPNameC == true)
            {
                if (body.Contains("案件名") == true)
                {
                    company[0] = "株式会社アウトソーシングテクノロジー";
                    company[1] = "冨岡　大吾/Daigo Tomioka";
                    company[2] = "株式会社アウトソーシングテクノロジー （略称：OSTech） \r\n"
                                + "冨岡　大吾/Daigo Tomioka\r\n"
                                + "〒100-0005 東京都千代田区丸の内1-8-3 丸の内トラストタワー本館16F 17F\r\n"
                                + "Tel.03-3286-7888 Fax.03-3286-7889\r\n"
                                + "d-tomioka@ostechnology.co.jp\r\n"
                                + "Web：http://www.ostechnology.co.jp";     
                    company[3] = "C";
                }
                
            }
            if (CPNameD == true)
            {
                company[0] = "株式会社スマートテックエンタテイメント";
                company[1] = "寺田　泰明";
                company[2] = "株式会社スマートテックエンタテイメント \r\n"
                            + "寺田　泰明\r\n"
                            + "〒103-0025　東京都中央区日本橋茅場町1-13-13　七宝ビル２階\r\n"
                            + "TEL: 03-6264-8826 FAX: 03-6264-8827\r\n"
                            + "携帯: 090-7087-8920\r\n"
                            + "一般社団法人モバイル・コンテンツ・フォーラム";
                company[3] = "D";
            }
            if (CPNameE == true)
            {
                if (body.Contains("最寄り駅") == true)
                {
                    company[0] = "株式会社アウトソーシングテクノロジー";
                    company[1] = "加藤 佑麻 / Yuma Kato";
                    company[2] = "株式会社アウトソーシングテクノロジー （略称：OSTech） \r\n"
                                + "加藤 佑麻 / Yuma Kato\r\n"
                                + "〒330-0854 埼玉県さいたま市大宮区桜木町1 - 11 - 20 大宮JPビルディング 3F\r\n"
                                + "TEL :048-640-1350/ 048-640-1351\r\n"
                                + "Mail :y-kato@ostechnology.co.jp\r\n"
                                + "Web：http://www.ostechnology.co.jp";
                    company[3] = "E";
                }
            }
            if (CPNameF == true)
            {
                company[0] = "フューチャー・アンティークス株式会社";
                company[1] = "安部 伸宏";
                company[2] = "フューチャー・アンティークス株式会社 \r\n"
                          + "安部 伸宏\r\n"
                          + "〒150-0031 東京都渋谷区桜丘町22 - 14 N.E.SビルN棟1B\r\n"
                          + "TEL：03-6809-0785（代表）　 携帯：070-4510-4977\r\n"
                          + "Email：n.abe@futureantiques.co.jp\r\n"
                          + "URL：http://www.futureantiques.co.jp/";
                company[3] = "F";
            }
            if (CPNameG == true)
            {
                company[0] = "株式会社Miraie";
                company[1] = "塩田 陵平";
                company[2] = "株式会社Miraie \r\n"
                + "ITコンサルティング事業部　塩田 陵平\r\n"
                + "〒150-0002 東京都渋谷区渋谷1 - 12 - 2 クロスオフィス渋谷6階\r\n"
                + "TEL：03-5774-6300 FAX：03-5774-6301\r\n"
                + "MAIL　  ：shioda@miraie-group.jp\r\n"
                + "http://www.miraie-group.jp/";
                company[3] = "G";
            }
            if (CPNameH == true)
            {
                company[0] = "アヴァント株式会社";
                company[1] = "池田　凪沙";
                company[2] = "アヴァント株式会社\r\n"
                            + "SI事業部　SIサポート\r\n"
                            + "池田　凪沙　Ikeda Nagisa\r\n"
                            + "〒164-0011 東京都中野区中央5 - 2 - 1 第3ナカノビル6F\r\n"
                            + "TEL：03-6382-5970 FAX：03-6382-5971\r\n"
                            + "E-mail:nagisa.ikeda@avant-sl.com";
                company[3] = "H";
            }
            return company;
        }
        public string[] MailInfo(string CPCode, string body)
        {
            string[] Result = new string[6];

            if (CPCode == "A")
            {
                string begin = "【業務名】";
                string end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[0] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【作業内容】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[1] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【募集人数】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[2] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【必須スキル】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[3] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【単価】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[4] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【外国人】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[5] = body.Substring(0, body.IndexOf(end));
                    }
                }
            } // 구인
            if (CPCode == "B")
            {
                string begin = "【案件名】";
                string end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[0] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【概要】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[1] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【必須スキル】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[3] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【募集人数】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[2] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【単価】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[4] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【国籍制限】";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[5] = body.Substring(0, body.IndexOf(end));
                    }
                }
            } // 구인
            if (CPCode == "C")
            {
                string begin = "■案件名";
                string end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[0] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "■作業内容";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[1] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "■人数";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[2] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "■募集スキル";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[3] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "■単価";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[4] = body.Substring(0, body.IndexOf(end));
                    }
                }
                Result[5] = "該当なし";
            } // 구인
            if (CPCode == "D")
            {
                string begin = "所属：";
                string end = "名";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[0] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "最寄り駅：";
                end = "稼";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[1] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "稼動可能日：";
                end = "希";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[4] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "希望単価：";
                end = "ス";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[3] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "スキル：";
                end = "提";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[2] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "備考：";
                end = "*";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[5] = body.Substring(0, body.IndexOf(end));
                    }
                }
            }
            if (CPCode == "E")
            {
                string begin;
                string end;
               
                begin = "最寄り駅";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[1] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "■稼働可能日";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[4] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "単価";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[3] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "スキル";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[2] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "経験";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[5] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "所属";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[0] = body.Substring(0, body.IndexOf(end));
                    }
                }
            }
            if (CPCode == "F")
            {
                string begin;
                string end;
               
                begin = "【最寄駅】：";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[1] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【所属】：";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[0] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【単金】：";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[3] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【開始日】：";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[4] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【スキル】：";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[2] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "【備考】：";
                end = "【";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[5] = body.Substring(0, body.IndexOf(end));
                    }
                }
            }
            if (CPCode == "G")
            {
                string begin;
                string end;

                begin = "●最寄：";
                end = "●";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[1] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "●稼働：";
                end = "●";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[4] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "●単金：";
                end = "●";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[3] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "●スキル：";
                end = "●";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[2] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "●備考：";
                end = "━";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[0] = body.Substring(0, body.IndexOf(end));
                        Result[5] = body.Substring(0, body.IndexOf(end));
                    }
                }
            }
            if (CPCode == "H")
            {
                string begin ;
                string end;
                begin = "最寄駅：";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[1] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "■稼働日：";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[4] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "■所属：";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[0] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "■単価：";
                end = "■";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[3] = body.Substring(0, body.IndexOf(end));
                    }
                }
                begin = "■スキル";
                end = "≪";
                if (body.IndexOf(begin) > -1)
                {
                    body = body.Substring(body.IndexOf(begin) + begin.Length);
                    if (body.IndexOf(end) > -1)
                    {
                        Result[2] = body.Substring(0, body.IndexOf(end));
                    }
                }
                Result[5] = "該当なし";
            }
            return Result;
        }
        public DataTable SearchKeyword(string key, string[] Keyword, string OKNG, DateTime StartDay, string ID, string PWD)
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
                    client.Authenticate(ID, PWD, cancel.Token);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly, cancel.Token);

                    var query = SearchQuery.All;
                    foreach (var uid in inbox.Search(query, cancel.Token))
                    {
                        var message   = inbox.GetMessage(uid, cancel.Token);
                        

                        if (key == "案件")
                        {
                            bool isHave = Convert.ToString(message.Subject).Contains(key);
                            bool isHave2 = Convert.ToString(message.TextBody).Contains("要員");
                            bool keyword1 = (Convert.ToString(message.TextBody)).ToUpper().Contains(Keyword[0].ToUpper());
                            bool keyword2 = (Convert.ToString(message.TextBody)).ToUpper().Contains(Keyword[1].ToUpper());
                            bool keyword3 = Convert.ToString(message.TextBody).Contains(Keyword[2]);
                            bool keyword4 = Convert.ToString(message.TextBody).Contains(Keyword[3]);
                            bool keyword5 = (Convert.ToString(message.TextBody)).ToUpper().Contains(Keyword[4].ToUpper());
                            bool keyword6 = Convert.ToString(message.TextBody).Contains("不可");
                            if (OKNG == "true")
                            {
                                if (isHave == true && keyword1 == true && keyword2 == true && keyword3 == true && keyword5 == true && keyword6 == false)
                                {
                                    if(Keyword[3] == "")
                                    {
                                        int result1 = DateTime.Compare(StartDay, message.Date.DateTime);
                                        DateTime EndDay = Convert.ToDateTime(StartDay.Year + "-" + StartDay.Month + "-" + (StartDay.Day + 1));
                                        int result2 = DateTime.Compare(EndDay , message.Date.DateTime);

                                        if (result1 < 0 && result2 > 0)
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["日付"] = message.Date.DateTime;
                                            dr["メールアドレス"] = message.From;
                                            dr["件名"] = message.Subject;
                                            dt.Rows.Add(dr);
                                            inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                                            inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 101; i >= Convert.ToInt64(Keyword[3]); i--)
                                        {
                                            int result1 = DateTime.Compare(StartDay, message.Date.DateTime);
                                            DateTime EndDay = Convert.ToDateTime(StartDay.Year + "-" + StartDay.Month + "-" + (StartDay.Day + 1));
                                            int result2 = DateTime.Compare(EndDay, message.Date.DateTime);

                                            if (result1 < 0 && result2 > 0)
                                            {
                                                string want = i + "万";
                                                if (Convert.ToString(message.TextBody).Contains(want))
                                                {
                                                    DataRow dr = dt.NewRow();
                                                    dr["日付"] = message.Date.DateTime;
                                                    dr["メールアドレス"] = message.From;
                                                    dr["件名"] = message.Subject;
                                                    dt.Rows.Add(dr);
                                                    inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                                                    inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                                                }
                                            }
                                        }
                                    }
                                    
                                }
                            }
                            else
                            {
                                if (isHave == true && keyword1 == true && keyword2 == true && keyword3 == true && keyword5 == true && keyword6 == true)
                                {
                                    if (Keyword[3] == "")
                                    {
                                        int result1 = DateTime.Compare(StartDay, message.Date.DateTime);
                                        DateTime EndDay = Convert.ToDateTime(StartDay.Year + "-" + StartDay.Month + "-" + (StartDay.Day + 1));
                                        int result2 = DateTime.Compare(EndDay, message.Date.DateTime);

                                        if (result1 < 0 && result2 > 0)
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["日付"] = message.Date.DateTime;
                                            dr["メールアドレス"] = message.From;
                                            dr["件名"] = message.Subject;
                                            dt.Rows.Add(dr);
                                            inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                                            inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 101; i >= Convert.ToInt64(Keyword[3]); i--)
                                        {
                                            int result1 = DateTime.Compare(StartDay, message.Date.DateTime);
                                            DateTime EndDay = Convert.ToDateTime(StartDay.Year + "-" + StartDay.Month + "-" + (StartDay.Day + 1));
                                            int result2 = DateTime.Compare(EndDay, message.Date.DateTime);

                                            if (result1 < 0 && result2 > 0)
                                            {
                                                string want = i + "万";
                                                if (Convert.ToString(message.TextBody).Contains(want))
                                                {
                                                    DataRow dr = dt.NewRow();
                                                    dr["日付"] = message.Date.DateTime;
                                                    dr["メールアドレス"] = message.From;
                                                    dr["件名"] = message.Subject;
                                                    dt.Rows.Add(dr);
                                                    inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                                                    inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                                                }
                                            }
                                        }
                                    }
                                    
                                }
                            }

                        }
                        else if (key == "人材") // 인재
                        {
                            bool isHave = Convert.ToString(message.Subject).Contains(key);
                            bool isHave2 = Convert.ToString(message.TextBody).Contains("要員");
                            bool keyword1 = Convert.ToString(message.TextBody).Contains(Keyword[0]);
                            bool keyword2 = (Convert.ToString(message.TextBody)).ToUpper().Contains(Keyword[1].ToUpper());
                            bool keyword3 = (Convert.ToString(message.TextBody)).ToUpper().Contains(Keyword[2].ToUpper());
                            bool keyword4 = Convert.ToString(message.TextBody).Contains(Keyword[3]);
                            bool keyword5 = (Convert.ToString(message.TextBody)).ToUpper().Contains(Keyword[4].ToUpper());
                            bool keyword6 =  Convert.ToString(message.TextBody).Contains(Keyword[5]);

                            if (isHave == true || isHave2 == true || Convert.ToString(message.TextBody).Contains("エンジニアのご紹介") == true || Convert.ToString(message.TextBody).Contains("人材") == true)
                            {
                                if (keyword1 == true && keyword2 == true && keyword3 == true  && keyword5 == true && keyword6 == true && Convert.ToString(message.Subject).Contains("案件") == false)
                                {
                                    if (Keyword[3] == "")
                                    {
                                        int result1 = DateTime.Compare(StartDay, message.Date.DateTime);
                                        DateTime EndDay = Convert.ToDateTime(StartDay.Year + "-" + StartDay.Month + "-" + (StartDay.Day+1));
                                        int result2 = DateTime.Compare(EndDay, message.Date.DateTime);

                                        if (result1 < 0 && result2 > 0)
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr["日付"] = message.Date.DateTime;
                                            dr["メールアドレス"] = message.From;
                                            dr["件名"] = message.Subject;
                                            dt.Rows.Add(dr);
                                            inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                                            inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                                        }
                                    }
                                    else
                                    {
                                        for (int i = 10; i <= Convert.ToInt64(Keyword[3]); i++)
                                        {
                                            int result1 = DateTime.Compare(StartDay, message.Date.DateTime);
                                            DateTime EndDay = Convert.ToDateTime(StartDay.Year + "-" + StartDay.Month + "-" + (StartDay.Day + 1));
                                            int result2 = DateTime.Compare(EndDay, message.Date.DateTime);

                                            if (result1 < 0 && result2 > 0)
                                            {
                                                string want = i + "万";
                                                if (Convert.ToString(message.TextBody).Contains(want))
                                                {
                                                    DataRow dr = dt.NewRow();
                                                    dr["日付"] = message.Date.DateTime;
                                                    dr["メールアドレス"] = message.From;
                                                    dr["件名"] = message.Subject;
                                                    dt.Rows.Add(dr);
                                                    inbox.Open(FolderAccess.ReadWrite); // 쓰기 전용으로 열어줌
                                                    inbox.AddFlags(uid, MessageFlags.Seen, true); // 읽음 표시 
                                                }
                                            }
                                        }
                                    }
                                       
                                    
                                }
                            }
                        }
                    }
                    client.Disconnect(true, cancel.Token);
                    return dt;
                }
            }
        }
    

    }
}