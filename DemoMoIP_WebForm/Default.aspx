<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoMoIP_WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <h2>Demo MoIP</h2>
    
    <div class="row">
        <div class="form-group">
            <label for="exampleInputEmail1">Token</label>
            <asp:TextBox ID="token" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:Button runat="server" OnClick="GerarToken_Click" Text="Gerar Token" CssClass="btn btn-success" />

    </div>
  
</asp:Content>
