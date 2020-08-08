using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SweetAndSaltyStudios.Behaviours
{
	public abstract class GridBehaviour : MonoBehaviour
	{
        #region VARIABLES
#pragma warning disable 0649
        [SerializeField] private PlayerBehaviour owner;
        [SerializeField] private Text headerLabelText;
#pragma warning restore 0649
        private Dictionary<Vector2Int, CellBehaviour> allCells = new Dictionary<Vector2Int, CellBehaviour>();

        protected List<CellBehaviour> freeCells = new List<CellBehaviour>();

        private Vector2Int gridSize = new Vector2Int(10, 10);

        #endregion VARIABLES

        #region PROPERTIES


        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            CreateCells(
                Resources.Load<CellBehaviour>("Prefabs/Cell"), 
                transform.Find("Content").Find("CellContainer").transform);
        }

        private void Start()
        {
            headerLabelText.text = owner.name;
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void CreateCells(CellBehaviour cellPrefab, Transform container)
        {
            if(cellPrefab == null) { Debug.LogWarning("'Cell' prefab is NULL"); return; }

            var position = Vector2Int.zero;

            for(var x = 0; x < gridSize.x; x++)
            {
                for(var y = 0; y < gridSize.y; y++)
                {
                    var cellBehaviour = Utility.CreateBehaviour($"Cell ( {x} , {y} )", cellPrefab, container);

                    if(cellBehaviour == null) continue;

                    position.x = x;
                    position.y = y;

                    allCells.Add(position, cellBehaviour);
                }
            }

            freeCells = new List<CellBehaviour>(allCells.Values);
        }
     
        private CellBehaviour GetCell(Vector2Int position)
        {
            position.x -= 1;
            position.y -= 1;

            if(IsPositionInGrid(position) == false) { Debug.LogWarning($"Position ' {position} ' out of range"); return null; }

            return allCells[position];
        }

        private bool IsPositionInGrid(Vector2Int position)
        {
            return position.x > 0 
                && position.x < gridSize.x
                && position.y > 0 
                && position.y < gridSize.y;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}