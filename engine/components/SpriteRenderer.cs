using System;

namespace ArmadilloEngine
{
    class SpriteRenderer : Component
    {
        public Vector Dimensions { get; private set; }
        public char[,] SpriteText { get; private set; }

        public void SetSprite(char[,] sprite)
        {
            SpriteText = sprite;
            Dimensions = new Vector(sprite.GetLength(0), sprite.GetLength(1));
        }

        public static char[,] StringToSpriteText(string str, int width, int height)
        {
            char[,] sprite = new char[width, height];
            int z = 0;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    sprite[x, y] = str[z];
                    z++;
                }                   

            return sprite;
        }
    }
}
