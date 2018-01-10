using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CourseProject
{
    public class AddCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FoodViewModel vm = new FoodViewModel();
            XDocument doc = XDocument.Load(Properties.Settings.Default.DataConnection);

            if (!String.IsNullOrWhiteSpace(vm.Selected.IdRS))
            {
                doc.Root.Add(new XElement("Item",
                new XAttribute("date", vm.Date.ToString()),
                new XAttribute("name", vm.Selected.BrandRS + " " + vm.Selected.NameRS),
                new XAttribute("calory", vm.Selected.CaloriesRS.ToString())));
                doc.Save(Properties.Settings.Default.DataConnection);
            }            
        }


        public event EventHandler CanExecuteChanged;
    }
}

