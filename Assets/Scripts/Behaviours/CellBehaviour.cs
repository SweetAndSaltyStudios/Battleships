using UnityEngine;
using UnityEngine.UI;

namespace SweetAndSaltyStudios.Behaviours
{
	public class CellBehaviour : MonoBehaviour
	{
        #region VARIABLES

        #endregion VARIABLES

        #region PROPERTIES

        public Image BackgroundImage { get; private set; }
        public RectTransform RectTransform { get { return transform as RectTransform; } }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            BackgroundImage = GetComponentInChildren<Image>();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}