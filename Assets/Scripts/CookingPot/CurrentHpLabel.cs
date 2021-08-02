using CookingPot.Update;
using UnityEngine;
using UnityEngine.UI;

namespace CookingPot
{
    internal sealed class CurrentHpLabel
    {
        private const string CurrentHp = "Текущее здоровье";
        private readonly Text _currentHpLabel;
        private readonly PlayerController _playerController;

        public CurrentHpLabel(GameObject currentHpVisual, PlayerController playerController)
        {
            _playerController = playerController;
            _currentHpLabel = currentHpVisual.GetComponent<Text>();
            _currentHpLabel.color = Color.red;
            playerController.OnHealthDrain += ChangeLabel;
        }

        private void ChangeLabel()
        {
            _currentHpLabel.text = $"{CurrentHp}: {_playerController.CurrentHealth:000}";
        }

        internal void Disable()
        {
            _currentHpLabel.enabled = false;
            _playerController.OnHealthDrain -= ChangeLabel;
        }
    }
}