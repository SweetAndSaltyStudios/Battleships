using System.Collections;
using UnityEngine;
using SweetAndSaltyStudios.Behaviours;

namespace SweetAndSaltyStudios
{
    public class GameManager : MonoBehaviour
	{
        #region VARIABLES

        [Space]
        [Header("FleetPrototype")]
#pragma warning disable 0649
        [SerializeField] FleetPrototype fleetPrototype;
#pragma warning restore 0649

        [Space]
        [Header("References")]
#pragma warning disable 0649
        [SerializeField] private Transform gameArea;
        [SerializeField] private Transform uiContainer;
#pragma warning restore 0649

        private Coroutine iRunGame_Coroutine;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void QuitButton()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.Beep();
#endif
        }

        public void LocalButton()
        {
            StartGame(
                new LocalGame(
                "Local game",
                Utility.CreateBehaviours("Player", Resources.Load<PlayerBehaviour>("Prefabs/Player"), gameArea, 2),
                fleetPrototype
                ));
        }

        public void OnlineButton()
        {
            StartGame(
                 new OnlineGame(
                "Online game",
                 Utility.CreateBehaviours("Player", Resources.Load<PlayerBehaviour>("Prefabs/Player"), gameArea, 2),
                 fleetPrototype
                 ));
        }

        private void StartGame(Game newGame)
        {
            iRunGame_Coroutine = StartCoroutine(IRunGame(newGame));
        }

        private IEnumerator IRunGame(Game game)
        {
            var waitForEndOfFrame = new WaitForEndOfFrame();

            yield return game.HandleStart();

            yield return waitForEndOfFrame;

            yield return game.HandleSetUp();

            yield return waitForEndOfFrame;

            yield return game.HandleGameLoop();

            yield return waitForEndOfFrame;

            yield return game.HandleEndGame();
        }

        #endregion CUSTOM_FUNCTIONS
    }
}