<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="songla._default" %>

<!---------------------------------------- Azure WebHook 控制頁 -------------------------------------------->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--[按鈕] 向指定使用者推播最新熱門歌曲 -->
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="PUSH LATEST HOT SONG" Font-Size="Larger" BackColor="#FF5050" Font-Italic="False" ForeColor="White" BorderStyle="None" />
        <br />
        <br />
        <!--[按鈕] 向指定使用者傳送問候語 -->
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="SEND GREETINGS" Font-Size="Larger" BackColor="#FF5050" ForeColor="White" Font-Italic="False" BorderStyle="None" />
    
    </div>
    </form>
</body>
</html>
