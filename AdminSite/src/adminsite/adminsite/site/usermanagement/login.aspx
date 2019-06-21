<%@ Page Title="" Language="C#" MasterPageFile="~/site/usermanagement/usermanagement.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="adminsite.site.usermanagement.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <span class="login100-form-title p-b-34 p-t-27">
        Inicio de sesión
    </span>

    <div class="wrap-input100 validate-input" data-validate="Enter username">
        <input class="input100" type="text" name="username" placeholder="Correo electrónico">
        <span class="focus-input100" data-placeholder="&#xf207;"></span>
    </div>

    <div class="wrap-input100 validate-input" data-validate="Enter password">
        <input class="input100" type="password" name="pass" placeholder="Contraseña">
        <span class="focus-input100" data-placeholder="&#xf191;"></span>
    </div>
    
    <div class="row">
        <div class="col-lg-6">
            <button class="accept-form-btn">
                Iniciar sesión
            </button>
        </div>
        <div class="col-lg-6">
            <button class="cancel-form-btn">
                Cancelar
            </button>
        </div>
    </div>

    <div class="text-center p-t-90">
        <a class="txt1" href="#">
            Pulse aquí para registrarse
        </a>
        <br />
        <br />
        <a class="txt1" href="#">
            ¿Olvidó su contraseña?
        </a>
    </div>
</asp:Content>
