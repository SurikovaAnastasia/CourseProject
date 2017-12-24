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
            if (value != null)
            {
                ObservableCollection<ResultOfSearch> FoodList = (ObservableCollection<ResultOfSearch>)value;
                ObservableCollection<string> FoodName = new ObservableCollection<string>();
                foreach (ResultOfSearch Food in FoodList)
                {
                    FoodName.Add(Food.BrandRS + " " + Food.NameRS);
                }
                return FoodName;
            }
            else
                throw new ArgumentNullException("Ничего не введено");
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
