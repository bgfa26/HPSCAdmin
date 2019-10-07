<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="hrmreports.aspx.cs" Inherits="adminsite.site.employees.hrm.hrmreports" %>

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
                Reportes de HRM
            </h1>
        </div>
    </div>

    <div class="row" style="margin-bottom:25px">
        <div class="col-lg-4">
            <label style="text-align:right;margin-top:10px">Reporte: </label>
            <asp:DropDownList ID="reportsDropList" runat="server" CssClass="form-control textinput">
                <asp:ListItem Text="Empleados que no han entregado hoja de tiempo" Value="0" />
                <asp:ListItem Text="Supervisores que no han aprobado hojas de tiempo" Value="1" />
                <asp:ListItem Text="Gerentes que no han aprobado todas las horas en una cuenta" Value="2" />
            </asp:DropDownList>
        </div>
        <div class="col-lg-2">
            <label style="text-align:right;margin-top:10px">Desde: </label>
            <asp:TextBox ID="dateinit" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-lg-2">
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
                                    <th>Nombre y apellido</th>
                                    <th><asp:Label ID="headerOUACP" runat="server" Text="Unidad organizacional / Cuentas" ReadOnly="True" BorderStyle="None" /></th>
                                </tr>
                            </thead>

                            <tbody id="tableRows">
                                <asp:Repeater ID="repReports" runat="server">
                                    <ItemTemplate>
                                            <tr id="<%# Eval("id") %>">
                                                <td><asp:Label ID="employeeId" runat="server" Text='<%# Eval("id") %>' ReadOnly="True" BorderStyle="None" /></td>
                                                <td><%# Eval("firstName") %> <%# Eval("lastName") %></td>
                                                <td><%# Eval("unitAccount") %></td>
                                            </tr>              
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>Cédula de identidad</th>
                                    <th>Nombre y apellido</th>
                                    <th><asp:Label ID="footerOUACP" runat="server" Text="Unidad organizacional / Cuentas" ReadOnly="True" BorderStyle="None" /></th>
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