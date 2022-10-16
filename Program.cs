
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

ECommerceDbContext dbContext = new();

Customer customer = new()
{
    FirstName = "Eda",
    LastName = "Turk"
};
Customer customer1 = new()
{
    FirstName = "Eda1",
    LastName = "Turk"
};
Customer customer2 = new()
{
    FirstName = "Eda2",
    LastName = "Turk"
};
Customer customer3 = new()
{
    FirstName = "Eda3",
    LastName = "Turk"
};


#region Add-Update-Delete(crud)
//await dbContext.Customers.AddAsync(customer);
//dbContext.Customers.AddRangeAsync(customer1, customer2, customer3); //birden fazla veri yolladık


//await dbContext.SaveChangesAsync();
//var customerList =  await dbContext.Customers.ToListAsync();
//foreach (var customerss in customerList)
//{
//    customerss.LastName += "A-guncelleme";//TUM VERILER ICIN GUNCELLEME

//}
//await dbContext.SaveChangesAsync();

// Customer customerFind= await dbContext.Customers.FirstOrDefaultAsync(u => u.Id == 3);
//customerFind.FirstName = "Adoo_Changed";

//await dbContext.SaveChangesAsync();
#endregion


#region Method Syntax(query)
//var kisiler = await dbContext.Customers.ToListAsync();
//foreach (var kisi in kisiler)
//{
//    Console.WriteLine(kisi.FirstName);
//}

#endregion
#region Query Syntax(query)
//var kisiler2 = await (from kisi in dbContext.Customers
//                      select kisiler).ToListAsync();

#endregion
#region  IQueryable ve IEnumaerable nedir? nasıl execute edilir?(query)

//IQueryable sorguya karsılık gelir
//EF core uzerinden yapılmıs olan sorgunun execute edilmemiş halidir.
//IEnumerable ise sorgunun calıstırılıp execute edilmis halini ifade eder.
//IEnumerable bellekteki veriyi temsil etmektedir(genel olarak)
//sorguyu execute etmek icin ToListAsync fonksiyonu kullanırız.

#endregion
#region Deferred Execution(Ertelenmis calısma)(query)

//IQueryable calısmalarında ilgili kod yazıldıgı noktada tetiklenmez/calıstırılmaz yani ilgili kod yazıldıgı yerde sorguyu generate etmez.Nerede eder?execute edildigi yerde

//int urunId = 5;

//var urunler = from urun in dbContext.Products
//              where urun.Id == urunId
//              select urun;



//urunId = 200;

//foreach (var urun in urunler)
//{
//    Console.WriteLine(urun.Name);
//}

//bu yapılan sorguda query alanı bekler bundan dolayı ıd 5 degil 200 alınır.!!!!!!

#endregion


#region Çoğul Veri Getiren Sorgulama  Fonksiyonları(query)

#region ToListAsync
//uretilen sorguyu execute ettirmemizi saglayan fonksiyondur.
//var urunler = dbContext.Customers.ToListAsync();
#endregion
#region Where
//olusturulan sorguya where sartı eklememize yarayan fonksiyondur.
//var urunler = await  dbContext.Products.Where(u => u.Id > 500).ToListAsync(); // tolistasync diyerek execute yaptırırız

#endregion
#region OrderBy
//sorgu uzerinde sıralama yapmamızı saglayan bir fonksiyondur.
//var urunler = dbContext.Products.Where(u => u.Id > 500 || u.Name.EndsWith("2")).OrderBy(u => u.Name);
#endregion
#endregion

#region Tekil Veri Getiren Sorgulama Fonksiyonları(query)
#region SingleAsync
//yapılan sorguda sadece tek bir verinin gelmesini istiyorsak single ya da  SingleOrDefault fonksiyonlarını kullanırız.
//single ile birden fazla veri geri gelebiliyor olsaydı bu fonksiyon hata verirdi.
#endregion

#region SingleOrDefaultAsync
//yapılan sorguda sadece tek bir verinin gelmesini istiyorsak single ya da  singleordefault fonksiyonlarını kullanırız.
//single ile birden fazla veri geri gelebiliyor olsaydı bu fonksiyon hata vermezdi.
//Bundan dolayı OrDefaultlu olanı kullanmak daha mantıklıdır.
//var urun = dbContext.Products.SingleOrDefaultAsync(u => u.Id == 22);

#endregion

#region FirstOrDefault
//elimizde coklu veri olabilir ancak bize elde edilen verilerden ilkini getirir.tek bir veri getirir.
//var urun = await dbContext.Products.FirstOrDefaultAsync(u => u.Id==25);

#endregion
#region FindAsync
//find fonksiyonu yalnızca pimary key alanlarını sorgular
//find fonksiyonu primary key kolonuna ozeldir.hızlı bir sekilde sorgulama yapmamızı saglayan bir fonksiyondur
//var urun = await dbContext.Products.FindAsync(11); // direkt olarak kolayca arama yapmamızı saglar 

#endregion
#region

#endregion
#region

#endregion


#endregion

#region Diğer Sorgulama Fonksiyonları
#region CountAsync
//Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(int) bizlere bildiren fonksiyondur.
//var urunler = (await context.Urunler.ToListAsync()).Count();
//var urunler = await context.Urunler.CountAsync();
#endregion

#region LongCountAsync
//Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(long) bizlere bildiren fonksiyondur.
//var urunler = await context.Urunler.LongCountAsync(u => u.Fiyat > 5000);
#endregion

