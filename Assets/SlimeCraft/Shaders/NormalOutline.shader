Shader "SlimeCraft/NormalOutline"
{
	Properties
	{
	    _Color("Color", Color) = (0.5, 0.5, 0.5, 0.5)
	}
	SubShader
	{
		Pass {            
            Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }

            Stencil {
                Ref 255
                Comp Greater
                Pass Keep
            }
            
            ZWrite Off
            ZTest Always
            Blend SrcAlpha OneMinusSrcAlpha
            
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma target 2.0
                #pragma multi_compile_fog

                #include "UnityCG.cginc"

                fixed4 _Color;

                struct appdata_t {
                    float4 vertex : POSITION;
                    float2 texcoord : TEXCOORD0;
                    float3 normal : NORMAL;
                    UNITY_VERTEX_INPUT_INSTANCE_ID
                };

                struct v2f {
                    float4 vertex : SV_POSITION;
                    UNITY_VERTEX_OUTPUT_STEREO
                };

                v2f vert (appdata_t v)
                {
                    v2f o;
                    UNITY_SETUP_INSTANCE_ID(v);
                    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                    o.vertex = UnityObjectToClipPos(v.vertex + v.normal * 0.1);
                    return o;
                }

                fixed4 frag (v2f i) : SV_Target
                {
                    return _Color;
                }
            ENDCG
        }
	}
}