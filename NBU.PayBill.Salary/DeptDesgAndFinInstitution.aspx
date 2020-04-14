﻿<%@ Page Title="Departments, Designation and Financial Institutions" Language="C#" MasterPageFile="~/Salary.Master" AutoEventWireup="true" CodeBehind="DeptDesgAndFinInstitution.aspx.cs" Inherits="NBU.PayBill.Salary.DeptDesgAndFinInstitution" %>

<%@ Register TagPrefix="uc" TagName="UCaddNewDD" Src="~/Controls/DepartmentAndDesignationDetails.ascx" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Departments, Designation and Financial Institutions</div>
        <div class="panel-body">
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <div class="well well-sm">
                            <asp:Label ID="lblTitleDept" ClientIDMode="Static" CssClass="h4" runat="server" Text="Departments"></asp:Label>
                        </div>
                        <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true">
                            <HeaderStyle CssClass="gvHeader" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <RowStyle CssClass="gvRows" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeptName" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-4">
                        <div class="well well-sm">
                            <asp:Label ID="lblTitleDesg" ClientIDMode="Static" CssClass="h4" runat="server" Text="Designations"></asp:Label>
                        </div>
                        <asp:GridView ID="gvDesignation" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true">
                            <HeaderStyle CssClass="gvHeader" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <RowStyle CssClass="gvRows" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Designation">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesgName" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-4">
                        <div class="well well-sm">
                            <asp:Label ID="lblTitleFinInst" ClientIDMode="Static" CssClass="h4" runat="server" Text="Financial Institutions"></asp:Label>
                        </div>
                        <asp:GridView ID="gvFinInstitution" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true">
                            <HeaderStyle CssClass="gvHeader" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <RowStyle CssClass="gvRows" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Financial Institution Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFinInstitutionName" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFinInstitutionAddress" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-footer">
            <%--Label for No Records Found--%>
            <asp:Label ID="lblNoRecordsFound" runat="server" Text=""></asp:Label>
            <br />
            <a href="#addDepartmentForm" class="btn btn-primary" rel="modal:open">+ Add New Department </a>
            <a href="#addDesignationForm" class="btn btn-primary" rel="modal:open">+ Add New Designation </a>
            <a href="#addFinInstitutionForm" class="btn btn-primary" rel="modal:open">+ Add New Financial Institution </a>
        </div>
    </div>
    <div class="modal" id="addDepartmentForm">
        <div class="form-row">
            <div class="form-group col-md-12 well well-sm">
                <asp:Label ID="uc_lbl_title" ClientIDMode="Static" CssClass="h3" runat="server" Text="Add New Department"></asp:Label>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-12">
                <label for="txtDeptName">Name</label>
                <asp:TextBox CssClass="form-control" ID="txtDeptName" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-12">
                <label for="txtBankAcc">Bank Account Number</label>
                <asp:TextBox CssClass="form-control" ID="txtBankAcc" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Button ID="btnDeptAdd" CssClass="btn btn-danger btn-block text-center" ClientIDMode="Static" runat="server" Text="Cancel" />
            </div>
            <div class="form-group col-md-4">
                <asp:Button ID="btnDeptClear" CssClass="btn btn-secondary btn-block text-center" ClientIDMode="Static" runat="server" Text="Clear" />
            </div>
            <div class="form-group col-md-4">
                <asp:Button ID="btnDeptCancel" CssClass="btn btn-success btn-block text-center" ClientIDMode="Static" runat="server" Text="Submit" />
            </div>
        </div>
    </div>
    <div class="modal" id="addDesignationForm">
        <div class="form-row">
            <div class="form-group col-md-12 well well-sm">
                <asp:Label ID="Label1" ClientIDMode="Static" CssClass="h3" runat="server" Text="Add New Designation"></asp:Label>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-12">
                <label for="txtDesigName">Name</label>
                <asp:TextBox CssClass="form-control" ID="txtDesigName" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Button ID="btnDesigAdd" CssClass="btn btn-danger btn-block text-center" ClientIDMode="Static" runat="server" Text="Cancel" />
            </div>
            <div class="form-group col-md-4">
                <asp:Button ID="btnDesigClear" CssClass="btn btn-secondary btn-block text-center" ClientIDMode="Static" runat="server" Text="Clear" />
            </div>
            <div class="form-group col-md-4">
                <asp:Button ID="btnDesigCancel" CssClass="btn btn-success btn-block text-center" ClientIDMode="Static" runat="server" Text="Submit" />
            </div>
        </div>
    </div>
    <div class="modal" id="addFinInstitutionForm">
        <div class="form-row">
            <div class="form-group col-md-12 well well-sm">
                <asp:Label ID="Label2" ClientIDMode="Static" CssClass="h3" runat="server" Text="Add New Financial Institution"></asp:Label>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-12">
                <label for="txtFinInstName">Name</label>
                <asp:TextBox CssClass="form-control" ID="txtFinInstName" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-12">
                <label for="txtFinInstAddress">Address</label>
                <asp:TextBox CssClass="form-control" ID="txtFinInstAddress" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Button ID="btnFinInstAdd" CssClass="btn btn-danger btn-block text-center" ClientIDMode="Static" runat="server" Text="Cancel" />
            </div>
            <div class="form-group col-md-4">
                <asp:Button ID="btnFinInstClear" CssClass="btn btn-secondary btn-block text-center" ClientIDMode="Static" runat="server" Text="Clear" />
            </div>
            <div class="form-group col-md-4">
                <asp:Button ID="btnFinInstCancel" CssClass="btn btn-success btn-block text-center" ClientIDMode="Static" runat="server" Text="Submit" />
            </div>
        </div>
    </div>
</asp:Content>
