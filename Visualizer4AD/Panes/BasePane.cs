﻿using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Threading;
using viewmodel;

namespace Visualizer.Panes
{
    public abstract class BasePane : ViewModelBase
    {
        protected int _progresscount = 0;
        protected bool _processing = false;

        protected Graph _graph;
        public Graph Graph { get { return this._graph; } }

        protected Node SelectedNode { get; set; }

        protected string _notificationtext;
        public string NotificationText
        {
            get { return this._notificationtext; }
            set
            {
                this._notificationtext = value;
                this.OnPropertyChanged(this, "NotificationText");
            }
        }

        protected string _header;
        public string Header
        {
            get { return this._header; }
            set
            {
                this._header = value;
                this.OnPropertyChanged(this, "Header");
            }
        }

        protected string _findlabeltext;
        public string FindLabelText
        {
            get { return this._findlabeltext; }
            set
            {
                this._findlabeltext = value;
                this.OnPropertyChanged(this, "FindLabelText");
            }
        }

        protected string _findtext;
        public string FindText
        {
            get { return this._findtext; }
            set
            {
                this._findtext = value;
                this.OnPropertyChanged(this, "FindText");
            }
        }

        protected bool _controlsenabled = true;
        public bool ControlsEnabled
        {
            get { return this._controlsenabled; }
            set
            {
                this._controlsenabled = value;
                this.OnPropertyChanged(this, "ControlsEnabled");
            }
        }

        protected string _searchtext;
        public string SearchText
        {
            get { return this._searchtext; }
            set
            {
                this._searchtext = value;
                this.OnPropertyChanged(this, "SearchText");
            }
        }


        // Constructor
        public BasePane()
        {
            this.NotificationText = string.Empty;
        }

        protected void OnTextBoxFocused(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
        }

        

        /// <summary>
        /// Adds notification with dots slowly working. Adds the dots to the specified string
        /// </summary>
        /// <param name="basetext"></param>
        protected void NotifyProgress(string basetext)
        {
            int count = 0;
            this.NotificationText = basetext;

            while (this._processing == true)
            {
                if (count < 5)
                {
                    this.NotificationText = this.NotificationText + ".";
                    count++;
                }
                else
                {
                    this.NotificationText = basetext;
                    count = 0;
                }
                Thread.Sleep(500);
            }
            this.NotificationText = string.Empty;
        }

        protected void UpdateProgressMessage_ForAsync(string newmessage)
        {
            this.NotificationText = newmessage;
            this._progresscount = 0;
        }

        protected void NotifyFinishSearchWithCount(int count)
        {
            //show the results to the user
            string s;
            s = "Found " + count + " item";
            if (count != 1) { s = s + "s"; }

            this.UpdateProgressMessage_FinishAsync(s);
        }

        protected void NotifyFinishBuildWithCount(int count)
        {
            //show the results to the user
            string s;
            s = "Found " + count + " connection";
            if (count != 1) { s = s + "s"; }

            this.UpdateProgressMessage_FinishAsync(s);
        }

        /// <summary>
        /// Update the progress message so that it stays after the async NotifyProgress 
        /// thread finishes
        /// </summary>
        /// <param name="newmessage"></param>
        protected void UpdateProgressMessage_FinishAsync(string newmessage)
        {
            Thread.Sleep(550);
            this.NotificationText = newmessage;
        }

        protected void StartProcessing()
        {
            this.ControlsEnabled = false;
            this._processing = true;
        }

        protected void FinishProcessing()
        {
            this.ControlsEnabled = true;
            this._processing = false;
        }

        protected abstract void BuildGraph();
        protected void OnBuildKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.BuildGraph();
            }
        }

        protected void OnSearchResultsListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                //if (this._selectedresult != null) { this.BuildGraph(); }
                this.BuildGraph();
            }
        }

        protected void OnBuildButtonPressed(object sender, RoutedEventArgs e)
        {
            this.BuildGraph();
        }

        protected void OnGViewerMouseClicked(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GViewer viewer = (GViewer)sender;
            object selected = viewer.SelectedObject;
            if (selected != null)
            {
                this.SelectedNode = selected as Node;
                if (this.SelectedNode != null)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right) { this.OnGViewerMouseRightClick(); }
                }
            }
        }

        protected void OnProgressUpdate(object sender, EventArgs e)
        {
            if (this._progresscount < 2)
            {
                this.NotificationText = this.NotificationText + ".";
                this._progresscount++;
            }
            else { this.NotificationText = string.Empty; }
        }

        protected virtual void OnGViewerMouseRightClick() { }
    }
}
