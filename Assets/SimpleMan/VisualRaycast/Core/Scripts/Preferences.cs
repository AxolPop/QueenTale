using UnityEngine;

namespace SimpleMan.VisualRaycast
{
    public static class Preferences
    {
        //******            PROPERTIES        	******\\
        public static Color HitColor 
        { 
            get => _hitColor; 
            set => _hitColor = value; 
        }
        public static Color NoHitColor 
        { 
            get => _noHitColor;
            set => _noHitColor = value; 
        }
        public static float FadeTime 
        { 
            get => _fadeTime; 
            set => _fadeTime = Mathf.Clamp(value, 0.1f, 10); 
        }
        public static bool ShowDistances 
        { 
            get => _showDistances; 
            set => _showDistances = value; 
        }
        public static bool ShowObjectNames 
        { 
            get => _showObjectNames; 
            set => _showObjectNames = value; 
        }



        //******            FIELDS          	******\\
        private static Color _hitColor = Color.green;
        private static Color _noHitColor = Color.red;
        private static float _fadeTime = 0.3f;
        private static bool _showDistances = false;
        private static bool _showObjectNames = false;



        //******    	    METHODS  	  	    ******\\
        public static void SetDefaults()
        {
            _hitColor = Color.green;
            _noHitColor = Color.red;
            _fadeTime = 0.3f;
            _showDistances = false;
            _showObjectNames = false;
        }
    }
}