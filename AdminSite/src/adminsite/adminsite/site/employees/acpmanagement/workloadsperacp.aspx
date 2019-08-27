<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workloadsperacp.aspx.cs" MasterPageFile="~/site/employees/employees.Master"Inherits="adminsite.site.employees.acpmanagement.workloadsperacp" %>

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
                                    <th>Cédula de identidad</th>
                                    <th>Nombre y apelido</th>
                                    <th>Estatus</th>
                                    <th>Día 1</th>
                                    <th>Día 2</th>
                                    <th>Día 3</th>
                                    <th>Día 4</th>
                                    <th>Día 5</th>
                                    <th>Día 6</th>
                                    <th>Día 7</th>
                                    <th>Día 8</th>
                                    <th>Día 9</th>
                                    <th>Día 10</th>
                                    <th>Día 11</th>
                                    <th>Día 12</th>
                                    <th>Día 13</th>
                                    <th>Día 14</th>
                                    <th>Día 15</th>
                                    <th>Día 16</th>
                                    <th>Opciones</th>
                                </tr>
                            </thead>

                            <tbody id="tableRows">
                                <asp:Repeater ID="repCostCenter" runat="server">
                                    <ItemTemplate>
                                            <tr id="<%# Eval("id") %>">
                                                <td><%# Eval("timesheet.employee.id") %></td>
                                                <td><%# Eval("timesheet.employee.firstName") %> <%# Eval("timesheet.employee.lastName") %></td>
                                                <td><%# Eval("status") %></td>
                                                <td><%# Eval("day1") %></td>
                                                <td><%# Eval("day2") %></td>
                                                <td><%# Eval("day3") %></td>
                                                <td><%# Eval("day4") %></td>
                                                <td><%# Eval("day5") %></td>
                                                <td><%# Eval("day6") %></td>
                                                <td><%# Eval("day7") %></td>
                                                <td><%# Eval("day8") %></td>
                                                <td><%# Eval("day9") %></td>
                                                <td><%# Eval("day10") %></td>
                                                <td><%# Eval("day11") %></td>
                                                <td><%# Eval("day12") %></td>
                                                <td><%# Eval("day13") %></td>
                                                <td><%# Eval("day14") %></td>
                                                <td><%# Eval("day15") %></td>
                                                <td><%# Eval("day16") %></td>
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
                                    <th>Cédula de identidad</th>
                                    <th>Nombre y apelido</th>
                                    <th>Estatus</th>
                                    <th>Día 1</th>
                                    <th>Día 2</th>
                                    <th>Día 3</th>
                                    <th>Día 4</th>
                                    <th>Día 5</th>
                                    <th>Día 6</th>
                                    <th>Día 7</th>
                                    <th>Día 8</th>
                                    <th>Día 9</th>
                                    <th>Día 10</th>
                                    <th>Día 11</th>
                                    <th>Día 12</th>
                                    <th>Día 13</th>
                                    <th>Día 14</th>
                                    <th>Día 15</th>
                                    <th>Día 16</th>
                                    <th>Opciones</th>
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
                <asp:Button ID="cancelBtn" runat="server" Text="Regresar" CssClass="btn btn-lg btn-danger" Width="100%" OnClick="cancelBtn_Click"/>
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

