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
                    <div class="row">
                        <div class="col-lg-6" style="text-align: left;">
                            <label style="text-align:left;margin-top:10px">Desde: </label>
                            <asp:TextBox ID="TextBox3" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-lg-6" style="text-align: left;">
                            <label style="text-align:left;margin-top:10px">Hasta: </label>
                            <asp:TextBox ID="TextBox4" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
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
                            <div class="col-lg-6">
                                <label style="text-align:right;margin-top:10px">Desde: </label>
                                <asp:TextBox ID="initPie" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label style="text-align:right;margin-top:10px">Hasta: </label>
                                <asp:TextBox ID="endPie" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-lg-12" style="margin-top:15px">
                                <input type="button" onclick="getACPByMonth()" value="Buscar" class="btn btn-lg" style="width:100%"/>
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
                        <div class="col-lg-6">
                            <label style="text-align:right;margin-top:10px">Desde: </label>
                            <asp:TextBox ID="initLine" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <label style="text-align:right;margin-top:10px">Hasta: </label>
                            <asp:TextBox ID="EndLine" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-lg-12" style="margin-top:15px">
                            <input type="button" onclick="getACPByMonth()" value="Buscar" class="btn btn-lg" style="width:100%"/>
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
                                <label style="text-align:left;margin-top:10px">Desde: </label>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-lg-6" style="text-align: left;">
                                <label style="text-align:left;margin-top:10px">Hasta: </label>
                                <asp:TextBox ID="TextBox2" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-lg-12" style="margin-top:15px">
                                <input type="button" onclick="getACPByMonth()" value="Buscar" class="btn btn-lg" style="width:100%"/>
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


    <!-- Chart code -->
    <script>
        var chart = AmCharts.makeChart("bardiv", {
          "type": "serial",
          "theme": "none",
          "dataProvider": [ {
            "country": "USA",
            "visits": 2025
          }, {
            "country": "China",
            "visits": 1882
          }, {
            "country": "Japan",
            "visits": 1809
          }, {
            "country": "Germany",
            "visits": 1322
          }, {
            "country": "UK",
            "visits": 1122
          }, {
            "country": "France",
            "visits": 1114
          }, {
            "country": "India",
            "visits": 984
          }, {
            "country": "Spain",
            "visits": 711
          }, {
            "country": "Netherlands",
            "visits": 665
          }, {
            "country": "Russia",
            "visits": 580
          }, {
            "country": "South Korea",
            "visits": 443
          }, {
            "country": "Canada",
            "visits": 441
          }, {
            "country": "Brazil",
            "visits": 395
          } ],
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
    </script>

    <script>
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
          "dataProvider": [
            {
              "year": 2005,
              "income": 23.5
            },
            {
              "year": 2006,
              "income": 26.2
            },
            {
              "year": 2007,
              "income": 30.1
            },
            {
              "year": 2008,
              "income": 29.5
            },
            {
              "year": 2009,
              "income": 24.6
            }
          ],
            "export": {
              "enabled": true
             }

        });
    </script>

    <script>
        var chart = AmCharts.makeChart("linediv", {
            "language": "es",
            "type": "serial",
            "theme": "none",
            "marginRight": 40,
            "marginLeft": 40,
            "autoMarginOffset": 20,
            "mouseWheelZoomEnabled":true,
            "dataDateFormat": "YYYY-MM-DD",
            "valueAxes": [{
                "id": "v1",
                "axisAlpha": 0,
                "position": "left",
                "ignoreAxisWidth":true
            }],
            "balloon": {
                "borderThickness": 1,
                "shadowAlpha": 0
            },
            "graphs": [{
                "id": "g1",
                "balloon":{
                    "drop":true,
                    "adjustBorderColor":false,
                    "color":"#ffffff"
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
                "oppositeAxis":false,
                "offset":30,
                "scrollbarHeight": 80,
                "backgroundAlpha": 0,
                "selectedBackgroundAlpha": 0.1,
                "selectedBackgroundColor": "#888888",
                "graphFillAlpha": 0,
                "graphLineAlpha": 0.5,
                "selectedGraphFillAlpha": 0,
                "selectedGraphLineAlpha": 1,
                "autoGridCount":true,
                "color":"#AAAAAA"
            },
            "chartCursor": {
                "pan": true,
                "valueLineEnabled": true,
                "valueLineBalloonEnabled": true,
                "cursorAlpha":1,
                "cursorColor":"#258cbb",
                "limitToGraph":"g1",
                "valueLineAlpha":0.2,
                "valueZoomable":true
            },
            "valueScrollbar":{
                "oppositeAxis":false,
                "offset":50,
                "scrollbarHeight":10
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
            "dataProvider": [{
                "date": "2019-01-01",
                "value": 13
            }, {
                "date": "2019-02-01",
                "value": 11
            }, {
                "date": "2019-03-01",
                "value": 15
            }, {
                "date": "2019-04-01",
                "value": 16
            }, {
                "date": "2019-05-01",
                "value": 18
            }, {
                "date": "2019-06-01",
                "value": 13
            }, {
                "date": "2019-07-01",
                "value": 22
            }, {
                "date": "2019-08-01",
                "value": 23
            }, {
                "date": "2019-09-01",
                "value": 20
            }, {
                "date": "2019-10-01",
                "value": 17
            }, {
                "date": "2019-11-01",
                "value": 16
            }, {
                "date": "2019-12-01",
                "value": 18
            }]
        });

        chart.addListener("rendered", zoomChart);

        zoomChart();

        function zoomChart() {
            chart.zoomToIndexes(chart.dataProvider.length - 40, chart.dataProvider.length - 1);
        }
    </script>
        
    <!-- Pie chart code -->
    <script type="text/javascript">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
        function getACPByMonth() {
            PageMethods.GetACPByMonth(createPieChart);
        }
        function createPieChart(response, userContext, methodName) {
            console.log(response);
            var chart = AmCharts.makeChart( "piediv", {
              "type": "pie",
              "radius": 140,
                "theme": "none",
                "dataProvider": getData(response),
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

        function getData(data) {
            var chartData = [];
            var dataSplitted = data.split(";");
            console.log(dataSplitted.length);
            for (var i = 0; i < dataSplitted.length; i++) {
                var statistic = dataSplitted[i].split(",");
                chartData.push({
                    country: statistic[0],
                    litres: statistic[1]
                });
            }
            return chartData;
        }
    </script>
</asp:Content>