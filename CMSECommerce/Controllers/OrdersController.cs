using CMSECommerce.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMSECommerce.Controllers;
public class OrdersController(DataContext context, SignInManager<IdentityUser> signInManger): Controller
{
    private readonly DataContext _context = context;
    private readonly SignInManager<IdentityUser> _signInManger = signInManger;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        // Recupero il carrello dalla sessione
        List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

        Order order = new Order
        {
            UserName = User.Identity.Name,
            GrandTotal = cart.Sum(x => x.Price * x.Quantity)
        };

        _context.Add(order);
        await _context.SaveChangesAsync();

        int id = order.Id;
        foreach (var item in cart)
        {
            OrderDetail orderDetail = new()
            {
                OrderId = id,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                Price = item.Price,
                Image = item.Image
            };
            _context.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        // Rimuovo il carrello
        HttpContext.Session.Remove("Cart");

        return RedirectToAction("Index");
    }
}
