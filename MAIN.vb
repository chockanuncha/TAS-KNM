Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports System.Threading
Imports System.ComponentModel
Imports System.Net.Sockets
Imports BackendTalk.Main
Imports System.Windows.Forms
'Imports System.Net.Dns
Partial Public Class MAIN
    Private cls As New Class_SQLSERVERDB
    Public U_NAME As String = "None"
    Public U_GROUP As String = "None"
    Public U_NAME_ID As Integer
    Public U_GROUP_ID As Integer
    Public EventString As String = ""
    Private Property TextAlignment As New ContentAlignment
    Private examplePage As New LightVisualElement
    Private exampleControls As New Dictionary(Of String, UserControl)
    Private Property ShouldHandleMouseInput As Boolean
    Private currentExample As String = String.Empty
    Private Property NotifyParentOnMouseInput As Boolean
    Private headerLabel As New LightVisualElement
    Private backButton As New RadButtonElement
    Dim TimeText As Integer = 100
    Friend WithEvents ThrShipment As BackgroundWorker
    Dim CallBlackShipment As New MethodInvoker(AddressOf Me.DataBlackShipment)
    Dim Memory As MemoryManagement.Manage
    Dim Clearram As Integer = 0
    Dim strHostName As String = ""
    Dim strIPAddress As String = ""

    'gobal variable
    Dim LicActive, StrTest As String
    Dim receiveBytes As [Byte]()
    Dim receivePortNum As Integer
    Public ServerReceived As UdpClient
    Public receivedRemoteEndpoint As New System.Net.IPEndPoint(System.Net.IPAddress.Any, receivePortNum)
    Dim WithEvents Backend_talk As New BackendTalk.Main
    Dim Count_ConnectLicense As Integer = 0
    Dim formenable As Boolean = True

#Region "TAS license"
    Function GetIPAddress() As String
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        Return strIPAddress
    End Function
    Private Sub Initiallicense()
        Dim MessCon As String = Backend_talk.Connect(My.Settings.LicStatus, My.Settings.LicServer)
        TextBox1.Text = MessCon.ToString
    End Sub

    Private Sub BackendSend()
        Dim MessSend As String = Backend_talk.send(Process.GetCurrentProcess().Id.ToString + "//4//")
        If MessSend Is Nothing Then
            Count_ConnectLicense = 0
            TextBox2.Text = "OK"
            Me.radPanorama1.Enabled = True
            formenable = True
            EnableControls()
        Else
            Count_ConnectLicense = Count_ConnectLicense + 1
            TextBox2.Text = MessSend.ToString
            If Count_ConnectLicense = 3 Then
                formenable = False
                Me.radPanorama1.Enabled = False
                EnableControls()
                Count_ConnectLicense = 0
                Exit Sub
            End If
        End If
    End Sub
    Public Sub CallBackEvent(ByVal Str As String) Handles Backend_talk.RtRead
        Dim ResulBackend() As String = Strings.Split(Str, "//")
        If ResulBackend(0) = Process.GetCurrentProcess.Id.ToString Then
            LicActive = ResulBackend(3)
        End If
        StrTest = Str
        'Me.Invoke(New EventHandler(AddressOf BackendRecMessage))
    End Sub
    Sub EnableControls()
        Dim lista As New FormCollection
        lista = Application.OpenForms
        For Each a As Form In lista
            a.Enabled = formenable
        Next
    End Sub

    '            GLOIP = IPAddress.Parse("127.0.0.1")
    '            GLOINTPORT = "44444"
    '            udpClient.Connect(GLOIP, GLOINTPORT)
    '            bytCommand = Encoding.ASCII.GetBytes(txtMessage.Text)
    '            pRet = udpClient.Send(bytCommand, bytCommand.Length)
    '#End Region

    '#Region "Licene Client Recieve"


    '        GLOIP = IPAddress.Parse("127.0.0.1")
    '        GLOINTPORT = "44444"
    '        udpClient.Connect(GLOIP, GLOINTPORT)

    '    bytCommand = Encoding.ASCII.GetBytes(txtMessage.Text)
    '            pRet = udpClient.Send(bytCommand, bytCommand.Length)


    'Connect(status As String, ip_adds As String) as

