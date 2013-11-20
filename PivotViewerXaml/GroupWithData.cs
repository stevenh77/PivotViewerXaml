using System.Collections.ObjectModel;

namespace PivotViewerXaml
{
    public class GroupWithData<T>
    {
        public Group<T> Group { get; set; }
        public ObservableCollection<T> Data { get; set; }
    }
}