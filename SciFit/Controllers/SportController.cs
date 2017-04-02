﻿using System.Dynamic;
using System.Web.Mvc;
using SciFit.Logic;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class SportController : Controller
    {
        public ActionResult SportPlan(UserModel userModel)
        {
            var generatePlan = new GeneratePlan();

            //Hardcoded for normal user
            userModel.RoleId = 1;

            var users = new Users();

            if (users.PostUser(userModel))
            {
                var plan = new SportNutritionPlanModel
                {
                    SportPlan = generatePlan.GenerateSportPlan(userModel),
                    NutritionPlan = generatePlan.GenerateNutritionPlan(userModel)
                };
                return View("Plan", plan);
            }
            return null;
        }

        public ActionResult Login(UserModel userModel)
        {
            var generatePlan = new GeneratePlan();
            var user = new Users();

            //Get logged in user data from model in db
            //var loggedInData = user.PostUser(userModel);

            var loggedInData = user.UserLogin(userModel.UserName, userModel.Password);

            if (loggedInData != null)
            {
                var userData = new SportNutritionPlanModel
                {
                    SportPlan = generatePlan.GenerateSportPlan(userModel),
                    NutritionPlan = generatePlan.GenerateNutritionPlan(userModel),
                    User = loggedInData
                };

                return View("Plan", userData);
            }

            return RedirectToAction("Login", "Authentication");
        }
    }
}