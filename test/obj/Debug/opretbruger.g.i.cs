﻿#pragma checksum "..\..\opretbruger.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0AD42D10987232A8D23A2EBF2E004FC67C0D775A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using test;
using test.Primary_funkions;


namespace test {
    
    
    /// <summary>
    /// opretbruger
    /// </summary>
    public partial class opretbruger : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\opretbruger.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtnavn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\opretbruger.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtalder;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\opretbruger.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtsex;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\opretbruger.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtby;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\opretbruger.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtommig;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\opretbruger.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtinter;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\opretbruger.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAvatar;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\opretbruger.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgAvatar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/test;component/opretbruger.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\opretbruger.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtnavn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtalder = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtsex = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.txtby = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtommig = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtinter = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtAvatar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ImgAvatar = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            
            #line 72 "..\..\opretbruger.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UploadLocallyStoredImage);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 73 "..\..\opretbruger.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.gembruger);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

