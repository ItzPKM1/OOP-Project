namespace deliverySystem.DSA
{
public class CustomStack<T>
{
    //Attributes are an array list or storage
    private T[] arr;
    private int count;
    

    public CustomStack(int capacity)
    {
        if (capacity <= 0)
        {
            throw new CustomException.CustomException.InvalidDataException("Capacity must be greater than zero.");
        }
        arr = new T[capacity];
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

//methods. these are like what we learned in python scripting class.
    public void Push(T item)
    {
        if (count == arr.Length)
        {
            throw new CustomException.CustomException.EmptyStructureException("Stack is full.");
        }
        arr[count] = item;
        count++;
    }

    public T Pop() // for a stack you pop the last item, but for a queue you pop the first item.
    {
        if (count == 0)
        {
            throw new CustomException.CustomException.EmptyStructureException("Stack is empty.");
        }
        count--;
        T item = arr[count]; // not count -1 because that would return the second to the top item. corrected.
        arr[count] = default(T);
        // removed accidental count--
        return item;
    }

    public T Peek() // peek is in front for a queue, but for top peek is the last item.
    {
        if (count == 0)
        {
            throw new CustomException.CustomException.EmptyStructureException("Stack is empty.");
        }
        return arr[count - 1];
    }

    public bool IsEmpty()
    {
        return count == 0;  
    }
}
}