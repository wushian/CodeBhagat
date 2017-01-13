<%@ Control Language="C#" CodeBehind="sa106Search.ascx.cs" AutoEventWireup="true" Inherits="NewWebsite.sa106Search" %>

<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
		<table class="MainTable">
			<tr>
				<td>
					<asp:Panel ID="pnlSearch2" runat="server" CssClass="searchPanel">
							<div style="float: left;">
								<asp:Label ID="lblSearchPanel" runat="server" CssClass="searchPanelTitle">Search sa106</asp:Label></div>
							<div style="float: right; vertical-align: middle;">
								<asp:ImageButton ID="imgExpand" runat="server" ImageUrl="~/images/expand.gif" />
						</div>
					</asp:Panel>
					<asp:Panel ID="pnlSearch1" runat="server" DefaultButton="lbtnSearch" ForeColor="White">
						<table id="tblsa106" class="TableSearch">

						<tr>
							<td class="FieldLabelOdd" style="width:20%">Gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtgkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="reggkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtgkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Ord Date:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtorddate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtorddate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regorddate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtorddate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Mr200gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtmr200gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regmr200gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtmr200gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Issue Date:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtissuedate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtissuedate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regissuedate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtissuedate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Pono:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtpono" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regpono" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtpono">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Salesno:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtsalesno" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regsalesno" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtsalesno">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Returnno:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtreturnno" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regreturnno" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtreturnno">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Return Date:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtreturndate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtreturndate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regreturndate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtreturndate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Deliveryno:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtdeliveryno" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regdeliveryno" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtdeliveryno">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Ret Type:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtrettype" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regrettype" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtrettype">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">X Type:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtxtype" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regxtype" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtxtype">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Ba205gkey:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba205gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba205gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba205gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Pickup Date:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtpickupdate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtpickupdate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regpickupdate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtpickupdate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Cancel Date:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtcanceldate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtcanceldate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regcanceldate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtcanceldate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Ba100gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba100gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba100gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba100gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Ba102gkey:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba102gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba102gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba102gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Ba103gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba103gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba103gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba103gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Ba119gkey:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba119gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba119gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba119gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Ba118gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba118gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba118gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba118gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Ba121gkey:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba121gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba121gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba121gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Ba104gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba104gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba104gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba104gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Ba209gkey:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba209gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba209gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba209gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Returnamt:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtreturnamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regreturnamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtreturnamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Canadaamt:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtcanadaamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regcanadaamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtcanadaamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Freightamt:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtfreightamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regfreightamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtfreightamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Proceamt:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtproceamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regproceamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtproceamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Insuredamt:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtinsuredamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="reginsuredamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtinsuredamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Pickupamt:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtpickupamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regpickupamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtpickupamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Discountamt:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtdiscountamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regdiscountamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtdiscountamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Vouchersamt:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtvouchersamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regvouchersamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtvouchersamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Reservatamt:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtreservatamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regreservatamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtreservatamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Activityamt:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtactivityamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regactivityamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtactivityamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Totalfreight:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txttotalfreight" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regtotalfreight" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txttotalfreight">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Totaltreatment:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txttotaltreatment" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regtotaltreatment" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txttotaltreatment">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Totalinsurance:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txttotalinsurance" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regtotalinsurance" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txttotalinsurance">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Totalamt:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txttotalamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regtotalamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txttotalamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Pairs:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtpairs" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regpairs" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtpairs">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Remark:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtremark" runat="server" MaxLength="0" TextMode="MultiLine" Rows="4" Columns="50"></asp:textbox>
								<asp:regularexpressionvalidator id="regremark" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtremark">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Ba005gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba005gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba005gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba005gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Modify Date:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtmodifydate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtmodifydate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regmodifydate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtmodifydate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Revise Date:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtrevisedate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtrevisedate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regrevisedate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtrevisedate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Approve:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtapprove" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regapprove" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtapprove">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Aes101gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtaes101gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regaes101gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtaes101gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Ses101gkey:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtses101gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regses101gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtses101gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Es101gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtes101gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="reges101gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtes101gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Replication Create:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtreplication_create" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtreplication_create" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regreplication_create" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtreplication_create">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Replication Up Date:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtreplication_update" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtreplication_update" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regreplication_update" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtreplication_update">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Rownum:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtrownum" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regrownum" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtrownum">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Addproceamt:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtaddproceamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regaddproceamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtaddproceamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Lossproceamt:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtlossproceamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="reglossproceamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtlossproceamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Virementamt:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtvirementamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regvirementamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtvirementamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Ba040gkey:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba040gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba040gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba040gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Ba040gkey1:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba040gkey1" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba040gkey1" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba040gkey1">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Receivable Date:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtreceivabledate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtreceivabledate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regreceivabledate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtreceivabledate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Receivableamt:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtreceivableamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regreceivableamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtreceivableamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Virement Date:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtvirementdate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtvirementdate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regvirementdate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtvirementdate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Salesamt:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtsalesamt" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regsalesamt" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtsalesamt">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Collchk:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtcollchk" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regcollchk" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtcollchk">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Payfreight:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtpayfreight" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regpayfreight" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtpayfreight">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Strchk:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtstrchk" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regstrchk" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtstrchk">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Noamount:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtnoamount" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regnoamount" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txtnoamount">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Totalamount:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txttotalamount" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regtotalamount" runat="server" ValidationExpression="^-[0-9]+$|^[0-9]+$"
									ControlToValidate="txttotalamount">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Ba101gkey:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtba101gkey" runat="server" MaxLength="0"></asp:textbox>
								<asp:regularexpressionvalidator id="regba101gkey" runat="server" ValidationExpression="^[a-zA-Z0-9 ,.()-]*$"
									ControlToValidate="txtba101gkey">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelEven" style="width:20%">Remittance Date:</td>
							<td class="FieldDataRowEven">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtremittancedate" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtremittancedate" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regremittancedate" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtremittancedate">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						<tr>
							<td class="FieldLabelOdd" style="width:20%">Remittancetime:</td>
							<td class="FieldDataRowOdd">
							<div class="form-inline">
								<div class="form-inline">
								<div class="form-group">
								<asp:textbox id="txtremittancetime" runat="server" MaxLength="0"></asp:textbox>
									<asp:CalendarExtender runat="server" TargetControlID="txtremittancetime" Format="MM/dd/yyyy" />
								<asp:regularexpressionvalidator id="regremittancetime" runat="server" ValidationExpression="^([0-9]|/)*$"
									ControlToValidate="txtremittancetime">Invalid Input</asp:regularexpressionvalidator>
								</div></div>
							</div>
							</td>
						</tr>
						</table>
						<div style="vertical-align: middle; width:100%; text-align: right; margin-top:2px;" >
								<asp:Button ID="lbtnSearch" runat="server" Text="Search" CssClass="PageButton" Width="70px"
									OnClick="lbtnSearch_Click"></asp:Button>&nbsp;
								<asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="PageButton" Width="70px"
									OnClick="btnClear_Click" />
						</div>
					</asp:Panel>
					<asp:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="pnlSearch1"
						ExpandControlID="pnlSearch2" CollapseControlID="pnlSearch2" Collapsed="True" TextLabelID="lblSearchPanel"
						ImageControlID="imgExpand" ExpandedText="Search sa106" CollapsedText="Search sa106"
						ExpandedImage="~/images/collapse.gif" CollapsedImage="~/images/expand.gif"
						SuppressPostBack="true" SkinID="" Enabled="True" />
				</td>
			</tr>
		</table>
    </ContentTemplate>
</asp:UpdatePanel>
	