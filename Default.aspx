<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
        <asp:GridView  ID="Grid1" runat="server" AutoGenerateColumns=false 
            OnSelectedIndexChanged="SelectRow"   OnRowDataBound=RowData  
            Width="337px">
        <Columns>
        <asp:TemplateField HeaderText="System Prefix" SortExpression="systemPrefix">
            <ItemTemplate>
                <asp:Label ID="SystemLabel" runat="server" Text='<%# Eval("systemPrefix") %>' BorderStyle=None></asp:Label>
                <asp:TextBox ID="SystemTxtBox" runat="server" Text='<%# Eval("systemPrefix") %>' BorderStyle=None Visible=false ></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField HeaderText="Application Name"  DataField="appName" />
        <asp:BoundField HeaderText="Code"  DataField="code" />
        </Columns>
        
        <SelectedRowStyle BackColor=AliceBlue />

        </asp:GridView>

        <asp:Button ID=updateBtn1  runat=server OnClick="UpdateRow" Text=Update  Enabled=false />
        <asp:Button ID=deleteBtn1  runat=server OnClick="DeleteRow" Text=Delete  Enabled=false />

</asp:Content>
