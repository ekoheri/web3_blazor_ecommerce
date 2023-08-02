namespace BlazorApp.Data;

public class BooksBasket
{
    public List<BookInBasket> Basket {get; set;}
    public event Action? OnBasketChange;
    public BooksBasket()
    {
        if(Basket == null)
            Basket = new List<BookInBasket>();
    }
    public void AddValue(BookInBasket value)
    {
        Basket.Add(value);
        NotifyStateChange();
    }
    public void RemoveValue(string value)
    {
        Basket.RemoveAt(
            Basket.FindIndex(i => i.Id_Basket == value)
        );
        NotifyStateChange();
    }
    private void NotifyStateChange()=>OnBasketChange?.Invoke();
}