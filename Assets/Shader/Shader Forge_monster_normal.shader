Shader "Shader Forge/monster_normal" {
	Properties {
		[HDR] _texcolor ("texcolor", Vector) = (0.5,0.5,0.5,1)
		_maintex ("maintex", 2D) = "white" {}
		[HDR] _hitcolor ("hitcolor", Vector) = (0,0,0,1)
		[HDR] _basecolor ("basecolor", Vector) = (0,0,0,1)
		_seecolor ("seecolor", Vector) = (0.4264706,0.4264706,0.4264706,1)
		_fresnelexp ("fresnelexp", Range(0, 1)) = 0.9401709
		_seeintensty ("seeintensty", Range(0, 10)) = 1
		_opacity ("opacity", Range(0, 1)) = 1
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
		_emission ("emission", 2D) = "black" {}
		[HDR] _emissioncolor ("emissioncolor", Vector) = (0.2573529,0.2573529,0.2573529,1)
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
	//CustomEditor "ShaderForgeMaterialInspector"
}