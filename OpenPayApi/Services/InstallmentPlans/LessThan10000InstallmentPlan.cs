using System;
using System.Collections.Generic;
using OpenPayApi.Models;

namespace OpenPayApi.Services.InstallmentPlans
{
    public class LessThan10000InstallmentPlan : InstallmentPlanBase
    {
        private const decimal MinPrice = 1000M;
        private const decimal MaxPrice = 10000M;
        private const decimal TwentyFivePercent = 0.25M;
        private const int FourInstallments = 4;
        private const int ThirtyDays = 30;

        public override bool CanHandle(decimal purchasePrice) => purchasePrice >= MinPrice && purchasePrice < MaxPrice;

        public override List<InstallmentsDto> GetInstallmentPlan(decimal purchasePrice, DateTime purchaseDate)
        {
            var deposit = purchasePrice * TwentyFivePercent;

            return new List<InstallmentsDto>
            {
                new InstallmentsDto
                {
                    Deposit = deposit,
                    Installments = GetInstallmentDetails(purchasePrice, deposit, purchaseDate, ThirtyDays,
                        FourInstallments)
                }
            };
        }
    }
}