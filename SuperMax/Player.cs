using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Timers;
using DIKUArcade.Physics;


namespace SuperMarioBroski{
        public class Player : Entity{
        private const float Movement_Speed = 0.025f;
        private DynamicShape shape;
        public bool isColliding = false;
        public Player(DynamicShape shape, IBaseImage image) : base(shape, image)
        {
            this.shape = shape;
        }

        /// <summary> The method 'Boundaries' defines the coordinates for which the map inside the window is defined.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = ""> Takes no param.
        /// </param>
        /// <returns> void
        /// </returns>

        // mangler Y koordinat boundaries.
        private void Boundaries() {
            if (shape.Position.X > 0.9f) {
                    shape.Position.X = 0.9f;
                } else if (shape.Position.X < 0.0f) {
                    shape.Position.X = 0.0f;
                }
        }

        /// <summary> The method 'moveleft' take a boolean value, checks with the Boundaries method, and then moves the shape of the player according to the Movement_Speed-field.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = ""> The boolean value concerning whether to move or not.
        /// </param>
        /// <returns> void
        /// </returns>
        public void moveleft(bool val){
            Boundaries();
            if(val){
                this.shape.Position.X-=Movement_Speed;
            }
        }

        /// <summary> The method 'moveleft' take a boolean value, checks with the Boundaries method, and then moves the shape of the player according to the Movement_Speed-field.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = ""> The boolean value concerning whether to move or not.
        /// </param>
        /// <returns> void
        /// </returns>
        public void moveright(bool val, Block block){
            Boundaries();
            float tempPosition = this.shape.Position.X;
            if(CollisionDetection.Aabb(this.shape.AsDynamicShape(), block.Shape).Collision){
                this.shape.Position.X = tempPosition;
            }
            if(val){
                this.shape.Position.X+=Movement_Speed;        
            }
        }

        public void Collision (Block block){
            // float tempPosition = player.shape.Position.Y;
            System.Console.WriteLine(CollisionDetection.Aabb(this.Shape.AsDynamicShape(), block.Shape).Collision);

            if(CollisionDetection.Aabb(this.Shape.AsDynamicShape(), block.Shape).Collision){
                System.Console.WriteLine("COLLISION");
                isColliding = true;
            }

            // if (this.GetPosition() == block.GetPosition()){
            //     System.Console.WriteLine("COLLISION");
            //     isColliding = true;
            // }
            // if (CollisionDetection.Aabb(new DynamicShape (new Vec2F(this.Shape.Position.X, this.Shape.Position.Y), new Vec2F(this.Shape.Extent.X, this.Shape.Extent.Y)).AsDynamicShape(), block.Shape).Collision){
            //     System.Console.WriteLine("COLLISION");
            //     isColliding = true;
            // }

            // if(CollisionDetection.Aabb(this.Shape.AsDynamicShape(), block.Shape).Collision){
            //     System.Console.WriteLine("COLLISION");
            //     isColliding = true;
            // }
            // blocks.Iterate(block => {
            //     if(CollisionDetection.Aabb(this.Shape.AsDynamicShape(),block.Shape).Collision){
            //         isColliding = true;
            //         player.shape.Position.Y = tempPosition;
            //         System.Console.WriteLine("COLLISION");
            //     }
            //     else {
            //         this.shape.Position.Y -= 0.00001f;
            //     }
            // });
        }
        // isjumping needs to change to false when hitting objective.
        public void jump(bool val, EntityContainer <Block> blocks, Player player){
            Boundaries();
            if (isColliding && val){
                this.shape.Position.Y += Movement_Speed;
            }
        }

        /// <summary> The 'GetPosition'-method returns the current position of the instatiated player when called.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = ""> Takes no param.
        /// </param>
        /// <returns> A Vec2F-coordinate of the player-entitys position.
        /// </returns>
        public Vec2F GetPosition() {
            return shape.Position;
        }
    }
}