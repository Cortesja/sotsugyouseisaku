Shader "Unlit/Transparent"
{
   Properties
   {
    _ShieldedColor("shielded color",Color)=(0.0,1.0,0.0,1)
    _NotShieldedColor("not shielded color",Color)=(0.34,0.85,0.92,1)
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
         fixed4 _ShieldedColor;
         fixed4 _NotShieldedColor;

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
           Comp NotEqual
          }

        CGPROGRAM
        //é’ï¡Ç≥ÇÍÇƒÇ¢Ç»Ç¢éûÇÃï`âÊèàóù
        fixed4 frag(float4 i:SV_POSITION):SV_TARGET
		{
		   fixed4 o = _NotShieldedColor;
		   return o;
		}
        ENDCG
      }
      Pass
      {
          Tags{"Queue"="Geometry+1"}
          Stencil
          {
              Ref 1
              Comp Equal
          }
          ztest always

        CGPROGRAM
        //é’ï¡Ç≥ÇÍÇƒÇ¢ÇÈÇ∆Ç´ÇÃï`âÊèàóù
        fixed4 frag(float4 i:SV_POSITION):SV_TARGET
		{
		   fixed4 o = _ShieldedColor;
		   return o;
		}
        ENDCG
      }
    }
}
