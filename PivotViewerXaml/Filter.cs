using System;

namespace PivotViewerXaml
{
    public class Filter<T>
    {
        public string Description { get; set; }
        public Predicate<T> Predicate{ get; set; }
    }
}
