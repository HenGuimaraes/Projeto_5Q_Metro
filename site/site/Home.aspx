    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="site.Home" %>

<DOCTYPE! HTML>
<html>
    <head>
        <meta charset="utf-8">
         <meta http-equiv="X-IU-Compatible" content="IE-edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="css/home.css">
        <link rel="icon" href="img/logo-2.png">
    </head>
<body> 
    <form runat="server">
        <!--header-->
        <header>
            <nav class="nav">
                <div id="logo">
                    <img class="logomenu" src="img/logo-2.png"/>
                </div>
		        <!--menu-->
			    <div class="dropdown">
                    <%--<asp:Button Text="usuario" runat="server" class="dropbtn"/>
				    <div class="dropdown-content">
					    <a href="#">cadastro</a>
					    <a href="#">sair</a>
				    </div>--%>
			    </div>
            </nav>
        </header>
    
        <!--cidade-->
        <section class="header-site">
        </section>
        <!--div p enfeitar-->
<%--        <div class="divex"> 
        </div>--%>
	
	    <!--div e botões -->
            <div class="corpo">
		    <img src="img/icone12.png" class="icone2" style="margin-left:28%">
		    <button type="submit" class="icone">relatorio</button>
		    <img src="img/icone12.png" class="icone2" style="margin-left:12%">
		    <button type="submit" class="icone" >estastisticas</button>
        </div>

	    <!--footer-->
		    <footer>
		    <div class="divfoot">
			    <h3 class="footer">feito por:</h3>
			    <p class="footer">Alice Coelho</p>
			    <p class="footer">Jean Sales</p>
			    <p class="footer">Lucas Nascimento</p>
			    <p class="footer">Mateus Soares</p>
		    </div>
		    <div class="divfoot">
			    <h3 class="footer2">contato</h3><br>
			    <p class="footer2">5q@gmail.com.br </p>
			    <p class="footer2">(11)1111-1111</p>
			    <p class="footer2">(11)1111-1111</p>
		    </div>
		    </footer>
        </form>
    </body>
</html>