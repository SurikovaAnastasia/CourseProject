using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CourseProject
{
    class DataConverter
    {
        public ObservableCollection<Grid> DataGrid(ObservableCollection<Data> Items, DateTime Date)
        {       
            if (Items != null)
            {
                ObservableCollection<Grid> Rows = new ObservableCollection<Grid>();
                foreach (var item in Items)
                {
                    if ((item.Date.Day == Date.Day) && (item.Date.Month == Date.Month) && (item.Date.Year == Date.Year))
                    {
                        Grid Row = new Grid();
                        Row.Name = item.Name;
                        Row.Calory = item.Calory;
                        Rows.Add(Row);
                    }
                }
                return Rows;
            }
            else
                throw new ArgumentNullException("В XML ничего нет");
        }
    }

    public struct Grid
    {
        public string Name { get; set; }
        public decimal? Calory { get; set; }
    }
}
