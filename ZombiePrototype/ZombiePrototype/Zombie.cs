using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZombiePrototype
{
    public class Zombie : Entity
    {
        public Zombie()
            : base()
        {
            speed = Utils.generateDirectionVector();

            while (speed.X == 0 && speed.Y == 0)
                speed = Utils.generateDirectionVector();
        }

        public Zombie(float xDimension, float yDimension)
            : base(xDimension, yDimension)
        {
            throw new NotImplementedException();
        }

        public override void action()
        {
            pos += speed;

            int MaxX = Utils.X_DIMENSION_SIZE - Utils.X_ENTITY_SIZE;
            int MinX = 0;

            int MaxY = Utils.Y_DIMENSION_SIZE - Utils.Y_ENTITY_SIZE;
            int MinY = 0;

            if (pos.X > MaxX)
            {
                speed.X *= -1;
                pos.X = MaxX;
            }
            else if (pos.X < MinX)
            {
                speed.X *= -1;
                pos.X = MinX;
            }

            if (pos.Y > MaxY - 120)
            {
                speed.Y *= -1;
                pos.Y = MaxY - 120;
            }
            else if (pos.Y < MinY)
            {
                speed.Y *= -1;
                pos.Y = MinY;
            }
        }
    }
}
