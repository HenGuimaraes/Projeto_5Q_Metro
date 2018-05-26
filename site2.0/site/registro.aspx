 &nbsp; <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="site.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/5qRe.css"/>
    <link rel="icon" href="img/logo-2.png"/><!--icone da pagina-->
</head>
<body style="background-image:url(fundoregistro.jpg)">
    <form id="form1" runat="server">
        <div>
            <img src="img/logo-2.png"  style="margin-left: 2%; margin-top: 2%;height:23%; width:20%;"/>
            <div class="div" style=" display: flex; flex-direction:column">
                <!---- logo da tela-->
                <div class="div1">
<%--                <div id="aviso">
                        <asp:Label Text="preencha todos os espaços" ID="Label2" runat="server" 
                        Style="margin-left:20%" ForeColor="Red" Visible="false" ></asp:Label>
                   
                        <asp:Label Text="seu id nao contem apenas numeros." ID="btnidlabel" runat="server" 
                        Style="margin-left:20%" ForeColor="Red" Visible="false"></asp:Label>

                        <asp:Label Text="Suas senhas nao batem." ID="btnlabel" runat="server"
                        Style="margin-left:20%"   ForeColor="Red" Visible="false"></asp:Label> 
                    </div>--%>

                    <!-- campos de cadastro -->
                    <asp:TextBox placeholder="Digite o nome completo" ID="txtNome" runat="server" /> 
                    
                    <asp:TextBox runat="server" ID="txtLogin" placeholder="Digite o login"/>

                    <asp:TextBox placeholder="Digite a senha" runat="server" ID="txtSenha" />
               
                    <asp:TextBox placeholder="Confirme a senha" runat="server" ID="txtConfirmarSenha" />
                 
                    <asp:DropDownList ID="dropDownList" runat="server" AppendDataBoundItems="true"
                        OnSelectedIndexChanged="dropDownList_SelectedIndexChanged"/>
                    <!-- Botão para cadastrar -->
                    <asp:Button Text="Confirmar" runat="server" ID="btnConfirmar" OnClick="btnConfirmar_Click" />
                    <!--Mensagem de erro -->
                    <asp:Label  Text="" runat="server" ID="lblErro" />
                    
                </div>
            </div>            
        </div>
    </form>
</body>
</html>
