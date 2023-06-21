<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="CarnetConfig.aspx.cs" Inherits="PortalServicios.BackEnd.CarnetConfig" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-app {
            border-radius: 3px;
            position: relative;
            padding: 25px 25px;
            margin: 0 0 10px 10px;
            min-width: 100px;
            height: 100px;
            text-align: center;
            color: #666;
            border: 1px solid #ddd;
            background-color: #f4f4f4;
            font-size: 18px;
        }

            .btn-app > .fa, .btn-app > .glyphicon, .btn-app > .ion {
                font-size: 30px;
                display: block;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="divOpciones" runat="server">
        <div class="col-md-10 col-md-offset-1" style="text-align: center;">
            <a class="btn btn-app" id="btnConfigurarHorarios" runat="server" onserverclick="btnConfigurarHorarios_ServerClick">
                <i class="fa fa-clock-o"></i>Horarios
            </a>
            <a class="btn btn-app" href="DiasNoLaborales.aspx">
                <i class="fa fa-calendar-o"></i>Dias No Laborables
            </a>
<%--            <a class="btn btn-app">
                <i class="fa fa-calendar"></i>Horarios Especiales
            </a>--%>
        </div>
    </div>
    <div class="row" id="divHorarios" visible="false" runat="server">
        <div class="col-md-10 col-md-offset-1">
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Configuracion de Horarios de Atencion</h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <asp:GridView ID="gvHorarios" 
                        runat="server" CellPadding="4" 
                        DataKeyNames="DIA"
                        ForeColor="#333333" GridLines="None" 
                        CssClass="table table-condensed"
                        OnRowCommand="gvHorarios_RowCommand"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="DIA" HeaderText="DIA"></asp:BoundField>
                            <asp:TemplateField HeaderText="PRIMER TURNO">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHoraInicio" CssClass="form-control" TextMode="Time" Text=' <%# Eval("HORA_INICIO") %> ' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ULTIMO TURNO">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHoraCierre" CssClass="form-control" TextMode="Time" Text=' <%# Eval("HORA_CIERRE") %> ' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="INTERVALO">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHoraIntervalo" CssClass="form-control" TextMode="Number" Text=' <%# Eval("INTERVALO") %> ' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CANT. BOX DE ATENCION">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHoraTurnosSimultaneos" CssClass="form-control" min="1" TextMode="Number" Text=' <%# Eval("TURNOS_SIMULTANEOS") %> ' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CommandName="actualizar" 
                                       CommandArgument='<%# Container.DataItemIndex %>'  CssClass="btn btn-success"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <EditRowStyle BackColor="#999999"></EditRowStyle>
                        <FooterStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></FooterStyle>
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>
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
                <div class="box-footer clearfix">
                    <ul class="pagination pagination-sm no-margin pull-right">
                        <li>
                            <asp:Button ID="btnCancelarHorarios" CssClass="btn btn-warning" runat="server"
                                Text="Volver" OnClick="btnCancelarHorarios_Click" /></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery 2.1.4 -->
    <script src="../../App_Themes/plugins/jQuery/jQuery-2.1.4.min.js"></script>

    <!-- Bootstrap 3.3.2 JS -->
    <script src="../../App_Themes/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript">
       
    </script>
    <!-- AdminLTE App -->
    <script src="../../App_Themes/dist/js/app.min.js" type="text/javascript"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../../App_Themes/dist/js/demo.js" type="text/javascript"></script>
</asp:Content>
