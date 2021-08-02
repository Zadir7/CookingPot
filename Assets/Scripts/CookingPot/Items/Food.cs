using UnityEngine;

namespace CookingPot.Items
{
    public class Food : Edible
    {
        [SerializeField] 
        [Range(1, 10)]
        [Tooltip("Количество здоровья, восстанавливаемое едой")]
        private float healthAmount;
        
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