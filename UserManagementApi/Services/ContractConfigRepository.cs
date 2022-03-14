using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public class ContractConfigRepository
    {
        public readonly DbConnect _context;

        public ContractConfigRepository(DbConnect context)
        {
            _context = context;
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
                //.Take(3)
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
    }
}
