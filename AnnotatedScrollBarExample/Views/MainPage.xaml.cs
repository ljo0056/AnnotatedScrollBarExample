using AnnotatedScrollBarExample.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace AnnotatedScrollBarExample.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {        
        ViewModel = App.GetService<MainViewModel>();        
        InitializeComponent();
    }

    private void PopulateLabelCollection()
    {
        if (0 == ViewModel.Methods.Count)
            return;
        if (null == annotatedScrollBar || double.IsNaN(ViewModel.Methods[0].Height))
            return;

        annotatedScrollBar.Labels.Clear();

        var y = 0;
        annotatedScrollBar.Labels.Add(new AnnotatedScrollBarLabel(ViewModel.Methods[0].Title, y));
        y += Convert.ToInt32(ViewModel.Methods[0].Height);

        for (var i = 1; i < ViewModel.Methods.Count; i++)
        {
            var m = ViewModel.Methods[i];
            annotatedScrollBar.Labels.Add(new AnnotatedScrollBarLabel(m.Title, y));

            if (double.IsNaN(m.Height))
                break;

            y += Convert.ToInt32(m.Height);
        }
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        scrollView.ScrollPresenter.VerticalScrollController = annotatedScrollBar.ScrollController;
        PopulateLabelCollection();
    }

    private void ItemsRepeater_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        //PopulateLabelCollection();
    }

    private void AnnotatedScrollBar_DetailLabelRequested(AnnotatedScrollBar sender, AnnotatedScrollBarDetailLabelRequestedEventArgs e)
    {
        if (null == sender)
            return;
        if (0 == sender?.Labels.Count)
            return;

        var label = sender!.Labels.LastOrDefault(l => l.ScrollOffset < e.ScrollOffset);
        if (null != label)
            e.Content = label.Content.ToString();
    }
}
