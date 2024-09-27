// Copyright (c) Jamie B Donovan. All rights reserved.
// Licensed under the MIT License. See License in the project root for license information.

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace AutodeskCommands;

public partial class Commands
{
    
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