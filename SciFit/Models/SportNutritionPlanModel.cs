﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFit.Models
{
    public class SportNutritionPlanModel
    {
        public List<SportPlanModel> SportPlan { get; set; }

        public List<NutritionPlanModel> NutritionPlan { get; set; }
    }
}