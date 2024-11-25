<%@ Page Title="" Language="C#" MasterPageFile="~/UyePanel/UyeMaster.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="DepocumWebApplication.UyePanel.UrunEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formPanel">
    <div class="panelBaslik">
        <h3>Makale Ekle</h3>
    </div>
    <div class="panelIci bolunmus">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
            <span>Ürün Ekleme İşlemi Başarılı</span>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="sol">
            <div class="satir">
                <label>ÜRÜN</label><br />
                <asp:TextBox ID="tb_urun" runat="server" CssClass="metinKutu" placeholder="Ürün Adı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <label>DEPO</label><br />
                <asp:DropDownList ID="ddl_depolar" runat="server" CssClass="metinKutu" DataTextField="Isim" DataValueField="ID" AppendDataBoundItems="true">
                    <asp:ListItem Value="-1" Text="Depo Seçiniz"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="satir">
                <label>RAF</label><br />
                <asp:DropDownList ID="ddl_raflar" runat="server" CssClass="metinKutu" DataTextField="Isim" DataValueField="ID" AppendDataBoundItems="true">
                    <asp:ListItem Value="-1" Text="Raf Seçiniz"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="satir">
                <label>PALET</label><br />
                <asp:DropDownList ID="ddl_paletler" runat="server" CssClass="metinKutu" DataTextField="Isim" DataValueField="ID" AppendDataBoundItems="true">
                    <asp:ListItem Value="-1" Text="Palet Seçiniz"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="satir" style="padding-top: 15px;">
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="formButon" OnClick="lbtn_ekle_Click">Makale Ekle</asp:LinkButton>
                <div style="clear: both"></div>
            </div>
        </div>
        <div style="clear: both"></div>
    </div>
</div>
</asp:Content>
