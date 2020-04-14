<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.ascx.cs" Inherits="NBU.PayBill.Salary.Controls.AddNewEmployee" %>
<br />
<div class="form-row">
    <ul class="nav nav-tabs col-lg-12">
        <li class="active"><a data-toggle="tab" href="#basic">Basic Details</a></li>
        <li><a data-toggle="tab" href="#personal">Personal Details</a></li>
        <li><a data-toggle="tab" href="#university">University Related Details</a></li>
    </ul>

    <div class="tab-content col-lg-12">
        <div id="basic" class="tab-pane fade in active">
            <div class="form-group">
                <label for="uc_txt_Name">Name</label>
                <asp:TextBox CssClass="form-control" ID="uc_txt_Name" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
            <%--Calendar is not working.--%>
            <div class="form-group">
                <label for="uc_cal_DateOfBirth">Date of birth</label>
                <asp:TextBox CssClass="form-control" ID="uc_cal_DateOfBirth" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="uc_txt_UID">AADHAR UID number</label>
                <asp:TextBox CssClass="form-control" ID="uc_txt_UID" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="uc_txt_PAN">PAN card number</label>
                <asp:TextBox CssClass="form-control" ID="uc_txt_PAN" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="uc_txt_Phone">Phone number</label>
                <asp:TextBox CssClass="form-control" ID="uc_txt_Phone" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="uc_txt_Email">Email</label>
                <asp:TextBox CssClass="form-control" ID="uc_txt_Email" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
        </div>
        <div id="personal" class="tab-pane fade">
            <div class="form-group">
                <label for="uc_radio_Gender">Gender</label>
                <asp:RadioButtonList ID="uc_radio_Gender" CssClass="form-check" ClientIDMode="Static" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Male &nbsp&nbsp" Value="M"></asp:ListItem>
                    <asp:ListItem Text="Female &nbsp&nbsp" Value="F"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <label for="uc_radio_MaritalStatus">Marital Status </label>
                <asp:RadioButtonList ID="uc_radio_MaritalStatus" CssClass="form-check" ClientIDMode="Static" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Married &nbsp&nbsp" Value="M"></asp:ListItem>
                    <asp:ListItem Text="Single &nbsp&nbsp" Value="S"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <label for="uc_txt_Address">Address</label>
                <asp:TextBox ID="uc_txt_Address" CssClass="form-control" ClientIDMode="Static" runat="server" Rows="3"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="uc_ddl_Caste">Caste</label>
                <asp:DropDownList ID="uc_ddl_Caste" CssClass="form-check" runat="server" ClientIDMode="Static">
                    <asp:ListItem Text="General" Value="GEN"></asp:ListItem>
                    <asp:ListItem Text="OBC" Value="OBC"></asp:ListItem>
                    <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                    <asp:ListItem Text="ST" Value="ST"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="uc_ddl_Religion">Religion</label>
                <asp:DropDownList ID="uc_ddl_Religion" CssClass="form-check" ClientIDMode="Static" runat="server">
                    <asp:ListItem Text="Hindu" Value="H"></asp:ListItem>
                    <asp:ListItem Text="Muslim" Value="M"></asp:ListItem>
                    <asp:ListItem Text="Christian" Value="C"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="uc_ddl_BloodGroup">Blood Group</label>
                <asp:DropDownList ID="uc_ddl_BloodGroup" CssClass="form-check" AutoPostBack="true" ClientIDMode="Static" runat="server">
                    <asp:ListItem Text="A+" Value="AP"></asp:ListItem>
                    <asp:ListItem Text="A-" Value="AN"></asp:ListItem>
                    <asp:ListItem Text="B+" Value="BP"></asp:ListItem>
                    <asp:ListItem Text="B-" Value="BN"></asp:ListItem>
                    <asp:ListItem Text="O+" Value="OP"></asp:ListItem>
                    <asp:ListItem Text="O-" Value="ON"></asp:ListItem>
                    <asp:ListItem Text="AB+" Value="ABP"></asp:ListItem>
                    <asp:ListItem Text="AB-" Value="ABN"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="OTH"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="uc_txt_Qualification">Qualification</label>
                <asp:TextBox ID="uc_txt_Qualification" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="uc_txt_EmergencyContact">Emergency Contact</label>
                <asp:TextBox ID="uc_txt_EmergencyContact" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
        </div>
        <div id="university" class="tab-pane fade">
            <div class="form-group">
                <label for="uc_ddl_Department">Department</label>
                <asp:DropDownList ID="uc_ddl_Department" CssClass="form-check" ClientIDMode="Static" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="uc_ddl_Designation">Designation</label>
                <asp:DropDownList ID="uc_ddl_Designation" CssClass="form-check" ClientIDMode="Static" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="uc_cal_DateOfJoining">Date of Joining</label>
                <asp:TextBox ID="uc_cal_DateOfJoining" CssClass="form-control" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="uc_ddl_Category">Category</label>
                <asp:DropDownList ID="uc_ddl_Category" CssClass="form-check" ClientIDMode="Static" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:CheckBox ID="uc_check_QuarterProvided" ClientIDMode="Static" CssClass="form-check" runat="server" />
                <label for="uc_check_QuarterProvided">Is quarter provided? </label>
                <br />
                <label for="uc_txt_QuarterNumber">Quarter Number</label>
                <asp:TextBox ID="uc_txt_QuarterNumber" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:CheckBox ID="uc_check_IsRetired" ClientIDMode="Static" CssClass="form-check" runat="server" />
                <label for="uc_check_QuarterProvided">Is retired? </label>
                <br />
                <label for="uc_cal_DateOfRetirement">Date of Retirement</label>
                <asp:TextBox ID="uc_cal_DateOfRetirement" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="uc_cal_DateOfNextIncrement">Date of Next Increment</label>
                <asp:TextBox ID="uc_cal_DateOfNextIncrement" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="uc_txt_Remarks">Remarks</label>
                <asp:TextBox ID="uc_txt_Remarks" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
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
