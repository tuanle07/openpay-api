using System;
using System.Collections.Generic;

namespace OpenPayApi.Models
{
    public class InstallmentsDto
    {
        public decimal Deposit { get; set; }

        public IEnumerable<InstallmentDetail> Installments { get; set; }

        public class InstallmentDetail
        {
            public decimal Amount { get; set; }

            public DateTime PaymentDate { get; set; }
        }
    }
}
