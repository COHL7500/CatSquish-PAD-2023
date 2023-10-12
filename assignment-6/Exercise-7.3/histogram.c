void histogram(int n, int ns[], int max, int freq[])
{
    int i;
    int j;
    int k;

    for (i = 0; i < (max+1); i = i+1)
    {
        k = 0;

        for (j = 0; j < n; j = j+1)
        {
            if (ns[j] == i)
                k = k+1;
        }

        freq[i] = k;
    }
}

void main()
{
    int arr[7];
    int freq[4];

    arr[0] = 1;
    arr[1] = 2;
    arr[2] = 1;
    arr[3] = 1;
    arr[4] = 1;
    arr[5] = 2;
    arr[6] = 0;

    histogram(7, arr, 3, freq);

    int l;

    for (l = 0; l < 4; l = l+1)
    {
        print freq[l];
    }
}
