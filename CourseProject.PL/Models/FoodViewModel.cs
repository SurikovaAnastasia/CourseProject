using System;
using System.Collections.Generic;
using System.ComponentModel;
using CourseProject.BLL.BusinessModels;
using System.Windows.Input;
using CourseProject.PL.Commands;
using System.Collections.ObjectModel;

namespace CourseProject.PL.Models
{
    public class FoodViewModel : INotifyPropertyChanged
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }

        private string _search;
        private ObservableCollection<ResultOfSearch> _searchResult;
        private ResultOfSearch _selected;

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

        public ICommand AddCom { get; set; }

        public FoodViewModel()
        {
            SearchResult = new ObservableCollection<ResultOfSearch>();
            //AddCom = new AddCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
    }
}
    
