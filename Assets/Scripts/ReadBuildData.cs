using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class ReadBuildData : MonoBehaviour
{
    BuildableObjectsData[][] buildableObjectsData;
    void ReadData()
    {
        string ReadString;
        string filePath = Application.dataPath + "/json/BuildResourcesData.json";
        try
        {
            ReadString = File.ReadAllText(filePath);
        }
        catch
        {
            Debug.LogError("json 파일 오류");
            ReadString = default;
        }

        buildableObjectsData = JsonConvert.DeserializeObject<BuildableObjectsData[][]>(ReadString);
    }

    public BuildableObjectsData[][] GetReadData()
    {
        ReadData();
        return buildableObjectsData;
    }
}
