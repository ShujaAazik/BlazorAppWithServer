using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;

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

        public async Task AddDataFormat(DataFormat dataFormat)
        {
            if (!_context.DataFormats.Any(format=>format.Name == dataFormat.Name))
            {
                _context.DataFormats.Add(dataFormat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DataFormat>> GetDataFormats()
        {
            return await _context.DataFormats.ToListAsync();
        }

        public async Task UpdateDataFormat(DataFormat dataFormat)
        {
            _context.Update(dataFormat);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveDataFormat(int dataFormatId)
        {
            _context.DataFormats.Remove(_context.DataFormats.First(df => df.DataFormatId == dataFormatId));
            await _context.SaveChangesAsync();
        }

        public async Task AddContractConfig(ContractConfig contractConfig)
        {
            if (_context.DataFormats.Any(df=>df.DataFormatId == contractConfig.DataFormatId))
            {
                _context.Update(contractConfig);
                await _context.SaveChangesAsync();
            }
            else
            {
                 _context.Add(contractConfig);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ContractConfig>> ReadContractConfigs()
        {
            return await _context.contractConfigs
                .Include(x=>x.DataFormat)
                .Take(_config.GetValue<int>("DisplayedRowList"))
                .ToListAsync();
        }

        public async Task UpdateContractConfig(ContractConfig contractConfig)
        {
            _context.Update(contractConfig);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContractConfig(int contractConfigId)
        {
            _context.contractConfigs.Remove(_context.contractConfigs.First(contConfig => contConfig.ContractConfigId == contractConfigId));
            await _context.SaveChangesAsync();
        }

        public async Task<List<ContractConfig>> GetFilteredConfigList(ContractConfigSearchCM contractConficSearchCM)
        {
            var configList = await _context.contractConfigs.Include(x => x.DataFormat).ToListAsync();

            configList = FilterCode(configList, contractConficSearchCM.Code);
            configList = FilterContractId(configList, contractConficSearchCM.ContractId);
            configList = FilterDescription(configList, contractConficSearchCM.Description);
            configList = FilterDataFormatId(configList, contractConficSearchCM.DataFormatId);

            return configList;
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
