# Arabic Text Display Support

Arabic text display plugin(ArabicTool.dll, targets .NET 3.5) and Unity editor tool(ArabicTextMenu.cs, targets .NET 3.5)

How to use ?

The first method:
step 1. Create a Text of UGUI.
step 2. Use the SetText(str) method to set the arabic text.
You can do it like follow code:

// Use Text of UGUI
GameObject textObject2 = GameObject.Find("Text");
if (textObject2)
{
    Text text2 = textObject2.GetComponent<Text>();
    text2.SetText("ذات مرة كانت هناك ملكة.كانت تجلس عند النافذة.هناك الثلوج خارج في الحديقة -- <size=20><color=#00FF00>الثلج على تلة في الممر، والثلوج على الأكواخ وعلى الأشجار</color></size>: <color=#FF3030><b>كل شيء مع الثلج الأبيض.</b></color>\n\n<i>لديها بعض الملابس في يدها إبرة.القماش في يدها بيضاء مثل الثلج.</i>\n\nالملكة كانت تقديم معطف الطفل الصغير.قالت \"<i><color=#40E0D0>أريد لطفلي أن يكون أبيض مثل هذا القماش أبيض مثل الثلج.وسأعطي الكلمة لها بياض الثلج </color></i>\".\n\nبعد بضعة أيام أن الملكة قد الطفل.كان الطفل أبيض مثل الثلج.دعا لها الملكة سنو وايت.\n\n<color=#EE00EE>ولكن الملكة كان مريضا جدا، وبعد أيام قليلة توفيت.سنو وايت عاش، و كانت سعيدة جدا و الطفل الجميل.</color>\n\nسنة واحدة بعد ذلك تزوج الملك من ملكة أخرى.الملكة الجديدة كانت جميلة جدا، لكنها ليست امرأة طيبة.");
}

The second method:
step 1. Use the menu GameObject -> UI -> SeniorText to create a text component.
step 2. Set the arabic string to the text field of SeniorText.
You can do it like follow code:

// Use SeniorText of plugin
GameObject textObject1 = GameObject.Find("SeniorText");
if(textObject1)
{
    SeniorText text1 = textObject1.GetComponent<SeniorText>();
    text1.text = "ذات مرة كانت هناك ملكة.كانت تجلس عند النافذة.هناك الثلوج خارج في الحديقة -- <size=20><color=#00FF00>الثلج على تلة في الممر، والثلوج على الأكواخ وعلى الأشجار</color></size>: <color=#FF3030><b>كل شيء مع الثلج الأبيض.</b></color>\n\n<i>لديها بعض الملابس في يدها إبرة.القماش في يدها بيضاء مثل الثلج.</i>\n\nالملكة كانت تقديم معطف الطفل الصغير.قالت \"<i><color=#40E0D0>أريد لطفلي أن يكون أبيض مثل هذا القماش أبيض مثل الثلج.وسأعطي الكلمة لها بياض الثلج </color></i>\".\n\nبعد بضعة أيام أن الملكة قد الطفل.كان الطفل أبيض مثل الثلج.دعا لها الملكة سنو وايت.\n\n<color=#EE00EE>ولكن الملكة كان مريضا جدا، وبعد أيام قليلة توفيت.سنو وايت عاش، و كانت سعيدة جدا و الطفل الجميل.</color>\n\nسنة واحدة بعد ذلك تزوج الملك من ملكة أخرى.الملكة الجديدة كانت جميلة جدا، لكنها ليست امرأة طيبة.";
}


The ArabicToolDemo.unity and ArabicToolDemo.cs is for demo.
