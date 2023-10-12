void histogram(int n, int ns[], int max, int freq[])
{
    int i;
    int j;
    int k;

    i = 0;

    while (i < (max+1))
    {
        k = 0;
        j = 0;

        while (j < n)
        {
            if (ns[j] == i)
                k = k+1;
            j = j+1;
        }

        freq[i] = k;
        i = i+1;
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
    l = 0;
    
    while (l < 4)
    {
        print freq[l];
        l = l + 1;
    }
}