using System;
using System.Linq;
using System.Windows;

namespace PivotViewerXaml
{
    public partial class MainPage
    {
        private ViewModel<Trade> viewModel;

        private Grouping currentGrouping;

        public MainPage()
        {
            InitializeComponent();
            var items = Trade.CreateTrades();
            viewModel = new ViewModel<Trade>(items, t => t.Sector.ToString());
            currentGrouping = Grouping.Sector;
            UpdateGroupByPropertyText();
            this.DataContext = viewModel;
        }

        private void AddFilterForLastSevenDays_OnClick(object sender, RoutedEventArgs e)
        {
            var filter = new Filter<Trade>
            {
                Description = "t => t.DealDate >= DateTime.Today.AddDays(-7)",
                Predicate = t => t.DealDate >= DateTime.Today.AddDays(-7)
            };
            viewModel.AddFilter(filter);
        }

        private void AddFilterForChfOrUsd_OnClick(object sender, RoutedEventArgs e)
        {
            var filter = new Filter<Trade>
            {
                Description = "t => new[] { 'CHF', 'USD' }.Contains(t.Currency.Code)",
                Predicate = t => new[] { "CHF", "USD" }.Contains(t.Currency.Code)
            };
            viewModel.AddFilter(filter);
        }

        private void ApplyFilter_OnClick(object sender, RoutedEventArgs e)
        {
            viewModel.ApplyFilters();
        }

        private void ClearFilter_OnClick(object sender, RoutedEventArgs e)
        {
            viewModel.ClearFilters();
        }

        private void ChangeGroupingProperty_OnClick(object sender, RoutedEventArgs e)
        {
            Func<Trade, string> keySelector = null;
            switch (currentGrouping)
            {
                case Grouping.Sector:
                    keySelector = t => t.Currency.Code;
                    currentGrouping = Grouping.Currency;
                    break;
                case Grouping.Currency:
                    keySelector = t => t.Underlying;
                    currentGrouping = Grouping.Underlying;
                    break;
                case Grouping.Underlying:
                    keySelector = t => t.Sector.ToString();
                    currentGrouping = Grouping.Sector;
                    break;
            }

            UpdateGroupByPropertyText();
            viewModel.SetGroupingProperty(keySelector);
        }

        private void UpdateGroupByPropertyText()
        {
            this.GroupByProperty.Text = currentGrouping.ToString();    
        }

        private enum Grouping
        {
            Sector,
            Currency,
            Underlying
        }
    }
}