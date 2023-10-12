void arrsum(int n, int arr[], int *sump)
{
    int sum;
    int i;
    
    sum = 0;
    i = 0;
    
    while (i < n)
    {
        sum = sum + arr[i];
        i = i + 1;
    }

    *sump = sum;
}

void main()
{
    int n;
    int array[4];
    int *sum;

    n = 4;

    array[0] = 7;
    array[1] = 13;
    array[2] = 9;
    array[3] = 8;

    arrsum(n, array, sum);
    print *sum;
}