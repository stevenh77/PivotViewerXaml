using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PivotViewerXaml
{
    public class ViewModel<T> : PropertyChangedBase
    {
        public IEnumerable<T> Source { get; set; }
        public ObservableCollection<Filter<T>> Filters { get; private set; }
        public ObservableCollection<GroupWithData<T>> GroupsWithData { get; private set; }
        private IEnumerable<IGrouping<string, T>> groupedData;

        public ViewModel(IEnumerable<T> source, Func<T, string> keySelector)
        {
            Source = source;
            Filters = new ObservableCollection<Filter<T>>();
            SetGroupingProperty(keySelector);
        }

        private void CreateBindableGroupsWithData(Func<T, string, bool> groupPredicate)
        {
            GroupsWithData = new ObservableCollection<GroupWithData<T>>();
            foreach (var group in groupedData)
            {
                var localGroup = group;
                var bindableGroup = new Group<T>
                                    {
                                        Label = localGroup.Key,
                                        Predicate = t => groupPredicate(t, localGroup.Key)
                                    };
                var bindableData = new ObservableCollection<T>(localGroup);
                var groupWithData = new GroupWithData<T> { Data = bindableData, Group = bindableGroup };
                GroupsWithData.Add(groupWithData);
            }
            ApplyFilters();
            OnPropertyChanged("GroupsWithData");
        }

        public void AddFilter(Filter<T> filter)
        {
            this.Filters.Add(filter);
        }

        public void SetGroupingProperty(Func<T, string> keySelector)
        {
            groupedData = Source.GroupBy(keySelector);
            var groupPredicate = new Func<T, string, bool>((t, s) => keySelector.Invoke(t) == s);
            CreateBindableGroupsWithData(groupPredicate);
        }

        public void ApplyFilters()
        {
            foreach (var groupWithData in GroupsWithData)
            {
                // combine group predicate with the filters
                var filterAndGroupPredicates = (from f in Filters select f.Predicate)
                                                .Union(new[] { groupWithData.Group.Predicate })
                                                .Select(p => p);

                // loop through our source 
                foreach (var tradeInSource in Source)
                {
                    var doesTradeBelongInGroup = filterAndGroupPredicates.All(predicate => predicate(tradeInSource));
                    var tradeAlreadyInGroup = groupWithData.Data.Contains(tradeInSource);

                    if (doesTradeBelongInGroup && !tradeAlreadyInGroup)
                    {
                        // add
                        groupWithData.Data.Add(tradeInSource);
                    }
                    else if (!doesTradeBelongInGroup && tradeAlreadyInGroup)
                    {
                        // remove
                        groupWithData.Data.Remove(tradeInSource);
                    }
                }
            }
        }
        
        public void ClearFilters()
        {
            this.Filters.Clear();
            this.ApplyFilters();
        }
    }
}