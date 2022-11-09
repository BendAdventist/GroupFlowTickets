namespace GroupFlowTickets;

public static class Extensions
{
    public static void SortBy<T, TKey>(this List<T> list, Func<T,TKey> keySelector) where TKey : IComparable
    {
        list.Sort((x, y) => keySelector(x).CompareTo(keySelector(y)));
    }
}