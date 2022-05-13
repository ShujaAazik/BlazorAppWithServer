using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UserManagementApi.Models;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Collections;

namespace UserManagementApi.Services
{
    public class ContractConfigRepository
    {
        private LookupContext _lookUpContext;

        private IConfiguration _config;

        public ContractConfigRepository(LookupContext lookUpContext, IConfiguration configuration)
        {
            _lookUpContext = lookUpContext;
            _config = configuration;
        }

        public async Task<CommonResponseCM> AddDataFormat(DataFormat dataFormat)
        {
            CommonResponseCM response;
            try
            {
                if (!_lookUpContext.DataFormats.Any(format => format.Name == dataFormat.Name))
                {
                    _lookUpContext.DataFormats.Add(dataFormat);
                    await _lookUpContext.SaveChangesAsync();
                }
                response = new(true);
            }
            catch (Exception)
            {
                response = new(false, "Unable to add Data Format to database. Contact Help Desk for more Details");
            }
            
            return response;
        }

        public async Task<CommonResponseCM> GetDataFormats()
        {
            var content = new List<DataFormat>();
            CommonResponseCM response;
            try
            {
                content = await _lookUpContext.DataFormats.ToListAsync();
                response = new(true);
                response.CreateContent(content);
            }
            catch (Exception)
            {
                response = new(false,"Unable to retrieve Data Formats from database. Contact Help Desk for more Details");
            }

            return response;
        }

        public async Task<CommonResponseCM> UpdateDataFormat(DataFormat dataFormat)
        {
            CommonResponseCM response;
            try
            {
                _lookUpContext.Update(dataFormat);
                await _lookUpContext.SaveChangesAsync();
                response = new(true);
            }
            catch (Exception)
            {
                response = new(false, "Unable to update Data Format to database. Contact Help Desk for more details");
            }

            return response;
        }

        public async Task<CommonResponseCM> RemoveDataFormat(int dataFormatId)
        {
            CommonResponseCM response;
            try
            {
                _lookUpContext.DataFormats.Remove(_lookUpContext.DataFormats.First(df => df.DataFormatId == dataFormatId));
                await _lookUpContext.SaveChangesAsync();
                response = new(true);
            }
            catch (Exception)
            {
                response = new(false, "Unable to remove Data Format from database. Contact Help Desk for more details");
            }

            return response;
        }

        public async Task<CommonResponseCM> AddContractConfig(ContractConfig contractConfig)
        {
            CommonResponseCM response;
            try
            {
                if (_lookUpContext.DataFormats.Any(df => df.DataFormatId == contractConfig.DataFormatId))
                {
                    _lookUpContext.Update(contractConfig);
                }
                else
                {
                    _lookUpContext.Add(contractConfig);
                }
                await _lookUpContext.SaveChangesAsync();
                response = new(true);
            }
            catch (Exception ex)
            {
                response = new(false, "Unable to add Contract Configuration to database. Contact Help Desk for more Details");
            }

            return response;
        }
        
        public async Task<CommonResponseCM> ReadContractDictionary()
        {

            CommonResponseCM response;
            var content = await _lookUpContext.ContractConfig
                .Include(x => x.DataFormat)
                .ToListAsync();
            response = new(true);
            response.CreateContent(content);
            return response;
        }

        public async Task<CommonResponseCM> ReadContractConfigs()
        {
            CommonResponseCM response;
            try
            {
                var content = await _lookUpContext.ContractConfig
                                .Include(x => x.DataFormat)
                                .Take(_config.GetValue<int>("DisplayedRowList"))
                                .ToListAsync();
                response = new(true);
                response.CreateContent(content);
            }
            catch (Exception)
            {
                response = new(false, "Unable to retrieve Contract Configurations from database. Contact Help Desk for more Details");
            }

            return response;
        }

        public async Task<CommonResponseCM> UpdateContractConfig(ContractConfig contractConfig)
        {
            CommonResponseCM response;
            try
            {
                _lookUpContext.Update(contractConfig);
                await _lookUpContext.SaveChangesAsync();
                response = new(true);
            }
            catch (Exception)
            {
                response = new(false, "Unable to update Contract Configuration to database. Contact Help Desk for more Details");
            }

            return response;
        }

        public async Task<CommonResponseCM> DeleteContractConfig(int contractConfigId)
        {
            CommonResponseCM response;
            try
            {
                _lookUpContext.ContractConfig.Remove(_lookUpContext.ContractConfig.First(contConfig => contConfig.ContractConfigId == contractConfigId));
                await _lookUpContext.SaveChangesAsync();
                response = new(true);
            }
            catch (Exception)
            {
                response = new(false, "Unable to remove Contract Configuration from database. Contact Help Desk for more Details");
            }

            return response;
        }

        public async Task<CommonResponseCM> GetFilteredConfigList(ContractConfigSearchCM contractConficSearchCM)
        {
            CommonResponseCM response;
            try
            {
                var configList = await _lookUpContext.ContractConfig.Include(x => x.DataFormat).ToListAsync();

                configList = FilterCode(configList, contractConficSearchCM.Code);
                configList = FilterContractId(configList, contractConficSearchCM.ContractId);
                configList = FilterDescription(configList, contractConficSearchCM.Description);
                configList = FilterDataFormatId(configList, contractConficSearchCM.DataFormatId);

                response = new(true);
                response.CreateContent(configList);
            }
            catch (Exception)
            {
                response = new(false, "Unable to retrieve Contract Configurations from database. Contact Help Desk for more Details");
            }

            return response;
        }

        private static List<ContractConfig> FilterCode(List<ContractConfig> contractConfigurations, string Code)
        {
            if (string.IsNullOrEmpty(Code))
            {
                return contractConfigurations;
            }

            return contractConfigurations.Where(x => x.Code.ToLower().Contains(Code.ToLower())).ToList();
        }

        private static List<ContractConfig> FilterDescription(List<ContractConfig> contractConfigurations, string Description)
        {
            if (string.IsNullOrEmpty(Description))
            {
                return contractConfigurations;
            }

            return contractConfigurations.Where(x => x.Description.ToLower().Contains(Description.ToLower())).ToList();
        }

        private static List<ContractConfig> FilterContractId(List<ContractConfig> contractConfigurations, int? ContractId)
        {
            if (ContractId == -1 || ContractId == null)
            {
                return contractConfigurations;
            }

            return contractConfigurations.Where(x => x.ContractId == ContractId).ToList();
        }

        private static List<ContractConfig> FilterDataFormatId(List<ContractConfig> contractConfigurations, int? DataFormatId)
        {
            if (DataFormatId == 0 || DataFormatId == null)
            {
                return contractConfigurations;
            }

            return contractConfigurations.Where(x => x.DataFormatId.Equals(DataFormatId)).ToList();
        }
    }
}
