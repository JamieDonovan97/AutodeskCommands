// Copyright (c) Jamie B Donovan. All rights reserved.
// Licensed under the MIT License. See License in the project root for license information.

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using Exception = Autodesk.AutoCAD.Runtime.Exception;

namespace AutodeskCommands;

/// <summary>
/// A simple C# Plugin for AutoCAD that displays "HelloWorld" to the command line
/// using the command HelloWorld. Also displays to command line upon initialisation and termination.
/// </summary>
public class Commands : IExtensionApplication
{
    // Globals
    public static Document? _activeDocument;
    public static Editor? _activeEditor;

    /// <summary>
    /// Initialises the plugin.
    /// Runs on AutoCAD Startup.
    /// </summary>
    public void Initialize()
    {
        _activeDocument = Application.DocumentManager.MdiActiveDocument;
        _activeEditor = _activeDocument.Editor;
        _activeEditor?.WriteMessage("\nPlugin Loaded Successfully.");

        // Subscribe to the document events.
        Application.DocumentManager.DocumentActivated += UpdateDocument;
               
    }
    
    /// <summary>
    /// Terminates the plugin, Unloads Resources and unsubscribes from events.
    /// </summary>
    public void Terminate()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public static void UpdateDocument(object sender, DocumentCollectionEventArgs e)
    {
        _activeDocument = Application.DocumentManager.MdiActiveDocument;
        _activeEditor = _activeDocument.Editor;
        _activeEditor?.WriteMessage($"\nDocument '{e.Document.Name}' is opened.");
    }
      
    /// <summary>
    /// AutoCAD Commandline command HELLOWORLD.
    /// displays "Hello World!" in the command line.
    /// </summary>
    [CommandMethod("HelloWorld")]
    public static void DisplayHelloWorld()
    {
        // Display "Hello World!" in the command line
        _activeEditor?.WriteMessage("\nHello World!");
    }
    
    /// <summary>
    /// Apply variables or settings to the opened drawing.
    /// </summary>
    public static void StartUpVariables()
    {
        // Set the system variables
        Application.SetSystemVariable("LTSCALE", 1.0);
        Application.SetSystemVariable("FILEDIA", 1.0);
    }
}

