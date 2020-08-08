using System;
using UnityEngine;

namespace SweetAndSaltyStudios
{
    [Serializable]
	public class ShipPrototype
	{
        #region VARIABLES

#pragma warning disable 0649
        [SerializeField] string name;
        [SerializeField] int size;
        [SerializeField] int amount;
        [SerializeField] Color color;
#pragma warning restore 0649

        #endregion VARIABLES

        #region PROPERTIES

        public string Name { get { return name; } }
        public int Size { get { return size; } }
        public int Amount { get { return amount; } }
        public Color Color { get { return color; } }

        #endregion PROPERTIES

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}