namespace Task4_SortMethods
{
    public class StoogeSort
    {
        /// <summary>
        /// Если первый элемент меньше последнего, поменять их местами.
        /// Затем, если в массиве более 2 элементов сделать рекурсивную сортировку первых 2/3 элементов,
        /// затем последние 2/3 элементов, и еще раз для подтверждения первые 2/3 элементов. 
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public static void Sort(int[] array, int startIndex, int endIndex)
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

                Sort(array, startIndex, endIndex - temp);

                Sort(array, startIndex + temp, endIndex);

                Sort(array, startIndex, endIndex - temp);
            }
        }
    }
}