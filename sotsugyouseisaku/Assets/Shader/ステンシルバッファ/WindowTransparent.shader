Shader "Unlit/WindowTransparent"
{
     Properties
   {
    _Color("Color",Color)=(0.0,1.0,0.0,0)
   }

   SubShader 
   {
       //���p�V�F�[�_��Transparent�̃^�C�~���O�ŕ`�悵�Ă���̂ŁA�����+1
        Tags{"Queue"="Transparent+1"}
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
         fixed4 _Color;

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
          Stencil//�X�e���V���o�b�t�@��1���������܂ꂽ��`�揈��
          {
           Ref 2
           Comp Equal
          }
          ztest always
        CGPROGRAM
        //�Օ�����Ă��Ȃ����̕`�揈��
        fixed4 frag(float4 i:SV_POSITION):SV_TARGET
		{
		   fixed4 o = _Color;
		   return o;
		}
        ENDCG
      }
   }
}
