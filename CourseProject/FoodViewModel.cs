using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Reflection;
using System.IO;

namespace CourseProject
{
    public class FoodViewModel : INotifyPropertyChanged
    {
        private DateTime _date;
        private string _search;
        private ObservableCollection<ResultOfSearch> _searchResult;
        private ResultOfSearch _selected;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                DoPropertyChanged(nameof(Date));
                ObservableCollection<Data> Items = new ObservableCollection<Data>();
                DataAccess da = new DataAccess();
                DataConverter dc = new DataConverter();
                Items = da.ReadData(Properties.Settings.Default.DataConnection);
                Table = dc.DataGrid(Items, _date);
                DoPropertyChanged(nameof(Table));
            }
        }

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                API api = new API();
                SearchResult = api.SearchQuery(_search);
                DoPropertyChanged(nameof(SearchResult));
                DoPropertyChanged(nameof(Search));
            }
        }

        public ObservableCollection<ResultOfSearch> SearchResult
        {
            get { return _searchResult; }
            set
            {
                _searchResult = value;
                DoPropertyChanged(nameof(SearchResult));
            }
        }

        public ResultOfSearch Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                DoPropertyChanged(nameof(Selected));
            }
        }

        public ObservableCollection<Grid> Table { get; set; }

        public ICommand AddCom { get; set; }

        public FoodViewModel()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            SearchResult = new ObservableCollection<ResultOfSearch>();

            ResultOfSearch a = new ResultOfSearch();
            a.BrandRS = "1";
            a.CaloriesRS = 2;
            a.IdRS = "3";
            a.NameRS = "4";
            SearchResult.Add(a);
            Selected = a;

            Date = DateTime.Today;

            AddCom = new AddCommand();
        }

        #region
        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
        #endregion
    }
}
