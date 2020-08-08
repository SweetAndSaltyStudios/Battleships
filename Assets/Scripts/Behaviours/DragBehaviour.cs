using UnityEngine;
using UnityEngine.EventSystems;

namespace SweetAndSaltyStudios.Behaviours
{
    public class DragBehaviour : MonoBehaviour,
    IBeginDragHandler, 
    IDragHandler,
    IEndDragHandler
    {
        #region VARIABLES

        private IDraggable draggable;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            draggable = GetComponent<IDraggable>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(draggable == null) return;

            draggable.BeginDrag();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(draggable == null) return;

            draggable.Drag(eventData.delta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(draggable == null) return;

            draggable.EndDrag();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}