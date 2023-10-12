using System;
using System.Collections.Generic;

int[] Merge(int[] xs, int[] ys)
{
    int i = 0;
    int j = 0;
    int k = 0;
    int[] mergedArr = new int[xs.Length + ys.Length];

    while (i < xs.Length && j < ys.Length)
    {
        if (xs[i] < ys[j])
        {
            mergedArr[k] = xs[i];
            i++;
        }
        else
        {
            mergedArr[k] = ys[j];
            j++;
        }

        k++;
    }

    while (i < xs.Length)
    {
        mergedArr[k] = xs[i];
        i++;
        k++;
    }

    while (j < ys.Length)
    {
        mergedArr[k] = ys[j];
        j++;
        k++;
    }

    return mergedArr;
}

int[] xs = { 3, 5, 12 };
int[] ys = { 2, 3, 4, 7 };

foreach (var item in Merge(xs, ys))
{
    Console.WriteLine(item.ToString());
}
