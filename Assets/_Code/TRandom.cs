using System.Collections;
using System.Collections.Generic;
using System;

public static class TRandom
{
    private static Random random = new Random();

    public static int RandomIndex(int minValue, int maxValue) =>
        random.Next(minValue, maxValue);

    public static byte[] RandomByteIndex(byte count, int start, int end)
    {
        byte[] buffer = new byte[count];
        random.NextBytes(buffer);

        return buffer;
    }

    public static T RandomItemMass<T>(T[] array) =>
        array[random.Next(0, array.Length)];

    public static T RandomItemList<T>(List<T> list) =>
        list[random.Next(0, list.Count)];

    public static double RandomFloatingPoint(double minValue, double maxValie) =>
        random.NextDouble() * (maxValie - minValue) + minValue;
}
