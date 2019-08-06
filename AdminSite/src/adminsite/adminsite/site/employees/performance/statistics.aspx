<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="statistics.aspx.cs" Inherits="adminsite.site.employees.performance.statistics" %>

<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/plugins/datatables/dataTables.bootstrap.css">

    <title>AdminSite</title>

    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="../css/sb-admin.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.css'/>

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
          height: 500px;
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
                Estadísticas
            </h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-bar-chart-o"></i> Cursos, cuentas o permisos que utilizan más tiempo</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6" style="text-align: left;">
                            <label style="text-align:left;margin-top:10px">Mes: </label>
                            <asp:DropDownList ID="monthHBarChartDl" runat="server" CssClass="form-control textinput">
                                <asp:ListItem Text="Enero" Value="1" />
                                <asp:ListItem Text="Febrero" Value="2" />
                                <asp:ListItem Text="Marzo" Value="3" />
                                <asp:ListItem Text="Abril" Value="4" />
                                <asp:ListItem Text="Mayo" Value="5" />
                                <asp:ListItem Text="Junio" Value="6" />
                                <asp:ListItem Text="Julio" Value="7" />
                                <asp:ListItem Text="Agosto" Value="8" />
                                <asp:ListItem Text="Septiembre" Value="9" />
                                <asp:ListItem Text="Octubre" Value="10" />
                                <asp:ListItem Text="Noviembre" Value="11" />
                                <asp:ListItem Text="Diciembre" Value="12" />
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-6" style="text-align: left;">
                            <label style="text-align:left;margin-top:10px">Año: </label>
                            <asp:DropDownList ID="yearHBarChartDl" runat="server" CssClass="form-control textinput"></asp:DropDownList>
                        </div>
                        <div class="col-lg-12" style="margin-top:15px">
                            <input type="button" onclick="getACPByMonth()" value="Buscar" class="btn btn-lg" style="width:100%"/>
                        </div>
                    </div>
                    <div class="row">
                        <div id="barhorizontaldiv"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <div class="panel panel-green" style="height:700px">
                <div class="panel-heading">
                    <h3 class="panel-title"><i class="fa fa-long-arrow-right"></i> Promedio de horas trabajadas por día de la semana</h3>
                </div>
                <div class="panel-body">
                    <div class="flot-chart">
                        <div class="row">
                            <div class="col-lg-6" style="text-align: left;">
                                <label style="text-align:left;margin-top:10px">Mes: </label>
                                <asp:DropDownList ID="monthPieChartDl" runat="server" CssClass="form-control textinput">
                                <asp:ListItem Text="Enero" Value="1" />
                                <asp:ListItem Text="Febrero" Value="2" />
                                <asp:ListItem Text="Marzo" Value="3" />
                                <asp:ListItem Text="Abril" Value="4" />
                                <asp:ListItem Text="Mayo" Value="5" />
                                <asp:ListItem Text="Junio" Value="6" />
                                <asp:ListItem Text="Julio" Value="7" />
                                <asp:ListItem Text="Agosto" Value="8" />
                                <asp:ListItem Text="Septiembre" Value="9" />
                                <asp:ListItem Text="Octubre" Value="10" />
                                <asp:ListItem Text="Noviembre" Value="11" />
                                <asp:ListItem Text="Diciembre" Value="12" />
                            </asp:DropDownList>
                            </div>
                            <div class="col-lg-6" style="text-align: left;">
                                <label style="text-align:left;margin-top:10px">Año: </label>
                                <asp:DropDownList ID="yearPieChartDl" runat="server" CssClass="form-control textinput"></asp:DropDownList>
                            </div>
                            <div class="col-lg-12" style="margin-top:15px">
                                <input type="button" onclick="getAverageHoursPerDayOfWeek()" value="Buscar" class="btn btn-lg" style="width:100%"/>
                            </div>
                        </div>
                        <div class="row">
                            <div id="piediv"></div>
                        </div>
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
                    <div class="row">
                        <div class="col-lg-12">
                            <label style="text-align:right;margin-top:10px">Año: </label>
                            <select id="yearLineChartDl" class="form-control textinput">

                            </select>
                        </div>
                        <div class="col-lg-12" style="margin-top:15px">
                            <input type="button" onclick="getHoursPerMonth()" value="Buscar" class="btn btn-lg" style="width:100%"/>
                        </div>
                    </div>
                    <div class="row">
                        <div id="linediv"></div>
                    </div>
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
                        <div class="row">
                            <div class="col-lg-6" style="text-align: left;">
                                <label style="text-align:left;margin-top:10px">Mes: </label>
                                <asp:DropDownList ID="monthCarChartDl" runat="server" CssClass="form-control textinput">
                                <asp:ListItem Text="Enero" Value="1" />
                                <asp:ListItem Text="Febrero" Value="2" />
                                <asp:ListItem Text="Marzo" Value="3" />
                                <asp:ListItem Text="Abril" Value="4" />
                                <asp:ListItem Text="Mayo" Value="5" />
                                <asp:ListItem Text="Junio" Value="6" />
                                <asp:ListItem Text="Julio" Value="7" />
                                <asp:ListItem Text="Agosto" Value="8" />
                                <asp:ListItem Text="Septiembre" Value="9" />
                                <asp:ListItem Text="Octubre" Value="10" />
                                <asp:ListItem Text="Noviembre" Value="11" />
                                <asp:ListItem Text="Diciembre" Value="12" />
                            </asp:DropDownList>
                            </div>
                            <div class="col-lg-6" style="text-align: left;">
                                <label style="text-align:left;margin-top:10px">Año: </label>
                                <asp:DropDownList ID="yearBarChartDl" runat="server" CssClass="form-control textinput"></asp:DropDownList>
                            </div>
                            <div class="col-lg-12" style="margin-top:15px">
                                <input type="button" onclick="getTotalHoursPerPosition()" value="Buscar" class="btn btn-lg" style="width:100%"/>
                            </div>
                        </div>
                        <div class="row">
                            <div id="bardiv"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.row -->
