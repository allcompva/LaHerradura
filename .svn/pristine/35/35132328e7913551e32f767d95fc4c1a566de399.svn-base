<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="AutorizarOPago.aspx.cs" Inherits="LaHerradura.Proveedores.AutorizarOPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .nav > li > a:hover, .nav > li > a:active, .nav > li > a:focus {
            color: #444;
            background: transparent;
        }

        /*thead {
            display: none;
        }*/
    </style>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hIdOp" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">ORDENES DE PAGO</h3>
                    </div>
                    <div class="box-body">
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tab_1" data-toggle="tab">Para Autorizar</a></li>
                                <li><a href="#tab_2" data-toggle="tab">Autorizadas</a></li>
                                <li><a href="#tab_3" data-toggle="tab">Pagadas</a></li>
                                <li><a href="#tab_4" data-toggle="tab">Con pago a cuenta</a></li>
                                <li><a href="#tab_5" data-toggle="tab">Anuladas</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane active" id="tab_1">
                                    <asp:GridView ID="gvParaAutorizar"
                                        OnRowDataBound="gvParaAutorizar_RowDataBound"
                                        CssClass="table"
                                        AutoGenerateColumns="false"
                                        runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div id="divDetalle" runat="server">
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="tab_2">
                                    <asp:GridView ID="gvAutorizadas"
                                        OnRowDataBound="gvAutorizadas_RowDataBound"
                                        CssClass="table"
                                        AutoGenerateColumns="false"
                                        runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div id="divDetalle" runat="server">
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="tab_3">
                                    <asp:UpdatePanel ID="UpdatePanel1"
                                        UpdateMode="Conditional"
                                        runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnPagadas"
                                                CssClass="btn btn-success"
                                                OnClick="btnPagadas_Click"
                                                Visible="false"
                                                runat="server" Text="Cargar Ordenes" />
                                            <div class="row" style="padding-top: 20px; margin: 0; margin-bottom: 50px; border: solid 1px lightgray; background-color: lightseagreen;">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label style="color: white;">Ver</label>
                                                        <asp:DropDownList ID="DDLFiltroFecha"
                                                            AutoPostBack="true"
                                                            OnSelectedIndexChanged="DDLFiltroFecha_SelectedIndexChanged"
                                                            CssClass="form-control"
                                                            runat="server">
                                                            <asp:ListItem Text="Todas" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Filtrar por Mes" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" id="divAnio" runat="server" visible="false">
                                                        <label style="color: white;">Año</label>
                                                        <asp:DropDownList ID="DDLAnio"
                                                            AutoPostBack="true"
                                                            OnSelectedIndexChanged="DDLAnio_SelectedIndexChanged"
                                                            CssClass="form-control"
                                                            runat="server">
                                                            <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                            <asp:ListItem Text="2021" Selected="True" Value="2021"></asp:ListItem>
                                                            <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                            <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                                            <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                                            <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group" id="divMes" runat="server" visible="false">
                                                        <label style="color: white;">Mes</label>
                                                        <asp:DropDownList ID="DDLMes"
                                                            AutoPostBack="true"
                                                            OnSelectedIndexChanged="DDLMes_SelectedIndexChanged"
                                                            CssClass="form-control"
                                                            runat="server">
                                                            <asp:ListItem Text="Enero" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Febrero" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Marzo" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Abril" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Mayo" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Junio" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Julio" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="Agosto" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Septiembre" Value="9"></asp:ListItem>
                                                            <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                                                            <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                                                            <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <asp:GridView ID="gvPagados"
                                                CssClass="table"
                                                ShowHeader="true"
                                                AutoGenerateColumns="false"
                                                runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="EJERCICIO" HeaderText="Ejercicio" />
                                                    <asp:BoundField DataField="ORDEN_PEDIDO" HeaderText="Orden Pedido" />
                                                    <asp:BoundField DataField="FECHA_ORDEN" HeaderText="Fecha" DataFormatString="{0:d}"/>
                                                    <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Proveedor" />
                                                    <asp:BoundField DataField="MONTO_ORIGINAL" DataFormatString="{0:c}" HeaderText="Monto Original" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a target="_blank" href="../Back/Reportes/ordenPago.aspx?nroOP=<%#Eval("ID_OP")%>">
                                                                <span class="fa fa-download" style="font-size:18px;"></span>
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="tab_4">
                                    <asp:GridView ID="gvACta"
                                        OnRowDataBound="gvACta_RowDataBound"
                                        CssClass="table"
                                        AutoGenerateColumns="false"
                                        runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div id="divDetalle" runat="server">
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="tab_5">
                                    <asp:GridView ID="gvAnuladas"
                                        OnRowDataBound="gvAnuladas_RowDataBound"
                                        CssClass="table"
                                        AutoGenerateColumns="false"
                                        runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div id="divDetalle" runat="server">
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                <!-- /.tab-pane -->
                            </div>
                            <!-- /.tab-content -->
                        </div>
                    </div>
                    <div class="box-footer"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade in" id="modalAutorizar">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Autorización Orden de Pago</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <p>
                            Esta seguro de autorizar la orden de pago número <strong id="lblNro"></strong>por un total
                            de <strong>$</strong> <strong id="lblTotal"></strong>a nombre de <strong id="lblProv"></strong>
                        </p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnAutorizar" CssClass="btn btn-primary"
                        OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                        OnClick="btnAutorizar_Click" runat="server" Text="Autorizar" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalAnular">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Anular Orden de Pago</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <p>
                            Esta seguro de <strong style="color: red">ANULAR</strong> la orden de pago número <strong id="lblNroAnula"></strong>por un total
                            de <strong>$</strong> <strong id="lblTotalAnula"></strong>a nombre de 
                            <strong id="lblProvAnula"></strong>
                        </p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnAnular" CssClass="btn btn-primary"
                        OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                        OnClick="btnAnular_Click" runat="server" Text="Anular" />
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
    <script src="../App_Themes/stacktable.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvPagados.ClientID %>').DataTable(
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
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        $('#' + '<%=gvPagados.ClientID %>').DataTable(
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
                    }
                });
            };
        });



        function abrirAuorizar(ID_OP, NRO_OP, PROVEEDOR, MONTO) {
            $('#modalAutorizar').modal('show');
            $("#ContentPlaceHolder1_hIdOp").val(ID_OP);
            $("#lblNro").text(NRO_OP);
            $("#lblTotal").text(MONTO);
            $("#lblProv").text(PROVEEDOR);
        }
        function abrirAnular(ID_OP, NRO_OP, PROVEEDOR, MONTO) {
            $('#modalAnular').modal('show');
            $("#ContentPlaceHolder1_hIdOp").val(ID_OP);
            $("#lblNroAnula").text(NRO_OP);
            $("#lblTotalAnula").text(MONTO);
            $("#lblProvAnula").text(PROVEEDOR);
        }

    </script>

</asp:Content>
