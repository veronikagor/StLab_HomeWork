namespace Task4_SortMethods
{
    public class StoogeSort
    {
        public static void Sort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
                return;

            // Если первый элемент меньше последнего, поменять их местами
            if (array[startIndex] > array[endIndex])
            {
                int t = array[startIndex];
                array[startIndex] = array[endIndex];
                array[endIndex] = t;
            }

            // Если в массиве более 2 элементов
            if (endIndex - startIndex + 1 > 2)
            {
                int temp = (endIndex - startIndex + 1) / 3;

                // Рекурсивная сортировка первых 2/3 элементов 
                Sort(array, startIndex, endIndex - temp);

                // Рекурсивная сортировка последних 2/3 элементов
                Sort(array, startIndex + temp, endIndex);

                // РРекурсивная сортировка первыx 2/3 элементов еще раз для подтверждения
                Sort(array, startIndex, endIndex - temp);
            }
        }
    }
}