using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SimpleBlurEffect : MonoBehaviour {

    public Material EffectMaterial;
    public int Iteration;
    public int DownSacle;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (EffectMaterial != null)
        {
            int height = source.width >> DownSacle;
            int width = source.height >> DownSacle;

            RenderTexture rt = RenderTexture.GetTemporary(width, height);
            Graphics.Blit(source, rt);

            for(int i=0;i<Iteration;i++)
            {
                RenderTexture rt2 = RenderTexture.GetTemporary(width, height);
                Graphics.Blit(rt, rt2, EffectMaterial);
                RenderTexture.ReleaseTemporary(rt);
                rt = rt2;
            }

            Graphics.Blit(rt, destination);
            RenderTexture.ReleaseTemporary(rt);
        }
    }
}
