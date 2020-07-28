using Jasper.Attributes;

namespace JasperTestService
{
    public class ItemHandler
    {
        private readonly ItemsDbContext _dbContext;

        public ItemHandler(ItemsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Transactional]
        public ItemCreated Handle(CreateItemCommand command)
        {
            var item = new Item { Name = command.Name };
            _dbContext.Items.Add(item);
            return new ItemCreated { Id = item.Id };
        }
    }
}
