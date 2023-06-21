<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="LaHerradura.Back.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:HiddenField ID="hIdUsuario" runat="server" />
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Administración de usuarios</h3>
                        <a href="#" class="btn btn-primary pull-right"
                            onclick="abrirModalEdit('', '', '', '', '','', '')">
                            <span class="fa fa-plus"></span>&nbsp;Nuevo Usuario
                        </a>
                    </div>
                    <div class="box-body">
                        <asp:GridView ID="gvUsuarios"
                            CssClass="table table-hover"
                            OnRowDataBound="gvUsuarios_RowDataBound"
                            OnRowCommand="gvUsuarios_RowCommand"
                            AutoGenerateColumns="false"
                            runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="USUARIO" HeaderText="Usuario" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRol"
                                            runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="APELLIDO" HeaderText="Apellido" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                <asp:BoundField DataField="MAIL" HeaderText="Mail" />
                                <asp:BoundField DataField="CEL" HeaderText="Telefono" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="btn-group">
                                            <button type="button" class="btn btn-info dropdown-toggle"
                                                data-toggle="dropdown">
                                                <span class="fa fa-bars"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li id="btnEditar" runat="server">
                                                    <a href="#"
                                                        onclick="abrirModalEdit('<%#Eval("ID")%>','<%#Eval("USUARIO")%>', 
                                                            '<%#Eval("ROL")%>','<%#Eval("APELLIDO")%>','<%#Eval("NOMBRE")%>', 
                                                            '<%#Eval("MAIL")%>','<%#Eval("CEL")%>')">
                                                        <span class="fa fa-edit"></span>
                                                        Editar
                                                    </a>
                                                </li>
                                                <li id="btnClearPass" runat="server">
                                                    <a href="#"
                                                        onclick="abrirModalPass('<%#Eval("ID")%>')">
                                                        <span class="fa fa-key"></span>
                                                        Blanquear contraseña
                                                    </a>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="btnActivar" 
                                                        CommandArgument='<%#Eval("ID")%>'
                                                        CommandName="activar"
                                                        OnClientClick="return confirm('¿Esta seguro de activar el usuario?')"
                                                        runat="server">
                                                        <span class="fa fa-eye-slash"></span>&nbsp;Activar
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="btnDesactivar" 
                                                        CommandArgument='<%#Eval("ID")%>'
                                                        CommandName="desactivar" 
                                                        OnClientClick="return confirm('¿Esta seguro de desactivar el usuario?')"
                                                        runat="server">
                                                        <span class="fa fa-eye"></span>&nbsp;Desactivar
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="btnEliminar" 
                                                        CommandArgument='<%#Eval("ID")%>'
                                                        CommandName="eliminar" 
                                                        OnClientClick="return confirm('¿Esta seguro de eliminar el usuario?')"
                                                        runat="server">
                                                        <span class="fa fa-remove"></span>&nbsp;Eliminar
                                                    </asp:LinkButton>
                                                </li>
                                            </ul>
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
            </div>
        </div>
    </div>

    <div class="modal fade in" id="modalEdit">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Agregar / Editar usuario</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Nombre de usuario</label>
                                <asp:TextBox ID="txtUsuario" AutoCompleteType="Disabled"
                                    CssClass="form-control"
                                    placeholder="Nombre de usuario"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rv1" runat="server" 
                                    ForeColor="Red" ControlToValidate="txtUsuario"
                                    ValidationGroup="usuario"
                                    ErrorMessage="Ingrese el nombre de usuario"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Rol</label>
                                <asp:DropDownList ID="DDLRol"
                                    CssClass="form-control"
                                    runat="server">
                                    <asp:ListItem Text="Administrador" Value="1">                                        
                                    </asp:ListItem>
                                    <asp:ListItem Text="Estudios" Value="3">                                        
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row" id="divPass">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Contraseña</label>
                                <asp:TextBox ID="txtPass"
                                    CssClass="form-control"
                                    TextMode="Password"
                                    placeholder="Ingrese contraseña"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Repita contraseña</label>
                                <asp:TextBox ID="txtPass2"
                                    CssClass="form-control"
                                    TextMode="Password"
                                    placeholder="Repita contraseña"
                                    runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="cv" runat="server" 
                                    ControlToValidate="txtPass2"
                                    ControlToCompare="txtPass"
                                    ValidationGroup="usuario"
                                    ErrorMessage="Las contraseñas no coinciden"></asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox ID="txtNombre"
                                    CssClass="form-control"
                                    placeholder="Nombre"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rv2" runat="server" 
                                    ForeColor="Red" ControlToValidate="txtNombre"
                                    ValidationGroup="usuario"
                                    ErrorMessage="Ingrese el nombre"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Apellido</label>
                                <asp:TextBox ID="txtApellido"
                                    CssClass="form-control"
                                    placeholder="Apellido"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rv3" runat="server" 
                                    ForeColor="Red" ControlToValidate="txtApellido"
                                    ValidationGroup="usuario"
                                    ErrorMessage="Ingrese el apellido"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Telefono</label>
                                <asp:TextBox ID="txtTelefono"
                                    CssClass="form-control"
                                    placeholder="Telefono"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Mail</label>
                                <asp:TextBox ID="txtMail"
                                    CssClass="form-control"
                                    placeholder="Mail"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnAceptarUsuario" CssClass="btn btn-primary"
                        ValidationGroup="usuario"
                        OnClick="btnAceptarUsuario_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade in" id="modalBlanqueaPass">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Blanquear contraseña</h4>
                </div>
                <div class="modal-body">
                    <div class="row"">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Nueva Contraseña</label>
                                <asp:TextBox ID="txtNewPass"
                                    CssClass="form-control"
                                    TextMode="Password"
                                    placeholder="Ingrese contraseña"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ForeColor="Red" ControlToValidate="txtNewPass"
                                    ValidationGroup="password"
                                    ErrorMessage="Ingrese contraseña"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Repita contraseña</label>
                                <asp:TextBox ID="txtConfirmNewPass"
                                    CssClass="form-control"
                                    TextMode="Password"
                                    placeholder="Repita contraseña"
                                    runat="server"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToValidate="txtConfirmNewPass"
                                    ControlToCompare="txtNewPass"
                                    ValidationGroup="password"
                                    ErrorMessage="Las contraseñas no coinciden"></asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button data-dismiss="modal" class="btn btn-default">Cancelar</button>
                    <asp:Button ID="btnClearPass" runat="server" Text="Aceptar" 
                        CssClass="btn btn-primary"
                        ValidationGroup="password"
                        OnClick="btnClearPass_Click1"/>
                </div>
            </div>
        </div>
    </div>
    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js"></script>
    <script>
        function abrirModalEdit(ID, USUARIO, ROL, APELLIDO, NOMBRE,
            MAIL, CEL) {
            
            $('#modalEdit').modal('show');

            //PERIODO 
            if (ID == '')
                $("#divPass").show();
            else
                $("#divPass").hide();
            $("#ContentPlaceHolder1_hIdUsuario").val(ID);
            $("#ContentPlaceHolder1_txtUsuario").val(USUARIO);
            $("#ContentPlaceHolder1_txtNombre").val(NOMBRE);
            $("#ContentPlaceHolder1_txtApellido").val(APELLIDO);
            $("#ContentPlaceHolder1_txtTelefono").val(CEL);
            $("#ContentPlaceHolder1_txtMail").val(MAIL);
            $("#ContentPlaceHolder1_DDLRol").val(ROL);
        }
        function abrirModalPass(ID) {
            
            $('#modalBlanqueaPass').modal('show');

            //PERIODO 
            $("#ContentPlaceHolder1_hIdUsuario").val(ID);
        }
    </script>
</asp:Content>
