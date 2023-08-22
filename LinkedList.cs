using System.Runtime.InteropServices;

namespace LSRE_3;

unsafe struct Node<T> where T : unmanaged
{
    public static Node<T>* Alloc(T* value)
    {
        var pointer = (Node<T>*)Marshal.AllocHGlobal(sizeof(Node<T>));
        pointer->data = value;
        pointer->next = null;
        return pointer;
    }

    public T* data;
    public Node<T>* next;
}

unsafe struct LinkedList<T> where T: unmanaged
{
    public Node<T>* first;
    public Node<T>* last;

    public static LinkedList<T>* Alloc()
    {
        var pointer = (LinkedList<T>*) Marshal.AllocHGlobal(sizeof(LinkedList<T>));
        pointer->first = null;
        pointer->last = null;
        return pointer;
    }

    public bool Contains(Player* player)
    {
        fixed (Node<T>** pptr = &first)
        {
            while(*pptr != null)
            {
                if (*pptr == player)
                    return true;
            }
            return false;
        }

    }

    public delegate void IterateCallback(T* pointer);

    public void ForEach(IterateCallback callback)
    {
        fixed (Node<T>** pptr = &first)
        {
            while (*pptr != null)
            {
                callback((*pptr)->data);
            }
        }
    }

    public void Add(T* value)
    {
        Node<T>* node = Node<T>.Alloc(value);
        if (first == null)
        {
            first = node;
            last = node;
        } else
        {
            last->next = node;
            last = node;
        }
    }
}