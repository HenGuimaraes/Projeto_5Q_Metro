<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home2.aspx.cs" Inherits="site.Home2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" runat="server" href="~/css/home2.css"/>
    <link rel="stylesheet" href="css/fontawesome-all.min.css" />
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">

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
        <div id="myModal">
	        <div class="modal-content" id="modal-grafico">
                <span class="close">&times;</span>
                <div id="grafico" style="height:80%; width:98.6%">
                    <br />
                </div>
                <div style="margin-left:13.5%"></div>
            </div>
        </div>


        <!-- modal da tela de cadastro -->
		<div id="myModal2">
            <div class="modal-content" id="modal-cadastro">
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
                        <asp:Button Text="Confirmar" runat="server" CssClass="btn btn-default" ID="btnConfirmar" OnClick="btnConfirmar_Click" UseSubmitBehavior="false" />
                        <!--Mensagem de erro -->
                        <asp:Label Text="" runat="server" ID="lblErro"/>
                    </div>
                </div>           
            </div>
		</div>   




        <!-- modal da tela de cadastro -->
		<div id="myModal3">
            <div class="modal-content" id="modal-cadastro-trens">
                <span class="feichar">&times;</span><!-- "botão" de fechar a modal-->
                    <h1 align="center">Cadastro de Trens e Vagões</h1>
            </div>
		</div>   

        <!--Cabeçalho com menu dropdown e a logo-->
        <header>
            <nav class="navbar navbar-default" style="margin-bottom:0; background-color:white">
                <div class="container-fluid">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <img class="navbar-brand" id="logoIcon" src="img/logo-2.png"/>
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#menu" aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        </button>
                    </div>

                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse" id="menu">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Henrique <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                    <button type="button" class="btn btn-default" id="myBtn3" ><i class="fas fa-cog"></i>  Cadastrar usuários</button>
                                    <button type="button" class="btn btn-default" id="myBtn4" ><i class="fas fa-cog"></i>  Cadastrar trens e vagões</button>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#" id="sair">Sair</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div><!-- /.navbar-collapse -->
                </div><!-- /.container-fluid -->
            </nav>
        </header>
        <!--Imagem que fica abaixo do cabeçalho-->
        <section class="backImg"></section>
        <!--Corpo do site, onde fica os únicos dois botões principais-->
        <main id="main">
            <div>
		        <button type="button" class="btn btn-default" id="myBtn1"><i class="fas fa-chart-area"></i>   Temperatura em tempo real</button>
                <button type="button" class="btn btn-default" id="myBtn2" ><i class="fas fa-table"></i>   Trens, vagões e arduinos</button>
            </div>
        </main>
        <!--Rodapé-->
        <footer>
            <p>Site feito por: Alice Coelho | Henrique Guimarães | Jean Sales | Lucas Nascimento | Mateus Soares</p>
            <p>Contato: 5Q@gmail.com | (11)11111-1111 | (11)1111-1111</p>
        </footer>


        <script type="text/javascript" src="js/jquery-3.3.1.min.js"></script>
	    <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <!--Scripts que abrem e fecham as modais-->
        <!--Modal do gráfico-->
        <script>
            // pega o modal
            var modal = document.getElementById('myModal');

            // pega o botão que abre o modal
            var btn = document.getElementById('myBtn1');

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
            var modal2 = document.getElementById('myModal2');

            // pega o botão que abre o modal
            var btn1 = document.getElementById('myBtn3');
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


        <!--Modal da tela de cadastro de trens-->
        <script>
            // pega o modal
            var modal3 = document.getElementById('myModal3');

            // pega o botão que abre o modal
            var btn2 = document.getElementById('myBtn4');
            // botão de fechar o modal
            var span3 = document.getElementsByClassName('fechar')[0];

            // ao clicar no botão, deixa a modal fixa na tela 
            btn2.onclick = function () {
                modal3.style.display = "block";
            }
            // ao clicar no X, transforma a modal invisivel(none)
            span3.onclick = function () {
                modal3.style.display = "none";
            }

            // quando clicar fora do modal feichar
            modal3.onclick = function (event) {
                if (event.target == modal3) {
                    modal3.style.display = "none";
                }
            }
        </script>


    </form>
</body>
</html>
