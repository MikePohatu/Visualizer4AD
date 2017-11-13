﻿using System;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
//using viewmodel;

namespace Visualizer
{
    public static class MsaglHelpers
    {
        public static void ConfigureNode(Node a)
        {
            a.Attr.Shape = Shape.Box;
            a.Attr.XRadius = 3;
            a.Attr.YRadius = 3;
            a.Attr.Padding = 3;
            a.Attr.LabelMargin = 5;
            //a.LabelText = col.Name + Environment.NewLine + col.ID;
            //a.Attr.FillColor = Color.Green;
            a.Attr.LineWidth = 2;

            //a.UserData = col;
        }

        public static void ConfigureCollectionsGViewer(GViewer viewer )
        {
            viewer.EdgeInsertButtonVisible = false;
            viewer.NavigationVisible = false;
            viewer.UndoRedoButtonsVisible = false;
            viewer.CurrentLayoutMethod = LayoutMethod.MDS;
            //viewer.AsyncLayout = true;
        }

        public static void ConfigureApplicationsGViewer(GViewer viewer)
        {
            viewer.EdgeInsertButtonVisible = false;
            viewer.NavigationVisible = false;
            viewer.UndoRedoButtonsVisible = false;
            //viewer.CurrentLayoutMethod = LayoutMethod.MDS;
            //viewer.AsyncLayout = true;
        }
    }
}
