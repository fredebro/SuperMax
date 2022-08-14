using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;

namespace SuperMarioBroski {
    public class Block : Entity{
        public IBaseImage image2;
        private DynamicShape shape;
        private bool isColliding;
        public Block(DynamicShape shape, IBaseImage image, IBaseImage _image2) : base(shape, image) {
            this.shape = shape;
            this.image2 =_image2;
        }
        /// <summary> The method 'GetPosition' uses the DIKUArcade library to find the position of the instantiated block.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = ""> Takes no argument.
        /// </param>
        /// <returns> The position of the block-entity.
        /// </returns>
        public Vec2F GetPosition() {
            return shape.Position;
        }        
    }
}