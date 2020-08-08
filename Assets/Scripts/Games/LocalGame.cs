using System.Collections;
using UnityEngine;
using SweetAndSaltyStudios.Behaviours;
using System.Collections.Generic;

namespace SweetAndSaltyStudios
{
    public class LocalGame : Game
    {
        #region VARIABLES

        private PlayerBehaviour currentPlayer;
        private bool isRunning;
        private readonly WaitUntil waitUntil_InputPressed;

        #endregion VARIABLES

        #region PROPERTIES

        private int maxTurns = 4;

        #endregion PROPERTIES

        #region CONSTRUCTORS

        public LocalGame(string name, IList<PlayerBehaviour> players, FleetPrototype fleetPrototype) : base(name, players, fleetPrototype)
        {
            waitUntil_InputPressed = new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        #endregion CONSTRUCTORS

        #region CUSTOM_FUNCTIONS

        private void SwitchNextPlayer()
        {
            if(currentPlayer != null)
            {
                currentPlayer.gameObject.SetActive(false);
            }

            currentPlayer = currentPlayer == Player_1 ? Player_2 : Player_1;

            currentPlayer.gameObject.SetActive(true);
        }

        public override IEnumerator HandleStart()
        {
            yield return waitUntil_InputPressed;

            SwitchNextPlayer();
        }
        public override IEnumerator HandleSetUp()
        {
            yield return new WaitUntil(() => currentPlayer.IsReady);

            SwitchNextPlayer();

            yield return new WaitUntil(() => currentPlayer.IsReady);

            SwitchNextPlayer();

            yield return waitUntil_InputPressed;

            isRunning = true;
        }
        public override IEnumerator HandleGameLoop()
        {
            while(isRunning)
            {
                yield return currentPlayer.HandleTurn();

                SwitchNextPlayer();

                yield return waitUntil_InputPressed;

                maxTurns--;

                if(maxTurns < 0)
                {
                    isRunning = false;
                }
            }
        }
        public override IEnumerator HandleEndGame()
        {
            Debug.Log("HandleEndGame()");
            yield return waitUntil_InputPressed;
            Debug.LogWarning("GAME ENDED!");

            Player_1.gameObject.SetActive(false);
            Player_2.gameObject.SetActive(false);
        }

        #endregion CUSTOM_FUNCTIONS
    }
}