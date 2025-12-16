using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RSCO.LoanManagement.MultiTenancy.HostDashboard.Dto;

namespace RSCO.LoanManagement.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}