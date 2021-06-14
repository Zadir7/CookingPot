using CookingPot.Update;
using UnityEngine;
using UnityEngine.UI;

namespace CookingPot
{
    internal sealed class CurrentHpLabel : IUpdatable
    {
        private const string CurrentHp = "Текущее здоровье";
        private readonly Text _currentHpLabel;
        private readonly IHealth _playerHealth;

        public CurrentHpLabel(GameObject currentHpVisual, IHealth playerHealth)
        {
            _playerHealth = playerHealth;
            _currentHpLabel = currentHpVisual.GetComponent<Text>();
            _currentHpLabel.color = Color.red;
            UpdaterStatic.AddToUpdatables(this);
        }

        public void Update()
        {
            _currentHpLabel.text = $"{CurrentHp}: {_playerHealth.CurrentHealth:000}";
        }

        internal void Disable()
        {
            _currentHpLabel.enabled = false;
        }
    }
}