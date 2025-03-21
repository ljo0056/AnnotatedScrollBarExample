using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AnnotatedScrollBarExample.Resources;

public class GCMethod : ObservableObject
{
    public string Title
    {
        get;
        set;
    } = "";

    private double height = double.NaN;
    public double Height
    {
        get => height;
        set => SetProperty(ref height, value);
    }    
}

public class OvenMethod : GCMethod
{
    public int Index { get; set; } = 1;
    public OvenMethod()
    {
        Title = "Oven";
    }
}

public class ValveMethod : GCMethod
{
    public int Index { get; set; } = 2;
    public string Temp { get; set; } = "Temp";
    public ValveMethod()
    {
        Title = "Valve";
    }
}

public class CapilaryMethod : GCMethod
{
    public int Index { get; set; } = 2;
    public string Temp { get; set; } = "Temp";
    public CapilaryMethod()
    {
        Title = "Capilary (1)";
    }
}

public class PackedMethod : GCMethod
{
    public int Index { get; set; } = 2;
    public string Temp { get; set; } = "Temp";
    public PackedMethod()
    {
        Title = "Packed (1)";
    }
}