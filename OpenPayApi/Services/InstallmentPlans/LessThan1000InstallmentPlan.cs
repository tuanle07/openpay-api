using System;
using System.Collections.Generic;
using OpenPayApi.Models;

namespace OpenPayApi.Services.InstallmentPlans
{
    public class LessThan1000InstallmentPlan : InstallmentPlanBase
    {
        private const decimal MinPrice = 100M;
        private const decimal MaxPrice = 1000M;
        private const decimal TwentyPercent = 0.2M;
        private const decimal ThirtyPercent = 0.3M;
        private const int FiveInstallments = 5;
        private const int FourInstallments = 4;
        private const int FifteenDays = 15;

        public override bool CanHandle(decimal purchasePrice) => purchasePrice >= MinPrice && purchasePrice < MaxPrice;

        public override List<InstallmentsDto> GetInstallmentPlan(decimal purchasePrice, DateTime purchaseDate)
        {
            var twentyPercentDeposit = purchasePrice * TwentyPercent;
            var thirtyPercentDeposit = purchasePrice * ThirtyPercent;

            return new List<InstallmentsDto>
            {
                new InstallmentsDto
                {
                    Deposit = twentyPercentDeposit,
                    Installments = GetInstallmentDetails(purchasePrice, twentyPercentDeposit, purchaseDate, FifteenDays,
                        FiveInstallments)
                },
                new InstallmentsDto
                {
                    Deposit = thirtyPercentDeposit,
                    Installments = GetInstallmentDetails(purchasePrice, thirtyPercentDeposit, purchaseDate, FifteenDays,
                        FourInstallments)
                }
            };
        }
    }
}