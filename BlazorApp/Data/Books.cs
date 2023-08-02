namespace BlazorApp.Data;
public class Books
{
    public string Id { get; set; } = "";
    public string Photo { get; set; } = "";
    public string Judul { get; set; } = "";
    public string Rating { get; set; } = "";
    public string Harga { get; set; } = "";
    public int Stock {get; set; } = 0;
    public int Jumlah_Basket {get; set;} = 0;
    public bool InBasket {get;set;} = false;
}

public class BookDetail
{
    public string Id {get; set; } = "";
    public string Photo {get; set; } = "";
    public string Judul {get; set; } = "";
    public string Deskripsi {get; set; } = "";
    public string Rating {get; set; } = "";
    public string Harga {get; set; } = "";
    public int Stock {get; set; } = 0;
}

public class BookInBasket
{
    public string Id_Basket {get; set;} = "";
    public string Judul_Basket {get; set;} = "";
    public string Harga_Basket {get; set;} = "";
    public int Jumlah_Basket {get; set;} = 0;
    public bool InBasket {get;set;} = false;
}

public class PostModel
{
    public string userName {get;set;} = "";
    public string passwd {get;set;} = "";
}

public class ResponseModel
{
    public bool status {get;set;} = false;
    public string user {get; set;} = "";
    public string token {get;set;} = "";
}