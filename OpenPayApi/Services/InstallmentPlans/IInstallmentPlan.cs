using System;
using System.Collections.Generic;
using OpenPayApi.Models;

namespace OpenPayApi.Services.InstallmentPlans
{
    public interface IInstallmentPlan
    {
        bool CanHandle(decimal purchasePrice);

        List<InstallmentsDto> GetInstallmentPlan(decimal purchasePrice, DateTime purchaseDate);
    }
}
