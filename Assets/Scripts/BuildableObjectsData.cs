public class BuildableObjectsData
{
    //필요한 자원, 양
    public string[] ResourcesName { get; private set; }
    public int[] ResourcesCount { get; private set; }

    public BuildableObjectsData(string[] resourcesName, int[] resourcesCount)
    {
        ResourcesName = resourcesName; ResourcesCount = resourcesCount;
    }
}
