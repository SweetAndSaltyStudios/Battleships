using System.Collections;
using SweetAndSaltyStudios.Behaviours;
using System.Collections.Generic;

namespace SweetAndSaltyStudios
{
    public abstract class Game
    {
        #region VARIABLES
        
        #endregion VARIABLES
        
        #region PROPERTIES

        public string Name { get; }
        public PlayerBehaviour Player_1 { get; }
        public PlayerBehaviour Player_2 { get; }
        
        #endregion PROPERTIES

        #region CONSTRUCTORS

        public Game(string name, IList<PlayerBehaviour> players, FleetPrototype fleetPrototype)
        {
            Name = name;

            if(players.Count >= 2)
            {
                Player_1 = players[0];

                Player_1.CreateFleet(fleetPrototype);

                Player_2 = players[1];

                Player_2.CreateFleet(fleetPrototype);
            }
        }
        #endregion CONSTRUCTORS

        #region CUSTOM_FUNCTIONS

        public abstract IEnumerator HandleStart();
        public abstract IEnumerator HandleSetUp();
        public abstract IEnumerator HandleGameLoop();
        public abstract IEnumerator HandleEndGame();
        
        #endregion CUSTOM_FUNCTIONS
    }
}