using AnnotatedScrollBarExample.Resources;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AnnotatedScrollBarExample.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    public ObservableCollection<GCMethod> Methods { get; } = new();

    private GCMethod? selectItem = null;
    public GCMethod? SelectItem
    {
        get => selectItem;
        set => selectItem = value;
    }

    public MainViewModel()
    {
        Methods.Add(new OvenMethod());
        Methods.Add(new ValveMethod());
        Methods.Add(new CapilaryMethod());
        Methods.Add(new PackedMethod());
    }
}