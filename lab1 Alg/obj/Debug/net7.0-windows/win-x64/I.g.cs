﻿#pragma checksum "..\..\..\..\I.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8B7022CB7714C26609B9590EE97395B0C8D5CE29"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ScottPlot.WPF;
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
using lab1_Alg;


namespace lab1_Alg {
    
    
    /// <summary>
    /// I
    /// </summary>
    public partial class I : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ScottPlot.WPF.WpfPlot Graph;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SlMaxVal;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SelectAlg;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbNumGraphs;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SlVectorLength;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtClearPlot;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SlCountStart;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbPow;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CbLoad;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\I.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CbAprox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/lab1 Alg;component/i.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\I.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Graph = ((ScottPlot.WPF.WpfPlot)(target));
            return;
            case 2:
            this.SlMaxVal = ((System.Windows.Controls.Slider)(target));
            return;
            case 3:
            
            #line 23 "..\..\..\..\I.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtStart);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SelectAlg = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\..\I.xaml"
            this.SelectAlg.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectAlg_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TbNumGraphs = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SlVectorLength = ((System.Windows.Controls.Slider)(target));
            return;
            case 7:
            this.BtClearPlot = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\I.xaml"
            this.BtClearPlot.Click += new System.Windows.RoutedEventHandler(this.ClearPlot);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SlCountStart = ((System.Windows.Controls.Slider)(target));
            return;
            case 9:
            this.TbPow = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.CbLoad = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this.CbAprox = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

