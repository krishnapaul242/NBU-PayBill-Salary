<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Transaction.ascx.cs" Inherits="NBU.PayBill.Salary.Controls.Transaction" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <div class="container">
            <div class="row">
                <div class="col-lg-3">
                    <label>Name: </label>
                </div>
                <div class="col-lg-3">
                    <label>Department: </label>
                </div>
                <div class="col-lg-3">
                    <label>Designation: </label>
                </div>
                <div class="col-lg-3">
                    <label>Category: </label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-4"></div>
                <div class="col-lg-4"></div>
            </div>
        </div>
    </ItemTemplate>
</asp:FormView>
