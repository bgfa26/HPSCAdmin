﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="timesheetemployee.aspx.cs" Inherits="adminsite.site.employees.hrm.timesheetemployee" %>


<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/plugins/datatables/dataTables.bootstrap.css">

    <title>Talento humano</title>

    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="../css/sb-admin.css" rel="stylesheet">
    <link href="../css/timesheet-table.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server"> 
    
    <asp:ScriptManager ID="smMain" runat="server" EnablePageMethods="true" />
    <!-- Page Heading -->
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header" style="font-size:30px">
                Hoja de tiempo N°<asp:Label ID="timesheetLbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" />
            </h1>
        </div>
    </div>

    <div class="row" style="padding:12px">
        <div class="table-responsive">
            <table class="table table-bordered table-hover" id="job-table">
                <thead style="background: #eee;">
                    <tr>
                        <th scope="col" class="text-center">Cuenta/Curso/Permiso</th> 
                        <th scope="col" class="text-center" style="padding-left:25px;padding-right:25px">Estatus</th>                        
                        <th scope="col" class="text-center"><asp:Label ID="header1" runat="server" Text='Día 1' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header2" runat="server" Text='Día 2' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header3" runat="server" Text='Día 3' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header4" runat="server" Text='Día 4' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header5" runat="server" Text='Día 5' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header6" runat="server" Text='Día 6' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header7" runat="server" Text='Día 7' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header8" runat="server" Text='Día 8' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header9" runat="server" Text='Día 9' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header10" runat="server" Text='Día 10' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header11" runat="server" Text='Día 11' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header12" runat="server" Text='Día 12' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="header13" runat="server" Text='Día 13' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center" id="header14"><asp:Label ID="_header14" runat="server" Text='Día 14' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center" id="header15"><asp:Label ID="_header15" runat="server" Text='Día 15' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center" id="header16"><asp:Label ID="_header16" runat="server" Text='Día 16' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center">Total</th>
                    </tr>
                </thead>
                <tbody class="text-center tableBody">
                    <asp:Repeater ID="repWorkloads" runat="server">
                        <ItemTemplate>
                                <tr id="<%# Eval("id") %>">
                                    <td><%# Eval("accountCoursePermit.name") %></td>
                                    <td><%# Eval("status") %></td>
                                    <td id="day1" runat="server"><%# Eval("day1") %></td>
                                    <td id="day2" runat="server"><%# Eval("day2") %></td>
                                    <td id="day3" runat="server"><%# Eval("day3") %></td>
                                    <td id="day4" runat="server"><%# Eval("day4") %></td>
                                    <td id="day5" runat="server"><%# Eval("day5") %></td>
                                    <td id="day6" runat="server"><%# Eval("day6") %></td>
                                    <td id="day7" runat="server"><%# Eval("day7") %></td>
                                    <td id="day8" runat="server"><%# Eval("day8") %></td>
                                    <td id="day9" runat="server"><%# Eval("day9") %></td>
                                    <td id="day10" runat="server"><%# Eval("day10") %></td>
                                    <td id="day11" runat="server"><%# Eval("day11") %></td>
                                    <td id="day12" runat="server"><%# Eval("day12") %></td>
                                    <td id="day13" runat="server"><%# Eval("day13") %></td>
                                    <td id="day14" runat="server"><%# Eval("day14") %></td>
                                    <td id="day15" runat="server"><%# Eval("day15") %></td>
                                    <td id="day16" runat="server"><%# Eval("day16") %></td>
                                    <td><%# TotalHoursPerACP(Eval("day1"), Eval("day2"), Eval("day3"), Eval("day4"), Eval("day5"), Eval("day6"), 
                                                             Eval("day7"), Eval("day8"), Eval("day9"), Eval("day10"), Eval("day11"), Eval("day12"), 
                                                             Eval("day13"), Eval("day14"), Eval("day15"), Eval("day16")) %></td>
                                </tr>              
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
                <tfoot>
                    <tr>
                        <th scope="col" class="text-center" colspan="2">Total</th>
                        <th scope="col" class="text-center"><asp:Label ID="day1Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day2Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day3Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day4Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day5Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day6Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day7Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day8Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day9Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day10Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day11Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day12Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="day13Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center" id="footer14"><asp:Label ID="day14Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center" id="footer15"><asp:Label ID="day15Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center" id="footer16"><asp:Label ID="day16Lbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                        <th scope="col" class="text-center"><asp:Label ID="totalLbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" /></th>
                    </tr>
                </tfoot>
            </table>
        </div>
        <br />
        <asp:Label ID="commentLbl" runat="server" Font-Size="Medium"></asp:Label>
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3" style="margin-top:20px">
                    <asp:Button ID="approveBtn" runat="server" Text="Aprobar" CssClass="btn btn-lg btn-success" Width="100%" OnClick="approveBtn_Click"/>
                </div>
                <div class="col-md-3" style="margin-top:20px">
                    <input type="button" value="Denegar" id="denyBtn" onclick="rejectTimesheet()" class="btn btn-lg btn-danger" style="width:100%;">
                </div>
                <div class="col-md-3" style="margin-top:20px">
                    <asp:Button ID="waitBtn" runat="server" Text="En espera" CssClass="btn btn-lg btn-warning" Width="100%" OnClick="waitBtn_Click"/>
                </div>
                <div class="col-md-3" style="margin-top:20px">
                    <button runat="server" id="cancelBtn" class="btn btn-lg btn-info" title="Search" onserverclick="cancelBtn_Click" style="width:100%">
                        <i class="fa fa-reply"></i> Regresar
                    </button>
                </div>
            </div>
        </div>
        <br />
    </div>
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
    <script>
        table = $('#table').DataTable({
            "paging":   false
        });

    </script>

    <script>
        $(document).ready(function () {
            hideColumns();
        });

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        function hideColumns() {
            PageMethods.CheckEndDate(hideColumn);
        }
        function hideColumn(response, userContext, methodName) {
            if (response == "30") {
                document.getElementById("header16").style.display = "none";
                document.getElementById("footer16").style.display = "none";
                $('td:nth-child(18)').hide();
            }
            else if (response == "15") {
                document.getElementById("header16").style.display = "none";
                document.getElementById("footer16").style.display = "none";
                $('td:nth-child(18)').hide();
            }
            else if (response == "29") {
                document.getElementById("header16").style.display = "none";
                document.getElementById("footer16").style.display = "none";
                document.getElementById("header15").style.display = "none";
                document.getElementById("footer15").style.display = "none";
                $('td:nth-child(18)').hide();
                $('td:nth-child(17)').hide();
            }
            else if (response == "28") {
                document.getElementById("header16").style.display = "none";
                document.getElementById("footer16").style.display = "none";
                document.getElementById("header15").style.display = "none";
                document.getElementById("footer15").style.display = "none";
                document.getElementById("header14").style.display = "none";
                document.getElementById("footer14").style.display = "none";
                $('td:nth-child(18)').hide();
                $('td:nth-child(17)').hide();
                $('td:nth-child(16)').hide();
            }
        }
    </script>

    <script type="text/javascript">

        function errorSweetAlertPost(msg, type) {
            swal({
                title: msg,
                timer: 2000,
                buttons: false,
                className: 'heightswal',
                icon: type
            })
            .then(() => {
                rejectTimesheet();
            });
        }
        function rejectTimesheet() {
            swal({
              title: "Comentario sobre la hoja de tiempo",
              text: "Escriba el motivo para rechazar la hoja de tiempo",
              content: "input",
              buttons: {
                cancel: {
                    text: 'Cancelar',
                    visible: true
                },
                confirm: {
                    text: 'Aceptar',
                    closeModal: false
                }
              },
              closeOnConfirm: false,
              closeOnCancel: false,
              cancelButtonText: "Cancelar",
              confirmButtonText: "Aceptar"
            })
            .then((value) => {
                if ((value === false)) {
                    swal.close();
                }
                else {
                    if (value === false) return false;
                    else {
                        swal.close();
                        if ((value === "") && (value != "True")) {
                            errorSweetAlertPost("No se pueden dejar vacío el mensaje", "error");
                            console.log("no hay valor");
                            return false
                        }
                        else {
                            swal.close();
                            deniedAndComment(value);
                        }
                    }
                }
            });
        }

        function sleep(milliseconds) {
            var start = new Date().getTime();
            for (var i = 0; i < 1e7; i++) {
                if ((new Date().getTime() - start) > milliseconds) {
                    break;
                }
            }
        }

        function deniedAndComment(value) {
            PageMethods.DenyTimesheet(value, success);
        }
        
        function success(response, userContext, methodName) {
            if (response === "ok") {
                sweetAlertNoRedirect('Se ha actualizado la hoja de tiempo exitosamente', 'success');
            } else if (response === "reject") {
                errorSweetAlert('No se ha podido actualizar la hoja de trabajo', 'error');
            } else if (response === "error") {
                errorSweetAlert('Se ha generado un error procesando su solicitud', 'error');
            }
        }
    </script>
</asp:Content>
