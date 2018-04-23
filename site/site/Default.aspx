<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="site.Default" %>

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
            <img src="img/logo-2.png"  style="margin-left: 2%; margin-top: 2%;height:30%; width:15%;"/>
            <form>
                <label for="ID"></label>
                <input placeholder="ID"/>
                <br/>
                <label for="senha"></label>
                <input placeholder="Senha" type="password" />
                <br/>
                <button type="submit" style="font-size: 16">Próximo</button>
            </form>
            
        </div>
        </div>
    </form>
</body>
</html>
