using ArabicTool;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject registerMenu;

    [SerializeField]
    SeniorText ArabicLanguage;

    void Awake()
    {
        ArabicLanguage.text = "العربية";
    }

    public void ToggleMenus()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        registerMenu.SetActive(!registerMenu.activeSelf);
    }

    public void ColorButton() 
    {
        
    }

    public void ShapeButton()
    {

    }

    public void ExitButton()
    {
        
    }
}
