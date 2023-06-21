<%@ Page Title="" Language="C#" EnableEventValidation="false"
    MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Asientos.aspx.cs" Inherits="LaHerradura.Back.Asientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css" />
    <style>
        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            border-top: none;
        }

        @media print {
            .hidden-print {
                display: none !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:HiddenField ID="hCantRegistros" runat="server" />
        <div class="row" id="divListado" runat="server">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Libro diario</h3>
                    </div>
                    <div class="box-body">
                        <div class="col-md-12 hidden-print" style="display: block;">
                            <asp:Button ID="btnAsientoExpensas"
                                CssClass="btn btn-info"
                                OnClick="btnAsientoExpensas_Click"
                                runat="server" Text="Asiento Liquidacion Expensas" />
                            <asp:Button ID="btnAsientoPagoExpensas"
                                CssClass="btn btn-info"
                                OnClick="btnAsientoPagoExpensas_Click"
                                runat="server" Text="Asiento Pago Expensas" />
                            <asp:Button ID="btnAsientoPagoProveedor"
                                CssClass="btn btn-info"
                                OnClick="btnAsientoPagoProveedor_Click"
                                runat="server" Text="Asiento Pago Proveedores" />
                            <asp:Button ID="btnAsientoProveedor"
                                CssClass="btn btn-info"
                                OnClick="btnAsientoProveedor_Click"
                                runat="server" Text="Asiento Proveedores" />
                            <asp:Button ID="btnAsientoNotaCredito"
                                CssClass="btn btn-info"
                                OnClick="btnAsientoNotaCredito_Click"
                                runat="server" Text="Asiento Notas de Credito" />
                            <asp:Button ID="btnAddAsiento"
                                CssClass="btn btn-primary pull-right"
                                OnClick="btnAddAsiento_Click"
                                runat="server" Text="Crear Asiento" />
                            <button class="btn btn-default pull-right" onclick="window.print()">
                                <span class="fa fa-print">&nbsp;Imprimir</span>
                            </button>
                        </div>
                        <div class="col-md-3 hidden-print" style="margin-top: 15px;">
                            <div class="form-group">
                                <label>Periodo</label>
                                <asp:DropDownList ID="DDLPeriodo"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="DDLPeriodo_SelectedIndexChanged"
                                    CssClass="form-control"
                                    runat="server">
                                    <asp:ListItem Text="Este mes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Hoy" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Todo el año" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Personalizado" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-top: 15px;">
                            <div class="form-group">
                                <label>Desde</label>
                                <asp:TextBox ID="txtFechaInicio"
                                    TextMode="Date"
                                    CssClass="form-control"
                                    Enabled="false"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-top: 15px;">
                            <div class="form-group">
                                <label>Hasta</label>
                                <asp:TextBox ID="txtFechaFin" CssClass="form-control"
                                    TextMode="Date"
                                    Enabled="false"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 hidden-print" style="margin-top: 15px; padding-top: 23px;">
                            <asp:Button ID="btnFiltro" runat="server" Text="Aplicar" Visible="false"
                                OnClick="btnFiltro_Click"
                                CssClass="btn btn-primary" />
                        </div>
                        <div class="col-md-12" style="margin-top: 15px;">
                            <asp:GridView ID="gvListaAsientos"
                                OnDataBound="gvListaAsientos_DataBound"
                                OnRowDataBound="gvListaAsientos_RowDataBound"
                                OnRowCommand="gvListaAsientos_RowCommand"
                                CssClass="table"
                                AutoGenerateColumns="false"
                                runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="NRO" HeaderText="Nro." />
                                    <asp:BoundField DataField="_FECHA"
                                        HeaderText="Fecha" />
                                    <asp:BoundField DataField="CUENTA" HeaderText="Cuenta" />
                                    <asp:BoundField DataField="DEBE"
                                        DataFormatString="{0:c}"
                                        ItemStyle-Wrap="false"
                                        HeaderText="Debe" />
                                    <asp:BoundField DataField="HABER"
                                        ItemStyle-Wrap="false"
                                        DataFormatString="{0:c}"
                                        HeaderText="Haber" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEliminar" 
                                                CommandArgument='<%#Eval("ID")%>'
                                                CommandName="eliminar"
                                                OnClientClick="return confirm('¿Esta seguro de eliminar el asiento?')"
                                                runat="server">
                                                <span class="fa fa-remove" style="font-size:18px; color:red;"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="box-footer"></div>
                </div>
            </div>
        </div>
        <div id="divAddAsiento" runat="server" visible="false">
            <div class="alert alert-danger alert-dismissible" 
                id="divErrorAsiento" runat="server" visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                <h4><i class="icon fa fa-ban"></i>Error!</h4>
                <p id="lblErrorAsiento" runat="server"></p>
            </div>
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="modal-title">Agregar Asiento</h3>
                    </div>
                    <div class="box-body">
                        <div class="row" style="margin-top: 15px;">
                            <div class="col-md-3">
                                <label>Fecha</label>
                                <asp:TextBox ID="txtFecha"
                                    CssClass="form-control"
                                    TextMode="Date"
                                    runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-9">
                                <label>Descripción</label>
                                <asp:TextBox ID="txtDetalle"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Cuenta Contable</label>
                                <asp:DropDownList ID="DDLCuentas"
                                    CssClass="form-control"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <label>Debe / Haber</label>
                                <asp:DropDownList ID="DDLDebeHaber" CssClass="form-control" 
                                    runat="server">
                                    <asp:ListItem Text="Debe" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Haber" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <label>Monto</label>
                                <asp:TextBox ID="txtHaber"
                                    TextMode="Number"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:LinkButton ID="btnAddCuenta"
                                    OnClick="btnAddCuenta_Click"
                                    Style="margin-top: 23px;" runat="server"
                                    CssClass="btn btn-success btn-block">
                                    <span class="fa fa-check" style="font-size:20px;"></span>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-md-12">
                                <asp:GridView ID="gvAddAsiento"
                                    CssClass="table"
                                    OnDataBound="gvAddAsiento_DataBound"
                                    AutoGenerateColumns="false"
                                    OnRowDataBound="gvAddAsiento_RowDataBound"
                                    OnRowCommand="gvAddAsiento_RowCommand"
                                    DataKeyNames="ID_CUENTA, DEBE, HABER, NOMBRE_CUENTA, DESCRIPCION"
                                    runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="NOMBRE_CUENTA" HeaderText="Cuenta" />                                        
                                        <asp:BoundField DataField="DEBE"
                                            DataFormatString="{0:c}"
                                            HeaderText="Debe" />
                                        <asp:BoundField DataField="HABER"
                                            DataFormatString="{0:c}"
                                            HeaderText="Haber" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEliminar"
                                                    CommandArgument='<%# Container.DataItemIndex %>'
                                                    CommandName="eliminar"
                                                    runat="server">
                                                    <span class="fa fa-remove" style="font-size:18px; color:red;"></span>
                                                </asp:LinkButton>
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
                        </div>
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-md-6" style="margin-top: 30px; text-align: right;">
                                <strong style="padding-top: 18px;">Total:</strong>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Debe</label>
                                    <asp:TextBox ID="txtTotalDebe"
                                        Enabled="false"
                                        CssClass="form-control"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Haber</label>
                                    <asp:TextBox ID="txtTotalHaber"
                                        Enabled="false"
                                        CssClass="form-control"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-footer" style="text-align: right;">
                        <asp:Button ID="btnCancelAdd"
                            CssClass="btn btn-warning"
                            OnClick="btnCancelAdd_Click"
                            runat="server" Text="Cancelar" />
                        <asp:Button ID="btnAceptarAdd"
                            OnClick="btnAceptarAdd_Click"
                            CssClass="btn btn-primary"
                            runat="server" Text="Aceptar" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

</asp:Content>
