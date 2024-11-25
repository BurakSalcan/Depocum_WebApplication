<%@ Page Title="" Language="C#" MasterPageFile="~/UyePanel/UyeMaster.Master" AutoEventWireup="true" CodeBehind="RafListele.aspx.cs" Inherits="DepocumWebApplication.UyePanel.RafListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="formPanel" style="margin-top:15px">
    <div class="panelBaslik">
        <h3>Raf Listele</h3>
    </div>
    <div class="panelIci">
        <asp:ListView ID="lv_raflar" runat="server" OnItemCommand="lv_raflar_ItemCommand">
            <LayoutTemplate>
                <table class="schrodinger" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>No</th>
                        <th width="80%">Raf Adı</th>
                        <th width="80%">Bağlı Olduğu Depo</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <%-- Listenin ana taşıyıcısı --%>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Depo_ID") %></td>
                    <td><%# Eval("DurumStr") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CssClass="tablobuton durum" CommandArgument='<%# Eval("ID") %>' CommandName="durum">Durum Değiştir</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablobuton sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                        <a href='RafListele.aspx?kid=<%# Eval("ID") %>' class="tablobuton duzenle">Düzenle</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
</asp:Content>
