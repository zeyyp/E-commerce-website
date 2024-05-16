
namespace shopping.web.Models;


public class Basket // alısveriş sepetinin tamamı
{
    public List<BasketLine> Items {get;set;} =new List<BasketLine>();



    public void AddProduct(Product p,int adet)
    {
        
        var line = Items.Where(i=>i.urun.Id == p.Id).FirstOrDefault();

        if(line==null)//sepete daha once eklenmemıs.
        {
            Items.Add(new BasketLine(){urun = p, Adet=adet});
             Console.WriteLine("Ürün sepete eklendi.");

        }
        else
        {
            line.Adet += adet;
            Console.WriteLine("Ürün miktarı güncellendi.");
        }
    }

    public void RemoveProduct(Product p)
    {
        Items.RemoveAll(i=>i.urun.Id ==p.Id);
    }

    public decimal TotalPrice()
    {
       return Items.Sum(i => i.urun.price * i.Adet);
    }

}

public class BasketLine  // alısveriş sepetımızın her bır satırı urunler
{
    public int BasketLineId {get; set;}
    public Product? urun { get; set; } 
    public int Adet { get; set; } 

}