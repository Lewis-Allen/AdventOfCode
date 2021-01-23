using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    public class HexCell
    {
        public Pos Pos { get; set; }
        public bool White { get; set; }

        public HexCell NE { get; set; }
        public HexCell E { get; set; }
        public HexCell SE { get; set; }
        public HexCell SW { get; set; }
        public HexCell W { get; set; }
        public HexCell NW { get; set; }

        public HexCell(Pos pos, bool white, Dictionary<Pos, HexCell> lookup)
        {
            Pos = pos;
            White = white;
            lookup.Add(Pos, this);
        }

        public bool Transverse(Stack<Direction> directions, Dictionary<Pos, HexCell> lookup)
        {
            if(directions.Count == 0)
            {
                White = !White;
                return White;
            }
            else
            {
                var currentDirection = directions.Pop();
                switch (currentDirection)
                {
                    case Direction.NE:
                        if (NE is null)
                        {
                            Pos location = new(Pos.X + 1, Pos.Y + 1);
                            NE = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
                        }
                        return NE.Transverse(directions, lookup);

                    case Direction.E:
                        if (E is null)
                        {
                            Pos location = new (Pos.X + 2, Pos.Y);
                            E = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
                        }
                        return E.Transverse(directions, lookup);

                    case Direction.SE:
                        if (SE is null)
                        {
                            Pos location = new(Pos.X + 1, Pos.Y - 1);
                            SE = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
                        }
                        return SE.Transverse(directions, lookup);

                    case Direction.SW:
                        if (SW is null)
                        {
                            Pos location = new(Pos.X - 1, Pos.Y - 1);
                            SW = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
                        }
                        return SW.Transverse(directions, lookup);

                    case Direction.W:
                        if (W is null)
                        {
                            Pos location = new(Pos.X - 2, Pos.Y);
                            W = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
                        }
                        return W.Transverse(directions, lookup);

                    case Direction.NW:
                        if (NW is null)
                        {
                            Pos location = new(Pos.X - 1, Pos.Y + 1);
                            NW = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
                        }
                        return NW.Transverse(directions, lookup);

                    default:
                        return true;
                }
            }
        }

        public List<HexCell> GetAdjacents(Dictionary<Pos, HexCell> lookup)
        {
            List<HexCell> adj = new();

            if (NE is null)
            {
                Pos location = new(Pos.X + 1, Pos.Y + 1);
                NE = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
            }
            adj.Add(NE);

            if (E is null)
            {
                Pos location = new(Pos.X + 2, Pos.Y);
                E = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
            }
            adj.Add(E);

            if (SE is null)
            {
                Pos location = new(Pos.X + 1, Pos.Y - 1);
                SE = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
            }
            adj.Add(SE);

            if (SW is null)
            {
                Pos location = new(Pos.X - 1, Pos.Y - 1);
                SW = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
            }
            adj.Add(SW);

            if (W is null)
            {
                Pos location = new(Pos.X - 2, Pos.Y);
                W = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
            }
            adj.Add(W);

            if (NW is null)
            {
                Pos location = new(Pos.X - 1, Pos.Y + 1);
                NW = lookup.ContainsKey(location) ? lookup[location] : new HexCell(location, true, lookup);
            }
            adj.Add(NW);

            return adj;
        }
    }
}
