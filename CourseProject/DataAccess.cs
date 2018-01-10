using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseProject
{
    public class DataAccess
    {
        public ObservableCollection<Data> ReadData(String filePath)
        {
            var path = Path.GetFullPath(filePath);

            if (!File.Exists(path))
                throw new FileNotFoundException("Items file not found");

            try
            {
                XDocument doc = XDocument.Load(path);
                ObservableCollection<Data> values = new ObservableCollection<Data>();

                foreach (var element in doc.Root.Elements())
                {
                    Data item = new Data();
                    item.Date = DateTime.Parse(element.Attributes().FirstOrDefault(x => x.Name == "date").Value);
                    item.Name = element.Attributes().FirstOrDefault(x => x.Name == "name").Value;
                    item.Calory = decimal.Parse(element.Attributes().FirstOrDefault(x => x.Name == "calory").Value);

                    values.Add(item);

                }

                return values;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("File reading error", ex);
            }

        }

        public ObservableCollection<Data> AddData(String filePath)
        {
            var path = Path.GetFullPath(filePath);

            if (!File.Exists(path))
                throw new FileNotFoundException("Items file not found");

            try
            {
                XDocument doc = XDocument.Load(path);
                ObservableCollection<Data> values = new ObservableCollection<Data>();

                foreach (var element in doc.Root.Elements())
                {
                    Data item = new Data();
                    item.Date = DateTime.Parse(element.Attributes().FirstOrDefault(x => x.Name == "date").Value);
                    item.Name = element.Attributes().FirstOrDefault(x => x.Name == "name").Value;
                    item.Calory = decimal.Parse(element.Attributes().FirstOrDefault(x => x.Name == "calory").Value);

                    values.Add(item);

                }

                return values;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("File reading error", ex);
            }
        }
    }
    
    public struct Data
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal? Calory { get; set; }
    }
}
