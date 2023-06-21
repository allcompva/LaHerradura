<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="InformeSaldos.aspx.cs" Inherits="LaHerradura.Back.InformeSaldos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" id="divListado" runat="server">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Resumen de Saldos</h3>
                    </div>
                    <div class="box-body">
                        <div class="col-md-12" style="margin-top: 15px;" id="div1" runat="server">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Fecha de Corte</label>
                                    <asp:TextBox ID="txtFechaCorte"
                                        TextMode="Date" CssClass="form-control"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4" style="padding-top:23px;">
                                <asp:Button ID="btnFechaCorte"
                                    CssClass="btn btn-primary"
                                    OnClick="btnFechaCorte_Click"
                                    runat="server" Text="Aplicar" />
                            </div>
                        </div>
                        <div class="col-md-12" style="margin-top: 15px;" id="divMayor" runat="server">
                            <asp:GridView ID="gvSaldos"
                                CssClass="table"
                                OnRowCommand="gvSaldos_RowCommand"
                                AutoGenerateColumns="false"
                                runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="NRO_CTA"
                                        HeaderText="Cuenta" />
                                    <asp:BoundField DataField="FACTURACION_EXPENSAS"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Facturacion" />
                                    <asp:BoundField DataField="PAGOS"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Pagos" />
                                    <asp:BoundField DataField="FACTURACION_INTERESES"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Intereses Facturados" />
                                    <asp:BoundField DataField="NOTAS_CREDITO"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Notas de Crédito" />
                                    <asp:BoundField DataField="INTERES_PLAN_PAGO"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Interes Planes de Pago" />
                                    <asp:BoundField DataField="FACTURAS_MANUALES"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Facturacion Externa" />
                                    <asp:BoundField DataField="NOTAS_DEBITO_INTERNA"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Notas de Débito Internas" />
                                    <asp:BoundField DataField="NOTAS_CREDITO_INTERNA"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Notas de Crédito Internas" />
                                    <asp:BoundField DataField="SALDO"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Saldo" />
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
                        <%--                        <div class="col-md-12" style="margin-top: 15px;" id="divDetalle"
                            runat="server" visible="false">
                            <asp:GridView ID="gvListaAsientos"
                                CssClass="table"
                                ShowFooter="true"
                                OnRowDataBound="gvListaAsientos_RowDataBound"
                                AutoGenerateColumns="false"
                                runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="_NRO" HeaderText="Nro." />
                                    <asp:BoundField DataField="_FECHA"
                                        HeaderText="Fecha" />
                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" />
                                    <asp:BoundField DataField="CUENTA" HeaderText="Cuenta" />
                                    <asp:BoundField DataField="DEBE"
                                        DataFormatString="{0:c}"
                                        HeaderText="Debe" />
                                    <asp:BoundField DataField="HABER"
                                        DataFormatString="{0:c}"
                                        HeaderText="Haber" />
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

                            <div class="col-md-12" style="padding-top: 20px; text-align: right">
                                <a href="LibroMayor.aspx" class="btn btn-success">Volver</a>
                            </div>
                        </div>--%>
                    </div>
                    <div class="box-footer"></div>
                </div>
            </div>
        </div>
    </div>

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
            $('#' + '<%=gvSaldos.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    ordering: false,
                    "lengthMenu": [[10, 25, 50], [10, 25, 50]],
                    "iDisplayLength": 10,
                    buttons: [
                        'excel', 'print'
                    ],
                    columnDefs: [{
                        targets: "_all",
                        sortable: false
                    }]
                }
            );

        });
    </script>
</asp:Content>
