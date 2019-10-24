# LeetCodeHelper
Leetcode helper library (pure c# and .NET 4.6), such as convert an array/string to list/tree, print array/tree, etc.

## Part 1

the  DS offered by LeetCode

```c#
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
```

## Part 2: API

#### IEnumerable\<T>

```c#
new int[] { 12, 42, 2, 3, -23, 12 }.Print();
new List<int>() {12, 42, 2, 3, -23, 12 }.Print();
new HashSet<int>() { 12, 42, 2, 3, -23, 12 }.Print();
new SortedSet<int>() { 12, 42, 2, 3, -23, 12 }.Print();

Dictionary<int, int> dic = new Dictionary<int, int>()
{
    [1] = 3,
    [2] = 6,
    [3] = 9
};
dic.Print();
```

#### ListNode

```c#
int[] arr = new int[] { 12, 42, 2, 3, -23, 12 };
ListNode head1 = arr.ToList();
ListNode head2 = arr.ToListWithCircle();
ListNode head3 = arr.ToListWithCircle(3);

head1.Print();
```

#### TreeNode

```c#
int[] arr = new int[] { 12, 42, 2, 3, -23, 12 };
TreeNode root1 = arr.ToTree();
root1.Print();

TreeNode root2 = "[12, 42, 2, null, -23, 12]".ToTree();
root2.Print();
```

  ​ 

---

***To Update***

