using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices.Core;
using System;
using System.Linq;
using System.Reflection.Metadata;


namespace AutodeskCommands
{
    /// <summary>
    /// A simple C# Plugin for AutoCAD that displays "HelloWorld" to the command line
    /// </summary>
    public class HelloWorld
    {
        /// <summary>
        /// The Hello command that displays "Hello World!" in the command line.
        /// </summary>
        [CommandMethod("HelloWorld")]
        public void Hello()
        {
            // Get the active document
            var document = Application.DocumentManager.MdiActiveDocument;
            
            // Get the editor object
            var editor = document.Editor;
            
            // Display "Hello World!" in the command line
            editor.WriteMessage("Hello World!");
        }
    }
}

