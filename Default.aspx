
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyDbConn %>" SelectCommand="SELECT * FROM [Table]" ProviderName="<%$ ConnectionStrings:MyDbConn.ProviderName %>"></asp:SqlDataSource>
    </form>

