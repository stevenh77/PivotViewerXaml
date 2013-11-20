using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace PivotViewerXaml
{
    [TemplatePart(Name = "PART_LayoutRoot")]
    [TemplateVisualState(Name = "Loaded", GroupName = "CommonStates"),
    TemplateVisualState(Name = "Unloaded", GroupName = "CommonStates"),
    TemplateVisualState(Name = "Empty", GroupName = "CommonStates")]
    public class PivotViewer : Control
    {
        private Canvas partCanvas;
        private Border partLayoutRoot;
        private ContentPresenter partContent;
        public PivotViewerState PivotViewerState { get; set; }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", 
                                        typeof(IEnumerable), 
                                        typeof(PivotViewer), 
                                        new PropertyMetadata(default(IEnumerable)));

        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(PivotViewer), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set {  SetValue(ItemTemplateProperty, value);}
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public PivotViewer()
        {
            this.DefaultStyleKey = typeof(PivotViewer);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            partCanvas = this.GetTemplateChild("PART_Canvas") as Canvas;
            partLayoutRoot = (Border)this.GetTemplateChild("PART_LayoutRoot");
            partContent = (ContentPresenter)this.GetTemplateChild("PART_Content");
        }

        internal void GoToState(PivotViewerState state, bool useTransition)
        {
            VisualStateManager.GoToState(this, Enum.GetName(typeof(PivotViewerState), state), useTransition);
            PivotViewerState = state;
        }

        internal bool HasContent()
        {
            return true;
        }
    }
}