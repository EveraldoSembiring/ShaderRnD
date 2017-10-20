Shader "Glow/CompositeGlowEffct"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Intensity("Intensity", float) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv1 : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
			};

			struct v2f
			{
				float2 uv1 : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			sampler2D _GlowBlurredTex;
			sampler2D _GlowPrePassTex;
			float _Intensity;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv1 = v.uv1;
				o.uv2 = v.uv2;
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv1);
				fixed4 blurred = tex2D(_GlowBlurredTex, i.uv2);
				fixed4 prepass = tex2D(_GlowPrePassTex, i.uv2);
				fixed4 glow = max(0, blurred - prepass);

				return col + glow * _Intensity;
			}
			ENDCG
		}
	}
}
