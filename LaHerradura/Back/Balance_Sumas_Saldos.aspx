﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Balance_Sumas_Saldos.aspx.cs" Inherits="LaHerradura.Back.Balance_Sumas_Saldos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css" />
    <style>
        .table > thead > tr > th {
            border-bottom: 2px solid #f4f4f4 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="callout callout-danger" id="divError" runat="server">
            <h4>Error!</h4>
            <p id="lblError" runat="server">
            </p>
        </div>
        <div class="row" id="divListado" runat="server">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Balance de Sumas y Saldos</h3>
                    </div>
                    <div class="box-body">
                        <div class="col-md-3 hidden-print" style="margin-top: 15px;">
                            <div class="form-group">
                                <label>Ejercicio</label>
                                <asp:DropDownList ID="DDLEjercicio"
                                    CssClass="form-control"
                                    runat="server">
                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                    <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                    <asp:ListItem Text="2022" Value="2022" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                    <asp:ListItem Text="2024" Value="2024"></asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-top: 15px;">
                            <div class="form-group">
                                <label>Desde</label>
                                <asp:TextBox ID="txtFechaInicio"
                                    TextMode="Date"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-top: 15px;">
                            <div class="form-group">
                                <label>Hasta</label>
                                <asp:TextBox ID="txtFechaFin" CssClass="form-control"
                                    TextMode="Date"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 hidden-print" style="margin-top: 15px; padding-top: 23px;">
                            <asp:Button ID="btnFiltro" runat="server" Text="Aplicar"
                                OnClick="btnFiltro_Click"
                                CssClass="btn btn-primary" />
                        </div>
                        <div class="col-md-12" style="margin-top: 15px;">
                            <asp:GridView ID="gvBalance"
                                OnDataBound="gvBalance_DataBound"
                                ShowFooter="true"
                                OnRowDataBound="gvBalance_RowDataBound"
                                CssClass="table"
                                AutoGenerateColumns="false"
                                runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <tr class="gvHeader">
                                                <th style="width: 0px"></th>
                                                <th rowspan="2">CUENTA</th>
                                                <th rowspan="2">DESCRIPCION</th>
                                                <th colspan="2">SALDO ANTERIOR</th>
                                                <th colspan="2">SUMAS</th>
                                                <th colspan="2">SALDO</th>
                                            </tr>
                                            <tr class="gvHeader">
                                                <th></th>
                                                <th>DEBE</th>
                                                <th>HABER</th>
                                                <th>DEBE</th>
                                                <th>HABER</th>
                                                <th>DEBE</th>
                                                <th>HABER</th>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td><%# Eval("N5") %></td>
                                            <td><%# Eval("DESC_SUBCUENTA") %></td>
                                            <td style="white-space: nowrap"><%# Eval("SALDO_ANTERIOR_DEBE", "{0:C}") %></td>
                                            <td style="white-space: nowrap"><%# Eval("SALDO_ANTERIOR_HABER", "{0:C}")%></td>
                                            <td style="white-space: nowrap"><%# Eval("DEBE", "{0:C}")%></td>
                                            <td style="white-space: nowrap"><%# Eval("HABER", "{0:C}")%></td>
                                            <td style="white-space: nowrap"><%# Eval("SALDO_DEBE","{0:C}")%></td>
                                            <td style="white-space: nowrap"><%# Eval("SALDO_HABER","{0:C}")%></td>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <td></td>
                                            <td><strong>TOTALES</strong></td>
                                            <td style="white-space: nowrap"><strong id="lblSaldoAntDebe" runat="server"></strong></td>
                                            <td style="white-space: nowrap"><strong id="lblSaldoAntHaber" runat="server"></strong></td>
                                            <td style="white-space: nowrap"><strong id="lblSumaDebe" runat="server"></strong></td>
                                            <td style="white-space: nowrap"><strong id="lblSumaHaber" runat="server"></strong></td>
                                            <td style="white-space: nowrap"><strong id="lblSaldoDebe" runat="server"></strong></td>
                                            <td style="white-space: nowrap"><strong id="lblSaldoHaber" runat="server"></strong></td>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
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
            $('#' + '<%=gvBalance.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    columnDefs: [{
                        targets: "_all",
                        sortable: false
                    }],
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": -1,
                    buttons: [
                        'excel', 'print'
                    ]
                }
            );
        });
        // Code that uses other library's $ can follow here.
    </script>

</asp:Content>
