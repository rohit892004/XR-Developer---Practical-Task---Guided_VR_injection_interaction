Shader "Custom/SyringeLiquid"
{
    Properties
    {
        _MedicineColor ("Medicine Color", Color) = (0.1, 0.8, 0.2, 1)

        _FillAmount ("Fill Amount", Range(0,1)) = 0

        _Transparency ("Transparency", Range(0,1)) = 0.85

        _LiquidSmoothness ("Liquid Look Smoothness", Range(0,1)) = 0.85

        _FillEdgeSoftness ("Fill Edge Softness", Range(0.001,0.2)) = 0.02

        _ReverseFillDirection ("Reverse Fill Direction", Range(0,1)) = 1
    }

    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
            "RenderPipeline"="UniversalPipeline"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Back

        Pass
        {
            Name "MedicineLiquid"

            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float3 positionOS  : TEXCOORD0;
                float3 normalWS    : TEXCOORD1;
            };

            CBUFFER_START(UnityPerMaterial)

                float4 _MedicineColor;

                float _FillAmount;
                float _Transparency;
                float _LiquidSmoothness;
                float _FillEdgeSoftness;
                float _ReverseFillDirection;

            CBUFFER_END


            Varyings vert(Attributes input)
            {
                Varyings output;

                output.positionHCS =
                    TransformObjectToHClip(input.positionOS.xyz);

                // IMPORTANT:
                // Keep object-space position so liquid follows
                // the syringe/cylinder orientation.
                output.positionOS = input.positionOS.xyz;

                output.normalWS =
                    TransformObjectToWorldNormal(input.normalOS);

                return output;
            }


            half4 frag(Varyings input) : SV_Target
            {
                /*
                 * UNITY CYLINDER:
                 *
                 * Local Y = cylinder length
                 *
                 * -1 side -------- 0 -------- +1 side
                 *
                 * We normalize Y into 0 -> 1.
                 */

                float y = input.positionOS.y;

                // Convert local Y to 0-1.
                float fillPosition =
                    saturate(y * 0.5 + 0.5);


                /*
                 * Reverse direction.
                 *
                 * 0 = bottom -> top
                 * 1 = top -> bottom
                 */
                fillPosition =
                    lerp(
                        fillPosition,
                        1.0 - fillPosition,
                        _ReverseFillDirection
                    );


                /*
                 * Create the liquid boundary.
                 *
                 * FillAmount:
                 *
                 * 0.0 = empty
                 * 0.25 = 25%
                 * 0.5 = 50%
                 * 0.75 = 75%
                 * 1.0 = full
                 */

                float edge =
                    _FillEdgeSoftness;

                float liquidMask =
                    1.0 - smoothstep(
                        _FillAmount - edge,
                        _FillAmount + edge,
                        fillPosition
                    );


                /*
                 * At FillAmount = 0
                 * don't show anything.
                 */

                liquidMask *= step(0.001, _FillAmount);


                /*
                 * Medicine color
                 */

                float3 finalColor =
                    _MedicineColor.rgb;


                /*
                 * Slight liquid lighting.
                 */

                float3 normal =
                    normalize(input.normalWS);

                float3 viewDirection =
                    normalize(
                        _WorldSpaceCameraPos -
                        TransformObjectToWorld(input.positionOS)
                    );

                float fresnel =
                    pow(
                        1.0 - saturate(dot(normal, viewDirection)),
                        3.0
                    );

                finalColor +=
                    fresnel *
                    _LiquidSmoothness *
                    0.15;


                /*
                 * Transparency
                 */

                float alpha =
                    liquidMask *
                    _Transparency;


                return half4(
                    finalColor,
                    alpha
                );
            }

            ENDHLSL
        }
    }
}