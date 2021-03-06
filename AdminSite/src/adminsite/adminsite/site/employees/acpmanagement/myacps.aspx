﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="myacps.aspx.cs" Inherits="adminsite.site.employees.acpmanagement.myacps" %>


<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/plugins/datatables/dataTables.bootstrap.css">

    <title>Mis centros de costo</title>

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
                Mis cuentas, cursos y permisos
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
                                    <th>Identificador</th>
                                    <th>Nombre</th>
                                    <th>Tipo</th>
                                    <th>Fecha de inicio</th>
                                    <th>Fecha de fin</th>
                                    <th>Opciones</th>
                                </tr>
                            </thead>

                            <tbody id="tableRows">
                                <asp:Repeater ID="repCostCenter" runat="server" OnItemCommand="repCostCenter_ItemCommand">
                                    <ItemTemplate>
                                        <tr id="<%# Eval("id") %>">
                                            <td><asp:Label ID="id" runat="server" Text='<%# Eval("id") %>' ReadOnly="True" BorderStyle="None" /></td>
                                            <td><%# Eval("name") %></td>
                                            <td><%# Eval("typeStringFormat") %></td>
                                            <td><%# string.Format("{0:dd/MM/yyyy}", Eval("initDate")) %></td>
                                            <td><%# GetEndDate(Eval("endDate")) %></td>
                                            <td style="text-align:center">
                                                <asp:ImageButton ID="viewWorkloads" runat="server" Text="Visualizar" ImageUrl="~/site/employees/img/icons/assign.svg" Height="25px" Width="25px" ToolTip="Visualizar" />
                                            </td>
                                        </tr>              
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Identificador</th>
                                    <th>Nombre</th>
                                    <th>Tipo</th>
                                    <th>Fecha de inicio</th>
                                    <th>Fecha de fin</th>
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