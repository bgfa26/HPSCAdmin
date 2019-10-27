<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workloadsperacp.aspx.cs" MasterPageFile="~/site/employees/employees.Master"Inherits="adminsite.site.employees.acpmanagement.workloadsperacp" %>

<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/plugins/datatables/dataTables.bootstrap.css">

    <title>Centros de costo</title>

    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="../css/sb-admin.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.css'/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server"> 
    <!-- Page Heading -->
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                Horas de trabajo en la cuenta <asp:Label ID="lblTitle" runat="server" Text='' ReadOnly="True" BorderStyle="None" />
            </h1>
        </div>
    </div>

    <div class="row" style="margin-bottom:25px">
        <div class="col-lg-4">
            <label style="text-align:right;margin-top:10px">Desde: </label>
            <asp:TextBox ID="dateinit" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-lg-4">
            <label style="text-align:right;margin-top:10px">Hasta: </label>
            <asp:TextBox ID="dateend" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-sm-3">
            <asp:Button ID="acceptBtn" runat="server" Text="Aceptar" CssClass="btn btn-md btn-success" Width="100%" style="margin-top:34px" OnClick="acceptBtn_Click"/>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-body">
                    <div class="table-responsive"> 
                        <table id="table" class="table table-bordered table-striped table-hover dt-responsive">
                            <thead>
                                <tr>
                                    <th>CI</th>
                                    <th>Empleado</th>
                                    <th>Estatus</th>
                                    <th id="header1" runat="server">Día 1</th>
                                    <th id="header2" runat="server">Día 2</th>
                                    <th id="header3" runat="server">Día 3</th>
                                    <th id="header4" runat="server">Día 4</th>
                                    <th id="header5" runat="server">Día 5</th>
                                    <th id="header6" runat="server">Día 6</th>
                                    <th id="header7" runat="server">Día 7</th>
                                    <th id="header8" runat="server">Día 8</th>
                                    <th id="header9" runat="server">Día 9</th>
                                    <th id="header10" runat="server">Día 10</th>
                                    <th id="header11" runat="server">Día 11</th>
                                    <th id="header12" runat="server">Día 12</th>
                                    <th id="header13" runat="server">Día 13</th>
                                    <th id="header14" runat="server">Día 14</th>
                                    <th id="header15" runat="server">Día 15</th>
                                    <th id="header16" runat="server">Día 16</th>
                                    <th id="headerTotal" runat="server">Total</th>
                                    <th>Opciones</th>
                                </tr>
                            </thead>

                            <tbody id="tableRows">
                                <asp:Repeater ID="repCostCenter" runat="server" OnItemCommand="repCostCenter_ItemCommand" >
                                    <ItemTemplate>
                                            <tr id="<%# Eval("id") %>">
                                                <td><%# Eval("timesheet.employee.id") %> <asp:Label ID="idWorkload" runat="server" Text='<%# Eval("id") %>' ReadOnly="True" BorderStyle="None" Visible="false"/></td>
                                                <td><%# Eval("timesheet.employee.firstName") %> <%# Eval("timesheet.employee.lastName") %></td>
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
                                                <td id="total" runat="server"><%# TotalHoursPerEmployee(Eval("day1"), Eval("day2"), Eval("day3"), Eval("day4"), Eval("day5"), Eval("day6"), 
                                                             Eval("day7"), Eval("day8"), Eval("day9"), Eval("day10"), Eval("day11"), Eval("day12"), 
                                                             Eval("day13"), Eval("day14"), Eval("day15"), Eval("day16")) %></td>
                                                <td style="text-align:center">
                                                    <asp:ImageButton ID="update" runat="server" Text="Aceptar" ImageUrl="~/site/employees/img/icons/check.svg" Height="26px" Width="26px" ToolTip="Aceptar" Style="margin-right:2px"/>
                                                    <asp:ImageButton ID="cancel" runat="server" Text="Cancelar" ImageUrl="~/site/employees/img/icons/close.svg" Height="25px" Width="25px" ToolTip="Cancelar"  Style="margin-left:2px"/>
                                                </td>
                                            </tr>              
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th colspan="3">Total</th>
                                    <th id="footer1" runat="server">Día 1</th>
                                    <th id="footer2" runat="server">Día 2</th>
                                    <th id="footer3" runat="server">Día 3</th>
                                    <th id="footer4" runat="server">Día 4</th>
                                    <th id="footer5" runat="server">Día 5</th>
                                    <th id="footer6" runat="server">Día 6</th>
                                    <th id="footer7" runat="server">Día 7</th>
                                    <th id="footer8" runat="server">Día 8</th>
                                    <th id="footer9" runat="server">Día 9</th>
                                    <th id="footer10" runat="server">Día 10</th>
                                    <th id="footer11" runat="server">Día 11</th>
                                    <th id="footer12" runat="server">Día 12</th>
                                    <th id="footer13" runat="server">Día 13</th>
                                    <th id="footer14" runat="server">Día 14</th>
                                    <th id="footer15" runat="server">Día 15</th>
                                    <th id="footer16" runat="server">Día 16</th>
                                    <th id="footerTotal" runat="server">Total</th>
                                    <th id="footerOpciones" runat="server">Opciones</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-3" style="margin-top:20px">
            </div>
            <div class="col-md-6" style="margin-top:20px">
                <asp:Button ID="cancelBtn" runat="server" Text="Regresar" CssClass="btn btn-lg btn-info" Width="100%" OnClick="cancelBtn_Click"/>
            </div>
            <div class="col-md-3" style="margin-top:20px">
            </div>
        </div>
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
    <script>table = $('#table').DataTable();</script>
</asp:Content>

