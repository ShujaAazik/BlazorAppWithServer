using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UserManagementApi.Models;
using System.Text;

namespace UserManagementApi.Services
{
    public class ContractConfigRepository
    {
        public readonly DbConnect _context;

        private IConfiguration _config;

        public ContractConfigRepository(DbConnect context,IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
        }

        public async Task<CommonResponseCM> AddDataFormat(DataFormat dataFormat)
        {
            CommonResponseCM response;
            try
            {
                if (!_context.DataFormats.Any(format => format.Name == dataFormat.Name))
                {
                    _context.DataFormats.Add(dataFormat);
                    await _context.SaveChangesAsync();
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
                content = await _context.DataFormats.ToListAsync();
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
                _context.Update(dataFormat);
                await _context.SaveChangesAsync();
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
                _context.DataFormats.Remove(_context.DataFormats.First(df => df.DataFormatId == dataFormatId));
                await _context.SaveChangesAsync();
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
                if (_context.DataFormats.Any(df => df.DataFormatId == contractConfig.DataFormatId))
                {
                    _context.Update(contractConfig);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Add(contractConfig);
                    await _context.SaveChangesAsync();
                }
                response = new(true);
            }
            catch (Exception)
            {
                response = new(false, "Unable to add Contract Configuration to database. Contact Help Desk for more Details");
            }

            return response;
        }

        public async Task<CommonResponseCM> ReadContractConfigs()
        {
            CommonResponseCM response;
            try
            {
                var content = await _context.contractConfigs
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
                _context.Update(contractConfig);
                await _context.SaveChangesAsync();
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
                _context.contractConfigs.Remove(_context.contractConfigs.First(contConfig => contConfig.ContractConfigId == contractConfigId));
                await _context.SaveChangesAsync();
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
                var configList = await _context.contractConfigs.Include(x => x.DataFormat).ToListAsync();

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
            if (ContractId == 0 || ContractId == null)
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
