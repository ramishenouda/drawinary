using ArabicTool;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public string ArabicText;
    public string EnglishText;

    [SerializeField]
    SeniorText seniorText;

    [SerializeField]
    Text text;

    void Start() 
    {
        seniorText.text = ArabicText;
        text.text = EnglishText;
    }

    public void SetArabicText() 
    {
        seniorText.gameObject.SetActive(true);
        text.gameObject.SetActive(false);
    }

    public void SetEnglishText()
    {
        text.gameObject.SetActive(true);
        seniorText.gameObject.SetActive(false);
    }
}
