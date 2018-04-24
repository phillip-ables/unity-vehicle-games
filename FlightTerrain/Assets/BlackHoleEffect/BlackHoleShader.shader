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

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};


			uniform sampler2D _MainTex;
			uniform float2 _Position;
			uniform float _Rad;
			uniform float _Ratio;
			uniform float _Distance;

			ENDCG
		}
	}
}
