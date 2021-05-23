using UnityEngine;
using UnityEngine.UI;

namespace Selection
{
    public class ShapeSpriteScript : MonoBehaviour
    {
        public static ShapeGameManager gameManager;
        private static RawImage indicatorRi;
        private RawImage ri;

        void Start()
        {
            indicatorRi = gameManager.indicatorObj.GetComponent<RawImage>();
            ri = this.gameObject.GetComponent<RawImage>();
        }

        public void OnClick()
        {
            if (ri.texture == indicatorRi.texture)
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