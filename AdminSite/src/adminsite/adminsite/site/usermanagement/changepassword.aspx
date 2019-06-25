<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/usermanagement/usermanagement.Master" CodeBehind="changepassword.aspx.cs" Inherits="adminsite.site.usermanagement.changepassword" %>

<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
	<title>Actualización de contraseña</title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.all.min.js"></script>
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.min.css'/>
    <script>
        function sweetAlert(msg, type) {
            swal({
                title: msg,
                timer: 2000,
                showConfirmButton: false,
                type: type
            })
            .then(() => {
                
                window.location.href = '/site/usermanagement/login.aspx';
            });
        }
        function errorSweetAlert(msg, type) {
            swal({
                title: msg,
                timer: 2000,
                showConfirmButton: false,
                type: type
            });
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <span class="login100-form-title p-b-34 p-t-27">
        Actualización de contraseña
    </span>


    <div class="wrap-input100 validate-input" data-validate="Ingrese su contraseña">
        <input class="input100" id="pwd" type="password" name="password" placeholder="Contraseña" runat="server" maxlength="15">
        <span class="focus-input100" data-placeholder="&#xf191;"></span>
    </div>
    <div class="wrap-input100 validate-input" data-validate="Ingrese la verificación de su contraseña">
        <input class="input100" id="pwdverification" type="password" name="passwordverification" placeholder="Verificación de contraseña" runat="server" maxlength="15">
        <span class="focus-input100" data-placeholder="&#xf191;"></span>
    </div>
    
    <div class="row">
        <div class="col-lg-6">
            <asp:ScriptManager runat="server" ID="sm">
            </asp:ScriptManager>
            <asp:updatepanel runat="server">
                <ContentTemplate>
                    <asp:Button ID="acceptBtn" runat="server" class="accept-form-btn" Text="Aceptar" style="width:100%" OnClick="acceptBtn_Click" />
                </ContentTemplate>
            </asp:updatepanel>
        </div>
        <div class="col-lg-6">
            <input type="button" class="cancel-form-btn" style="width:100%" value="Cancelar" onclick="window.location='/site/usermanagement/login.aspx';"/>
        </div>
    </div>
</asp:Content>