<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Iva_Compras.aspx.cs" Inherits="LaHerradura.Iva_Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="box box-primary">
        <div class="box-header">
            <h3 class="box-title">Libro Iva Compras</h3>
        </div>
        <div class="box-body">
            <div class="col-md-3">
                <div class="form-group">
                    <label>Año</label>
                    <asp:DropDownList ID="DDLAnio"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="DDLAnio_SelectedIndexChanged"
                        CssClass="form-control"
                        runat="server">
                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                        <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                        <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                        <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label>Mes</label>
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
            <div class="col-md-3">
                <div class="form-group">
                    <label>Factura (<span id="lblFacturas" runat="server"></span>)</label>
                    <asp:TextBox ID="txtTotalFacturas" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label>Notas de Credito (<span id="lblNC" runat="server"></span>)</label>
                    <asp:TextBox ID="txtTotalNC" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12">
                <asp:GridView
                    ID="gvIvaVentas"
                    CssClass="table"
                    AutoGenerateColumns="false"
                    runat="server">
                    <Columns>
                        <asp:BoundField DataField="FECHA_CAE" DataFormatString="{0:d}" HeaderText="Fecha CAE"/>
                        <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Proveedor"/>
                        <asp:BoundField DataField="PTO_VTA" HeaderText="Pto. Venta"/>
                        <asp:BoundField DataField="NRO_CTE" HeaderText="N° Comprobante"/>
                        <asp:BoundField DataField="OBS" HeaderText="Detalle"/>
                        <asp:BoundField DataField="MONTO_ORIGINAL" DataFormatString="{0:c}" HeaderText="Monto"/>
                    </Columns>
                </asp:GridView>
            </div>

        </div>
        <div class="box-footer"></div>
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
            $('#' + '<%=gvIvaVentas.ClientID %>').DataTable(
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
