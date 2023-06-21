<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="DetalleLiquidacion.aspx.cs" Inherits="LaHerradura.Back.DetalleLiquidacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <!--Load the AJAX API-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">

        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawStacked);

        function drawStacked() {
            // Create the data table.
            $.ajax({
                type: "POST",
                url: "DetalleLiquidacion.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var chartdata = new google.visualization.DataTable();
                    chartdata.addColumn('string', 'Periodos');
                    chartdata.addColumn('number', 'Adeudado');
                    chartdata.addColumn('number', 'Cobrado');
                    chartdata.addRows(r.d);

                    var options = {
                        bar: { groupWidth: '75%' },
                        isStacked: true,
                        colors: ['#e0440e', '#4caf50'],
                        title: 'Resumen Cobranza de Expensas ',
                        subtitle: 'Ejercicio 2020',

                    };
                    // Instantiate and draw our chart, passing in some options.
                    var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
                    chart.draw(chartdata, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }

        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChartConceptos);

        function drawChartConceptos() {
            var id = $("#ContentPlaceHolder1_hPeriodo").val();
            // Create the data table.
            $.ajax({
                type: "POST",
                url: "DetalleLiquidacion.aspx/GetChartDataConceptos",
                data: "{ periodo:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var chartdata = new google.visualization.DataTable();
                    chartdata.addColumn('string', 'Concepto');
                    chartdata.addColumn('number', 'cantidad');
                    chartdata.addRows(r.d);

                    var options = {
                        title: 'Resumen Conceptos',
                        subtitle: 'Ejercicio 2020',
                    };

                    var chart = new google.visualization.PieChart(document.getElementById('piechartConceptos'));
                    chart.draw(chartdata, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChartConceptosSinExpensa);
        function drawChartConceptosSinExpensa() {
            var id = $("#ContentPlaceHolder1_hPeriodo").val();
            // Create the data table.
            $.ajax({
                type: "POST",
                url: "DetalleLiquidacion.aspx/GetChartDataConceptosSinExpensa",
                data: "{ periodo:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var chartdata = new google.visualization.DataTable();
                    chartdata.addColumn('string', 'Concepto');
                    chartdata.addColumn('number', 'cantidad');
                    chartdata.addRows(r.d);

                    var options = {
                        title: 'Resumen Conceptos (Sin expensa ordinaria)'
                    };

                    var chart = new google.visualization.PieChart(document.getElementById('piechartConceptosSinExpensa'));
                    chart.draw(chartdata, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChartMediosPago);
        function drawChartMediosPago() {
            var id = $("#ContentPlaceHolder1_hPeriodo").val();
            // Create the data table.
            $.ajax({
                type: "POST",
                url: "DetalleLiquidacion.aspx/drawChartMediosPago",
                data: "{ periodo:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var chartdata = new google.visualization.DataTable();
                    chartdata.addColumn('string', 'Concepto');
                    chartdata.addColumn('number', 'cantidad');
                    chartdata.addRows(r.d);

                    var options = {
                        title: 'Resumen Medios de Pago'
                    };

                    var chart = new google.visualization.PieChart(document.getElementById('piechartMediosPago'));
                    chart.draw(chartdata, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
        google.charts.load('current', { 'packages': ['bar'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            // Create the data table.
            var id = $("#ContentPlaceHolder1_hPeriodo").val();
            $.ajax({
                type: "POST",
                url: "DetalleLiquidacion.aspx/GetChartDataVencimientos",
                data: "{ periodo:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var chartdata = new google.visualization.DataTable();
                    chartdata.addColumn('string', 'Cuentas');
                    chartdata.addColumn('number', 'Cantidad de cuentas');
                    chartdata.addRows(r.d);

                    var options = {
                        chart: {
                            title: 'Company Performance',
                            subtitle: 'Sales, Expenses, and Profit: 2014-2017',
                        }
                    };
                    // Instantiate and draw our chart, passing in some options.
                    var chart = new google.visualization.ColumnChart(document.getElementById('divVencimientos'));
                    chart.draw(chartdata, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hPeriodo" runat="server" />
    <div class="modal-content">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">×</span></button>
            <div class="box box-widget widget-user-2">
                <div class="widget-user-header bg-aqua-active">
                    <div class="widget-user-image">
                        <img class="img-circle" src="../App_Themes/img/expensas.png" />
                    </div>
                    <!-- /.widget-user-image -->
                    <h2 class="widget-user-username" id="lblPeriodo" runat="server"></h2>
                    <h4 class="widget-user-desc" id="lblEstado" runat="server"></h4>
                </div>
            </div>
        </div>
        <div class="modal-body">
            <div class="row">
                <div class="col-md-12" id="divErrorEx" runat="server">
                    <div class="alert alert-danger alert-dismissible"
                        role="alert">
                        <strong>Error!</strong>
                        <p id="msgError" runat="server" style="color: white;"></p>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
            </div>
            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#tab_2" data-toggle="tab">Detalle</a></li>
                    <li><a href="#tab_1" data-toggle="tab">Resumen</a></li>
                    <li class="pull-right">
                        <a href="expensas.aspx" class="btn btn-success">
                            <span class="fa fa-sign-out">&nbsp; Salir</span>
                        </a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane" id="tab_1">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="box box-warning">
                                    <div class="box-header">
                                        <h3 class="box-title">Resumen Liquidación</h3>
                                    </div>
                                    <div class="box-body">
                                        <asp:GridView ID="gvResumen1"
                                            AutoGenerateColumns="false"
                                            GridLines="None"
                                            ShowHeader="false"
                                            CssClass="table" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="DETALLE" HeaderText="" />
                                                <asp:BoundField DataField="CANTCTAS" HeaderText="" />
                                                <asp:BoundField DataFormatString="{0:c}" DataField="TOTAL" HeaderText="" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="box box-info">
                                    <div class="box-header">
                                        <h3 class="box-title">Resumen Conceptos</h3>
                                    </div>
                                    <div class="box-body">
                                        <asp:GridView ID="gvResumen"
                                            GridLines="None"
                                            OnRowDataBound="gvResumen_RowDataBound"
                                            AutoGenerateColumns="false"
                                            CssClass="table table-hover"
                                            runat="server">
                                            <Columns>
                                                <asp:BoundField HeaderText="Concepto" DataField="DETALLE" />
                                                <asp:BoundField HeaderText="Cant." DataField="CANTCTAS" />
                                                <asp:BoundField HeaderText="Monto" DataFormatString="{0:c}" DataField="TOTAL" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="box box-info">
                                    <div class="box-header">
                                        <h3 class="box-title">Detalle Conceptos</h3>
                                    </div>
                                    <div class="box-body">
                                        <asp:GridView ID="gvDetalleConceptos"
                                            GridLines="None"
                                            OnRowDataBound="geDetalleConceptos_RowDataBound"
                                            AutoGenerateColumns="false"
                                            CssClass="table table-hover"
                                            runat="server">
                                            <Columns>
                                                <asp:BoundField HeaderText="Cuenta" DataField="NRO_CTA" />
                                                <asp:BoundField HeaderText="Concepto" DataField="DESCRIPCION" />
                                                <asp:BoundField HeaderText="Cantidad" DataField="CANT" />
                                                <asp:BoundField HeaderText="Costo" DataFormatString="{0:c}" 
                                                    DataField="COSTO" />
                                                <asp:BoundField HeaderText="Total" DataFormatString="{0:c}" 
                                                    DataField="TOTAL" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="chart_div"></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="divVencimientos"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechartConceptos"></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechartConceptosSinExpensa"></div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechartMediosPago"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.tab-pane -->
                    <div class="tab-pane active" id="tab_2">
                        <div class="box box-info">
                            <div class="box-header">
                                <h3 class="box-title">Resumen Liquidación</h3>
                            </div>
                            <div class="box-body">
                                <asp:GridView ID="gvCuentas"
                                    GridLines="None"
                                    CssClass="table table-hover"
                                    OnRowDataBound="gvCuentas_RowDataBound"
                                    AutoGenerateColumns="false"
                                    runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="NRO_CTA" HeaderText="Nro. Cuenta" ControlStyle-Width="5%"
                                            HeaderStyle-Width="5%" />
                                        <asp:TemplateField HeaderText="Nro. Factura">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFact" runat="server" Text=""></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="MONTO_ORIGINAL" DataFormatString="{0:c}" HeaderText="Monto Original" />
                                        <asp:BoundField DataField="DESC_VENCIMIENTO" DataFormatString="{0:c}" HeaderText="Desc. Pago en termino" />
                                        <asp:BoundField DataField="INTERES_MORA" DataFormatString="{0:c}" HeaderText="Interes mora" />
                                        <asp:BoundField DataField="DEBE" DataFormatString="{0:c}" HeaderText="Debe" />
                                        <asp:BoundField DataField="HABER" DataFormatString="{0:c}" HeaderText="Haber" />
                                        <asp:BoundField DataField="SALDO" DataFormatString="{0:c}" HeaderText="Saldo" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div id="divAnchorRecibo" runat="server">
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#00A7D0" ForeColor="White" />
                                </asp:GridView>
                            </div>
                            <div class="box-footer"></div>
                        </div>
                    </div>
                </div>
                <!-- /.tab-content -->
            </div>
        </div>





        <div class="modal-footer" style="text-align: right;">
        </div>
    </div>

    <!-- /.content -->
    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js"></script>

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
            $('#' + '<%=gvCuentas.ClientID %>').DataTable(
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
                    "order": [[0, "asc"]]
                }
            );
        });
        // Code that uses other library's $ can follow here.
    </script>
</asp:Content>
