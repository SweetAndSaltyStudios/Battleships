using System.Collections;
using System.Collections.Generic;
using SweetAndSaltyStudios.Behaviours;

namespace SweetAndSaltyStudios
{
    public class OnlineGame : Game
    {
        #region VARIABLES

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region CONSTRUCTORS

        public OnlineGame(string name, IList<PlayerBehaviour> players, FleetPrototype fleetPrototype) : base(name, players, fleetPrototype)
        {

        }

        #endregion CONSTRUCTORS

        #region CUSTOM_FUNCTIONS

        public override IEnumerator HandleStart()
        {
            throw new System.NotImplementedException();
        }
        public override IEnumerator HandleSetUp()
        {
            throw new System.NotImplementedException();
        }
        public override IEnumerator HandleGameLoop()
        {
            throw new System.NotImplementedException();
        }
        public override IEnumerator HandleEndGame()
        {
            throw new System.NotImplementedException();
        }

        #endregion CUSTOM_FUNCTIONS
    }
}