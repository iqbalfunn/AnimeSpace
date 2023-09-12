﻿#pragma checksum "..\..\..\View\PageLibrary.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B6F6A127B39F5B200D9E8CC8DB756C1583B199309AD185B2E0A9399A566C61D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AnimeSpace.View;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace AnimeSpace.View {
    
    
    /// <summary>
    /// PageLibrary
    /// </summary>
    public partial class PageLibrary : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\View\PageLibrary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameTabLibrary;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\View\PageLibrary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem LVIVideos;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\PageLibrary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem LVIHistory;
        
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
            System.Uri resourceLocater = new System.Uri("/AnimeSpace;component/view/pagelibrary.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PageLibrary.xaml"
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
            this.FrameTabLibrary = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.LVIVideos = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 21 "..\..\..\View\PageLibrary.xaml"
            this.LVIVideos.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.LVIVideos_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LVIHistory = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 27 "..\..\..\View\PageLibrary.xaml"
            this.LVIHistory.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.LVIHistory_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
