<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home2.aspx.cs" Inherits="site.Home2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/css/home3.css" rel="stylesheet" type="text/css" runat="server"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        function showDropDownMenu() {
            var btn = document.getElementById(<%=dropbtn.ClientID%>);
            var dropdown = document.getElementById("dropdown-content");
            if (dropdown.style.display == "none") {
                dropdown.style.display = "block";
            } else {
                dropdown.style.display = "none";
            }
        }

        google.charts.load('current', { packages: ['corechart', 'line'] });
        google.charts.setOnLoadCallback(desenharGrafico);

        var total = 0, grafico = null, data = null;
        var options = {
                'backgroundColor': 'transparent'
        };

        function desenharGrafico() {
            if (data == null) {
                data = new google.visualization.DataTable();
                data.addColumn('number', 'Tempo');
                data.addColumn('number', 'ºC');

                grafico = new google.visualization.LineChart(document.getElementById('grafico'));
            }

            grafico.draw(data,options, { title: "Temperaturas em Tempo Real" });

            setTimeout(function () {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json',
                    url: 'home.aspx/TemperaturaAtual',
                    data: '{}',
                    success: function (response) {
                        data.addRow([total, response.d]);
                        total++;
                        desenharGrafico();
                    },
                    error: function () {
                    }
                });
            }, 1000);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- modal do gráfico -->
        <div id="myModal" class="modal">
	        <div class="modal-content">
                <span class="close">&times;</span>
                <div id="grafico" style="height:80%; width:98.6%">
                    <br />
                </div>
                <div style="margin-left:13.5%"></div>
            </div>
        </div>
        <!-- modal da tela de cadastro -->
		<div id="modalteste" class="modal2">
            <div class="modal-cadastro">
                <span class="feichar">&times;</span><!-- "botão" de fechar a modal-->
                <div class="modalCadastro">
                    <h1 align="center">Cadastro de usuários</h1>
                    <div id="corpo">
                        <%-- Botoões, campos e dropDownList --%>
                        <asp:TextBox placeholder="Digite o nome completo" ID="txtNome" runat="server" /> 
                    
                        <asp:TextBox runat="server" ID="txtLogin" placeholder="Digite o login"/>

                        <asp:TextBox placeholder="Digite a senha" runat="server" TextMode="Password" ID="txtSenha" />
               
                        <asp:TextBox placeholder="Confirme a senha" runat="server" TextMode="Password" ID="txtConfirmarSenha" />
                 
                        <asp:DropDownList ID="dropDownList" runat="server" AppendDataBoundItems="true"/>
                        <!-- Botão para cadastrar -->
                        <asp:Button Text="Confirmar" runat="server" ID="btnConfirmar" OnClick="btnConfirmar_Click" UseSubmitBehavior="false" />
                        <!--Mensagem de erro -->
                        <asp:Label Text="" runat="server" ID="lblErro"/>
                    </div>
                </div>           
            </div>
		</div>   
        <!--Cabeçalho com menu dropdown e a logo-->
        <header>
            <img id="logomenu" src="img/logo-2.png"/>
            <div class="dropdown">
                <asp:Button Text="dropdown" runat="server" ID="dropbtn" ClientIDMode="Static"/>
              <div id="dropdown-content">
                <a href="#">Link 1</a>
                <a href="#">Link 2</a>
                <a href="#">Link 3</a>
              </div>
            </div>
        </header>
        <!--Imagem que fica abaixo do cabeçalho-->
        <section class="header-site"></section>
        <!--Corpo do site, onde fica os únicos dois botões principais-->
        <main>
            <div id="btn-conteiner">
		        <button type="button" class="icone" id="myBtn"><i class="fa fa-cog"></i>Grafico</button>
                <button type="button" class="icone" id="botao" ><i class="fa fa-cog"></i>Cadastrar usuários</button>
            </div>
        </main>
        <!--Rodapé-->
        <footer>
            <p>Site feito por: Alice Coelho | Henrique Guimarães | Jean Sales | Lucas Nascimento | Mateus Soares</p>
            <p>Contato: 5Q@gmail.com | (11)11111-1111 | (11)1111-1111</p>
        </footer>
        <!--Scripts que abrem e fecham as modais-->
        <!--Modal do gráfico-->
        <script>
            // pega o modal
            var modal = document.getElementById('myModal');

            // pega o botão que abre o modal
            var btn = document.getElementById('myBtn');

            // botão de feichar o modalx
            var span = document.getElementsByClassName('close')[0];

            // quando clica no botão
            btn.onclick = function () {
                modal.style.display = "block";
            };

            // quando clica no X
            span.onclick = function () {
                modal.style.display = "none";
            };

            // quando clicar fora do modal feichar
            modal.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
            };
        </script>
        <!--Modal da tela de cadastro-->
        <script>
            // pega o modal
            var modal2 = document.getElementById('modalteste');

            // pega o botão que abre o modal
            var btn1 = document.getElementById('botao');
            // botão de feichar o modal
            var span2 = document.getElementsByClassName('feichar')[0];

            // quando clica no botão
            btn1.onclick = function () {
                modal2.style.display = "block";
            }
            // quando clica no X
            span2.onclick = function () {
                modal2.style.display = "none";
            }

            // quando clicar fora do modal feichar
            modal2.onclick = function (event) {
                if (event.target == modal2) {
                    modal2.style.display = "none";
                }
            }
        </script>
    </form>
</body>
</html>
