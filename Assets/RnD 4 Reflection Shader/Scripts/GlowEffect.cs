using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public Material CompositeMaterial;
    public float Intensity = 1;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        CompositeMaterial.SetFloat("Intensity", Intensity);
        Graphics.Blit(source, destination, CompositeMaterial, 0);
    }
}
