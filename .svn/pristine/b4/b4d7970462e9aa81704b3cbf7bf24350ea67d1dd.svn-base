<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="cuentas.aspx.cs" Inherits="LaHerradura.Back.cuentas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link href="../App_Themes/stacktable.css?v=1.0" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Main content -->
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
                        <h2 class="widget-user-username"
                            style="margin-top: 15px; margin-bottom: 15px;">Inmuebles</h2>
                    </div>
                    <div class="box-body" style="padding: 20px;">
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                <asp:GridView
                                    ID="gvCtas"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CellPadding="4"
                                    CssClass="table table-bordered table-hover dataTable"
                                    OnRowDataBound="gvCtas_RowDataBound"
                                    ForeColor="#333333"
                                    GridLines="None">
                                    <Columns>
                                        <asp:BoundField HeaderStyle-Width="10%" DataField="NRO_CTA" HeaderText="Cuenta" />
                                        <asp:BoundField HeaderStyle-Width="10%" DataField="MANZANA" HeaderText="Manzana" />
                                        <asp:BoundField HeaderStyle-Width="10%" DataField="LOTE" HeaderText="Lote" />
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
                                        <asp:TemplateField HeaderText="Responsables">
                                            <ItemTemplate>
                                                <ul class="nav nav-stacked" id="ulMails" runat="server">
                                                </ul>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SALDO" ItemStyle-Wrap="false" DataFormatString="{0:c}"
                                            ItemStyle-HorizontalAlign="Right" HeaderText="Saldo" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a href="inmueble.aspx?nrocta=<%#Eval("NRO_CTA")%>">
                                                    <span class="fa fa-edit" style="font-size: 20px;"></span>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#00a7d0" ForeColor="White" />
                                </asp:GridView>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="box-footer">
                    </div>
                </div>
                <!-- /.widget-user -->
            </div>
        </div>
        <!-- /.box -->
    </section>
    <!-- /.content -->
    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js?v=1"></script>
        <script src="../App_Themes/stacktable.js"></script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvCtas.ClientID %>').DataTable(
                {
initComplete: function() {
            $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
        },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"
                    }
                }
            );
            $('#<%=gvCtas.ClientID %>').cardtable();
        });
        // Code that uses other library's $ can follow here.
    </script>
</asp:Content>
