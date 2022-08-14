using DIKUArcade.Events;
using DIKUArcade.State;
using DIKUArcade.Input;

namespace SuperMarioBroski {

    public class StateMachine : IGameEventProcessor {
        public IGameState ActiveState { get; private set; }

        /// <summary>Constructor
        /// </summary>
        /// <remarks> 
        /// </remarks>None
        /// <returns>None only initalizes
        /// </returns>
        public StateMachine() {
            SuperBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
            SuperBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            ActiveState = GameRunning.GetInstance();
        }
        
        /// <summary>Switches state 
        /// </summary>
        /// <remarks> None
        /// </remarks>
        /// <param name = "statetype">
        /// </param>
        /// <returns>ActiveState
        /// </returns>
        public void SwitchState(GameStateType stateType) {
            switch (stateType) {

                case GameStateType.GameRunning:
                    ActiveState = GameRunning.GetInstance();
                    break;
            }
        }

        /// <summary> Handles the event for GameOver
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = "action">Determines if release or press action
        /// </param>
        /// <param name = "key">The keyboard key presses
        /// </param>
        /// <returns>None
        /// </returns>
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key){
            ActiveState.HandleKeyEvent(action, key);

        }
        
        /// <summary> Handles the eventbus
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = "gameevent">Used for proccesing the event
        /// </param>
        /// <returns>None
        /// </returns>
        public void ProcessEvent( GameEvent gameEvent) {

            if (gameEvent.EventType == GameEventType.InputEvent) {
                switch (gameEvent.Message) {
                    case "KEY_PRESS":
                        ActiveState.HandleKeyEvent(DIKUArcade.Input.KeyboardAction.KeyPress, DIKUArcade.Input.KeyboardKey.Enter);
                        break;

                    case "KEY_RELEASE":
                        ActiveState.HandleKeyEvent(DIKUArcade.Input.KeyboardAction.KeyRelease, DIKUArcade.Input.KeyboardKey.Down);
                        break;

                    default:
                        break;
                }

            }
            if (GameEventType.GameStateEvent == gameEvent.EventType) {
                switch (gameEvent.Message) {
                    case "CHANGE_STATE":
                        SwitchState(StateTransformer.TransformStringToState(gameEvent.StringArg1));
                        break;
                    default:
                        break;
                }
                if(gameEvent.StringArg1=="GAME_RUNNING"){
                    ActiveState = GameRunning.GetInstance();
                }


            }
        }
    }
}