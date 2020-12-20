using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20
{
    public class Tile
    {
        public long ID { get; set; }
        public char[][] Value { get; set; }
        public Tile Top { get; set; }
        public Tile Right { get; set; }
        public Tile Bottom { get; set; }
        public Tile Left { get; set; }

        public bool Fixed { get; set; } = false;

        public Tile(long id, char[][] values)
        {
            ID = id;
            Value = values;
        }

        public static char[] RightSide(char[][] chars)
        {
            char[] rightSide = new char[chars.Length];
            for (var i = 0; i < chars.Length; i++)
            {
                rightSide[i] = chars[i][chars.Length - 1];
            }

            return rightSide;
        }

        public static char[] LeftSide(char[][] chars)
        {
            char[] leftSide = new char[chars.Length];
            for (var i = 0; i < chars.Length; i++)
            {
                leftSide[i] = chars[i][0];
            }

            return leftSide;
        }

        public void FindNeighbours(List<Tile> tiles)
        {
            foreach(var thisConfig in GetConfigs())
            { 
                foreach(var tile in tiles.Where(s => ID != s.ID).ToList())
                {
                    var otherTileConfigs = tile.GetConfigs();

                    foreach(var config in otherTileConfigs)
                    {
                        if (Top is null && tile.Bottom is null && Enumerable.SequenceEqual(thisConfig[0], config[^1]))
                        {
                            Value = thisConfig;
                            tile.Value = config;
                            
                            Top = tile;
                            tile.Bottom = this;

                            Fixed = true;
                            tile.Fixed = true;

                            tile.FindNeighbours(tiles);
                        }

                        if(Right is null && tile.Left is null && Enumerable.SequenceEqual(RightSide(thisConfig), LeftSide(config)))
                        {
                            Value = thisConfig;
                            tile.Value = config;

                            Right = tile;
                            tile.Left = this;

                            Fixed = true;
                            tile.Fixed = true;

                            tile.FindNeighbours(tiles);
                        }

                        if (Bottom is null && tile.Top is null && Enumerable.SequenceEqual(thisConfig[^1], config[0]))
                        {
                            Value = thisConfig;
                            tile.Value = config;
                            Bottom = tile;
                            tile.Top = this;

                            Fixed = true;
                            tile.Fixed = true;

                            tile.FindNeighbours(tiles);
                        }

                        if (Left is null && tile.Right is null && Enumerable.SequenceEqual(LeftSide(Value), RightSide(config)))
                        {
                            Value = thisConfig;
                            tile.Value = config;
                            Left = tile;
                            tile.Right = this;

                            Fixed = true;
                            tile.Fixed = true;

                            tile.FindNeighbours(tiles);
                        }

                        if (tile.Fixed)
                            break;
                    }
                }

                if (Fixed)
                    break;
            }
        }

        public List<char[][]> GetConfigs()
        {
            //Standard
                // tile.Rotate()
                // tile.Rotate()
                // tile.Rotate()
            // FlipY
                // tile.Rotate()
                // tile.Rotate()
                // tile.Rotate()
            // FlipX
                // tile.Rotate()
                // tile.Rotate()
                // tile.Rotate()

            List<char[][]> configs = new();
            char[][] orig = new char[10][];
            Array.Copy(Value, orig, 10);

            if (Fixed)
            {
                configs.Add(orig);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    char[][] copy = new char[10][];
                    Array.Copy(orig, copy, 10);
                    configs.Add(copy);

                    copy = new char[10][];
                    Array.Copy(orig, copy, 10);
                    copy = FlipH(copy);
                    configs.Add(copy);

                    copy = new char[10][];
                    Array.Copy(orig, copy, 10);
                    copy = FlipV(copy);
                    configs.Add(copy);

                    orig = Rotate(orig);
                }
            }

            return configs;
        }

        public static char[][] Rotate(char[][] tile)
        {
            char[][] chars = new char[tile.Length][];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = new char[tile.Length];
            }

            for (int i = 0; i < tile.Length; i++)
            {
                for (int j = 0; j < tile.Length; j++)
                {
                    chars[i][j] = tile[tile.Length - j - 1][i];
                }
            }

            return chars;
        }

        public static char[][] FlipH(char[][] tile)
        {
            char[][] chars = new char[tile.Length][];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = new char[tile.Length];
            }

            for (int x = 0; x < tile.Length / 2; x++)
            {
                for (int y = 0; y < tile.Length; y++)
                {
                    var temp = tile[y][x];
                    chars[y][x] = tile[y][tile.Length - 1 - x];
                    chars[y][tile.Length - 1 - x] = temp;
                }
            }

            return chars;
        }

        public static char[][] FlipV(char[][] tile)
        {
            char[][] chars = new char[tile.Length][];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = new char[tile.Length];
            }

            for (int x = 0; x < tile.Length; x++)
            {
                for (int y = 0; y < tile.Length / 2; y++)
                {
                    var temp = tile[y][x];
                    chars[y][x] = tile[tile.Length - 1 - y][x];
                    chars[tile.Length - 1 - y][x] = temp;
                }
            }

            return chars;
        }
    }
}
