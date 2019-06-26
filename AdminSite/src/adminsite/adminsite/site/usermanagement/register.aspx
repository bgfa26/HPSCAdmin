﻿<%@ Page Language="C#" MasterPageFile="~/site/usermanagement/usermanagement.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="adminsite.site.register" %>

<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
	<title>Recuperación de contraseña</title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.all.min.js"></script>
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.min.css'/>
    <script>
        function sweetAlert(msg) {
            swal({
                title: msg,
                timer: 2000,
                showConfirmButton: false,
                type: 'success'
            })
            .then(() => {
                window.location.href = '/site/usermanagement/login.aspx';
            });
        }
        function errorSweetAlert(msg) {
            swal({
                title: msg,
                timer: 2000,
                showConfirmButton: false,
                type: 'error'
            });
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <span class="login100-form-title p-b-34 p-t-27">
        Registro de usuario
    </span>

    <asp:Panel id="employeeForm" runat="server">

        <div class="wrap-input100 validate-input" data-validate="Ingrese su correo">
            <input class="input100" id="email" type="text" name="email" placeholder="Correo electrónico" runat="server" maxlength="50">
            <span class="focus-input100" data-placeholder="&#xf207;"></span>
        </div>
    
        <div class="row">
            <div class="col-lg-6">
                <asp:Button ID="acceptBtn" runat="server" class="accept-form-btn" Text="Aceptar" style="width:100%" OnClick="acceptBtn_Click"/>
            </div>
            <div class="col-lg-6">
                <input type="button" class="cancel-form-btn" style="width:100%" value="Cancelar" onclick="window.location='/site/usermanagement/login.aspx';"/>
            </div>
        </div>
    </asp:Panel>

    
    <asp:Panel id="verificationForm" runat="server" Visible="false">
        <div class="wrap-input100 validate-input">
            <input class="input100" id="codeHex" type="text" name="codeHex" placeholder="Código de verificación" runat="server"  maxlength="6">
            <span class="focus-input100" data-placeholder="&#xf191;"></span>
        </div>
    
        <div class="row">
            <div class="col-lg-6">
                <asp:Button ID="verificationBtn" runat="server" class="accept-form-btn" Text="Aceptar" style="width:100%" OnClick="verificationBtn_Click"/>
            </div>
            <div class="col-lg-6">
                <input type="button" class="cancel-form-btn" style="width:100%" value="Cancelar" onclick="window.location='/site/usermanagement/login.aspx';"/>
            </div>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="message" runat="server" Visible="false">
        <div style="text-align:center;margin-top:20px">
            <label class="txt1">El código de verificación puede demorar en ser enviado al correo</label>
        </div>            
    </asp:Panel>
</asp:Content>

