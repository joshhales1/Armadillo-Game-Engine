using System;
using System.Collections.Generic;

namespace ArmadilloEngine
{
    public static partial class Game
    {
        static class Renderer
        {
            static List<SpriteRenderer> SpritesForRender = new List<SpriteRenderer>();

            static int RenderMode;


            static char[,] OldBuffer;
            static char[,] CurrentBuffer;

            static string LoopDebugMessage = "";

            public static void Start(Vector windowDimensions, int renderMode)
            {
                Console.CursorVisible = false;
                RenderMode = renderMode;
                SetGameWindowSize(windowDimensions);
                OldBuffer = GenerateBuffer();
                CurrentBuffer = GenerateBuffer();
            }

            public static void Render()
            {
                OldBuffer = CurrentBuffer;
                CurrentBuffer = GenerateBuffer();

                //Game
                try
                {
                    for (int x = 0; x < CurrentBuffer.GetLength(0); x++)
                        for (int y = 0; y < CurrentBuffer.GetLength(1); y++)
                        {
                            if (OldBuffer[x, y] != CurrentBuffer[x, y])
                            {
                                Console.SetCursorPosition(x * RenderMode, y);
                                Console.Write("\b" + CurrentBuffer[x, y]);
                                if (RenderMode == 2)
                                {
                                    Console.SetCursorPosition(x * 2 + 1, y);
                                    Console.Write("\b" + CurrentBuffer[x, y]);
                                }
                            }
                        }
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArmadilloEngineException("Do not manually resize the game window");
                }

                //Debug
                string newloopMessage = Debug.RecentMessage;
                LoopDebugMessage = newloopMessage.PadRight(
                    newloopMessage.Length < LoopDebugMessage.Length ? LoopDebugMessage.Length : 0,
                    " "[0]);


                for (int i = 0; i < LoopDebugMessage.Length; i++)
                {
                    Console.SetCursorPosition(i + 1, 0);
                    if (i > Console.BufferWidth + 1)
                        break;
                    else
                        Console.Write("\b" + LoopDebugMessage[i]);
                }
            }

            static char[,] GenerateBuffer()
            {
                char[,] grid = BufferTemplate();
                foreach (SpriteRenderer sprite in SpritesForRender)
                {
                    Vector offset = sprite.Owner.GetComponent<Transform>().Position;
                    Vector dimensions = sprite.Dimensions;

                    for (int x = 0; x < dimensions.x; x++)
                        for (int y = 0; y < dimensions.y; y++)
                        {
                            int xPos = (int)offset.x + x;
                            int yPos = (int)offset.y + y;
                            if (xPos > Console.BufferWidth / RenderMode - 1 || xPos < 0 || yPos > Console.BufferHeight - 1 || yPos < 0) continue;
                            grid[(int)offset.x + x, (int)offset.y + y] = sprite.SpriteText[x, y];
                        }
                }
                SpritesForRender.Clear();
                return grid;
            }

            static void SetGameWindowSize(Vector a)
            {
                if (a.x < 16 || a.y < 16)
                    throw new ArmadilloEngineException("Console window dimensions cannot be smaller than 16.");

                Console.SetWindowSize(1, 1);
                Console.SetBufferSize((int)a.x * RenderMode, (int)a.y);
                Console.SetWindowSize((int)a.x * RenderMode, (int)a.y);
            }

            static char[,] BufferTemplate() => new char[Console.BufferWidth / RenderMode, Console.BufferHeight];

            public static void AddSprite(SpriteRenderer sprite) => SpritesForRender.Add(sprite);


        }
    }
    
}
