using System.Collections.Generic;
using UnityEngine;
using SweetAndSaltyStudios.Behaviours;

namespace SweetAndSaltyStudios
{
	public class PrimaryGridBehaviour : GridBehaviour
	{
        #region VARIABLES

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void PlaceFleet(IList<ShipBehaviour> fleet)
        {
            for(var i = 0; i < fleet.Count; i++)
            {
                PlaceShip(fleet[i], GetNextFreeCell());
            }
        }

        private void PlaceShip(ShipBehaviour shipBehaviour, CellBehaviour anchorCell)
        {
            shipBehaviour.RectTransform.position = anchorCell.RectTransform.position;
        }

        private CellBehaviour GetNextFreeCell()
        {
            var freeCell = freeCells[0];
            freeCells.RemoveAt(0);
            return freeCell;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}