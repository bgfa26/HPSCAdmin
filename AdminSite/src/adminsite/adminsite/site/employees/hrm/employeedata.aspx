<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="employeedata.aspx.cs" Inherits="adminsite.site.employees.hrm.employeedata" %>

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
                Información del empleado
            </h1>
        </div>
    </div>
    
    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-12" style="margin-top:10px">
                            <div class="col-md-6">
                                <label style="text-align:right">Cédula de identidad: </label>
				                <input type="text" class="form-control textinput" id="id" runat="server" maxlength="50" readonly="readonly">
                            </div>
                            <div class="col-md-6">
                                <label style="text-align:right">Identificador del trabajador: </label>
				                <input type="text" class="form-control textinput" id="workerid" runat="server" maxlength="50" readonly="readonly">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin-top:10px">
                            <div class="col-md-6">
                                <label style="text-align:right">Nombre del empleado: </label>
				                <input type="text" class="form-control textinput" id="name" runat="server" maxlength="50" readonly="readonly">
                            </div>
                            <div class="col-md-6">
                                <label style="text-align:right">Correo electrónico: </label>
				                <input type="text" class="form-control textinput" id="email" runat="server" maxlength="50" readonly="readonly">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin-top:10px">
                            <div class="col-md-6">
                                <label style="text-align:right">Cargo: </label>
                                <asp:DropDownList ID="positionDropList" runat="server" CssClass="form-control textinput"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label style="text-align:right">Unidad organizacional: </label>
                                <asp:DropDownList ID="ouDropList" runat="server" CssClass="form-control textinput"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin-top:10px">
                            <div class="col-md-6">
                                <label style="text-align:right">Supervisa: </label>
                                <asp:DropDownList ID="superviseDropList" runat="server" CssClass="form-control textinput"></asp:DropDownList>
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

