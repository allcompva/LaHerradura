<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Persona.aspx.cs" Inherits="LaHerradura.Back.Persona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hIdTelefono" runat="server" />
    <div class="row" style="margin-top: 25px;">
        <div class="col-md-10 col-md-offset-1">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Agregar / Editar persona</h3>
                </div>
                <div class="box-body">
                    <div class="col-md-8">
                        <div class="row" style="padding: 10px;">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Apellido</label>
                                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="padding: 10px;">
                            <%--                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Tipo Doc</label>
                                    <asp:DropDownList ID="DDLTipoDoc" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>--%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Nro. Doc</label>
                                    <asp:TextBox ID="txtNroDoc" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>C.U.I.T.</label>
                                    <asp:TextBox ID="txtCuit" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="padding: 10px;">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Sexo</label>
                                    <asp:DropDownList ID="DDLSexo" CssClass="form-control"
                                        runat="server">
                                        <asp:ListItem Value="M" Text="Masculino"></asp:ListItem>
                                        <asp:ListItem Value="F" Text="Femenino"></asp:ListItem>
                                        <asp:ListItem Value="PJ" Text="Persona Jurídica"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Fec. Nacimiento</label>
                                    <asp:TextBox TextMode="Date" ID="txtFecNac" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4" style="text-align: right" id="divTelefonos" runat="server">
                        <button type="button" class="btn btn-social btn-bitbucket" onclick="abrirModalTelefono('', '54', '351', '')">
                            <i class="fa fa-phone"></i>Agrgar Telefono
                        </button>
                        <div style="margin-top: 10px;">
                            <asp:GridView
                                ID="gvTelefonos"
                                ShowFooter="false"
                                ShowHeader="false"
                                AutoGenerateColumns="false"
                                GridLines="Horizontal"
                                CssClass="table table-hover"
                                runat="server">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            +<%#Eval("COD_PAIS")%> (<%#Eval("COD_AREA")%>)<%#Eval("NUMERO")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <a href="#" onclick="abrirModalTelefono('<%#Eval("ID")%>', '<%#Eval("COD_PAIS")%>', '<%#Eval("COD_AREA")%>', '<%#Eval("NUMERO")%>')">
                                                <span class="fa fa-edit"></span>
                                            </a>
                                            <a href="#" onclick="abrirModalEliminaMail('<%#Eval("ID")%>', '<%#Eval("COD_PAIS")%>', '<%#Eval("COD_AREA")%>', '<%#Eval("NUMERO")%>')"><span class="fa fa-remove" style="color: red;"></span></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BorderColor="LightGray" />
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
            <div class="box-footer" style="text-align: right;">
                <asp:Button ID="btnCancelar" CssClass="btn btn-warning"
                    OnClick="btnCancelar_Click"
                    runat="server" Text="Cancelar" />
                <asp:Button ID="btnAceptar" CssClass="btn btn-primary"
                    OnClick="btnAceptar_Click"
                    runat="server" Text="Aceptar" />
            </div>
        </div>
    </div>


    <div class="modal fade in" id="modalAddTelefono">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Agrregar Telefono</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-3 form-group">
                            <label>Cod. Pais</label>
                            <asp:TextBox TextMode="Number" ID="txtCodPais" CssClass="form-control"
                                Text="54" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rv1" runat="server" ForeColor="Red"
                                ValidationGroup="agregarTelefono"
                                ControlToValidate="txtCodPais" Display="Dynamic"
                                ErrorMessage="Ingrese código de pais"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3 form-group">
                            <label>Cod. Area <small>(Sin 0)</small></label>
                            <asp:TextBox TextMode="Number" ID="txtCodArea" CssClass="form-control"
                                Text="351" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rv2" runat="server" ForeColor="Red"
                                ControlToValidate="txtCodArea" Display="Dynamic"
                                ValidationGroup="agregarTelefono"
                                ErrorMessage="Ingrese código de area"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Numero <small>(Sin 15)</small></label>
                            <asp:TextBox TextMode="Number" ID="txtNro" CssClass="form-control"
                                Text="" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rv3" runat="server" ForeColor="Red"
                                ControlToValidate="txtNro" Display="Dynamic"
                                ValidationGroup="agregarTelefono"
                                ErrorMessage="Ingrese número"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="text-align: right;">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnAceptarTelefono" runat="server"
                        ValidationGroup="agregarTelefono"
                        onserverclick="btnAceptarTelefono_ServerClick" class="btn btn-primary">
                        Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal modal-danger fade in" id="modalMailElimina">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Eliminar Mail</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Esta seguro de eliminar el telefono</label>
                        <asp:TextBox ID="txtEliminaMail" Enabled="false" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnEliminarMail" CssClass="btn btn-outline"
                        OnClick="btnEliminarMail_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
    <script>
        function abrirModalTelefono(ID, COD_PAIS, COD_AREA, NUMERO) {
            $('#modalAddTelefono').modal('show');
            //ID
            $("#ContentPlaceHolder1_hIdTelefono").val(ID);
            $("#ContentPlaceHolder1_txtCodPais").val(COD_PAIS);
            $("#ContentPlaceHolder1_txtCodArea").val(COD_AREA);
            $("#ContentPlaceHolder1_txtNro").val(NUMERO);
            $("#ContentPlaceHolder1_txtNro").focus();
        }
        function abrirModalEliminaMail(ID, COD_PAIS, COD_AREA, NUMERO) {
            $('#modalMailElimina').modal('show');
            //ID
            $("#ContentPlaceHolder1_hIdTelefono").val(ID);
            $("#ContentPlaceHolder1_txtEliminaMail").val('+' + COD_PAIS + '(' + COD_AREA + ') ' + NUMERO);

        }
    </script>
</asp:Content>
