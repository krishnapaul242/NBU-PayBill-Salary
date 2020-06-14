<%@ Page Title="Employee" Language="C#" MasterPageFile="~/Salary.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="NBU.PayBill.Salary.Employee" %>

<%@ Register Src="~/Controls/EmployeeDetails.ascx" TagPrefix="uc" TagName="EmployeeDetails" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="row">
                <div class="col-md-2 mx-auto">&nbsp <b>Employees</b> </div>
                <div class="col-md-2 mr-3">
                    <asp:DropDownList AutoPostBack="false" ID="ddlCategory" ToolTip="Select Category" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" DataTextField="CategoryName" DataValueField="CategoryID">
                        <asp:ListItem Text="Select Category" Value="null" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 mr-3">
                    <asp:DropDownList AutoPostBack="false" ID="ddlDepartment" ToolTip="Select Department" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" DataTextField="DepartmentName" DataValueField="DepartmentCD">
                        <asp:ListItem Text="Select Department" Value="null" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 mr-3">
                    <asp:DropDownList AutoPostBack="false" ID="ddlDesignation" ToolTip="Select Designation" runat="server" Visible="true" CssClass="form-control" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" DataTextField="DesignationName" DataValueField="DesignationCD">
                        <asp:ListItem Text="Select Designation" Value="null" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 mr-3">
                    <asp:TextBox AutoPostBack="false" ID="txtEmpName" ToolTip="Type Employee Name" placeholder="Enter Employee Name" runat="server" CssClass="form-control" ClientIDMode="Static" OnTextChanged="txtEmpName_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnLoadEmployees" runat="server" ToolTip="Filter and Load employee data" CssClass="btn btn-block btn-default" Text="Filter Employees" OnClick="btnLoadEmployees_Click" />
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="container-fluid">
                <div class="row">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-3 mr-3"><b>&nbsp Employee Details</b> </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control" ToolTip="Select Employee to Load data" AutoPostBack="true" ClientIDMode="Static" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Select Employee" Value="null" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="max-height: 700px;">
                            <div class="row">
                                <div class="col-md-6 mr-3 ">

                                    <label for="ed_Name">Name</label>
                                    <asp:TextBox ID="ed_Name" runat="server" CssClass="form-control" placeholder="Employee Name"></asp:TextBox>

                                </div>
                                <div class="col-md-3 mr-3 ">

                                    <label for="ed_UID">AADHAR UID Number</label>
                                    <asp:TextBox ID="ed_UID" runat="server" CssClass="form-control" placeholder="e.g. 1245 7845 6548"></asp:TextBox>

                                </div>
                                <div class="col-md-3">

                                    <label for="ed_PAN">PAN</label>
                                    <asp:TextBox ID="ed_PAN" runat="server" CssClass="form-control" placeholder="e.g. ABCDE1234F"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row" style="margin-top:2rem">
                                <div class="col-md-6 mr-3 ">

                                    <label for="ed_Address">Address</label>
                                    <asp:TextBox ID="ed_Address" runat="server" CssClass="form-control" placeholder="Full Correspondance Address"></asp:TextBox>

                                </div>
                                <div class="col-md-4 mr-3 ">

                                    <label for="ed_Email">Email ID</label>
                                    <asp:TextBox ID="ed_Email" runat="server" CssClass="form-control" placeholder="e.g. name@xyz.com"></asp:TextBox>

                                </div>
                                <div class="col-md-2 mr-3 ">

                                    <label for="ed_Phone">Mobile / Phone</label>
                                    <asp:TextBox ID="ed_Phone" runat="server" CssClass="form-control" placeholder="e.g. 9876543210"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row" style="margin-top:2rem">
                                <div class="col-md-2 mr-3 ">

                                    <label for="ed_IsActive">Is Employee Active?</label>
                                    <asp:TextBox ID="ed_IsActive" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                                </div>
                                <div class="col-md-2 mr-3 ">

                                    <label for="ed_DOB">Date of Birth</label>
                                    <asp:TextBox ID="ed_DOB" type="date" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-md-2 mr-3 ">

                                    <label for="ed_DOJ">Date of Joining</label>
                                    <asp:TextBox ID="ed_DOJ" type="date" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-md-2 mr-3 ">

                                    <label for="ed_DOR">Date of Retirement</label>
                                    <asp:TextBox ID="ed_DOR" type="date" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-md-2 mr-3 ">

                                    <label for="ed_DNI">Date of Next Increment</label>
                                    <asp:TextBox ID="ed_DNI" type="date" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-md-2 mr-3 ">

                                    <label for="ed_Quarter">Quarter Number</label>
                                    <asp:TextBox ID="ed_Quarter" runat="server" CssClass="form-control" placeholder="Optional"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row" style="margin-top:2rem">
                                <div class="col-md-3 mr-3 ">

                                    <label for="ed_ddlGender">Gender</label>
                                    <asp:DropDownList ID="ed_ddlGender" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-3 mr-3 ">

                                    <label for="ed_ddlMStatus">Marital Status</label>
                                    <asp:DropDownList ID="ed_ddlMStatus" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Married" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Single" Value="S"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-3 mr-3 ">

                                    <label for="ed_ddlCaste">Caste</label>
                                    <asp:DropDownList ID="ed_ddlCaste" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="General" Value="GEN"></asp:ListItem>
                                        <asp:ListItem Text="OBC" Value="OBC"></asp:ListItem>
                                        <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                                        <asp:ListItem Text="ST" Value="ST"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-3 mr-3 ">

                                    <label for="ed_ddlReligion">Religion</label>
                                    <asp:DropDownList ID="ed_ddlReligion" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Hindu" Value="H"></asp:ListItem>
                                        <asp:ListItem Text="Muslim" Value="M"></asp:ListItem>
                                        <asp:ListItem Text="Christian" Value="C"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div class="row" style="margin-top:2rem">
                                <div class="col-md-3 mr-3 ">

                                    <label for="ed_ddlDepartment">Department</label>
                                    <asp:DropDownList ID="ed_ddlDepartment" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control" DataTextField="DepartmentName" DataValueField="DepartmentCD">
                                        <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-3 mr-3 ">

                                    <label for="ed_ddlDesignation">Designation</label>
                                    <asp:DropDownList ID="ed_ddlDesignation" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control" DataTextField="DesignationName" DataValueField="DesignationCD">
                                        <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-3 mr-3 ">

                                    <label for="ed_ddlCategory">Category</label>
                                    <asp:DropDownList ID="ed_ddlCategory" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control" DataTextField="CategoryName" DataValueField="CategoryID">
                                        <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-3 mr-3 ">

                                    <label for="ed_ddlBloodGroup">Blood Group</label>
                                    <asp:DropDownList ID="ed_ddlBloodGroup" runat="server" AutoPostBack="false" AppendDataBoundItems="true" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="null" Selected="True"></asp:ListItem>
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
                            </div>
                            <div class="row" style="margin-top:2rem">
                                <div class="col-md-4 mr-3 ">

                                    <label for="ed_Qualification">Qualification</label>
                                    <asp:TextBox ID="ed_Qualification" runat="server" CssClass="form-control" placeholder="Highest completed degree and equivalants"></asp:TextBox>

                                </div>
                                <div class="col-md-2 mr-3 ">

                                    <label for="ed_EmergencyPhone">Emergency Contact</label>
                                    <asp:TextBox ID="ed_EmergencyPhone" runat="server" CssClass="form-control" placeholder="e.g. 9876543210"></asp:TextBox>

                                </div>
                                <div class="col-md-6 mr-3 ">

                                    <label for="ed_Remarks">Remarks</label>
                                    <asp:TextBox ID="ed_Remarks" runat="server" CssClass="form-control" placeholder="Add Remarks"></asp:TextBox>

                                </div>
        </div>
                        </div>
                        <div class="panel-footer">
                            <div class="row">
                                <div class="col-md-2 mx-5 ">
                                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" ToolTip="Get Previous Employee" CssClass="btn btn-block text-center btn-default" OnClick="btnPrevious_Click" />
                                </div>
                                <div class="col-md-2 mx-5 ">
                                    <asp:Button ID="btnNext" runat="server" Text="Next" ToolTip="Get Next Employee" CssClass="btn btn-block text-center btn-default" OnClick="btnNext_Click"/>
                                </div>
                                <div class="col-md-2 mx-5 ">
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" ToolTip="Print Employee Data" CssClass="btn btn-block text-center btn-info" OnClick="btnPrint_Click" />
                                </div>
                                <div class="col-md-2 mx-5 ">
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete this Employee" CssClass="btn btn-block text-center btn-danger" OnClick="btnDelete_Click" />
                                </div>
                                <div class="col-md-2 mx-5 ">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update Employee Data" CssClass="btn btn-block text-center btn-success" OnClick="btnUpdate_Click" />
                                </div>
                                <div class="col-md-2 mx-5 ">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" ToolTip="Add New Employee" CssClass="btn btn-block text-center btn-primary" OnClick="btnAdd_Click" />
                                </div>
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
