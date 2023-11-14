using System.Collections.Generic;

namespace FtlNavigator;

public class Game
{
    public IReadOnlyList<Beacon> _beacons;

    public Game()
    {
        _beacons = Generate();
    }

    private static IReadOnlyList<Beacon> Generate()
    {
        return new List<Beacon>
        {
            // Row 1
            new Beacon(1, 25, 30, false, new int[] { 7 }),
            new Beacon(2, 90, 25, false,  new int[] { 8, 3 }),
            new Beacon(3, 130, 40, false,  new int[] { 2, 8, 9, 10, 4 }),
            new Beacon(4, 170, 35, false,  new int[] { 3, 10, 5, 11 }),
            new Beacon(5, 225, 25, false,  new int[] { 4, 11, 6 }),
            new Beacon(6, 260, 40, false,  new int[] { 5, 11, 12 }),
            // Row 2
            new Beacon(7, 40, 80, false,  new int[] { 1, 8, 13, 14 }),
            new Beacon(8, 80, 70, false,  new int[] { 2, 3, 9, 13, 7 }),
            new Beacon(9, 110, 80, false,  new int[] { 2, 3, 8, 10, 14, 15 }),
            new Beacon(10, 175, 80, false,  new int[] { 9, 3, 4, 11, 15, 16, 17 }),
            new Beacon(11, 225, 60, true,  new int[] { 4, 5, 6, 10, 12, 16, 17 }),
            new Beacon(12, 260, 80, false,  new int[] { 6, 11, 17, 18 }),
            // Row 3
            new Beacon(13, 30, 110, false,  new int[] { 7, 8, 14 }),
            new Beacon(14, 80, 125, false,  new int[] { 13, 7, 8, 9, 20, 15 }),
            new Beacon(15, 120, 130, false,  new int[] { 9, 10, 14, 20, 21 }),
            new Beacon(16, 190, 125, false,  new int[] { 10, 11, 17, 22, 23 }),
            new Beacon(17, 230, 110, false,  new int[] { 11, 12, 10, 16, 23, 18 }),
            new Beacon(18, 255, 120, false,  new int[] { 17, 12, 23, 24 }),
            // Row 4
            new Beacon(19, 40, 175, false,  new int[] { 20 }),
            new Beacon(20, 90, 155, false,  new int[] { 14, 15, 19, 21 }),
            new Beacon(21, 130, 175, false,  new int[] { 20, 15, 22 }),
            new Beacon(22, 180, 165, false,  new int[] { 16, 21, 23 }),
            new Beacon(23, 205, 160, false,  new int[] { 16, 17, 18, 22, 24 }),
            new Beacon(24, 265, 165, false,  new int[] { 18, 23 }),
        };
    }
}