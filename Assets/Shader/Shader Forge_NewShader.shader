Shader "Shader Forge/NewShader" {
	Properties {
		_node_5901 ("node_5901", 2D) = "white" {}
		_node_2013 ("node_2013", Vector) = (0.5,0.5,0.5,1)
		_node_4269 ("node_4269", Range(0, 10)) = 1.190431
		[HideInInspector] _node_8769 ("node_8769", Float) = 2
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