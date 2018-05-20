&nbsp; <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="site.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/5q.css"/>
    <link rel="icon" href="img/logo-2.png"/><!--icone da pagina-->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <video autoplay loop muted>
			    <source src="videcurto.mp4" type="video/mp4"/>
		    </video>
            <div class="div">
                <img src="img/logo-2.png"  style="margin-left: 2%; margin-top: 2%;height:35%; width:20%;"/>
            
                <div id="d"><asp:TextBox placeholder="digite o id" ID="id1" runat="server"> 
                            </asp:TextBox>
                </div>
               
                <br/>

                <div id="se" >
                    <asp:TextBox placeholder="digite a senha" runat="server" ID="Senha"> 
                    </asp:TextBox> 
                </div>

                <br/>
            </div>
            <div id="but"> 
                <asp:Button Text="Próximo" runat="server" ID="btnproximo" Font-Size="16" BorderStyle="Outset" BackColor="Gray"
                       ForeColor="#333333" style="margin-top:-40%" onclick="btnproximo_Click"/> 
            </div>
            <div id="erro">
                <asp:Label Text="id ou usuario incorreto" ID="Label2" runat="server" 
                Style="margin-left:20%" ForeColor="Red" Visible="false" ></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
