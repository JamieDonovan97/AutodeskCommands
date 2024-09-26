using System.Windows.Controls;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace AutodeskCommands;

/// <summary>
/// A simple C# Plugin for AutoCAD that displays "HelloWorld" to the command line
/// based on the "Create Your First AutoCAD Plugin" by Autodesk University
/// </summary>
///
public class Test : Page
{
    private int x = 5;
}
public class Commands : IExtensionApplication
{
    /// <summary>
    /// Initializes the plugin.
    /// Runs on AutoCAD Startup
    /// </summary>
    public void Initialize()
    {
        var editor = GetEditor();
        editor.WriteMessage("\nPlugin Loaded Successfully.");
    }
    
    /// <summary>
    /// Terminates the plugin.
    /// Unload Resources
    /// </summary>
    public void Terminate()
    {
        var editor = GetEditor();
        editor.WriteMessage("\nPlugin terminated.");
    }
    
    /// <summary>
    /// The Hello command that displays "Hello World!" in the command line.
    /// </summary>
    [CommandMethod("HELLOWORLD")]
    public static void Fred()
    {
        // Get the active document
        var document = Application.DocumentManager.MdiActiveDocument;
            
        // Get the editor object
        var editor = document.Editor;
            
        // Display "Hello World!" in the command line
        editor.WriteMessage("\nHello World!");
    }

    /// <summary>
    /// Helper method to get the active AutoCAD document.
    /// </summary>
    /// <returns> Returns the active AutoCAD document </returns>
    private static Document GetActiveDocument()
    {
        return Application.DocumentManager.MdiActiveDocument;
    }
    
    /// <summary>
    /// Helper method to get the active AutoCAD document.
    /// </summary>
    /// <returns> Returns the active AutoCAD document </returns>
    private static Editor GetEditor()
    {
        return GetActiveDocument().Editor;
    }
}

