using Abp.Dependency;
using Abp.ObjectMapping;
using RSCO.LoanManagement.ApiClient;
using RSCO.LoanManagement.ApiClient.Models;
using RSCO.LoanManagement.Maui.Core;
using RSCO.LoanManagement.Maui.Core.DataStorage;
using RSCO.LoanManagement.Maui.Models.Common;
using RSCO.LoanManagement.Sessions.Dto;

namespace RSCO.LoanManagement.Maui.Services.Storage
{
    public class DataStorageService : IDataStorageService, ISingletonDependency
    {
        private readonly IDataStorageManager _dataStorageManager;
        private readonly IObjectMapper _objectMapper;

        public DataStorageService(
            IDataStorageManager dataStorageManager,
            IObjectMapper objectMapper)
        {
            _dataStorageManager = dataStorageManager;
            _objectMapper = objectMapper;
        }

        public async Task StoreAccessTokenAsync(string newAccessToken, string newEncryptedAccessToken)
        {
            var authenticateResult = _dataStorageManager.Retrieve<AuthenticateResultPersistanceModel>(MauiConsts.CurrentSessionTokenInfo);

            authenticateResult.AccessToken = newAccessToken;
            authenticateResult.EncryptedAccessToken = newEncryptedAccessToken;

            await _dataStorageManager.StoreAsync(MauiConsts.CurrentSessionTokenInfo, authenticateResult);
        }

        public AbpAuthenticateResultModel RetrieveAuthenticateResult()
        {
            var data = _dataStorageManager.Retrieve<AuthenticateResultPersistanceModel>(
                    MauiConsts.CurrentSessionTokenInfo
            );

            return _objectMapper.Map<AbpAuthenticateResultModel>(
                data
            );
        }

        public async Task StoreAuthenticateResultAsync(AbpAuthenticateResultModel authenticateResultModel)
        {
            await _dataStorageManager.StoreAsync(
                MauiConsts.CurrentSessionTokenInfo,
                _objectMapper.Map<AuthenticateResultPersistanceModel>(authenticateResultModel)
            );
        }

        public TenantInformation RetrieveTenantInfo()
        {
            return _objectMapper.Map<TenantInformation>(
                _dataStorageManager.Retrieve<TenantInformationPersistanceModel>(
                    MauiConsts.CurrentSessionTenantInfo
                )
            );
        }

        public async Task StoreTenantInfoAsync(TenantInformation tenantInfo)
        {
            await _dataStorageManager.StoreAsync(
                MauiConsts.CurrentSessionTenantInfo,
                _objectMapper.Map<TenantInformationPersistanceModel>(tenantInfo)
            );
        }

        public GetCurrentLoginInformationsOutput RetrieveLoginInfo()
        {
            return _objectMapper.Map<GetCurrentLoginInformationsOutput>(
                _dataStorageManager.Retrieve<CurrentLoginInformationPersistanceModel>(
                    MauiConsts.CurrentSessionLoginInfo
                )
            );
        }

        public async Task StoreLoginInformationAsync(GetCurrentLoginInformationsOutput loginInfo)
        {
            await _dataStorageManager.StoreAsync(
                MauiConsts.CurrentSessionLoginInfo,
                _objectMapper.Map<CurrentLoginInformationPersistanceModel>(
                    loginInfo
                )
            );
        }

        public void ClearSessionPersistance()
        {
            _dataStorageManager.RemoveIfExists(MauiConsts.CurrentSessionTokenInfo);
            _dataStorageManager.RemoveIfExists(MauiConsts.CurrentSessionTenantInfo);
            _dataStorageManager.RemoveIfExists(MauiConsts.CurrentSessionLoginInfo);
        }
    }
}