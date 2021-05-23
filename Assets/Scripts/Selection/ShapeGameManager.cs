using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Selection
{
    public class ShapeGameManager : MonoBehaviour
    {
        public int levels = 5;
        private GameObject[] objects;
        public GameObject indicatorObj;

        private Texture2D[] texs;

        public void BuildLevel()
        {
            System.Random rand = new System.Random();

            var lvlTexs = texs.OrderBy(t => rand.Next()).Skip(levels).ToArray();

            objects = new GameObject[lvlTexs.Length];

            // Creating shape objects
            for (int i = 0; i < objects.Length; ++i)
            {
                objects[i] = Instantiate(Resources.Load("Selection/ShapeSprite"), this.transform) as GameObject;

                // Changing sprite color
                RawImage objRi = objects[i].GetComponent<RawImage>();
                objRi.texture = lvlTexs[i];

            }

            // Creating shape indicator object
            indicatorObj = Instantiate(Resources.Load("Selection/ShapeSprite"), this.transform.parent.transform) as GameObject;

            // Removing script from indicator object
            ShapeSpriteScript spriteScript = indicatorObj.GetComponent<ShapeSpriteScript>();
            Destroy(spriteScript);

            RectTransform indicatorRectTransform = indicatorObj.GetComponent<RectTransform>();
            indicatorRectTransform.anchoredPosition = new Vector3(0.0f, -40.0f, 0.0f);

            // Displaying below
            RawImage indicatorRi = indicatorObj.GetComponent<RawImage>();

            // Selecting a random color
            int index = rand.Next(0, lvlTexs.Length);
            indicatorRi.texture = lvlTexs[index];

        }

        void Start()
        {
            texs = new Texture2D[]{
                Resources.Load("Selection/Circle") as Texture2D,
                Resources.Load("Selection/Square") as Texture2D,
                Resources.Load("Selection/Capsule") as Texture2D,
                Resources.Load("Selection/HexagonFlat-Top") as Texture2D,
                Resources.Load("Selection/HexagonPointed-Top") as Texture2D,
                Resources.Load("Selection/IsometricDiamond") as Texture2D,
            };
            BuildLevel();
            ShapeSpriteScript.gameManager = this;
        }

        public void LevelUp()
        {
            if (levels <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }

            // Destroying previous objects
            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }
            Destroy(indicatorObj);

            --levels;
            BuildLevel();
        }
    }
}



