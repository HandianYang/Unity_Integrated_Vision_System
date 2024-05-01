// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Based on Unlit shader, but culls the front faces instead of the back

Shader "InsideVisible" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }	// objects rendered with this shader should be opaque
	Cull front	// Render the back faces of the object
	LOD 100		// Level of Detail
	
	Pass {  
		CGPROGRAM	// beginning of the CG code
			#pragma vertex vert		// specify the vertex shader fnnction as `vert`
			#pragma fragment frag	// specify the fragment shader fnnction as `frag`
			
			#include "UnityCG.cginc"
			
			// input data
			struct appdata_t {
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			// output data
			struct v2f {
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			// vertex shader function
			v2f vert (appdata_t v)
			{
				v2f o;
				float scale = 2;

				v.texcoord.x = 1 - v.texcoord.x;
				v.texcoord *= scale;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			// fragment shader function
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.texcoord);
				return col;
			}
		ENDCG	// end of the CG code
	}
}

}