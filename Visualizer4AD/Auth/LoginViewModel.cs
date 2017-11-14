﻿using System;
using Microsoft.Win32;
using viewmodel;
using common;

namespace Visualizer4AD.Auth
{
    public class LoginViewModel: ViewModelBase
    {
        private string _username;
        private string _domain;
        private string _server;
        private bool _passthrough;
        private string _usernamelabel;
        private string _domainlabel;
        private string _serverlabel;
        private string _passthroughlabel;
        private string _okbuttontext;
        private string _cancelbuttontext;
        private string _sitelabel;
        private string _site;
        private string _pwlabel;
        private string _tooltipmessage;
        private string _notifymessage;

        public LoginViewModel()
        {
            this.SetDefaults();
        }

        public string ToolTipMessage
        {
            get { return this._tooltipmessage; }
            set
            {
                this._tooltipmessage = value;
                this.OnPropertyChanged(this, "ToolTipMessage");
            }
        }
        public string NotifyMessage
        {
            get { return this._notifymessage; }
            set
            {
                this._notifymessage = value;
                this.OnPropertyChanged(this, "NotifyMessage");
            }
        }
        public string DeniedMessage { get; set; }
        public string TooltipDefaultMessage { get; set; }

        public bool PassThrough
        {
            get { return this._passthrough; }
            set
            {
                this._passthrough = value;
                this.OnPropertyChanged(this, "PassThrough");
            }
        }
        public string PassThroughLabel
        {
            get { return this._passthroughlabel; }
            set
            {
                this._passthroughlabel = value;
                this.OnPropertyChanged(this, "PassThroughLabel");
            }
        }

        public string Username
        {
            get { return this._username; }
            set
            {
                this._username = value;
                this.OnPropertyChanged(this, "Username");
            }
        }

        public string UsernameLabel
        {
            get { return this._usernamelabel; }
            set
            {
                this._usernamelabel = value;
                this.OnPropertyChanged(this, "UsernameLabel");
            }
        }

        public string Domain
        {
            get { return this._domain; }
            set
            {
                this._domain = value;
                this.OnPropertyChanged(this, "Domain");
            }
        }
        public string DomainLabel
        {
            get { return this._domainlabel; }
            set
            {
                this._domainlabel = value;
                this.OnPropertyChanged(this, "DomainLabel");
            }
        }

        public string Server
        {
            get { return this._server; }
            set
            {
                this._server = value;
                this.OnPropertyChanged(this, "Server");
            }
        }
        public string ServerLabel
        {
            get { return this._serverlabel; }
            set
            {
                this._serverlabel = value;
                this.OnPropertyChanged(this, "ServerLabel");
            }
        }

        public string Site
        {
            get { return this._site; }
            set
            {
                this._site = value;
                this.OnPropertyChanged(this, "Site");
            }
        }

        public string SiteLabel
        {
            get { return this._sitelabel; }
            set
            {
                this._sitelabel = value;
                this.OnPropertyChanged(this, "SiteLabel");
            }
        }

        public string OkButtonText
        {
            get { return this._okbuttontext; }
            set
            {
                this._okbuttontext = value;
                this.OnPropertyChanged(this, "OkButtonText");
            }
        }

        public string CancelButtonText
        {
            get { return this._cancelbuttontext; }
            set
            {
                this._cancelbuttontext = value;
                this.OnPropertyChanged(this, "CancelButtonText");
            }
        }

        public string PasswordLabel
        {
            get { return this._pwlabel; }
            set
            {
                this._pwlabel = value;
                this.OnPropertyChanged(this, "PasswordLabel");
            }
        }

        public bool TryConnect(IAuthenticator authenticator, string password)
        {
            bool connected = false;

            if (this.PassThrough == true) { connected = authenticator.Connect(this.Server); }
            else { connected = authenticator.Connect(this.Username, password, this.Domain, this.Server); }

            if (connected == false)
            {
                this.NotifyMessage = this.DeniedMessage;
            }
            else
            {
                this.NotifyMessage = null;
            }

            return connected;
        }

        private void SetDefaults()
        {
            //this.Server = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\ConfigMgr10\AdminUI\MRU\1", "ServerName", null);
            //this.Site = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\ConfigMgr10\AdminUI\MRU\1", "SiteCode", null);
            this.Username = Environment.UserName;
            this.Domain = Environment.UserDomainName;
            this.DeniedMessage = "Connection failed";
            this.ToolTipMessage = "Please enter connection details";
            this.DomainLabel = "Domain:";
            this.ServerLabel = "Server:";
            this.PasswordLabel = "Password:";
            this.UsernameLabel = "Username:";
            this.PassThroughLabel = "Use current user:";
            this.OkButtonText = "OK";
            this.CancelButtonText = "Cancel";
            this.SiteLabel = "Site code:";
            this.PassThrough = true;
        }
    }
}
