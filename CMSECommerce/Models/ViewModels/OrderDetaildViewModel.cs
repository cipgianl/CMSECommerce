namespace CMSECommerce.Models.ViewModels;

public class OrderDetaildViewModel
{
    public Order Order { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}
