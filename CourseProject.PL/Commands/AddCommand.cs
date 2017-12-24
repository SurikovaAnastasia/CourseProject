using CourseProject.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Reflection;

namespace CourseProject.PL.Commands
{
    class AddCommand : ICommand
    {
        public bool CanExecute(Object parameter)
        {
            return true;
        }

        public void Execute(Object parameter)
        {
            var vmAdd = parameter as FoodViewModel;
            string newElements = "bhjnk";
            if (vmAdd == null)
                throw new ArgumentNullException("Модель представления не может быть null");
            //if (String.IsNullOrWhiteSpace(vmAdd.Selected))
                throw new ArgumentNullException("Выбранная еда не может быть null");
            var prop = parameter.GetType().GetProperty("Foods",
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            prop.SetValue(parameter, newElements);
        }

        public event EventHandler CanExecuteChanged;
    }
}
