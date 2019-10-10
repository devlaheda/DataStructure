/// <summary>
/// this Class is an application for DS Dynamic array
/// Created by  Lahcen Edaif @ Dev.lah.eda@gmail.com
/// inspired by William Fiset, william.alexandre.fiset@gmail.com
/// </summary>
/// <typeparam name="T"></typeparam>
class DynamicArrays<T> : IEnumerable
{
    private T[] arr;
    private int capacity = 0;
    private int len = 0;

    public DynamicArrays()
    {
    }

    public DynamicArrays(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentException($"Invalid capacity for an array : \" {capacity} \"");
        }

        this.capacity = capacity;
        arr = new T[capacity];
    }

    public int Size => this.len;
    public bool IsEmpty => (this.Size == 0);
    /// <summary>
    /// Get the item in the index provide 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T GetElementAt(int index)
    {
        if (!(index > this.len || IsEmpty))
        {
            return arr[index];
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }
    /// <summary>
    /// change the value of the index provided if it's valid
    /// </summary>
    /// <param name="index"></param>
    /// <param name="element"></param>
    public void SetElementAt(int index, T element)
    {
        if (!(index > this.len || IsEmpty))
        {
            arr[index] = element;
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }
    /// <summary>
    /// Clear the array and free the Memory using GC
    /// </summary>
    public void Clear()
    {
        arr = new T[0];
        len = capacity = 0;
        GC.Collect();
    }

    public void Add(T element)
    {
        if (len + 1 >= capacity || capacity == 0)
        {
            capacity++;
            // Create a temp array 
            T[] tempArray = new T[capacity];
            // move the elements to the temporary array
            for (var i = 0; i < len; i++) tempArray[i] = arr[i];
            arr = tempArray;
        }

        arr[len++] = element;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return arr.GetEnumerator();
    }

    /// <summary>
    /// Removing an item by a giving index if it exist 
    /// </summary>
    /// <param name="index"> index of the item we want to remove
    /// </param>
    /// <returns></returns>
    public T RemoveAt(int index)
    {
        // Defensive programming checking for the index is valid 
        if (index >= len || index < 0)
            throw new IndexOutOfRangeException();
        // Getting the data before deleting it from the array
        var data = arr[index];
        var tempArray = new T[len - 1];
        for (int i = 0, j = 0; i < len; i++, j++)
        {
            // Fixing the value of (j) to skip over the index by (i)
            if (i == index)
                j--;
            else
                tempArray[j] = arr[i];
        }

        capacity = --len;
        arr = tempArray;
        return data;
    }
    /// <summary>
    /// Return the Index Of an item in the array
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int IndexOf(T item)
    {
        for (int i = 0; i < len; i++)
        {
            if (arr[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }
    /// <summary>
    /// Remove an item if it exist in the array and return a boo to indicate the statue of the operation
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index != -1)
        {
            RemoveAt(index);
            return true;
        }
        return false;
    }
    /// <summary>
    /// check if the array Contain the item provided 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(T item) => IndexOf(item) != -1;
}