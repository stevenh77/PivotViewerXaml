using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PivotViewerXaml
{
    public class PivotSource<T> : ObservableCollection<T>
    {
        public PivotSource(IEnumerable<T> list) : base(list)
        {
        }
    }
}