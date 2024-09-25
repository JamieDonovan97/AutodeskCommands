using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices.Core;
using System;
using System.Linq;


namespace AutodeskCommands
{
    public class HelloWorld
    {
        [CommandMethod("HelloWorld")]
        public void Hello()
        {
            var document = Application.DocumentManager.MdiActiveDocument;
            
            var editor = document.Editor;
            
            editor.WriteMessage("Hello World!");
        }
    }
}

