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
        <div>
            <asp:GridView ID="gridView" DataKeyNames="stor_id" runat="server" CssClass="table table-bordered"
                    AutoGenerateColumns="false" ShowFooter="true" HeaderStyle-Font-Bold="true"
                    onrowcancelingedit="gridView_RowCancelingEdit"
                    onrowdeleting="gridView_RowDeleting"
                    onrowediting="gridView_RowEditing"
                    onrowupdating="gridView_RowUpdating"
                    onrowcommand="gridView_RowCommand"
                    OnRowDataBound="gridView_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="stor_id">
                        <ItemTemplate>
                            <asp:Label ID="txtstorid" runat="server" Text='<%#Eval("stor_id") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblstorid" runat="server" width="40px" Text='<%#Eval("stor_id") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="instorid" width="40px" runat="server"/>
                            <asp:RequiredFieldValidator ID="vstorid" runat="server" ControlToValidate="instorid" Text="?" ValidationGroup="validaiton"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="stor_name">
                         <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("stor_name") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtname" width="70px"  runat="server" Text='<%#Eval("stor_name") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="inname"  width="120px" runat="server"/>
                            <asp:RequiredFieldValidator ID="vname" runat="server" ControlToValidate="inname" Text="?" ValidationGroup="validaiton"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Día 16">
                         <ItemTemplate>
                            <asp:Label ID="day16Lbl" runat="server" Text='12'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="day16Txt" width="70px"  runat="server" Text='12'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="inDay16"  width="120px" runat="server"/>
                            <asp:RequiredFieldValidator ID="vDay16" runat="server" ControlToValidate="inname" Text="?" ValidationGroup="validaiton"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="stor_address">
                        <ItemTemplate>
                            <asp:Label ID="lbladdress" runat="server" Text='<%#Eval("stor_address") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtaddress" width="70px"  runat="server" Text='<%#Eval("stor_address") %>'/>
                        </EditItemTemplate>
                       <FooterTemplate>
                           <asp:TextBox ID="inaddress" width="110px"  runat="server"/>
                           <asp:RequiredFieldValidator ID="vaddress" runat="server" ControlToValidate="inaddress" Text="?" ValidationGroup="validaiton"/>
                       </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="city">
                         <ItemTemplate>
                           <asp:Label ID="lblcity" runat="server" Text='<%#Eval("city") %>'/>
                       </ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtcity" width="50px"   runat="server" Text='<%#Eval("city") %>'/>
                       </EditItemTemplate>
                      <FooterTemplate>
                          <asp:TextBox ID="incity" width="60px"  runat="server"/>
                          <asp:RequiredFieldValidator ID="vcity" runat="server" ControlToValidate="incity" Text="?" ValidationGroup="validaiton"/>
                      </FooterTemplate>
                   </asp:TemplateField>
                    <asp:TemplateField HeaderText="state">
                      <ItemTemplate>
                          <asp:Label ID="lblstate" runat="server" Text='<%#Eval("state") %>'/>
                      </ItemTemplate>
                      <EditItemTemplate>
                          <asp:TextBox ID="txtstate" width="30px"  runat="server" Text='<%#Eval("state") %>'/>
                      </EditItemTemplate>
                      <FooterTemplate>
                          <asp:TextBox ID="instate" width="40px"   runat="server"/>
                          <asp:RequiredFieldValidator ID="vstate" runat="server" ControlToValidate="instate" Text="?" ValidationGroup="validaiton"/>
                      </FooterTemplate>
                     </asp:TemplateField>
                    <asp:TemplateField HeaderText="zip">
                        <ItemTemplate>
                            <asp:Label ID="lblzip" runat="server" Text='<%#Eval("zip") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtzip" width="30px"  runat="server" Text='<%#Eval("zip") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="inzip" width="40px"   runat="server"/>
                            <asp:RequiredFieldValidator ID="vzip" runat="server" ControlToValidate="inzip" Text="?" ValidationGroup="validaiton"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Opciones">
                        <EditItemTemplate>
                            <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update"  Text="Update"  />
                            <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel"  Text="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit"  Text="Edit"  />
                            <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete"  Text="Delete"  />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" CommandName="AddNew"  Text="Add New Row" ValidationGroup="validaiton" />
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