</asp:Content>

<asp:Content ID="javaScript" ContentPlaceHolderID="js" runat="server">

    <!-- jQuery -->
    <script src="../js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/sweet.js"></script>

    <!-- DataTables -->
    <script src="../css/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../css/plugins/datatables/dataTables.bootstrap.min.js"></script>

    <script src="amcharts3/lib/amcharts.js"></script>
    <script src="amcharts3/lib/pie.js"></script>
    <script src="amcharts3/lib/serial.js"></script>
    <script src="amcharts3/lib/lang/es.js"></script>
    <script src="amcharts3/lib/plugins/export/export.min.js"></script>
    <script src="amcharts3/lib/plugins/responsive/responsive.min.js"></script>
    <link rel="stylesheet" href="amcharts3/lib/plugins/export/export.css" type="text/css" media="all" />

    
    <!-- Horizontal bar chart code -->
    <script type="text/javascript">
        $(document).ready(function () {
            populateYears();
        });

        function populateYears() {
            var dropdown = document.getElementById("yearLineChartDl");
            
            for (var i = 2010; i < 2051; ++i) {
                dropdown[dropdown.length] = new Option(i, i);
            }
        }
    </script>
    <!-- Horizontal bar chart code -->
    <script type="text/javascript">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        function getACPByMonth() {
            PageMethods.GetACPByMonth(createHorizontalBarChart);
        }
        function createHorizontalBarChart(response, userContext, methodName) {
            var chart = AmCharts.makeChart("barhorizontaldiv", {
              "type": "serial",
              "theme": "none",
              "categoryField": "year",
              "rotate": true,
              "startDuration": 1,
              "categoryAxis": {
                "gridPosition": "start",
                "position": "left"
              },
              "trendLines": [],
              "graphs": [
                {
                  "balloonText": "Income:[[value]]",
                  "fillAlphas": 0.8,
                  "id": "AmGraph-1",
                  "lineAlpha": 0.2,
                  "title": "Income",
                  "type": "column",
                  "valueField": "income"
                }
              ],
              "guides": [],
              "valueAxes": [
                {
                  "id": "ValueAxis-1",
                  "position": "top",
                  "axisAlpha": 0
                }
              ],
              "allLabels": [],
              "balloon": {},
              "titles": [],
              "dataProvider": getDataHorizontal(response),
              "export": {
                "enabled": true
              }

            });
        }
        function getDataHorizontal(data) {
            var chartData = [];
            var dataSplitted = data.split(";");
            for (var i = 0; i < dataSplitted.length; i++) {
                var statistic = dataSplitted[i].split(",");
                chartData.push({
                    year: statistic[0],
                    income: statistic[1]
                });
            }
            return chartData;
        }

    </script>
        
    <!-- Pie chart code -->
    <script type="text/javascript">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        function getAverageHoursPerDayOfWeek() {
            PageMethods.GetAverageHoursPerDayOfWeek(createPieChart);
        }
        function createPieChart(response, userContext, methodName) {
            var chart = AmCharts.makeChart( "piediv", {
              "type": "pie",
              "radius": 140,
                "theme": "none",
                "dataProvider": getDataPie(response),
              "valueField": "litres",
              "titleField": "country",
               "balloon":{
               "fixedPosition":true
              },
              "export": {
                "enabled": true
              },
              "responsive": {
                "enabled": true,
                "addDefaultRules": true,
                "rules": [
                  {
                    "minWidth": 500
                  }
                ]
              }
            } );
        }
        function getDataPie(data) {
            var chartData = [];
            var dataSplitted = data.split(";");
            for (var i = 0; i < dataSplitted.length; i++) {
                var statistic = dataSplitted[i].split(",");
                chartData.push({
                    country: statistic[0],
                    litres: statistic[1]
                });
            }
            return chartData;
        }
        function getRandomColor() {
            var letters = '0123456789ABCDEF';
            var color = '#';
            for (var i = 0; i < 6; i++) {
            color += letters[Math.floor(Math.random() * 16)];
            }
            return color;
        }

    </script>
    
    <!-- Line chart code -->
    <script type="text/javascript">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        function getHoursPerMonth() {
            PageMethods.GetHoursPerMonth(document.getElementById("yearLineChartDl").value, createLineChart);
        }
        function createLineChart(response, userContext, methodName) {
            if (response != "error") {
                var chart = AmCharts.makeChart("linediv", {
                    "language": "es",
                    "type": "serial",
                    "theme": "none",
                    "marginRight": 40,
                    "marginLeft": 40,
                    "autoMarginOffset": 20,
                    "mouseWheelZoomEnabled": true,
                    "dataDateFormat": "YYYY-MM",
                    "valueAxes": [{
                        "id": "v1",
                        "axisAlpha": 0,
                        "position": "left",
                        "ignoreAxisWidth": true
                    }],
                    "balloon": {
                        "borderThickness": 1,
                        "shadowAlpha": 0
                    },
                    "graphs": [{
                        "id": "g1",
                        "balloon": {
                            "drop": true,
                            "adjustBorderColor": false,
                            "color": "#ffffff"
                        },
                        "bullet": "round",
                        "bulletBorderAlpha": 1,
                        "bulletColor": "#FFFFFF",
                        "bulletSize": 5,
                        "hideBulletsCount": 50,
                        "lineThickness": 2,
                        "title": "red line",
                        "useLineColorForBulletBorder": true,
                        "valueField": "value",
                        "balloonText": "<span style='font-size:18px;'>[[value]]</span>"
                    }],
                    "chartScrollbar": {
                        "graph": "g1",
                        "oppositeAxis": false,
                        "offset": 30,
                        "scrollbarHeight": 80,
                        "backgroundAlpha": 0,
                        "selectedBackgroundAlpha": 0.1,
                        "selectedBackgroundColor": "#888888",
                        "graphFillAlpha": 0,
                        "graphLineAlpha": 0.5,
                        "selectedGraphFillAlpha": 0,
                        "selectedGraphLineAlpha": 1,
                        "autoGridCount": true,
                        "color": "#AAAAAA"
                    },
                    "chartCursor": {
                        "pan": true,
                        "valueLineEnabled": true,
                        "valueLineBalloonEnabled": true,
                        "cursorAlpha": 1,
                        "cursorColor": "#258cbb",
                        "limitToGraph": "g1",
                        "valueLineAlpha": 0.2,
                        "valueZoomable": true
                    },
                    "valueScrollbar": {
                        "oppositeAxis": false,
                        "offset": 50,
                        "scrollbarHeight": 10
                    },
                    "categoryField": "date",
                    "categoryAxis": {
                        "parseDates": true,
                        "dashLength": 1,
                        "minorGridEnabled": true
                    },
                    "export": {
                        "enabled": true
                    },
                    "dataProvider": getDataLine(response)
                });

                chart.addListener("rendered", zoomChart);

                zoomChart();

                function zoomChart() {
                    chart.zoomToIndexes(chart.dataProvider.length - 40, chart.dataProvider.length - 1);
                }
            }
            else {
                console.log("error");
            }
        }

        function getDataLine(data) {
            var chartData = [];
            var dataSplitted = data.split(";");
            for (var i = 0; i < dataSplitted.length; i++) {
                var statistic = dataSplitted[i].split(",");
                chartData.push({
                    date: statistic[0],
                    value: statistic[1]
                });
            }
            return chartData;
        }

    </script>
    
    <!-- Bar chart code -->
    <script type="text/javascript">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        function getTotalHoursPerPosition() {
            PageMethods.GetTotalHoursPerPosition(createBarChart);
        }
        function createBarChart(response, userContext, methodName) {
            var chart = AmCharts.makeChart("bardiv", {
              "type": "serial",
              "theme": "none",
              "dataProvider": getDataBar(response),
              "valueAxes": [ {
                "gridColor": "#FFFFFF",
                "gridAlpha": 0.2,
                "dashLength": 0
              } ],
              "gridAboveGraphs": true,
              "startDuration": 1,
              "graphs": [ {
                "balloonText": "[[category]]: <b>[[value]]</b>",
                "fillAlphas": 0.8,
                "lineAlpha": 0.2,
                "type": "column",
                "valueField": "visits"
              } ],
              "chartCursor": {
                "categoryBalloonEnabled": false,
                "cursorAlpha": 0,
                "zoomable": false
              },
              "categoryField": "country",
              "categoryAxis": {
                "gridPosition": "start",
                "gridAlpha": 0,
                "tickPosition": "start",
                "tickLength": 20
              },
              "export": {
                "enabled": true
              }

            } );
        }
        function getDataBar(data) {
            var chartData = [];
            var dataSplitted = data.split(";");
            for (var i = 0; i < dataSplitted.length; i++) {
                var statistic = dataSplitted[i].split(",");
                chartData.push({
                    country: statistic[0],
                    visits: statistic[1]
                });
            }
            return chartData;
        }

    </script>

</asp:Content>