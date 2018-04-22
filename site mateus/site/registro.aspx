<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="site.registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
         <style type="text/css" > 
                #cabe{
                    position:absolute;
                    top:10%;
                    left:30%;
                }
                #name {
                    position:absolute;
                    top: 20%;
                    left: 23%;
                    height:2%;
                    color:white;
                    font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;

                }
                #password{
                    position:absolute;
                    top:35%;
                   left:23%;
                     color:white;
                     height:2%;
                    font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
                }
                #password1 {
                    position:absolute;
                    top:50%;
                    left:23%;
                     color:white;
                    font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
                    height:2%;
                }
                #id {
                     position:absolute;
                    top: 65%;
                    left: 23%;
                    color:white;
                    font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
                    height:2%;

                }
                #img{
                    position:absolute;
                    top:3%;
                    left:0%;
                }
                #cargo{ 
                    position:absolute;
                    top:80%;
                    left:25%;

                }
                #a{
                    position:absolute;
                    top:80%;
                    left:100%;
                }
                    
             </style>
</head>
<body style="background-image:url(fundo.jpg)";
    background-repeat:no-repeat >
    <form id="form1" runat="server">
        <div>
       
           <div id="img"> <img src="logo1.png"    width=30%/></div>
            <div id="cabe"> <img src="login1.png" width=160%  />
                

                <div id="id"> ID <asp:TextBox placeholder="digite o id" ID="id1" runat="server" width="225%" Height="300%" > </asp:TextBox> </div>
                <div id="name">  Nome <asp:TextBox placeholder="digite o nome" ID="Nome" runat="server" width="197%" Height="300%" > </asp:TextBox></div>
                <div id="password"> Senha <asp:TextBox placeholder="digite a senha" runat="server" ID="Senha" width="193%" Height="300%"> </asp:TextBox> </div>
                <div id="password1"> Confirme a senha <asp:TextBox placeholder="digite a senha" runat="server" ID="Senha1" width="140%" Height="300%" > </asp:TextBox> </div>
                <div id="cargo"> <asp:DropDownList ID="cargos" runat="server" AutoPostBack="true" BackColor="Black" BorderStyle="Solid" BorderColor="#666666" Font-Names="Georgia" ForeColor="White" >
                                    <asp:ListItem Text="cargos" Value=""> </asp:ListItem>
                                    <asp:ListItem Text="gerente" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="piao" value="2"></asp:ListItem> 
                                 </asp:DropDownList> </div>
                <div id="a"> <asp:Button Text="confirmar" runat="server" ID="btnconfirmar" BackColor="Black" BorderStyle="Solid" BorderColor="#666666" Font-Names="Georgia" ForeColor="White" OnClick="btnconfirmar_Click" />   </div>
            </div>
               
            
       
        </div>
    </form>
</body>
</html>
