<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentAndDesignationDetails.ascx.cs" Inherits="NBU.PayBill.Salary.Controls.AddNewDepartment" %>
<div class="form-row">
    <div class="form-group col-md-12 well well-sm">
        <asp:Label ID="uc_lbl_title" ClientIDMode="Static" CssClass="h3" runat="server"></asp:Label>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_txt_Name">Name</label>
        <asp:TextBox CssClass="form-control" ID="uc_txt_Name" ClientIDMode="Static" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-4">
        <asp:Button ID="uc_btn_cancel" CssClass="btn btn-danger btn-block text-center" ClientIDMode="Static" runat="server" Text="Cancel" />
    </div>
    <div class="form-group col-md-4">
        <asp:Button ID="uc_btn_clear" CssClass="btn btn-secondary btn-block text-center" ClientIDMode="Static" runat="server" Text="Clear" />
    </div>
    <div class="form-group col-md-4">
        <asp:Button ID="uc_btn_submit" CssClass="btn btn-success btn-block text-center" ClientIDMode="Static" runat="server" Text="Submit" />
    </div>
</div>
