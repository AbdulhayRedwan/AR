<%@ Page Title="" Language="C#" MasterPageFile="~/Guider/MasterGuider.master" AutoEventWireup="true" CodeFile="Manage_Tourist_Guider_Booking.aspx.cs" Inherits="Guider_Manage_Tourist_Guider_Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="app-content content">
        <div class="content-wrapper">
            <div class="content-wrapper-before"></div>
            <div class="content-header row">
                <div class="content-header-left col-md-4 col-12 mb-2">
                    <h3 class="content-header-title">Manage Tourist Guider Booking</h3>
                </div>
                <div class="content-header-right col-md-8 col-12">
                    <div class="breadcrumbs-top float-md-right">
                        <div class="breadcrumb-wrapper mr-1">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="MasterGuider_Default.aspx">Home</a>
                                </li>
                                <li class="breadcrumb-item active">Tourist Guider Booking
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
                                     
                                    <table width="90%">
                                        <tr id="Tr1" runat="server" visible="false">
                                            <td>
                                                <asp:Label ID="lbl_Id_H" runat="server" Text="Id"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbl_Id" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 10px;">
                                                <asp:Label ID="lbl_Admin_Id_H" runat="server" Text="Guider Places"></asp:Label></td>
                                            <td> 
                                                <asp:DropDownList ID="Ddl_Guider_Places_Id" runat="server" class="form-control" AutoPostBack="True" Width="90%"></asp:DropDownList>
                                                 
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding-left: 10px;">
                                                <asp:Label ID="Label1" runat="server" Text="Tourists"></asp:Label></td>
                                            <td> 
                                                <asp:DropDownList ID="ddl_Tourist_Id" runat="server" class="form-control" AutoPostBack="True" Width="90%"></asp:DropDownList>
                                                 
                                            </td>
                                        </tr>


                                        <tr>
                                            <td style="padding-left: 10px;">
                                                <asp:Label ID="lbl_Date_Time_H" runat="server" Text="Date Time"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txt_Date_Time" runat="server" MaxLength="50" Width="90%" class="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_Date_Time" runat="server" ControlToValidate="txt_Date_Time" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 10px;">
                                                <asp:Label ID="lbl_Notes_H" runat="server" Text="Notes"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txt_Notes" runat="server" MaxLength="50" Width="90%" Height="150px" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV_Notes" runat="server" ControlToValidate="txt_Notes" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                    </table>
                                    <p>
                                        <asp:Label ID="lbl_SaveSuccess" runat="server" Text="" CssClass="failureNotification"></asp:Label>
                                        <asp:ValidationSummary ID="VS8" runat="server" ValidationGroup="f" CssClass="failureNotification" />
                                        <p dir="ltr">
                                            <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="f" class="btn btn-secondary btn-min-width mr-1 mb-1" />
                                            <asp:Button ID="btn_Clear" runat="server" Text="New" OnClick="btn_Clear_Click" class="btn btn-secondary btn-min-width mr-1 mb-1" />
                                            <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click" class="btn btn-secondary btn-min-width mr-1 mb-1" />
                                        </p>
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


                                    <asp:GridView ID="gvTourist_Guider_Booking" OnRowCommand="gvTourist_Guider_Booking_RowCommand" runat="server" AutoGenerateColumns="False" Width="95%" OnPageIndexChanging="gvTourist_Guider_Booking_PageIndexChanging" AllowPaging="True" CellPadding="4" PageSize="15" CssClass="table" ForeColor="#333333" GridLines="Both">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#" SortExpression="RowNumber">
                                                <ItemTemplate>
                                                    <%--Row Counts--%>

                                                    <asp:Label ID="lbl_RowNumber" runat="server" Text='<%# Bind("RowNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Place_Name" SortExpression="Place_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Place_Name" runat="server" Text='<%# Bind("Place_Name") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            
                                            <asp:TemplateField HeaderText="Guider_Name" SortExpression="Guider_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Guider_Name" runat="server" Text='<%# Bind("Guider_Name") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="tourist_Name" SortExpression="tourist_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_tourist_Name" runat="server" Text='<%# Bind("tourist_Name") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Date_Time" SortExpression="Date_Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Date_Time" runat="server" Text='<%# Bind("Date_Time") %>'></asp:Label>
                                                    <headerstyle horizontalalign="Left" />
                                                    <itemstyle horizontalalign="Left" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtn_Update" ImageUrl="~/Admin/assets/update.png" runat="server" CommandArgument='<%# Bind("ID") %>' CommandName="updte" Width="30px" /><asp:ImageButton ID="imgbtn_Delete" CommandName="Delte" ImageUrl="~/Admin/assets/del.png" Width="30px" runat="server" CommandArgument='<%# Bind("ID") %>' OnClientClick="return validateDelete();" />
                                                </ItemTemplate>
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

