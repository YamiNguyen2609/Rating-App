﻿#pragma checksum "..\..\..\..\SlideForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8518C90147813087BE13FEF217AA54A3ED0C4DC5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Rating_App;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Rating_App {
    
    
    /// <summary>
    /// SlideForm
    /// </summary>
    public partial class SlideForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\SlideForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Rating_App.SlideForm window;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\SlideForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid panel;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\SlideForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_path;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\SlideForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_path;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\SlideForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_submit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Rating_App;component/slideform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SlideForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.window = ((Rating_App.SlideForm)(target));
            
            #line 9 "..\..\..\..\SlideForm.xaml"
            this.window.Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\SlideForm.xaml"
            this.window.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.panel = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btn_path = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\SlideForm.xaml"
            this.btn_path.Click += new System.Windows.RoutedEventHandler(this.btn_path_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_path = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.btn_submit = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\SlideForm.xaml"
            this.btn_submit.Click += new System.Windows.RoutedEventHandler(this.btn_submit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

