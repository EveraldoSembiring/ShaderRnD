using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowableObject : MonoBehaviour {
    public float _LerpFactor;
    public Color TargetColor;

    public Color GlowColor = Color.white;
    private Color _IdleColor = Color.black;

    private Color _CurrentColor;
    private MeshRenderer[] _Renderers;

	// Use this for initialization
	void Start () {
        _CurrentColor = _IdleColor;
        _Renderers = GetComponentsInChildren<MeshRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        _CurrentColor = Color.Lerp(_CurrentColor, TargetColor, _LerpFactor * Time.deltaTime);

        for (int i = 0; i < _Renderers.Length; i++)
        {
            for (int j = 0; j < _Renderers[i].materials.Length; j++)
                _Renderers[i].materials[j].SetColor("_GlowColor", _CurrentColor);
        }
    }

    private void OnMouseEnter()
    {
        TargetColor = GlowColor;
    }

    private void OnMouseExit()
    {
        TargetColor = _IdleColor;
    }
}
