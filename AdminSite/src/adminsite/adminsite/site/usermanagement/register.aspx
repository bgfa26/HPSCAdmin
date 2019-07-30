<%@ Page Language="C#" MasterPageFile="~/site/usermanagement/usermanagement.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="adminsite.site.register" %>

<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
    <title>Registro de usuarios</title>
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
    <style>
        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            /* display: none; <- Crashes Chrome on hover */
            -webkit-appearance: none;
            margin: 0; /* <-- Apparently some margin are still there even though it's hidden */
        }

        input[type=number] {
            -moz-appearance:textfield; /* Firefox */
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <span class="login100-form-title p-b-34 p-t-27">
        Registro de usuario
    </span>

    <asp:Panel id="employeeForm" runat="server">

        <div class="wrap-input100 validate-input" data-validate="Ingrese su correo">
            <input class="input100" id="email" type="text" name="email" placeholder="Correo electrónico" runat="server" maxlength="50">
            <span class="focus-input100" data-placeholder="&#xf15a;"></span>
        </div>
    
        <div class="wrap-input100 validate-input" data-validate="Ingrese su cédula de identidad">
            <input class="input100" id="idci" type="number" name="id" placeholder="Cédula de identidad" runat="server" maxlength="15">
            <span class="focus-input100" data-placeholder="&#xf207;"></span>
        </div>

        <div class="wrap-input100 validate-input" data-validate="Ingrese su identificador de trabajador">
            <input class="input100" id="idworker" type="text" name="workerid" placeholder="Identificador de trabajador" runat="server" maxlength="20">
            <span class="focus-input100" data-placeholder="&#xf207;"></span>
        </div>

        <div class="wrap-input100 validate-input" data-validate="Ingrese su primer nombre">
            <input class="input100" id="namefirst" type="text" name="name" placeholder="Primer nombre" runat="server" maxlength="50">
            <span class="focus-input100" data-placeholder="&#xf207;"></span>
        </div>
    

        <div class="wrap-input100 validate-input" data-validate="Ingrese su primer apellido">
            <input class="input100" id="namelast" type="text" name="lastname" placeholder="Primer apellido" runat="server" maxlength="50">
            <span class="focus-input100" data-placeholder="&#xf207;"></span>
        </div>
    

        <div class="wrap-input100 validate-input" data-validate="Ingrese su contraseña">
            <input class="input100" id="pwd" type="password" name="pwd" placeholder="Contraseña" runat="server" maxlength="15">
            <span class="focus-input100" data-placeholder="&#xf191;"></span>
        </div>
    

        <div class="wrap-input100 validate-input" data-validate="Ingrese la verificación de su contraseña">
            <input class="input100" id="pwdverification" type="password" name="pwdverification" placeholder="Verificación de contraseña" runat="server" maxlength="15">
            <span class="focus-input100" data-placeholder="&#xf191;"></span>
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

