// Copyright (c) Jamie B Donovan. All rights reserved.
// Licensed under the MIT License. See License in the project root for license information.

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace AutodeskCommands;

/// <summary>
/// A simple C# Plugin for AutoCAD that displays "HelloWorld" to the command line
/// using the command _HelloWorld. Also displays to command line upon initialisation and termination.
/// </summary>
public class Commands : IExtensionApplication
{
    /// <summary>
    /// Initialises the plugin.
    /// Runs on AutoCAD Startup
    /// </summary>
    public void Initialize()
    {
        var editor = GetEditor();
        editor.WriteMessage("\nPlugin Loaded Successfully.");
        
        // Subscribe to the DocumentActivated event
        Application.DocumentManager.DocumentCreated += OnDocumentOpened;

        Application.DocumentManager.DocumentToBeDestroyed += OnDocumentClosed;
    }
    
    /// <summary>
    /// Terminates the plugin.
    /// Unload Resources
    /// </summary>
    public void Terminate()
    {
        // Unsubscribe from the 
        Application.DocumentManager.DocumentCreated -= OnDocumentOpened;
        Application.DocumentManager.DocumentToBeDestroyed -= OnDocumentClosed;
        
        // Get Editor
        var editor = GetEditor();
        // Display "Hello World!" in the command line
        editor.WriteMessage("\nPlugin terminated.");
        
    }

    private static void OnDocumentOpened(object sender, DocumentCollectionEventArgs e)
    {
        var editor = e.Document.Editor;
        editor.WriteMessage($"\nDocument '{e.Document.Name}' is opened.");

        // Example: Setting a system variable when the document is opened
        SetVariables(editor);
    }
    
    private void OnDocumentClosed(object sender, DocumentCollectionEventArgs e)
    {
        var editor = e.Document.Editor;
        editor.WriteMessage($"\nDocument '{e.Document.Name}' is closing.");

        // Unsubscribe from events specific to this document if needed
        Application.DocumentManager.DocumentToBeDestroyed -= OnDocumentClosed;
    }
    
    /// <summary>
    /// Apply variables or settings to the opened drawing.
    /// </summary>
    /// <param name="editor">The editor of the current document.</param>
    private static void SetVariables(Editor editor)
    {
        // Example: Set the system variable "LTSCALE" to 1.0
        editor.WriteMessage("\nSetting LTSCALE to 1.0...");
        Application.SetSystemVariable("LTSCALE", 1.0);

        // Set more variables or execute commands as needed
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
        var activeDoc = Application.DocumentManager.MdiActiveDocument;
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
        var activeEditor = GetActiveDocument().Editor;
        if (activeEditor == null)
        {
            throw new InvalidOperationException("Unable to retrieve the editor for the active document.");
        }
        return activeEditor;
    }
}

