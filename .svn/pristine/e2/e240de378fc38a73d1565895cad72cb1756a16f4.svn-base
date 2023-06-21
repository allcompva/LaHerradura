<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LaHerradura.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>La | Herradura</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"
        name="viewport" />
    <!-- Bootstrap 3.3.7 -->
    <link href="App_Themes/bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="App_Themes/bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Theme style -->
    <link href="App_Themes/AdminLTE/css/AdminLTE.min.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />
</head>
<body>
    <form id="form1" runat="server" style="overflow-y: hidden">
        <header class="main-header">
            <!-- Header Navbar: style can be found in header.less -->
            <nav class="navbar navbar-static-top">
                <div class="navbar-custom-menu">
                    <ul class="nav navbar-nav">
                        <li class="dropdown user user-menu">
                            <a href="indexAdmin.aspx">
                                <span class="hidden-xs">Acceso administracion</span>
                            </a>
                        </li>
                    </ul>
                </div>

            </nav>
        </header>
        <div class="login-box" style="box-shadow: 0 -1px 0 #e5e5e5, 0 0 2px rgba(0,0,0,0.12), 0 2px 4px rgba(0,0,0,0.24); padding: 20px;">
            <div class="login-logo">
                <img src="img/logo.png" style="width: 100%;" />
                <p style="text-align: right; color: #46653d;"><b>Online</b></p>
                <hr style="border-top: 1px solid #d2d2d2;" />
            </div>
            <!-- /.login-logo -->
            <div class="login-box-body" id="divLogIEstadar" runat="server">
                <div class="form-group has-feedback">
                    <input type="number" class="form-control" placeholder="C.U.I.T"
                        runat="server" id="txtMail" />
                    <span class="glyphicon glyphicon-user form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <input type="password" class="form-control" placeholder="Password"
                        id="txtPass" runat="server" />
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                    <div class="col-xs-12" style="text-align: center; margin-bottom: 20px; margin-top: 20px;">
                        <button type="submit" id="btnIngresar" runat="server"
                            onserverclick="btnIngresar_ServerClick"
                            style="border-radius: 20px; min-width: 50%;"
                            class="btn btn-bitbucket">
                            <span class="fa fa-sign-in"></span>&nbspIngresar</button>
                        <%--<button id="Button1" class="btn btn-primary" runat="server"
                            style="font-size: 1.5rem;"
                            onserverclick="Button1_ServerClick" 
                            validationgroup="login">
                            Set Pass</button> --%>
                    </div>
                    <!-- /.col -->
                    <div class="col-md-12 alert alert-success fade in alert-dismissible" id="divOk" visible="false"
                        style="margin-top: 15pX;" runat="server">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close" title="close">×</a>
                        <strong>Ok!</strong> <span id="lblOk" runat="server"></span>
                    </div>
                    <div class="col-md-12">
                        <span class="fa fa-warning" style="color: red;"
                            visible="false"
                            id="lblError" runat="server"></span>
                    </div>
                </div>
                <a href="#" data-toggle="modal" data-target="#modalPass">Olvide mi contraseña</a><br />
            </div>
            <div class="login-box-body" id="divPrimerIgreso" runat="server" visible="false">
                <div class="form-group has-feedback" style="text-align: center;">
                    <h3 class="modal-title" id="myModalLabel">Actualizar contraseña
                    </h3>
                </div>
                <div class="form-group has-feedback">
                    <asp:HiddenField ID="hEstado" runat="server" />
                    <div id="divLogIn" runat="server">
                        <p class="login-box-msg" style="color: white; text-align: left; font-size: 18px; padding-left: 0;">
                        </p>

                        <div class="form-group has-feedback">
                            <label>Contraseña actual</label>
                            <input type="password" class="form-control" placeholder="Contraseña Actual" id="txtOldPass" runat="server" />
                            <asp:RequiredFieldValidator ID="rv1" runat="server" ErrorMessage="Ingrese su contraseña actual" ForeColor="red"
                                ControlToValidate="txtOldPass" ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group has-feedback">
                            <label>Nueva Contraseña</label>
                            <input type="password" class="form-control" placeholder="Contraseña Nueva" id="txtNewPass" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese su nueva contraseña" ForeColor="red"
                                ControlToValidate="txtNewPass" ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group has-feedback">
                            <label>Repita su nueva contraseña</label>
                            <input type="password" class="form-control" placeholder="Repita su nueva contraseña" id="txtNewPass2" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Repita su nueva contraseña"
                                ForeColor="red" Display="Dynamic"
                                ControlToValidate="txtNewPass2" ValidationGroup="login"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="red" ControlToValidate="txtNewPass2"
                                ControlToCompare="txtNewPass" ValidationGroup="login" Display="Dynamic"
                                ErrorMessage="Las contraseñas ingresadas no coinciden"></asp:CompareValidator>
                        </div>
                        <div class="form-group has-feedback">
                            <label>Mail</label>
                            <input type="email" class="form-control" placeholder="Ingrese su mail" id="txtMal"
                                runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese su nueva contraseña" ForeColor="red"
                                ControlToValidate="txtMal" ValidationGroup="login"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row">
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <!-- /.col -->
                    <div class="col-xs-12" style="text-align: right;">
                        <button type="button" class="btn btn-warning" data-dismiss="modal" id="btnCacelar"
                            runat="server" onserverclick="btnCacelar_ServerClick">
                            <span aria-hidden="true">Cancelar</span>
                        </button>

                        <button id="btnCambioPass" class="btn btn-primary" runat="server"
                            style="font-size: 1.5rem;"
                            onserverclick="btnCambioPass_ServerClick" validationgroup="login">
                            SIGUIENTE</button>
                    </div>
                    <!-- /.col -->
                </div>
            </div>
            <!-- /.login-box-body -->
        </div>
        <div>
        </div>
        <div class="modal fade in" id="modalPass">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
                        <h4 class="modal-title">Recuperar mi contraseña</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <p>
                                    Si olvido su contraseña, indique su número de CUIT y el sistema le enviara 
                                    de forma automatica a su correo las instrucciones para reestablecer su clave
                                </p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Número de CUIT</label>
                                    <asp:TextBox CssClass="form-control" ID="txtUsuarioRecupero" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="text-align: right;">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <button runat="server" onserverclick="btnAceptarCambioPass_ServerClick" id="btnAceptarCambioPass"
                            type="button" class="btn btn-primary">
                            Aceptar</button>
                    </div>

                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>

        <script src="App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
        <script src="App_Themes/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
