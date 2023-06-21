<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="EnvioComprobantes.aspx.cs" Inherits="LaHerradura.Back.EnvioComprobantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        label {
            padding-left: 5px;
            font-weight: 500;
        }
        /* custom checkbox */
        .checkbox {
            display: block;
            position: relative;
            margin-bottom: 12px;
            cursor: pointer;
            font-size: 22px;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

            /* hide the browser's default checkbox */
            .checkbox input {
                position: absolute;
                opacity: 0;
                cursor: pointer;
            }

        /* create custom checkbox */
        .check {
            position: absolute;
            top: 0;
            height: 25px;
            width: 25px;
            background-color: #eee;
            border: 1px solid #ccc;
        }

        /* on mouse-over, add border color */
        .checkbox:hover input ~ .check {
            border: 2px solid #2489C5;
        }

        /* add background color when the checkbox is checked */
        .checkbox input:checked ~ .check {
            background-color: #2489C5;
            border: none;
        }

        /* create the checkmark and hide when not checked */
        .check:after {
            content: "";
            position: absolute;
            display: none;
        }

        /* show the checkmark when checked */
        .checkbox input:checked ~ .check:after {
            display: block;
        }

        /* checkmark style */
        .checkbox .check:after {
            left: 9px;
            top: 5px;
            width: 5px;
            height: 10px;
            border: solid white;
            border-width: 0 3px 3px 0;
            -webkit-transform: rotate(45deg);
            -ms-transform: rotate(45deg);
            transform: rotate(45deg);
        }
    </style>

    <style>
        .headerDerecha {
            text-align: right;
        }

        input[type=checkbox] {
            /* Doble-tamaño Checkboxes */
            -ms-transform: scale(2.5); /* IE */
            -moz-transform: scale(2.5); /* FF */
            -webkit-transform: scale(2.5); /* Safari y Chrome */
            -o-transform: scale(2.5); /* Opera */
            padding: 10px;
        }

        /* Tal vez desee envolver un espacio alrededor de su texto de casilla de verificación */
        .checkboxtexto {
            /* Checkbox texto */
            font-size: 110%;
            display: inline;
        }

        td {
            border-top: 1px solid #bdbdbd !important;
            display: table-cell;
            vertical-align: middle !important;
        }

        @media (max-width: 800px) {
            .ocultar {
                display: none;
            }

            .ocultarHeader {
                display: none;
            }

            .margenHeader {
                margin-left: 0px !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="uPanel" UpdateMode="Conditional" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnEnvioMail"/>
        </Triggers>
        <ContentTemplate>
            <div class="row" style="display: none;">
                <div class="col-md-12">
                    <asp:GridView DataKeyNames="NRO_CTA, ID" ID="gvConfirmoEnvios" runat="server"></asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-primary">
                        <div class="box-header">
                            <h3>Envio de comprobantes</h3>
                            <h4 id="lblTitulo" runat="server"></h4>
                        </div>
                        <div class="box-body" style="padding: 20px;">

                            <asp:GridView ID="gvCtaCte"
                                CssClass="table"
                                ShowHeader="false"
                                OnRowCommand="gvCtaCte_RowCommand"
                                GridLines="None"
                                DataKeyNames="NRO_RECIBO_PAGO, NRO_CTA"
                                AutoGenerateColumns="false"
                                OnRowDataBound="gvCtaCte_RowDataBound"
                                runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <label class="checkbox" id="lblCheck" runat="server">
                                                <asp:CheckBox ID="chkSelect"
                                                    runat="server"
                                                    Checked="true"
                                                    AutoPostBack="true"
                                                    OnCheckedChanged="chkSelect_CheckedChanged" />
                                                <span class="check"></span>
                                            </label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Periodo"
                                        ItemStyle-Wrap="true">
                                        <ItemTemplate>
                                            <div id="divPeriodo" runat="server">
                                            </div>
                                            <div id="divDet" runat="server">
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEnviado" runat="server"
                                                CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                OnClientClick="return confirm('¿Esta seguro de marcar el comprobante como enviado?');">
                                                <span class="fa fa-remove" style="color:red"
                                                    title="Marcar como enviado"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BorderColor="LightGray" BackColor="#00a7d0" ForeColor="White" Font-Bold="false" />
                                <RowStyle BorderColor="LightGray" />
                            </asp:GridView>
                            <button type="button" class="btn btn-primary pull-right" data-toggle="modal"
                                style="margin-top: 15px;" data-target="#modal-default">
                                <span class="fa fa-envelope"></span>&nbsp;&nbsp;Enviar Mail
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade in" id="modal-default">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                            <h4 class="modal-title">Confirmación envío de comprobantes</h4>
                        </div>
                        <div class="modal-body">
                            <p id="lblCantComp" runat="server"></p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancelar</button>
                            <asp:LinkButton ID="btnEnvioMail" CssClass="btn btn-primary"
                                OnClientClick="this.disabled=true;this.value = 'Enviando mails...'" UseSubmitBehavior="false"
                                OnClick="btnEnvioMail_Click" runat="server">
                        <span class="fa fa-envelope"></span>&nbsp;&nbsp;Enviar Mail
                            </asp:LinkButton>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
