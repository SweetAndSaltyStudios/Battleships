using UnityEditor;

namespace SweetAndSaltyStudios
{
    [CustomEditor(typeof(CurvedText))]
	public class CurvedTextEditor : Editor
	{
        #region VARIABLES

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}