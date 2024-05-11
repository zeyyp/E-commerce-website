
namespace shopping.web.Models;


public class Basket // alısveriş sepetinin tamamı
{
    private List<BasketLine> _basketLines =new List<BasketLine>();

    public List<BasketLine> BasketLine
    {
        get { return _basketLines; }
    }


    public void AddProduct(Product p,int adet)
    {
        var line = _basketLines.Where(i=>i.urun.Id == p.Id).FirstOrDefault();

        if(line==null)
        {
            _basketLines.Add(new BasketLine(){urun = p, Adet=adet});
        }
        else
        {
            line.Adet += adet;
        }
    }

    public void RemoveProduct(Product p)
    {
        _basketLines.RemoveAll(i=>i.urun.Id ==p.Id);
    }

    public decimal TotalPrice()
    {
       return _basketLines.Sum(i => i.urun.price * i.Adet);
    }

}

public class BasketLine  // alısveriş sepetımızın her bır satırı urunler
{
    public Product? urun { get; set; } 
    public int Adet { get; set; } 

}