<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="employeelist.aspx.cs" Inherits="adminsite.site.employees.hrm.employeelist" %>


<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/plugins/datatables/dataTables.bootstrap.css">

    <title>SB Admin - Bootstrap Admin Template</title>

    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="../css/sb-admin.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="../css/plugins/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server"> 
    <!-- Page Heading -->
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                Listado de empleados <small>Statistics Overview</small>
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
                                    <th>Cédula de identidad</th>
                                    <th>ID del trabajador</th>
                                    <th>Nombre y apelido</th>
                                    <th>Correo electrónico</th>
                                    <th>Cargo/Unidad organizacional</th>
                                    <th>Opciones</th>
                                </tr>
                            </thead>
                            
                            <tbody id="tableRows">
                                <asp:Repeater ID="repEmployees" runat="server">
                                    <ItemTemplate>
                                            <tr id="<%# Eval("correo") %>">
                                                <td><%# Eval("nombre") %> <%# Eval("apellido") %></td>
                                                <td><%# Eval("usuario") %></td>
                                                <td><asp:Label ID="correoemp" runat="server" Text='<%# Eval("correo") %>' ReadOnly="True" BorderStyle="None" /></td>
                                                <td><%# Eval("rol") %></td>
                                                <td style="text-align:center">
                                                    <asp:ImageButton ID="Eliminar" runat="server" Text="Eliminar" ImageUrl="~/Vista/Common/img/eliminar.ico" Height="25px" Width="25px" ToolTip="Eliminar empleado" />
                                                </td>
                                            </tr>              
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Cédula de identidad</th>
                                    <th>ID del trabajador</th>
                                    <th>Nombre y apelido</th>
                                    <th>Correo electrónico</th>
                                    <th>Cargo/Unidad organizacional</th>
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

    <!-- DataTables -->
    <script src="../css/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../css/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script>table = $('#table').DataTable();</script>
</asp:Content>
