<%@ Page Title="Employee" Language="C#" MasterPageFile="~/Salary.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="NBU.PayBill.Salary.Employee" %>

<%@ Register Src="~/Controls/EmployeeDetails.ascx" TagPrefix="uc" TagName="EmployeeDetails" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">&nbsp Employees </div>
        <div class="panel-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-2">
                        <div class="panel panel-default">
                            <a class="panel-heading btn btn-block" data-toggle="collapse" href="#FilterBox" role="button" aria-expanded="false" aria-controls="FilterBox">&nbsp Filter </a>
                            <div class="panel-body collapse" id="FilterBox" style="display:block;">
                                <div class="container-fluid">
                                    <div class="row">
                                        <b>
                                            <asp:Label ID="lblCategoryDDL" runat="server" ClientIDMode="Static" Text=" Select Category: " Visible="true"></asp:Label></b>
                                    </div>
                                    <div class="row">
                                        <asp:DropDownList AutoPostBack="false" ID="ddlCategory" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                            <asp:ListItem Text="Please Select" Value="null" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        <b>
                                            <asp:Label ID="lblDepartmentDDL" runat="server" ClientIDMode="Static" Text=" Select Department: " Visible="true"></asp:Label></b>
                                    </div>
                                    <div class="row">
                                        <asp:DropDownList AutoPostBack="false" ID="ddlDepartment" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                            <asp:ListItem Text="Please Select" Value="null" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        <b>
                                            <asp:Label ID="lblDesignationDDL" runat="server" ClientIDMode="Static" Text=" Select Designation: " Visible="true"></asp:Label></b>
                                    </div>
                                    <div class="row">
                                        <asp:DropDownList AutoPostBack="false" ID="ddlDesignation" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged">
                                            <asp:ListItem Text="Please Select" Value="null" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        <b>
                                            <asp:Label ID="lblEmpNameTXT" runat="server" ClientIDMode="Static" Text=" Employee Name: " Visible="true"></asp:Label></b>
                                    </div>
                                    <div class="row">
                                        <asp:TextBox AutoPostBack="false" ID="txtEmpName" runat="server" CssClass="form-control" ClientIDMode="Static" OnTextChanged="txtEmpName_TextChanged"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <asp:Button ID="btnLoadEmployees" runat="server" CssClass="btn btn-block btn-default" Text="Load Employees" OnClick="btnLoadEmployees_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <a class="panel-heading btn btn-block" data-toggle="collapse" href="#ActionBox" role="button" aria-expanded="false" aria-controls="ActionBox">&nbsp Actions </a>
                            <div class="panel-body collapse" id="ActionBox">
                                <div class="container-fluid">
                                    <div class="row">
                                        <asp:Button ID="btnAddNewEmp" runat="server" OnClick="BtnAddNewEmp_Click" CssClass="btn btn-primary" Text="+ Add New Employee "></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <b>&nbsp Employees </b> <asp:LinkButton ID ="btnEditSelected" runat="server" OnClick="btnEditSelected_Click" ToolTip="Edit Selected Employees" Visible="false"><i class="fas fa-edit"></i></asp:LinkButton>
                            </div>
                            <div class="panel-body" style="max-height: 700px;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" BorderStyle="None">

                                    <Columns>
                                        <asp:TemplateField ItemStyle-BorderStyle="None" ItemStyle-BorderWidth="0px" ItemStyle-BorderColor="Transparent" ControlStyle-BorderStyle="None">
                                            <HeaderTemplate></HeaderTemplate>
                                            <ControlStyle BorderStyle="None" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" CssClass="checkbox-inline form-control" Font-Size="XX-Small" ToolTip='<%# Eval("EmpName") %>' Text='<%# Eval("EmpName") %>' />
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
                    <div class="col-lg-8">
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
