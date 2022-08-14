using SuperMarioBroski;
using System;
namespace SuperMarioBroski {

    public class StateTransformer {

        public StateTransformer() {
        }

        /// <summary>Returns a corresponding string for state
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = "state">string for transfroming to state
        /// </param>
        /// <returns>state
        /// </returns>
        public static GameStateType TransformStringToState(string state) {
            switch (state) {
                case "GAME_RUNNING":
                    return GameStateType.GameRunning;
                default:
                    throw new InvalidOperationException("Invalid GameState");
            }
        }

         /// <summary>Returns a corresponding state for string
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = "state">state for transfroming to string
        /// </param>
        /// <returns>string of state 
        /// </returns>
        public static string TransformStateToString(GameStateType stateType) {
            switch (stateType) {
                case GameStateType.GameRunning:
                    return "GAME_RUNNING";
                default:
                    throw new InvalidOperationException("Invalid GameState");
            }
        }
    }
}