<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPass.aspx.cs" Inherits="LaHerradura.CambioPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="App_Themes/bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="App_Themes/AdminLTE/css/AdminLTE.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row" style="margin-top: 50px;">
                <div class="col-md-8 col-md-offset-2">
                    <div class="alert alert-success fade in alert-dismissible" style="margin-top: 18px;"
                        runat="server" id="divOk" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close" title="close">×</a>
                        <strong>Su clave a sido restalecida con exito</strong>
                        <div style="text-align: right; margin-top:25px;">
                            <a href="index.aspx" class="btn btn-success" runat="server">Salir</a>
                        </div>
                    </div>

                </div>
                <div class="col-md-8 col-md-offset-2">
                    <div class="alert alert-danger fade in alert-dismissible" style="margin-top: 18px;"
                        runat="server" id="divError" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close" title="close">×</a>
                        <strong id="msgError" runat="server"></strong>
                    </div>
                </div>
                <div class="col-md-8 col-md-offset-2" id="divCambioPass" runat="server">
                    <div class="box box-primary" style="border-top-color: #3c4c39;">
                        <div class="box-header" style="text-align: center;">
                            <img src="http://200.89.178.11/img/mailRecuperoPass.png" style="width: 100%;" />
                            <hr style="border-top: 1px solid #d2d6de;" />
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>Nueva contraseña</label>
                                <asp:TextBox ID="txtPass" CssClass="form-control"
                                    placeholder="Ingrese su nueva clave"
                                    TextMode="Password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rv1" ForeColor="Red" ControlToValidate="txtPass"
                                    runat="server" ErrorMessage="Ingrese la contraseña"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Repita contraseña</label>
                                <asp:TextBox ID="txtPass2" CssClass="form-control"
                                    placeholder="Repita su nueva clave"
                                    TextMode="Password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rv2" ForeColor="Red" ControlToValidate="txtPass2"
                                    runat="server" ErrorMessage="Ingrese la contraseña"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cv1" runat="server" ForeColor="Red"
                                    ControlToValidate="txtPass2" ControlToCompare="txtPass"
                                    ErrorMessage="Las contraseñas ingresadas no coinciden"></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="box-footer" style="text-align: right;">
                            <a href="index.aspx" class="btn btn-warning" runat="server">Cancelar</a>
                            <asp:Button ID="btnAceptar" CssClass="btn btn-primary" runat="server"
                                Text="Aceptar" OnClick="btnAceptar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
