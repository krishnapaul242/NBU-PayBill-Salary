<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EarningAndDeductionDetails.ascx.cs" Inherits="NBU.PayBill.Salary.Controls.AddNewEarning" %>
<div class="form-row">
    <div class="form-group col-md-12 well well-sm">
<asp:Label ID="uc_lbl_title" ClientIDMode="Static" CssClass="h3" runat="server"></asp:Label>
</div>
</div>

<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_radio_applicableToAll">Is this applicable to all employees?</label>
        <asp:RadioButtonList ID="uc_radio_applicableToAll" CssClass="form-check" ClientIDMode="Static" runat="server" RepeatDirection="Horizontal" >
            <asp:ListItem Text="Yes &nbsp&nbsp" Value="T"></asp:ListItem>
            <asp:ListItem Text="No" Value="F"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_txt_Name">Name</label>
        <asp:TextBox CssClass="form-control" ID="uc_txt_Name" ClientIDMode="Static" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_txt_description">Description</label>
        <asp:TextBox CssClass="form-control" ID="uc_txt_description" ClientIDMode="Static" runat="server"></asp:TextBox>
    </div>
</div>
<%--For now textboxes are used for multi select, Later on jquery will be used to implement the multi select--%>
<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_ddl_categories">Select Applicable Employee Categories</label>
        <asp:DropDownList CssClass="form-control" ID="uc_ddl_categories" ClientIDMode="Static" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_ddl_subcategories">Select Applicable Employee Subcategories</label>
        <asp:DropDownList CssClass="form-control" ID="uc_ddl_subcategories" ClientIDMode="Static" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-12">
        <b><asp:label id="uc_lbl_fixedOrVarriable" runat="server" ClientIDMode="Static" for="uc_radio_fixedOrVariable"></asp:label></b>
        <asp:RadioButtonList ID="uc_radio_fixedOrVariable" CssClass="form-check" ClientIDMode="Static" runat="server" RepeatDirection="Horizontal" >
            <asp:ListItem Text="Yes &nbsp&nbsp" Value="T"></asp:ListItem>
            <asp:ListItem Text="No" Value="F"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_txt_value">Value</label>
        <asp:TextBox CssClass="form-control" ID="uc_txt_value" ClientIDMode="Static" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-row">
    <div class="col-md-12">
        <b>Eligibility Condition: </b>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-6">
        <label for="uc_radio_eligibilityConditionOperator">If basic salay is</label>
        <asp:RadioButtonList ID="uc_radio_eligibilityConditionOperator" CssClass="form-check" ClientIDMode="Static" runat="server" RepeatDirection="Horizontal" >
            <asp:ListItem Text="Greater &nbsp&nbsp" Value="gt"></asp:ListItem>
            <asp:ListItem Text="Less " Value="lt"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div class="form-group col-md-6">
        <label for="uc_txt_eligibilityConditionValue">than</label>
        <asp:TextBox CssClass="form-control" ID="uc_txt_eligibilityConditionValue" ClientIDMode="Static" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-row">
    <div class="form-group col-md-12">
        <label for="uc_txt_maxValue">Maximum Value</label>
        <asp:TextBox CssClass="form-control" ID="uc_txt_maxValue" ClientIDMode="Static" runat="server"></asp:TextBox>
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
