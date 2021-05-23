using UnityEngine;
using UnityEngine.UI;

namespace Selection
{
    public class ColorSpriteScript : MonoBehaviour
    {
        public static ColorGameManager gameManager;
        private static RawImage indicatorRi;
        private RawImage ri;

        void Start()
        {
            indicatorRi = gameManager.indicatorObj.GetComponent<RawImage>();
            ri = this.gameObject.GetComponent<RawImage>();
        }

        public void OnClick()
        {
            if (ri.color == indicatorRi.color)
            {
                gameManager.LevelUp();
                Debug.Log("They match!");
            }
            else
            {
                Debug.Log("They dont match!");
            }
        }
    }
}