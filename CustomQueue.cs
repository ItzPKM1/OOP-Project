namespace deliverySystem.DSA
{
public class CustomQueue<T>
{
    //Attributes are an array list or storage
    private T[] arr;
    private int count;
    

    public CustomQueue(int capacity)
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
    public void Enqueue(T item)
    {
        if (count == arr.Length)
        {
            throw new CustomException.CustomException.OverCapacityException("Queue is full.");
        }
        arr[count] = item;
        count++;
    }

    public T Dequeue()
    {
        //remove and return the item at the front of the queue
        if (count == 0)
        {
            throw new CustomException.CustomException.EmptyStructureException("Queue is empty."); // added our custom exceptions from the CustomException class.
        }
        T item = arr[0];
        for (int i = 1; i < count; i++)
        {
            arr[i - 1] = arr[i];
        }
        arr[count - 1] = default(T); // Clear the last item
        count--;
        return item;
    }

    public T Peek()
    {
        if (count == 0)
        {
            throw new CustomException.CustomException.EmptyStructureException("Queue is empty."); // added our custom exceptions from the CustomException class.
        }
        return arr[0];
    }

    public bool IsEmpty()
    {
        return count == 0;  
    }
}
}