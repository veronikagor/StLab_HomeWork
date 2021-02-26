namespace Task4_SortMethods
{
    public class SelectionSort
    {
        /// <summary>
        /// Предположим, что первый элемент является наименьшим значением.
        /// Если какое-либо из оставшихся значений меньше, найдем наименьшее из них.
        /// Заменим найденное наименьшее значение текущим значением
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayLength"></param>
        public static void Sort(int[] array, int arrayLength)
        {
            int temp;
            int smallestItem;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                smallestItem = i;
                for (int j = i + 1; j < arrayLength; j++)
                {
                    if (array[j] < array[smallestItem])
                    {
                        smallestItem = j;
                    }
                }

                temp = array[smallestItem];
                array[smallestItem] = array[i];
                array[i] = temp;
            }
        }
    }
}