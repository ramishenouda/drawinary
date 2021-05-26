using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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

            GameObject correctAudioSourceObj = Instantiate(Resources.Load("Selection/CorrectAudioSource"), this.transform) as GameObject;
            GameObject wrongAudioSourceObj = Instantiate(Resources.Load("Selection/WrongAudioSource"), this.transform) as GameObject;

            ColorSpriteScript.gameManager = this;
            ColorSpriteScript.wrongAS = wrongAudioSourceObj.GetComponent<AudioSource>();
            ColorSpriteScript.correctAS = correctAudioSourceObj.GetComponent<AudioSource>();
        }

        public void LevelUp()
        {
            // Destroying previous objects
            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }
            Destroy(indicatorObj);

            if (levels <= 0)
            {
                StartCoroutine("GameDone");
                return;
            }

            --levels;
            BuildLevel();
        }

        public IEnumerator GameDone()
        {
            // Remove indicatorText
            Destroy(GameObject.FindGameObjectWithTag("IndicatorText"));

            // Display congratulationsText & Button
            GameObject congratulationsTextObj = Instantiate(Resources.Load("Selection/CongratulationsText"), this.transform.parent.transform) as GameObject;
            GameObject nextSceneButtonObj = Instantiate(Resources.Load("Selection/NextSceneButton"), this.transform.parent.transform) as GameObject;

            GameObject congratulationsAudioSourceObj = Instantiate(Resources.Load("Selection/CongratulationsAudioSource"), congratulationsTextObj.transform) as GameObject;
            AudioSource congratulationsAudioSource = congratulationsAudioSourceObj.GetComponent<AudioSource>();
            Button btn = nextSceneButtonObj.GetComponent<Button>();

            // Disabling button until congratulations sound effect is played
            btn.interactable = false;
            congratulationsAudioSource.PlayOneShot(congratulationsAudioSource.clip);
            yield return new WaitWhile(() => congratulationsAudioSource.isPlaying);
            btn.interactable = true;
        }
    }
}



