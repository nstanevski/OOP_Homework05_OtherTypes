namespace _03_GenericList.Interfaces
{
    interface IGenericList<T>
    {
        void Add(T newElement);
        T this[int index] { get; set; }
        void Remove(int index);
        void Insert(T newElement, int index);
        void Clear();
        int FindIndex(T val);
        bool Contains(T val);
        T Min();
        T Max();
    }
}
