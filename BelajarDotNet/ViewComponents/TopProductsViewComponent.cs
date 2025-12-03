using BelajarDotNet.Models;
using Microsoft.AspNetCore.Mvc;
namespace ViewComponentInMVC.ViewComponents
{
    public class TopProductsViewComponent : ViewComponent
    {
        //The Invoke method for the View component
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            // Your logic for preparing data
            ProductViewRepository productRepository = new ProductViewRepository();
            var products = await productRepository.GetTopProductsAsync(count);
            return View(products);
        }

        //public IViewComponentResult Invoke(int count)
        //{
        // // Your logic for preparing data
        // ProductRepository productRepository = new ProductRepository();
        // var products = productRepository.GetTopProductsAsync(count).Result;
        // return View(products);
        //}
    }
}