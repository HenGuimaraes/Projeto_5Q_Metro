<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tabela.aspx.cs" Inherits="site.tabela" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList placeholder="trens"  ID="trens" runat="server">
                      <asp:ListItem text="trens" value="0"></asp:ListItem>
                   </asp:DropDownList>  
            <asp:Button Text="atualizar" ID="att" runat="server" onclick="att_Click" />
             <asp:button id="vagao1" runat="server" ReadOnly="True" Visible="False"></asp:button>
             <asp:button id="vagao2" runat="server" ReadOnly="True" Visible="False"></asp:button>
            <asp:button id="vagao3" runat="server" ReadOnly="True" Visible="False"></asp:button>
             <asp:button id="vagao4" runat="server" ReadOnly="True" Visible="False"></asp:button>
             <asp:button id="vagao5" runat="server" ReadOnly="True" Visible="False"></asp:button>
             <asp:button id="vagao6" runat="server" ReadOnly="True" Visible="False"></asp:button>
             <asp:button id="vagao7" runat="server" ReadOnly="True" Visible="False"></asp:button>
             <asp:button id="vagao8" runat="server" ReadOnly="True" Visible="False"></asp:button>
            <asp:DropDownList placeholder="vagoes" id="vagau" runat="server">
                
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
