using System;
using System.Collections.Generic;
using OpenPayApi.Models;

namespace OpenPayApi.Services.InstallmentPlans
{
    public class LargerThan10000InstallmentPlan : IInstallmentPlan
    {
        private const decimal MinPrice = 10000M;

        public bool CanHandle(decimal purchasePrice) => purchasePrice >= MinPrice;

        public List<InstallmentsDto> GetInstallmentPlan(decimal purchasePrice, DateTime purchaseDate)
        {
            return new List<InstallmentsDto>();
        }
    }
}