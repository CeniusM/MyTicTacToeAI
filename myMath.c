#include<stdio.h>

int main()
{
    printf("hi");

    return 0;
}

int add(int x, int y) // willh this caosue memoryleak
{
    return x + y;
}