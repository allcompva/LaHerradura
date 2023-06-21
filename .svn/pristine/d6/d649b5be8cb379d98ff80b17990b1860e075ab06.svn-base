<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Caja.aspx.cs" Inherits="LaHerradura.Back.Caja" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        hr {
            margin-top: 20px;
            margin-bottom: 20px;
            border: 0;
            border-top: 1px solid #cecece;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hUsuario" runat="server" />
    <asp:HiddenField ID="hIdPlanilla" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hIngresosCaja" Value="0" runat="server" />
            <asp:HiddenField ID="hEgresosCaja" Value="0" runat="server" />
            <asp:HiddenField ID="hIngresosCajaCheque" Value="0" runat="server" />
            <asp:HiddenField ID="hEgresosCajaCheque" Value="0" runat="server" />
            <asp:HiddenField ID="hIngresosBanco" Value="0" runat="server" />
            <asp:HiddenField ID="hEgresosBanco" Value="0" runat="server" />
            <asp:HiddenField ID="hSaldoCajaEfvo" Value="0" runat="server" />
            <asp:HiddenField ID="hSaldoCajaCheque" Value="0" runat="server" />
            <asp:HiddenField ID="hSaldoBanco" Value="0" runat="server" />
            <div class="callout callout-danger" id="divError" runat="server">
                <h4 id="lblTitError" runat="server">No se ha encontrado una caja abierta</h4>
                <p id="lblMsjError" runat="server"></p>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h3>Planilla caja y banco
                        
                    </h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10">
                    <asp:TextBox ID="txtFecha" CssClass="form-control" runat="server"
                        OnTextChanged="txtFecha_TextChanged" AutoPostBack="true">
                    </asp:TextBox>
                </div>
                <div class="col-md-2">
                    <%--<input id="btnCerraCa" class="btn btn-warning btn-block"
                        runat="server"
                        type="button" value="Cerrar Caja" onclick="abrirModalMail()" />--%>
                </div>
            </div>
            <div class="row" style="margin-top: 30px;">
                <div class="col-md-4">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">Caja Efectivo</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <table class="table table-bordered">
                                <tbody>
                                    <tr>
                                        <td>Saldo Anterior</td>
                                        <td style="text-align: right;">
                                            <span id="spanSaldoAntCajaEfvo" runat="server"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Ingresos</td>
                                        <td style="text-align: right;">
                                            <span id="spanIngresosCajaEfvo" runat="server"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Egresos</td>
                                        <td style="text-align: right;">
                                            <span id="spanEgresosCajaEfvo" runat="server"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Subtotal</td>
                                        <td style="text-align: right;">
                                            <strong id="spanSubTotalCajaEfvo" runat="server"></strong></td>
                                    </tr>
                                    <tr>
                                        <td>Subtotal</td>
                                        <td style="text-align: right;">
                                            <strong id="spanSaldoCajaEfvo" runat="server"></strong></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">Caja Cheques</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <table class="table table-bordered">
                                <tbody>
                                    <tr>
                                        <td>Saldo Anterior</td>
                                        <td style="text-align: right;">
                                            <span id="spanSaldoAntCheque" runat="server"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Ingresos</td>
                                        <td style="text-align: right;">
                                            <span id="spanIngresosCajaCheque" runat="server"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Egresos</td>
                                        <td style="text-align: right;">
                                            <span id="spanEgresosCajaCheque" runat="server"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Subtotal</td>
                                        <td style="text-align: right;">
                                            <strong id="spanSubTotalCheque" runat="server"></strong></td>
                                    </tr>
                                    <tr>
                                        <td>Saldo</td>
                                        <td style="text-align: right;">
                                            <strong id="spanSaldoCheque" runat="server"></strong></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="box">
                        <div class="box-header with-border">
                            <h3 class="box-title">Banco</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <table class="table table-bordered">
                                <tbody>
                                    <tr>
                                        <td>Saldo Anterior</td>
                                        <td style="text-align: right;">
                                            <span id="spanSaldoAntBanco" runat="server"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Ingresos</td>
                                        <td style="text-align: right;">
                                            <span id="spanIngresosBanco" runat="server"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Egresos</td>
                                        <td style="text-align: right;">
                                            <span id="spanEgresosBanco" runat="server"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Subtotal</td>
                                        <td style="text-align: right;">
                                            <strong id="spanSubTotalBanco" runat="server"></strong></td>
                                    </tr>
                                    <tr>
                                        <td>Saldo</td>
                                        <td style="text-align: right;">
                                            <strong id="spanSaldoBanco" runat="server"></strong></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="box">
                        <div class="box-header">
                            <h3 class="box-title">Ingresos</h3>
                            <input id="Button1" class="btn btn-warning btn-block"
                                runat="server"
                                type="button" value="Cargar Movimiento" onclick="abrirModalMovimiento()" />
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body table-responsive">
                            <asp:GridView ID="gvIngresos"
                                CssClass="table"
                                AutoGenerateColumns="false"
                                OnRowCommand="gvIngresos_RowCommand"
                                OnRowDataBound="gvIngresos_RowDataBound"
                                runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="HORA" HeaderText="FECHA" />
                                    <asp:BoundField DataField="CUENTA" HeaderText="CUENTA" />
                                    <%--                                            <asp:BoundField DataField="CUENTA_EGRESO" HeaderText="CUENTA EGRESO" />--%>
                                    <asp:BoundField DataField="DETALLE" HeaderText="DETALLE" />
                                    <asp:BoundField DataField="MONTO" HeaderText="MONTO" DataFormatString="{0:C}" />
                                    <%--<asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEliminar" runat="server"
                                                        CommandName="eliminar"
                                                        CommandArgument='<%#Eval("id")%>'
                                                        OnClientClick="return confirm('¿Esta seguro de eliminar el ingreso?');">
                                                        <i class="fa fa-remove"></i>
                                                    </asp:LinkButton>                                    <asp:LinkButton ID="lbtnEditar" runat="server"
                                                        CommandName="editar"
                                                        CommandArgument='<%#Eval("id")%>'                                                        >
                                                        <i class="fa fa-edit"></i>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                </Columns>
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
                            </asp:GridView>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box">
                        <div class="box-header">
                            <h3 class="box-title">Egresos</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body table-responsive">
                            <asp:GridView ID="gvEgresos"
                                CssClass="table"
                                OnRowDataBound="gvEgresos_RowDataBound"
                                OnRowCommand="gvEgresos_RowCommand"
                                AutoGenerateColumns="false"
                                runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="HORA" HeaderText="FECHA" />
                                    <asp:BoundField DataField="CUENTA" HeaderText="CUENTA" />
                                    <%--<asp:BoundField DataField="CUENTA_EGRESO" HeaderText="CUENTA EGRESO" />
                                            <asp:BoundField DataField="USUARIO_CARGA" HeaderText="USUARIO" />
                                            <asp:BoundField DataField="RESPONSABLE" HeaderText="RESPONSABLE" />--%>
                                    <asp:BoundField DataField="DETALLE" HeaderText="DETALLE" />
                                    <asp:BoundField DataField="MONTO" HeaderText="MONTO" DataFormatString="{0:C}" />
                                    <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEliminar" runat="server"
                                                        CommandName="eliminar"
                                                        CommandArgument='<%#Eval("id")%>'
                                                        OnClientClick="return confirm('¿Esta seguro de eliminar el egreso?');">
                                                        <i class="fa fa-remove"></i>
                                                    </asp:LinkButton>
                                                                                                      <asp:LinkButton ID="lbtnEditar" runat="server"
                                                        CommandName="editar"
                                                        CommandArgument='<%#Eval("id")%>'                                                        >
                                                        <i class="fa fa-edit"></i>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                </Columns>
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
                            </asp:GridView>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
            </div>

            <div class="modal fade in" id="modalMovimiento">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                        </div>
                        <div class="modal-body">
                            <div class="box box-primary">
                                <div class="box-header">
                                    <h4 class="modal-title">Movimientos</h4>
                                </div>
                                <div class="box-body">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Fecha</label>
                                            <asp:TextBox ID="txtFechaMov"
                                                TextMode="Date"
                                                CssClass="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Monto</label>
                                            <asp:TextBox ID="txtMonto"
                                                CssClass="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Egresa de</label>
                                            <asp:DropDownList ID="DDLEgreso"
                                                CssClass="form-control"
                                                runat="server">
                                                <asp:ListItem Value="1" Text="Caja"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Banco"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Cheque"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Ingresa a</label>
                                            <asp:DropDownList ID="DDLIngreso"
                                                CssClass="form-control"
                                                runat="server">
                                                <asp:ListItem Value="1" Text="Caja"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Banco"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Cheque"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Obsevaciones</label>
                                            <asp:TextBox ID="txtDetalleMov" TextMode="MultiLine" CssClass="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="text-align: right;">
                                        <button type="button" class="btn btn-default"
                                            data-dismiss="modal">
                                            Cancelar</button>
                                        <asp:Button ID="btnAddMovimiento" runat="server" Text="Cerrar Caja"
                                            OnClientClick="return confirm('¿Esta seguro de cargar el movimiento?')"
                                            OnClick="btnAddMovimiento_Click"
                                            CssClass="btn btn-primary" />
                                    </div>
                                </div>
                                <div class="box-footer"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade in" id="modalMail">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                        </div>
                        <div class="modal-body">
                            <div class="box box-primary">
                                <div class="box-header">
                                    <h4 class="modal-title">Cierre de Caja</h4>
                                </div>
                                <div class="box-body">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Fecha</label>
                                            <asp:TextBox ID="txtFechaHora" CssClass="form-control"
                                                Enabled="false"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Usuario</label>
                                            <asp:TextBox ID="txtUsuario" CssClass="form-control"
                                                Enabled="false"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Saldo Caja Efvo.</label>
                                            <asp:TextBox ID="txtSaldoCajaEfvo" CssClass="form-control"
                                                Enabled="false"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Saldo Caja Cheques</label>
                                            <asp:TextBox ID="txtSaldoCajaCheque" CssClass="form-control"
                                                Enabled="false"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Saldo Banco</label>
                                            <asp:TextBox ID="txtSaldoBanco" CssClass="form-control"
                                                Enabled="false"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Obsevaciones</label>
                                            <asp:TextBox ID="txtObs" TextMode="MultiLine" CssClass="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="text-align: right;">
                                        <button type="button" class="btn btn-default"
                                            data-dismiss="modal">
                                            Cancelar</button>
                                        <asp:Button ID="btnCerrarCaja" runat="server" Text="Cerrar Caja"
                                            OnClientClick="return confirm('¿Esta seguro de cerrar la caja?')"
                                            OnClick="btnCerrarCaja_Click"
                                            CssClass="btn btn-primary" />
                                    </div>
                                </div>
                                <div class="box-footer"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        function abrirModalMail() {
            $('#modalMail').modal('show');
        }
        function abrirModalMovimiento() {
            $('#modalMovimiento').modal('show');
        }
    </script>

    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js?v=1"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.1/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.1/js/buttons.flash.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.1/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.1/js/buttons.print.min.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvEgresos.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": 10,
                    buttons: [
                        'excel', 'print'
                    ]
                }
            );

            $('#' + '<%=gvIngresos.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": 10,
                    buttons: [
                        'excel', 'print'
                    ],
                    "order": [[0, "desc"]]
                }
            );
        });
        // Code that uses other library's $ can follow here.
    </script>
</asp:Content>