#End Region



    Private Sub FReShipment()
        ThrShipment = New BackgroundWorker
        ThrShipment.WorkerSupportsCancellation = True
        AddHandler ThrShipment.DoWork, AddressOf RefreshShipment
        ThrShipment.RunWorkerAsync()
    End Sub

    Private Sub RefreshShipment()
        While Not ThrShipment.CancellationPending
            Try
                Using dt As DataTable = cls.Query("select  top 1 ' + CONVERT(VARCHAR,ldate,120) + ' ' + ISNULL(DETAIL,'') + ' as EventDetail,* from t_event  order by id DESC;")
                    If dt.Rows.Count > 0 Then
                        EventString = dt.Rows(0).Item("EventDetail").ToString()
                    Else
                        EventString = ""
                    End If
                End Using
            Catch ex As Exception
            End Try
            Clearram = Clearram + 1
            If Clearram >= 10 Then
                Try
                    Memory = New MemoryManagement.Manage
                    Memory.FlushMemory()
                    Clearram = 0
                Catch ex As Exception
                End Try
            End If

            Try
                Me.BeginInvoke(CallBlackShipment)
                Thread.Sleep(2000)
            Catch ex As Exception
            End Try
        End While
    End Sub
    Private Sub DataBlackShipment()
        Eventext.Text = EventString.ToString
        Try
            RichTextBox1.Text = RichTextBox1.Text & "," & StrTest.ToString & vbCrLf
        Catch ex As Exception
        End Try
        If TextBox2.Text <> "OK" Then
            'Me.radPanorama1.Enabled = False
            Eventext.Text = TextBox2.Text
            Initiallicense()
            BackendSend()
            'ElseIf TextBox2.Text = "OK" And Me.radPanorama1.Enabled = False Then
            '   Me.radPanorama1.Enabled = True
        Else
            BackendSend()
        End If



    End Sub
    Private Sub titleBar_MaximizeRestore(ByVal sender As Object, ByVal args As EventArgs)
        If Me.WindowState <> FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub backButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        UnloadExample()
    End Sub
    Private Sub PrepareHeader()
        Dim headerLayout As New StackLayoutElement()
        headerLayout.Orientation = Orientation.Horizontal
        headerLayout.Margin = New System.Windows.Forms.Padding(0, 35, 0, 0)
        headerLayout.NotifyParentOnMouseInput = True
        headerLayout.ShouldHandleMouseInput = False
        headerLayout.StretchHorizontally = False
        Me.backButton = New RadButtonElement() With {
         .StretchHorizontally = False
        }
        Me.backButton.Margin = New Padding(40, 0, 28, 0)
        'Me.backButton_Click.Click += New EventHandler(backButton_Click)
        Me.backButton.Visibility = ElementVisibility.Hidden
        headerLayout.Children.Add(Me.backButton)
        Me.headerLabel = New LightVisualElement()
        Me.headerLabel.Text = "TAS KNM LPG Terminal"
        Me.headerLabel.Font = New Font("Segoe UI Light", 42, GraphicsUnit.Point)
        Me.headerLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
        Me.headerLabel.ForeColor = Color.White
        Me.headerLabel.TextAlignment = ContentAlignment.MiddleLeft
        Me.headerLabel.MaxSize = New Size(630, 110)
        Me.headerLabel.NotifyParentOnMouseInput = True
        Me.headerLabel.ShouldHandleMouseInput = False
        Me.headerLabel.StretchHorizontally = False
        headerLayout.Children.Add(Me.headerLabel)
        Me.radPanorama1.PanoramaElement.Children.Add(headerLayout)
    End Sub
    Private Sub UpdateExampleControlPosition()
        Dim ctrl As UserControl = Me.GetCurrentExampleControl()
        If ctrl IsNot Nothing Then
            ctrl.Bounds = New Rectangle(New Point(120, Me.examplePage.ControlBoundingRectangle.Y + 60), New Size(Me.Width - 180, Me.Height - Me.examplePage.ControlBoundingRectangle.Y - 120))
        End If
    End Sub
    Private Sub OnExampleOpened(ByVal sender As Object, ByVal e As AnimationStatusEventArgs)
        Dim ctrl As UserControl = Me.GetCurrentExampleControl()
        If ctrl IsNot Nothing Then
            Me.Controls.Add(ctrl)
            ctrl.BringToFront()
            Me.UpdateExampleControlPosition()
        End If
    End Sub
    Private Function GetCurrentExampleControl() As UserControl
        If Me.currentExample <> "" AndAlso Me.exampleControls.ContainsKey(Me.currentExample) Then
            Return Me.exampleControls(Me.currentExample)
        End If
        Return Nothing
    End Function
    Private Sub LoadExample(ByVal exampleName As String, ByVal tile As RadLiveTileElement)
        If currentExample <> String.Empty Then
            Return
        End If
        Me.currentExample = exampleName
        Me.headerLabel.Text = tile.Text
        'Me.backButton.Visibility = ElementVisibility.Visible
        Me.examplePage.PositionOffset = New SizeF(-Me.radPanorama1.Width, 0)
        examplePage.Visibility = ElementVisibility.Visible
        Dim setting As New AnimatedPropertySetting(RadElement.PositionOffsetProperty,
                                                   New SizeF(-Me.radPanorama1.Width, 0),
                                                   SizeF.Empty, CInt(10.0 * 800.0 / Me.Width), 10)
        setting.ApplyValue(Me.examplePage)
    End Sub

    Private Sub UnloadExample()
        Me.Controls.Remove(Me.GetCurrentExampleControl())
        Me.backButton.Visibility = ElementVisibility.Hidden
        Me.headerLabel.Text = "IRPC"
        Me.examplePage.PositionOffset = New SizeF(-Me.radPanorama1.Width, 0)
        examplePage.Visibility = ElementVisibility.Visible
        Dim setting As New AnimatedPropertySetting(RadElement.PositionOffsetProperty, SizeF.Empty, New SizeF(-Me.radPanorama1.Width, 0), CInt(10.0 * 800.0 / Me.Width), 10)
        'setting.AnimationFinished += New AnimationFinishedEventHandler(OnExampleClosed)
        setting.ApplyValue(Me.examplePage)
    End Sub

    Private Sub RadTileElement34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Advisenote_Menu.Click
        Try
            Memory = New MemoryManagement.Manage
            Memory.FlushMemory()
        Catch ex As Exception
        End Try
        'Me.AddOwnedForm(Advisenote)
        'Advisenote.Show()

        Me.AddOwnedForm(Advisenote)
        If Advisenote.Chk_View() = False Then
            Exit Sub
        Else
            Advisenote.Show()
        End If


    End Sub

    Private Sub linkTile1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Customer_Menu.Click
        Me.AddOwnedForm(Customer)
        Customer.Show()
    End Sub

    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''My.Application.ChangeCulture("th-TH")
        M_NAME.Text = U_NAME
        M_GROUP.Text = U_GROUP
        Eventext.Left = 1850
        RadButton1.Enabled = False
        Me.radPanorama1.Enabled = True
        Unloading.Visibility = ElementVisibility.Collapsed
        Count_ConnectLicense = 0
        Initiallicense()
        Try
            'Memory = New MemoryManagement.Manage
            'Memory.FlushMemory()
            Clearram = 0
        Catch ex As Exception
        End Try

        LoadingGroup.Enabled = False
        Unloading.Enabled = False
        MMIGroups.Enabled = False
        Report.Enabled = False
        RecordGroup.Enabled = False
        ConfigGroup.Enabled = False
        'Supervisor.Enabled = False
        ToolGroup.Enabled = False

        PrepareExamples()
        FReShipment()
    End Sub

    Private Sub PreloadControls()
        For Each entry As KeyValuePair(Of String, UserControl) In Me.exampleControls
            Me.Controls.Add(entry.Value)
            entry.Value.Location = New Point(120, 180)
        Next
    End Sub
    Private Sub PrepareExamples()
        examplePage = New LightVisualElement()
        examplePage.DrawText = False
        examplePage.DrawFill = True
        examplePage.BackColor = Color.White
        examplePage.GradientStyle = GradientStyles.Solid
        examplePage.Visibility = ElementVisibility.Collapsed
        Me.radPanorama1.PanoramaElement.Children.Add(examplePage)
        examplePage.Margin = New Padding(0, 140, 0, 0)
        Me.exampleControls = New Dictionary(Of String, UserControl)()
        Me.PreloadControls()
    End Sub



    Private Sub photoAlbumTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub RadTileElement4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Bay)
        Bay.Show()
    End Sub

    Private Sub main_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'My.Application.ChangeCulture("th-TH")
        Timer1.Enabled = True
    End Sub


    Private Sub bugTrackerTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.AddOwnedForm(Cardreaderform)
        'Cardreaderform.Show()
    End Sub


    Private Sub RadLiveTileElement22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(USER)
        USER.Show()
    End Sub

    Private Sub RadLiveTileElement11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Usergroup)
        Usergroup.Show()
    End Sub


    Private Sub BLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLogin.Click
        Login.UserName.Text = ""
        Login.UserName.Focus()
        Login.Pass.Text = ""
        Login.UserName.Focus()
        Login.ShowDialog()
    End Sub
    Private Sub BLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLogout.Click
        CEvent("USER : " + U_NAME + " Logout Tas ")
        BLogout.Visible = False
        BLogin.Visible = True
        U_NAME = "None"
        U_GROUP = "None"
        U_NAME_ID = -1
        U_GROUP_ID = -1
        main_Shown(sender, e)
        main_Load(sender, e)
    End Sub
    Public Sub CEvent(ByVal Detail As String)
        Try
            If Detail <> "" Then
                Try
                    cls.Insert("INSERT INTO T_EVENT (DETAIL)  VALUES('" + (Detail) + "')")
                Catch ex As Exception
                End Try

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Config_Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Reportmain)
        Reportmain.Show()
    End Sub

    Private Sub linkTile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Card_Menu.Click
        Me.AddOwnedForm(Card)
        Card.Show()
    End Sub

    Private Sub RadLiveTileElement13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.AddOwnedForm(USER)
        'USER.Show()
    End Sub

    Private Sub RadLiveTileElement15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Driver_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Driver_Menu.Click
        Me.AddOwnedForm(Driver)
        If Driver.Chk_View() = False Then
            Exit Sub
        Else
            Driver.Show()
        End If
    End Sub

    Private Sub RadTileElement2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(BatchMeter)
        BatchMeter.Show()
    End Sub

    Private Sub qsfTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Journal_Events)
        Journal_Events.Show()
    End Sub

    Private Sub RadLiveTileElement9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Tank_UnloadOrder)
        Tank_UnloadOrder.Show()
    End Sub

    Private Sub RadLiveTileElement18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Seal_setting)
        Seal_setting.Show()
    End Sub

    Private Sub RadTileElement38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Setting)
        Setting.Show()
    End Sub

    Private Sub themeViewerTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Q_Load)
        Q_Load.Show()
    End Sub

    Private Sub RadLiveTileElement10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadLiveTileElement10.Click
        Me.AddOwnedForm(Reportmain)
        Reportmain.Show()
    End Sub

    Private Sub RadLiveTileElement3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadLiveTileElement3.Click
        Me.AddOwnedForm(Reportmain)
        Reportmain.Show()
    End Sub

    Private Sub RadLiveTileElement31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadLiveTileElement31.Click
        Me.AddOwnedForm(Reportmain)
        Reportmain.Show()
    End Sub

    Private Sub RadLiveTileElement23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Load_byday)
        Load_byday.Show()
    End Sub

    Private Sub RadLiveTileElement29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Bay_Setting)
        Bay_Setting.Show()

    End Sub

    Private Sub RadTileElement30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub linkTile3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TruckCompany_Menu.Click
        'Me.AddOwnedForm(Shipper)
        'Shipper.Show()
        Me.AddOwnedForm(Company)
        Company.Show()
    End Sub



    Private Sub rssReaderTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Temp)
        Temp.Show()

    End Sub

    Private Sub RadLiveTileElement23_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BayMenu.Click
        Me.AddOwnedForm(Bay)
        Bay.Show()
    End Sub

    Private Sub RadLiveTileElement24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.AddOwnedForm(USER)
        'USER.Show()
    End Sub

    Private Sub RadLiveTileElement9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MeterMenu.Click
        Me.AddOwnedForm(BatchMeter)
        BatchMeter.Show()
    End Sub




    Private Sub RadLiveTileElement11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadLiveTileElement11.Click
        Me.AddOwnedForm(Tank_Order)
        Tank_Order.Show()
    End Sub

    Private Sub RadLiveTileElement12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadLiveTileElement12.Click
        Me.AddOwnedForm(TimeStatus)
        TimeStatus.Show()
    End Sub

    Private Sub RadLiveTileElement21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadLiveTileElement21.Click
        Me.AddOwnedForm(Companyparent)
        Companyparent.Show()
    End Sub

    Private Sub ShipperMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShipperMenu.Click
        Me.AddOwnedForm(Shipper)
        Shipper.Show()
    End Sub

    Private Sub StatusMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusMenu.Click
        Me.AddOwnedForm(F_Status)
        F_Status.Show()
    End Sub

    Private Sub ProductMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductMenu.Click
        Me.AddOwnedForm(Product)
        Product.Show()
    End Sub

    Private Sub CardreaderMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Tank_Order)
        Tank_Order.Show()
    End Sub

    Private Sub RadLiveTileElement39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.AddOwnedForm(Override)
        'Override.Show()
    End Sub

    Private Sub RadLiveTileElement41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueueMenu.Click
        Me.AddOwnedForm(ConfigQ)
        ConfigQ.Show()
    End Sub

    Private Sub RadLiveTileElement40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BannerMenu.Click
        Try
            Me.AddOwnedForm(Banner)
            Banner.Show()
            'ThrShipment.RunWorkerAsync()
            'ThrShipment.CancelAsync()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        'Me.AddOwnedForm(ChangPassword)
        ChangPassword.U_PassOLD.Text = ""
        ChangPassword.U_passnew.Text = ""
        ChangPassword.U_PassConfirm.Text = ""
        ChangPassword.RadTextBox1.Text = Date.Now.ToString
        ChangPassword.ShowDialog()


    End Sub
    Private Sub AlarmGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
        'e.CellElement.BackColor = Color.Red
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Eventext.Text = EventString.ToString
        If Eventext.Left > -(Me.Width - Eventext.Width) Then
            Eventext.Left = Eventext.Left - 1
        Else
            Eventext.Left = Me.Width - Eventext.Width
        End If
    End Sub

    Private Sub MAIN_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ThrShipment.CancelAsync()
    End Sub

    Private Sub HistoryMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryMenu.Click
        Me.AddOwnedForm(Journal_Events)
        Journal_Events.Show()
    End Sub

    Private Sub themeViewerTile_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles themeViewerTile.Click
        Me.AddOwnedForm(Q_Load)
        Q_Load.Show()
    End Sub



    Private Sub RadLiveTileElement23_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Workonlan)
        Workonlan.Show()
    End Sub

    Private Sub chartViewZoomScrollTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chartViewZoomScrollTile.Click
        Dim SetupPath As String = Application.StartupPath & "\MMI\ICC_TASMMI.exe"
        Process.Start(SetupPath)
    End Sub

    Private Sub schedulerTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles schedulerTile.Click
        Dim SetupPath As String = Application.StartupPath & "\MMI\ICC_TASMMI.exe"
        Process.Start(SetupPath)
    End Sub

    Private Sub listViewTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listViewTile.Click
        Dim SetupPath As String = Application.StartupPath & "\MMI\ICC_TASMMI.exe"
        Process.Start(SetupPath)
    End Sub

    Private Sub OverrideMenu_Click(sender As Object, e As EventArgs) Handles OverrideMenu.Click
        Me.AddOwnedForm(Override)
        Override.Show()
    End Sub

    Private Sub UserMenu_Click(sender As Object, e As EventArgs) Handles UserMenu.Click

        Me.AddOwnedForm(USER)
        If (USER.Chk_View() = False) And U_GROUP_ID <> 1 Then
            Exit Sub
        Else
            USER.Show()
        End If


    End Sub

    Private Sub Topup_Menu_Click(sender As Object, e As EventArgs) Handles Topup_Menu.Click
        Me.AddOwnedForm(Topup)
        If Topup.Chk_View() = False Then
            Exit Sub
        Else
            Topup.Show()
        End If
    End Sub

    Private Sub Statusview_Menu_Click(sender As Object, e As EventArgs) Handles Statusview_Menu.Click
        Me.AddOwnedForm(Advisenote_Status)
        If Advisenote_Status.Chk_View() = False Then
            Exit Sub
        Else
            Advisenote_Status.Show()
        End If
    End Sub

    Private Sub BaySetting_Menu_Click(sender As Object, e As EventArgs) Handles BaySetting_Menu.Click
        Me.AddOwnedForm(Bay_Setting)
        If Bay_Setting.Chk_View() = False Then
            Exit Sub
        Else
            Bay_Setting.Show()
        End If
    End Sub



    Private Sub Truck_Menu_Click(sender As Object, e As EventArgs) Handles Truck_Menu.Click
        Me.AddOwnedForm(Truck)
        If Truck.Chk_View() = False Then
            Exit Sub
        Else
            Truck.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EnableControls()
        'Initiallicense()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BackendSend()
    End Sub
End Class



