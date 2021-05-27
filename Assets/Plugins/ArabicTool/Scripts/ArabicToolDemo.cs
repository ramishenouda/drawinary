using UnityEngine;
using UnityEngine.UI;
using ArabicTool;
using System.Text;

public class ArabicToolDemo : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        TestArabText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TestArabText()
    {
        //Debug.LogError("TestArabText");

        // Use SeniorText of plugin
        GameObject textObject1 = GameObject.Find("SeniorText");
        if(textObject1)
        {
            SeniorText text1 = textObject1.GetComponent<SeniorText>();
            text1.text = "";
            text1.text = null;

            text1.text = "ذات مرة كانت هناك ملكة.كانت تجلس عند النافذة.هناك الثلوج خارج في الحديقة -- <size=20><color=#00FF00>الثلج على تلة في الممر، والثلوج على الأكواخ وعلى الأشجار</color></size>: <color=#FF3030><b>كل شيء مع الثلج الأبيض.</b></color>\n\n<i>لديها بعض الملابس في يدها إبرة.القماش في يدها بيضاء مثل الثلج.</i>\n\nالملكة كانت تقديم معطف الطفل الصغير.قالت \"<i><color=#40E0D0>أريد لطفلي أن يكون أبيض مثل هذا القماش أبيض مثل الثلج.وسأعطي الكلمة لها بياض الثلج </color></i>\".\n\nبعد بضعة أيام أن الملكة قد الطفل.كان الطفل أبيض مثل الثلج.دعا لها الملكة سنو وايت.\n\n<color=#EE00EE>ولكن الملكة كان مريضا جدا، وبعد أيام قليلة توفيت.سنو وايت عاش، و كانت سعيدة جدا و الطفل الجميل.</color>\n\nسنة واحدة بعد ذلك تزوج الملك من ملكة أخرى.الملكة الجديدة كانت جميلة جدا، لكنها ليست امرأة طيبة.";

        }

        string co = ArabicTool.ArabicTextTool.Convert("");
        string rstr = ArabicTool.ArabicTextTool.ReverseOnly(co);

    }

}
