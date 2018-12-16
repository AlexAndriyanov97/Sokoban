using System;
using System.Drawing;
using System.Linq;

namespace Sokoban
{
    public class Map
    {
        private IGameObject[,] mapOfObjects;
        public readonly int MapWidth;
        public readonly int MapHeight;

        public Map(string map)
        {
            const string separator = "\r\n";

            var rows = map.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
            {
                throw new Exception($"Wrong test map '{map}'");
            }

            mapOfObjects = new IGameObject[rows[0].Length, rows.Length];
            
            MapWidth = mapOfObjects.GetLength(0);
            MapHeight = mapOfObjects.GetLength(1);
            for (var x = 0; x < rows[0].Length; x++)
            {
                for (var y = 0; y < rows.Length; y++)
                {
                    mapOfObjects[x, y] = CreateCreatureBySymbol(rows[y][x]);
                }
            }
        }

        private static IGameObject CreateCreatureBySymbol(char c)
        {
            switch (c)
            {
                case 'P':
                    return new Player();
                case 'B':
                    return new Box();
                case 'F':
                    return new Finish();
                case 'W':
                    return new Wall();
                case 'E':
                    return new EmptyCell();
                case ' ':
                    return new EmptyCell();
                default:
                    throw new Exception($"wrong character for IGameObject {c}");
            }
        }
    }
}