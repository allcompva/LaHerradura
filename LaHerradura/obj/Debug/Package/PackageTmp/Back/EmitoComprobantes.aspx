<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="EmitoComprobantes.aspx.cs" Inherits="LaHerradura.Back.EmitoComprobantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hIdCta" runat="server" />
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <!-- Widget: user widget style 1 -->
                <div class="box box-widget widget-user-2">
                    <!-- Add the bg color to the header using any of the bg-* classes -->
                    <div class="widget-user-header bg-aqua-active">
                        <div class="widget-user-image">
                            <img class="img-circle" src="../App_Themes/img/expensas.png" />
                        </div>
                        <!-- /.widget-user-image -->
                        <h2 class="widget-user-username"
                            style="margin-top: 15px; margin-bottom: 15px;">Emisión de Notas de Credito</h2>
                    </div>
                    <div class="box-body" style="padding: 20px;">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Año</label>
                                    <asp:DropDownList ID="DDLAnio"
                                        CssClass="form-control"
                                        OnSelectedIndexChanged="DDLAnio_SelectedIndexChanged"
                                        AutoPostBack="true"
                                        runat="server">
                                        <asp:ListItem Value="2021" Text="2021"></asp:ListItem>
                                        <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Mes</label>
                                    <asp:DropDownList ID="DDLMes"
                                        CssClass="form-control"
                                        OnSelectedIndexChanged="DDLMes_SelectedIndexChanged"
                                        AutoPostBack="true"
                                        runat="server">
                                        <asp:ListItem Value="01" Text="Enero" Selected></asp:ListItem>
                                        <asp:ListItem Value="02" Text="Febrero"></asp:ListItem>
                                        <asp:ListItem Value="03" Text="Marzo"></asp:ListItem>
                                        <asp:ListItem Value="04" Text="Abril"></asp:ListItem>
                                        <asp:ListItem Value="05" Text="Mayo"></asp:ListItem>
                                        <asp:ListItem Value="06" Text="Junio"></asp:ListItem>
                                        <asp:ListItem Value="07" Text="Julio"></asp:ListItem>
                                        <asp:ListItem Value="08" Text="Agosto"></asp:ListItem>
                                        <asp:ListItem Value="09" Text="Septiembre"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="Octubre"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="Noviembre"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="Diciembre"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Todos"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <a href="#" class="btn btn-default"
                                        onclick="abrirModalAddComprobante('')">
                                        <span
                                            class="fa fa-download">&nbsp;Emitir Notas de Crédito</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="box">
                            <div class="box-header with-border">
                                <h3 class="box-title">Total Cobrado:
                                                        <strong id="lblDeuda" runat="server"></strong>
                                    <strong>-</strong>
                                    Cuentas Cobradas: <strong id="lblCantCta" runat="server"></strong>
                                </h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <asp:GridView
                                    ID="gvCtas"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CellPadding="4"
                                    CssClass="table"
                                    OnRowDataBound="gvCtas_RowDataBound"
                                    OnRowCommand="gvCtas_RowCommand"
                                    ForeColor="#333333"
                                    GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="NRO_CTA" HeaderText="Cuenta" />
                                        <asp:BoundField DataField="NRO_RECIBO_PAGO" HeaderText="N° Recibo" />
                                        <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="MONTO_ORIGINAL" ItemStyle-Wrap="false" DataFormatString="{0:c}"
                                            ItemStyle-HorizontalAlign="Right" HeaderText="Monto Facturado" />
                                        <asp:BoundField DataField="DESC_VENCIMIENTO" ItemStyle-Wrap="false" DataFormatString="{0:c}"
                                            ItemStyle-HorizontalAlign="Right" HeaderText="Descuento" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a target="_blank" href="Reportes/Recibo.aspx?nroRecibo=<%#Eval("NRO_RECIBO_PAGO")%>">
                                                    <span class="fa fa-search"></span>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a href="#"
                                                    onclick="abrirModalAddComprobante('<%#Eval("ID")%>')">
                                                    <span style="font-size: 20px;"
                                                        class="fa fa-download"></span>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <!-- /.box-body -->
                            <div class="box-footer clearfix">
                            </div>
                        </div>

                    </div>
                    <div class="box-footer">
                    </div>
                </div>
                <!-- /.widget-user -->
            </div>
        </div>
        <!-- /.box -->
    </section>

    <div class="modal fade in" id="modal-default">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Emitir Notas de Credito</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Fecha Notas de Credito</label>
                        <asp:TextBox ID="txtFecha" TextMode="Date"
                            CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnEmitirNC" CssClass="btn btn-primary"
                        runat="server" Text="Aceptar" OnClick="btnEmitirNC_Click" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.content -->
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
            $('#' + '<%=gvCtas.ClientID %>').DataTable(
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
                    "order": [[0, "asc"]]
                }
            );
        });
        // Code that uses other library's $ can follow here.

        function abrirModalAddComprobante(ID) {
            $('#modal-default').modal('show');
            //PERIODO
            $("#ContentPlaceHolder1_hIdCta").val(ID);
        }
    </script>
</asp:Content>
