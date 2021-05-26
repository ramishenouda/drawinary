using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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

                // Changing sprite texture
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

            // Selecting a random texture
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

            GameObject correctAudioSourceObj = Instantiate(Resources.Load("Selection/CorrectAudioSource"), this.transform) as GameObject;
            GameObject wrongAudioSourceObj = Instantiate(Resources.Load("Selection/WrongAudioSource"), this.transform) as GameObject;

            ShapeSpriteScript.gameManager = this;
            ShapeSpriteScript.wrongAS = wrongAudioSourceObj.GetComponent<AudioSource>();
            ShapeSpriteScript.correctAS = correctAudioSourceObj.GetComponent<AudioSource>();
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



