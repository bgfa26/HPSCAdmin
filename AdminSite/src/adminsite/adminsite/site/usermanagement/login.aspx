<%@ Page Language="C#" MasterPageFile="~/site/usermanagement/usermanagement.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="adminsite.site.usermanagement.login" %>

<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
	<title>Inicio de sesión</title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.all.min.js"></script>
	<link rel="stylesheet" type="text/css" href="css/fade.css">
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
        function infoSweetAlert(msg) {
            swal({
                title: msg,
                timer: 4000,
                showConfirmButton: false,
                type: 'info'
            });
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <span class="login100-form-logo">
	  <div id="logohpsc" hidden="hidden" style="text-align:center">
        <img src="../common/img/hpsc.png" class="img-responsive img-centered" width="70" alt="" id="hpsc">
	  </div>
	  <div id="logomt2005" hidden="hidden" style="text-align:center">
        <img src="../common/img/mt2005.png" class="img-responsive img-centered" width="70" alt="" id="mt2005">
	  </div>
	  <div id="logointeratec" hidden="hidden" style="text-align:center">
        <img src="../common/img/interatec.png" class="img-responsive img-centered" width="70" alt="" id="interatec">
	  </div>
	  <div id="logoguest" style="text-align:center">
        <i class="fas fa-user" id="guest"></i>
	  </div>
        
    </span>

    <span class="login100-form-title p-b-34 p-t-27">
        Inicio de sesión
    </span>

    <div class="wrap-input100 validate-input" data-validate="Ingrese su correo">
        <input class="input100" id="email" type="text" name="email" placeholder="Correo electrónico" onkeypress="funcion()" onblur="funcion()" maxlength="50">
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

    <script>
        function funcion() {
            var email = document.getElementById("email").value;
            var emailFilter = /^[a-zA-Z0-9\-_]+(\.[a-zA-Z0-9\-_]+)*@[a-z0-9]+(\-[a-z0-9]+)*(\.[a-z0-9]+(\-[a-z0-9]+)*)*\.[a-z]{1,4}$/;
            if (emailFilter.test(email)) {
                if (email.includes("hp-sc")) {
                    document.getElementById('logohpsc').removeAttribute("hidden");
                    document.getElementById('logohpsc').className = "fade-in";
                    document.getElementById('logomt2005').setAttribute("hidden", "hidden");
                    document.getElementById('logomt2005').className = "";
                    document.getElementById('logointeratec').setAttribute("hidden", "hidden");
                    document.getElementById('logointeratec').className = "";
                    document.getElementById('logoguest').setAttribute("hidden", "hidden");
                    document.getElementById('logoguest').className = "";
                    document.getElementById("hpsc").width = "80";
                } else if (email.includes("mt2005")) {
                    document.getElementById('logomt2005').removeAttribute("hidden");
                    document.getElementById('logomt2005').className = "fade-in";
                    document.getElementById('logohpsc').setAttribute("hidden", "hidden");
                    document.getElementById('logohpsc').className = "";
                    document.getElementById('logointeratec').setAttribute("hidden", "hidden");
                    document.getElementById('logointeratec').className = "";
                    document.getElementById('logoguest').setAttribute("hidden", "hidden");
                    document.getElementById('logoguest').className = "";
                    document.getElementById("mt2005").width = "75";
                } else if (email.includes("interatec")) {
                    document.getElementById('logointeratec').removeAttribute("hidden");
                    document.getElementById('logointeratec').className = "fade-in";
                    document.getElementById('logohpsc').setAttribute("hidden", "hidden");
                    document.getElementById('logohpsc').className = "";
                    document.getElementById('logomt2005').setAttribute("hidden", "hidden");
                    document.getElementById('logomt2005').className = "";
                    document.getElementById('logoguest').setAttribute("hidden", "hidden");
                    document.getElementById('logoguest').className = "";
                    document.getElementById("interatec").width = "100";
                } else {
                    document.getElementById('logohpsc').removeAttribute("hidden");
                    document.getElementById('logohpsc').className = "fade-in";
                    document.getElementById('logomt2005').setAttribute("hidden", "hidden");
                    document.getElementById('logomt2005').className = "";
                    document.getElementById('logointeratec').setAttribute("hidden", "hidden");
                    document.getElementById('logointeratec').className = "";
                    document.getElementById('logoguest').setAttribute("hidden", "hidden");
                    document.getElementById('logoguest').className = "";
                    document.getElementById("hpsc").width = "80";
                }
            }
        }
</script>
</asp:Content>
