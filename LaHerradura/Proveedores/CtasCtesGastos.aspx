<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true"
    CodeBehind="CtasCtesGastos.aspx.cs" Inherits="LaHerradura.Proveedores.CtasCtesGastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css" />
    <style>
        .nav > li > a:hover, .nav > li > a:active, .nav > li > a:focus {
            color: #444;
            background: transparent;
        }
    </style>

    <style>
        label {
            padding-left: 5px;
            font-weight: 500;
        }

        .nav > li > a {
            position: relative;
            display: block;
            padding: 5px 10px;
        }
    </style>

    <style>
        .headerDerecha {
            text-align: right;
        }

        .checkbox .btn, .checkbox-inline .btn {
            padding-left: 3em;
            min-width: 8em;
        }

        .checkbox label, .checkbox-inline label {
            text-align: left;
            color: black;
            width: 100%;
            text-align: right;
        }

        .checkbox input[type="checkbox"] {
            float: none;
            margin-left: -80px;
        }

        td {
            display: table-cell;
            vertical-align: middle !important;
        }

        @media (max-width: 800px) {
            .ocultar {
                display: none;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hNroRecibo" runat="server" />
    <div class="container">
        <section class="content-header">
            <div class="row">
                <div class="col-md-12">
                    <div class="alert alert-danger alert-dismissible fade in" role="alert" id="divError"
                        runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
                        <h4>Error!</h4>
                        <p id="txtError" runat="server">
                        </p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-9">
                    <div class="input-group">
                    </div>
                    <!-- /input-group -->

                </div>
                <div class="col-xs-3">
                </div>
            </div>
        </section>
        <div class="box box-primary">
            <div class="box-header">
                <h3 class="box-title" id="lblProv" runat="server"></h3>
            </div>
            <div class="box-body">
                <div class="nav-tabs-custom">
                    <ul class="nav nav-tabs">
                        <li class="active">
                            <a href="#tab_1" data-toggle="tab">Cuenta corriente
                            </a>
                        </li>
                        <%--                        <li>
                            <a href="#tab_2" data-toggle="tab">Ordenes de pago
                            </a>
                        </li>--%>
                        <li>
                            <a href="#tab_3" data-toggle="tab">Anticipos
                            </a>
                        </li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="tab_1">
                            <section class="content">
                                <div class="outer_div">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="box">
                                                <div class="box-header with-border">
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="DDLFiltro"
                                                            AutoPostBack="true"
                                                            OnSelectedIndexChanged="DDLFiltro_SelectedIndexChanged"
                                                            CssClass="form-control" runat="server">
                                                            <asp:ListItem Text="Gastos a pagar" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Cuenta completa" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Movimento Cuenta" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-4"
                                                        style="padding: 6px; border: solid 1px lightgray;">
                                                        <strong>Sdo. a favor La Herradura 
                                            <span id="spanBilletera" runat="server"
                                                style="font-size: 14px;"
                                                class="pull-right badge bg-green"></span></strong>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <a href="CtaCteGastos1.aspx" class="btn btn-default pull-right">
                                                            <span class="fa fa-sign-out"></span>&nbsp;Volver
                                                        </a>
                                                    </div>
                                                </div>
                                                <!-- /.box-header -->
                                                <div class="box-body">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            <asp:GridView ID="gvProveedores"
                                                                CssClass="table"
                                                                runat="server"
                                                                ShowHeader="true"
                                                                OnRowCommand="gvProveedores_RowCommand"
                                                                OnRowDataBound="gvProveedores_RowDataBound"
                                                                CellPadding="4"
                                                                AutoGenerateColumns="False"
                                                                ForeColor="#333333"
                                                                GridLines="None">
                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                                                <Columns>
                                                                    <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                                                    <asp:BoundField DataField="FACTURA" HeaderText="Factura" />
                                                                    <asp:BoundField DataField="OBS" HeaderText="Detalle" />
                                                                    <asp:BoundField DataField="SALDO" HeaderText="Saldo" DataFormatString="{0:c}" />
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Height="40px" CssClass="headerDerecha" HorizontalAlign="Right" />
                                                                        <HeaderTemplate>
                                                                            <label style="text-align: right !important; font-weight: 700">
                                                                                TOTAL</label>
                                                                        </HeaderTemplate>
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <div id="divCheckPago" runat="server"
                                                                                class="form-group" style="padding-bottom: 0px; padding-top: 0px; margin-bottom: -10px; margin-top: -10px">
                                                                                <div class="checkbox">
                                                                                    <label class="btn" id="btnChk" runat="server">
                                                                                        <asp:CheckBox ID="chkSelect"
                                                                                            runat="server"
                                                                                            AutoPostBack="true"
                                                                                            TextAlign="left"
                                                                                            Style="margin-left: 10px; padding-bottom: 0px; padding-top: 0px; margin-bottom: 0px; margin-top: 0px;"
                                                                                            OnCheckedChanged="chkSelect_CheckedChanged"
                                                                                            Text='<%# Eval("SALDO") %>' />
                                                                                    </label>
                                                                                </div>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnEliminar"
                                                                                CommandName="eliminar"
                                                                                OnClientClick="return confirm('¿esta seguro de eliminar el comprobante?')"
                                                                                CommandArgument='<%# Eval("ID") %>'
                                                                                runat="server">
                                                        <span class="fa fa-remove" style="color:red;"></span></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
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
                                                            <div style="display: none;">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4" id="divOrdenPago" runat="server"
                                                            visible="false">
                                                            <div class="box box-primary">
                                                                <div class="box-header">
                                                                    <h3 class="box-title">Orden de Pago</h3>
                                                                </div>
                                                                <div class="box-body">
                                                                    <ul class="nav nav-stacked">
                                                                        <li><a href="#">Facturas Seleccionadas
                                                                                <span class="pull-right badge" id="lblCantFacturas"
                                                                                    runat="server"></span></a></li>
                                                                        <li><a href="#">Monto 
                                                                                <span class="pull-right" id="lblMonto"
                                                                                    runat="server"></span></a></li>
                                                                    </ul>
                                                                </div>
                                                                <div class="box-footer" style="text-align: right;">
                                                                    <button type="button" class="btn btn-primary"
                                                                        data-toggle="modal"
                                                                        data-target="#modalOrdenPago">
                                                                        Generar Orden de Pago
                                                                    </button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <asp:GridView ID="gvCtaTotal"
                                                                CssClass="table table-hover"
                                                                AutoGenerateColumns="false"
                                                                ShowHeader="true"
                                                                GridLines="None"
                                                                OnRowDataBound="gvCtaTotal_RowDataBound"
                                                                OnRowCommand="gvCtaTotal_RowCommand"
                                                                runat="server">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Movimiento">
                                                                        <ItemTemplate>
                                                                            <div id="lblCta" runat="server"></div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                                                            </asp:GridView>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <asp:GridView ID="gvMovCta"
                                                                CssClass="table table-hover"
                                                                AutoGenerateColumns="false"
                                                                ShowHeader="true"
                                                                GridLines="None"
                                                                runat="server">
                                                                <Columns>
                                                                    <asp:BoundField DataField="ID_PROVEEDOR" HeaderText="Id"/>
                                                                    <asp:BoundField DataField="NOMBRE_FANTASIA" HeaderText="Nombre Fantasia"/>
                                                                    <asp:BoundField DataField="RAZON_SOCIAL" HeaderText="Razón Social"/>
                                                                    <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:d}"/>
                                                                    <asp:BoundField DataField="TIPO_MOVIMIENTO" HeaderText="Movimiento"/>
                                                                    <asp:BoundField DataField="FACTURA" HeaderText="Factura"/>
                                                                    <asp:BoundField DataField="RECIBO_PAGO" HeaderText="Recibo"/>
                                                                    <asp:BoundField DataField="DEBE" HeaderText="Debe" DataFormatString="{0:c}"/>
                                                                    <asp:BoundField DataField="HABER" HeaderText="Haber" DataFormatString="{0:c}"/>
                                                                </Columns>
                                                                <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div class="row" id="divAsiento" runat="server" visible="false">
                                                        <div class="col-md-4 col-md-offset-8"
                                                            style="padding-right: 30px;">
                                                            <div class="box">
                                                                <div class="box-header">
                                                                </div>
                                                                <!-- /.box-header -->
                                                                <div class="box-body no-padding">
                                                                    <table class="table table-condensed">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <div style="font-weight: 700; font-size: 14pt; color: gray;">
                                                                                        Saldo:
                                                                                        <span class="pull-right">$</span>
                                                                                    </div>
                                                                                </td>
                                                                                <td style="text-align: right;">
                                                                                    <asp:Label ID="lblDeudaPagar"
                                                                                        Font-Bold="true" Font-Size="14"
                                                                                        ForeColor="GrayText" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <!-- /.box-body -->
                                                            </div>

                                                            <asp:Label ID="lblCantSelecionados" Font-Bold="true" Font-Size="8"
                                                                ForeColor="GrayText" runat="server" Text=""></asp:Label>
                                                            <asp:Label ID="Label3" Font-Bold="true" Font-Size="8"
                                                                ForeColor="GrayText" runat="server" Text="Periodo(s) Seleccionado(s)">
                                                            </asp:Label>

                                                            <asp:Label ID="lblMensaje" ForeColor="Red" runat="server" Text="">

                                                            </asp:Label>
                                                            <br />
                                                            <%--<a href="#" onclick="abrirAcentarPago()"
                                                                class="btn btn-primary pull-right">Acentar Pago</a>--%>
                                                            <button type="button"
                                                                class="btn btn-primary pull-right"
                                                                id="btnAcentarPago" runat="server"
                                                                onserverclick="btnAcentarPago_ServerClick">
                                                                <span class="fa fa-money"></span>&nbsp;Acentar Pago
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.box-body -->
                                                <div class="box-footer clearfix">
                                                </div>

                                            </div>
                                            <!-- /.box -->
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->


                                </div>
                                <!-- Datos ajax Final -->
                            </section>
                            <div class="modal modal-danger fade in" id="modalAnulaComprobante">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">×</span></button>
                                            <h4 class="modal-title">Anular Comprobante</h4>
                                        </div>
                                        <div class="modal-body">
                                            <h3>¿Esta seguro de anular el comprobante?</h3>
                                            <div class="form-group">
                                                <label>Observaciones</label>
                                                <asp:TextBox ID="txtObsAnulaComprobante"
                                                    CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                                            <asp:Button ID="btnAceptarCancelaDeuda" CssClass="btn btn-outline"
                                                OnClick="btnAceptarCancelaDeuda_Click" runat="server" Text="Aceptar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal modal-primary fade in" id="modalOrdenPago">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">×</span></button>
                                            <h4 class="modal-title">Generar Orden de Pago</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>Fecha</label>
                                                        <asp:TextBox ID="txtFecha"
                                                            CssClass="form-control"
                                                            TextMode="Date"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>Total</label>
                                                        <asp:TextBox ID="txtTotal"
                                                            CssClass="form-control"
                                                            Enabled="false"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label>Detalle</label>
                                                        <asp:GridView ID="gvConfirmoPago"
                                                            CssClass="table"
                                                            runat="server"
                                                            ShowHeader="true"
                                                            CellPadding="4"
                                                            AutoGenerateColumns="False"
                                                            ForeColor="#333333"
                                                            GridLines="None">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                                            <Columns>
                                                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                                                <asp:BoundField DataField="FACTURA" HeaderText="Factura" />
                                                                <asp:BoundField DataField="OBS" HeaderText="Detalle" />
                                                                <asp:BoundField DataField="SALDO" HeaderText="Saldo" />
                                                            </Columns>
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
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                                            <asp:Button ID="btnAceptarOrdenPago" CssClass="btn btn-outline"
                                                OnClick="btnAceptarOrdenPago_Click" runat="server" Text="Aceptar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal modal-primary fade in" id="modalAutorizaOrdenPago">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">×</span></button>
                                            <h4 class="modal-title">Autorizar Orden de Pago</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>Autoriza</label>
                                                        <asp:DropDownList ID="DDLUsuario"
                                                            CssClass="form-control"
                                                            runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label>Contraseña</label>
                                                        <asp:TextBox ID="txtPass"
                                                            TextMode="Password"
                                                            CssClass="form-control"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--                        <div class="tab-pane" id="tab_2">
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
                        </div>--%>
                        <div class="tab-pane" id="tab_3">
                            <asp:GridView
                                ID="gvAdelantos"
                                runat="server"
                                CellPadding="4"
                                ForeColor="#333333"
                                OnRowCommand="gvAdelantos_RowCommand"
                                OnRowDataBound="gvAdelantos_RowDataBound"
                                CssClass="table"
                                AutoGenerateColumns="false"
                                GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="NRO_RECIBO_ADELANTO" HeaderText="N° Recibo" />
                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Medio de Pago" />
                                    <asp:BoundField DataField="MONTO" HeaderText="Monto" DataFormatString="{0:c}" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete"
                                                CommandName="eliminar"
                                                OnClientClick="return confirm('¿Esta seguro de eliminar el adelanto?');"
                                                CommandArgument='<%#Eval("ID")%>'
                                                runat="server">
                                                <span class="fa fa-remove" style="color:red;"></span>    
                                            </asp:LinkButton>&nbsp;
                                            <a target="_blank"
                                                href="../Back/Reportes/AdelantoProveedor.aspx?nroAdelanto=<%#Eval("ID")%>&idProv=<%#Eval("ID_PROVEEDOR")%>">
                                                <span class="fa fa-search"></span>
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
                        </div>
                    </div>
                    <!-- /.tab-content -->
                </div>
            </div>
            <div class="box-footer"></div>
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
            $('#' + '<%=gvAdelantos.ClientID %>').DataTable(
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
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvMovCta.ClientID %>').DataTable(
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
                    "ordering": false
                }
            );
        });
        function abrirAnulaComprobante(nro_recibo) {
            $('#modalAnulaComprobante').modal('show');
            $("#ContentPlaceHolder1_hNroRecibo").val(nro_recibo);
        }
    </script>
</asp:Content>
