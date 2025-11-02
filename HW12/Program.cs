public class Program
{
    public delegate bool ConditionDelegate(int x);

    public static int[] Reverse(int[] array)
    {
        int[] reversed = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            reversed[i] = array[array.Length - 1 - i];
        }
        return reversed;
    }

    public static int[] Sort(int[] array)
    {
        int[] sorted = (int[])array.Clone();
        Array.Sort(sorted);
        return sorted;
    }

    public static bool Any(int[] array, ConditionDelegate condition)
    {
        foreach (int item in array)
        {
            if (condition(item))
                return true;
        }
        return false;
    }

    public static bool All(int[] array, ConditionDelegate condition)
    {
        foreach (int item in array)
        {
            if (!condition(item))
                return false;
        }
        return true;
    }

    public static int FirstOrDefault(int[] array, ConditionDelegate condition)
    {
        foreach (int item in array)
        {
            if (condition(item))
                return item;
        }
        return default;
    }

    public static int LastOrDefault(int[] array, ConditionDelegate condition)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (condition(array[i]))
                return array[i];
        }
        return default;
    }

    public static int[] FindAll(int[] array, ConditionDelegate condition)
    {
        List<int> result = new List<int>();
        foreach (int item in array)
        {
            if (condition(item))
                result.Add(item);
        }
        return result.ToArray();
    }

    public static int FindIndex(int[] array, ConditionDelegate condition)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (condition(array[i]))
                return i;
        }
        return -1;
    }

    public static int FindLastIndex(int[] array, ConditionDelegate condition)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (condition(array[i]))
                return i;
        }
        return -1;
    }

    public static int Sum(int[] array)
    {
        int sum = 0;
        foreach (int item in array)
        {
            sum += item;
        }
        return sum;
    }

    public static Main(string[] args)
    {
        
    }
}