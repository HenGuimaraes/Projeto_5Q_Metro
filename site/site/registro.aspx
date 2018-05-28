&nbsp; <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="site.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/cadUsuario.css"/>
    <link rel="icon" href="img/logo-2.png"/><!--icone da pagina-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js" type="text/javascript"></script>
<%--    <script type="text/javascript"  lang="js">
        $(function () {
            $("#<%=txtNome.ClientID %>").keypress(function () {
                alert("Wow; Its Work!.")
            });
        });
    </script> --%>
</head>
<body>
    <form id="form1" runat="server">
            <div class="modalCadastro">
                <h1>Cadastro de usuários</h1>
                <div id="corpo">
                    <%-- Botoões, campos e dropDownList --%>
                    <asp:TextBox placeholder="Digite o nome completo" ID="txtNome" runat="server" /> 
                    
                    <asp:TextBox runat="server" ID="txtLogin" placeholder="Digite o login"/>

                    <asp:TextBox placeholder="Digite a senha" textMode="Password" runat="server" ID="txtSenha" />
               
                    <asp:TextBox placeholder="Confirme a senha" textMode="Password" runat="server" ID="txtConfirmarSenha" />
                 
                    <asp:DropDownList ID="dropDownList" runat="server" AppendDataBoundItems="true"/>
                    <!-- Botão para cadastrar -->
                    <asp:Button Text="Confirmar" runat="server" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
                    <!--Mensagem de erro -->
                    <asp:Label Text="" runat="server" ID="lblErro"/>
                </div>
            </div>            
    </form>
</body>
</html>
