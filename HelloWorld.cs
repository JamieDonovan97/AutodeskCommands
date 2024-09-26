// Copyright (c) Jamie B Donovan. All rights reserved.
// Licensed under the MIT License. See License in the project root for license information.

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace AutodeskCommands;

/// <summary>
/// A simple C# Plugin for AutoCAD that displays "HelloWorld" to the command line
/// based on the "Create Your First AutoCAD Plugin" by Autodesk University
/// </summary>
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
    [CommandMethod("HelloWorld")]
    public static void DisplayHelloWorld()
    {
        // Get Editor
        var editor = GetEditor();
        // Display "Hello World!" in the command line
        editor.WriteMessage("\nHello World!");
    }

    /// <summary>
    /// Retrieves the active AutoCAD document.
    /// </summary>
    /// <returns> Returns the active AutoCAD document </returns>
    private static Document GetActiveDocument()
    {
        Document activeDoc = Application.DocumentManager.MdiActiveDocument;
        if (activeDoc == null)
        {
            throw new InvalidOperationException("Unable to retrieve the active AutoCAD document.");
        }
        return activeDoc;
    }
    
    /// <summary>
    /// Retrieves the active AutoCAD document's editor.
    /// </summary>
    /// <returns> Returns the active AutoCAD document's editor </returns>
    private static Editor GetEditor()
    {
        Editor activeEditor = GetActiveDocument().Editor;
        if (activeEditor == null)
        {
            throw new InvalidOperationException("Unable to retrieve the editor for the active document.");
        }
        return activeEditor;
    }
}

