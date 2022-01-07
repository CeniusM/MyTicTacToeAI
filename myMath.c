#include<stdio.h>

int main()
{
    printf("hi");

    return 0;
}

int add(int x, int y) // will this cause memoryleak
{
    return x + y;
}