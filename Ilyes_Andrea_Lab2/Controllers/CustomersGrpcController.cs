using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using GrpcCustomersService;
using ModelAccess = Ilyes_Andrea_Lab2.Models;

namespace Ilyes_Andrea_Lab2.Controllers
{
    public class CustomersGrpcController : Controller
    {
        private readonly GrpcChannel channel;
        public CustomersGrpcController()
        {
            //a se modifica portul corespunzator (vezi in proiectul GrpcCustomerService->Properties->launchSettings.json)
            channel = GrpcChannel.ForAddress("https://localhost:7279");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            CustomerList cust = client.GetAll(new Empty());
            return View(cust);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new CustomerService.CustomerServiceClient(channel);
                var createdCustomer = client.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new CustomerService.CustomerServiceClient(channel);
            Customer customer = client.Get(new CustomerId() { Id = (int)id });
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = new CustomerService.CustomerServiceClient(channel);
            Empty response = client.Delete(new CustomerId()
            {
                Id = id
            });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = new CustomerService.CustomerServiceClient(channel);
            Customer customer = client.Get(new CustomerId { Id = (int)id });

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var client = new CustomerService.CustomerServiceClient(channel);
                client.Update(customer);
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

    }
}
