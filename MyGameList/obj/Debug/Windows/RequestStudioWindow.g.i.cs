﻿#pragma checksum "..\..\..\Windows\RequestStudioWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1C1F2BF234522D18B5792262EB925A5480381E07"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MyGameList.Windows;
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


namespace MyGameList.Windows {
    
    
    /// <summary>
    /// RequestStudioWindow
    /// </summary>
    public partial class RequestStudioWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Windows\RequestStudioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StudioNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Windows\RequestStudioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton YesRadioButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Windows\RequestStudioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton NoRadioButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\RequestStudioWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock StudioNameErrorTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/MyGameList;component/windows/requeststudiowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\RequestStudioWindow.xaml"
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
            this.StudioNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.YesRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\..\Windows\RequestStudioWindow.xaml"
            this.YesRadioButton.Checked += new System.Windows.RoutedEventHandler(this.YesRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NoRadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\..\Windows\RequestStudioWindow.xaml"
            this.NoRadioButton.Checked += new System.Windows.RoutedEventHandler(this.NoRadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 17 "..\..\..\Windows\RequestStudioWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ConfirmButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 18 "..\..\..\Windows\RequestStudioWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StudioNameErrorTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

