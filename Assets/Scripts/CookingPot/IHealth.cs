namespace CookingPot
{
    public interface IHealth
    {
        float MaxHealth { get; set; }
        float CurrentHealth { get; set; }

        void RestoreHealth(float amount);
    }
}