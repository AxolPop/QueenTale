using UnityEngine;
using UnityEditor;

namespace SimpleMan.VisualRaycast 
{ 
    public static class PreferencesWindow
    {
        //******            FIELDS          	******\\
        private static string prefsPrefix = "VisualCast.";



        //******    	    METHODS  	  	    ******\\
        // Add preferences section named "My Preferences" to the Preferences window
        [PreferenceItem("Simple Man: Visual Raycast")]
        public static void PreferencesGUI()
        {
            //Update all fields from editor prefs
            UpdateFromPrefs();


            // Preferences GUI
            GUILayout.Space(20);
            Preferences.HitColor = EditorGUILayout.ColorField(new GUIContent("Hit Color"), Preferences.HitColor, true, false, false);
            Preferences.NoHitColor = EditorGUILayout.ColorField(new GUIContent("No Hit Color"), Preferences.NoHitColor, true, false, false);
            Preferences.FadeTime = EditorGUILayout.Slider(new GUIContent("Fade Time"), Preferences.FadeTime, 0.1f, 5);
            GUI.enabled = false;
            Preferences.ShowDistances = EditorGUILayout.Toggle(new GUIContent("Show Distances"), Preferences.ShowDistances);
            Preferences.ShowObjectNames = EditorGUILayout.Toggle(new GUIContent("Show Object Names"), Preferences.ShowObjectNames);
            GUI.enabled = true;





            //Set defaults button
            GUILayout.Space(20);
            if (GUILayout.Button(new GUIContent("Set Defaults"), GUILayout.Height(20)))
                Preferences.SetDefaults();


            // Save the preferences
            if (GUI.changed)
                Save();
        }


        private static void Save()
        {
            
            EditorPrefs.SetString($"{prefsPrefix}HitColor", Preferences.HitColor.ToString());
            EditorPrefs.SetString($"{prefsPrefix}NoHitColor", Preferences.NoHitColor.ToString());
            EditorPrefs.SetFloat($"{prefsPrefix}FadeTime", Preferences.FadeTime);
        }


        private static void UpdateFromPrefs()
        {
            //Update hit color
            if (EditorPrefs.HasKey($"{prefsPrefix}HitColor"))
            {
                string hitColorValueName = EditorPrefs.GetString($"{prefsPrefix}HitColor");
                Preferences.HitColor= ToColor(hitColorValueName);
            }


            //Update no hit color
            if (EditorPrefs.HasKey($"{prefsPrefix}NoHitColor"))
            {
                string noHitColorValueName = EditorPrefs.GetString($"{prefsPrefix}NoHitColor");
                Preferences.NoHitColor = ToColor(noHitColorValueName);
            }


            //Update fade time
            if (EditorPrefs.HasKey($"{prefsPrefix}FadeTime"))
            {
                Preferences.FadeTime = EditorPrefs.GetFloat($"{prefsPrefix}FadeTime");
            }
        }


        private static Color ToColor(string valueName)
        {
            //Remove the header and brackets
            valueName = valueName.Replace("RGBA(", "");
            valueName = valueName.Replace(")", "");


            //Get the individual values (red green blue and alpha)
            var strings = valueName.Split(","[0]);



            Color result = Color.white;
            for (int i = 0; i < 4; i++)
            {
                result[i] = System.Single.Parse(strings[i]);
            }


            return result;
        }
    }
}