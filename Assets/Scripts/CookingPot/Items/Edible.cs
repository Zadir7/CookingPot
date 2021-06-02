namespace CookingPot.Items
{
    public abstract class Edible : Item
    {
        public abstract float HealthAmount { get; set; }
        public abstract void Use(IHealth health);
    }
}