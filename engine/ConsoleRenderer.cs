using System;
using System.Collections.Generic;

namespace ArmadilloEngine
{
    static class Renderer
    {
        static List<SpriteRenderer> SpritesForRender = new List<SpriteRenderer>();
        public static Vector GameWindowDimensions = new Vector(20, 20);

        public static byte RenderMode = DoubleChar;

        static char[,] OldBuffer = new char[0, 0];
        static char[,] CurrentBuffer = new char[0, 0];


        public static void Render()
        {
            OldBuffer = CurrentBuffer;
            CurrentBuffer = GenerateBuffer();

            for (int x = 0; x < OldBuffer.GetLength(0); x++)
                for (int y = 0; y < OldBuffer.GetLength(1); y++)
                {
                    if (OldBuffer[x, y] != CurrentBuffer[x, y])
                    {
                        if (OldBuffer[x, y] != CurrentBuffer[x, y])
                        {
                            unmatched = true;
                            break;
                        }
                        if (unmatched) break;
                    }
                if (!unmatched) return;
            } else
            {
                SpecialRender = false;
            }

            Console.Clear();
            for (int y = 0; y < GameWindowDimensions.y; y++)                
            {
                for (int x = 0; x < GameWindowDimensions.x; x++)
                {
                    Console.Write(CurrentBuffer[x, y]);
                    if (RenderMode == DoubleChar) Console.Write(CurrentBuffer[x, y]);
                }
                Console.Write("\n");
            }
            SpritesForRender.Clear();                
        }

        public static void RequestRender()
        {
            SpecialRender = true;
        }

        static char[,] GenerateBuffer()
        {
            char[,] grid = new char[(int)GameWindowDimensions.x, (int)GameWindowDimensions.y];

            foreach (SpriteRenderer sprite in SpritesForRender)
            {
                Vector offset = sprite.Owner.GetComponent<Transform>().Position;
                Vector dimensions = sprite.Dimensions;
                for (int x = 0; x < dimensions.x; x++)
                    for (int y = 0; y < dimensions.y; y++)
                    {
                        int xPos = (int)offset.x + x;
                        int yPos = (int)offset.y + y;
                        if (xPos > GameWindowDimensions.x - 1 || xPos < 0 || yPos > GameWindowDimensions.y - 1 || yPos < 0) continue;
                        grid[(int)offset.x + x, (int)offset.y + y] = sprite.SpriteText[x, y];
                    }
                        
            }
            return grid;
        }

        public static void AddSprite(SpriteRenderer sprite) => SpritesForRender.Add(sprite);

        public static byte SingleChar = 0;
        public static byte DoubleChar = 0;
    }
}
