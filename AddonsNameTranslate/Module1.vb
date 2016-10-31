Module Module1
    Dim WithEvents wb As System.Windows.Forms.WebBrowser = New System.Windows.Forms.WebBrowser
    Dim hasLoaded As Boolean = False
    Dim file As System.IO.FileInfo

    Sub Main()
        Console.WriteLine("SRCDS Addons To Name")
        Console.WriteLine("--------------------")

        wb.ScriptErrorsSuppressed = True

        Dim fileNames = My.Computer.FileSystem.GetFiles(System.IO.Directory.GetCurrentDirectory, FileIO.SearchOption.SearchTopLevelOnly, "*.gma")
        Static Dim steamAddonURL As String = "http://steamcommunity.com/sharedfiles/filedetails/?id="

        For Each fileName As String In fileNames
            ' Create connection to the steam website for title
            file = New System.IO.FileInfo(fileName)

            Dim resFileName As String = file.Name.Replace("ds_", "").Replace(".gma", "")
            ' Console.WriteLine(resFileName)

            wb.Navigate(steamAddonURL & resFileName)

            Do
                ' Console.Write(".")
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(100)
            Loop Until hasLoaded = True

            hasLoaded = False
        Next

    End Sub

    Sub LoadCompleted(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wb.DocumentCompleted
        Console.WriteLine(file.Name & " | " & wb.Document.Title.Replace("Steam Workshop :: ", ""))
        hasLoaded = True
    End Sub

End Module
