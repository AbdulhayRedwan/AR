<%@ Page Title="" Language="C#" MasterPageFile="~/Guider/MasterGuider.master" AutoEventWireup="true" CodeFile="Manage_Guider_Places.aspx.cs" Inherits="Guider_Manage_Guider_Places" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div class="app-content content">
        <div class="content-wrapper">
            <div class="content-wrapper-before"></div>
            <div class="content-header row">
                <div class="content-header-left col-md-4 col-12 mb-2">
                    <h3 class="content-header-title">Manage Guider_Places</h3>
                </div>
               
                 <div class="content-header-right col-md-8 col-12">
                    <div class="breadcrumbs-top float-md-right">
                        <div class="breadcrumb-wrapper mr-1">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Admin_Default.aspx">Home</a>
                                </li>
                                <li class="breadcrumb-item active">Guider Places
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
                                        <table   width="90%" class="table table-borderless mb-0">
                                            <tr id="Tr1" runat="server" visible="false">
                                                <td> <asp:Label ID="lbl_Id_H" runat="server" Text="Id"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_Id" runat="server"></asp:Label></td>
                                            </tr>
                                      
                                            <tr>
                                                <td> <asp:Label ID="lbl_Tourism_Type_Id_H" runat="server" Text="Tourist Place" ></asp:Label></td>
                                                <td>
                                                    


                                                            <asp:DropDownList ID="Ddl_Tourist_Place_Id" runat="server" class="form-control" AutoPostBack="True"  Width="90%"></asp:DropDownList>

                                                </td>
                                        
                                                
                                                
                                                    </tr>
                                         
                                          
                                          
                                            <tr>
                                                <td> <asp:Label ID="lbl_Details_H" runat="server" Text="Details"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Details" runat="server" MaxLength="550"  Width="90%" class="form-control" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_Details" runat="server" ControlToValidate="txt_Details" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td> <asp:Label ID="lbl_Price_Hour_H" runat="server" Text="Hour Price"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txt_Price_Hour" runat="server" MaxLength="550"  Width="90%" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV_Price_Hour" runat="server" ControlToValidate="txt_Price_Hour" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
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


                                    <asp:GridView ID="gvGuider_Places" OnRowCommand="gvGuider_Places_RowCommand" runat="server" AutoGenerateColumns="False" Width="95%" OnPageIndexChanging="gvGuider_Places_PageIndexChanging" AllowPaging="True" CellPadding="4" PageSize="15" CssClass="table" ForeColor="#333333" GridLines="Both">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#" SortExpression="RowNumber">
                                                <ItemTemplate>  
                                                    <asp:Label ID="lbl_RowNumber" runat="server" Text='<%# Bind("RowNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>



                                            <asp:TemplateField HeaderText="City Name" SortExpression="Price Hour">
                                                <ItemTemplate> <asp:Label ID="lbl_City_Name" runat="server" Text='<%# Bind("City_Name") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Tourit_Places" SortExpression="Price Hour">
                                                <ItemTemplate> <asp:Label ID="lbl_Tourit_Places_Name" runat="server" Text='<%# Bind("Tourit_Places_Name") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Price_Hour" SortExpression="Price Hour">
                                                <ItemTemplate> <asp:Label ID="lbl_Description" runat="server" Text='<%# Bind("Price_Hour") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                              <asp:TemplateField HeaderText="Details" SortExpression="Details">
                                                <ItemTemplate> <asp:Label ID="lbl_Name" runat="server" Text='<%# Bind("Details") %>'></asp:Label>
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
  

</asp:Content>

