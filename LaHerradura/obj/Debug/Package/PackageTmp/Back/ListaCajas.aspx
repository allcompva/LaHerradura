<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="ListaCajas.aspx.cs" Inherits="LaHerradura.Back.ListaCajas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />

    <style>
        .table-bordered > thead > tr > th, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > tbody > tr > td, .table-bordered > tfoot > tr > td {
            border: 1px solid #bbbbbb;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Planillas de Caja y Banco</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table class="table table-bordered box box-primary"
                            id="tbCajas"
                            style="border-top: 3px solid #3c8dbc !important;">
                            <thead>
                                <tr>
                                    <th rowspan="2" style="vertical-align: middle; display:none;">Fecha</th>
                                    <th rowspan="2" style="vertical-align: middle;">Fecha</th>
                                    <th colspan="4" style="text-align: center;">Caja Efectivo</th>
                                    <th colspan="4" style="text-align: center;">Caja Cheques</th>
                                    <th colspan="4" style="text-align: center;">Banco</th>
                                </tr>
                                <tr>
                                    <th style="font-weight: 400;">Saldo Ant.</th>
                                    <th style="font-weight: 400;">Ingresos</th>
                                    <th style="font-weight: 400;">Egresos</th>
                                    <th>Saldo</th>
                                    <th style="font-weight: 400;">Saldo Ant.</th>
                                    <th style="font-weight: 400;">Ingresos</th>
                                    <th style="font-weight: 400;">Egresos</th>
                                    <th>Saldo</th>
                                    <th style="font-weight: 400;">Saldo Ant.</th>
                                    <th style="font-weight: 400;">Ingresos</th>
                                    <th style="font-weight: 400;">Egresos</th>
                                    <th>Saldo</th>
                                </tr>
                            </thead>
                            <tbody id="tbDatos" runat="server">
                            </tbody>
                        </table>
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer">
                    </div>
                    <!-- /.box-footer -->
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
            $('#tbCajas').DataTable(
                {
                    "order": [[0, "desc"]],
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"
                    },
                    dom: 'Bfrtip',
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print'
                    ]
                }
            );
        });
    </script>
</asp:Content>
