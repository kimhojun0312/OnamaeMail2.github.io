<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="OnamaeMail.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>kim hojun</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css"
        rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="row">
            MAIL SEARCH&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Button ID="btnReturn" runat="server" Text="LOGOUT" OnClick="btnReturn_Click" /><br />
            <br />
            日付：<asp:DropDownList ID="ddlYear" runat="server">
                <asp:ListItem>2018</asp:ListItem>
                <asp:ListItem>2019</asp:ListItem>
                <asp:ListItem>2020</asp:ListItem>
                <asp:ListItem>2021</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblYears" runat="server" Text="年"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlMonth" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblMonths" runat="server" Text="月"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlDay" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblDays" runat="server" Text="日  "></asp:Label>
            <br />
            <br />
            検索条件：<asp:RadioButton ID="rdoIN" runat="server" Text="求人" GroupName="select" Checked="True" />
&nbsp;<asp:RadioButton ID="rdoOUT" runat="server" Text="紹介" GroupName="select"/>
            &nbsp;<asp:Button ID="btnChange" runat="server" Text="変更" OnClick="btnChange_Click" />
            &nbsp;<asp:UpdateProgress ID="UpdateProgress1" runat="server">
            </asp:UpdateProgress>
            <br />
            <br />
            <asp:Label ID="lblKey1" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlTeam" runat="server">
                <asp:ListItem>選択なし</asp:ListItem>
                <asp:ListItem>弊社社員</asp:ListItem>
                <asp:ListItem>契約社員</asp:ListItem>
                <asp:ListItem>個人事業主</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtKey1" runat="server" Visible="False" Width="280px"></asp:TextBox>
&nbsp;
            <asp:Label ID="lblKey2" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtKey2" runat="server" Visible="False" Width="280px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblKey3" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlPeople" runat="server">
                <asp:ListItem>選択なし</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblPeople" runat="server" Visible="False" Text ="名"></asp:Label>
            <asp:TextBox ID="txtKey3" runat="server" Visible="False" Width="280px"></asp:TextBox>
&nbsp;
            <asp:Label ID="lblKey4" runat="server" Visible="False" ForeColor="Black"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlPay" runat="server">
                <asp:ListItem>選択なし</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>75</asp:ListItem>
                <asp:ListItem>100</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblKey4a" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblKey5" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtKey5" runat="server" Visible="False" Width="280px"></asp:TextBox>
&nbsp;
            <asp:Label ID="lblKey6" runat="server" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rdoOK" runat="server" Text="可能" GroupName="foreign" Checked="True" />
            <asp:RadioButton ID="rdoNG" runat="server" Text="不可能" GroupName="foreign"/>
            <asp:TextBox ID="txtKey6" runat="server" Width="280px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" style="margin-left: 0px" Text="検索" Width="363px" />
            &nbsp; <br />
            &nbsp;&nbsp;
            <br />
            <asp:GridView ID="GVList" runat="server" OnRowCommand="GVList_RowCommand" >
                <Columns>
                    <asp:ButtonField Text="詳細" CommandName="Detail" />
                </Columns>
            </asp:GridView>

            <br />
            
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
            <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <!-- Modal -->
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                        aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="myModalLabel">
                                        メール内容</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="lbCPName" runat="server" Text="会社名：　　" ></asp:Label>
                                    <asp:TextBox ID="txtCPName" runat="server"  Width="550px" ReadOnly ="True" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="lbManager" runat="server" Text="担当者名：　"  ></asp:Label>
                                    <asp:TextBox ID="txtManager" runat="server" Text="" ReadOnly ="True" Width="550px" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="lbResult1" runat="server" Text="案件名：　　"></asp:Label>
                                    <asp:TextBox ID="txtResult1" runat="server" Text="" ReadOnly ="True" Width="550px" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="lbResult2" runat="server" Text="業内容：　" ></asp:Label>

            　                        <asp:TextBox ID="txtResult2" runat="server" Text="" ReadOnly ="True" Width="550px" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="lbResult3" runat="server" Text="募集人数：　" ></asp:Label>
                                    <asp:TextBox ID="txtResult3" runat="server" Text="" ReadOnly ="True" Width="550px" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="lbResult4" runat="server" Text="必須スキル："></asp:Label>
                                    <asp:TextBox ID="txtResult4" runat="server" Text="" ReadOnly ="True" Width="550px" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="lbResult5" runat="server" Text="契約携帯：　"></asp:Label>
                                    <asp:TextBox ID="txtResult5" runat="server" Text="" ReadOnly ="True"  Width="550px" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="lbResult6" runat="server" Text="外国人：　　" ></asp:Label>
                                    <asp:TextBox ID="txtResult6" runat="server" Text="" ReadOnly ="True" Width="550px" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="lbResult7" runat="server" Text="署名：　　" ></asp:Label>
            　                        <asp:TextBox ID="txtSign" runat="server" Height="60px" ReadOnly ="True" Width="550px" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>