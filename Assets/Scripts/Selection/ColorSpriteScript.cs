using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Selection
{
    public class ColorSpriteScript : MonoBehaviour
    {
        public static ColorGameManager gameManager;
        private static RawImage indicatorRi;
        private RawImage ri;

        public static AudioSource correctAS;
        public static AudioSource wrongAS;

        void Start()
        {
            indicatorRi = gameManager.indicatorObj.GetComponent<RawImage>();
            ri = this.gameObject.GetComponent<RawImage>();
        }

        public void OnClick()
        {
            if (ri.color == indicatorRi.color)
            {
                correctAS.PlayOneShot(correctAS.clip);
                StartCoroutine(NextLevel(correctAS));
                Debug.Log("They match!");
            }
            else
            {
                // Already won
                if (correctAS.isPlaying) return;
                wrongAS.PlayOneShot(wrongAS.clip);
                Debug.Log("They dont match!");
            }
        }

        public IEnumerator NextLevel(AudioSource audioS)
        {
            yield return new WaitWhile(() => audioS.isPlaying);
            gameManager.LevelUp();
        }
    }
}