void arrsum(int n, int arr[], int *sump)
{
    int sum;
    int i;

    sum = 0;

    for (i = 0; i < n; i = i+1)
    {
        sum = sum + arr[i];
        print sum;
    }

    *sump = sum;
}

void squares(int n, int arr[])
{
    int i;

    for (i = 0; i < n; i = i+1)
    {
        arr[i] = i * i;
    }
}

void main()
{
    int n;
    int squareArr[20];
    int *sum;

    n = 20;

    squares(n, squareArr);
    arrsum(n, squareArr, sum);
    print *sum;
}
