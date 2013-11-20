using System;

namespace PivotViewerXaml
{
    public class Group<T>
    {
        public string Label { get; set; }
        public Predicate<T> Predicate { get; set; }
    }
}