using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Toggle English;
    public Toggle Arabic;

    public ButtonScript[] buttons;

    private void Start() 
    {
        setMenuLanguage();
    }

    void setMenuLanguage() 
    {
        if (English.isOn) 
            SetEnglishMenu(true);
        else 
            SetArabicMenu(true);
    }

    public void SetArabicMenu(bool value) 
    {
        if (!Arabic.isOn) 
            return;
        
        for(int i = 0; i < buttons.Length; i++)
            buttons[i].SetArabicText();
    }

    public void SetEnglishMenu(bool value) 
    {
        if (!English.isOn) 
            return;
        
        for(int i = 0; i < buttons.Length; i++)
            buttons[i].SetEnglishText();
    }
}
