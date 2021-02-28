namespace Lessons4_ArraysAndCollections.CollectionActions
{
    public class ArrayActions
    {
        /// <summary>
        /// Сортировка выбором:
        /// предположим, что первый элемент является наименьшим значением.
        /// Если какое-либо из оставшихся значений меньше, найдем наименьшее из них.
        /// Заменим найденное наименьшее значение текущим значением
        /// </summary>
        /// <param name="array">the array of integers</param>
        public static void SelectionSort(int[] array)
        {
            int temp;
            int indexOfSmallestItem;

            for (int i = 0; i < array.Length - 1; i++)
            {
                indexOfSmallestItem = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[indexOfSmallestItem])
                    {
                        indexOfSmallestItem = j;
                    }
                }

                temp = array[indexOfSmallestItem];
                array[indexOfSmallestItem] = array[i];
                array[i] = temp;
            }
        }

        /// <summary>
        /// Сортировка по частям:
        /// если первый элемент меньше последнего, поменять их местами.
        /// Затем, если в массиве более 2 элементов сделать рекурсивную сортировку первых 2/3 элементов,
        /// затем последние 2/3 элементов, и еще раз для подтверждения первые 2/3 элементов. 
        ///
        /// </summary>
        /// <param name="array">the array of integers</param>
        public static void StoogeSort(int[] array)
        {
            int startIndex = 0;
            StoogeSort(array, startIndex, array.Length - 1);
        }

        public static void StoogeSort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
                return;

            if (array[startIndex] > array[endIndex])
            {
                int temp = array[startIndex];
                array[startIndex] = array[endIndex];
                array[endIndex] = temp;
            }

            if (endIndex - startIndex + 1 > 2)
            {
                int temp = (endIndex - startIndex + 1) / 3;

                StoogeSort(array, startIndex, endIndex - temp);

                StoogeSort(array, startIndex + temp, endIndex);

                StoogeSort(array, startIndex, endIndex - temp);
            }
        }
    }
}