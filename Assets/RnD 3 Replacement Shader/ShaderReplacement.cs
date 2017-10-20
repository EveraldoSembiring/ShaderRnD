using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderReplacement : MonoBehaviour {
    public Shader ReplacementShader;
    public Color _OverDrawColor;

    private void OnValidate()
    {
        Shader.SetGlobalColor("_OverDrawColor",_OverDrawColor);
    }

    void OnEnable()
    {
        if (ReplacementShader != null)
            GetComponent<Camera>().SetReplacementShader(ReplacementShader, "");
    }

    private void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }
}
