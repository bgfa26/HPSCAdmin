<%@ Page Language="C#" MasterPageFile="~/site/usermanagement/usermanagement.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="adminsite.site.usermanagement.login" %>

<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
	<title>Inicio de sesión</title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.all.min.js"></script>
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.min.css'/>
    <script>
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
    <span class="login100-form-logo">
        <i class="fas fa-user"></i>
    </span>

    <span class="login100-form-title p-b-34 p-t-27">
        Inicio de sesión
    </span>

    <div class="wrap-input100 validate-input" data-validate="Ingrese su correo">
        <input class="input100" id="email" type="text" name="email" placeholder="Correo electrónico"  maxlength="50">
        <span class="focus-input100" data-placeholder="&#xf207;"></span>
    </div>

    <div class="wrap-input100 validate-input" data-validate="Ingrese su contraseña">
        <input class="input100" id="password" type="password" name="password" placeholder="Contraseña"  maxlength="15">
        <span class="focus-input100" data-placeholder="&#xf191;"></span>
    </div>
    
    <div class="row">
        <div class="col-lg-12">
            <asp:ScriptManager runat="server" ID="sm">
            </asp:ScriptManager>
            <asp:updatepanel runat="server">
                <ContentTemplate>
                    <asp:Button ID="acceptBtn" runat="server" class="accept-form-btn" Text="Iniciar sesión" style="width:100%" OnClick="acceptBtn_Click" />
                </ContentTemplate>
            </asp:updatepanel>
        </div>
    </div>

    <div class="text-center p-t-90">
        <a class="txt1" href="/site/usermanagement/register.aspx">
            Pulse aquí para registrarse
        </a>
        <br />
        <br />
        <a class="txt1" href="/site/usermanagement/recoverpassword.aspx">
            ¿Olvidó su contraseña?
        </a>
    </div>
</asp:Content>
