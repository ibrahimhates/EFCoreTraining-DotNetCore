using Microsoft.EntityFrameworkCore;
Console.WriteLine();

#region Veri Nasıl Silinir?

//ETicaretContext context = new();
//Urun urun = await context.Urunler.FirstOrDefaultAsync(x => x.Id == 3);
//context.Urunler.Remove(urun);
//await context.SaveChangesAsync();
#endregion
#region Silme İşleminde ChangeTracker'ın Rolü
//ChangeTracker, context üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır.
//Bu takip mekanizması sayesinde context üzerinden gelen verilerle ilgili işlemler-
//neticesinde update yahut delete sorgularının oluşturulacağı anlaşılır!
#endregion
#region Takip Edilmeyen Nesneler Nasıl Silinir?
//ETicaretContext context = new();
//Urun urun = new Urun()
//{
//    Id=5
//};
//context.Urunler.Remove(urun);
//await context.SaveChangesAsync();
#region EntityState İle Silme İşlemi
//ETicaretContext context = new ETicaretContext();
//Urun u = new() { Id = 1 };
//context.Entry(u).State = EntityState.Deleted;
//await context.SaveChangesAsync();
#endregion
#endregion
#region Birden Fazla Veri Silinirken Nelere Dikkat Edilmelidir?
#region SaveChanges'ı Verimli Kullanalım

#endregion
#region RemoveRange
ETicaretContext context = new();

//var urunler = await context.Urunler.Where(x => x.Id >= 4 && x.Id <= 8).ToListAsync();
//context.Urunler.RemoveRange(urunler);
//await context.SaveChangesAsync();

#endregion
#endregion


public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=ETicaretDB;User ID=SA;Password=Password1");
    }
}
public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }
}