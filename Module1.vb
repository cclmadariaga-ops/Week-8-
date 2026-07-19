Imports System.IO
Imports System.Security.Policy
Imports Newtonsoft.Json
'TODO:1. Change Procedure name to your own procedure name

'TODO:2.  Add Json package to the resources

'TODO:3. Create A Project Class

'TODO:4.  Create A Json file for the Project Class

'TODO:5.  Refactor writeFile procedure to take a string for data input

'TODO:6.  move the input variable up to the global class variable access

'TODO:7.  Seralize Project Class

'TODO:8.  Deseralize The Project json Class

'TODO:9.  Use snippets (insert comment) to add comments to procedures and functions

'TODO:10.Refactor your code to create subfolders in a separate procedure

'TODO:11.Remove reference comments

Module Module1

    'READ: 'More information on file reading and writing in the coursebook: pg 68: FileRead

    'https://drive.google.com/file/d/1qwb9Sq3bf9sWPdAUeiFX_xM1Knb4Ikpp/view

    Dim ProjectName As String = ""

    Dim FullDirectory As String = ""


    Sub main()

        Dim UserInput As String = ""


        While UserInput <> "exit"

            Console.WriteLine("Welcome to Midnight Mixx!")
            Console.WriteLine("create your music world project.")
            Console.WriteLine()

            Console.WriteLine("Enter your music project name:")
            ProjectName = Console.ReadLine()

            'create project folder on Desktop'
            Dim desktop As String =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            FullDirectory = Path.Combine(desktop, ProjectName)

            Directory.CreateDirectory(FullDirectory)

            Console.WriteLine()
            Console.WriteLine("choose a command:")
            Console.WriteLine("create - build ypur music world")
            Console.WriteLine("exit - close Midnight Mixx")


            UserInput = Console.ReadLine().ToLower()


            If UserInput = "create" Then

                CreateSubFolders()

                SaveProjectJSON()



                Console.WriteLine()
                Console.WriteLine("Your Midnight Mixx project has been created successfully!")
                Console.WriteLine("project saved at: " & FullDirectory)

            ElseIf UserInput <> "exit" Then

                Console.WriteLine("command not recognized.")
            End If

        End While

    End Sub

    
    'This is what creates project subfolders.
  
    Private Sub CreateSubFolders()


        'Documentation folders

        CreateProjectFolder(FullDirectory, "Docs")
        CreateProjectFolder($"{FullDirectory}\Docs", "Research")
        CreateProjectFolder($"{FullDirectory}\Docs", "Design")
        CreateProjectFolder($"{FullDirectory}\Docs", "References")



        'Asset folders

        CreateProjectFolder(FullDirectory, "Assets")
        CreateProjectFolder($"{FullDirectory}\Assets", "Art")
        CreateProjectFolder($"{FullDirectory}\Assets", "AlbumArt")
        CreateProjectFolder($"{FullDirectory}\Assets", "Images")
        CreateProjectFolder($"{FullDirectory}\Assets", "Icons")



        'Data folders

        CreateProjectFolder(FullDirectory, "Data")
        CreateProjectFolder($"{FullDirectory}\Data", "Playlists")
        CreateProjectFolder($"{FullDirectory}\Data", "Songs")
        CreateProjectFolder($"{FullDirectory}\Data", "JSON")



        'Music folders

        CreateProjectFolder(FullDirectory, "Audio")
        CreateProjectFolder($"{FullDirectory}\Audio", "Songs")
        CreateProjectFolder($"{FullDirectory}\Audio", "Effects")



        'Music Worlds

        CreateProjectFolder(FullDirectory,
                            "MusicWorlds")
        CreateProjectFolder($"{FullDirectory}\MusicWorlds", "Dreamscape")
        CreateProjectFolder($"{FullDirectory}\MusicWorlds", "Chill")
        CreateProjectFolder($"{FullDirectory}\MusicWorlds", "Energy")
        CreateProjectFolder($"{FullDirectory}\MusicWorlds", "Relaxation")



        'Screenshots

        CreateProjectFolder(FullDirectory, "Screenshots")


    End Sub
     Private Sub WriteFile(fileName As String, location As String)
        'Ref:https://docs.microsoft.com/en-us/dotnet/visual-basic/developing-apps/programming/drives-directories-files/how-to-write-text-to-files-with-a-streamwriter

        If fileName <> "" Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(location + "\" + fileName + ".txt", True)
            file.WriteLine("
weekApplication Change Log

App Name

Midnight Mixx

## Previous Version

My previous Folder Maker App could:

* Create a music project folder structure for organizing files.
* Create folders for playlists, songs, genres, covers, And project resources.
* Save basic project information into text files.

## New Version

This version adds:

* **JSON saving**
  The application now saves project information into a `Project.json` file Using JSON serialization. The Project Class stores information such As project name, current music world, selected mood, playlist name, songs, genre, description, And creation date.

* **NuGet/package use**
  The application uses the Newtonsoft.Json NuGet package to serialize And deserialize project information.

* **File save location**
  The application now creates the project folder on the user's Desktop using the project name entered in the console. The JSON file is saved inside the `Data\JSON` folder.

* **Three TODO items completed**

  * Created a Project class to store project information.
  * Added JSON serialization And deserialization.
  * Refactored the WriteFile procedure to accept data input.
  * Created a separate procedure for generating project subfolders.
  * Added comments to procedures And functions.

## TODO Items I Chose

### 1. TODO item: Create A Project Class

* **What I changed**
  I created a Project Class With properties For project name, music world, mood, playlist information, genre, description, creation Date, And favorite status.

* **Why it improves the app**
  The Project class organizes related information together And makes it easier to save And load project data.

---

### 2. TODO item: Serialize Project Class

* **What I changed**
  I added JSON serialization using `JsonConvert.SerializeObject()` to convert the Project object into a JSON file.

* **Why it improves the app**
  The app can now save project information in a structured format that can be stored And used later.

---

### 3. TODO item: Refactor WriteFile Procedure To Take Data Input

* **What I changed**
  I updated the WriteFile procedure so it accepts the file name, location, And Data that should be written.

* **Why it improves the app**
  The procedure Is more reusable because it can save different types of information instead of only writing one fixed message.

---

## Functions And Procedures I Commented

* **CreateSubFolders**

  * Purpose Creates the different project folders For documentation, assets, Data, audio, music worlds, And screenshots.
  * Inputs: None.
  * Output Or result: Creates the folder structure inside the user's project folder.

* **CreateProjectFolder**

  * Purpose Creates individual folders inside the project directory.
  * Inputs: Folder Path And folder name.
  * Output Or result: Creates a New folder.

* **WriteFile**

  * Purpose Writes Text Or JSON data into a file.
  * Inputs: file name, file location, And Data.
  * Output Or result: Creates And saves a file.

SaveProjectJSON

  Purpose Saves Project information as JSON.
  Inputs: None.
  Output Or result: Creates a Project.json file containing saved project information.

LoadProjectJSON

  Purpose Loads saved project information from a JSON file.
  Inputs: JSON file path.
  Output Or result: Returns a Project object from the saved JSON data.

Testing Notes

What worked

   The program successfully creates a project folder on the Desktop.
   The application creates the required subfolders.
   Project information Is saved into a Project.json file.
  JSON serialization successfully converts the Project object into saved data.

What failed

  The first version had errors because the project directory was Not assigned before creating folders.
  There were issues caused by duplicate procedure names And incorrect variable usage.

What I fixed

 Added a FullDirectory path that creates the project folder on the Desktop.
  Removed duplicate CreateProjectFolder procedures.
  Fixed the Input variable issue by using UserInput.
  Corrected JSON file saving.

What I would improve in version 2.1

  Add a graphical user interface instead of only using the console.
  Allow users to edit existing projects.
  Add music recommendations based on mood And genre.
  Add connections to music services.
  Allow users to share created music worlds."
)
            file.Close()

        End If

    End Sub

    Public Sub CreateProjectFolder(newFolderPath As String,
                            FolderName As String)

        My.Computer.FileSystem.CreateDirectory(newFolderPath & "\" + FolderName)

    End Sub


    
    'This is what Writes data to a file.
   
    Private Sub WriteFile(fileName As String, location As String, data As String)


        If fileName <> "" Then


            Dim filePath As String =
                location + "\" + fileName


            File.WriteAllText(filePath, data)


        End If


    End Sub

    
    'Saves project information as JSON.
    
    Private Sub SaveProjectJSON()
        Dim project As New Project With {
            .ProjectName = ProjectName,
            .CurrentWorld = "Dreamscape",
            .SelectedMood = "Chill",
            .PlaylistName = "Late Night Drive",
            .PlaylistSongs = New List(Of String)
        }

        project.PlaylistSongs.Add("Example Song")

        project.SongCount =
            project.PlaylistSongs.Count

        project.IsFavorite = True

        project.CurrentGenre = "Music"

        project.Description =
            "Midnight Mix music world playlist planner."

        project.CreatedDate = Date.Now


        Dim json As String =
            JsonConvert.SerializeObject(project, Formatting.Indented)

        Dim jsonfolder As String =
            Path.Combine(FullDirectory, "data", "json")

        Directory.CreateDirectory(jsonfolder)

        WriteFile("Project.json",
                   jsonfolder, json)



    End Sub




    
    'Loads project information from JSON.
    
    Private Function LoadProjectJSON(filePath As String) As Project


        Dim json As String =
            File.ReadAllText(filePath)



        Dim project As Project =
            JsonConvert.DeserializeObject(Of Project)(json)



        Return project


    End Function


    Private Class Project
        Friend IsFavorite As Boolean
        Public Property CreatedDate As Date
        Public Property CurrentGenre As String
        Public Property CurrentWorld As String
        Public Property Description As String
        Public Property PlaylistName As String
        Public Property SongCount As Integer
        Public Property SelectedMood As String
        Public Property ProjectName As String
        Public Property PlaylistSongs As List(Of String)
    End Class



End Module
