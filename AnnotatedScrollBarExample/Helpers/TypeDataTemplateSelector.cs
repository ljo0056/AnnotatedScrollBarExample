using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using AnnotatedScrollBarExample.Resources;

namespace AnnotatedScrollBarExample.Helpers;

public class TypeDataTemplateSelector : DataTemplateSelector
{
    private readonly Dictionary<Type, DataTemplate> dataTemplates = new();

    public TypeDataTemplateSelector()
    {        
        Register<OvenMethod>(new OvenMethodRes());
        Register<ValveMethod>(new ValveMethodRes());
        Register<CapilaryMethod>(new CapilaryMethodRes());
        Register<PackedMethod>(new PackedMethodRes());
    }

    public void Register<T>(ResourceDictionary resource, string key)
    {
        var template = resource[key] as DataTemplate;
        if (template != null)
            Register<T>(template);
    }

    public void Register<T>(ResourceDictionary resource)
    {
        var template = resource[typeof(T).Name] as DataTemplate;
        if (template != null)
            Register<T>(template);
    }

    public void Register<T>(DataTemplate? template)
    {
        if (template is not null)
            dataTemplates[typeof(T)] = template;
        else
            dataTemplates.Remove(typeof(T));
    }

    protected override DataTemplate? SelectTemplateCore(object item)
    {
        if (item is not null)
        {
            if (dataTemplates.TryGetValue(item.GetType(), out var dataTemplate))
            {
                return dataTemplate;
            }
        }

        return base.SelectTemplateCore(item);
    }

    protected override DataTemplate? SelectTemplateCore(object item, DependencyObject container) => SelectTemplateCore(item);
}
