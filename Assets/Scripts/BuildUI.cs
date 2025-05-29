//using System.Text;
//using TMPro;
//using UnityEngine;

//public class BuildUI : MonoBehaviour
//{
//    [SerializeField] BuildableObject buildableObject;
//    TextMeshProUGUI[] textUIs;
//    //private void Start()
//    //{
//    //    int BuildableObjCount = gameObject.transform.childCount;
//    //    StringBuilder stringBuilder = new StringBuilder();

//    //    for (int i = 0; i < BuildableObjCount; i++)
//    //    {
//    //        int level = buildableObject.level[i];
//    //        for (int j = 0; j < buildableObject.resourceData[i][level].ResourcesName.Length; j++)
//    //        {
//    //            stringBuilder.Append($"{buildableObject.resourceData[i][level].ResourcesName[j]} X {buildableObject.resourceData[i][level].ResourcesCount[j]}\n");
//    //        }
//    //        stringBuilder.Remove(stringBuilder.Length - 1, 1);

//    //        string buildText = level == 0 ? "Build" : "Upgrade";

//    //        textUIs = gameObject.transform.GetChild(i).GetComponentsInChildren<TextMeshProUGUI>();

//    //        textUIs[0].text = level.ToString();
//    //        textUIs[1].text = stringBuilder.ToString();
//    //        textUIs[2].text = buildText;
//    //    }
//    //}

//    public void BuildButton1()
//    {
//        buildableObject.Build(0);
//    }

//    public void BuildButton2()
//    {
//        buildableObject.Build(1);
//    }

//    public void BuildButton3()
//    {
//        buildableObject.Build(2);
//    }
//}
