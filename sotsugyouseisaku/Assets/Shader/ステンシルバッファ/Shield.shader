Shader "Unlit/Shield"
{
  Properties
   {
    _RefrColor("Refraction color",Color)=(0.34,0.85,0.92,1)
   }

   SubShader 
   {
       CGINCLUDE
       #pragma vertex vert
         #pragma fragment frag
         #include "UnityCG.cginc"

         struct appdata
         {
            float4 vertex:POSITION;
            float2 uv:TEXCOORD0;
         };
         struct v2f
         {
            float4 vertex:SV_POSITION;
            float2 uv :TEXCOORD0;
         };
         fixed4 _RefrColor;

         v2f vert(appdata v)
         {
            v2f o;
            o.vertex=UnityObjectToClipPos(v.vertex);
            o.uv=v.uv;
            return o;
         }
         ENDCG
      Pass
      {
          Stencil
          {
           Ref 1
           Comp always
           Pass replace
          }

         CGPROGRAM
        fixed4 frag(float4 i:SV_POSITION):SV_TARGET
		{
		   fixed4 o = _RefrColor;
		   return o;
		}
         ENDCG
      }
    }
}
