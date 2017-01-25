<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoMoIP_WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <h2>Demo MoIP</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Finalizar Pedido</h4>
        <hr />
       
        <div class="form-group">
            
        </div>
       
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button  runat="server" OnClick="CreateUser_Click" Text="Comprar" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
    <script type="text/javascript">

    </script>


</asp:Content>
