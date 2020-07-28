using Microsoft.Extensions.Logging;
using System;

namespace JasperTestService
{
    public class ItemCreatedHandler
    {
        private readonly ILogger _logger;
        public ItemCreatedHandler(ILogger logger) => _logger = logger;

        public void Handle(ItemCreated itemCreated)
        {
            _logger.LogInformation("Item createed with id {Id}", itemCreated.Id);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Item created with id {itemCreated.Id}");
            Console.ResetColor();
        }
    }
}
