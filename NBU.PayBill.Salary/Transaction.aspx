<%@ Page Title="Transaction" Language="C#" MasterPageFile="~/Salary.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="NBU.PayBill.Salary.Transaction" %>

<%@ Register Src="~/Controls/Transaction.ascx" TagName="TransactionControl" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
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
                        <asp:Label ID="lblEmpNameTXT" runat="server" ClientIDMode="Static" Text=" Employee Name: " Visible="true"></asp:Label>
                    </b>
                    <asp:TextBox AutoPostBack="true" ID="txtEmpName" runat="server" ClientIDMode="Static" OnTextChanged="txtEmpName_TextChanged"></asp:TextBox>
                    <b>
                        <asp:Label ID="lblCategoryDDL" runat="server" ClientIDMode="Static" Text=" Select Category: " Visible="false"></asp:Label>
                    </b>
                    <asp:DropDownList AutoPostBack="true" ID="ddlCategory" runat="server" Visible="false"></asp:DropDownList>
                    <b>
                        <asp:Label ID="lblDepartmentDDL" runat="server" ClientIDMode="Static" Text=" Select Department: " Visible="false"></asp:Label>
                    </b>
                    <asp:DropDownList AutoPostBack="true" ID="ddlDepartment" runat="server" Visible="false"></asp:DropDownList>
                    <b>
                        <asp:Label ID="lblDesignationDDL" runat="server" ClientIDMode="Static" Text=" Select Designation: " Visible="false"></asp:Label>
                    </b>
                    <asp:DropDownList AutoPostBack="true" ID="ddlDesignation" runat="server" Visible="false"></asp:DropDownList>
                    <b>
                        <asp:Label ID="lblEmployeeDDL" runat="server" ClientIDMode="Static" Text=" Select Employee: " Visible="true"></asp:Label>
                    </b>
                    <asp:DropDownList AutoPostBack="true" ID="ddlEmployee" runat="server" Visible="true"></asp:DropDownList>
                </div>
                <div class="col-lg-2">
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
                                <asp:GridView ID="gvSelectEmployees" runat="server">
                                    <Columns>
                                        <asp:CheckBoxField HeaderText="Select" ShowHeader="true" />
                                        <asp:BoundField HeaderText="Name" DataField="EmpName" />
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
                                <div class="container">
                                    <div class="row form-group">
                                        <div class="col-lg-3">
                                            <label class="control-label" for="txtEDEmployeeName">Name: </label>
                                            <asp:TextBox ID="txtEDEmployeeName" ClientIDMode="Static" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <label class="control-label" for="txtEDEmployeeDepartment">Department: </label>
                                            <asp:TextBox ID="txtEDEmployeeDepartment" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-3">
                                            <label class="control-label" for="txtEDEmployeeDesignation">Designation: </label>
                                            <asp:TextBox ID="txtEDEmployeeDesignation" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <label class="control-label" for="txtEDEmployeeCategory">Category: </label>
                                            <asp:TextBox ID="txtEDEmployeeCategory" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeBasicPay">Basic Pay: </label>
                                            <asp:TextBox ID="txtEDEmployeeBasicPay" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeGradePay">Grade Pay:</label>
                                            <asp:TextBox ID="txtEDEmployeeGradePay" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeSpecialPay">Special Pay: </label>
                                            <asp:TextBox ID="txtEDEmployeeSpecialPay" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeStartDay">Day Start: </label>
                                            <asp:TextBox ID="txtEDEmployeeStartDay" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeEndDay">Day End: </label>
                                            <asp:TextBox ID="txtEDEmployeeEndDay" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeAbsentDay">Absent Days: </label>
                                            <asp:TextBox ID="txtEDEmployeeAbsentDay" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-lg-8">
                                            <label class="control-label" for="txtEDEmployeeDNI">Date of Next Increment: </label>
                                            <asp:TextBox ID="txtEDEmployeeDNI" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeTag">Tag: </label>
                                            <asp:TextBox ID="txtEDEmployeeTag" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="panel panel-default container-fluid">
                                                <div class="panel-heading">
                                                    <label>Earnings</label>
                                                </div>
                                                <div class="panel-body">
                                                    <asp:Repeater ID="repeaterEarnings" runat="server">
                                                        <ItemTemplate>
                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    <label></label>
                                                                </div>
                                                                <div class="col-lg-6">
                                                                    <label></label>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="panel panel-default container-fluid">
                                                <div class="panel-heading">
                                                    <label>Deductions</label>
                                                </div>
                                                <div class="panel-body">
                                                    <asp:Repeater ID="repeaterDeductions" runat="server">
                                                        <ItemTemplate>
                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    <label></label>
                                                                </div>
                                                                <div class="col-lg-6">
                                                                    <label></label>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-lg-12">
                                            <label class="control-label" for="txtEDEmployeeMessage">Message: </label>
                                            <asp:TextBox ID="txtEDEmployeeMessage" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeGrossPay">Gross Pay: </label>
                                            <asp:TextBox ID="txtEDEmployeeGrossPay" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeGrossDeduction">Gross Deduction: </label>
                                            <asp:TextBox ID="txtEDEmployeeGrossDeduction" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-4">
                                            <label class="control-label" for="txtEDEmployeeNetPay">Net Pay: </label>
                                            <asp:TextBox ID="txtEDEmployeeNetPay" CssClass="form-control form-inline" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-footer" style="padding: 2px !important;">
                                <p class="text-muted text-right" style="margin:2px !important; padding: 2px !important;"><asp:Label ID="footerDateTime" runat="server"></asp:Label></p>
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
