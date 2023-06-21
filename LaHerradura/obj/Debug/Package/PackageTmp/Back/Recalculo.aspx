<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" 
    AutoEventWireup="true" CodeBehind="Recalculo.aspx.cs" 
    Inherits="LaHerradura.Back.Recalculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* The switch - the box around the slider */
        .switch {
            position: relative;
            display: inline-block;
            width: 60px;
            height: 34px;
        }

            /* Hide default HTML checkbox */
            .switch input {
                opacity: 0;
                width: 0;
                height: 0;
            }

        /* The slider */
        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 26px;
                width: 26px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #00733e;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(26px);
            -ms-transform: translateX(26px);
            transform: translateX(26px);
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hPagoCuenta" runat="server" />
    <asp:HiddenField ID="hMontoOriginalBilletera" runat="server" />
    <asp:HiddenField ID="hMontoOriginal" runat="server" />
    <asp:HiddenField ID="hUsuario" runat="server" />
    <asp:HiddenField ID="hNroCta" runat="server" />
    <asp:HiddenField ID="hFechaRecalculo" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Asiento Pagos</h3>
                </div>
                <div class="box-body" style="padding: 25px;">
                    <div class="alert alert-warning alert-dismissible" role="alert" id="divError"
                        runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Error!</strong> <span id="txtError" runat="server"></span>
                    </div>
                    <div id="divAsientoPago" runat="server">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Fecha Cobro</label>
                                    <asp:TextBox ID="txtFechaCobro" CssClass="form-control"
                                        TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group" style="padding-top: 25px;">
                                    <asp:Button ID="btnRecalculo" CssClass="btn btn-primary btn-block"
                                        OnClick="btnRecalculo_Click"
                                        runat="server" Text="Recalcular Montos" />
                                </div>
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                                <div class="form-group" style="padding-top: 25px;">
                                    <a href="#" class="btn btn-default pull-right"
                                        id="btnSalir"
                                        runat="server" onserverclick="btnSalir_ServerClick">
                                        <span class="fa fa-sign-out">&nbsp; Salir</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="row" id="divSaldoBilletera" runat="server">
                            <div class="col-md-12">
                                <div class="callout callout-success" style="background: transparent !important; border-top: solid 1px #00a65a; border-bottom: solid 1px #00a65a; border-right: solid 1px #00a65a;">
                                    <div class="widget-user-header">
                                        <div class="widget-user-image">
                                            <img class="img-circle" style="width: 50px;" src="../img/billetera.png" alt="User Avatar" />
                                            <span class="widget-user-username"
                                                style="color: black; font-size: 18px; margin-left: 15px;">Pagas 
                                             <asp:TextBox
                                                 ID="txtMontoBilleteraEditable"
                                                 OnTextChanged="txtMontoBilleteraEditable_TextChanged"
                                                 AutoPostBack="true"
                                                 runat="server"></asp:TextBox>
                                                de las expensas seleccionadas con tu dinero disponible</span>
                                            <label class="switch pull-right">
                                                <asp:CheckBox ID="chkSelect"
                                                    runat="server"
                                                    Checked="true"
                                                    AutoPostBack="true"
                                                    OnCheckedChanged="chkSelect_CheckedChanged" />
                                                <span class="slider round"></span>
                                            </label>
                                        </div>
                                        <!-- /.widget-user-image -->
                                    </div>
                                    <div class="alert alert-danger alert-dismissible" style="margin-top: 20px;" id="divErrorBilletera" runat="server">
                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                        <h4><i class="icon fa fa-ban"></i>Error!</h4>
                                        <span id="lblMsgErrorBilletera" runat="server"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gvCtaCte"
                                    ForeColor="#333333"
                                    CssClass="table table-condensed"
                                    GridLines="None"
                                    CellPadding="4"
                                    AutoGenerateColumns="false"
                                    OnRowDataBound="gvDetails_RowDataBound"
                                    runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                        <asp:TemplateField HeaderText="Periodo" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPeriodo" runat="server" Text=""></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="VENCIMIENTO" HeaderText="VENCIMIENTO" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="MONTO_ORIGINAL" DataFormatString="{0:c}" HeaderText="MONTO ORIGINAL" />
                                        <asp:BoundField DataField="DESC_VENCIMIENTO" DataFormatString="{0:c}" HeaderText="DESC. PAGO EN TERMINO" />
                                        <asp:BoundField DataField="DIAS_MORA" HeaderText="DIAS MORA" />
                                        <asp:BoundField DataField="INTERES_MORA" DataFormatString="{0:c}" HeaderText="INTERES MORA" />
                                        <asp:TemplateField HeaderText="INTERES MORA">
                                            <ItemTemplate>
                                                <div id="lblInteresMora" runat="server">
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SALDO" DataFormatString="{0:c}" HeaderText="SALDO" />
                                        <asp:TemplateField HeaderText="Descuento">
                                            <ItemTemplate>
                                                <div id="divDescuento" runat="server">
                                                </div>
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
                            </div>
                        </div>
                        <div class="row">
                            <div id="divAsiento" runat="server">
                                <div class="col-md-4" style="padding-right: 30px;">
                                    <div class="box">
                                        <div class="box-header">
                                        </div>
                                        <div class="box-body no-padding">
                                            <table class="table table-condensed">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div style="color: gray;">
                                                                Monto Original:
                                                            <span class="pull-right">$</span>
                                                            </div>
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="lblMontoOriginal" Font-Size="12"
                                                                ForeColor="GrayText" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="color: gray;">
                                                                Descuento pago en termino
                                                            <span class="pull-right">$</span>
                                                            </div>
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="lblDesc" FFont-Size="12"
                                                                ForeColor="GrayText" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="color: gray;">
                                                                Intereses Mora:
                                                            <span class="pull-right">$</span>
                                                            </div>
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="lblInteresMora" Font-Size="12"
                                                                ForeColor="GrayText" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
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

                                    <br />
                                    <asp:Label ID="lblCantSelecionados" Font-Bold="true" Font-Size="8"
                                        ForeColor="GrayText" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="Label3" Font-Bold="true" Font-Size="8"
                                        ForeColor="GrayText" runat="server" Text="Periodo(s) Seleccionado(s)">
                                    </asp:Label>
                                    <br />
                                    <asp:Label ID="lblMensaje" ForeColor="Red" runat="server" Text="">

                                    </asp:Label>
                                    <br />
                                    <%--<a href="#" onclick="abrirAcentarPago()"
                                                                class="btn btn-primary pull-right">Acentar Pago</a>--%>
                                </div>
                                <div class="col-md-8">
                                    <div class="box box-primary" style="box-shadow: 1px 1px 12px 10px rgba(0,0,0,0.1);">
                                        <div class="box-header box-header-background-light with-border">
                                            <h3 class="box-title">PAGO: </h3>
                                            <%--<h3 class="pull-right box-title">TOTAL: $                                                                                                             
                                                    
                                                </h3>--%>
                                        </div>
                                        <div class="box-background">
                                            <div class="box-body">
                                                <div class="row" id="divMedioPago">
                                                    <div class="col-md-7">
                                                        <div class="form-group">
                                                            <label>Medio Pago</label>
                                                            <asp:DropDownList ID="DDLMedioPago"
                                                                AutoPostBack="true"
                                                                OnSelectedIndexChanged="DDLMedioPago_SelectedIndexChanged"
                                                                CssClass="form-control"
                                                                runat="server">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label>Monto</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon" id="basic-addon1">$</span>
                                                            <asp:TextBox ID="txtMontoVal" autocomplete="off"
                                                                CssClass="form-control" 
                                                                runat="server"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-2" style="padding-top: 25px;">
                                                        <asp:LinkButton ID="lbtnAddValor"
                                                            OnClick="lbtnAddValor_Click"
                                                            CssClass="btn btn-success "
                                                            runat="server"><i class="fa fa-check"></i> </asp:LinkButton>
                                                    </div>
                                                    <div id="divCheque" runat="server" visible="false">
                                                        <div class="col-md-8">
                                                            <div class="form-group">
                                                                <label>Banco</label>
                                                                <asp:DropDownList ID="DDLBanco"
                                                                    CssClass="form-control"
                                                                    runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Nro. Cheque</label>
                                                                <asp:TextBox ID="txtNroCheque"
                                                                    CssClass="form-control"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>CUIT Pagador</label>
                                                                <asp:TextBox ID="txtCuitPagador"
                                                                    CssClass="form-control"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Fecha Cheque</label>
                                                                <asp:TextBox ID="txtFechaCheque"
                                                                    TextMode="Date"
                                                                    CssClass="form-control"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row" style="margin-top: 20px;">
                                                    <div class="col-md-12">
                                                        <asp:GridView ID="gvValores"
                                                            runat="server"
                                                            CellPadding="4"
                                                            DataKeyNames="MEDIO_PAGO,BANCO,NRO_CHEQUE,MONTO,ID_PLAN_PAGO,ID_BANCO,CUIT_PAGADOR,FECHA_CHEQUE"
                                                            ShowHeader="false"
                                                            ForeColor="#333333"
                                                            OnRowCommand="gvValores_RowCommand"
                                                            CssClass="table table-condensed"
                                                            GridLines="None" AutoGenerateColumns="False">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                                            <Columns>
                                                                <asp:BoundField DataField="MEDIO_PAGO" HeaderText="Medio de Pago" />
                                                                <asp:BoundField DataField="BANCO" HeaderText="Banco" />
                                                                <asp:BoundField DataField="NRO_CHEQUE" HeaderText="Nro Cheque" />
                                                                <asp:BoundField DataField="MONTO" ItemStyle-HorizontalAlign="Right" HeaderText="Monto" DataFormatString="{0:c}" />
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton
                                                                            CommandArgument='<%# Container.DataItemIndex %>'
                                                                            CommandName="eliminar"
                                                                            ID="lbtnQuitar" runat="server">
                                                                        <i class="fa fa-remove" style="color:red;"></i>
                                                                        </asp:LinkButton>
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
                                                    </div>
                                                    <div class="col-md-12" style="padding-right: 30px;">
                                                        <p>
                                                            <strong class="pull-left box-title">TOTAL: </strong>
                                                            <strong class="pull-right box-title">$
                                                                                    <span id="spanSaldo" runat="server"></span>
                                                            </strong>
                                                        </p>
                                                    </div>
                                                    <div id="divBilletera" runat="server" visible="false">
                                                        <div class="col-md-12" style="padding-right: 30px; padding-top: 15px;">
                                                            <p>
                                                                <strong style="font-weight: 500" class="pull-left box-title">MONTO A ACREDITAR: </strong>
                                                                <strong style="font-weight: 500" class="pull-right box-title">$
                                                                                        <span id="spanAcreditar" runat="server"></span>
                                                                </strong>
                                                            </p>
                                                        </div>
                                                        <div class="col-md-12" style="padding-right: 30px; padding-top: 15px;">
                                                            <p>
                                                                <strong style="font-weight: 500" class="pull-left box-title">SALDO A FAVOR: </strong>
                                                                <strong style="font-weight: 500" class="pull-right box-title">$
                                                                                    <span id="spanBilletera" runat="server"></span>
                                                                </strong>
                                                            </p>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12" style="padding-top: 30px; text-align: right;">
                                                        <asp:Button ID="btnAcentarPago" CssClass="btn btn-primary"
                                                            Visible="false"
                                                            OnClientClick="this.disabled=true;this.value = 'Registrando pago...'" UseSubmitBehavior="false"
                                                            OnClick="btnAsientaPago_Click" runat="server" Text="Aceptar Pago" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalPago">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Acentar Pago</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:GridView ID="gvConfirmoPago"
                            CssClass="table table-hover"
                            AutoGenerateColumns="false"
                            runat="server">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                <asp:BoundField DataField="PERIODO" HeaderText="Periodo" />
                                <asp:BoundField DataField="SALDO" HeaderText="Saldo" />
                            </Columns>
                            <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                        </asp:GridView>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <label>Fecha Cobro</label>
                                <div class="input-group input-group-sm">
                                    <input type="text" disabled class="form-control" id="txtFecPag" runat="server" />
                                    <span class="input-group-btn"></span>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Medio Pago</label>
                                    <asp:DropDownList ID="DDLMedioPagoAnt" CssClass="form-control"
                                        runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Monto a pagar</label>
                                    <p style="padding: 5px; border: solid 1px gray;">
                                        Total:  
                                    <strong class="pull-right" id="txtTotDetalle" runat="server"></strong>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalDetalleInteres">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="border-bottom-color: #e5e5e5; background: cadetblue; color: white;">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 style="font-weight: 800" class="modal-title" id="lblTitDetalleInteres">Detalle de Intereses</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Ajuste Interes</label>
                                <asp:TextBox ID="txtAjusteInteres"
                                    placeholder="Ingrese el nuevo monto de interes"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Observaciones</label>
                                <asp:TextBox ID="txtObs"
                                    TextMode="MultiLine"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="border-top-color: #e5e5e5;">
                    <asp:Button ID="btnAceptar" CssClass="btn btn-primary"
                        OnClick="btnAceptar_Click"
                        runat="server" Text="Aceptar" />
                    <button data-dismiss="modal" class="btn btn-default">Volver</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalDescuento">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="border-bottom-color: #e5e5e5; background: cadetblue; color: white;">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 style="font-weight: 800" class="modal-title"
                        id="lblTitDescuento">Aplicar Descuento</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Descuento</label>
                                <asp:TextBox ID="txtAplicaDescuento"
                                    placeholder="Ingrese el nuevo monto de descuento"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Observaciones</label>
                                <asp:TextBox ID="txtObservaciones"
                                    TextMode="MultiLine"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="border-top-color: #e5e5e5;">
                    <asp:Button ID="btnAceptarDescuento" CssClass="btn btn-primary"
                        OnClick="btnAceptarDescuento_Click"
                        runat="server" Text="Aceptar" />
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hIdCta" runat="server" />
    <script>
        function abreDetalleInteres(id) {
            $('#ContentPlaceHolder1_hIdCta').val(id);
            $('#modalDetalleInteres').modal('show');
        }
        function abreDescuento(id, montoOriginal) {
            $('#ContentPlaceHolder1_hIdCta').val(id);
            $('#ContentPlaceHolder1_hMontoOriginal').val(montoOriginal);
            $('#lblTitDescuento').html("<p>Descuentos</p><hr style='margin: 0;'><p><small style='color:white;'>La acción de aplicar descuento anulara los intereses por mora y sera aplicado sobre el monto original facturado ($" + montoOriginal + ")</small></p>");
            $('#modalDescuento').modal('show');
        }
    </script>

</asp:Content>
