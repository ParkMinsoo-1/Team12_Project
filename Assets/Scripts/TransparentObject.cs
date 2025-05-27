using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    public enum BlendMode
    {
        Opaque = 0,
        //Cutout,
        //Fade,
        Transparent
    }

    MeshRenderer meshRenderer;
    int iNum = -1;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (iNum == -1) return;

        iNum = 1;

        if(iNum == 1)
        {
            NoTransparent();
        }
    }

    public void BecomeTransparent()
    {
        iNum = 0;
        for(int i = 0; i < meshRenderer.materials.Length; i++)
        {            
            changeRenderMode(meshRenderer.materials[i], BlendMode.Transparent);
            meshRenderer.materials[i].color = new Color(meshRenderer.materials[i].color.r, meshRenderer.materials[i].color.g, meshRenderer.materials[i].color.b, 0);
        }
    }

    public void NoTransparent()
    {
        for (int i = 0; i < meshRenderer.materials.Length; i++)
        {
            meshRenderer.materials[i].color = new Color(meshRenderer.materials[i].color.r, meshRenderer.materials[i].color.g, meshRenderer.materials[i].color.b, 1);
            iNum = -1;
        }
    }

    public static void changeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                standardShaderMaterial.SetFloat("_Mode", 0.0f);
                standardShaderMaterial.SetOverrideTag("RenderType", "Opaque");
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                break;
            //case BlendMode.Cutout:
            //    standardShaderMaterial.SetFloat("_Mode", 1.0f);
            //    standardShaderMaterial.SetOverrideTag("RenderType", "Opaque");
            //    standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            //    standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            //    standardShaderMaterial.SetInt("_ZWrite", 1);
            //    standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
            //    standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
            //    standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            //    standardShaderMaterial.renderQueue = 2450;
            //    break;
            //case BlendMode.Fade:
            //    standardShaderMaterial.SetFloat("_Mode", 2.0f);
            //    standardShaderMaterial.SetOverrideTag("RenderType", "Transparent");
            //    standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            //    standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            //    standardShaderMaterial.SetInt("_ZWrite", 0);
            //    standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
            //    standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
            //    standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            //    standardShaderMaterial.renderQueue = 3000;
            //    break;
            case BlendMode.Transparent:
                standardShaderMaterial.SetFloat("_Mode", 3.0f);
                standardShaderMaterial.SetOverrideTag("RenderType", "Transparent");
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
        }
    }
}
