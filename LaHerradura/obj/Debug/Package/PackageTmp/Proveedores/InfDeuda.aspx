<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="InfDeuda.aspx.cs" Inherits="LaHerradura.Proveedores.InfDeuda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                            style="margin-top: 15px; margin-bottom: 15px;">Gastos a pagar</h2>
                    </div>
                    <div class="box-body" style="padding: 20px;">
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

                                <div class="nav-tabs-custom">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a href="#tab_2" data-toggle="tab">Resumen</a></li>
                                        <li>
                                            <a href="#tab_1" data-toggle="tab">Detalle
                                            </a>
                                        </li>
                                    </ul>

                                    <div class="tab-content">
                                        <div class="tab-pane" id="tab_1">
                                            <div class="box">
                                                <div class="box-header with-border">
                                                    <h3 class="box-title">Total adeudado:
                                            <strong id="lblDeuda" runat="server"></strong>
                                                        <strong>-</strong>
                                                        Cuentas con deuda: <strong id="lblCantCta" runat="server"></strong>
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
                                                        ForeColor="#333333"
                                                        GridLines="None">
                                                        <Columns>
                                                            <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Razón Social"/>
                                                            <asp:BoundField DataField="NOMBRE_FANTASIA" HeaderText="Nombre Fantasia"/>
                                                            <asp:BoundField DataField="FACTURA" HeaderText="Factura"/>
                                                            <asp:BoundField DataField="DETALLE_FACTURA" HeaderText="Concepto"/>
                                                            <asp:BoundField DataField="MONTO_ORIGINAL" DataFormatString="{0:c}" 
                                                                HeaderText="Monto"/>
                                                            <asp:BoundField DataField="PAGO" DataFormatString="{0:c}" 
                                                                HeaderText="Pago a cta."/>
                                                            <asp:BoundField DataField="Saldo" DataFormatString="{0:c}" 
                                                                HeaderText="SALDO"/>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <!-- /.box-body -->
                                                <div class="box-footer clearfix">
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.tab-pane -->
                                        <div class="tab-pane active" id="tab_2">
                                            <div class="box">
                                                <div class="box-header with-border">
                                                    <h3 class="box-title">Total adeudado:
                                            <strong id="lblDeudaPeriodo" runat="server"></strong>
                                                        <strong>-</strong>
                                                        Cuentas con deuda: <strong id="lblCantCtaPeriodo" runat="server"></strong>
                                                    </h3>
                                                </div>
                                                <!-- /.box-header -->
                                                <div class="box-body">
                                                    <asp:GridView
                                                        ID="gvResumen"
                                                        runat="server"
                                                        AutoGenerateColumns="false"
                                                        CellPadding="4"
                                                        CssClass="table"
                                                        OnRowDataBound="gvResumen_RowDataBound"
                                                        ForeColor="#333333"
                                                        GridLines="None">
                                                     <Columns>
                                                            <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Razón Social"/>
                                                            <asp:BoundField DataField="NOMBRE_FANTASIA" HeaderText="Nombre Fantasia"/>
                                                            <asp:BoundField DataField="MONTO_ORIGINAL" DataFormatString="{0:c}" 
                                                                HeaderText="Monto"/>
                                                            <asp:BoundField DataField="PAGO" DataFormatString="{0:c}" 
                                                                HeaderText="Pago a cta."/>
                                                            <asp:BoundField DataField="Saldo" DataFormatString="{0:c}" 
                                                                HeaderText="SALDO"/>
                                                     </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <!-- /.box-body -->
                                                <div class="box-footer clearfix">
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.tab-pane -->
                                    </div>
                                    <!-- /.tab-content -->
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="box-footer">
                    </div>
                </div>
                <!-- /.widget-user -->
            </div>
        </div>
        <!-- /.box -->
    </section>
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
        function verExport() {
            $("#ContentPlaceHolder1_gvTotExport").show("slow");
            $("#ContentPlaceHolder1_gvT").hide("slow");
            $("#aVerExport").hide("slow");
            $("#aVerPantalla").show("slow");
        }
        function verPantalla() {
            $("#ContentPlaceHolder1_gvTotExport").hide("slow");
            $("#ContentPlaceHolder1_gvT").show("slow");
            $("#aVerExport").show("slow");
            $("#aVerPantalla").hide("slow");
        }
    </script>
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
                    "iDisplayLength": -1,
                    buttons: [
                        'excel', 'print'
                    ]
                }
            );

            $('#' + '<%=gvResumen.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": -1,
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
