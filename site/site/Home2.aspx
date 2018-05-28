
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home2.aspx.cs" Inherits="site.Home2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="~/css/home22.css" rel="stylesheet" type="text/css" runat="server"/>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <img id="logomenu" src="img/logo-2.png"/>
            <div class="dropdown">
                <asp:Button Text="dropdown" runat="server" ID="dropbtn"/>
              <div class="dropdown-content">
                <a href="#">Link 1</a>
                <a href="#">Link 2</a>
                <a href="#">Link 3</a>
              </div>
            </div>
        </header>
        <section class="header-site">
        </section>
        <div id="corpo">
		    <img src="img/icone12.png" class="icone2">
		    <button type="button" class="icone" id="myBtn">Grafico</button>
		    <img src="img/icone12.png" class="icone2">
            <button type="button" class="icone" id="botao" >Cadastrar usuários</button>
        </div>
        <footer>
            <p>Site feito por: Alice Coelho | Henrique Guimarães | Jean Sales | Lucas Nascimento | Mateus Soares</p>
            <p>Contato: 5Q@gmail.com | (11)11111-1111 | (11)1111-1111</p>
        </footer>
    </form>
</body>
</html>
