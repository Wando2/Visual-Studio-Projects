public class Career
{
    Career()
    {
        Items = new List<CareerItem>();
    }
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<CareerItem> Items { get; set; }

}