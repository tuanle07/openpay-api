using OpenPayApi.Models;
using OpenPayApi.Services;
using OpenPayApi.Services.InstallmentPlans;
using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace OpenPayApi.Tests
{
    public class InstallmentServiceTests
    {
        [Theory]
        [MemberData(nameof(GetInstallmentPlanTestData))]
        public void GetInstallmentPlan_ReturnCorrectInstallments(decimal purchasePrice, DateTime purchaseDate,
            List<InstallmentsDto> expectedInstallments)
        {
            // arrange
            var installmentPlans = new List<IInstallmentPlan>
            {
                new LessThan100InstallmentPlan(),
                new LessThan1000InstallmentPlan(),
                new LessThan10000InstallmentPlan(),
                new LargerThan10000InstallmentPlan()
            };
            var installmentService = new InstallmentService(installmentPlans);

            // act
            var actualInstallments = installmentService.GetInstallmentPlan(purchasePrice, purchaseDate);

            // assert
            actualInstallments.Should().BeEquivalentTo(expectedInstallments);
        }

        public static IEnumerable<object[]> GetInstallmentPlanTestData()
        {
            var today = DateTime.Now.Date;
            yield return new object[]
            {
                10, today, new List<InstallmentsDto>()
            };

            yield return new object[]
            {
                500, today, new List<InstallmentsDto>
                {
                    new InstallmentsDto
                    {
                        Deposit = 100.0M,
                        Installments = new List<InstallmentsDto.InstallmentDetail>
                        {
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 80.0M,
                                PaymentDate = today.AddDays(15)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 80.0M,
                                PaymentDate = today.AddDays(30)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 80.0M,
                                PaymentDate = today.AddDays(45)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 80.0M,
                                PaymentDate = today.AddDays(60)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 80.0M,
                                PaymentDate = today.AddDays(75)
                            }
                        }
                    },
                    new InstallmentsDto
                    {
                        Deposit = 150.0M,
                        Installments = new List<InstallmentsDto.InstallmentDetail>
                        {
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 87.5M,
                                PaymentDate = today.AddDays(15)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 87.5M,
                                PaymentDate = today.AddDays(30)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 87.5M,
                                PaymentDate = today.AddDays(45)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 87.5M,
                                PaymentDate = today.AddDays(60)
                            },
                        }
                    }
                }
            };

            yield return new object[]
            {
                1000, today, new List<InstallmentsDto>
                {
                    new InstallmentsDto
                    {
                        Deposit = 250.0M,
                        Installments = new List<InstallmentsDto.InstallmentDetail>
                        {
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 187.5M,
                                PaymentDate = today.AddDays(30)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 187.5M,
                                PaymentDate = today.AddDays(60)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 187.5M,
                                PaymentDate = today.AddDays(90)
                            },
                            new InstallmentsDto.InstallmentDetail
                            {
                                Amount = 187.5M,
                                PaymentDate = today.AddDays(120)
                            },
                        }
                    }
                }
            };

            yield return new object[]
            {
                10000, today, new List<InstallmentsDto>()
            };
        }
    }
}