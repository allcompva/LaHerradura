﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="ConceptosExpensa.aspx.cs" Inherits="LaHerradura.Back.ConceptosExpensa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hId" runat="server" />
    <div class="row" style="margin-top: 40px;">
        <div class="col-md-10 col-md-offset-1">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Conceptos Expensa</h3>
                </div>
                <button type="button" style="font-size: 18px; padding: 10px;"
                    onclick="abrirModalEdit('', '', '1', '0', '0','0');" class="btn btn-app btn-bitbucket">
                    <span style="font-size: 20px;" class="fa fa-plus"></span>Agregar Concepto
                </button>
                <div class="box-body">
                    <div class="alert alert-success alert-dismissible" id="divMensajeOk" runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                        <h5><i class="icon fas fa-check"></i>Felicidades!</h5>
                        <div id="txtMensaje" runat="server"></div>
                    </div>
                    <div class="alert alert-danger alert-dismissible" id="divMensajeError" runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                        <h5><i class="icon fas fa-ban"></i>Error!</h5>
                        <div id="txtMensajeError" runat="server"></div>
                    </div>
                    <asp:GridView
                        ID="gvConceptos"
                        runat="server"
                        AutoGenerateColumns="false"
                        CellPadding="4"
                        CssClass="table table-bordered table-hover dataTable"
                        OnRowCommand="gvConceptos_RowCommand"
                        OnRowDataBound="gvConceptos_RowDataBound"
                        EmptyDataText="No se encontraron conceptos"
                        ForeColor="#333333"
                        GridLines="None">
                        <Columns>
                            <asp:BoundField HeaderStyle-Width="10%" DataField="ID"
                                HeaderText="Cod." />
                            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" />
                            <asp:TemplateField HeaderText="CARGO/DESCUENTO">
                                <ItemTemplate>
                                    <asp:Label ID="lblSuma" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TIPO">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipo" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MONTO" DataFormatString="{0:c}"
                                ItemStyle-HorizontalAlign="Right" HeaderText="Monto" />
                            <asp:BoundField DataField="PORCENTAJE" DataFormatString="{0:c}"
                                ItemStyle-HorizontalAlign="Right" HeaderText="Porcentaje" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <div class="btn-group">
                                        <div class="btn-group">
                                            <button type="button" class="btn btn-info dropdown-toggle"
                                                data-toggle="dropdown">
                                                <span class="fa fa-bars"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li id="btnEditar" runat="server">
                                                    <a href="#"
                                                        onclick="abrirModalEdit('<%#Eval("ID")%>','<%#Eval("DESCRIPCION")%>', 
                                                            '<%#Eval("SUMA")%>','<%#Eval("MONTO")%>','<%#Eval("PORCENTAJE")%>',
                                                        '<%#Eval("TIPO")%>')">
                                                        <span style="font-size: 20px;" class="fa fa-edit"></span>
                                                        Editar
                                                    </a>
                                                </li>
                                                <li>
                                                    <asp:LinkButton
                                                        ID="btnActivar"
                                                        CommandArgument='<%#Eval("ID")%>'
                                                        runat="server"
                                                        CommandName="activar">
                                            <span class="fa fa-eye-slash" style="font-size:20px;"></span>Activar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton
                                                        ID="btnDesactivar"
                                                        CommandArgument='<%#Eval("ID")%>'
                                                        runat="server"
                                                        CommandName="desactivar">
                                            <span class="fa fa-eye" style="font-size:20px;"></span>Desactivar
                                                    </asp:LinkButton>
                                                </li>
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
    </div>


    <div class="modal fade in" id="modalConcepto">
        <div class="modal-dialog" style="width: 60%;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Agregar Concepto</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Descripcion</label>
                                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rv1" runat="server" ForeColor="Red"
                                ControlToValidate="txtDescripcion" ValidationGroup="alta"
                                ErrorMessage="Ingrese la descripcion del concepto"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Comportamiento</label>
                                <asp:DropDownList ID="DDLSuma" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Cargo" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Descuento" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Aplica</label>
                                <asp:DropDownList ID="DDLForma" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Monto fijo" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Porcentaje" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Monto</label>
                                <asp:TextBox CssClass="form-control" ID="txtMonto" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rv2" runat="server" ForeColor="Red"
                                ControlToValidate="txtDescripcion" ValidationGroup="alta"
                                ErrorMessage="Ingrese el monto"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Tipo</label>
                                <asp:DropDownList ID="DDLTipo" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Individual" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Masivo" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="text-align: right;">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" runat="server" id="btnAceptar"
                        onserverclick="btnAceptar_ServerClick" validationgroup="alta">
                        Aceptar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvConceptos.ClientID %>').DataTable(
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
    </script>
    <script>    
        function abrirModalEdit(ID, DESCRIPCION, SUMA, MONTO, PORCENTAJE, TIPO) {
            $('#modalConcepto').modal('show');

            $("#ContentPlaceHolder1_DDLSuma option[value=" + SUMA + "]").attr("selected", true);

            if (MONTO == '0.00') {
                $("#ContentPlaceHolder1_DDLForma option[value=1]").attr("selected", true);
                $("#ContentPlaceHolder1_txtMonto").val(PORCENTAJE);
            }
            else {
                $("#ContentPlaceHolder1_DDLForma option[value=0]").attr("selected", true);
                $("#ContentPlaceHolder1_txtMonto").val(MONTO);
            }
            if (TIPO == '0') {
                $("#ContentPlaceHolder1_DDLTipo option[value=0]").attr("selected", true);
            }
            else {
                $("#ContentPlaceHolder1_DDLTipo option[value=1]").attr("selected", true);
            }

            //ACCION
            $("#ContentPlaceHolder1_hId").val(ID);
            //PERIODO
            $("#ContentPlaceHolder1_txtDescripcion").val(DESCRIPCION);


        }
    </script>
</asp:Content>