#region AnyAsync
//Sorgu neticesinde verinin gelip gelmediğini bool türünde dönen fonksiyondur. 
//var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("1")).AnyAsync();
//var urunler = await context.Urunler.AnyAsync(u => u.UrunAdi.Contains("1"));
#endregion

#region MaxAsync
//Verilen kolondaki max değeri getirir.
//var fiyat = await context.Urunler.MaxAsync(u => u.Fiyat);
#endregion

#region MinAsync
//Verilen kolondaki min değeri getirir.
//var fiyat = await context.Urunler.MinAsync(u => u.Fiyat);
#endregion

#region Distinct
//Sorguda mükerrer kayıtlar varsa bunları tekilleştiren bir işleve sahip fonksiyondur.
//var urunler = await context.Urunler.Distinct().ToListAsync();
#endregion

#region AllAsync
//Bir sorgu neticesinde gelen verilerin, verilen şarta uyup uymadığını kontrol etmektedir. Eğer ki tüm veriler şarta uyuyorsa true, uymuyorsa false döndürecektir.
//var m = await context.Urunler.AllAsync(u => u.Fiyat < 15000);
//var m = await context.Urunler.AllAsync(u => u.UrunAdi.Contains("a"));
#endregion

#region SumAsync
//Vermiş olduğumuz sayısal proeprtynin toplamını alır.
//var fiyatToplam = await context.Urunler.SumAsync(u => u.Fiyat);
#endregion

#region AverageAsync
//Vermiş olduğumuz sayısal proeprtynin aritmatik ortalamasını alır.
//var aritmatikOrtalama = await context.Urunler.AverageAsync(u => u.Fiyat);
#endregion

#region Contains
//Like '%...%' sorgusu oluşturmamızı sağlar.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("7")).ToListAsync();
#endregion

#region StartsWith
//Like '...%' sorgusu oluşturmamızı sağlar.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.StartsWith("7")).ToListAsync();
#endregion

#region EndsWith
//Like '%...' sorgusu oluşturmamızı sağlar.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.EndsWith("7")).ToListAsync();
#endregion
#endregion


#region Sorgu Sonucu Dönüşüm Fonksiyonları
//Bu fonksiyonlar ile sorgu neticesinde elde edilen verileri isteğimiz doğrultuusnda farklı türlerde projecsiyon edebiliyoruz.

#region ToDictionaryAsync
//Sorgu neticesinde gelecek olan veriyi bir dictioanry olarak elde etmek/tutmak/karşılamak istiyorsak eğer kullanılır!
//var urunler = await context.Urunler.ToDictionaryAsync(u => u.UrunAdi, u => u.Fiyat);

//ToList ile aynı amaca hizmet etmektedir. Yani, oluşturulan sorguyu execute edip neticesini alırlar.
//ToList : Gelen sorgu neticesini entity türünde bir koleksiyona(List<TEntity>) dönüştürmekteyken,
//ToDictionary ise : Gelen sorgu neticesini Dictionary türünden bir koleksiyona dönüştürecektir.
#endregion

#region ToArrayAsync
//Oluşturulan sorguyu dizi olarak elde eder.
//ToList ile muadil amaca hizmet eder. Yani sorguyu execute eder lakin gelen sonucu entity dizisi  olarak elde eder.
//var urunler = await context.Urunler.ToArrayAsync();
#endregion

#region Select
//Select fonksiyonunun işlevsel olarak birden fazla davranışı söz konusudur,
//1. Select fonksiyonu, generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır. 

//var urunler = await context.Urunler.Select(u => new Urun
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();

//2. Select fonksiyonu, gelen verileri farklı türlerde karşılamamızı sağlar. T, anonim

//var urunler = await context.Urunler.Select(u => new 
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();


//var urunler = await context.Urunler.Select(u => new UrunDetay
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();

#endregion

#region SelectMany
//Select ile aynı amaca hizmet eder. Lakin, ilişkisel tablolar neticesinde gelen koleksiyonel verileri de tekilleştirip projeksiyon etmemizi sağlar.

//var urunler = await context.Urunler.Include(u => u.Parcalar).SelectMany(u => u.Parcalar, (u, p) => new
//{
//    u.Id,
//    u.Fiyat,
//    p.ParcaAdi
//}).ToListAsync();
#endregion
#endregion



#region GroupBy Fonksiyonu
//Gruplama yapmamızı sağlayan fonksiyondur.
#region Method Syntax
//var datas = await dbContext.Products.GroupBy(u => u.Price).Select(group => new
//{
//    Count = group.Count(),
//    Fiyat = group.Key
//}).ToListAsync();
#endregion
#region Query Syntax
//var datas = await (from urun in dbContext.Products
//                   group urun by urun.Price
//            into @group
//                   select new
//                   {
//                       Fiyat = @group.Key,
//                       Count = @group.Count()
//                   }).ToListAsync();
#endregion
#endregion

#region Foreach Fonksiyonu
//Bir sorgulama fonksiyonu değildir!
//Sorgulama neticesinde elde edilen koleksiyonel veriler üzerinde iterasyonel olarak dönmemizi ve teker teker verileri elde edip işlemler yapabilmemizi sağlayan bir fonksiyondur. foreach döngüsünün metot halidir!

//foreach (var item in datas)
//{

//}
//datas.ForEach(x =>
//{

//});
#endregion







public class ECommerceDbContext: DbContext
{
    public DbSet<Customer>Customers { get; set; }
    public DbSet<Product>Products{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=TURK\\SQLEXPRESS;Database=ECommerceDb; Trusted_Connection=True");
    }

}


public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
}