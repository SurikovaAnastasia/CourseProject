using CourseProject.BLL.Interfaces;
using CourseProject.BLL.Services;
using Ninject.Modules;

namespace CourseProject.PL.Util
{
    public class FoodModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHavingFood>().To<HavingFood>();
        }
    }
}
