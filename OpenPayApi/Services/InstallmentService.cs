using System;
using System.Collections.Generic;
using System.Linq;
using OpenPayApi.Infrastructure.Middlewares;
using OpenPayApi.Models;
using OpenPayApi.Services.InstallmentPlans;

namespace OpenPayApi.Services
{
    public interface IInstallmentService
    {
        List<InstallmentsDto> GetInstallmentPlan(decimal purchasePrice, DateTime purchaseDate);
    }

    public class InstallmentService : IInstallmentService
    {
        private readonly IEnumerable<IInstallmentPlan> _installmentPlans;

        public InstallmentService(IEnumerable<IInstallmentPlan> installmentPlans)
        {
            _installmentPlans = installmentPlans;
        }

        public List<InstallmentsDto> GetInstallmentPlan(decimal purchasePrice, DateTime purchaseDate)
        {
            var installmentPlan = _installmentPlans.First(p => p.CanHandle(purchasePrice));
            if (installmentPlan == null)
            {
                throw new HttpStatusCodeException(500, "Cannot find an installment plan for the inputted data");
            }

            return installmentPlan.GetInstallmentPlan(purchasePrice, purchaseDate);
        }
    }
}