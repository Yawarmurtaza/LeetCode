/// <summary>
/// Adds the numbers of linked list 1 and linked list 2 and returns the head node of summed linked list.
/// </summary>
/// <param name="l1"></param>
/// <param name="l2"></param>
/// <returns></returns>
public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    if (l1 == null || l2 == null)
    {
        return null;
    }

    Stack<int> s1 = new Stack<int>();
    while (l1 != null)
    {
        s1.Push(l1.val);
        l1 = l1.next;
    }

    Stack<int> s2 = new Stack<int>();
    while (l2 != null)
    {
        s2.Push(l2.val);
        l2 = l2.next;
    }

    double sum1 = 0;

    while (s1.Count != 0)
    {
        double temp = s1.Pop();
        for (int i = 0; i < s1.Count; i++)
        {
            temp *= 10;
        }

        sum1 += temp;
    }

    double sum2 = 0;
    while (s2.Count!=0)
    {
        double temp = s2.Pop();
        for (int i = 0; i < s2.Count; i++)
        {
            temp *= 10;
        }

        sum2 += temp;
    }


    double total = sum1 + sum2;
    Queue<int> resultQueue = new Queue<int>();
    do
    {
        double t = total % 10;
        resultQueue.Enqueue((int)t);

        total = total / 10;

    } while ((int)total != 0);

    ListNode head = new ListNode(resultQueue.Dequeue());
    ListNode tail = head;
    while (resultQueue.Count!=0)
    {
        tail.next = new ListNode(resultQueue.Dequeue());
        tail = tail.next;
    }

    return head;
}
