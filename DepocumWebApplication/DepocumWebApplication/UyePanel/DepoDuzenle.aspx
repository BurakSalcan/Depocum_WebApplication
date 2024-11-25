<%@ Page Title="" Language="C#" MasterPageFile="~/UyePanel/UyeMaster.Master" AutoEventWireup="true" CodeBehind="DepoDuzenle.aspx.cs" Inherits="DepocumWebApplication.UyePanel.DepoDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="formPanel">
     <div class="panelBaslik">
         <h3>Depo Düzenle</h3>
     </div>
     <div class="panelIci">
         <asp:Panel ID="pnl_basarili" runat="server" CssClass="panel basarili" Visible="false">
             <span>Depo Düzenleme İşlemi Başarılı</span>
         </asp:Panel>
         <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panel basarisiz" Visible="false">
             <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
         </asp:Panel>
         <div class="satir">
             <label>Depo Adı</label><br />
             <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu" placeholder="Depo Adı Giriniz"></asp:TextBox>
         </div>
         <div class="satir">
             <asp:CheckBox ID="cb_durum" runat="server" CssClass="check" Text="Kategori Aktif"/>
         </div>
         <div class="satir" style="padding-top:15px;">
             <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="formButon" OnClick="lbtn_duzenle_Click">Depo Düzenle</asp:LinkButton>
             <div style="clear:both"></div>
         </div>
     </div>
 </div>
</asp:Content>
