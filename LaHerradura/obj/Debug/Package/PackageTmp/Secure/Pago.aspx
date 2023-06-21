<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPVecino.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="LaHerradura.Secure.Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link href="../App_Themes/stacktable.css?v=1.0" rel="stylesheet" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=si" name="viewport" />
    <link href="../App_Themes/stacktable.css?v=1.0" rel="stylesheet" />
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
    
    <style>
        .st-key {
            display: none;
        }

        .bg-green, .callout.callout-success, .alert-success, .label-success, .modal-success .modal-body {
            background-color: transparent !important;
        }


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
            border-top: none !important;
            display: table-cell;
            /*vertical-align: middle !important;*/
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
    <asp:HiddenField ID="hNroCta" runat="server" />
    <div class="box box-widget widget-user-2">
        <div class="widget-user-header bg-aqua-active" style="background-color: #3c8dbc !important; border-top-right-radius: 25px; border-top-left-radius: 25px;">
            <div class="widget-user-image ocultarHeader">
                <img class="img-circle" src="../App_Themes/img/inm.png" />
            </div>
            <!-- /.widget-user-image -->
            <h3 style="font-size: 24px; padding-right: 15px; margin-right: 15px;"
                class="widget-user-username margenHeader" id="lblDireccion" runat="server"></h3>

            <h5 class="widget-user-desc margenHeader" style="font-size: 18px; font-weight: 700;"
                id="lblCta" runat="server"></h5>
            <h5 class="widget-user-desc margenHeader" style="font-size: 14px; font-weight: 500;"
                id="lblCatastrales" runat="server"></h5>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hMontoOriginalBilletera" runat="server" />
            <div class="row" style="margin-left: 0; margin-right: 0; display:none;">
                <div class="colmd-12">
                    <div class="callout callout-warning">
                        <h4 style="font-size: 20px;">Informacion Importante!</h4>
                        <p style="font-size: 18px;">Estimado vecino queremos informale que a partir del día de la fecha se encuentra disponible el pago on line de sus expensas.</p>
                        <p style="font-size: 18px;">Toda consulta y/o reclamo de funcionamiento del sitio sera atendida a partir del dia lunes 04/01/2021 (Primer día habil del mes)</p>
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
                                                 Enabled="false"
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
                                        OnCheckedChanged="chkSelect_CheckedChanged1" />
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
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active">
                                <a href="#tab_1" data-toggle="tab">Cuenta Corriente</a>
                            </li>
                            <li>
                                <a href="#tab_2" data-toggle="tab">Mis comprobantes</a>
                            </li>
                            <li>
                                <a href="#" class="btn btn-success" runat="server"
                                    onserverclick="btnLibreDeuda_ServerClick"
                                    visible="false"
                                    id="btnLibreDeuda">
                                    <span class="fa fa-download">&nbsp;
                                        Libre Deuda</span>
                                </a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_1">

                                <div class="row">
                                    <div class="col-md-8">
                                        <asp:GridView ID="gvCtaCte"
                                            CssClass="table"
                                            EmptyDataText="Al dia de la fecha su cuenta no presenta deuda"
                                            ShowHeader="false"
                                            GridLines="None"
                                            DataKeyNames="ID"
                                            AutoGenerateColumns="false"
                                            OnRowDataBound="gvCtaCte_RowDataBound"
                                            runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hidden"
                                                    HeaderStyle-CssClass="hidden" />

                                                <asp:TemplateField HeaderText="Periodo"
                                                    ItemStyle-Wrap="true">
                                                    <ItemTemplate>
                                                        <div id="divPeriodo" runat="server">
                                                            <div>
                                                                <%#Eval("PERIODOMAQUILLADO")%>
                                                                <hr style="margin-top: 5px; margin-bottom: 5px; border-top: 1px solid #d2cfcf;" />
                                                            </div>
                                                        </div>
                                                        <div id="divDet" runat="server">
                                                            <%#Eval("DETALLE_DEUDA")%>
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
                                                        <label class="checkbox" id="lblCheck" runat="server">
                                                            <asp:CheckBox ID="chkSelect"
                                                                runat="server"
                                                                AutoPostBack="true"
                                                                OnCheckedChanged="chkSelect_CheckedChanged" />
                                                            <span class="check"></span>
                                                        </label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div id="divPeriodo2" runat="server"></div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <tr style="display: none; background-color: white;" orderid="<%#Eval("ID")%>">
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
                                            <HeaderStyle BorderColor="LightGray" BackColor="#00a7d0" ForeColor="White" Font-Bold="false" />
                                            <RowStyle BorderColor="LightGray" />
                                        </asp:GridView>
                                    </div>
                                    <div class="col-md-4" id="divAsiento"
                                        runat="server">
                                        <div class="box box-primary" style="border-top-left-radius: 20%; border-top-right-radius: 20%; box-shadow: 3px -1px 10px 0px rgba(0,0,0,0.1); padding: 10px;">
                                            <div class="box-header" style="text-align: center">
                                                <span class="fa fa-credit-card" style="font-size: 40px; color: #00a7d0; border: 2px solid #3c8dbc!important; padding: 15px; border-radius: 50%;"></span>
                                                <h3 style="color: #2489c5;">Pago en línea</h3>
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
                                                                    Total a Pagar:
                                                                                        <span class="pull-right">$</span>
                                                                </div>
                                                            </td>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblDeudaPagar"
                                                                    Font-Bold="true" Font-Size="14"
                                                                    ForeColor="GrayText" runat="server" Text="0"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label1" Font-Bold="true" Font-Size="8"
                                                                    ForeColor="GrayText" runat="server" Text="De">
                                                                </asp:Label>
                                                                <asp:Label ID="lblCantSelecionados" Font-Bold="true" Font-Size="8"
                                                                    ForeColor="GrayText" runat="server" Text=""></asp:Label>
                                                                <asp:Label ID="Label3" Font-Bold="true" Font-Size="8"
                                                                    ForeColor="GrayText" runat="server" Text="Obligaciones seleccionadas">
                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center; padding-top: 25px;">
                                                                <asp:LinkButton ID="btnPagar"
                                                                    OnClick="btnPagar_Click"
                                                                    Style="font-size: 20px; padding: 10px; width: 50%; border-radius: 25px;"
                                                                    CssClass="btn btn-bitbucket" runat="server">
                                                <span class="fa fa-dollar"></span>&nbsp;Pagar</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <!-- /.box-body -->
                                        </div>


                                        <br />
                                        <asp:Label ID="lblMensaje" ForeColor="Red" runat="server" Text="">

                                        </asp:Label>
                                        <br />
                                        <%--<a href="#" onclick="abrirAcentarPago()"
                                                                class="btn btn-primary pull-right">Acentar Pago</a>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_2">
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="gvComprobantes"
                                            AutoGenerateColumns="false"
                                            GridLines="None"
                                            OnRowDataBound="gvComprobantes_RowDataBound"
                                            CssClass="table" runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div id="divComprobantes" runat="server">
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
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
                                    DataKeyNames="ID"
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
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js"></script>

    <script src="../App_Themes/stacktable.js"></script>

    <script>
        $('#<%=gvComprobantes.ClientID %>').cardtable();
    </script>
    <script>
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
</asp:Content>
