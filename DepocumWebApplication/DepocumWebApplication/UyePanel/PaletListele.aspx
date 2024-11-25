<%@ Page Title="" Language="C#" MasterPageFile="~/UyePanel/UyeMaster.Master" AutoEventWireup="true" CodeBehind="PaletListele.aspx.cs" Inherits="DepocumWebApplication.UyePanel.PaletListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="formPanel" style="margin-top:15px">
    <div class="panelBaslik">
        <h3>Palet Listele</h3>
    </div>
    <div class="panelIci">
        <asp:ListView ID="lv_paletler" runat="server" OnItemCommand="lv_paletler_ItemCommand">
            <LayoutTemplate>
                <table class="schrodinger" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>No</th>
                        <th width="80%">Palet Adı</th>
                        <th width="80%">Raf ID</th>
                        <th >Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <%-- Burası listenin ana taşıyısı --%>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Raf_ID") %></td>
                    <td><%# Eval("DurumStr") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CssClass="tablobuton durum" CommandArgument='<%# Eval("ID") %>' CommandName="durum">Durum Değiştir</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablobuton sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                        <a href='PaletListele.aspx?kid=<%# Eval("ID") %>' class="tablobuton duzenle">Düzenle</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
</asp:Content>
