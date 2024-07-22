using CarShop.Data;
using CarShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Repositories;

public class BrandEfRepository : EfRepository<Brand>, IBrandRepository
{
    public BrandEfRepository(DbContext ctx) : base(ctx) { }
}
