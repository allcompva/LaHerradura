<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="ExcluyeConcepto.aspx.cs" Inherits="LaHerradura.Back.ExcluyeConcepto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="margin-top: 25px; ">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title" runat="server" id="lblConcepto"></h3>
                </div>
                <div class="box-body" style="display: none;">
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Cantidad</label>
                                <asp:TextBox runat="server" ID="txtCantConcept"
                                    CssClass="form-control" TextMode="Number"
                                    onchange="calSubTotal()"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Concepto</label>
                                <asp:TextBox CssClass="form-control" Enabled="false"
                                    ID="txtConcepto" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Pre. Unit</label>
                                <asp:TextBox ID="txtCostoUnit" CssClass="form-control"
                                    runat="server" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Total</label>
                                <asp:TextBox ID="txtTot" Enabled="false"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Observaciones</label>
                                <asp:TextBox ID="txtObsConcepto"
                                    TextMode="MultiLine"
                                    CssClass="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                    <asp:Button ID="btnActualiza" CssClass="btn btn-primary pull-right" runat="server"
                        Text="Actualizar" OnClick="btnActualiza_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="row" style="margin-top: 25px;">
        <div class="col-md-6">
            <div class="box box-success">
                <div class="box-header with-border">
                    <h3 class="box-title">Cuentas Incluidas</h3>
                </div>
                <div class="box-body">
                    <asp:GridView
                        ID="gvCtas"
                        runat="server"
                        AutoGenerateColumns="false"
                        CellPadding="4"
                        CssClass="table"
                        OnRowDataBound="gvCtas_RowDataBound"
                        OnRowCommand="gvCtas_RowCommand"
                        ForeColor="#333333"
                        GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Mza-Lte">
                                <ItemTemplate>
                                    <span><%#Eval("MANZANA")%> - <%#Eval("LOTE")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Direccion">
                                <ItemTemplate>
                                    <span><%#Eval("CALLE")%> <%#Eval("NRO")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Responsables">
                                <ItemTemplate>
                                    <ul class="nav nav-stacked" id="ulResponsables" runat="server">
                                    </ul>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnExcluir"
                                        CommandArgument='<%#Eval("NRO_CTA")%>'
                                        CommandName="excluir"
                                        runat="server">
                                            <span class="fa fa-hand-o-right" style="font-size: 20px;"></span>
                                    </asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="box box-danger">
                <div class="box-header with-border">
                    <h3 class="box-title">Cuentas Excluidas</h3>
                </div>
                <div class="box-body">
                    <asp:GridView
                        ID="gvCtasExcluidas"
                        runat="server"
                        AutoGenerateColumns="false"
                        CellPadding="4"
                        OnRowCommand="gvCtasExcluidas_RowCommand"
                        OnRowDataBound="gvCtas_RowDataBound"
                        CssClass="table table-bordered table-hover dataTable"
                        ForeColor="#333333"
                        GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Mza-Lte">
                                <ItemTemplate>
                                    <span><%#Eval("MANZANA")%> - <%#Eval("LOTE")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Direccion">
                                <ItemTemplate>
                                    <span><%#Eval("CALLE")%> <%#Eval("NRO")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Responsables">
                                <ItemTemplate>
                                    <ul class="nav nav-stacked" id="ulResponsables" runat="server">
                                    </ul>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnIncluir"
                                        CommandArgument='<%#Eval("NRO_CTA")%>'
                                        CommandName="incluir"
                                        runat="server">
                                            <span class="fa fa-hand-o-left" style="font-size: 20px;"></span>
                                    </asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvCtas.ClientID %>').DataTable(
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
            $('#' + '<%=gvCtasExcluidas.ClientID %>').DataTable(
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
</asp:Content>
