using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

public class ReadBuildData : MonoBehaviour
{
    private static BuildableObjectsData[][] buildableObjectsData;
    public static BuildableObjectsData[][] BuildablObjectData 
    {
        get 
        { 
            if (buildableObjectsData == null) ReadData();
            return buildableObjectsData;
        }
    }

    static void ReadData()
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
