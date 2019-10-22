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

    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/1.6.0/css/buttons.dataTables.min.css" rel="stylesheet" />
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
    
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.0/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.0/js/buttons.html5.min.js"></script>
    <script>
        table = $('#table').DataTable({
            language: {
                "sProcessing":     "Procesando...",
                "sLengthMenu":     "Mostrar _MENU_ entradas",
                "sZeroRecords":    "No se encontraron coincidencias",
                "sEmptyTable":     "No se encontraron datos en la tabla",
                "sInfo":           "Mostrando desde _START_ hasta _END_ de _TOTAL_ entradas",
                "sInfoEmpty":      "Mostrando desde 0 hasta 0 de 0 entradas",
                "sInfoFiltered":   "(Filtrado de un total de _MAX_ entradas)",
                "sInfoPostFix":    "",
                "sSearch":         "Buscar:",
                "sUrl":            "",
                "sInfoThousands":  ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst":    "Primero",
                    "sLast":     "Último",
                    "sNext":     "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending":  ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                },
                "buttons": {
                    "copy": "Copiar data",
                    "excel": "Guardar excel",
                    "csv": "Guardar CSV",
                    "pdf": "Guardar PDF",
                    "pageLength": "Mostrar %d filas",
                    "colvis": "Visibilidad"
                }
            },
            dom: 'Bfrtip',
            buttons: [
                'pageLength',
                'copyHtml5',
                {
                    extend: 'excelHtml5',
                    messageTop: function () { return 'Reporte: ' + $('#content_reportsDropList option:selected').text(); }
                },
                {
                    extend: 'pdfHtml5',
                    messageTop: function () { return 'Reporte: ' + $('#content_reportsDropList option:selected').text(); }
                },
                'csvHtml5'
            ]
        } );

    </script>
</asp:Content>