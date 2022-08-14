using System.IO;
using System.Collections.Generic;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace SuperMarioBroski{
    public class Generator {
        private float xStartpoint = -0.1f;
        private float y = 0.0f;
        public EntityContainer <Block> blockEntities;

        /// <summary> The 'Generator' constructor is used to instantiate a generator object that is used to render the mapdata from the levelfiles.
        /// </summary>
        /// <remarks> 
        /// </remarks>
        /// <param name = ""> Takes no argument.
        /// </param>
        /// <returns> The instantiated object.
        /// </returns>
        public Generator(){                    
            blockEntities = new EntityContainer<Block>();
        }

        /// <summary> The 'mapGen'-method takes a string as an argument that corresponds to the data provided in the .txt file,
        /// and generates the correct blocks on the correct coordinates and instantiates it in a EntityContainer.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name = "level"> The argument is a string provided by the reader-class, which all has assigned their own responsibility.
        /// </param>
        /// <returns> EntityContainer which is used to render the blocks on the window.
        /// </returns>
        public EntityContainer <Block> mapGen () {
            for (int j = 0; j <= 2; j++){
                for (int i = 0 ; i <= 20; i++){
                    blockEntities.AddEntity(new Block (new DynamicShape (new Vec2F(0.05f+xStartpoint,0.05f+y),
                        new Vec2F(0.05f, 0.05f)), 
                            new Image(Path.Combine("Assets", "Images", "SuperBlock.jpg")),
                                new Image(Path.Combine("Assets", "Images", "SuperBlock.jpg"))));
                    xStartpoint +=0.05f;
                }
                xStartpoint = -0.1f;
                y -=0.05f;
            }
            return blockEntities;
        }
    }
}