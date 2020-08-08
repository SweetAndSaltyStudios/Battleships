using UnityEngine;

namespace SweetAndSaltyStudios
{
    public interface IDraggable
    {
        void BeginDrag();
        void Drag(Vector3 deltaPosition);
        void EndDrag();
    }
}