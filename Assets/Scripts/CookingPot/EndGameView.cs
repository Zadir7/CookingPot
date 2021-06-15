using UnityEngine;
using UnityEngine.UI;

namespace CookingPot
{
    internal sealed class EndGameView
    {
        private const string EndGameMessage = "К сожалению, вы не нашли достаточно еды, чтобы выжить...";
        private readonly Text _endGameLabel;

        public EndGameView(GameObject endGameVisual)
        {
            _endGameLabel = endGameVisual.GetComponent<Text>();
            _endGameLabel.color = Color.white;
            _endGameLabel.text = EndGameMessage;
        }
    }
}