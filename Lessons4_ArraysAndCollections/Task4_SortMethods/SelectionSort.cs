namespace Task4_SortMethods
{
    public class SelectionSort
    {
        public static void Sort(int[] array, int arrayLength)
        {
            int temp, smallestItem;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                //Предположим, что первый элемент является наименьшим значением
                smallestItem = i;
                for (int j = i + 1; j < arrayLength; j++)
                {
                    //Если какое-либо из оставшихся значений меньше, найдем наименьшее из них
                    if (array[j] < array[smallestItem])
                    {
                        smallestItem = j;
                    }
                }

                //Заменим найденное наименьшее значение текущим значением
                temp = array[smallestItem];
                array[smallestItem] = array[i];
                array[i] = temp;
            }
        }
    }
}