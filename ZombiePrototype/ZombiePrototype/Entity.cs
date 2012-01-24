using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZombiePrototype
{
    public abstract class Entity
    {
        protected Vector2 pos;
        protected Vector2 speed;
        protected Boolean status;

        /// <summary>
        ///  Sets entity details based on either project configurations (todo)
        ///  or just manually determined in code (Utils class).
        /// </summary>
        public Entity()
        {
            pos = Utils.generateLocationVector();
        }

        /// <summary>
        ///  Sets entity details manually.
        /// </summary>
        /// <param name="xDimension"></param>
        /// <param name="yDimension"></param>

        public Entity(float xDimension, float yDimension)
        {
            pos = new Vector2(xDimension, yDimension);
        }

        /// <summary>
        ///  An action for every entity object, that the ticker will execute on 
        ///  every child (either zombie or human). Method must be overridden
        ///  when implemented by concrete class. 
        /// </summary>
        public abstract void action();

        public Vector2 getPos()
        {
            return pos;
        }
    }
}
