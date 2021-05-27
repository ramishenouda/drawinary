#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace ArabicTool
{
    public class ArabicTextMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        [MenuItem("GameObject/UI/SeniorText")]
        public static void CreateSeniorText()
        {
            Transform curSelectTransform = Selection.activeTransform;
            GameObject obj = new GameObject();
            SeniorText text = obj.AddComponent<SeniorText>();
            text.SetRawText("New Senior Text");

            string prefix = "SeniorText";
            string findName = prefix;

            if (curSelectTransform)
            {
                int i = 0;

                while (true)
                {
                    if (i > 0)
                    {
                        findName = string.Format(prefix + " ({0})", i);
                    }

                    if (curSelectTransform.Find(findName))
                    {
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                obj.transform.SetParent(curSelectTransform);
            }

            obj.name = findName;
            obj.transform.localPosition = Vector3.zero;
        }
    }
}
#endif