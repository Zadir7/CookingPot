using UnityEngine;

namespace CookingPot.Items
{
    public class Food : Edible
    {
        [SerializeField] private float healthAmount;
        public override float HealthAmount 
        { 
            get => healthAmount;
            set => healthAmount = value;
        }
        
        public override void Use(IHealth health)
        {
            health?.RestoreHealth(HealthAmount);
            Destroy(gameObject);
        }
    }
}