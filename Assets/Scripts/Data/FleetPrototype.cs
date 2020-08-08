using System;
using UnityEngine;

namespace SweetAndSaltyStudios
{
    [Serializable]
	public class FleetPrototype
	{
        #region VARIABLES

#pragma warning disable 0649
        [SerializeField] ShipPrototype[] shipPrototypes;
#pragma warning restore 0649

        #endregion VARIABLES

        #region PROPERTIES

        public ShipPrototype[] ShipPrototypes { get { return shipPrototypes; } }

        #endregion PROPERTIES

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}