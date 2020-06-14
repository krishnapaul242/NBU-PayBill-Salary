<%@ Page Title="Salary, Earnings And Deductions" Language="C#" MasterPageFile="~/Salary.Master" AutoEventWireup="true" CodeBehind="SalaryEarningsDeductions.aspx.cs" Inherits="NBU.PayBill.Salary.SalaryEarningsDeductions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="row">
                <div class="col-md-2 col-sm-12 mx-auto"><b>Salary, Earnings & Deductions</b> </div>
                <div class="col-md-2 col-sm-6 mr-3">
                    <asp:DropDownList AutoPostBack="false" ID="ddlCategory" ToolTip="Select Category" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" DataTextField="CategoryName" DataValueField="CategoryID">
                        <asp:ListItem Text="Select Category" Value="null" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-6 mr-3">
                    <asp:DropDownList AutoPostBack="false" ID="ddlDepartment" ToolTip="Select Department" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" DataTextField="DepartmentName" DataValueField="DepartmentCD">
                        <asp:ListItem Text="Select Department" Value="null" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-6 mr-3">
                    <asp:DropDownList AutoPostBack="false" ID="ddlDesignation" ToolTip="Select Designation" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" DataTextField="DesignationName" DataValueField="DesignationCD">
                        <asp:ListItem Text="Select Designation" Value="null" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-6 mr-3">
                    <asp:TextBox AutoPostBack="false" ID="txtEmpName" ToolTip="Type Employee Name" placeholder="Enter Employee Name" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-12">
                    <asp:Button ID="btnFilterEmployees" runat="server" ToolTip="Filter and Load employee data" CssClass="btn btn-block btn-default" Text="Filter Employees" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 col-sm-12"></div>
                <div class="col-md-3 col-sm-4">
                    <asp:Button ID="btnEarningsDeductions" runat="server" ToolTip="Add, Edit, and Update Earnings and Deductions" CssClass="btn btn-block btn-default" Text="Earnings and Deductions Actions" />
                </div>
                <div class="col-md-3 col-sm-4">
                    <asp:Button ID="btnPayScale" runat="server" ToolTip="Add and Update Payment Scales" CssClass="btn btn-block btn-default" Text="Payment Scales" />
                </div>
                <div class="col-md-3 col-sm-4">
                    <asp:Button ID="btnSubcategory" runat="server" ToolTip="Add and Update Employee Subcategories" CssClass="btn btn-block btn-default" Text="Employee Subcategories" />
                </div>

            </div>
        </div>
        <div class="panel-body">
            <div id="PayscaleBox" runat="server" visible="false">
                <div class="row">
                    <div class="col-md-4">
                        <label for="PStxtEffMonthYear">Effective Month and Year</label>
                        <asp:TextBox ID="PStxtEffMonthYear" type="month" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="PSddlCategory">Category</label>
                        <asp:DropDownList ID="PSddlCategory" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control" DataTextField="CategoryName" DataValueField="CategoryID">
                            <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label for="PStxtPyBandNum">Pay Band Number</label>
                        <asp:TextBox ID="PStxtPayBandNum" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <label for="PStxtStartPay">Start Payment</label>
                        <asp:TextBox ID="PStxtStartPay" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label for="PStxtEndPay">End Pay</label>
                        <asp:TextBox ID="PStxtEndPay" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label for="PStxtGradePay">Grade Pay</label>
                        <asp:TextBox ID="PStxtGradePay" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label for="PStxtSpecialPay">Special Pay</label>
                        <asp:TextBox ID="PStxtSpecialPay" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="EarningDeductionBox" runat="server" visible="true">
                <div class="row">
                    <div class="col-md-2 col-sm-4">
                        <label for="EDtxtName">Name</label>
                        <asp:TextBox ID="EDtxtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-sm-4">
                        <label for="EDddlType">Type</label>
                        <asp:DropDownList ID="EDddlType" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control">
                            <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Earning" Value="E"></asp:ListItem>
                            <asp:ListItem Text="Deduction" Value="D"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-sm-4">
                        <label for="EDddlForAll">Applicable to All?</label>
                        <asp:DropDownList ID="EDddlForAll" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control">
                            <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="T"></asp:ListItem>
                            <asp:ListItem Text="No" Value="F"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6 col-sm-12">
                        <label for="EDtxtDescription">Description</label>
                        <asp:TextBox ID="EDtxtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-sm-4">
                        <label for="EDddlForAll">Fixed or Variable?</label>
                        <asp:DropDownList ID="EDddlFixedVariable" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control">
                            <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Fixed" Value="F"></asp:ListItem>
                            <asp:ListItem Text="Variable" Value="V"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-sm-4">
                        <label for="EDtxtWEFmonthYear">Effective Month and Year</label>
                        <asp:TextBox ID="EDtxtWEFmonthYear" type="month" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-sm-4">
                        <label for="EDddlCategory">Category</label>
                        <asp:DropDownList AutoPostBack="false" ID="EDddlCategory" ToolTip="Select Category" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" DataTextField="CategoryName" DataValueField="CategoryID">
                            <asp:ListItem Text="Select Category" Value="null" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-sm-4">
                        <label for="EDtxtScale">Scale</label>
                        <asp:TextBox ID="EDtxtScale" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4 col-sm-8">
                        <label for="EDlstDesignations">Select Subcategory</label>
                        <asp:DropDownList ID="EDlstDesignations" runat="server" CssClass="form-control" ItemType="">
                            <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="A" Value="null"></asp:ListItem>
                            <asp:ListItem Text="B" Value="null"></asp:ListItem>
                            <asp:ListItem Text="C" Value="null"></asp:ListItem>
                            <asp:ListItem Text="D" Value="null"></asp:ListItem>
                            <asp:ListItem Text="E" Value="null"></asp:ListItem>
                            <asp:ListItem Text="F" Value="null"></asp:ListItem>
                            <asp:ListItem Text="G" Value="null"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 col-sm-6">
                        <label for="EDtxtFixedValue">Fixed Value</label>
                        <asp:TextBox ID="EDtxtFixedValue" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <label for="EDtxtConditionOperator">Condition Operator</label>
                        <asp:TextBox ID="EDtxtConditionOperator" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <label for="EDtxtConditionValue">Condition Value</label>
                        <asp:TextBox ID="EDtxtConditionValue" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <label for="EDtxtMaxValue">Max Value</label>
                        <asp:TextBox ID="EDtxtMaxValue" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
