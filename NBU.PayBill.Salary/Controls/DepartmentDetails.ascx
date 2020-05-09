<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentDetails.ascx.cs" Inherits="NBU.PayBill.Salary.Controls.DepartmentDetails" %>
<div class="form-row">
    <div class="form-group col-md-12 well well-sm">
        <asp:Label ID="uc_lbl_title" ClientIDMode="Static" CssClass="h3" runat="server" Text="Add New Department"></asp:Label>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_txt_Name">Name</label>
        <asp:TextBox CssClass="form-control" Text="Department Name" ID="uc_txt_Name" ClientIDMode="Static" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_txt_BankAcc">Bank Account Number</label>
        <asp:TextBox CssClass="form-control" Text="Bank Account" ID="uc_txt_BankAcc" ClientIDMode="Static" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-4">
        <asp:Button ID="uc_btn_submit" runat="server" OnClick="uc_btn_submit_Click" CssClass="btn btn-block btn-success text-center" Text="Submit" />
    </div>
    <div class="form-group col-md-4">
        <asp:Button ID="uc_btn_clear" CssClass="btn btn-secondary btn-block text-center" ClientIDMode="Static" runat="server" Text="Clear" />
    </div>
    <div class="form-group col-md-4">
        <asp:Button ID="uc_btn_cancel" CssClass="btn btn-danger btn-block text-center" ClientIDMode="Static" runat="server" Text="Cancel" />
    </div>
</div>
