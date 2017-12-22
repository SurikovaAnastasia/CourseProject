using AutoMapper;
using CourseProject.BLL.DTO;
using CourseProject.BLL.Interfaces;
using CourseProject.DAL.Entities;
using CourseProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BLL.Services
{
    public class HavingFood : IHavingFood
    {
        IUnitOfWork Database { get; set; }
        public HavingFood(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void HaveFood(FoodDTO foodDTO)
        {
            Food food = new Food
            {
                Date = foodDTO.Date,
                Calories = foodDTO.Calories,
                NameOfFood = foodDTO.NameOfFood
            };
            Database.Foods.Create(food);
            Database.Save();
        }

        public FoodDTO GetFood(DateTime date)
        {
            var food = Database.Foods.Get(date);
            Mapper.Initialize(cfg => cfg.CreateMap<Food, FoodDTO>());
            return Mapper.Map<Food, FoodDTO>(food);
        }

        public IEnumerable<FoodDTO> GetFoods()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Food, FoodDTO>());
            return Mapper.Map<IEnumerable<Food>, List<FoodDTO>>(Database.Foods.GetAll());
        }
        public void Dispose() => Database.Dispose();
    }
}
