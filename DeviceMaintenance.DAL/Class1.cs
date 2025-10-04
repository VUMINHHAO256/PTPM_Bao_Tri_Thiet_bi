using DeviceMaintenance.DAL;
using DeviceMaintenance.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceMaintenance.BLL
{
    public class AssetService
    {
        private readonly AppDbContext _context;
        public AssetService(AppDbContext context) => _context = context;

        public async Task<List<Asset>> GetAll() => await _context.Assets.ToListAsync();
        public async Task<Asset?> GetById(int id) => await _context.Assets.FindAsync(id);
        public async Task<Asset> Add(Asset asset) { _context.Assets.Add(asset); await _context.SaveChangesAsync(); return asset; }
        public async Task Update(Asset asset) { _context.Assets.Update(asset); await _context.SaveChangesAsync(); }
        public async Task Delete(int id) { var a = await _context.Assets.FindAsync(id); if (a != null) { _context.Assets.Remove(a); await _context.SaveChangesAsync(); } }
    }
}
