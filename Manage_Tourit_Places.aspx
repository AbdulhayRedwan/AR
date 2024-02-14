<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="Manage_Tourit_Places.aspx.cs" Inherits="Admin_Manage_Tourit_Places" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="app-content content">
        <div class="content-wrapper">
            <div class="content-wrapper-before"></div>
            <div class="content-header row">
                <div class="content-header-left col-md-4 col-12 mb-2">
                    <h3 class="content-header-title">Manage Tourit Places</h3>
                </div>
                <div class="content-header-right col-md-8 col-12">
                    <div class="breadcrumbs-top float-md-right">
                        <div class="breadcrumb-wrapper mr-1">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Admin_Default.aspx">Home</a>
                                </li>
                                <li class="breadcrumb-item active">Tourit Places
                                </li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content-body">
                <!--native-font-stack -->
                <section id="global-settings" class="card">
                    <div class="card-header">
                        <h4 class="card-title">Settings</h4>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                        <div class="heading-elements">
                            <ul class="list-inline mb-0">
                                <li><a data-action="collapse"><i class="ft-minus"></i></a></li>
                                <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                                <li><a data-action="expand"><i class="ft-maximize"></i></a></li>
                                <li><a data-action="close"><i class="ft-x"></i></a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="card-content">
                        <div class="card-body">
                            <div class="card-text">
                                <p>It could help for managing the data of   <a href="#" target="_blank">system adminstrators.</a></p>

                            </div>
                        </div>
                    </div>
                </section>


                <!-- Headings -->
                <section id="html-headings-default" class="row match-height">
                    <div class="col-sm-12 col-md-6">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Data Entry <small class="text-muted">....</small></h4>
                                <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                                <div class="heading-elements">
                                    <ul class="list-inline mb-0">
                                        <li><a data-action="expand"><i class="ft-maximize"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="card-content">
                                <div class="card-body">
                                    <div class="card-text">
                                        <p>Please Fill the Data..</p>
                                    </div>
                                </div>
                                <div class="table-responsive">



                                    <fieldset>
                                        <table width="90%" class="table table-borderless mb-0">
                                            <tr id="Tr1" runat="server" visible="false">
                                                <td> <asp:Label ID="lbl_Id_H" runat="server" Text="Id"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Id" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_City_Id_H" runat="server" Text="Cities"></asp:Label></td>
                                                <td>
                                                    
                                                            <asp:DropDownList ID="Ddl_City_Id" runat="server" class="form-control" AutoPostBack="True" Width="90%"></asp:DropDownList>



                                                </td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Tourism_Type_Id_H" runat="server" Text="Tourism Types" ></asp:Label></td>
                                                <td>
                                                    


                                                            <asp:DropDownList ID="Ddl_Tourism_Type_Id" runat="server" class="form-control" AutoPostBack="True"  Width="90%"></asp:DropDownList>

                                                </td>
                                        
                                                
                                                
                                                    </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Name_H" runat="server" Text="Place Name"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Name" runat="server" MaxLength="50"  Width="90%" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_Name" runat="server" ControlToValidate="txt_Name" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Description_H" runat="server" Text="Description"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Description" runat="server" MaxLength="50"  Width="90%" class="form-control" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_Description" runat="server" ControlToValidate="txt_Description" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                            </tr>
                                          
                                            <tr>
                                                <td> <asp:Label ID="lbl_Location_H" runat="server" Text="Location"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Location" runat="server" MaxLength="550"  Width="90%" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_Location" runat="server" ControlToValidate="txt_Location" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Conditions_H" runat="server" Text="Conditions"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Conditions" runat="server" MaxLength="550"  Width="90%" class="form-control" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_Conditions" runat="server" ControlToValidate="txt_Conditions" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Opining_Hours_H" runat="server" Text="Opining Hours"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Opining_Hours" runat="server" MaxLength="550"  Width="90%" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_Opining_Hours" runat="server" ControlToValidate="txt_Opining_Hours" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Visitor_Counts_H" runat="server" Text="Visitor Counts"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Visitor_Counts" runat="server" MaxLength="550"  Width="90%" class="form-control" TextMode="Number"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_Visitor_Counts" runat="server" ControlToValidate="txt_Visitor_Counts" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Tickits_Prices_H" runat="server" Text="Tickits Prices"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Tickits_Prices" runat="server" MaxLength="50"  Width="90%" class="form-control" TextMode="Number"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_Tickits_Prices" runat="server" ControlToValidate="txt_Tickits_Prices" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                            </tr>


                                              <tr>
                                                <td> <asp:Label ID="lbl_Img1_H" runat="server" Text="Img1"></asp:Label></td>
                                                <td>
                                                 
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    <asp:Image ID="Image1" runat="server" Width="50px" Height="50px" />
                                                     

                                                </td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Img2_H" runat="server" Text="Img2"></asp:Label></td>
                                                <td>
                                                     
                                                    <asp:FileUpload ID="FileUpload2" runat="server" />
                                                         <asp:Image ID="Image2" runat="server" Width="50px" Height="50px" />
                                                   

                                                </td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Img3_H" runat="server" Text="Img3"></asp:Label></td>
                                                <td>
                                                    
                                                    <asp:FileUpload ID="FileUpload3" runat="server" />
                                                         <asp:Image ID="Image3" runat="server" Width="50px" Height="50px" />
                                                   

                                                </td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Img4_H" runat="server" Text="Img4"></asp:Label></td>
                                                <td>
                                              
                                                    <asp:FileUpload ID="FileUpload4" runat="server" />
                                                         <asp:Image ID="Image4" runat="server" Width="50px" Height="50px" />
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                        <p>
                                            <asp:Label ID="lbl_SaveSuccess" runat="server" Text="" CssClass="failureNotification"></asp:Label>
                                            <asp:ValidationSummary ID="VS8" runat="server" ValidationGroup="f" CssClass="failureNotification" />
                                        <p dir="ltr">
                                            <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="f"  class="btn btn-secondary btn-min-width mr-1 mb-1"/>
                                            <asp:Button ID="btn_Clear" runat="server" Text="New" OnClick="btn_Clear_Click" class="btn btn-secondary btn-min-width mr-1 mb-1" />
                                            <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" class="btn btn-secondary btn-min-width mr-1 mb-1" />
                                        </p>
                                    </fieldset>



                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-6">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Data Storage       </h4>
                                <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                                <div class="heading-elements">
                                    <ul class="list-inline mb-0">
                                        <li><a data-action="expand"><i class="ft-maximize"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="card-content">
                                <div class="card-body">
                                    <div class="card-text">
                                        <p>The data of admin have been stored and viewd here  .</p>
                                    </div>
                                </div>
                                <div class="table-responsive">


                                    <asp:GridView ID="gvTourit_Places" OnRowCommand="gvTourit_Places_RowCommand" runat="server" AutoGenerateColumns="False" Width="95%" OnPageIndexChanging="gvTourit_Places_PageIndexChanging" AllowPaging="True" CellPadding="4" PageSize="15" CssClass="table" ForeColor="#333333" GridLines="Both">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#" SortExpression="RowNumber">
                                                <ItemTemplate>  
                                                    <asp:Label ID="lbl_RowNumber" runat="server" Text='<%# Bind("RowNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                <ItemTemplate> <asp:Label ID="lbl_Name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        
                                           
                                            <asp:TemplateField HeaderText="Location" SortExpression="Location">
                                                <ItemTemplate> <asp:Label ID="lbl_Location" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Opining_Hours" SortExpression="Opining_Hours">
                                                <ItemTemplate> <asp:Label ID="lbl_Opining_Hours" runat="server" Text='<%# Bind("Opining_Hours") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Visitor_Counts" SortExpression="Visitor_Counts">
                                                <ItemTemplate> <asp:Label ID="lbl_Visitor_Counts" runat="server" Text='<%# Bind("Visitor_Counts") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tickits_Prices" SortExpression="Tickits_Prices">
                                                <ItemTemplate> <asp:Label ID="lbl_Tickits_Prices" runat="server" Text='<%# Bind("Tickits_Prices") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

  <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtn_Update" ImageUrl="~/Admin/assets/update.png" runat="server" CommandArgument='<%# Bind("ID") %>' CommandName="updte"  Width="30px"/><asp:ImageButton ID="imgbtn_Delete" CommandName="Delte" ImageUrl="~/Admin/assets/del.png" Width="30px" runat="server" CommandArgument='<%# Bind("ID") %>' OnClientClick="return validateDelete();" /></ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>


                                        </Columns>
                                        <AlternatingRowStyle CssClass="odd" BackColor="White" ForeColor="#284775" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle CssClass="head" Height="25px" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <EmptyDataRowStyle BackColor="GrayText" ForeColor="Black" />
                                        <EmptyDataTemplate>No Data .....</EmptyDataTemplate>
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>



                                    <script language="javascript" type="text/javascript">
                                        function validateDelete() {
                                            return confirm('Are you sure delete?');
                                        }
                                    </script>



                                </div>
                            </div>
                        </div>
                    </div>
                </section>

            </div>
        </div>
    </div>
    <!-- ////////////////////////////////////////////////////////////////////////////-->


</asp:Content>


