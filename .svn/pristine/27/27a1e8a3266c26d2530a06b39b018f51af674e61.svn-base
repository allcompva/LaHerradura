<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Proveedores_contactos.aspx.cs" Inherits="LaHerradura.Proveedores.Proveedores_contactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hID" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Button" Style="visibility: hidden;" />
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <div class="row">
            <div class="col-md-12">
                <div class="alert alert-danger alert-dismissible fade in" role="alert" id="divError"
                    runat="server" visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4>Error!</h4>
                    <p id="txtError" runat="server">
                    </p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="alert alert-success alert-dismissible fade in" role="alert" id="divOk"
                    runat="server" visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4>Error!</h4>
                    <p id="txtOk" runat="server">
                    </p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="btn-group pull-right">
                    <asp:LinkButton ID="lbtnSalir"
                        PostBackUrl="~/Proveedores/Proveedores.aspx"
                        CssClass="btn btn-success"
                        runat="server">
                                <i class="fa fa-sign-out"></i> Salir
                    </asp:LinkButton>
                    <a href="#" class="btn btn-primary" onclick="abrirEdit('', '', '', '', '', '', '', '', 'M') ">
                        <i class="fa fa-plus"></i>&nbsp;Nuevo Contacto
                    </a>
                </div>
            </div>
        </div>
    </section>
    <!-- Main content -->
    <section class="content">
        <div id="resultados_ajax"></div>
        <div class="outer_div">
            <div class="row">
                <div class="col-md-12">
                    <div class="box">
                        <div class="box-header with-border">
                            <p>
                                <h3 class="box-title"><strong>Empresa: </strong><strong id="lblEmpresa" style="color: #3c8dbc;" runat="server"></strong></h3>
                                <hr />
                            </p>
                            <p>
                                <h5 class="box-title">Listado de Contactos</h5>
                            </p>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <asp:GridView ID="gvContactos"
                                CssClass="table"
                                runat="server"
                                EmptyDataText="No se encuentran contactos para la empresa solicitada"
                                OnRowDataBound="gvContactos_RowDataBound"
                                OnRowCommand="gvContactos_RowCommand"
                                CellPadding="4"
                                AutoGenerateColumns="false"
                                ForeColor="#333333"
                                GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="Contacto">
                                        <ItemTemplate>
                                            <p><i class="fa fa-user"></i>&nbsp;<%# Eval("apellido") %> , <%# Eval("nombre") %></p>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Area">
                                        <ItemTemplate>
                                            <p><i class="fa fa-address-book"></i>&nbsp;<%# Eval("area") %></p>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contacto">
                                        <ItemTemplate>
                                            <p>
                                                <i class="fa fa-phone"></i>&nbsp;<%# Eval("telefono") %> - Interno: <%# Eval("interno") %> - 
                                                    <i class="fa fa-mobile-alt"></i>&nbsp;<%# Eval("celular") %> - 
                                                    <i class="fa fa-envelope"></i>&nbsp;<%# Eval("mail") %>
                                            </p>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="btn-group pull-right">
                                                <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">Acciones <span class="fa fa-caret-down"></span></button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <a href="#"
                                                            onclick="abrirEdit('<%# Eval("ID") %>',
                                                            '<%# Eval("APELLIDO") %>',
                                                            '<%# Eval("AREA") %>',
                                                            '<%# Eval("CELULAR") %>',
                                                            '<%# Eval("INTERNO") %>',
                                                            '<%# Eval("MAIL") %>',
                                                            '<%# Eval("NOMBRE") %>',
                                                            '<%# Eval("TELEFONO") %>',
                                                            '<%# Eval("SEXO") %>')">
                                                            <i class="fa fa-edit"></i>Editar
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="lbtnBorrar"
                                                            CommandName="eliminar"
                                                            OnClientClick='return confirm("Esta de eliminar el cliente");'
                                                            CommandArgument='<%# Eval("id") %>'
                                                            runat="server">
                                                                    <i class="fa fa-trash"></i>Borrar
                                                        </asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999"></EditRowStyle>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer clearfix">
                        </div>
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->


        </div>
        <!-- Datos ajax Final -->
    </section>

    <div class="modal fade in" id="modalProveedor">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Default Modal</h4>
                </div>
                <div class="modal-body">
                    <div class="modal-body">
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#activity" data-toggle="tab">Datos Personales</a></li>
                                <li><a href="#timeline" data-toggle="tab">Contacto</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="active tab-pane" id="activity" style="min-height: 280px;">
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <label>Apellido</label>
                                            <asp:TextBox ID="txtApellido" CssClass="form-control"
                                                placeholder="Ingrese el Apellido del contacto" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rv1" runat="server" ValidationGroup="contacto"
                                                Text="*" ForeColor="Red" Display="Dynamic"
                                                ErrorMessage="Ingrese el Apellido" ControlToValidate="txtApellido">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label>Nombre</label>
                                            <asp:TextBox ID="txtNombre" CssClass="form-control"
                                                placeholder="Ingrese el Nombre del contacto" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rv2" runat="server" ValidationGroup="contacto"
                                                Text="*" ForeColor="Red" Display="Dynamic"
                                                ErrorMessage="Ingrese el Nombre" ControlToValidate="txtNombre">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <label>Sexo</label>
                                            <asp:DropDownList ID="DDLSexo" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="M" Text="Masculino"></asp:ListItem>
                                                <asp:ListItem Value="F" Text="Femenino"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label>Area / Departamento</label>
                                            <asp:TextBox ID="txtArea" CssClass="form-control"
                                                placeholder="Ingrese el Area del contacto" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ValidationGroup="contacto"
                                                Text="*" ForeColor="Red" Display="Dynamic"
                                                ErrorMessage="Ingrese el Area del contacto" ControlToValidate="txtArea">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="timeline" style="min-height: 260px;">
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <label>Teléfono</label>
                                            <asp:TextBox ID="txtTelefono" CssClass="form-control"
                                                placeholder="Ingrese el Telefono del Contacto" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label>Interno</label>
                                            <asp:TextBox ID="txtInterno" CssClass="form-control"
                                                placeholder="Ingrese el/los Internos del contacto" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group col-md-6">
                                            <label>Celular</label>
                                            <asp:TextBox ID="txtCel" CssClass="form-control"
                                                placeholder="Ingrese el celular del contacto" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ValidationGroup="contacto"
                                                Text="*" ForeColor="Red" Display="Dynamic"
                                                ErrorMessage="Ingrese el Celular" ControlToValidate="txtCel">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label>Mail</label>
                                            <asp:TextBox ID="txtMail" CssClass="form-control"  TextMode="Email"
                                                placeholder="Ingrese el mail del contacto" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rv6" runat="server" ValidationGroup="contacto"
                                                Text="*" ForeColor="Red" Display="Dynamic"
                                                ErrorMessage="Ingrese el Mail" ControlToValidate="txtMail">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.tab-pane -->
                            </div>
                            <!-- /.tab-content -->
                        </div>
                        <!-- /.nav-tabs-custom -->


                    </div>
                    <div class="modal-footer">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="contacto" />
                        <asp:Button ID="btnCancelarModal" runat="server"
                            CssClass="btn btn-default" Text="Cancelar"
                            OnClick="btnCancelarModal_Click" />
                        <asp:Button ID="btnCrearCliente" runat="server"
                            ValidationGroup="contacto"
                            CssClass="btn btn-primary" Text="Aceptar"
                            OnClick="btnCrearCliente_Click" />
                    </div>

                </div>

            </div>
        </div>
    </div>


    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvContactos.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"
                    }
                }
            );
        });
        function abrirEdit(ID, APELLIDO, AREA, CELULAR, INTERNO, MAIL, NOMBRE, TELEFONO, SEXO) {
            $('#modalProveedor').modal('show');
            $("#ContentPlaceHolder1_hID").val(ID);
            $("#ContentPlaceHolder1_txtApellido").val(APELLIDO);
            $("#ContentPlaceHolder1_txtArea").val(AREA);
            $("#ContentPlaceHolder1_txtCel").val(CELULAR);
            $("#ContentPlaceHolder1_txtInterno").val(INTERNO);
            $("#ContentPlaceHolder1_txtMail").val(MAIL);
            $("#ContentPlaceHolder1_txtNombre").val(NOMBRE);
            $("#ContentPlaceHolder1_txtMail").val(MAIL);
            $("#ContentPlaceHolder1_txtTelefono").val(TELEFONO);
            $("#ContentPlaceHolder1_DDLSexo").val(SEXO);
        }
    </script>
</asp:Content>
