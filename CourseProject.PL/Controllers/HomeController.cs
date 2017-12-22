using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AutoMapper;
using CourseProject.BLL.DTO;
using CourseProject.BLL.Interfaces;
using CourseProject.PL.Models;

namespace CourseProject.PL.Controllers
{
    class HomeContrller : Controller
    {
        IHavingFood havingFood;
        public HomeContrller(IHavingFood have)
        {
            havingFood = have;
        }
        public ActionResult Index()
        {
            IEnumerable<FoodDTO> foodDtos = havingFood.GetFoods();
            Mapper.Initialize(cfg => cfg.CreateMap < FoodDTO, FoodViewModel>());
            var foods = Mapper.Map<IEnumerable<FoodDTO>, List<FoodViewModel>>(foodDtos);
            return View(foods);
        }

        public ActionResult HaveFood(DateTime date)
        {
            try
            {
                FoodDTO fooD = havingFood.GetFood(date);
                Mapper.Initialize(cfg => cfg.CreateMap < FoodDTO, FoodViewModel>().ForMember("FoodId", opt => opt.MapFrom(src => src.Id)));
                var food = Mapper.Map < FoodDTO, FoodViewModel>(fooD);
                return View(food);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult HaveFood(FoodViewModel food)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap < FoodViewModel, FoodDTO>());
                var foodDto = Mapper.Map < FoodViewModel, FoodDTO>(food);
                havingFood.HaveFood(foodDto);
            }
            catch (ValidationException ex)
            {
                //return Content(ex.Message);
            }
            return View(food);
        }
        protected override void Dispose(bool disposing)
        {
            havingFood.Dispose();
            base.Dispose(disposing);
        }
    }
}