﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="LaHerradura.Proveedores.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hID" runat="server" />
    <asp:HiddenField ID="hIdProv" runat="server" />
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
            <div class="col-xs-9">
                <div class="input-group">
                </div>
                <!-- /input-group -->

            </div>
            <div class="col-xs-3">
                <div class="btn-group pull-right" id="divAddProv" runat="server">
                    <a href="#" class="btn btn-primary"
                        onclick="abrirEdit('','','','','','',
                        '','','','','','','','','','')">
                        <i class="fa fa-plus"></i>&nbsp;Nuevo Proveedor
                    </a>
                </div>
            </div>
        </div>


    </section>
    <!-- Main content -->
    <section class="content">
        <div class="outer_div">
            <div class="row" id="divListado" runat="server">
                <div class="col-md-12">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">Listado de Proveedores</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <asp:GridView ID="gvProveedores"
                                CssClass="table"
                                runat="server"
                                ShowHeader="true"
                                OnRowDataBound="gvProveedores_RowDataBound"
                                OnRowCommand="gvProveedores_RowCommand"
                                CellPadding="4"
                                AutoGenerateColumns="False"
                                ForeColor="#333333"
                                GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="Empresa">
                                        <ItemTemplate>
                                            <p>
                                                <strong>Razon Social: </strong>
                                                <%# Eval("RAZON_SOCIAL") %>
                                            </p>
                                            <p>
                                                <strong>Nombre Fantasia: </strong>
                                                <%# Eval("NOMBRE_FANTASIA") %>
                                            </p>
                                            <p>
                                                <i class="fa fa-address-card"></i>&nbsp;<span><asp:Literal
                                                    ID="txtCondIva" runat="server"></asp:Literal></span>
                                            </p>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Direcci&#243;n">
                                        <ItemTemplate>
                                            <p>
                                                <i class="fa fa-address-book"></i>&nbsp;<%# Eval("calle") %>
                                                <%# Eval("nro") %> Bº <%# Eval("barrio") %>
                                            </p>
                                            <p>
                                                &nbsp;<%# Eval("localidad") %>, <span>
                                                    <asp:Literal
                                                        ID="txtProvincia" runat="server"></asp:Literal>
                                                    -                                                             
                                                            <asp:Literal
                                                                ID="ltlPais" runat="server"></asp:Literal></span>
                                            </p>
                                            <p>
                                                CP: <%# Eval("CP") %>
                                            </p>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contacto">
                                        <ItemTemplate>
                                            <p><i class="fa fa-phone"></i>&nbsp;<%# Eval("tel") %></p>
                                            <p><i class="fa fa-envelope"></i>&nbsp;<%# Eval("mail") %></p>
                                            <p><i class="fa fa-globe"></i>&nbsp;<a href="<%# Eval("web") %>" target="_blank"><%# Eval("web") %></a></p>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="btn-group pull-right" id="mnuAcciones" runat="server">
                                                <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">Acciones <span class="fa fa-caret-down"></span></button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="lbtnContactos"
                                                            CommandName="contactos"
                                                            CommandArgument='<%# Eval("id") %>'
                                                            runat="server">
                                                                    <i class="fa fa-users"></i>Contactos
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <a href="#"
                                                            onclick="abrirEdit('<%# Eval("ID") %>',
                                                            '<%# Eval("BARRIO") %>',
                                                            '<%# Eval("CALLE") %>',
                                                            '<%# Eval("CP") %>',
                                                            '<%# Eval("CUIT") %>',
                                                            '<%# Eval("ING_BRUTOS") %>',
                                                            '<%# Eval("LOCALIDAD") %>',
                                                            '<%# Eval("MAIL") %>',
                                                            '<%# Eval("NOMBRE_FANTASIA") %>',
                                                            '<%# Eval("NRO") %>',
                                                            '<%# Eval("RAZON_SOCIAL") %>',
                                                            '<%# Eval("TEL") %>',
                                                            '<%# Eval("WEB") %>',
                                                            '<%# Eval("COND_IVA") %>',
                                                            '<%# Eval("PAIS") %>',
                                                            '<%# Eval("PROVINCIA") %>')">
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
                                                    <li>
                                                        <a href="CtasCtesGastos.aspx?ID=<%# Eval("ID") %>">
                                                            <span class="fa fa-dollar-sign"></span>&nbsp; Cuenta corrienta
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="btnContabilidad"
                                                            CommandName="contabilidad"
                                                            CommandArgument='<%# Eval("id") %>'
                                                            runat="server">
                                                                    <i class="fa fa-money-bill"></i>Contabilidad
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
            <div class="row" id="divContabilidad" runat="server" visible="false">
                <div class="col-md-10 col-md-offset-1">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title" id="lblTitProv" runat="server"></h3>
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label>Cuenta pasivo</label>
                                        <asp:DropDownList ID="DDLPasivo"
                                            CssClass="form-control"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label>Cuenta gastos</label>
                                        <asp:DropDownList ID="DDLGastos"
                                            CssClass="form-control"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2" style="padding-top: 25px;">
                                    <asp:LinkButton ID="btnAddCuenta"
                                        OnClick="btnAddCuenta_Click"
                                        CssClass="btn btn-success btn-block" runat="server">
                                    <span class="fa fa-check"></span>
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="gvAsignacionCuentas"
                                        CssClass="table table-condensed"
                                        DataKeyNames="ID_PROV,ID_CTA_CONTABLE_PASIVO,ID_CTA_CONTABLE_GASTO"
                                        AutoGenerateColumns="false"
                                        OnRowCommand="gvAsignacionCuentas_RowCommand"
                                        runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                        <Columns>
                                            <asp:BoundField DataField="CUENTA_PASIVO" HeaderText="Cuenta pasivo" />
                                            <asp:BoundField DataField="CUENTA_GASTO" HeaderText="Cuenta gastos" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton
                                                        ID="btnEliminar"
                                                        CommandName="eliminar"
                                                        OnClientClick="return confirm('¿Esta seguro de quitar la asignacion?');"
                                                        CommandArgument='<%# Container.DataItemIndex %>'
                                                        runat="server">
                                                        <span class="fa fa-remove" style="color:red;"></span>
                                                    </asp:LinkButton>
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
                            </div>
                        </div>
                        <div class="box-footer" style="text-align:right;">
                            <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-warning"
                                OnClick="btnVolver_Click"
                                Text="Volver" />
                        </div>
                    </div>
                </div>
            </div>
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
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#activity" data-toggle="tab">Datos Empresa</a></li>
                            <li><a href="#timeline" data-toggle="tab">Contacto</a></li>
                            <li><a href="#settings" data-toggle="tab">Dirección</a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="active tab-pane" id="activity" style="min-height: 320px;">
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label>Razon Social</label>
                                        <asp:TextBox ID="txtRazonSocial" CssClass="form-control"
                                            placeholder="Ingrese la Razon Social de la Empresa" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rv1" runat="server" ValidationGroup="proveedor"
                                            Text="*" ForeColor="Red" Display="Dynamic"
                                            ErrorMessage="Ingrese la Razon Social" ControlToValidate="txtRazonSocial">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Nombre Fantasia</label>
                                        <asp:TextBox ID="txtNombreFantasia" CssClass="form-control"
                                            placeholder="Ingrese el Nombre de Fantasia de la Empresa" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rv2" runat="server" ValidationGroup="proveedor"
                                            Text="*" ForeColor="Red" Display="Dynamic"
                                            ErrorMessage="Ingrese el Nombre" ControlToValidate="txtNombreFantasia">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label>CUIT <small>Sin puntos ni guiones</small></label>
                                        <asp:TextBox ID="txtCUIT"
                                            TextMode="Number"
                                            CssClass="form-control"
                                            placeholder="Ingrese el CUIT de la Empresa" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rv3" runat="server" ValidationGroup="proveedor"
                                            Text="*" ForeColor="Red" Display="Dynamic"
                                            ErrorMessage="Por favor ingrese un número de CUIT valido (sin puntos ni guiones)" ControlToValidate="txtCUIT">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>NRO. ING. BRUTOS</label>
                                        <asp:TextBox ID="txtIngBrutos" CssClass="form-control"
                                            placeholder="Ingrese el Nro. de Ingresos Brutos de la Empresa" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-md-12">
                                        <label>Condicion IVA</label>
                                        <asp:DropDownList ID="DDLIva" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <!-- /.tab-pane -->
                            <div class="tab-pane" id="timeline" style="min-height: 260px;">
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label>Teléfono</label>
                                        <asp:TextBox ID="txtTelefono" CssClass="form-control"
                                            placeholder="Ingrese el Telefono de la Empresa" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Mail</label>
                                        <asp:TextBox ID="txtMail" CssClass="form-control" TextMode="Email"
                                            placeholder="Ingrese el mail de la Empresa" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-md-12">
                                        <label>Sitio Web</label>
                                        <asp:TextBox ID="txtWeb" CssClass="form-control"
                                            placeholder="Ingrese el Sitio Web de la Empresa" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <!-- /.tab-pane -->

                            <div class="tab-pane" id="settings" style="min-height: 320px;">
                                <div class="row">
                                    <asp:UpdatePanel ID="uPanelModal" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group col-md-6">
                                                <label>Pais</label>
                                                <asp:DropDownList ID="DDLPais"
                                                    AutoPostBack="true"
                                                    OnSelectedIndexChanged="DDLPais_SelectedIndexChanged"
                                                    CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Provincia</label>
                                                <asp:DropDownList ID="DDLProvincia"
                                                    CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label>Localidad</label>
                                        <asp:TextBox ID="txtLocalidad" CssClass="form-control"
                                            placeholder="Ingrese la Localidad de la Empresa" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Barrio</label>
                                        <asp:TextBox ID="txtBarrio" CssClass="form-control"
                                            placeholder="Ingrese el Barrio de la Empresa" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label>Calle</label>
                                        <asp:TextBox ID="txtCalle" CssClass="form-control"
                                            placeholder="Ingrese la Calle de la Empresa" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Nro</label>
                                        <asp:TextBox ID="txtNro" CssClass="form-control"
                                            placeholder="Ingrese el Nro de la Empresa" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-md-12">
                                        <label>Código Postal</label>
                                        <asp:TextBox ID="txtCP" CssClass="form-control"
                                            placeholder="Ingrese el Codigo Postal de la Empresa" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <!-- /.tab-pane -->
                        </div>
                        <!-- /.tab-content -->
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="proveedor" />
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnCrearCliente" runat="server"
                        ValidationGroup="proveedor"
                        CssClass="btn btn-primary" Text="Aceptar"
                        OnClick="btnCrearCliente_Click" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvProveedores.ClientID %>').DataTable(
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
        function abrirEdit(ID, BARRIO, CALLE, CP, CUIT, ING_BRUTOS, LOCALIDAD, MAIL, NOMBRE_FANTASIA, NRO, RAZON_SOCIAL, TEL, WEB, COND_IVA, PAIS, PROVINCIA) {
            $('#modalProveedor').modal('show');
            $("#ContentPlaceHolder1_hID").val(ID);
            $("#ContentPlaceHolder1_txtBarrio").val(BARRIO);
            $("#ContentPlaceHolder1_txtCalle").val(CALLE);
            $("#ContentPlaceHolder1_txtCP").val(CP);
            $("#ContentPlaceHolder1_txtCUIT").val(CUIT);
            $("#ContentPlaceHolder1_txtIngBrutos").val(ING_BRUTOS);
            $("#ContentPlaceHolder1_txtLocalidad").val(LOCALIDAD);
            $("#ContentPlaceHolder1_txtMail").val(MAIL);
            $("#ContentPlaceHolder1_txtNombreFantasia").val(NOMBRE_FANTASIA);
            $("#ContentPlaceHolder1_txtNro").val(NRO);
            $("#ContentPlaceHolder1_txtRazonSocial").val(RAZON_SOCIAL);
            $("#ContentPlaceHolder1_txtTelefono").val(TEL);
            $("#ContentPlaceHolder1_txtWeb").val(WEB);
            $("#ContentPlaceHolder1_DDLIva").val(COND_IVA);
            $("#ContentPlaceHolder1_DDLPais").val(PAIS);
            $("#ContentPlaceHolder1_DDLProvincia").val(PROVINCIA);
        }
    </script>
</asp:Content>
