using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowReplacement : MonoBehaviour {
    RenderTexture _Rt;
    public Material EffectMaterial;
    // Use this for initialization
    void Start () {
        _Rt = new RenderTexture(Screen.width, Screen.height, 24);
        Camera camera = GetComponent<Camera>();
        var glowShader = Shader.Find("Glow/GlowReplace");
        camera.targetTexture = _Rt;
        camera.SetReplacementShader(glowShader, "Glowable");
        Shader.SetGlobalTexture("_GlowPrePassTex", _Rt);
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (EffectMaterial != null)
        {
            RenderTexture _Blurred = RenderTexture.GetTemporary(_Rt.width, _Rt.height); ;
            Graphics.Blit(_Rt, _Blurred);

            Graphics.Blit(source,destination);

            Graphics.SetRenderTarget(_Blurred);
            GL.Clear(false, true, Color.clear);

            Graphics.Blit(source, _Blurred);

            for (int i = 0; i < 4; i++)
            {
                RenderTexture rt2 = RenderTexture.GetTemporary(_Blurred.width, _Blurred.height);
                Graphics.Blit(_Blurred, rt2, EffectMaterial);
                RenderTexture.ReleaseTemporary(_Blurred);
                _Blurred = rt2;
            }

            Shader.SetGlobalTexture("_GlowBlurredTex", _Blurred);
            RenderTexture.ReleaseTemporary(_Blurred);
        }
    }
}
