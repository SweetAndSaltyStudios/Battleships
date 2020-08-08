using UnityEngine;
using UnityEngine.UI;

namespace SweetAndSaltyStudios
{
	public class ControlBarBehaviour : MonoBehaviour
	{
        #region VARIABLES

        private Button readyButton;

        #endregion VARIABLES

        #region PROPERTIES

        public Button ReadyButton
        {
            get
            {
                if(readyButton == null) readyButton = GetComponentInChildren<Button>();

                return readyButton;
            }
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}