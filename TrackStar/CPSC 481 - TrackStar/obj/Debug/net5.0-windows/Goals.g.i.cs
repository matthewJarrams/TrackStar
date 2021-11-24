﻿#pragma checksum "..\..\..\Goals.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5CA698B429F5115B300C42D54B59AAB3C161197F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CPSC_481___TrackStar;
using LiveCharts.Wpf;
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


namespace CPSC_481___TrackStar {
    
    
    /// <summary>
    /// Goals
    /// </summary>
    public partial class Goals : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 17 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image mealBtn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image goalsBtn;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image homeBtn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image catBtn;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image infoBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox recordsListBox;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label goalTitle;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart progVisuals;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.Axis Yaxis;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextBtn;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Goals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrevBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CPSC 481 - TrackStar;component/goals.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Goals.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\Goals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Meals_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mealBtn = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.goalsBtn = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            
            #line 24 "..\..\..\Goals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.homeBtn = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            
            #line 28 "..\..\..\Goals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cate_Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.catBtn = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            
            #line 32 "..\..\..\Goals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Info_Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.infoBtn = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.recordsListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 12:
            
            #line 83 "..\..\..\Goals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 13:
            this.goalTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.progVisuals = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 15:
            this.Yaxis = ((LiveCharts.Wpf.Axis)(target));
            return;
            case 16:
            this.NextBtn = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\..\Goals.xaml"
            this.NextBtn.Click += new System.Windows.RoutedEventHandler(this.next_Vis_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.PrevBtn = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\Goals.xaml"
            this.PrevBtn.Click += new System.Windows.RoutedEventHandler(this.prev_Vis_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 67 "..\..\..\Goals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Update_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

