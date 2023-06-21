<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="ReservaCH.aspx.cs" Inherits="PortalServicios.BackEnd.CarnetAddTurno2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        label {
            padding-left: 10px;
        }
    </style>
    <script type="text/javascript">
        function deshabilitar(b) {
            b.style.display = 'none';
            document.getElementById("btnCancel").style.display = 'none';
            document.getElementById("divProgreso").style.display = 'block';
            return true;
        }
        function habilitar(b) {
            var aceptar = document.getElementById("ContentPlaceHolder1_btnAceptar");
            aceptar.style.display = 'block';
            b.style.display = 'block';
            document.getElementById("divProgreso").style.display = 'none';
            aceptar.value = "Aceptar";
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hCantTurnos" Value="0" runat="server" />
            <asp:HiddenField ID="hTurnosDisp" Value="0" runat="server" />
            <asp:HiddenField ID="htit" runat="server" />
            <asp:HiddenField ID="hNroCta" runat="server" />
            <div class="box box-warning" style="min-height: 500px;">
                <div class="box-header with-border">
                    <div class="col-md-9">
                        <h2 class="box-title" style="font-size: 24px;" id="hTitulo" runat="server"></h2>
                    </div>
                    <div class="col-md-3" style="text-align: right;">
                        <span class="input-group-btn">
                            <button class="btn btn-success" type="button" id="btnVolver" runat="server"
                                onserverclick="btnVolver_ServerClick">
                                <span class="fa fa-reply"></span>Volver</button>
                        </span>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="col-md-12" id="divError" runat="server" visible="false">
                        <div class="alert alert-success alert-dismissible" role="alert" style="border-color: #00a65a;">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong>Error!</strong>
                            <p id="msjOk" runat="server"></p>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="box box-default" style="margin-top: 40px;">
                            <div class="box-header with-border">
                                <h3 class="box-title">Turno</h3>
                            </div>
                            <div class="box-body" style="font-size: 16px;">
                                <div class="col-md-4 col-sm-12">
                                    <asp:Calendar
                                        ID="Calendar1"
                                        runat="server"
                                        BackColor="White"
                                        CssClass="table"
                                        BorderColor="White"
                                        OnDayRender="Calendar1_DayRender"
                                        WeekendDayStyle-BackColor="Gray" OnSelectionChanged="Calendar1_SelectionChanged"
                                        BorderWidth="1px"
                                        Font-Names="Verdana"
                                        Font-Size="9pt"
                                        ForeColor="Black"
                                        Height="190px"
                                        NextPrevFormat="FullMonth"
                                        Width="100%">
                                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt"></DayHeaderStyle>
                                        <NextPrevStyle VerticalAlign="Bottom" Font-Bold="True" Font-Size="8pt" ForeColor="#333333"></NextPrevStyle>
                                        <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                                        <SelectedDayStyle BackColor="#333399" ForeColor="White"></SelectedDayStyle>
                                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="0px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399"></TitleStyle>
                                        <TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
                                    </asp:Calendar>
                                </div>
                                <div class="col-md-2 col-sm-12">
                                    <h4>Disponible</h4>
                                    <asp:ListBox ID="lstHorarios" Height="290px" CssClass="form-control"
                                        OnSelectedIndexChanged="lstHorarios_SelectedIndexChanged"
                                        AutoPostBack="true"
                                        runat="server"></asp:ListBox>
                                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-md-5 col-sm-12">
                                    <h4>Turno Seleccionado</h4>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Dia</label>
                                                <asp:Label ID="lblDia" CssClass="form-control" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Turno</label>
                                                <asp:Label ID="lblHorario" CssClass="form-control" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Personas</label>
                                                <asp:DropDownList ID="DDLCantPersonas"
                                                    CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="25" Text="hasta 25"></asp:ListItem>
                                                    <asp:ListItem Value="45" Text="hasta 45"></asp:ListItem>
                                                    <asp:ListItem Value="60" Text="hasta 60"></asp:ListItem>
                                                    <asp:ListItem Value="80" Text="hasta 80"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Costo</label>
                                                <asp:Label ID="lblCosto" CssClass="form-control" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label></label>
                                        <a id="modalTurno" href="#modal-confirmacion" runat="server"
                                            visible="true"
                                            role="button" class="btn btn-success btn-block" data-toggle="modal">Confirmar Turno</a>

                                    </div>
                                </div>
                                <div class="col-md-12" style="margin-top: 20px;">
                                </div>
                            </div>
                            <div class="box-footer clearfix">
                            </div>
                        </div>
                    </div>
                </div>

                <div class="box-footer clearfix">
                </div>
            </div>


            <div class="row">
                <div class="col-md-12">
                    <div class="modal fade" id="modal-container-10184" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">

                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        ×
                                    </button>
                                    <h4 class="modal-title" id="myModalLabel">Requisitos para Licencia de Conducir
                                    </h4>
                                </div>
                                <div class="modal-body" id="divRequisitos" runat="server">
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Cerrar
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="modal fade" id="modal-confirmacion" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        ×
                                    </button>
                                    <h4 class="modal-title">Confirmacion de turno
                                    </h4>
                                </div>
                                <div class="modal-body" id="divConfirmacion" runat="server">
                                    <div class="form-group col-md-6">
                                        <label>Fecha</label>
                                        <asp:Label ID="lblFechaTurno" CssClass="form-control" runat="server" Text="">
                                        </asp:Label>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Hora</label>
                                        <asp:Label ID="lblHoraTurno" CssClass="form-control" runat="server" Text="">
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" id="btnCancel" class="btn btn-default" data-dismiss="modal" onclick="habilitar(this)">
                                        Cancelar
                                    </button>
                                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"
                                        OnClick="btnAceptar_Click" OnClientClick="return deshabilitar(this);" CssClass="btn btn-primary" />

                                    <div class="col-md-12 progress progress-sm active" id="divProgreso" style="display: none;">
                                        <div class="progress-bar progress-bar-success progress-bar-striped" role="progressbar" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100" style="width: 20%">
                                            <span class="sr-only">20% Complete</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- jQuery 2.1.4 -->
    <script src="../App_Themes/plugins/jQuery/jQuery-2.1.4.min.js"></script>

    <!-- Bootstrap 3.3.2 JS -->
    <script src="../App_Themes/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript">

</script>
    <!-- AdminLTE App -->
    <script src="../App_Themes/dist/js/app.min.js" type="text/javascript"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../App_Themes/dist/js/demo.js" type="text/javascript"></script>
</asp:Content>
