using System;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Events;
using System.Collections.Generic;


namespace SuperMarioBroski {
    public class Game : DIKUGame, IGameEventProcessor {
        
        private StateMachine stateMachine;
        private GameEventBus eventBus;

        /// <summary> The constructor 'Game' that creates the window in which our game is rendered.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = "winArgs"> Argument for constructing a DIKUArcade.Window object.
        /// </param>
        /// <returns> An instatiated object.
        /// </returns>
        public Game (WindowArgs winArgs) : base (winArgs) {
            window.SetKeyEventHandler(KeyHandler);
            eventBus = SuperBus.GetBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.TimedEvent,
            GameEventType.WindowEvent, GameEventType.InputEvent, GameEventType.PlayerEvent, GameEventType.GameStateEvent });
            stateMachine = new StateMachine();
           
        }

        /// <summary> The 'KeyHandler' method takes as argument the action and the key, and passes this information to the stateMachine.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = "action"> The action of either pressing or releasing a key.
        /// <param name = "key"> The key which is pressed.
        /// </param>
        /// <returns> void
        /// </returns>
        private void KeyHandler(KeyboardAction action, KeyboardKey key)
        {
            stateMachine.HandleKeyEvent(action, key);
        }

       /// <summary> It process eventBus
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param > None
        /// </param>
        public override void Render()
        {
            stateMachine.ActiveState.RenderState();
        }

        /// <summary> It process eventBus
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = "">
        /// </param>
        /// <returns>
        /// </returns>
        public override void Update()
        {
            stateMachine.ActiveState.UpdateState();
            eventBus.ProcessEvents();
        }

        /// <summary>We must have this empty function because of inheritance
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = "">
        /// </param>
        /// <returns>
        /// </returns>
        public void ProcessEvent(GameEvent gameEvent){}
    }
}
