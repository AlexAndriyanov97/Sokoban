using System;
using System.Drawing;
using System.Linq;

namespace Sokoban
{
    public class Map
    {
        public IGameObject[,] mapOfObjects;
        public readonly int MapWidth;
        public readonly int MapHeight;
        public Map(string map)
        {
            const string separator = "\n";

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
                    mapOfObjects[x, y] = CreateCreatureBySymbol(rows[y][x], x, y);
                }
            }
        }

        private static IGameObject CreateCreatureBySymbol(char c, int x, int y)
        {
            switch (c)
            {
                case 'P':
                    return new Player(x, y);
                case 'B':
                    return new Box(x,y);
                case 'F':
                    return new Finish(x,y);
                case 'W':
                    return new Wall(x,y);
                case 'E':
                    return new EmptyCell(x,y);
                case ' ':
                    return new EmptyCell(x,y);
                default:
                    throw new Exception($"wrong character for IGameObject {c}");
            }
        }

        public Point? GetPositionOfPlayer()
        {
            foreach (var gameObject in mapOfObjects)
            {
                if (gameObject is Player player)
                {
                    return player.GetPosition();
                }
            }

            return null;
        }

    }
}