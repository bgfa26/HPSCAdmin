<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="newacp.aspx.cs" Inherits="adminsite.site.employees.acp.newacp" %>


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
            <h1 class="page-header" id="titleHeader">
                Registro de cuentas, cursos y permisos
            </h1>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6" style="margin-top:10px">
                                <label style="text-align:right">Identificador: </label>
				                <input type="text" class="form-control textinput" id="id" runat="server" maxlength="50">

                                <label style="text-align:right;margin-top:10px">Nombre: </label>
				                <input type="text" class="form-control textinput" id="name" runat="server" maxlength="50">
                                                                
                                <label style="text-align:right;margin-top:10px">Tipo: </label>
                                <asp:DropDownList ID="type" runat="server" CssClass="form-control textinput">
                                    <asp:ListItem Text="Facturable" Value="1" />
                                    <asp:ListItem Text="No facturable" Value="2" />
                                </asp:DropDownList>
                                
                                <label style="text-align:right;margin-top:10px">Desde: </label>
                                <asp:TextBox ID="dateinit" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
                                                                
                                <label style="text-align:right;margin-top:10px">Hasta: </label>
                                <asp:TextBox ID="dateend" runat="server" class="form-control textinput" TextMode="Date"></asp:TextBox>
                                                                
                                <label style="text-align:right;margin-top:10px">Administrador: </label>
                                <input list="content_employeeList" name="employees" class="form-control" id="admin" autocomplete="off" runat="server">
                                <datalist id="employeeList" runat="server">

                                </datalist>
                            </div>
                            
                            <div class="col-md-6" style="margin-top:10px;height:inherit">
                                <label style="text-align:right">Disponible para: </label>
                                
                                <div id="divscroll" class="block">
                                    <asp:CheckBoxList ID="organizationalUnitsCkl" CssClass="form-control textinput" runat="server" Height="379px" Width="100%">

                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4" style="margin-top:20px">
                            </div>
                            <div class="col-md-4" style="margin-top:20px">
                                <asp:Button ID="acceptBtn" runat="server" Text="Aceptar" CssClass="btn btn-lg btn-success" Width="100%" OnClick="acceptBtn_Click"/>
                            </div>
                            <div class="col-md-4" style="margin-top:20px">
                            </div>
                        </div>
                    </div>
                    <br />
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
</asp:Content>
