﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true"
    CodeBehind="expensas.aspx.cs" Inherits="LaHerradura.Back.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main content -->
    <asp:HiddenField ID="hPeriodo" runat="server" />
    <asp:HiddenField ID="hAccion" runat="server" />

    <asp:HiddenField ID="hVenc1" runat="server" />
    <asp:HiddenField ID="hVenc2" runat="server" />
    <asp:HiddenField ID="hVenc3" runat="server" />

    <asp:HiddenField ID="hMonto1" runat="server" />
    <asp:HiddenField ID="hMonto2" runat="server" />
    <asp:HiddenField ID="hMonto3" runat="server" />

    <asp:HiddenField ID="hAlicuota" runat="server" />
    <asp:HiddenField ID="hIdServicio" runat="server" />

    <asp:HiddenField ID="hPeriodoModal" runat="server" />

    <asp:HiddenField ID="hPeriodoElimina" runat="server" />
    <asp:HiddenField ID="hConceptoElimina" runat="server" />

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
                        <h2 class="widget-user-username" style="margin-top: 15px; margin-bottom: 15px;">Expensas</h2>
                    </div>
                    <div class="box-footer">
                        <div class="alert alert-danger alert-dismissible" role="alert"
                            id="divError"
                            runat="server" visible="false">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong>Error!</strong> <span id="txtError" runat="server"></span>
                        </div>
                        <div id="divAcciones" runat="server">
                            <a class="btn btn-app btn-linkedin pull-right"
                                onclick="abrirModalAdd();">
                                <i class="fa fa-plus-square"></i>Nueva Liquidacion
                            </a>
                            <a class="btn btn-app btn-bitbucket pull-right"
                                onclick="abrirModalBanelco();">
                                <i class="fa fa-bank"></i>Cobranzas Banelco
                            </a>
                            <a class="btn btn-app btn-bitbucket pull-right"
                                onclick="abrirModalRapiPago();">
                                <i class="fa fa-bank"></i>Cobranzas Rapi Pago
                            </a>
                            <a class="btn btn-app btn-bitbucket pull-right"
                                onclick="abrirModalMacro1();">
                                <i class="fa fa-bank"></i>Cobranzas Debitos Macro
                            </a>
                        </div>
                        <h3>Listado de liquidaciones</h3>

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
                        <div id="divLiquidaciones" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <hr />
                                </div>
                            </div>
                            <asp:GridView
                                ID="gvLiquidaciones"
                                runat="server"
                                CellPadding="4"
                                ForeColor="#333333"
                                OnRowDataBound="gvLiquidaciones_RowDataBound"
                                OnRowCommand="gvLiquidaciones_RowCommand"
                                EmptyDataText="No se encontraron liquidaciones de expensas"
                                AutoGenerateColumns="false"
                                CssClass="table table-hover"
                                GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="Periodo">
                                        <ItemTemplate>
                                            <div id="btnVerDet" runat="server">
                                                <a href="#" onclick="verDetalle('<%#Eval("PERIODO")%>')">
                                                    <span class="fa fa-plus-circle" id="<%#Eval("PERIODO")%>"
                                                        style="color: #5D7B9D; font-weight: bold; font-size: 24px;"
                                                        orderid="<%#Eval("PERIODO")%>"></span></a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Periodo">
                                        <ItemTemplate>
                                            <span id="periodo" runat="server"></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="1° Vencimiento"
                                        DataField="venc1_corto" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField HeaderText="Monto" ItemStyle-Wrap="false"
                                        DataField="monto_1" DataFormatString="{0:c}" />
                                    <asp:BoundField HeaderText="2° Vencimiento"
                                        DataField="venc2_corto" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField HeaderText="Monto" ItemStyle-Wrap="false"
                                        DataField="monto_2" DataFormatString="{0:c}" />
                                    <asp:BoundField HeaderText="3° Vencimiento"
                                        DataField="venc3_corto" DataFormatString="{0:dd-MM-yyyy}" />
                                    <asp:BoundField HeaderText="Monto" ItemStyle-Wrap="false"
                                        DataField="monto_3" DataFormatString="{0:c}" />
                                    <asp:BoundField HeaderText="Ctas. Liquidadas"
                                        DataField="CANT_CTAS_CTES" />
                                    <asp:BoundField HeaderText="Tot. Liquidado"
                                        DataField="TOTAL_LIQUIDADO" DataFormatString="{0:c}" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="btn-group">
                                                <button type="button" class="btn btn-info dropdown-toggle"
                                                    data-toggle="dropdown">
                                                    <span class="fa fa-bars"></span>
                                                </button>
                                                <ul class="dropdown-menu" id="ulBotonesEstudio" runat="server">                                                  
                                                    <li id="Li4" runat="server">
                                                        <a href="DetalleLiquidacion.aspx?periodo=<%#Eval("PERIODO")%>">
                                                            <span style="font-size: 20px;" class="fa fa-bars"></span>
                                                            Detalle
                                                        </a>
                                                    </li>                                                                                                                                               
                                                </ul>
                                                <ul class="dropdown-menu" id="ulBotonesAdmin" runat="server">
                                                    <li id="btnVer" runat="server">
                                                        <a href="#" style="display: none"
                                                            onclick="abrirModal('<%#Eval("PERIODO")%>','<%#Eval("venc1_corto")%>', 
                                                            '<%#Eval("MONTO_1")%>','<%#Eval("venc2_corto")%>','<%#Eval("MONTO_2")%>', 
                                                            '<%#Eval("venc3_corto")%>','<%#Eval("MONTO_3")%>','<%#Eval("ALICUOTA_INTERES")%>', 
                                                            '<%#Eval("CANT_CTAS_CTES")%>','<%#Eval("TOTAL_LIQUIDADO")%>','<%#Eval("USUARIO_GENERA")%>', 
                                                            '<%#Eval("FECHA_GENERA")%>','<%#Eval("USUARIO_LIQUIDA")%>','<%#Eval("FECHA_LIQUIDA")%>', 
                                                            '<%#Eval("USUARIO_FACTURA")%>','<%#Eval("FECHA_FACTURA")%>','<%#Eval("ESTADO")%>')">
                                                            <span style="font-size: 20px;" class="fa fa-search"></span>
                                                            Ver
                                                        </a>
                                                    </li>
                                                    <li id="Li1" runat="server">
                                                        <a href="#"
                                                            onclick="abrirModalNota('<%#Eval("PERIODO")%>','<%#Eval("NOTA_FACTURA")%>')">
                                                            <span style="font-size: 20px;" class="fa fa-edit"></span>
                                                            Nota Facturas
                                                        </a>
                                                    </li>
                                                    <li id="btnDetalle" runat="server">
                                                        <a href="DetalleLiquidacion.aspx?periodo=<%#Eval("PERIODO")%>">
                                                            <span style="font-size: 20px;" class="fa fa-bars"></span>
                                                            Detalle
                                                        </a>
                                                    </li>
                                                    <li id="btnEditar" runat="server">
                                                        <a href="#"
                                                            onclick="abrirModalEdit('<%#Eval("PERIODO")%>','<%#Eval("venc1_corto")%>', 
                                                            '<%#Eval("MONTO_1")%>','<%#Eval("venc2_corto")%>','<%#Eval("MONTO_2")%>', 
                                                            '<%#Eval("venc3_corto")%>','<%#Eval("MONTO_3")%>','<%#Eval("ALICUOTA_INTERES")%>')">
                                                            <span style="font-size: 20px;" class="fa fa-edit"></span>
                                                            Editar
                                                        </a>
                                                    </li>
                                                    <li id="btnCargarConcepto" runat="server">
                                                        <a href="#"
                                                            onclick="abrirModalAddServicio(<%#Eval("PERIODO")%>)">
                                                            <i class="fa fa-plus" style="font-size: 20px;"></i>&nbsp; Cargar Concepto masivo
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="btnLiquidar"
                                                            CommandArgument='<%#Eval("PERIODO")%>'
                                                            runat="server"
                                                            OnClientClick="this.disabled=true;this.value = 'Procesando...'"
                                                            UseSubmitBehavior="false"
                                                            CommandName="liquidar">
                                            <span class="fa fa-money" style="font-size:20px;"></span>Liquidar
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="btnBorrar"
                                                            CommandArgument='<%#Eval("PERIODO")%>'
                                                            runat="server"
                                                            OnClientClick="return confirm('Esta seguro de eliminar la liquidación')"
                                                            CommandName="borrar">
                                            <span class="fa fa-trash" style="font-size:20px;"></span>Eliminar
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <div id="divFactura" runat="server">
                                                            <a href="#"
                                                                onclick="abrirModalFacturacion('<%#Eval("PERIODO")%>')">
                                                                <span style="font-size: 20px;" class="fa fa-money"></span>
                                                                Facturar
                                                            </a>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="btnEnviarMail"
                                                            CommandArgument='<%#Eval("PERIODO")%>'
                                                            runat="server"
                                                            OnClientClick="return confirm('¿Esta seguro de realizar el envio masivo de facturas de expensas?');"
                                                            CommandName="enviarMail">
                                            <span class="fa fa-envelope" style="font-size:20px;"></span>Enviar Mail
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="btnBorrarDetalle"
                                                            CommandArgument='<%#Eval("PERIODO")%>'
                                                            runat="server"
                                                            OnClientClick="return confirm('Esta seguro de eliminar el detalle de liquidación')"
                                                            CommandName="borrarDetalle">
                                            <span class="fa fa-trash" style="font-size:20px;"></span>Deshacer Liquidación
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="btnBanelco"
                                                            CommandArgument='<%#Eval("PERIODO")%>'
                                                            CommandName="banelco"
                                                            runat="server">
                                                            <span class="fa fa-bank" style="font-size:20px;"></span>Archivo Banelco
                                                        </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <a href="#"
                                                            onclick="abrirModalMacro('<%#Eval("PERIODO")%>')">
                                                            <span style="font-size: 20px;" class="fa fa-edit"></span>
                                                            Banco Macro
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton
                                                            ID="btnCodBarra"
                                                            Visible="true"
                                                            CommandArgument='<%#Eval("PERIODO")%>'
                                                            runat="server"
                                                            CommandName="codBarra">
                                            <span class="fa fa-envelope" style="font-size:20px;"></span>Rapipago
                                                        </asp:LinkButton>
                                                    </li>
                                                    <%--<li>
                                                        <asp:LinkButton
                                                            ID="btnEnviarMailnoEnviados"
                                                            CommandArgument='<%#Eval("PERIODO")%>'
                                                            runat="server"
                                                            OnClientClick="return confirm('¿Esta seguro de realizar el envio masivo de facturas de expensas?');"
                                                            CommandName="enviarMailnoEnviados">
                                                            <span class="fa fa-envelope" style="font-size:20px;"></span>Enviar Mail no Enviados
                                                        </asp:LinkButton>
                                                    </li>--%>
                                                </ul>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <tr style="display: none; background-color: white;" orderid="<%#Eval("PERIODO")%>">
                                                <td colspan="100%">
                                                    <div style="position: relative; left: 25px;">
                                                        <asp:GridView ID="gvDetails"
                                                            CssClass="table table-responsive"
                                                            Style="width: 90%; border: 1px solid #d0d0d0;"
                                                            GridLines="Horizontal"
                                                            ShowFooter="true"
                                                            DataKeyNames="PERIODO, ID_CONCEPTO"
                                                            OnRowDataBound="gvDetails_RowDataBound"
                                                            OnRowCommand="gvDetails_RowCommand"
                                                            AutoGenerateColumns="false"
                                                            runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="CANT" HeaderText="Cant." ControlStyle-Width="10%" />
                                                                <asp:BoundField DataField="DESC_CONCEPTO" HeaderText="Concepto" />
                                                                <asp:BoundField DataField="OBS" HeaderText="Observaciones" />
                                                                <asp:BoundField DataField="CANT_CTAS" HeaderText="Ctas. Excluidas" />
                                                                <asp:BoundField DataField="MONTO" HeaderText="Pre. Unit."
                                                                    DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                                                                    HeaderStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField DataField="SUBTOTAL" HeaderText="Sub Total"
                                                                    DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                                                                    HeaderStyle-HorizontalAlign="Right" />
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <div id="btnEliminar" runat="server">
                                                                            <a href="#"
                                                                                onclick="abrirModalElimina('<%#Eval("PERIODO")%>','<%#Eval("ID_CONCEPTO")%>','<%#Eval("DESC_CONCEPTO")%>')">
                                                                                <span style="font-size: 20px; color: red"
                                                                                    class="fa fa-trash"></span>
                                                                            </a>
                                                                            &nbsp;
                                                                        <a href="ExcluyeConcepto.aspx?idConcepto=<%#Eval("ID_CONCEPTO")%>&periodo=<%#Eval("PERIODO")%>">
                                                                            <span style="font-size: 20px;"
                                                                                class="fa fa-users"></span>
                                                                        </a>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
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
                        <div id="divBanelco" runat="server" visible="false">
                            <div class="row">
                                <div class="col-md-12">
                                    <hr />
                                </div>
                                <div class="col-md-1">
                                    <p style="color: #d4edda; background-color: #d4edda; border-color: #c3e6cb;">.</p>
                                </div>
                                <div class="col-md-2">
                                    <p>Comp. Listo para procesar</p>
                                </div>
                                <div class="col-md-1">
                                    <p style="color: #fff3cd; background-color: #fff3cd; border-color: #ffeeba;">.</p>
                                </div>
                                <div class="col-md-2">
                                    <p>Comp. Pagado</p>
                                </div>
                                <div class="col-md-1">
                                    <p style="color: #f8d7da; background-color: #f8d7da; border-color: #f5c6cb;">.</p>
                                </div>
                                <div class="col-md-2">
                                    <p>Comp. No encontrado</p>
                                </div>
                                <div class="col-md-12">
                                    <hr />
                                </div>
                            </div>
                            <asp:GridView
                                ID="gvBanelco"
                                CssClass="table table-bordered"
                                AutoGenerateColumns="false"
                                OnRowDataBound="gvBanelco_RowDataBound"
                                runat="server">
                                <Columns>
                                    <asp:BoundField DataField="NroReferencia" HeaderText="N° Cuenta" />
                                    <asp:BoundField DataField="IdFactura" HeaderText="Factura" />
                                    <asp:BoundField DataField="FechVencimiento" HeaderText="Vencimiento" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="FechaAplicacion" HeaderText="Fecha Cobro" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:c}" />
                                    <asp:BoundField DataField="FechaAcreditacion" HeaderText="Fecha Acreditacion" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="NroControl" HeaderText="Ticket (Banelco)" />
                                    <asp:TemplateField HeaderText="Canal Pago">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCanalPago" runat="server" Text="Label"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div runat="server" id="aConsulta">
                                                <a href="inmueble.aspx?nrocta=<%#Eval("NroReferencia")%>" target="_blank">
                                                    <span class="fa fa-search"></span>
                                                </a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="btnAceptarBanelco" CssClass="btn btn-primary pull-right" runat="server"
                                OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                                OnClick="btnAceptarBanelco_Click" Text="Aceptar" />
                            <asp:Button ID="btnCancelarBanelco" runat="server" Text="Cancelar" CssClass="btn btn-warning pull-right"
                                OnClick="btnCancelarBanelco_Click" />
                        </div>
                        <div id="divMacro" runat="server" visible="false">
                            <div class="row">
                                <div class="col-md-12">
                                    <hr />
                                </div>
                                <div class="col-md-1">
                                    <p style="color: #d4edda; background-color: #d4edda; border-color: #c3e6cb;">.</p>
                                </div>
                                <div class="col-md-2">
                                    <p>Comp. Listo para procesar</p>
                                </div>
                                <div class="col-md-1">
                                    <p style="color: #fff3cd; background-color: #fff3cd; border-color: #ffeeba;">.</p>
                                </div>
                                <div class="col-md-2">
                                    <p>Comp. Pagado</p>
                                </div>
                                <div class="col-md-1">
                                    <p style="color: #f8d7da; background-color: #f8d7da; border-color: #f5c6cb;">.</p>
                                </div>
                                <div class="col-md-2">
                                    <p>Comp. No encontrado</p>
                                </div>
                                <div class="col-md-12">
                                    <hr />
                                </div>
                            </div>
                            <asp:GridView
                                ID="gvMacro"
                                CssClass="table table-bordered"
                                AutoGenerateColumns="false"
                                OnRowDataBound="gvMacro_RowDataBound"
                                runat="server">
                                <Columns>
                                    <asp:BoundField DataField="NRO_CTA" HeaderText="N° Cuenta" />
                                    <asp:TemplateField HeaderText="Banco">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBanco"
                                                runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Caja de ahorro / Cta. Cte."
                                        DataField="Cuenta_bancaria_del_adherente" />
                                    <asp:BoundField HeaderText="COMPROBANTE"
                                        DataField="Identificacion_del_debito" />
                                    <asp:BoundField HeaderText="Fecha debito"
                                        DataFormatString="{0:d}"
                                        DataField="Fecha_de_vencimiento" />
                                    <asp:BoundField HeaderText="Monto"
                                        DataFormatString="{0:c}"
                                        DataField="Importe_debitado" />
                                    <asp:TemplateField HeaderText="Motivo rechazo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMotivoRechazo" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div runat="server" id="aConsulta">
                                                <a href="inmueble.aspx?nrocta=<%#Eval("NRO_CTA")%>" target="_blank">
                                                    <span class="fa fa-search"></span>
                                                </a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="btnAceptaMacro" CssClass="btn btn-primary pull-right" runat="server"
                                OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                                OnClick="btnAceptaMacro_Click" Text="Aceptar" />
                            <asp:Button ID="btnCancelarMacro" runat="server" Text="Cancelar" CssClass="btn btn-warning pull-right"
                                OnClick="btnCancelarMacro_Click" />
                        </div>
                        <div id="divRapiPago" runat="server" visible="false">
                            <div class="row">
                                <div class="col-md-12">
                                    <hr />
                                </div>
                                <div class="col-md-1">
                                    <p style="color: #d4edda; background-color: #d4edda; border-color: #c3e6cb;">.</p>
                                </div>
                                <div class="col-md-2">
                                    <p>Comp. Listo para procesar</p>
                                </div>
                                <div class="col-md-1">
                                    <p style="color: #fff3cd; background-color: #fff3cd; border-color: #ffeeba;">.</p>
                                </div>
                                <div class="col-md-2">
                                    <p>Comp. Pagado</p>
                                </div>
                                <div class="col-md-1">
                                    <p style="color: #f8d7da; background-color: #f8d7da; border-color: #f5c6cb;">.</p>
                                </div>
                                <div class="col-md-2">
                                    <p>Comp. No encontrado</p>
                                </div>
                                <div class="col-md-12">
                                    <hr />
                                </div>
                            </div>
                            <asp:GridView
                                ID="gvRapiPago"
                                CssClass="table table-bordered"
                                AutoGenerateColumns="false"
                                OnRowDataBound="gvRapiPago_RowDataBound"
                                runat="server">
                                <Columns>
                                    <asp:BoundField DataField="nroCta" HeaderText="N° Cuenta" />
                                    <asp:BoundField DataField="factura" HeaderText="Factura" />
                                    <asp:BoundField DataField="fechaCobro" HeaderText="Fecha Pago" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="importeCobrado" HeaderText="Importe cobrado" DataFormatString="{0:c}" />
                                    <asp:BoundField DataField="codigoBarra" HeaderText="Cod. Barra" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div runat="server" id="aConsulta">
                                                <a href="inmueble.aspx?nrocta=<%#Eval("nroCta")%>" target="_blank">
                                                    <span class="fa fa-search"></span>
                                                </a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="btnAceptarRapiPago"
                                CssClass="btn btn-primary pull-right" runat="server"
                                OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                                OnClick="btnAceptarRapiPago_Click" Text="Aceptar" />
                            <asp:Button ID="btnCancelarRapiPago" runat="server" Text="Cancelar" CssClass="btn btn-warning pull-right"
                                OnClick="btnCancelarRapiPago_Click" />
                        </div>
                    </div>
                </div>
                <!-- /.widget-user -->
            </div>
        </div>
        <!-- /.box -->
    </section>
    <!-- /.content -->
    <div class="modal fade in" id="modalConcepto">
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Cargar Concepto masivo</h4>
                </div>
                <div class="modal-body">
                    <div class="row" id="divListado">
                        <div class="col-md-12">
                            <asp:GridView
                                ID="gvConseptosAsignar"
                                runat="server"
                                AutoGenerateColumns="false"
                                CellPadding="4"
                                CssClass="table table-bordered table-hover dataTable"
                                OnRowCommand="gvConseptosAsignar_RowCommand"
                                OnRowDataBound="gvConseptosAsignar_RowDataBound"
                                EmptyDataText="No se encontraron conceptos"
                                ForeColor="#333333"
                                GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" />
                                    <asp:TemplateField HeaderText="Cargo/Descuento">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSuma" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Monto/Porcentaje">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMonto" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <a href="#"
                                                onclick="asignarServicio('<%#Eval("ID")%>',
                                                '<%#Eval("DESCRIPCION")%>','<%#Eval("SUMA")%>',
                                                '<%#Eval("MONTO")%>')">
                                                <span style="font-size: 20px;"
                                                    class="fa fa-download"></span>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div id="divDatos" style="display: none;">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Fecha</label>
                                    <input type="date" class="form-control"
                                        runat="server" id="txtFecha" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Cantidad</label>
                                    <input type="number" class="form-control"
                                        runat="server" onchange="calSubTotal()" id="txtCantConcept" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Concepto</label>
                                    <asp:TextBox ID="txtConcepto" Enabled="false"
                                        CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Pre. Unit</label>
                                    <asp:TextBox ID="txtCostoUnit" Enabled="false"
                                        CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Total</label>
                                    <asp:TextBox ID="txtTot" Enabled="false"
                                        CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Observaciones</label>
                                    <asp:TextBox ID="txtObsConcepto"
                                        CssClass="form-control"
                                        TextMode="MultiLine"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12" style="text-align: right;">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                <button type="button" class="btn btn-primary" runat="server" id="btnAceptarConcepto"
                                    onclientclick="this.disabled=true;this.value = 'Procesando...'" usesubmitbehavior="false"
                                    onserverclick="btnAceptarConcepto_ServerClick" validationgroup="alta">
                                    Aceptar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="text-align: right;">
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>


    <div class="modal modal-danger fade in" id="modalEliminaConcepto">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Eliminar Concepto</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Esta seguro de eliminar el concepto</label>
                        <asp:TextBox ID="txtEliminaConcepto" Enabled="false" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnEliminarConcepto" CssClass="btn btn-outline"
                        OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                        OnClick="btnEliminarConcepto_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalMacro">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Subir cobranza Debitos Macro</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Subir archivo</label>
                        <asp:FileUpload ID="fUpMacro" CssClass="form-control" runat="server" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnAceptarMacro" CssClass="btn btn-primary"
                        OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                        OnClick="btnAceptarMacro_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalBanelco">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Subir cobranza Banelco</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Subir archivo</label>
                        <asp:FileUpload ID="fUploadBanelco" CssClass="form-control" runat="server" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnBanelco" CssClass="btn btn-primary"
                        OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                        OnClick="btnBanelco_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalNota">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Nota Factura</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Nota a mostrar en factura (Maximo 400 caracteres)</label>
                        <asp:TextBox ID="txtLeyenda" CssClass="form-control"
                            TextMode="MultiLine" MaxLength="400" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnAceptarLeyenda" CssClass="btn btn-primary"
                        OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                        OnClick="btnAceptarLeyenda_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalRapiPago">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Subir cobranza Rapi Pago</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Subir archivo</label>
                        <asp:FileUpload ID="fUploadRapiPago" CssClass="form-control" runat="server" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnRapiPago" CssClass="btn btn-primary"
                        OnClientClick="this.disabled=true;this.value = 'Procesando...'" UseSubmitBehavior="false"
                        OnClick="btnRapiPago_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade in" id="modalFacturacion">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Facturacion</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Fecha facturas</label>
                        <asp:TextBox ID="txtFechaFactura" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnConfirmaFactura" CssClass="btn btn-primary"
                        OnClick="btnFacturar_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalCrearMacro">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Archivo Macro</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Fecha</label>
                        <asp:TextBox ID="txtFechaMacro" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnCrearMacro" CssClass="btn btn-primary"
                        OnClick="btnCrearMacro_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>

    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>
    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js"></script>
    <script>
        $(document).ready(function () {
            $("#modalConcepto").on('hidden.bs.modal', function () {
                $("#divListado").show('slow');
                $("#divDatos").hide('slow');
                $("#ContentPlaceHolder1_hIdServicio").val('');
                $("#ContentPlaceHolder1_txtCantConcept").val('');
                $("#ContentPlaceHolder1_txtConcepto").val('');
                $("#ContentPlaceHolder1_txtCostoUnit").val('');
                $("#ContentPlaceHolder1_txtTot").val('');
                $("#ContentPlaceHolder1_txtObsConcepto").val('');
            });
        });

    </script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvConseptosAsignar.ClientID %>').DataTable(
                {
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

        function abrirModalFacturacion(PERIODO) {
            $('#modalFacturacion').modal('show');
            //PERIODO
            $("#ContentPlaceHolder1_hPeriodo").val(PERIODO);

        }

        function abrirModalRapiPago() {
            $('#modalRapiPago').modal('show');
        }
        function abrirModalMacro1() {
            $('#modalMacro').modal('show');
        }
        function abrirModalBanelco() {
            $('#modalBanelco').modal('show');
        }
        function asignarServicio(ID, DESCRIPCION, SUMA, MONTO) {
            $("#divListado").hide('slow');
            $("#divDatos").show('slow');
            $("#ContentPlaceHolder1_hIdServicio").val(ID);
            $("#ContentPlaceHolder1_txtConcepto").val(DESCRIPCION);
            $("#ContentPlaceHolder1_txtCostoUnit").val(MONTO);
            $("#ContentPlaceHolder1_txtCantConcept").val('1');
            $("#ContentPlaceHolder1_txtTot").val(MONTO);

            var f = new Date();
            var dia = parseInt(f.getDate());
            var mes = parseInt(f.getMonth() + 1);
            var anio = f.getFullYear();

            var d = dia;
            var m = mes;

            if (dia < 10) {
                d = '0' + dia;
            }
            if (mes < 10) {
                m = '0' + mes;
            }

            $('#ContentPlaceHolder1_txtFecha').val(anio + '-' + m + '-' + d);
            $("#ContentPlaceHolder1_txtObsConcepto").focus();
        }
        function calSubTotal() {
            var preUni = parseFloat($("#ContentPlaceHolder1_txtCostoUnit").val());
            var cant = parseFloat($("#ContentPlaceHolder1_txtCantConcept").val());

            $("#ContentPlaceHolder1_txtTot").val(cant * preUni);
        }
    </script>
    <script>
        function abrirModal(PERIODO, VENCIMIENTO_1, MONTO_1, VENCIMIENTO_2, MONTO_2, VENCIMIENTO_3, MONTO_3,
            ALICUOTA_INTERES, CANT_CTAS_CTES, TOTAL_LIQUIDADO, USUARIO_GENERA, FECHA_GENERA,
            USUARIO_LIQUIDA, FECHA_LIQUIDA, USUARIO_FACTURA, FECHA_FACTURA, ESTADO) {
            $('#modalVerLiq').modal('show');
            //ID
            $("#ContentPlaceHolder1_lblPeriodo").text(
                'Resumen Liquidacion Periodo: ' + PERIODO.substring(0, 4) + ' - ' + PERIODO.substring(4, 7));
            $("#lblVenc1").text(VENCIMIENTO_1.substring(0, 10));

            $("#lblMonto1").text('$ ' + MONTO_1);
            $("#lblVenc2").text(VENCIMIENTO_2.substring(0, 10));
            $("#lblMonto2").text('$ ' + MONTO_2);
            $("#lblVenc3").text(VENCIMIENTO_3.substring(0, 10));
            $("#lblMonto3").text('$ ' + MONTO_3);
            $("#lblAlicuota").text(ALICUOTA_INTERES + ' %');

            $("#lblCantCta").text(CANT_CTAS_CTES);
            $("#lblMontoT").text('$ ' + TOTAL_LIQUIDADO);
            $("#lblDebe").text('$ ' + 0);
            $("#lblHaber").text('$ ' + 0);
            $("#lblSaldo").text('$ ' + 0);
            switch (ESTADO) {
                case '0':
                    $("#lblEstado").text('Estado: Generada (sin liquidar)');
                    break;
                case '1':
                    $("#lblEstado").text('Estado: Liquidado (sin facturar)');
                    break;
                case '2':
                    $("#lblEstado").text('Estado: Generada');
                    break;
                default:
            }
        }
        function abrirModalMacro(PERIODO) {
            $('#modalCrearMacro').modal('show');
            //PERIODO
            $("#ContentPlaceHolder1_hPeriodo").val(PERIODO);
        }
        function abrirModalNota(PERIODO, LEYENDA) {
            $('#modalNota').modal('show');
            //PERIODO
            $("#ContentPlaceHolder1_hPeriodo").val(PERIODO);
            $("#ContentPlaceHolder1_txtLeyenda").val(LEYENDA);
        }
        //DDLMes
        function abrirModalEdit(PERIODO, VENCIMIENTO_1, MONTO_1, VENCIMIENTO_2, MONTO_2, VENCIMIENTO_3, MONTO_3,
            ALICUOTA_INTERES) {
            //alert('modalAddExpensa');
            $('#modalAddExpensa').modal('show');
            //ACCION
            $("#ContentPlaceHolder1_hAccion").val('edita');
            //PERIODO
            $("#ContentPlaceHolder1_hPeriodo").val(PERIODO);
            $("#ContentPlaceHolder1_txtAnio").val(PERIODO.substring(0, 4));
            $("#ContentPlaceHolder1_DDLMes").val(PERIODO.substring(4, 6));
            //alert(PERIODO.substring(4, 6));
            //VENCIMIENTOS
            var arrayFecha = VENCIMIENTO_1.split("/");

            var mes = arrayFecha[1];
            if (mes < 9) {
                mes = "0" + mes;
            }
            var dia = arrayFecha[0];
            if (dia < 9) {
                dia = "0" + dia;
            }

            var arrayFecha2 = VENCIMIENTO_2.split("/");

            var mes2 = arrayFecha2[1];
            if (mes2 < 9) {
                mes2 = "0" + mes2;
            }

            var dia2 = arrayFecha2[0];
            if (dia2 < 9) {
                dia2 = "0" + dia2;
            }

            var arrayFecha3 = VENCIMIENTO_3.split("/");

            var mes3 = arrayFecha3[1];
            if (mes3 < 9) {
                mes3 = "0" + mes3;
            }

            var dia3 = arrayFecha3[0];
            if (dia3 < 9) {
                dia3 = "0" + dia3;
            }


            $("#ContentPlaceHolder1_txtVenc1").val(arrayFecha[2] + '-' + mes + '-' + dia);
            $("#ContentPlaceHolder1_txtVenc2").val(arrayFecha2[2] + '-' + mes2 + '-' + dia2);
            $("#ContentPlaceHolder1_txtVenc3").val(arrayFecha3[2] + '-' + mes3 + '-' + dia3);
            //MONTOS
            $("#ContentPlaceHolder1_txtMonto1").val(MONTO_1);
            $("#ContentPlaceHolder1_txtMonto2").val(MONTO_2);
            $("#ContentPlaceHolder1_txtMonto3").val(MONTO_3);
            //ALICUOTA
            $("#ContentPlaceHolder1_txtAlic").val(ALICUOTA_INTERES);
        }

        function abrirModalAdd() {
            $('#modalAddExpensa').modal('show');
            //ACCION
            $("#ContentPlaceHolder1_hAccion").val('crea');
            //PERIODO
            var periodo = $("#ContentPlaceHolder1_hPeriodo").val();
            $("#ContentPlaceHolder1_txtAnio").val(periodo.substring(0, 4));
            $("#ContentPlaceHolder1_txtMes").val(periodo.substring(4, 6));
            $("#ContentPlaceHolder1_txtNro").val(periodo.substring(6, 8));

            //VENCIMIENTOS
            $("#ContentPlaceHolder1_txtVenc1").val($("#ContentPlaceHolder1_hVenc1").val());
            $("#ContentPlaceHolder1_txtVenc2").val($("#ContentPlaceHolder1_hVenc2").val());
            $("#ContentPlaceHolder1_txtVenc3").val($("#ContentPlaceHolder1_hVenc3").val());
            //MONTOS
            $("#ContentPlaceHolder1_txtMonto1").val($("#ContentPlaceHolder1_hMonto1").val());
            $("#ContentPlaceHolder1_txtMonto2").val($("#ContentPlaceHolder1_hMonto2").val());
            $("#ContentPlaceHolder1_txtMonto3").val($("#ContentPlaceHolder1_hMonto3").val());
            //ALICUOTA
            $("#ContentPlaceHolder1_txtAlic").val($("#ContentPlaceHolder1_hAlicuota").val());
        }
        function abrirModalAddServicio(ID) {
            $('#modalConcepto').modal('show');
            //PERIODO
            $("#ContentPlaceHolder1_hPeriodoModal").val(ID);
        }
        function abrirModalElimina(PERIODO, ID_CONCEPTO, DESC_CONCEPTO) {
            $('#modalEliminaConcepto').modal('show');
            $("#ContentPlaceHolder1_hPeriodoElimina").val(PERIODO);
            $("#ContentPlaceHolder1_hConceptoElimina").val(ID_CONCEPTO);
            $("#ContentPlaceHolder1_txtEliminaConcepto").val(DESC_CONCEPTO);
        }
        function verDetalle(PERIODO) {
            var tr = $('#<%=gvLiquidaciones.ClientID%> tr[orderid =' + PERIODO + ']');
            tr.toggle();

            if (tr.is(':visible')) {
                $("#" + PERIODO).removeAttr('class');
                $("#" + PERIODO).attr('class', 'fa fa-minus-circle');
            }
            else {
                $("#" + PERIODO).removeAttr('class');
                $("#" + PERIODO).attr('class', 'fa fa-plus-circle');
            }
        }
    </script>

    <div class="modal fade in" id="modalAddExpensa">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Crear Expensa</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Año</label>
                                <asp:TextBox CssClass="form-control"
                                    ID="txtAnio" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Mes</label>
                                <%--                                <asp:TextBox CssClass="form-control"
                                    ID="txtMes" runat="server"></asp:TextBox>--%>
                                <asp:DropDownList ID="DDLMes" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="ENERO" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="FEBRERO" Value="02"></asp:ListItem>
                                    <asp:ListItem Text="MARZO" Value="03"></asp:ListItem>
                                    <asp:ListItem Text="ABRIL" Value="04"></asp:ListItem>
                                    <asp:ListItem Text="MAYO" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="JUNIO" Value="06"></asp:ListItem>
                                    <asp:ListItem Text="JULIO" Value="07"></asp:ListItem>
                                    <asp:ListItem Text="AGOSTO" Value="08"></asp:ListItem>
                                    <asp:ListItem Text="SEPTIEMBRE" Value="09"></asp:ListItem>
                                    <asp:ListItem Text="OCTUBRE" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="NOVIEMBRE" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="DICIEMBRE" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Nro</label>
                                <asp:DropDownList ID="DDLTipoExpesa"
                                    runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Ordiaria" Value="00"></asp:ListItem>
                                    <asp:ListItem Text="Extra Ordiaria" Value="01"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="border-right: 1px solid lightgray;">
                            <div class="form-group">
                                <label>1° Vencimiento</label>
                                <asp:TextBox TextMode="Date" CssClass="form-control"
                                    ID="txtVenc1" runat="server"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label>Monto</label>
                                <asp:TextBox CssClass="form-control" ID="txtMonto1"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4" style="border-right: 1px solid lightgray;">
                            <div class="form-group">
                                <label>2° Vencimiento</label>
                                <asp:TextBox TextMode="Date" CssClass="form-control"
                                    ID="txtVenc2" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Monto</label>
                                <asp:TextBox CssClass="form-control" ID="txtMonto2"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4" style="border-right: 1px solid lightgray;">
                            <div class="form-group">
                                <label>3° Vencimiento</label>
                                <asp:TextBox TextMode="Date" CssClass="form-control"
                                    ID="txtVenc3" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Monto</label>
                                <asp:TextBox CssClass="form-control" ID="txtMonto3"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Alicuota interes mensual porterior al 3° vencimiento</label>
                                <asp:TextBox CssClass="form-control" ID="txtAlic" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="text-align: right;">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="btnAceptarExpensa"
                        runat="server" onserverclick="btnAceptarExpensa_ServerClick">
                        Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>


    <div class="modal fade in" id="modalVerLiq">
        <div class="modal-dialog" style="width: 65%;">
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
                            <h4 class="widget-user-desc" id="lblEstado"></h4>
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="box box-widget widget-user-2">
                                <div class="box-footer no-padding">
                                    <ul class="nav nav-stacked">
                                        <li><a href="#">1° Vencimiento <span id="lblVenc1"
                                            class="pull-right" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Monto <span class="pull-right"
                                            id="lblMonto1" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">2° Vencimiento <span id="lblVenc2"
                                            class="pull-right" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Monto <span class="pull-right"
                                            id="lblMonto2" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">3° Vencimiento <span id="lblVenc3"
                                            class="pull-right" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Monto <span class="pull-right"
                                            id="lblMonto3" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Alicuota interes diario <span class="pull-right"
                                            id="lblAlicuota" style="font-size: 16px;"></span></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="box box-widget widget-user-2">
                                <div class="box-footer no-padding">
                                    <ul class="nav nav-stacked">
                                        <li><a href="#">Cant. Cuentas liquidadas <span id="lblCantCta"
                                            class="pull-right" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Total liquidado <span class="pull-right"
                                            id="lblMontoT" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Debe <span id="lblDebe"
                                            class="pull-right" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Haber <span class="pull-right"
                                            id="lblHaber" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Saldo <span id="lblSaldo"
                                            class="pull-right" style="font-size: 16px;"></span></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="box box-widget widget-user-2">
                                <div class="box-footer no-padding">
                                    <ul class="nav nav-stacked">
                                        <li><a href="#">Fecha generación: <span id="lblGenera"
                                            class="pull-right" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Usuario genera: <span class="pull-right"
                                            id="lblUsuarioGenera" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Fecha Liquidación: <span id="lblLiquida"
                                            class="pull-right" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Usuario liquida: <span class="pull-right"
                                            id="lblUsuarioLiquida" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Fecha Facturacion: <span id="lblFacrura"
                                            class="pull-right" style="font-size: 16px;"></span></a></li>
                                        <li><a href="#">Usuario Factura: <span class="pull-right"
                                            id="lblUsuarioFactura" style="font-size: 16px;"></span></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="text-align: right;">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary">Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <%--<asp:LinkButton ID="btnMacro"
        CommandArgument='<%#Eval("PERIODO")%>'
        CommandName="macro"
        runat="server">
        <span class="fa fa-bank" style="font-size:20px;"></span>Archivo Banco Macro
     </asp:LinkButton>--%>
</asp:Content>
