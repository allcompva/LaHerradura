<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="True" CodeBehind="CambioPass.aspx.cs" Inherits="LaHerradura.Back.CambioPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="margin-top: 50px;">
            <div class="col-md-8 col-md-offset-2">
                <div class="alert alert-success fade in alert-dismissible" style="margin-top: 18px;"
                    runat="server" id="divOk" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close" title="close">×</a>
                    <strong>Su clave a sido restablecida con éxito!</strong>
                    <div style="text-align: right; margin-top: 25px;">
                        <asp:Button ID="Button1" OnClick="btnCancel_Click" runat="server"
                            Text="Salir" CssClass="btn btn-warning" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="alert alert-danger fade in alert-dismissible" style="margin-top: 18px;"
                    runat="server" id="divError" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close" title="close">×</a>
                    <strong id="msgError" runat="server"></strong>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 col-md-offset-2" id="divCambioPass" runat="server">
                <div class="box box-primary" style="border-top-color: #3c4c39;">
                    <div class="box-header" style="text-align: center;">
                        <h2>Cambio de contraseña</h2>
                        <hr style="border-top: 1px solid #d2d6de;" />
                    </div>
                    <div class="box-body">

                        <h4 id="lblPersona" runat="server"></h4>
                        <h4 id="lblCuit" runat="server"></h4>
                        <h4 id="lblCuenta" runat="server"></h4>
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
                        <asp:Button ID="btnCancel" OnClick="btnCancel_Click" CausesValidation="false" runat="server"
                            Text="Salir" CssClass="btn btn-warning" />
                        <asp:Button ID="btnAceptar" CssClass="btn btn-primary" runat="server"
                            Text="Aceptar" OnClick="btnAceptar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
