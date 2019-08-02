<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" MasterPageFile="~/site/employees/employees.Master" Inherits="adminsite.site.employees.performance.WebForm1" %>

<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">

    <title>SB Admin - Bootstrap Admin Template</title>

    <link href="../css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="../css/sb-admin.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <style>
        #bardiv {
          width: 100%;
          height: 500px;
        }

        #barhorizontaldiv {
          width: 98%;
          height: 500px;
        }

        #piediv {
          width: 100%;
          height: 300px;
        }

        #linediv {
          width: 100%;
          height: 500px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server"> 
    <asp:ScriptManager ID="smMain" runat="server" EnablePageMethods="true" />
    <!-- Page Heading -->
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                Estadísticas de la empresa
            </h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o"></i> Cursos, cuentas o permisos que utilizan más tiempo mensualmente</h3>
                </div>
                <div class="panel-body">
                    <div id="barhorizontaldiv"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <div class="panel panel-green" style="height:570px">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-long-arrow-right"></i> Promedio de horas trabajadas por día de la semana</h3>
                    <input type="button" onclick="getACPByMonth()" />
                </div>
                <div class="panel-body">
                    <div class="flot-chart">
                        <div id="piediv"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o"></i> Total de horas trabajadas por mes</h3>
                </div>
                <div class="panel-body">
                    <div id="linediv"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-yellow">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-long-arrow-right"></i> Cantidad de horas laborales por cargo</h3>
                </div>
                <div class="panel-body">
                    <div class="text-right">
                        <div id="bardiv"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="javaScript" ContentPlaceHolderID="js" runat="server">

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <script src="amcharts4/core.js"></script>
    <script src="amcharts4/charts.js"></script>
    <script src="amcharts4/themes/animated.js"></script>
    <script src="amcharts4/lang/es_ES.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function getACPByMonth() {
            PageMethods.GetACPByMonth(createPieChart);
        }
        function createPieChart(response, userContext, methodName) {
            alert(response);
        }
    </script>
</asp:Content>
