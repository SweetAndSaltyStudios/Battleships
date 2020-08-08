using UnityEngine;
using UnityEngine.UI;

namespace SweetAndSaltyStudios.Behaviours
{
    public class ShipBehaviour : MonoBehaviour, IDraggable
    {
        #region VARIABLES

        private Image backgroundImage;

        #endregion VARIABLES

        #region PROPERTIES

        public RectTransform RectTransform { get { return transform as RectTransform;} }

        public Color BackgroundColor
        {
            set
            {
                if(backgroundImage == null) backgroundImage = GetComponentInChildren<Image>();

                backgroundImage.color = value;
            }
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

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

        #endregion CUSTOM_FUNCTIONS
    }
}