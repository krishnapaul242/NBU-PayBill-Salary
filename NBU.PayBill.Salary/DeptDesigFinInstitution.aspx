<%@ Page Title="" Language="C#" MasterPageFile="~/Salary.Master" AutoEventWireup="true" CodeBehind="DeptDesigFinInstitution.aspx.cs" Inherits="NBU.PayBill.Salary.DeptDesigFinInstitution" %>

<%@ Register TagPrefix="Forms" TagName="Department" Src="~/Controls/DepartmentDetails.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Departments, Designation and Financial Institutions</div>
         <div class="panel-body">
             <div class="container">
                 <div class="row">
                     <div class="col-md-4">
                         <div class="well well-sm"></div>
                         <asp:GridView runat="server" ID="gv_Department" CssClass="table table-hover">
                             <RowStyle CssClass="row" HorizontalAlign="Left" VerticalAlign="Middle" />
                             <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                            <asp:Label ID="lbl_DeptName" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                         </asp:GridView>
                     </div>
                     <div class="col-md-4">
                         <div class="well well-sm"></div>
                         <asp:GridView runat="server" ID="gv_Deignation" CssClass="table table-hover">
                             <RowStyle CssClass="row" HorizontalAlign="Left" VerticalAlign="Middle" />
                             <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                            <asp:Label ID="lbl_DeptName" runat="server" Text='<%# Eval("DesignationName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                         </asp:GridView>
                     </div>
                     <div class="col-md-4">
                         <div class="well well-sm"></div>
                         <asp:GridView runat="server" ID="gv_FinInst" CssClass="table table-hover">
                             <RowStyle CssClass="row" HorizontalAlign="Left" VerticalAlign="Middle" />
                             <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                            <asp:Label ID="lbl_DeptName" runat="server" Text='<%# Eval("FinancialInstitutionName") %>'></asp:Label>
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
        <Forms:Department runat="server" ID="Form_Department" />
    </div>
</asp:Content>
