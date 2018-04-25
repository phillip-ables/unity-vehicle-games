Shader "Hidden/BlackHoleShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
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
#pragma fragmentoption ARB_precision_hint_tastest
			
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float2 _Position;
			uniform float _Rad;
			uniform float _Ratio;
			uniform float _Distance;

			struct v2f {
				float4 pos : POSITION,
					float2 uv : TEXTCORD0;
			};

			v2f vert(appdata_img v) {
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.textcood;
				return o;
			}

			ENDCG
		}
	}
}
