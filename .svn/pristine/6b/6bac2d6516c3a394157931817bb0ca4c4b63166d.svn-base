<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master"
    AutoEventWireup="true" CodeBehind="CtaCteGastos1.aspx.cs"
    Inherits="LaHerradura.Proveedores.CtaCteGastos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <style type="text/css">
        .radioButtonList {
            list-style: none;
            margin: 0;
            padding: 0;
        }

            .radioButtonList.horizontal li {
                display: inline;
            }

            .radioButtonList label {
                display: inline;
                padding: 10px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hIdMedioPago" runat="server" />
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
            <div class="box box-primary">
                <div class="box-header">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label></label>
                            <asp:RadioButtonList ID="rbtnFiltro" AutoPostBack="true"
                                CssClass="radioButtonList"
                                RepeatDirection="Horizontal"
                                CellPadding="20"
                                OnSelectedIndexChanged="rbtnFiltro_SelectedIndexChanged"
                                runat="server">
                                <asp:ListItem Enabled="true" Text="Cuentas a pagar" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Todas" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="divBotones" runat="server">
                        <div class="btn-group pull-right">
                            <a href="#" class="btn btn-primary"
                                onclick="abrirEdit()">
                                <i class="fa fa-plus"></i>&nbsp;Cargar Gasto
                            </a>
                        </div>
                        <div class="btn-group pull-right">
                            <button type="button" class="btn btn-success"
                                data-toggle="modal" data-target="#modalAdelnto">
                                <i class="fa fa-plus"></i>&nbsp;Cargar Adelanto
                            </button>
                        </div>
                    </div>
                </div>
                <div class="box-body">
                    <asp:GridView ID="gvDeudas" CssClass="table"
                        AutoGenerateColumns="false"
                        OnRowDataBound="gvDeudas_RowDataBound"
                        runat="server" CellPadding="4"
                        ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
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
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Id" />
                            <asp:BoundField DataField="CUIT" HeaderText="CUIT" />
                            <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Razon Social" />
                            <asp:BoundField DataField="NOMBRE_FANTASIA" HeaderText="Nombre Fantasia" />
                            <asp:BoundField DataField="MAIL" HeaderText="Mail" />
                            <asp:BoundField DataField="TEL" HeaderText="Telefono" />
                            <asp:BoundField DataField="SALDO" HeaderText="Deuda" DataFormatString="{0:c}" />
                            <asp:TemplateField HeaderText="Sdo. a favor La Herradura">
                                <ItemTemplate>
                                    <div id="divBilletera" runat="server"></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href="CtasCtesGastos.aspx?ID=<%# Eval("ID") %>">
                                        <span class="fa fa-dollar-sign"></span>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="box-footer"></div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalAdelnto">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Adelanto a Proveedor</h4>
                </div>
                <div class="modal-body">
                    <div class="row" id="divMedioPago">
                        <div class="col-md-4">
                            <label>Fecha</label>
                            <asp:TextBox ID="txtFechaAdelanto"
                                TextMode="Date"
                                autocomplete="off"
                                min="0"
                                Text="0"
                                CssClass="form-control"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                runat="server"
                                ControlToValidate="txtMontoVal"
                                ForeColor="Red"
                                ValidationGroup="valMonto"
                                ErrorMessage="Ingrese el monto"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <label>Proveedor</label>
                                <asp:DropDownList ID="DDLProveedor2"
                                    CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-group">
                                <label>Medio Pago</label>
                                <asp:DropDownList ID="DDLMedioPago"
                                    CssClass="form-control"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Monto</label>
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon1">$</span>
                                <asp:TextBox ID="txtMontoVal"
                                    TextMode="Number"
                                    autocomplete="off"
                                    min="0"
                                    Text="0"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rv1"
                                runat="server"
                                ControlToValidate="txtMontoVal"
                                ForeColor="Red"
                                ValidationGroup="valMonto"
                                ErrorMessage="Ingrese el monto"></asp:RequiredFieldValidator>
                        </div>

                        <div id="divCheque" style="display: none;">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Banco</label>
                                    <asp:DropDownList ID="DDLBanco"
                                        CssClass="form-control"
                                        runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Nro. Cheque</label>
                                    <asp:TextBox ID="txtNroCheque"
                                        CssClass="form-control"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>CUIT Pagador</label>
                                    <asp:TextBox ID="txtCuitPagador"
                                        CssClass="form-control"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Fecha Cheque</label>
                                    <asp:TextBox ID="txtFechaCheque"
                                        TextMode="Date"
                                        CssClass="form-control"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <button type="button"
                            runat="server"
                            validationgroup="valMonto"
                            id="btnAceptarAdelanto"
                            onserverclick="btnAceptarAdelanto_ServerClick"
                            class="btn btn-primary">
                            Aceptar</button>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
            <!-- /.modal-dialog -->
        </div>
    </div>
    <div class="modal fade in" id="modalProveedor">
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <asp:UpdatePanel ID="uPanelCtas"
                    UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                            <h4 class="modal-title">Agregar Factura</h4>
                        </div>
                        <div class="modal-body">
                            <div id="divConsultaRequest" runat="server">

                                <div class="row">

                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Proveedor</label>
                                            <asp:DropDownList ID="DDLProveedor"
                                                AutoPostBack="true"
                                                OnSelectedIndexChanged="DDLProveedor_SelectedIndexChanged"
                                                CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Cuenta gasto</label>
                                            <asp:DropDownList ID="DDLCtaGasto" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Tipo gasto</label>
                                            <asp:DropDownList ID="DDLTipoGasto" CssClass="form-control"
                                                runat="server">
                                                <asp:ListItem Text="Abono Mensual" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Gasto Eventual" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Fecha carga</label>
                                            <asp:TextBox ID="txtFechaCarga" CssClass="form-control"
                                                TextMode="Date"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Fecha de Emisión del Comprobante</label>
                                            <asp:TextBox ID="txtFechaEmision" CssClass="form-control" TextMode="Date"
                                                placeholder="Ingrese la Fecha de emisión del comprobante"
                                                runat="server"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="consulta" ID="rv2" ForeColor="Red"
                                            runat="server"
                                            ErrorMessage="Ingrese la Fecha de emisión del comprobante"
                                            ControlToValidate="txtFechaEmision"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Punto de Venta</label>
                                            <asp:TextBox ID="txtPuntoVenta" CssClass="form-control" placeholder="Ingrese el punto de venta"
                                                runat="server"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="consulta" ID="rv3" ForeColor="Red"
                                            runat="server"
                                            ErrorMessage="Ingrese el punto de venta"
                                            ControlToValidate="txtPuntoVenta"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Número de Comprobante</label>
                                            <asp:TextBox ID="txtNumeroComprobante" CssClass="form-control"
                                                placeholder="Ingrese el número de comprobante"
                                                runat="server"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="consulta" ID="rv4" ForeColor="Red"
                                            runat="server"
                                            ErrorMessage="Ingrese el número de comprobante"
                                            ControlToValidate="txtNumeroComprobante"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Número de CAE:</label>
                                            <asp:TextBox ID="txtCAE" CssClass="form-control" placeholder="Ingrese el Número de CAE"
                                                runat="server"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator Display="Dynamic"
                                            ValidationGroup="consulta" ID="rv5"
                                            ForeColor="Red"
                                            runat="server"
                                            ErrorMessage="Ingrese el Número de CAE"
                                            ControlToValidate="txtCAE"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Importe Total de la operación</label>
                                            <asp:TextBox ID="txtImporte" CssClass="form-control" Text="0"
                                                placeholder="Importe Total de la operación"
                                                runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegexDecimal"
                                                Display="Dynamic"
                                                runat="server"
                                                ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                                ErrorMessage="Ingrese un monto decimal"
                                                ValidationGroup="consulta"
                                                ForeColor="Red"
                                                ControlToValidate="txtImporte" />
                                        </div>
                                        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="consulta" ID="rv6" ForeColor="Red"
                                            runat="server"
                                            ErrorMessage="Importe Total de la operación"
                                            ControlToValidate="txtImporte"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Tipo de Comprobante:</label>
                                            <asp:DropDownList ID="DDLTipoComprobante" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="1" Text="1 - Factura A"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="2 - Nota de Débito A"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="3 - Nota de Crédito A"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="4 - Recibo A"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="5 - Nota de Venta al Contado A"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="6 - Factura B"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="7 - Nota de Débito B"></asp:ListItem>
                                                <asp:ListItem Value="8" Text="8 - Nota de Crédito B"></asp:ListItem>
                                                <asp:ListItem Value="9" Text="9 - Recibo B"></asp:ListItem>
                                                <asp:ListItem Value="10" Text="10 - Nota de Venta al Contado B"></asp:ListItem>
                                                <asp:ListItem Value="11" Text="11 - Factura C" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="12" Text="12 - Nota de Débito C"></asp:ListItem>
                                                <asp:ListItem Value="13" Text="13 - Nota de Crédito C"></asp:ListItem>
                                                <asp:ListItem Value="15" Text="15 - Recibo C"></asp:ListItem>
                                                <asp:ListItem Value="18" Text="18 - Liquidacion de Servicios Publicos Clase B"></asp:ListItem>
                                                <asp:ListItem Value="19" Text="19 - Factura de Exportación"></asp:ListItem>
                                                <asp:ListItem Value="20" Text="20 - Nota Déb. P/Operac. con el Exterior"></asp:ListItem>
                                                <asp:ListItem Value="21" Text="21 - Nota Créd. P/Operac. con el Exterior"></asp:ListItem>
                                                <asp:ListItem Value="39" Text="39 - Otros Comprobantes A que Cumplan con la R.G. Nro. 1415"></asp:ListItem>
                                                <asp:ListItem Value="40" Text="40 - Otros Comprobantes B que Cumplan con la R.G. Nro. 1415"></asp:ListItem>
                                                <asp:ListItem Value="49" Text="49 - Comprobante de Compra de Bienes Usados"></asp:ListItem>
                                                <asp:ListItem Value="51" Text="51 - Factura M"></asp:ListItem>
                                                <asp:ListItem Value="52" Text="52 - Nota de Débito M"></asp:ListItem>
                                                <asp:ListItem Value="53" Text="53 - Nota de Crédito M"></asp:ListItem>
                                                <asp:ListItem Value="54" Text="54 - Recibo M"></asp:ListItem>
                                                <asp:ListItem Value="60" Text="60 - Cta. de Vta. y Líquido Prod. A"></asp:ListItem>
                                                <asp:ListItem Value="61" Text="61 - Cta. de Vta. y Líquido Prod. B"></asp:ListItem>
                                                <asp:ListItem Value="63" Text="63 - Liquidación A"></asp:ListItem>
                                                <asp:ListItem Value="64" Text="64 - Liquidación B"></asp:ListItem>
                                                <asp:ListItem Value="81" Text="81 - TIQUE FACTURA A"></asp:ListItem>
                                                <asp:ListItem Value="82" Text="82 -	TIQUE FACTURA B"></asp:ListItem>
                                                <asp:ListItem Value="83" Text="83 -	TIQUE"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Adjuntar comprobante</label>
                                            <asp:FileUpload ID="fUploadFactu" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Detalle</label>
                                            <asp:TextBox ID="txtDetalleFactura" TextMode="MultiLine"
                                                CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label id="lblError2" style="color: red;" runat="server">
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer" style="text-align: right;">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                            <asp:LinkButton ID="btnConsulta" OnClick="btnConsulta_Click" ValidationGroup="consulta"
                                CssClass="btn btn-primary" runat="server"><span class="fa fa-check"></span>&nbsp;Aceptar</asp:LinkButton>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>

    </div>

    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>
    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvDeudas.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"
                    }
                }
            );
            $('#ContentPlaceHolder1_DDLMedioPago').change(
                function () {
                    $("#ContentPlaceHolder1_hIdMedioPago").val(this.value);
                    if (this.value == "2")
                        $("#divCheque").show('slow');
                    else
                        $("#divCheque").hide('slow');
                    // Do something with val1 and val2 ...
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
        function abrirAdelanto(ID, BARRIO, CALLE, CP, CUIT, ING_BRUTOS, LOCALIDAD, MAIL, NOMBRE_FANTASIA, NRO, RAZON_SOCIAL, TEL, WEB, COND_IVA, PAIS, PROVINCIA) {
            $('#modalProveedor').modal('show');
        }
    </script>
</asp:Content>
