Public Class Workonlan


    Public Sub SendMagicPacket(ByVal ipAddress As String, ByVal strMacAddress As String, ByVal strLanSubnet As String)

        'SET THESE VARIABLES TO REAL VALUES

        Dim MacAddress As String = String.Empty

        Dim WANIPAddr As String = String.Empty

        Dim LanSubnet As String = String.Empty

        Dim strBroadcast As String = String.Empty

        'Ports to send magic packet to.

        Dim Port As Integer = 9

        Dim AltPort As Integer = 7

        Dim udpClient As New System.Net.Sockets.UdpClient

        Dim buf(101) As Char

        Dim sendBytes As [Byte]() = System.Text.Encoding.ASCII.GetBytes(buf)

        MacAddress = strMacAddress

        WANIPAddr = ipAddress

        LanSubnet = strLanSubnet

        For x As Integer = 0 To 5

            sendBytes(x) = CByte("&HFF")

        Next

        MacAddress = MacAddress.Replace("-", "").Replace(":", "")

        Dim i As Integer = 6

        For x As Integer = 1 To 16

            sendBytes(i) = CByte("&H" + MacAddress.Substring(0, 2))

            sendBytes(i + 1) = CByte("&H" + MacAddress.Substring(2, 2))

            sendBytes(i + 2) = CByte("&H" + MacAddress.Substring(4, 2))

            sendBytes(i + 3) = CByte("&H" + MacAddress.Substring(6, 2))

            sendBytes(i + 4) = CByte("&H" + MacAddress.Substring(8, 2))

            sendBytes(i + 5) = CByte("&H" + MacAddress.Substring(10, 2))

            i += 6

        Next

        Dim myAddress As String

        Try

            myAddress = System.Net.IPAddress.Parse(WANIPAddr).ToString

        Catch ex As Exception

            MsgBox("Packet send failed. see log")

            'log("Magic packet failed! ip address appears to be invalid! error: " & ex.Message)

            Exit Sub

        End Try

        If myAddress = String.Empty Then
            '' ping
            MessageBox.Show("Invalid IP address/Host Name given")

            Return

        End If

        Dim mySubnetArray() As String

        mySubnetArray = LanSubnet.Split(".")

        strBroadcast = CalculateBroadCastAddress(ipAddress, strLanSubnet)

        myAddress = WANIPAddr

        Try

            'log("Magic Packet Sent with data - ip:" & ipAddress & ", broadcast: " & strBroadcast & ", mac: " & strMacAddress & ", subnet: " & strLanSubnet)

            'send magic packet to broadcast ip

            udpClient.Send(sendBytes, sendBytes.Length, strBroadcast, Port)

            udpClient.Send(sendBytes, sendBytes.Length, strBroadcast, AltPort)

            'Send magic packet to PC's ip

            udpClient.Send(sendBytes, sendBytes.Length, ipAddress, Port)

            udpClient.Send(sendBytes, sendBytes.Length, ipAddress, AltPort)

            udpClient = Nothing

            '' ping

            'MsgBox("Magic Packet Sent! Computer should power on IF wake-on-lan is enabled.")

            'Shell("ping -t " & ipAddress, AppWinStyle.NormalFocus)

        Catch ex As Exception

            MsgBox("Error sending macgic packet. error: " & ex.Message)

        End Try

    End Sub

    Public Function CalculateBroadCastAddress(ByVal currentIP As String, ByVal ipNetMask As String) As String

        Dim strCurrentIP As String() = currentIP.ToString().Split(".")

        Dim strIPNetMask As String() = ipNetMask.ToString().Split(".")

        Dim arBroadCast As ArrayList = New ArrayList()

        Dim iTotalSubnets As Integer = 2 ^ BorrowedBits(strIPNetMask(3))

        Dim iHosts As Integer = 2 ^ (8 - BorrowedBits(strIPNetMask(3)))

        Dim iSubNetNum As Integer

        Dim iIPOctet As Integer = strCurrentIP(3)

        If iIPOctet / iHosts < 1 Then

            iSubNetNum = 0

        Else

            iSubNetNum = (iIPOctet / iHosts) - ((iIPOctet / iHosts) Mod 1)

        End If

        For i As Integer = 0 To 3

            If i <> 3 Then

                arBroadCast.Add(strCurrentIP(i))

            Else

                arBroadCast.Add((iHosts * iSubNetNum) + (iHosts - 1))

            End If

        Next

        Return arBroadCast(0) & "." & arBroadCast(1) & "." & arBroadCast(2) & "." & arBroadCast(3)

    End Function

    Function BorrowedBits(ByVal iNum As Int32) As Int32

        Select Case iNum

            Case 255

                Return 8

            Case 254

                Return 7

            Case 252

                Return 6

            Case 248

                Return 5

            Case 240

                Return 4

            Case 224

                Return 3

            Case 192

                Return 2

            Case 128

                Return 1

            Case 0

                Return 0

        End Select

    End Function

    Private Sub Workonlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'IRPCDataset.T_COMPUTER' table. You can move, or remove it, as needed.
        Me.T_COMPUTERTableAdapter.Fill(Me.IRPCDataset.T_COMPUTER)

    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            'SendMagicPacket(ds.Tables("TStation").Rows(I)("IPAddress").ToString,ds.Tables("TStation").Rows(I)("MACAddress").ToString, "255.255.255.0")
            'SendMagicPacket("192.168.5.232", "00-0B-AB-7C-76-D8", "255.255.255.0")

            Dim Ip, mac, subnet As String
            Ip = MasterGrid.CurrentRow.Cells("c_ipaddress").Value.ToString
            mac = MasterGrid.CurrentRow.Cells("c_macaddress").Value.ToString
            subnet = MasterGrid.CurrentRow.Cells("c_Subnet").Value.ToString
            SendMagicPacket(Ip.ToString, mac.ToString, subnet.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Workonlan_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.MasterGrid.TableElement.RowHeight = 25
        Me.MasterGrid.TableElement.TableHeaderHeight = 30
    End Sub
End Class
