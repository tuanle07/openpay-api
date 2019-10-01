using System;
using System.Collections.Generic;
using OpenPayApi.Models;

namespace OpenPayApi.Services.InstallmentPlans
{
    public class LessThan100InstallmentPlan : InstallmentPlanBase
    {
        private const decimal MinPrice = 0M;
        private const decimal MaxPrice = 100M;

        public override bool CanHandle(decimal purchasePrice) => purchasePrice >= MinPrice && purchasePrice < MaxPrice;

        public override List<InstallmentsDto> GetInstallmentPlan(decimal purchasePrice, DateTime purchaseDate)
        {
            return new List<InstallmentsDto>();
        }
    }
}