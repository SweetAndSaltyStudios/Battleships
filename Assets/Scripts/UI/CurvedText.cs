using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace SweetAndSaltyStudios
{
    [ExecuteInEditMode]
    public class CurvedText : Text
    {
        #region VARIABLES

        private const float MIN_RADIUS = 0.001f;
        private const float MAX_RADIUS = 40f;
        private const float MIN_SCALE_FACTOR = 0.001f;
        private const float MAX_SCALE_FACTOR = 100f;

        [Space]
        [Header("QUICK SETTINGS")]
#pragma warning disable 0649
        [SerializeField] [Range(MIN_RADIUS, MAX_RADIUS)] private float radius = 0.5f;
        // [SerializeField] [Range(0, 360)] private float wrapAngle = 360.0f;
        [SerializeField] [Range(MIN_SCALE_FACTOR, MAX_SCALE_FACTOR)] private float scaleFactor = 100.0f;
        // [SerializeField] private bool canExecuteAtRuntime = false;
#pragma warning restore 0649

        private float _radius = -1;
        private float _scaleFactor = -1;
        private float _circumference = -1;

        #endregion VARIABLES

        #region PROPERTIES

        private float Circumference
        {
            get
            {
                if(_radius != radius || _scaleFactor != scaleFactor)
                {
                    _circumference = 2.0f * Mathf.PI * radius * scaleFactor;
                    _radius = radius;
                    _scaleFactor = scaleFactor;
                }

                return _circumference;
            }
        }
       
        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        protected override void OnValidate()
        {
            base.OnValidate();

            ClampMinRadiusAndScaleFactor();
        }

        protected override void OnPopulateMesh(VertexHelper vertexHelper)
        {
            base.OnPopulateMesh(vertexHelper);

            var stream = new List<UIVertex>();

            vertexHelper.GetUIVertexStream(stream);

            for(var i = 0; i < stream.Count; i++)
            {
                var uiVertex = stream[i];

                var percentCircumference = uiVertex.position.x / Circumference;
                var offset = Quaternion.Euler(0.0f, 0.0f, -percentCircumference * 360.0f) * Vector3.up;

                uiVertex.position = offset * radius * scaleFactor + offset * uiVertex.position.y;
                uiVertex.position += Vector3.down * radius * scaleFactor;

                stream[i] = uiVertex;
            }

            vertexHelper.AddUIVertexTriangleStream(stream);
        }

        //private void Update()
        //{
        //    if(canExecuteAtRuntime == false) return;

        //    ClampMinRadiusAndScaleFactor();

        //    rectTransform.sizeDelta = new Vector2(Circumference * wrapAngle / 360.0f, rectTransform.sizeDelta.y);
        //}

        private void ClampMinRadiusAndScaleFactor()
        {
            if(radius <= 0.0f) radius = MIN_RADIUS;

            if(scaleFactor <= 0.0f) scaleFactor = MIN_SCALE_FACTOR;
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS


        #endregion CUSTOM_FUNCTIONS
    }
}