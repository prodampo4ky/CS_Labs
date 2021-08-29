
#include <iostream>
#include <time.h>
#include <algorithm>

using namespace std;

void oddEvenSort(int arr[], int n)
{
    bool isSorted = false; // Initially array is unsorted

    while (!isSorted) {
        isSorted = true;

        // Perform Bubble sort on odd indexed element
        for (int i = 1; i <= n - 2; i = i + 2) {
            if (arr[i] > arr[i + 1]) {
                swap(arr[i], arr[i + 1]);
                isSorted = false;
            }
        }

        // Perform Bubble sort on even indexed element
        for (int i = 0; i <= n - 2; i = i + 2) {
            if (arr[i] > arr[i + 1]) {
                swap(arr[i], arr[i + 1]);
                isSorted = false;
            }
        }
    }
    return;
}

int main()
{
    const int num = 100;
    
for (int i = 0; i < num; i++)
    {
        const int f = 99999;
        int arr[f];
        srand(time(NULL));
        // Filling matrix
        for (int i = 0; i < f; i++)
        {
            arr[i] = 1 + rand() % 10000;
        }
        int n = sizeof(arr) / sizeof(arr[0]);
        oddEvenSort(arr, n);
        return (0);
    }
}