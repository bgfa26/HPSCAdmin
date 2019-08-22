<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site/employees/employees.Master" CodeBehind="activetimesheet.aspx.cs" Inherits="adminsite.site.employees.timesheet.activetimesheet" %>


<asp:Content ID="ContentIndex" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/plugins/datatables/dataTables.bootstrap.css">

    <title>AdminSite</title>

    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="../css/sb-admin.css" rel="stylesheet">
    <link href="../css/timesheet-table.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.css'/>
    <style>
        
        th {
          text-align: center;
        }
        #content_gridView td {
          padding-top: 15px;
        }

    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server"> 
    
    <asp:ScriptManager ID="smMain" runat="server" EnablePageMethods="true" />
    <!-- Page Heading -->
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                Hoja de tiempo N°<asp:Label ID="timesheetLbl" runat="server" Text='' ReadOnly="True" BorderStyle="None" />
            </h1>
        </div>
    </div>
    <div class="row">
        <div style="width: 100%; height: 500px; overflow: scroll">
            <asp:GridView ID="gridView" DataKeyNames="id" runat="server" CssClass="table table-bordered" 
                    AutoGenerateColumns="false" ShowFooter="true" HeaderStyle-Font-Bold="true"
                    onrowcancelingedit="gridView_RowCancelingEdit"
                    onrowdeleting="gridView_RowDeleting"
                    onrowediting="gridView_RowEditing"
                    onrowupdating="gridView_RowUpdating"
                    onrowcommand="gridView_RowCommand"
                    OnRowDataBound="gridView_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Cuenta/Curso/Permiso">
                        <ItemTemplate>
                            <asp:Label ID="acpLbl" runat="server" Text='<%#Eval("accountCoursePermit.name") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="acpEditDl" AppendDataBoundItems="true" runat="server" CssClass="form-control textinput">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="acpNewDl" AppendDataBoundItems="true" runat="server" CssClass="form-control textinput">
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 1">
                        <ItemTemplate>
                            <asp:Label ID="day1Lbl" runat="server" Text='<%#Eval("day1") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day1Txt" width="60px" runat="server" Text='<%#Eval("day1") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay1" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 2">
                         <ItemTemplate>
                            <asp:Label ID="day2Lbl" runat="server" Text='<%#Eval("day2") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day2Txt" width="60px" runat="server" Text='<%#Eval("day2") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay2" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 3">
                         <ItemTemplate>
                            <asp:Label ID="day3Lbl" runat="server" Text='<%#Eval("day3") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day3Txt" width="60px" runat="server" Text='<%#Eval("day3") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay3" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 4">
                         <ItemTemplate>
                            <asp:Label ID="day4Lbl" runat="server" Text='<%#Eval("day4") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day4Txt" width="60px" runat="server" Text='<%#Eval("day4") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay4" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 5">
                         <ItemTemplate>
                            <asp:Label ID="day5Lbl" runat="server" Text='<%#Eval("day5") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day5Txt" width="60px" runat="server" Text='<%#Eval("day5") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay5" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 6">
                         <ItemTemplate>
                            <asp:Label ID="day6Lbl" runat="server" Text='<%#Eval("day6") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day6Txt" width="60px" runat="server" Text='<%#Eval("day6") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay6" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 7">
                         <ItemTemplate>
                            <asp:Label ID="day7Lbl" runat="server" Text='<%#Eval("day7") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day7Txt" width="60px" runat="server" Text='<%#Eval("day7") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay7" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 8">
                         <ItemTemplate>
                            <asp:Label ID="day8Lbl" runat="server" Text='<%#Eval("day8") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day8Txt" width="60px" runat="server" Text='<%#Eval("day8") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay8" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 9">
                         <ItemTemplate>
                            <asp:Label ID="day9Lbl" runat="server" Text='<%#Eval("day9") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day9Txt" width="60px" runat="server" Text='<%#Eval("day9") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay9" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 10">
                         <ItemTemplate>
                            <asp:Label ID="day10Lbl" runat="server" Text='<%#Eval("day10") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day10Txt" width="60px" runat="server" Text='<%#Eval("day10") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay10" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 11">
                         <ItemTemplate>
                            <asp:Label ID="day11Lbl" runat="server" Text='<%#Eval("day11") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day11Txt" width="60px" runat="server" Text='<%#Eval("day11") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay11" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 12">
                         <ItemTemplate>
                            <asp:Label ID="day12Lbl" runat="server" Text='<%#Eval("day12") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day12Txt" width="60px" runat="server" Text='<%#Eval("day12") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay12" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 13">
                         <ItemTemplate>
                            <asp:Label ID="day13Lbl" runat="server" Text='<%#Eval("day13") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day13Txt" width="60px" runat="server" Text='<%#Eval("day13") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay13" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 14">
                         <ItemTemplate>
                            <asp:Label ID="day14Lbl" runat="server" Text='<%#Eval("day14") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day14Txt" width="60px" runat="server" Text='<%#Eval("day14") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay14" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 15">
                         <ItemTemplate>
                            <asp:Label ID="day15Lbl" runat="server" Text='<%#Eval("day15") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day15Txt" width="60px" runat="server" Text='<%#Eval("day15") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay15" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-width="60px" ItemStyle-HorizontalAlign="center" HeaderText="Día 16">
                         <ItemTemplate>
                            <asp:Label ID="day16Lbl" runat="server" Text='<%#Eval("day16") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="day16Txt" width="60px" runat="server" Text='<%#Eval("day16") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox autocomplete="off" TextMode="Number" min="0" max="24" step="1" onkeypress="return this.value.length<=-1" CssClass="form-control textinput" ID="inDay16" width="60px" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Opciones" ItemStyle-HorizontalAlign="center" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:ImageButton ID="update" runat="server" Text="Aceptar" ImageUrl="~/site/employees/img/icons/check.svg" Height="26px" Width="26px" CommandName="Update" ToolTip="Aceptar" Style="margin-right:2px"/>
                            <asp:ImageButton ID="cancel" runat="server" Text="Cancelar" ImageUrl="~/site/employees/img/icons/close.svg" Height="25px" Width="25px" CommandName="Cancel" ToolTip="Cancelar"  Style="margin-left:2px"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="modify" runat="server" Text="Modificar" ImageUrl="~/site/employees/img/icons/assign.svg" Height="25px" Width="25px" CommandName="Edit" ToolTip="Modificar" />
                            <asp:ImageButton ID="delete" runat="server" Text="Eliminar" ImageUrl="~/site/employees/img/icons/trash.svg" Height="26px" Width="26px" CommandName="Delete" ToolTip="Eliminar" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="add" runat="server" Text="Agregar" ImageUrl="~/site/employees/img/icons/add.svg" Height="23px" Width="23px" CommandName="AddNew" ToolTip="Agregar" Style="margin-top:5px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div >
            <br />    
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </div>
    </div>
    
</asp:Content>

<asp:Content ID="javaScript" ContentPlaceHolderID="js" runat="server">

    <!-- jQuery -->
    <script src="../js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/sweet.js"></script>

    <!-- DataTables -->
    <script src="../css/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../css/plugins/datatables/dataTables.bootstrap.min.js"></script>
</asp:Content>


