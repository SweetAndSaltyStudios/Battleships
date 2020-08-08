using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SweetAndSaltyStudios.Behaviours
{
    public class PlayerBehaviour : MonoBehaviour
    {
        #region VARIABLES

        [Space]
        [Header("References")]
#pragma warning disable 0649
        [SerializeField] private PrimaryGridBehaviour primaryGrid;
        [SerializeField] private TrackingGridBehaviour trackingGrid;
        [SerializeField] private ControlBarBehaviour controlBar;
        [SerializeField] private Transform fleetContainer;
#pragma warning restore 0649

        private List<ShipBehaviour> ships = new List<ShipBehaviour>();

        #endregion VARIABLES

        #region PROPERTIES

        public bool IsReady { get; private set; }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Start()
        {
            gameObject.SetActive(false);
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void CreateFleet(FleetPrototype fleetPrototype)
        {
            var prefab = Resources.Load<ShipBehaviour>("Prefabs/Ship");
            var shipPrototypes = fleetPrototype.ShipPrototypes;

            for(var i = 0; i < shipPrototypes.Length; i++)
            {
                ships.AddRange(CreateShips(shipPrototypes[i], prefab, fleetContainer));
            }

            primaryGrid.PlaceFleet(ships);
        }

        private ShipBehaviour[] CreateShips(ShipPrototype shipPrototype, ShipBehaviour shipPrefab, Transform parent = null)
        {
            var name = shipPrototype.Name;
            var amount = shipPrototype.Amount;
            var size = shipPrototype.Size;
            var color = shipPrototype.Color;

            var createdShips = new ShipBehaviour[amount];

            for(var i = 0; i < amount; i++)
            {
                var ship = Utility.CreateBehaviour(name, shipPrefab, parent);
                ship.RectTransform.sizeDelta = new Vector2(60, size * 60);
                ship.BackgroundColor = color;

                createdShips[i] = ship;
            }

            return createdShips;
        }

        public IEnumerator HandleTurn()
        {
            yield return null;
        }

        public void ReadyButton()
        {
            IsReady = true;
        }

        public void SwitchGridButton()
        {

        }

        #endregion CUSTOM_FUNCTIONS
    }
}