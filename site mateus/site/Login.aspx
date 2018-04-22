<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="site.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css" > 
        #login{
            position:absolute;
           top: 35%;
           left: 35%;
        }
        #usuario {
            position: absolute;
            top: 30%;
            left: 25%;
        }
        #usuario1 {
            position: absolute;
            top: -200%;
            left: 35%;
            color: darkgray;
            outline-color: darkgray;
            font-family: Impact , Haettenschweiler, 'Arial Narrow Bold', sans-serif;
        }
            #u{
                  
            position:absolute;
            top: 55%;
            left:25%;
        }

        #senha1 {
            position: absolute;
            top: -40px;
            left: 75px;
            color: darkgray;
            outline-color: darkgray;
            font-family: Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
        } 
          #mg { left:1%;
               position:absolute;       
               top:3%;
          }
          #a {
                 position: absolute;
            top: 75%;
            left: 70%;
          }
    </style>
</head>
<body style="background-image:url(fundo.jpg)"; background-repeat:no-repeat>
    <form id="form1" runat="server">
        <div>

                    <div id="mg"> <img src="logo1.png" height="200" width="300" /> </div>
            <div id="login">
                <img src="login1.png" width=100% />
                <div id="usuario"> <div id="usuario1" > <h3> usuario </h3>  </div> <asp:TextBox ID="Usuario" runat="server" width="200" BorderColor="Gray"  >   </asp:TextBox> </div>
               <div id="u">  <div id="senha1"> <h3>senha </h3> </div> <asp:TextBox ID="Senha" runat="server" Width="200" BorderColor="Gray"> </asp:TextBox> </div>
                <div id="a">  <asp:Button Text="Enter" runat="server" ID="btnEnter" BackColor="Black" BorderStyle="Solid" BorderColor="#666666" Font-Names="Georgia" ForeColor="White" OnClick="btnEnter_Click" />  </div>
            </div>

                
        </div>
    </form>
</body>
</html>
