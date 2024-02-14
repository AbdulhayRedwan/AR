<%@ Page Title="" Language="C#" MasterPageFile="~/Guider/MasterGuider.master" AutoEventWireup="true" CodeFile="Update_My_Account.aspx.cs" Inherits="Guider_Update_My_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="app-content content">
        <div class="content-wrapper">
            <div class="content-wrapper-before"></div>
            <div class="content-header row">
                <div class="content-header-left col-md-4 col-12 mb-2">
                    <h3 class="content-header-title">Manage Guider</h3>
                </div>
                <div class="content-header-right col-md-8 col-12">
                    <div class="breadcrumbs-top float-md-right">
                        <div class="breadcrumb-wrapper mr-1">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Admin_Default.aspx">Home</a>
                                </li>
                                <li class="breadcrumb-item active">Guider
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


                                <table width="90%" class="table table-borderless mb-0">
                                    <tr id="Tr1" runat="server" visible="false">
                                        <td>
                                            <asp:Label ID="lbl_Id_H" runat="server" Text="Id"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lbl_Id" runat="server"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Full_Name_H" runat="server" Text="Full Name"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txt_Full_Name" runat="server" MaxLength="50" Width="90%" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_Full_Name" runat="server" ControlToValidate="txt_Full_Name" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Age_H" runat="server" Text="Age"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txt_BOD" runat="server" MaxLength="10" Width="90%" class="form-control" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_Age" runat="server" ControlToValidate="txt_BOD" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Email_H" runat="server" Text="Email"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txt_Email" runat="server" Width="90%" class="form-control"></asp:TextBox>
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="f" ControlToValidate="txt_Email" runat="server" ErrorMessage="*please Enter Correct Email"     ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>

                                            <asp:RequiredFieldValidator ID="RFV_Email" runat="server" ControlToValidate="txt_Email" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Password_H" runat="server" Text="Password"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txt_Password" runat="server" MaxLength="50" Width="90%" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_Password" runat="server" ControlToValidate="txt_Password" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Telephone_H" runat="server" Text="Telephone"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txt_Tel" runat="server" MaxLength="50" Width="90%" class="form-control" TextMode="Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_Telephone" runat="server" ControlToValidate="txt_Tel" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Address_H" runat="server" Text="Address"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txt_Address" runat="server" MaxLength="50" Width="90%" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV_Ttxt_Address" runat="server" ControlToValidate="txt_Address" ValidationGroup="f" CssClass="failureNotification">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                     
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Gender_H" runat="server" Text="Gender"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="ddl_Gender" runat="server" class="form-control" Width="90%">

                                                <asp:ListItem>--Gender--</asp:ListItem>

                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>

                                </table>

                                <p>
                                    <asp:Label ID="lbl_SaveSuccess" runat="server" Text="" CssClass="failureNotification"></asp:Label>
                                    <asp:ValidationSummary ID="VS8" runat="server" ValidationGroup="f" CssClass="failureNotification" /> 

                                <p dir="ltr">
                                        <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" ValidationGroup="f" class="btn btn-secondary btn-min-width mr-1 mb-1" />
                                      
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
                           <%-- <div class="card-body">
                                <div class="card-text">
                                    <p>The data of admin have been stored and viewd here  .</p>
                                </div>
                            </div>--%>
                           
                            </div>
                        </div>
                    </div>
                </section>

            </div>
        </div>
    </div>
   
    <!-- ////////////////////////////////////////////////////////////////////////////-->


    </asp:Content>