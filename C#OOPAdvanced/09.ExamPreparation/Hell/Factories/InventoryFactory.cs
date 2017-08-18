public class InventoryFactory
{
    public IInventory Create()
    {
        return new HeroInventory();
    }
}