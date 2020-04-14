<%@ Page Title="Employee" Language="C#" MasterPageFile="~/Salary.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="NBU.PayBill.Salary.Employee" %>

<%@ Register Src="~/Controls/EmployeeDetails.ascx" TagPrefix="uc" TagName="EmployeeDetails" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <%--Problems lies in this script section with bootstrap date picker--%>
    <%--<!-- Bootstrap -->
    <script type="text/javascript" src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
        media="screen" />
    <!-- Bootstrap DatePicker -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <!-- Bootstrap DatePicker -->
    <script type="text/javascript">
        $(function () {
            $("#uc_txt_DOB").datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "en"
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="row">
                <div class="col-lg-10">
                    <label for="">Select Employee by </label>
                    <%--Dropdown list for Employee selection method (by employee name; by dept, category and subcategory; by dept and designation)--%>
                    <asp:DropDownList AutoPostBack="true" ID="ddlSelectionMethod" runat="server" OnSelectedIndexChanged="ddlSelectionMethod_SelectedIndexChanged">
                        <asp:ListItem Text="Employee Name" Value="EN"></asp:ListItem>
                        <asp:ListItem Text="Department and Category" Value="DCS"></asp:ListItem>
                        <asp:ListItem Text="Department and Designation" Value="DD"></asp:ListItem>
                    </asp:DropDownList>
                    <b>
                        <asp:Label ID="lblEmpNameTXT" runat="server" ClientIDMode="Static" Text=" Employee Name: " Visible="true"></asp:Label></b>
                    <asp:TextBox AutoPostBack="true" ID="txtEmpName" runat="server" ClientIDMode="Static" OnTextChanged="txtEmpName_TextChanged"></asp:TextBox>
                    <b>
                        <asp:Label ID="lblCategoryDDL" runat="server" ClientIDMode="Static" Text=" Select Category: " Visible="false"></asp:Label></b>
                    <asp:DropDownList AutoPostBack="true" ID="ddlCategory" runat="server" Visible="false"></asp:DropDownList>
                    <b>
                        <asp:Label ID="lblDepartmentDDL" runat="server" ClientIDMode="Static" Text=" Select Department: " Visible="false"></asp:Label></b>
                    <asp:DropDownList AutoPostBack="true" ID="ddlDepartment" runat="server" Visible="false"></asp:DropDownList>
                    <b>
                        <asp:Label ID="lblDesignationDDL" runat="server" ClientIDMode="Static" Text=" Select Designation: " Visible="false"></asp:Label></b>
                    <asp:DropDownList AutoPostBack="true" ID="ddlDesignation" runat="server" Visible="false"></asp:DropDownList>
                    <b>
                        <asp:Label ID="lblEmployeeDDL" runat="server" ClientIDMode="Static" Text=" Select Employee: " Visible="true"></asp:Label></b>
                    <asp:DropDownList AutoPostBack="true" ID="ddlEmployee" runat="server" Visible="true"></asp:DropDownList>
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btnAddNewEmp" runat="server" OnClick="BtnAddNewEmp_Click" CssClass="btn btn-primary" Text="+ Add New Employee "></asp:Button>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-2">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <b>&nbsp Employees </b>
                            </div>
                            <div class="panel-body" style="max-height: 700px;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" BorderStyle="None">
                                    
                                    <Columns>
                                        <asp:TemplateField ItemStyle-BorderStyle="None" ItemStyle-BorderWidth="0px" ItemStyle-BorderColor="Transparent" ControlStyle-BorderStyle="None">
                                            <HeaderTemplate></HeaderTemplate>
                                            <ControlStyle BorderStyle="None" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" CssClass="checkbox-inline" Text='<%# Eval("[Name]") %>'/>
                                            </ItemTemplate>
                                            <FooterTemplate></FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <label>Nothing to show.</label>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                            <div class="panel-footer"></div>
                        </div>
                    </div>
                    <div class="col-lg-10">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <b>&nbsp Employee Details</b>
                            </div>
                            <div class="panel-body" style="max-height: 700px;">
                                <uc:EmployeeDetails ClientIDMode="Static" ID="EmployeeDetailsView" runat="server" Visible="false" />
                            </div>
                            <div class="panel-footer">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer">
        </div>
    </div>

</asp:Content>
