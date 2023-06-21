﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master"
    AutoEventWireup="true" CodeBehind="inmueble.aspx.cs"
    Inherits="LaHerradura.Back.inmueble" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />


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
    <link href="../App_Themes/stacktable.css?v=1.0" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



    <asp:HiddenField ID="hPagoCuenta" runat="server" />
    <asp:HiddenField ID="hId" runat="server" />
    <asp:HiddenField ID="hDireccion" runat="server" />
    <asp:HiddenField ID="hLat" runat="server" />
    <asp:HiddenField ID="hLong" runat="server" />
    <asp:HiddenField ID="hCP" runat="server" />

    <asp:HiddenField ID="hIdMail" runat="server" />
    <asp:HiddenField ID="hIdEliminaMail" runat="server" />
    <asp:HiddenField ID="hIdServicio" runat="server" />

    <asp:HiddenField ID="hMan" runat="server" />
    <asp:HiddenField ID="hLot" runat="server" />
    <asp:HiddenField ID="hDir" runat="server" />
    <asp:HiddenField ID="hNro" runat="server" />
    <asp:HiddenField ID="hCir" runat="server" />
    <asp:HiddenField ID="hSec" runat="server" />
    <asp:HiddenField ID="hManz" runat="server" />
    <asp:HiddenField ID="hPar" runat="server" />
    <asp:HiddenField ID="HPh" runat="server" />
    <asp:HiddenField ID="hNroRentas" runat="server" />

    <asp:HiddenField ID="hIdCta" runat="server" />
    <asp:HiddenField ID="hIdPersona" runat="server" />
    <asp:HiddenField ID="hIdPersonaElimina" runat="server" />

    <asp:HiddenField ID="hNroRecibo" runat="server" />
    <!-- Main content -->

    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <!-- Widget: user widget style 1 -->
                <div class="box box-widget widget-user-2">
                    <!-- Add the bg color to the header using any of the bg-* classes -->
                    <div class="widget-user-header bg-aqua-active">
                        <div class="widget-user-image">
                            <img class="img-circle" src="../App_Themes/img/inm.png" />
                        </div>
                        <!-- /.widget-user-image -->
                        <h3 style="font-size: 24px; padding-right: 15px; margin-right: 15px;"
                            class="widget-user-username" id="lblDireccion" runat="server"></h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool"
                                onclick="abrirModalEdit()" data-widget="Editar">
                                <i class="fa fa-edit" style="font-size: 20px; color: white;"></i>
                            </button>
                        </div>
                        <h5 class="widget-user-desc" style="font-size: 18px; font-weight: 700;"
                            id="lblCta" runat="server"></h5>
                        <h5 class="widget-user-desc" style="font-size: 14px; font-weight: 500;"
                            id="lblCatastrales" runat="server"></h5>
                    </div>

                    <div class="row" style="margin-top: 50px;">
                        <div class="col-md-8 col-md-offset-2">
                            <div class="alert alert-success fade in alert-dismissible" style="margin-top: 18px;"
                                runat="server" id="divOk" visible="false">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close" title="close">×</a>
                                <%--<strong>Su clave a sido restablecida con éxito!</strong>--%>
                                <strong id="msjOk" runat="server"></strong>
                                <div style="text-align: right; margin-top: 25px;">
                                    <asp:Button ID="Button2" OnClick="btnCancel_Click" runat="server"
                                        Text="Salir" CssClass="btn btn-warning" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8 col-md-offset-2">
                            <div class="alert alert-danger fade in alert-dismissible" style="margin-top: 18px;"
                                runat="server" id="div2" visible="false">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close" title="close">×</a>
                                <strong id="msgError" runat="server"></strong>
                            </div>
                        </div>
                    </div>

                    <div class="box-body" id="divScroll">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="alert alert-warning alert-dismissible" role="alert"
                                    id="divError"
                                    runat="server" visible="false">
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <strong>Error!</strong>
                                    <span id="txtError" runat="server"></span>
                                </div>
                                <hr />
                                <div class="nav-tabs-custom">
                                    <ul class="nav nav-tabs">
                                        <li class="active"><a href="#tab_1" data-toggle="tab">Cuenta Corriente</a></li>
                                        <li><a href="#tab_2" data-toggle="tab">Información General</a></li>
                                        <li><a href="#tab_3" data-toggle="tab">Servicios y Adicionales</a></li>
                                        <li><a href="#tab_4" data-toggle="tab">Débito Automático</a></li>
                                        <li class="pull-right"><a href="cuentas.aspx" class="btn btn-success">
                                            <span class="fa fa-sign-out">&nbsp; Salir</span>
                                        </a></li>
                                        <li class="pull-right" runat="server" id="btnLibre">
                                            <a href="#" class="btn btn-success" runat="server"
                                                onserverclick="btnLibreDeuda_ServerClick"
                                                id="btnLibreDeuda">
                                                <span class="fa fa-download">&nbsp; Libre Deuda</span>
                                            </a></li>
                                        <li class="pull-right" runat="server" id="btnCargar">
                                            <a href="#" class="btn btn-success" onclick="abrirCargarDedua()">
                                                <span class="fa fa-plus-square">&nbsp; Cargar Deuda</span>
                                            </a>
                                        </li>
                                        <li class="pull-right" runat="server" id="btnNotaDebito">
                                            <a href="#" class="btn btn-success"
                                                onclick="abrirModalNotaDebito()">
                                                <span class="fa fa-plus-square">&nbsp; Nota de Debito</span>
                                            </a>
                                        </li>
                                        <li class="pull-right" runat="server" id="btnNotaCredito">
                                            <a href="#" class="btn btn-success"
                                                onclick="abrirModalNotaCredito()">
                                                <span class="fa fa-plus-square">&nbsp; Nota de Crédito</span>
                                            </a>
                                        </li>
                                    </ul>
                                    <div class="tab-content">
                                        <div class="tab-pane" id="tab_2">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="box-header with-border">
                                                        <div class="row">
                                                            <div class="col-md-6 box-header" style="padding-top: 0px;">
                                                                <h4 style="font-weight: 600">Propietarios / Inquilinos</h4>
                                                                <hr style="padding: 0; margin: 0;" />
                                                                <ul class="nav nav-stacked" id="lblPropietarios"
                                                                    runat="server">
                                                                </ul>
                                                                <div class="box-tools pull-right">
                                                                    <a href="#"
                                                                        data-toggle="modal" data-target="#modalAddPersona"
                                                                        class="btn btn-box-tool">
                                                                        <i class="fa fa-plus-circle"
                                                                            style="font-size: 24px;"></i>
                                                                    </a>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 box-header" style="padding-top: 0px;">
                                                                <h4 style="font-weight: 600">Mails envío expensas</h4>
                                                                <hr style="padding: 0; margin: 0;" />
                                                                <ul class="nav nav-stacked" id="ulMails"
                                                                    runat="server">
                                                                </ul>
                                                                <div class="box-tools pull-right">
                                                                    <a href="#"
                                                                        onclick="abrirModalMail('', '')"
                                                                        class="btn btn-box-tool">
                                                                        <i class="fa fa-plus-circle"
                                                                            style="font-size: 24px;"></i>
                                                                    </a>
                                                                </div>
                                                                <ul class="nav nav-stacked" id="lblContacto" runat="server">
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane active" id="tab_1">
                                            <%--             <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                                <ContentTemplate>--%>
                                            <div class="row" id="divBilletera" runat="server">
                                                <div class="col-md-12">
                                                    <div class="callout callout-success"
                                                        style="background: transparent !important; border-top: solid 1px #00a65a; border-bottom: solid 1px #00a65a; border-right: solid 1px #00a65a;">
                                                        <div class="widget-user-header" style="padding: 0">
                                                            <div class="widget-user-image">
                                                                <img class="img-circle" style="width: 30px;" src="../img/billetera.png" alt="User Avatar" />
                                                                <span class="widget-user-username" style="color: black; font-size: 18px; margin-left: 15px;">
                                                                    <strong id="lblMontoBilletera" runat="server"></strong>Disponible para cancelacion de deuda</span>
                                                            </div>
                                                            <!-- /.widget-user-image -->
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="form-group col-md-6">
                                                    <label>Filtro</label>
                                                    <asp:DropDownList ID="DDLFiltro" CssClass="form-control"
                                                        runat="server" AutoPostBack="true"
                                                        OnSelectedIndexChanged="DDLFiltro_SelectedIndexChanged">
                                                        <asp:ListItem Value="0" Text="Deuda"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Cuenta completa"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Deuda exportable"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Movimiento cuenta"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group col-md-6">
                                                    <label>Total Deuda: </label>
                                                    <asp:TextBox CssClass="form-control" Style="text-align: right;" Enabled="false" ID="txtSaldo" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="gvCtaCte"
                                                        CssClass="table table-bordered"
                                                        AutoGenerateColumns="false"
                                                        OnRowDataBound="gvCtaCte_RowDataBound"
                                                        OnRowCommand="gvCtaCte_RowCommand"
                                                        runat="server">
                                                        <Columns>
                                                            <asp:BoundField DataField="ID" HeaderText="ID"
                                                                ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <div id="divVerDetalle" runat="server">
                                                                        <a href="#" onclick="verDetalle('<%#Eval("ID")%>')">
                                                                            <span class="fa fa-plus-circle" id="<%#Eval("ID")%>"
                                                                                style="color: #5D7B9D; font-weight: bold; font-size: 24px;"
                                                                                orderid="<%#Eval("ID")%>"></span></a>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Periodo"
                                                                ItemStyle-Wrap="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPeriodo" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="VENCIMIENTO" HeaderText="VENCIMIENTO" DataFormatString="{0:d}" />
                                                            <asp:BoundField DataField="MONTO_ORIGINAL" DataFormatString="{0:c}" HeaderText="MONTO" />
                                                            <asp:BoundField DataField="DIAS_MORA" HeaderText="DIAS MORA" />
                                                            <asp:TemplateField HeaderText="INTERES MORA">
                                                                <ItemTemplate>
                                                                    <div id="lblInteresMora" runat="server">
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PAGO A CUENTA">
                                                                <ItemTemplate>
                                                                    <div id="lblPagoCta" runat="server">
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right">
                                                                <HeaderStyle Height="40px" CssClass="headerDerecha" HorizontalAlign="Right" />
                                                                <HeaderTemplate>
                                                                    <label style="text-align: right !important; font-weight: 700">
                                                                        TOTAL</label>
                                                                    <%--<input id="chkAll" name="chkAll" onclick="javascript: SelectAllCheckboxes(this)" type="checkbox" />--%>
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
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right">
                                                                <HeaderStyle Height="40px" CssClass="headerDerecha" HorizontalAlign="Right" />
                                                                <HeaderTemplate>
                                                                    <label style="text-align: right !important; font-weight: 700">
                                                                        NC</label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div runat="server" id="btnNC">
                                                                        <a href="#"
                                                                            onclick="abrirModalAddComprobante('<%#Eval("ID")%>','<%#Eval("MONTO_ORIGINAL")%>')">
                                                                            <span class="fa fa-credit-card"></span>
                                                                        </a>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnQuitarDeuda"
                                                                        OnClientClick="return confirm('¿Esta seguro de eliminar la deuda?');"
                                                                        CommandArgument='<%# Eval("ID") %>'
                                                                        CommandName="quitaDeuda"
                                                                        runat="server">
                                                                                <span class="fa fa-remove" style="color:red; font-size:18px;"></span>
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgWebActiva"
                                                                        CommandArgument='<%# Eval("ID") %>'
                                                                        ImageUrl="~/img/activoWeb.png"
                                                                        CommandName="webActiva"
                                                                        OnClientClick="return confirm('Esta seguro de bloquear el periodo para el pago web')"
                                                                        runat="server" />
                                                                    <asp:ImageButton ID="imgWebBloquea"
                                                                        ImageUrl="~/img/bloqueoWeb.png"
                                                                        OnClientClick="return confirm('Esta seguro de activar el periodo para el pago web')"
                                                                        CommandArgument='<%# Eval("ID") %>'
                                                                        CommandName="webBloquea"
                                                                        runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <tr style="display: none; background-color: white;" orderid="<%#Eval("ID")%>">
                                                                        <td colspan="100%">
                                                                            <div style="position: relative; left: 25px;">
                                                                                <asp:GridView ID="gvDetails"
                                                                                    CssClass="table table-responsive"
                                                                                    GridLines="None"
                                                                                    ShowFooter="true"
                                                                                    Width="90%"
                                                                                    DataKeyNames="PERIODO, ID_CONCEPTO"
                                                                                    OnRowDataBound="gvDetails_RowDataBound"
                                                                                    OnRowCommand="gvDetails_RowCommand"
                                                                                    AutoGenerateColumns="false"
                                                                                    runat="server">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="CANT" HeaderText="Cant." ControlStyle-Width="10%" />
                                                                                        <asp:BoundField DataField="DESC_CONCEPTO" HeaderText="Concepto" />
                                                                                        <asp:BoundField DataField="OBS" HeaderText="Observaciones" />
                                                                                        <asp:BoundField DataField="COSTO" HeaderText="Pre. Unit."
                                                                                            DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                                                                                            HeaderStyle-HorizontalAlign="Right" />
                                                                                        <asp:BoundField DataField="SUBTOTAL" HeaderText="Sub Total"
                                                                                            DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                                                                                            HeaderStyle-HorizontalAlign="Right" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>

                                                    </asp:GridView>

                                                    <div class="modal fade in" id="modalPagoCta">
                                                        <div class="modal-dialog" style="width: 80%;">
                                                            <div class="modal-content">
                                                                <div class="modal-header" style="border-bottom-color: #e5e5e5;">
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                        <span aria-hidden="true">×</span></button>
                                                                    <h4 class="modal-title" id="lblTitPagoCta"></h4>
                                                                </div>
                                                                <div class="modal-body" id="divPagoCta">
                                                                </div>
                                                                <div class="modal-footer" style="border-top-color: #e5e5e5;">
                                                                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="modal fade in" id="modalDetalleInteres">
                                                        <div class="modal-dialog" style="width: 80%;">
                                                            <div class="modal-content">
                                                                <div class="modal-header" style="border-bottom-color: #e5e5e5; background: cadetblue; color: white;">
                                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                        <span aria-hidden="true">×</span></button>
                                                                    <h4 style="font-weight: 800" class="modal-title" id="lblTitDetalleInteres">Detalle de Intereses</h4>
                                                                </div>
                                                                <div class="modal-body" id="div1" runat="server">
                                                                    <div class="row">
                                                                        <div class="col-md-12" id="divDetInteres">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="modal-footer" style="border-top-color: #e5e5e5;">
                                                                    <button data-dismiss="modal" class="btn btn-default">Volver</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:GridView ID="gvCtaTotal"
                                                        CssClass="table table-hover"
                                                        AutoGenerateColumns="false"
                                                        ShowHeader="false"
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
                                                    <asp:GridView ID="gvExport"
                                                        CssClass="table table-bordered table-hover dataTable"
                                                        AutoGenerateColumns="false"
                                                        ShowHeader="true"
                                                        OnRowDataBound="gvExport_RowDataBound"
                                                        GridLines="None"
                                                        runat="server">
                                                        <Columns>
                                                            <asp:BoundField DataField="ID" HeaderText="ID"
                                                                ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                                            <asp:TemplateField HeaderText="Periodo"
                                                                ItemStyle-Wrap="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPeriodo" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="VENCIMIENTO" HeaderText="VENCIMIENTO" DataFormatString="{0:d}" />
                                                            <asp:BoundField DataField="MONTO_ORIGINAL" DataFormatString="{0:c}" HeaderText="MONTO" />
                                                            <asp:BoundField DataField="DIAS_MORA" HeaderText="DIAS MORA" />
                                                            <asp:BoundField DataField="INTERES_MORA" DataFormatString="{0:c}" HeaderText="INTERES MORA" />
                                                            <asp:TemplateField HeaderText="PAGO A CUENTA">
                                                                <ItemTemplate>
                                                                    <div id="lblPagoCta" runat="server">
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="SALDO" DataFormatString="{0:c}" HeaderText="Total" />
                                                        </Columns>
                                                        <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                                                    </asp:GridView>
                                                    <asp:GridView ID="gvMovCtaCte"
                                                        CssClass="table table-bordered table-hover dataTable"
                                                        AutoGenerateColumns="false"
                                                        ShowHeader="true"
                                                        GridLines="None"
                                                        OnRowDataBound="gvMovCtaCte_RowDataBound"
                                                        runat="server">
                                                        <Columns>
                                                            <asp:BoundField DataField="ID" HeaderText="ID"
                                                                ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" />
                                                            <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:d}" />
                                                            <asp:BoundField DataField="DESCRIPCION" HeaderText="Concepto" />
                                                            <asp:BoundField DataField="DEBE" ItemStyle-ForeColor="Red" HeaderText="Debe" DataFormatString="{0:c}" />
                                                            <asp:BoundField DataField="HABER" DataFormatString="{0:c}" ItemStyle-ForeColor="Green" HeaderText="Haber" />
                                                            <asp:BoundField DataField="SALDO" DataFormatString="{0:c}" HeaderText="Total" />
                                                        </Columns>
                                                        <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <div class="row" id="divAsiento" runat="server">
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
                                                        id="btnPlanPago"
                                                        runat="server"
                                                        onclick="abrirPlanPago()"
                                                        class="btn btn-warning">
                                                        <span class="fa fa-money"></span>&nbsp;Plan de Pago
                                                    </button>
                                                    <button type="button"
                                                        class="btn btn-primary pull-right"
                                                        id="Button1" runat="server"
                                                        onserverclick="btnCambioFecha_ServerClick">
                                                        <span class="fa fa-money"></span>&nbsp;Acentar Pago
                                                    </button>
                                                </div>
                                            </div>

                                            <div class="modal fade in" id="modalPlanPago">
                                                <div class="modal-dialog">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                <span aria-hidden="true">×</span></button>
                                                            <h4 class="modal-title">Plan Pago</h4>
                                                        </div>
                                                        <div class="modal-body">
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label>Cantidad de cuotas</label>
                                                                        <asp:DropDownList ID="DDLCuotas" CssClass="form-control"
                                                                            runat="server">
                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                                            <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label>Fecha primera cuota</label>
                                                                        <asp:TextBox ID="txtFechaCupta" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label>TNA <small>(Tasa Nominal Anual)</small></label>
                                                                        <asp:TextBox Text="" ID="txtTasa" CssClass="form-control" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label>Sistema de Amortización</label>
                                                                        <asp:DropDownList ID="DDLAmortiza" CssClass="form-control" runat="server">
                                                                            <asp:ListItem Text="Frances" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Directo" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="modal-footer">
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancelar</button>
                                                                    <button type="button"
                                                                        class="btn btn-primary pull-right"
                                                                        id="btnAceptaPlanPago" runat="server"
                                                                        onserverclick="btnPlanPago_ServerClick">
                                                                        <span class="fa fa-money"></span>&nbsp;Aceptar
                                                                    </button>
                                                                </div>
                                                            </div>

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

                                            <%--   </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </div>
                                        <!-- /.tab-pane -->
                                        <div class="tab-pane" id="tab_3">
                                            <div class="row">

                                                <div class="col-md-12" style="display: none;">
                                                    <a class="btn btn-app btn-linkedin">
                                                        <i class="fa fa-home"></i>Club House
                                                    </a>
                                                    <a class="btn btn-app btn-dropbox">
                                                        <i class="fa fa-university"></i>S.U.M.
                                                    </a>
                                                    <a class="btn btn-app btn-vk">
                                                        <i class="fas fa-table-tennis" style="font-size: 20px;"></i>
                                                        <br />
                                                        Cancha Tenis
                                                    </a>
                                                    <a class="btn btn-app btn-bitbucket">
                                                        <i class="fa fa-futbol-o"></i>Cancha Futbol
                                                    </a>
                                                    <a class="btn btn-app btn-google">
                                                        <i class="fa fa-bullhorn"></i>Multas
                                                    </a>
                                                    <a class="btn btn-app btn-github">
                                                        <i class="fa fa-money-bill"></i>Facturacion
                                                    </a>
                                                </div>
                                            </div>

                                            <div class="box-header">
                                                <h3 class="box-title">Conceptos a inputar en proxima expensa</h3>

                                                <div class="box-tools pull-right">
                                                    <a class="btn btn-box-tool btn-bitbucket" style="font-size: 16px;"
                                                        data-toggle="modal" data-target="#modalConcepto">
                                                        <i class="fa fa-plus" style="font-size: 16px;"></i>&nbsp; Cargar Concepto
                                                    </a>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-top: 10px;">
                                                <div class="col-md-12">
                                                    <asp:GridView
                                                        ID="gvConceptos"
                                                        runat="server"
                                                        AutoGenerateColumns="false"
                                                        CellPadding="4"
                                                        CssClass="table table-bordered table-hover dataTable"
                                                        OnRowCommand="gvConceptos_RowCommand"
                                                        OnRowDataBound="gvConceptos_RowDataBound"
                                                        EmptyDataText="No se encontraron conceptos adicionales para la proxima liquidación"
                                                        ForeColor="#333333"
                                                        GridLines="None">
                                                        <Columns>
                                                            <asp:BoundField HeaderStyle-Width="10%" DataField="FECHA"
                                                                HeaderText="Fecha" DataFormatString="{0:d}" />
                                                            <asp:BoundField HeaderStyle-Width="10%" DataField="CANT"
                                                                HeaderText="Cantidad" />
                                                            <asp:BoundField DataField="DESC_CONCEPTO" HeaderText="Concepto" />
                                                            <asp:BoundField DataField="OBS" HeaderText="Obs." />
                                                            <asp:BoundField DataField="COSTO" DataFormatString="{0:c}"
                                                                ItemStyle-HorizontalAlign="Right" HeaderText="Precio Unit." />
                                                            <asp:BoundField DataField="SUBTOTAL" DataFormatString="{0:c}"
                                                                ItemStyle-HorizontalAlign="Right" HeaderText="Subtotal" />
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <div class="btn-group">
                                                                        <div class="btn-group">
                                                                            <button type="button" class="btn btn-info dropdown-toggle"
                                                                                data-toggle="dropdown">
                                                                                <span class="fa fa-bars"></span>
                                                                            </button>
                                                                            <ul class="dropdown-menu">
                                                                                <li id="btnEditar" runat="server"></li>
                                                                                <li>
                                                                                    <asp:LinkButton
                                                                                        ID="btnBorrar"
                                                                                        CommandArgument='<%#Eval("ID")%>'
                                                                                        runat="server"
                                                                                        OnClientClick="return confirm('Esta seguro de eliminar la liquidación')"
                                                                                        CommandName="borrar">
                                            <span class="fa fa-trash" style="font-size:20px;"></span>Eliminar
                                                                                    </asp:LinkButton>
                                                                                </li>
                                                                            </ul>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane" id="tab_4">
                                            <div class="box box-primary" id="divAltaDebito"
                                                runat="server">
                                                <div class="box-header">
                                                    <h3 class="box-title"></h3>
                                                </div>
                                                <div class="box-body">
                                                </div>
                                            </div>
                                            <div class="box box-primary" runat="server"
                                                id="divBajaDebito">
                                                <div class="box-header">
                                                    <asp:Button ID="btnBajaDebito" runat="server"
                                                        Text="Baja Débito"
                                                        CssClass="btn btn-danger pull-right" OnClick="btnBajaDebito_Click" />
                                                </div>
                                                <div class="box-body">
                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Banco</label>
                                                                <asp:DropDownList ID="DDLBancos"
                                                                    CssClass="form-control"
                                                                    AutoPostBack="true"
                                                                    OnSelectedIndexChanged="DDLBancos_SelectedIndexChanged"
                                                                    runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>CBU</label>
                                                                <asp:TextBox ID="txtCBU"
                                                                    CssClass="form-control"
                                                                    runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div id="divMacro" runat="server">
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label>Tipo Cuenta</label>
                                                                    <asp:DropDownList ID="DDLTipoCuenta"
                                                                        CssClass="form-control"
                                                                        runat="server">
                                                                        <asp:ListItem Text="Caja de Ahorro"
                                                                            Value="4"></asp:ListItem>
                                                                        <asp:ListItem Text="Cuenta Corriente"
                                                                            Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label>Nro. Sucursal</label>
                                                                    <asp:TextBox ID="txtSucursal"
                                                                        CssClass="form-control"
                                                                        runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label>Nro. Cuenta</label>
                                                                    <asp:TextBox ID="txtCuenta"
                                                                        CssClass="form-control"
                                                                        runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <asp:Button ID="btnAltaDebito"
                                                                OnClick="btnAltaDebito_Click"
                                                                CssClass="btn btn-primary"
                                                                runat="server" Text="Alta Debito" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.tab-content -->
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-footer" style="text-align: right;">
                            <div class="row">
                                <div class="col-md-12">
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- /.widget-user -->
                </div>
            </div>
            <!-- /.box -->
        </div>
    </section>
    <!-- /.content -->


    <div class="modal fade in" id="modalMail">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Cargar Mail</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Mail</label>
                        <asp:TextBox ID="txtMailCta" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnAcptarMailCta" CssClass="btn btn-primary"
                        OnClick="btnAcptarMailCta_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal modal-danger fade in" id="modalMailElimina">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Eliminar Mail</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Esta seguro de eliminar el mail</label>
                        <asp:TextBox ID="txtEliminaMail" Enabled="false" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnEliminarMail" CssClass="btn btn-outline"
                        OnClick="btnEliminarMail_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade in" id="modalConcepto">
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Cargar Concepto</h4>
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

    <div class="modal fade in" id="modalInmueble">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Inmueble</h4>
                </div>
                <div class="modal-body">
                    <div class="row" style="padding-top: 15px">
                        <div class="col-md-2">
                            <h4>Manzana</h4>
                            <asp:TextBox ID="txtManzanaCambiar" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h4>Lote</h4>
                            <asp:TextBox ID="txtLoteCambiar" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <h4>Calle</h4>
                            <asp:TextBox ID="txtCalleCambiar" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <h4>Nro.</h4>
                            <asp:TextBox ID="txtNroCambiar" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4>Denominacion catastral Municipal</h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label>Cir</label>
                            <asp:TextBox TextMode="Number" min="0" ID="txtCIR" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvcir" runat="server"
                                ControlToValidate="txtCIR"
                                ValidationGroup="catastral"
                                Display="Dynamic"
                                ErrorMessage="Ingrese la Circunscripción" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <label>Sec</label>
                            <asp:TextBox TextMode="Number" min="0" ID="txtSEC" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvsec" runat="server"
                                ControlToValidate="txtSEC"
                                Display="Dynamic"
                                ValidationGroup="catastral"
                                ErrorMessage="Ingrese la Sección" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            <label>Man</label>
                            <asp:TextBox TextMode="Number" min="0" ID="txtMAN" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvman" runat="server"
                                ControlToValidate="txtMAN"
                                ValidationGroup="catastral"
                                Display="Dynamic"
                                ErrorMessage="Ingrese la Manzana" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            <label>Par</label>
                            <asp:TextBox TextMode="Number" min="0" ID="txtPAR" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvpar" runat="server"
                                ControlToValidate="txtPAR"
                                Display="Dynamic"
                                ValidationGroup="catastral"
                                ErrorMessage="Ingrese la Parcela" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            <label>PH</label>
                            <asp:TextBox TextMode="Number" min="0" ID="txtPH" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvph" runat="server"
                                ControlToValidate="txtPH"
                                ValidationGroup="catastral"
                                Display="Dynamic"
                                ErrorMessage="Ingrese la PH" ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 15px">
                        <div class="col-md-12">
                            <h4>Nro. cuenta Rentas de la Provincia</h4>
                            <asp:TextBox ID="txtNRP" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="text-align: right;">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" runat="server"
                        validationgroup="catastral"
                        id="btnAceptarCatastral" onserverclick="btnAceptarCatastral_ServerClick">
                        Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade in" id="modalResponsable">
        <div class="modal-dialog modal-warning">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Cambiar responsable de facturación</h4>
                </div>
                <div class="modal-body">
                    <h4>Esta seguro de cambiar el responsable de facturación</h4>
                </div>
                <div class="modal-footer" style="text-align: right;">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-outline" runat="server" id="btnAceptarCambioResponsabilidad"
                        onserverclick="btnAceptarCambioResponsabilidad_ServerClick">
                        Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <!-- MODAL ADD PERSONA -->
    <div class="modal fade in" id="modalAddPersona">
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <div class="modal-header">
                    <a href="#" onclick="nuevaPersona()" class="btn btn-primary pull-right">
                        <span class="fa fa-plus-square"></span>Nueva Persona
                    </a>
                    <h4 class="modal-title">Agregar Persona</h4>
                </div>
                <div class="modal-body">
                    <div class="row" id="divListadoPersonas">
                        <div class="col-md-12">
                            <asp:GridView
                                ID="gvPersonasSeleccionar"
                                runat="server"
                                AutoGenerateColumns="false"
                                CellPadding="4"
                                CssClass="table table-bordered table-hover dataTable"
                                OnRowCommand="gvPersonasSeleccionar_RowCommand"
                                OnRowDataBound="gvPersonasSeleccionar_RowDataBound"
                                EmptyDataText="No se encontraron personas"
                                ForeColor="#333333"
                                GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="APELLIDO" HeaderText="Apellido" />
                                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                    <asp:BoundField DataField="NRO_DOC" HeaderText="Nro.Doc" />
                                    <asp:BoundField DataField="NRO_CUIT" HeaderText="C.U.I.T." />

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <a href="#"
                                                onclick="asignarPersona('<%#Eval("ID")%>')">
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
                    <div id="divDatosPersona" style="display: none;">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Relacion</label>
                                    <asp:DropDownList CssClass="form-control"
                                        ID="DDLRol" runat="server">
                                        <asp:ListItem Value="Propietario" Text="Propietario"></asp:ListItem>
                                        <asp:ListItem Value="Inquilino" Text="Inquilino"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
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
                                <button type="button" class="btn btn-primary" runat="server"
                                    id="btnAceptarAgregarPersona"
                                    onserverclick="btnAceptarAgregarPersona_ServerClick" validationgroup="alta">
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

    <div class="modal modal-danger fade in" id="modalEliminaRelacion">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Eliminar vínculo</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Esta seguro de eliminar el vínculo</label>
                        <asp:TextBox ID="txtVinculo" Enabled="false" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnEliminaVinculo" CssClass="btn btn-outline"
                        OnClick="btnEliminaVinculo_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal modal-primary fade in" id="modalCargaDeuda">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Cargar Deuda</h4>
                </div>
                <div class="modal-body">
                    <%--                    <asp:UpdatePanel ID="uPanlelCargaDeuda" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>--%>
                    <div class="form-group">
                        <label>Periodo</label>
                        <asp:DropDownList ID="DDLPeriodosDeuda"
                            OnSelectedIndexChanged="DDLPeriodosDeuda_SelectedIndexChanged"
                            AutoPostBack="true"
                            CssClass="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Deuda</label>
                        <asp:TextBox ID="txtDeuda" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Fecha ultimo pago</label>
                        <asp:TextBox ID="txtFechaUltimoPago"
                            TextMode="Date"
                            CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%--                        </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnCargarDeuda" CssClass="btn btn-outline"
                        OnClick="btnCargarDeuda_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>

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

    <div class="modal fade in" id="modalNotaDebito">
        <div class="modal-dialog modal-info">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Nota de Débito</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Monto</label>
                        <asp:TextBox CssClass="form-control"
                            ID="txtMontoNotaDebito"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Descripción</label>
                        <asp:TextBox ID="txtDescNotaDebito"
                            CssClass="form-control"
                            TextMode="MultiLine"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer" style="text-align: right;">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-outline" runat="server" id="btnAceptarNotaDebito"
                        onserverclick="btnAceptarNotaDebito_ServerClick">
                        Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade in" id="modalNotaCredito">
        <div class="modal-dialog modal-warning">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Nota de Crédito Interna</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Monto</label>
                        <asp:TextBox CssClass="form-control"
                            ID="txtMontoNotaCredito"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Descripción</label>
                        <asp:TextBox ID="txtDescNotaCredito"
                            CssClass="form-control"
                            TextMode="MultiLine"
                            runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer" style="text-align: right;">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-outline" runat="server"
                        id="btnAceptarNotaCredito"
                        onserverclick="btnAceptarNotaCredito_ServerClick">
                        Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div class="modal fade in" id="modal-default">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Emitir Nota de Crédito Fiscal</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Fecha Nota de Credito</label>
                        <asp:TextBox ID="txtFechaNC" TextMode="Date"
                            CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            ForeColor="Red"
                            ControlToValidate="txtFechaNC"
                            ValidationGroup="NCF"
                            runat="server" ErrorMessage="Ingrese la Fecha">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Monto</label>
                        <asp:TextBox ID="txtMonto"
                            CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvMonto"
                            ForeColor="Red"
                            ControlToValidate="txtMonto"
                            ValidationGroup="NCF"
                            runat="server" ErrorMessage="Ingrese el Monto">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Detalle</label>
                        <asp:TextBox ID="txtDescripcionNCFiscal"
                            CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            ForeColor="Red"
                            ControlToValidate="txtDescripcionNCFiscal"
                            ValidationGroup="NCF"
                            runat="server" ErrorMessage="Ingrese descripcion">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnEmitirNCFiscal"
                        OnClick="btnEmitirNCFiscal_Click"
                        CssClass="btn btn-primary"
                        ValidationGroup="NCF"
                        runat="server" Text="Aceptar" />

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
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
    <script src="../App_Themes/stacktable.js"></script>

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
            $("#modalAddPersona").on('hidden.bs.modal', function () {
                $("#divListadoPersonas").show('slow');
                $("#divDatosPersona").hide('slow');
            });

            //$('#ContentPlaceHolder1_DDLRol').on('change', function () {
            //    alert("La acción se puede lanzar aquí, ¿por qué no? " + this.value);
            //})
        });
        function abrirModalAddComprobante(ID, MONTO) {
            $('#modal-default').modal('show');
            //PERIODO
            $("#ContentPlaceHolder1_hIdCta").val(ID);
            $("#ContentPlaceHolder1_txtMonto").val(MONTO);
        }
        function abrirCargarDedua() {
            $('#modalCargaDeuda').modal('show');
        }
        function abrirAnulaComprobante(nro_recibo) {
            $('#modalAnulaComprobante').modal('show');
            $("#ContentPlaceHolder1_hNroRecibo").val(nro_recibo);
        }
        function abrirPlanPago() {
            $('#modalPlanPago').modal('show');
        }

        function abreDetalleInteres(fechaVenc, monto, cta, periodo, pagoCta) {

            var js = '{fechaVenc: "' + fechaVenc + '", monto: "' + monto + '", cta: "' + cta + '", periodo: "' + periodo + '", pagoCta: "' + pagoCta + '"}';
            $.ajax({
                async: false,
                type: "POST",
                url: "inmueble.aspx/addDetInteres",
                data: js,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: resultadoValida,
                error: errores
            });
        }
        function resultadoValida(msg) {
            $('#divDetInteres').html(msg.d);
            $('#modalDetalleInteres').modal('show');

        }
        function abreDetallePagoCta(cta, periodo, id) {

            var js = '{cta: "' + cta + '", periodo: "' + periodo + '", id: "' + id + '"}';
            $.ajax({
                async: false,
                type: "POST",
                url: "inmueble.aspx/addDetPagoCta",
                data: js,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: resultadoValida2,
                error: errores
            });
        }
        function resultadoValida2(msg) {
            $('#divPagoCta').html(msg.d);
            $('#modalPagoCta').modal('show');
        }
        function errores(msg) {
            //msg.responseText tiene el mensaje de error enviado por el servidor
            alert('Error: ' + msg.responseText);
        }
        function verDetalle(ID) {
            var tr = $('#<%=gvCtaCte.ClientID%> tr[orderid =' + ID + ']');
            tr.toggle();

            if (tr.is(':visible')) {
                $("#" + ID).removeAttr('class');
                $("#" + ID).attr('class', 'fa fa-minus-circle');
            }
            else {
                $("#" + ID).removeAttr('class');
                $("#" + ID).attr('class', 'fa fa-plus-circle');
            }
        }
    </script>
    <script>    
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvExport.ClientID %>').DataTable(
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
            $('#' + '<%=gvMovCtaCte.ClientID %>').DataTable(
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
            $('#' + '<%=gvPersonasSeleccionar.ClientID %>').DataTable(
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
            $('#<%=gvCtaCte.ClientID %>').cardtable();
            $('#<%=gvCtaTotal.ClientID %>').cardtable();
        });
        function calSubTotal() {
            var preUni = parseFloat($("#ContentPlaceHolder1_txtCostoUnit").val());
            var cant = parseFloat($("#ContentPlaceHolder1_txtCantConcept").val());

            $("#ContentPlaceHolder1_txtTot").val(cant * preUni);
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
        function asignarPersona(ID) {
            $("#divListadoPersonas").hide('slow');
            $("#divDatosPersona").show('slow');
            $("#ContentPlaceHolder1_hIdPersona").val(ID);

        }
        function abrirAcentarPago() {
            $('#modalPago').modal('show');
        }
        function abrirModalMail(ID, MAIL) {
            $('#modalMail').modal('show');
            //ID
            $("#ContentPlaceHolder1_hIdMail").val(ID);
            $("#ContentPlaceHolder1_txtMailCta").val(MAIL);

        }
        function abrirModalEliminaMail(ID, MAIL) {
            $('#modalMailElimina').modal('show');
            //ID
            $("#ContentPlaceHolder1_hIdEliminaMail").val(ID);
            $("#ContentPlaceHolder1_txtEliminaMail").val(MAIL);

        }
        function abrirModalEliminaVinculo(ID, VINCULO) {
            $('#modalEliminaRelacion').modal('show');
            //ID
            $("#ContentPlaceHolder1_hIdPersonaElimina").val(ID);
            $("#ContentPlaceHolder1_txtVinculo").val(VINCULO);

        }
        function abreModalPagoCta() {
            $('#modalPagoCta').modal('show');
        }
        function nuevaPersona() {
            window.location.href = "Persona.aspx?nrocta=" + $("#ContentPlaceHolder1_hIdCta").val();
        }
        function abrirModalEdit() {
            $('#modalInmueble').modal('show');
            //ID
            $("#ContentPlaceHolder1_txtManzanaCambiar").val($("#ContentPlaceHolder1_hMan").val());
            $("#ContentPlaceHolder1_txtLoteCambiar").val($("#ContentPlaceHolder1_hLot").val());
            $("#ContentPlaceHolder1_txtCalleCambiar").val($("#ContentPlaceHolder1_hDir").val());
            $("#ContentPlaceHolder1_txtNroCambiar").val($("#ContentPlaceHolder1_hNro").val());
            $("#ContentPlaceHolder1_txtCIR").val($("#ContentPlaceHolder1_hCir").val());
            $("#ContentPlaceHolder1_txtSEC").val($("#ContentPlaceHolder1_hSec").val());
            $("#ContentPlaceHolder1_txtMAN").val($("#ContentPlaceHolder1_hManz").val());
            $("#ContentPlaceHolder1_txtPAR").val($("#ContentPlaceHolder1_hPar").val());
            $("#ContentPlaceHolder1_txtPH").val($("#ContentPlaceHolder1_HPh").val());
            $("#ContentPlaceHolder1_txtNRP").val($("#ContentPlaceHolder1_hNroRentas").val());
        }
        function abrirModalResponsable(IDPERSONA) {
            $('#modalResponsable').modal('show');
            //ID
            $("#ContentPlaceHolder1_hIdPersona").val(IDPERSONA);
        }

        function abrirModalNotaDebito() {
            $('#modalNotaDebito').modal('show');
        }
        function abrirModalNotaCredito() {
            $('#modalNotaCredito').modal('show');
        }
    </script>
</asp:Content>
