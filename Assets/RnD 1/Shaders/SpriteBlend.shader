﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "R&D/Sprite Blend"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_SecondTex("Second Texture", 2D) = "white" {}
		_Tween("Tween", Range(0,1)) = 0
	}
	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
		}

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _SecondTex;
			float _Tween;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				float4 col1 = tex2D(_MainTex, i.uv);
				float4 col2 = tex2D(_SecondTex, i.uv);
				float4 v = (col1 * (1 - _Tween)) + (col2 * _Tween);
				return v;
			}
			ENDCG
		}
	}
}
