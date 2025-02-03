Shader "Shader Forge/add_flow" {
	Properties {
		_tint ("tint", Vector) = (1,1,1,1)
		_main_Tex ("main_Tex", 2D) = "white" {}
		_value ("value", Float) = 2
		_niuqu ("niuqu", 2D) = "white" {}
		_niuqu_value ("niuqu_value", Float) = 2
		_uv_speed ("uv_speed", Vector) = (0.5,0.5,0,0)
		_mask ("mask", 2D) = "white" {}
		_StencilComp ("Stencil Comparison", Float) = 6
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ShaderForgeMaterialInspector"
}