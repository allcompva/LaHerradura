<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="InformePagoProveedores.aspx.cs" Inherits="LaHerradura.Back.InformePagoProveedores" %>

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
                            style="margin-top: 15px; margin-bottom: 15px;">Informe Pago Proveedores</h2>
                    </div>
                    <div class="box-body" style="padding: 20px;">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active">
                                    <a href="#tab_1" data-toggle="tab"></a>
                                </li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane active" id="tab_1">
                                    <div class="box">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">
                                                <strong id="lblDeuda" runat="server"></strong>
                                                <strong>-</strong>
                                                <strong id="lblCantCta" runat="server"></strong>
                                            </h3>
                                        </div>

                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <div class="row" style="padding-top: 20px; margin: 0; border: solid 1px lightgray; background-color: lightseagreen;">
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label style="color: white;">Ejercicio</label>
                                                        <asp:DropDownList ID="DDLAnio"
                                                            AutoPostBack="true"
                                                            OnSelectedIndexChanged="DDLAnio_SelectedIndexChanged"
                                                            CssClass="form-control"
                                                            runat="server">
                                                            <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                            <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                            <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                            <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                                            <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                                            <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
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

                                                <div class="col-md-2">
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
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label style="color: white;">Medio de Pago</label>
                                                        <asp:DropDownList ID="DDLFiltro"
                                                            AutoPostBack="true"
                                                            OnSelectedIndexChanged="DDLFiltro_SelectedIndexChanged"
                                                            CssClass="form-control"
                                                            runat="server">
                                                            <asp:ListItem Text="TODOS"></asp:ListItem>
                                                            <asp:ListItem Text="EFECTIVO ADMINISTRACION" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="CHEQUE" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="TRANSFERENCIA BANCARIA" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="DEBITO AUTOMATICO" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="ANTICIPO PROVEEDORES" Value="9"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 20px; margin: 0">
                                                <div class="col-md-12" style="text-align: right;">
                                                    <div class="form-group">
                                                        <label>Total</label>
                                                        <asp:TextBox ID="txtTotal" Enabled="false"
                                                            CssClass="form-control"
                                                            Font-Bold="true"
                                                            Style="text-align: right;"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <asp:GridView
                                                        ID="gvFacturas"
                                                        runat="server"
                                                        AutoGenerateColumns="false"
                                                        CellPadding="4"
                                                        CssClass="table"
                                                        OnRowDataBound="gvFacturas_RowDataBound"
                                                        ForeColor="#333333"
                                                        GridLines="None">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Wrap="false">
                                                                <ItemTemplate>
                                                                    <div id="divFecha" runat="server"
                                                                        style="display: none;">
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:d}" />
                                                            <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Razon Social" />
                                                            <asp:BoundField DataField="NOMBRE_FANTASIA" HeaderText="Nombre Fantasia" />
                                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="Forma de Pago" />
                                                            <asp:BoundField DataField="MONTO" HeaderText="Monto Pagado" DataFormatString="{0:c}" ItemStyle-Wrap="false" />
                                                        </Columns>

                                                    </asp:GridView>
                                                </div>
                                            </div>

                                        </div>
                                        <!-- /.box-body -->
                                        <div class="box-footer clearfix">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.tab-content -->
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
    <script src="../js/moment.js"></script>
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
            var buttonCommon = {
                exportOptions: {
                    columns: function (column, data, node) {
                        if (column == 0) {
                            return false;
                        }
                        return true;
                    },
                }
            };

            $('#' + '<%=gvFacturas.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    buttons: [
                        $.extend(true, {}, buttonCommon, {
                            extend: 'excelHtml5'
                        }),
                        $.extend(true, {}, buttonCommon, {
                            extend: 'pdfHtml5'
                        })
                    ]
                }
            );
        });
        // Code that uses other library's $ can follow here.
    </script>
</asp:Content>
