using UnityEngine;


namespace SimpleMan.VisualRaycast
{
    public class CustomParams
    {
        //******            PROPERTIES        	******\\
        public Color HitColor => _hitColor;
        public Color NoHitColor => _noHitColor;
        public float FadeTime => _fadeTime;




        //******            FIELDS          	******\\
        private  Color _hitColor = Color.green;
        private  Color _noHitColor = Color.red;
        private  float _fadeTime = 0.5f;




        //******           CONSTRUCTORS         ******\\
        public CustomParams(Color hitColor, Color noHitColor, float fadeTime)
        {
            _hitColor = hitColor;
            _noHitColor = noHitColor;

            if (fadeTime < 0.1f || fadeTime > 10)
                throw new System.ArgumentOutOfRangeException("Custom Params: Fade time must be greater than 0.1 and less then 10");

            _fadeTime = Mathf.Clamp(fadeTime, 0.1f, 10);
        }
    }
}