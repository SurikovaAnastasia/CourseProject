using CourseProject.BLL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CourseProject.PL.Converters
{
    public class ResultOfSearchConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {

            try
            {
                ObservableCollection<ResultOfSearch> FoodList = (ObservableCollection<ResultOfSearch>)value;
                ObservableCollection<string> FoodName = (ObservableCollection<string>)parameter;
                foreach (ResultOfSearch Food in FoodList)
                {
                    FoodName.Add(Food.NameRS);
                }
                return FoodName;
            }
            catch
            {
                return "Hmmmmmm";
            }
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
