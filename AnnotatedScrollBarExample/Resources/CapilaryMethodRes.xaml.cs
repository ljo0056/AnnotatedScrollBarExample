using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace AnnotatedScrollBarExample.Resources;

public sealed partial class CapilaryMethodRes : ResourceDictionary
{
    public CapilaryMethodRes()
    {
        this.InitializeComponent();
    }

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (sender is FrameworkElement f)
        {
            if (f.DataContext is GCMethod m)
                m.Height = e.NewSize.Height;
        }
    }
}