﻿#pragma checksum "..\..\opretbrugerfirst.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63287FF1E667F750DB820655EE6304BED5C743AD"
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


namespace test {
    
    
    /// <summary>
    /// opretbrugerfirst
    /// </summary>
    public partial class opretbrugerfirst : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\opretbrugerfirst.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtnavn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\opretbrugerfirst.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtalder;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\opretbrugerfirst.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox txtsex;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\opretbrugerfirst.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtby;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\opretbrugerfirst.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtommig;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\opretbrugerfirst.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtinter;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\opretbrugerfirst.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtsog;
        
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
            System.Uri resourceLocater = new System.Uri("/test;component/opretbrugerfirst.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\opretbrugerfirst.xaml"
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
            this.txtsog = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 60 "..\..\opretbrugerfirst.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.gembruger);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

