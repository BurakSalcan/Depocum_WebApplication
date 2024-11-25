<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="DepocumWebApplication.UyeGiris.UyeGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/GirisStyle.css" rel="stylesheet" />
    <meta name="robots" content="noindex, nofollow" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="karsilama">
            <h1 style="color:black; text-align: center">DEPOCUM UYGULAMASI GİRİŞ PANELİ</h1> <br /> 
            <label style="color:black; font-size:20px; padding-left: 100px">Üye girişi için lütfen bilgilerinizi giriniz.</label>
            <div class="maincerceve">
                <div class="panel">
                    <asp:Panel ID="pnl_hata" runat="server" CssClass="hatakutu" Visible="false">
                        <asp:Label ID="lbl_hatametin" runat="server"></asp:Label>
                    </asp:Panel>
                    <div class="satir">
                        <label style="color:white"; font-weight:900>MAİL İLE GİRİŞ YAPIN</label>
                        <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu" placeholder="mail@mail.com" Text="ali@ali.com"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <label style="color:white">PAROLA</label>
                        <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" Text="1234" placeholder="******"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <asp:CheckBox ID="cb_hatirla" runat="server" CssClass="check" Text="Beni Hatırla" />
                    </div>
                    <div class="satir" style="text-align:center">
                        <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="girisButon" OnClick="lbtn_giris_Click">Giriş Yap</asp:LinkButton>
                    </div>
                </div>
                <div style="clear:both"></div>
            </div>
        </div>
    </form>
</body>
</html>
