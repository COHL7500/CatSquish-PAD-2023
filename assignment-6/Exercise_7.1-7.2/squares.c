void arrsum(int n, int arr[], int *sump)
{
    int sum;
    int i;
    
    sum = 0;
    i = 0;
    
    while (i < n)
    {
        sum = sum + arr[i];
        print sum;
        i = i + 1;
    }

    *sump = sum;
}

void squares(int n, int arr[])
{
    int i;
    i = 0;
    while (i < n)
    {
        arr[i] = i * i;
        i = i + 1;
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