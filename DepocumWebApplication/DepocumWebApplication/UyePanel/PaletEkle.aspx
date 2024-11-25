<%@ Page Title="" Language="C#" MasterPageFile="~/UyePanel/UyeMaster.Master" AutoEventWireup="true" CodeBehind="PaletEkle.aspx.cs" Inherits="DepocumWebApplication.UyePanel.PaletEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="formPanel">
    <div class="panelBaslik">
        <h3>Palet Ekle</h3>
    </div>
    <div class="panelIci">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
              <asp:Label ID="lbl_basariliMesaj" runat="server"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="satir">
            <label>Palet Adı</label><br />
            <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu" placeholder="Palet Adı Giriniz"></asp:TextBox>
        </div>
        <div class="satir" style="padding-top:15px;">
            <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="formButon" OnClick="lbtn_ekle_Click">Palet Ekle</asp:LinkButton>
            <div style="clear:both"></div>
        </div>
    </div>
</div>
</asp:Content>
