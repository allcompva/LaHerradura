<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexAdmin.aspx.cs" Inherits="LaHerradura.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
        <div class="login-box">
            <div class="login-logo">
                <a href="../../index2.html">La <b>Herradura</b></a>
            </div>
            <!-- /.login-logo -->
            <div class="login-box-body">
                <p class="login-box-msg">Iniciar Sesión</p>
                <div class="form-group has-feedback">
                    <input type="text" class="form-control" placeholder="Usuario"
                        runat="server" id="txtMail" />
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <input type="password" class="form-control" placeholder="Password"
                        id="txtPass" runat="server" />
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                    <div class="col-xs-8">
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <button type="submit" id="btnIngresar" runat="server"
                            onserverclick="btnIngresar_ServerClick"
                            class="btn btn-primary btn-block btn-flat">
                            Ingresar</button>
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
            <!-- /.login-box-body -->
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
                                        Si olvido su contraseña, indique su nombre de usuario y el sistema le enviara 
                                    de forma automatica a su correo las instrucciones para reestablecer su clave
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Nombre de usuario</label>
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
