using System;
using System.Collections.Generic;
using OpenPayApi.Models;

namespace OpenPayApi.Services.InstallmentPlans
{
    public abstract class InstallmentPlanBase : IInstallmentPlan
    {
        protected IEnumerable<InstallmentsDto.InstallmentDetail> GetInstallmentDetails(decimal purchasePrice,
            decimal deposit,
            DateTime purchaseDate, int installmentInterval, int numberOfInstallments)
        {
            var installmentDetails = new List<InstallmentsDto.InstallmentDetail>();
            for (var i = 1; i <= numberOfInstallments; i++)
            {
                installmentDetails.Add(new InstallmentsDto.InstallmentDetail
                {
                    Amount = (purchasePrice - deposit) / numberOfInstallments,
                    PaymentDate = purchaseDate.AddDays(installmentInterval * i)
                });
            }

            return installmentDetails;
        }

        public abstract bool CanHandle(decimal purchasePrice);

        public abstract List<InstallmentsDto> GetInstallmentPlan(decimal purchasePrice, DateTime purchaseDate);
    }
}