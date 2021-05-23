using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Selection
{
    public class ColorGameManager : MonoBehaviour
    {
        public int levels = 5;
        public Texture2D tex;
        private GameObject[] objects;
        public GameObject indicatorObj;

        public Color[] colors = { Color.black, Color.magenta, Color.cyan, Color.red, Color.green, Color.blue, };

        public void BuildLevel()
        {
            System.Random rand = new System.Random();

            var lvlColors = colors.OrderBy(c => rand.Next()).Skip(levels).ToArray();

            objects = new GameObject[lvlColors.Length];

            // Creating colored objects
            for (int i = 0; i < objects.Length; ++i)
            {
                objects[i] = Instantiate(Resources.Load("Selection/ColorSprite"), this.transform) as GameObject;

                // Changing sprite color
                RawImage objRi = objects[i].GetComponent<RawImage>();
                objRi.color = lvlColors[i];

            }

            // Creating colored indicator object
            indicatorObj = Instantiate(Resources.Load("Selection/ColorSprite"), this.transform.parent.transform) as GameObject;

            // Removing script from indicator object
            ColorSpriteScript spriteScript = indicatorObj.GetComponent<ColorSpriteScript>();
            Destroy(spriteScript);

            RectTransform indicatorRectTransform = indicatorObj.GetComponent<RectTransform>();
            indicatorRectTransform.anchoredPosition = new Vector3(0.0f, -40.0f, 0.0f);

            // Displaying below
            RawImage indicatorRi = indicatorObj.GetComponent<RawImage>();

            // Selecting a random color
            int index = rand.Next(0, lvlColors.Length);
            indicatorRi.color = lvlColors[index];

            // Coloring the indicator text
            GameObject indicatorTextObj = GameObject.FindGameObjectWithTag("IndicatorText");
            Text indicatorText = indicatorTextObj.GetComponent<Text>();
            indicatorText.color = lvlColors[index];
        }
        void Start()
        {
            BuildLevel();
            ColorSpriteScript.gameManager = this;
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



