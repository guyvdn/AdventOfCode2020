using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day17
{
    public class ConwayCubes
    {
        private HashSet<string> _activeCubes = new();
        private int _minX;
        private int _maxX;
        private int _minY;
        private int _maxY;
        private int _minZ;
        private int _maxZ;
        private int _minW;
        private int _maxW;

        public ConwayCubes(IReadOnlyList<string> input)
        {
            _maxX = input.Count;
            _maxY = input.Count;
            _maxZ = 1;
            _maxW = 1;

            for (var x = _minX; x < _maxX; x++)
                for (var y = _minY; y < _maxY; y++)
                    if (input[y][x] == '#')
                        _activeCubes.Add(PositionToKey(x, y, 0, 0));
        }

        private static string PositionToKey(in int x, in int y, in int z, in int w)
        {
            return $"{x}|{y}|{z}|{w}";
        }

        public int ActiveCubes => _activeCubes.Count;

        public void Cycle3D(int times)
        {
            Cycle(times, Expand3D, Activate3D);
        }

        public void Cycle4D(int times)
        {
            Cycle(times, Expand4D, Activate4D);
        }

        private void Cycle(int times, Action expandFunction, Func<int, int, int, int, bool> activateFunction)
        {
            for (var time = 1; time <= times; time++)
            {
                expandFunction();

                var newState = new HashSet<string>();

                for (var x = _minX; x < _maxX; x++)
                    for (var y = _minY; y < _maxY; y++)
                        for (var z = _minZ; z < _maxZ; z++)
                            for (var w = _minW; w < _maxW; w++)
                                if (activateFunction(x, y, z, w))
                                    newState.Add(PositionToKey(x, y, z, w));

                _activeCubes = newState;
            }
        }

        private bool Activate3D(int x, int y, int z, int w)
        {
            var activeNeighbours = 0;

            for (var nX = -1; nX <= 1; nX++)
                for (var nY = -1; nY <= 1; nY++)
                    for (var nZ = -1; nZ <= 1; nZ++)
                        if (_activeCubes.Contains(PositionToKey(x + nX, y + nY, z + nZ, w)))
                            activeNeighbours++;

            return activeNeighbours == 3 || (activeNeighbours == 4 && _activeCubes.Contains(PositionToKey(x, y, z, w)));
        }

        private bool Activate4D(int x, int y, int z, int w)
        {
            var activeNeighbours = 0;

            for (var nX = -1; nX <= 1; nX++)
                for (var nY = -1; nY <= 1; nY++)
                    for (var nZ = -1; nZ <= 1; nZ++)
                        for (var nW = -1; nW <= 1; nW++)
                            if (_activeCubes.Contains(PositionToKey(x + nX, y + nY, z + nZ, w + nW)))
                                activeNeighbours++;

            return activeNeighbours == 3 || (activeNeighbours == 4 && _activeCubes.Contains(PositionToKey(x, y, z, w)));
        }

        private void Expand3D()
        {
            _minX--;
            _maxX++;
            _minY--;
            _maxY++;
            _minZ--;
            _maxZ++;
        }

        private void Expand4D()
        {
            Expand3D();
            _minW--;
            _maxW++;
        }
    }
}