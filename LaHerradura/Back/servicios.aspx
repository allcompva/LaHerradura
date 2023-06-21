<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="servicios.aspx.cs" Inherits="LaHerradura.Back.servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: 25px;">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Servicios</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <asp:GridView
                        CssClass="table table-hover"
                        ID="gvServicios"
                        runat="server"
                        CellPadding="4"
                        ForeColor="#333333"
                        AutoGenerateColumns="false"
                        GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="DESCRIPCION" HeaderText="Servicio" />
                            <asp:BoundField DataField="COSTO" HeaderText="Costo" />
                            <asp:BoundField DataField="CANT_PERSONAS" HeaderText="Invitados Maximos" />
                            <asp:BoundField DataField="ADICIONAL" HeaderText="Guardia Adicional por mas invitados" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="btn-group">
                                        <div class="btn-group">
                                            <button type="button" class="btn btn-info dropdown-toggle"
                                                data-toggle="dropdown">
                                                <span class="fa fa-bars"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li>
                                                    <a ></a>
                                                </li>
                                                <li id="btnEditar" runat="server">
                                                    <a href="#"
                                                        onclick="abrirModalAdd('<%#Eval("PERIODO")%>','<%#Eval("VENCIMIENTO_1")%>', 
                                                            '<%#Eval("MONTO_1")%>','<%#Eval("VENCIMIENTO_2")%>','<%#Eval("MONTO_2")%>', 
                                                            '<%#Eval("VENCIMIENTO_3")%>','<%#Eval("MONTO_3")%>','<%#Eval("ALICUOTA_INTERES")%>')">
                                                        <span style="font-size: 20px;" class="fa fa-edit"></span>
                                                        Editar
                                                    </a>
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
                                            </ul>
                                        </div>
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
                </div>
                <!-- /.box-body -->
                <div class="box-footer text-center">
                </div>
                <!-- /.box-footer -->
            </div>
        </div>
    </div>

</asp:Content>
