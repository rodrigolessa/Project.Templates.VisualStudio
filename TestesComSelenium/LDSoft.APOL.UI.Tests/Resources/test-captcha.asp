<%@  language="VBScript" %>
<%
	Call Main()

    Sub Main()
    	Response.Write(session("checktext"))
    End Sub
%>