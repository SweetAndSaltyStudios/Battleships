using UnityEngine;

namespace SweetAndSaltyStudios
{
    public class UIPanel : MonoBehaviour, IDraggable
    {
        #region VARIABLES

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        public void BeginDrag()
        {

        }

        public void Drag(Vector3 deltaPosition)
        {
            transform.position += deltaPosition;
        }

        public void EndDrag()
        {

        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}