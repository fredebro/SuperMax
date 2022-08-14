using System;
using System.IO;
using DIKUArcade.State;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using System.Collections.Generic;
using DIKUArcade.Graphics;
using DIKUArcade.Physics;
using DIKUArcade.Math;
using DIKUArcade.Events;
using DIKUArcade.Timers;

namespace SuperMarioBroski {
    public class GameRunning : IGameState, IGameEventProcessor {
        
        private static GameRunning instance = null;
        private GameEventBus eventBus;
        private Entity backGroundImage;

        private Image image;
        private Player player;
        private Generator generator;
        private EntityContainer<Block> blocks;
        private Block blockTest;

        private bool left;
        private bool right;
        private bool up;

        public static GameRunning GetInstance() {
            return GameRunning.instance ?? (GameRunning.instance = new GameRunning());
        }
        public void NewInstance() {
            GameRunning.instance = new GameRunning();
        }
        public GameRunning () {
            
            InitializeGameState();
            image = new Image(Path.Combine("Assets", "Images", "background.png"));
            backGroundImage = new Entity(new DynamicShape(new Vec2F(0.0f, 0.0f), new Vec2F(1.0f, 1.0f)), image);
            eventBus.Subscribe(GameEventType.TimedEvent, this);
            
        }
       public void InitializeGameState(){
            eventBus = SuperBus.GetBus();

            player = new Player(new DynamicShape(new Vec2F(0.45f, 0.2f),
                new Vec2F(0.2f, 0.2f)),
                    new Image(Path.Combine("Assets", "Images", "supermario.jpg")));

            blockTest = new Block(new DynamicShape(new Vec2F(0.18f, 0.3f),
                new Vec2F(0.2f, 0.2f)),
                    new Image (Path.Combine("Assets", "Images", "SuperBlock.jpg")),
                        new Image(Path.Combine("Assets", "Images", "teal-block.png")));

            generator = new Generator();
            blocks = generator.mapGen();

            StaticTimer.RestartTimer();
       }
        public void UpdateGameLogic() {    
            
        }
        public void ResetState(){

        }

       public void UpdateState(){
        eventBus.ProcessEvents();
        player.moveright(right, blockTest);
        player.Collision(blockTest);
        player.moveleft(left);

        // if (player.isColliding){
        //     System.Console.WriteLine(player.isColliding);
        // }
        player.jump(up, blocks, player);
       }
        
        public void RenderState(){
            backGroundImage.RenderEntity();
            player.RenderEntity();
            // blocks.RenderEntities();
            blockTest.RenderEntity();
        }
        
        /// <summary> Handles the eventbus
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = "gameevent">Used for proccesing the event
        /// </param>
        /// <returns>None
        /// </returns>
        public void ProcessEvent(GameEvent gameEvent){
            eventBus.ProcessEvents();
        }

        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
        {
            if (action == KeyboardAction.KeyPress)
            {
                switch (key)
                {
                    case KeyboardKey.Left:
                    left = true;
                    break;

                    case KeyboardKey.Right:
                    right = true;
                    break;

                    case KeyboardKey.Up:
                    up = true;
                    break;

                    case KeyboardKey.Escape:
                    SuperBus.GetBus().RegisterEvent((new GameEvent{EventType=GameEventType.GameStateEvent, Message="CHANGE_STATE", StringArg1="GAME_PAUSED"}));
                    break;

                    default:
                        break;
                }
            }
            if(action ==  KeyboardAction.KeyRelease){
                switch (key)
                {
                    case KeyboardKey.Left:
                    left = false;
                    break;

                    case KeyboardKey.Right:
                    right = false;
                    break;

                    case KeyboardKey.Up:
                    up = false;
                    break;

                    case KeyboardKey.Escape:
                        break;
                        
                    default:
                        break;
                }
            }
        }
    }
}
