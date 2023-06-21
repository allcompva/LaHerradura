<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="LaHerradura.Back.Facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="box box-primary" id="div1" runat="server">
                    <div class="box-header">
                        <h3 class="box-title">Facturacion</h3>
                    </div>
                    <div class="alert alert-danger alert-dismissible" role="alert"
                        id="divError"
                        runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Error!</strong> <span id="txtError" runat="server"></span>
                    </div>
                    <div class="box-body" id="divListaFactura" runat="server" visible="true">
                        <asp:Button ID="btnAddFactura" runat="server" Text="Facturar"
                            Style="margin-bottom: 25px;"
                            OnClick="btnAddFactura_Click" CssClass="btn btn-primary pull-right" />
                        <asp:GridView ID="gvFacturas"
                            runat="server"
                            CellPadding="4"
                            CssClass="table"
                            AutoGenerateColumns="false"
                            OnRowDataBound="gvFacturas_RowDataBound"
                            ForeColor="#333333"
                            GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="Factura">
                                    <ItemTemplate>
                                        <span id="lblFactura" style="white-space: nowrap;" runat="server"></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FECHA_CAE" DataFormatString="{0:d}" HeaderText="Fecha" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Cliente" />
                                <asp:BoundField DataField="DETALLE" HeaderText="Detalle" />
                                <asp:BoundField DataField="MONTO" HeaderText="Monto" DataFormatString="{0:c}" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a target="_blank" href="Reportes/Factura.aspx?&ptoVta=<%#Eval("PTO_VTA")%>&nroCte=<%#Eval("NRO_CTE")%>&tipoCte=<%#Eval("TIPO_COMPROBANTE")%>">
                                            <span class="fa fa-download"></span>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
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
                    <div class="box-body" id="divAddFactura" runat="server" visible="false">
                        <asp:UpdatePanel UpdateMode="Conditional"
                            ID="uPanelTipo" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Punto de Venta</label>
                                            <asp:DropDownList ID="DDLPuntoVenta" CssClass="form-control" runat="server">
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Tipo de comprobante</label>
                                            <asp:DropDownList ID="DDLTipoComp"
                                                AutoPostBack="true"
                                                OnSelectedIndexChanged="DDLTipoComp_SelectedIndexChanged"
                                                CssClass="form-control" runat="server">
                                                <asp:ListItem Text="Factura C" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="Nota de Credito C" Value="13"></asp:ListItem>
                                                <asp:ListItem Text="Nota de Debito C" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Fecha</label>
                                            <asp:TextBox ID="txtFecha" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Tipo de comprobante</label>
                                            <asp:DropDownList ID="DDLConceptos"
                                                AutoPostBack="true"
                                                OnSelectedIndexChanged="DDLConceptos_SelectedIndexChanged"
                                                CssClass="form-control" runat="server">
                                                <asp:ListItem Text="Productos" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Productos y Servicios" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Servicios" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" id="divServicio"
                                    runat="server" visible="false">
                                    <div class="col-md-12">
                                        <div class="box box-info">
                                            <div class="box-header">
                                                <h3 class="box-title">Período Facturado</h3>
                                            </div>
                                            <div class="box-body">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>Desde</label>
                                                        <asp:TextBox ID="txtServiciosDesde"
                                                            TextMode="Date"
                                                            CssClass="form-control"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>Hasta</label>
                                                        <asp:TextBox ID="txtServiciosHasta"
                                                            TextMode="Date"
                                                            CssClass="form-control"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label>Vto. para el Pago</label>
                                                        <asp:TextBox ID="txtServiciosVenc"
                                                            TextMode="Date"
                                                            CssClass="form-control"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" id="divCompAsociado"
                                    runat="server" visible="false">
                                    <div class="col-md-12">
                                        <h3>Comprobante Asociado</h3>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Punto de Venta</label>
                                            <asp:TextBox ID="txtPtoVtaCompAsoc"
                                                CssClass="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Numero de Comprobante</label>
                                            <asp:TextBox ID="txtNroCompAsoc"
                                                CssClass="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Vincular a Cuenta</label>
                                            <asp:DropDownList ID="DDLVincular"
                                                AutoPostBack="true"
                                                OnSelectedIndexChanged="DDLVincular_SelectedIndexChanged"
                                                CssClass="form-control" runat="server">
                                                <asp:ListItem Text="Si" Value="si"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="no"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4" id="divCtas" runat="server">
                                        <div class="form-group">
                                            <div class="form-group">
                                                <label>Cuenta a vincular</label>
                                                <asp:DropDownList ID="DDLCuentas"
                                                    AutoPostBack="true"
                                                    OnSelectedIndexChanged="DDLCuentas_SelectedIndexChanged"
                                                    CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>CUIT</label>
                                            <asp:TextBox ID="txtNroDoc"
                                                TextMode="Number"
                                                CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Nombre / Razón Social</label>
                                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div id="divPlanCuentas" runat="server">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Cuenta Debe</label>
                                                <asp:DropDownList
                                                    ID="DDLDebe"
                                                    CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Cuenta Haber</label>
                                                <asp:DropDownList
                                                    ID="DDLHaber"
                                                    CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Descripción</label>
                                            <asp:TextBox ID="txtDescripcion"
                                                CssClass="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Monto</label>
                                            <asp:TextBox ID="txtTotal"
                                                CssClass="form-control"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="box-footer" style="text-align: right;">
                            <a href="Facturacion.aspx" class="btn btn-warning">Cancelar</a>
                            <asp:Button ID="btnSig1" CssClass="btn btn-primary"
                                OnClick="btnSig1_Click"
                                runat="server" Text="Facturar" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
