﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="timesheetlist.aspx.cs" Inherits="adminsite.site.employees.timesheet.timesheetlist" %>

<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/plugins/datatables/dataTables.bootstrap.css">

    <title>Hojas de tiempo</title>

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
                Lista de hojas de tiempo
            </h1>
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
                                    <th></th>
                                    <th>Identificador</th>
                                    <th>Fecha de inicio</th>
                                    <th>Fecha de cierre</th>
                                    <th>Estatus</th>
                                    <th>Opciones</th>
                                </tr>
                            </thead>

                            <tbody id="tableRows">
                                <asp:Repeater ID="repTimesheet" runat="server"  OnItemCommand="repTimesheet_ItemCommand">
                                    <ItemTemplate>
                                            <tr id="<%# Eval("id") %>">
                                                <td style="text-align:center">
                                                    <asp:Image ID="statusIcon" runat="server" Text="En espera" ImageUrl="~/site/employees/img/icons/history.svg" Height="26px" Width="26px" ToolTip="En espera"/>
                                                </td>
                                                <td><asp:Label ID="timesheetId" runat="server" Text='<%# Eval("id") %>' ReadOnly="True" BorderStyle="None" /></td>
                                                <td><%# string.Format("{0:dd/MM/yyyy}", Eval("initDate")) %></td>
                                                <td><%# string.Format("{0:dd/MM/yyyy}", Eval("endDate")) %></td>
                                                <td><asp:Label ID="status" runat="server" Text='<%# Eval("status") %>' ReadOnly="True" BorderStyle="None" /></td>
                                                <td style="text-align:center">
                                                    <asp:ImageButton ID="viewEdit" runat="server" Text="Visualizar/Modificar" ImageUrl="~/site/employees/img/icons/list.svg" Height="26px" Width="26px" ToolTip="Visualizar/Modificar" />
                                                </td>
                                            </tr>              
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th></th>
                                    <th>Identificador</th>
                                    <th>Fecha de inicio</th>
                                    <th>Fecha de cierre</th>
                                    <th>Estatus</th>
                                    <th>Opciones</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
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
