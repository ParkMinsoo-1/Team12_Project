public class BuildableObjectsData
{
    //�ʿ��� �ڿ�, ��
    public string[] ResourcesName { get; private set; }
    public int[] ResourcesCount { get; private set; }

    public BuildableObjectsData(string[] resourcesName, int[] resourcesCount)
    {
        ResourcesName = resourcesName; ResourcesCount = resourcesCount;
    }
}
