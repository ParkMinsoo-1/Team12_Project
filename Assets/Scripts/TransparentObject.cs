using UnityEngine;

public class TransparentObject : MonoBehaviour
{   
    MeshRenderer meshRenderer;
    int iNum;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        iNum = 1;

        if(iNum == 1)
        {
            NoTransparent();
        }
    }

    public void BecomeTransparent()
    {
        iNum = 0;
        meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, 0);
    }

    public void NoTransparent()
    {
        meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, 1);
    }
}
