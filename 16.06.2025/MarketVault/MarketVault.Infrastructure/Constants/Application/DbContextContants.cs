namespace MarketVault.Infrastructure.Constants.Application
{
    public static class DbContextContants
    {
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=MarketVault; " +
            "Integrated Security = True; Connect Timeout = 30; Encrypt = True; " +
                "Trust Server Certificate=False; Application Intent = ReadWrite; Multi Subnet Failover=False";
    }
}
