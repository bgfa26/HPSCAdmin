<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="employeelist.aspx.cs" Inherits="adminsite.site.employees.hrm.employeelist" %>


<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/plugins/datatables/dataTables.bootstrap.css">

    <title>Talento humano</title>

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
                Listado de empleados
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
                                <asp:Repeater ID="repEmployees" runat="server" OnItemCommand="repEmployees_ItemCommand">
                                    <ItemTemplate>
                                            <tr id="<%# Eval("id") %>">
                                                <td><asp:Label ID="employeeId" runat="server" Text='<%# Eval("id") %>' ReadOnly="True" BorderStyle="None" /></td>
                                                <td><%# Eval("workerid") %></td>
                                                <td><%# Eval("firstname") %> <%# Eval("lastname") %></td>
                                                <td><asp:Label ID="employeeEmail" runat="server" Text='<%# Eval("email") %>' ReadOnly="True" BorderStyle="None" /></td>
                                                <td><%# Eval("positionName") %> / <%# Eval("organizationalUnit") %></td>
                                                <td style="text-align:center">
                                                    <asp:ImageButton ID="modify" runat="server" Text="Modificar" ImageUrl="~/site/employees/img/icons/assign.svg" Height="25px" Width="25px" ToolTip="Modificar" />
                                                    <asp:ImageButton ID="delete" runat="server" Text="Eliminar" ImageUrl="~/site/employees/img/icons/trash.svg" Height="26px" Width="26px" ToolTip="Eliminar" />
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
    <script src="../js/sweet.js"></script>

    <!-- DataTables -->
    <script src="../css/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../css/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script>table = $('#table').DataTable();</script>
</asp:Content>
