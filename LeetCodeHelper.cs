using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeHelper
{
	public class Pair<T1, T2>
    {
        public T1 first;
        public T2 second;

        public Pair(T1 f, T2 s)
        {
            this.first = f;
            this.second = s;
        }
        public override string ToString()
        {
        	return string.Format("[{0}, {1}]", first.ToString(), second.ToString());
        }
    }

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
        public override string ToString()
        {
            if (left == null && right == null)
                return val.ToString();
            else if (left != null && right == null)
                return string.Format("{0} ({1}, null)", val.ToString(), left);
            else if (left == null && right != null)
                return string.Format("{0} (null, {1})", val.ToString(), right);
            else
                return string.Format("{0} ({1}, {2})", val.ToString(), left, right);
        }
    }

    public static class LeetCodeHelper
    {
        public static void Print<T>(this IEnumerable<T> list)
        {
            StringBuilder sb = new StringBuilder();
            if (list == null)
                throw new Exception("The `list` is null. ");

            if (!list.Any())
                Print(" ");
            else
            {
                foreach (var t in list)
                {
                    sb.Append(t).Append(", ");
                }
                string s = sb.ToString();
                Print(s.Substring(0, s.LastIndexOf(',')));
            }
        }

        public static void Print(this ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            bool isCircle = false;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    isCircle = true;
                    break;
                }
            }

            if (isCircle)
            {
                fast = head;
                while (fast != slow)
                {
                    fast = fast.next;
                    slow = slow.next;
                }

                PrintListWithCircle(head, fast);
            }
            else
            {
                PrintList(head);
            }
        }

        private static void PrintList(ListNode head)
        {
            StringBuilder sb = new StringBuilder();
            while (head != null)
            {
                sb.Append(head.val).Append(" -> ");
                head = head.next;
            }

            sb.Append("null");
            Print(sb.ToString());
        }

        private static void PrintListWithCircle(ListNode head, ListNode node)
        {
            bool isTouch = false;
            StringBuilder sb = new StringBuilder();
            while (head != null)
            {
                if (head == node)
                {
                    if (isTouch)
                    {
                        sb.AppendFormat("({0})", node.val);
                        break;
                    }
                    else
                        isTouch = true;
                }

                sb.Append(head.val).Append(" -> ");
                head = head.next;
            }

            Print(sb.ToString());
        }

        public static ListNode ToList(this IEnumerable<int> list)
        {
            if (list == null || !list.Any())
                return null;

            ListNode dummy = new ListNode(-1);
            ListNode res = dummy;
            foreach (int num in list)
            {
                ListNode node = new ListNode(num);
                dummy.next = node;
                dummy = dummy.next;
            }
            return res.next;
        }

        public static ListNode ToListWithCircle(this IEnumerable<int> list, int index = 0)
        {
            if (list == null || !list.Any())
                return null;

            if (index >= list.Count())
                throw new Exception("The `index` is invalid. ");

            ListNode dummy = new ListNode(-1);
            ListNode res = dummy;
            ListNode store = null;
            int i = 0;
            foreach (int num in list)
            {
                ListNode node = new ListNode(num);
                if (i == index)
                    store = node;

                dummy.next = node;
                dummy = dummy.next;
                i++;
            }

            dummy.next = store;
            return res.next;
        }

        public static void Print(this TreeNode node)
        {
            if(node == null)
                Print("null");
            else
            {
                Print(node.ToString());
            }
        }

        public static TreeNode ToTree(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            int i = 0;
            int j = s.Length - 1;
            while (s[i] == '[' || s[i] == ' ' || s[i] == ']') ++i;
            while (s[j] == '[' || s[j] == ' ' || s[j] == ']') --j;

            s = s.Substring(i, j - i + 1);
            string[] arr = s.Split(',');
            return arr.ToTree();
        }

        public static TreeNode ToTree(this IList<int> arr)
        {
            if (arr == null || arr.Count <= 0)
                return null;
            return CreateTree(arr, 0);
        }

        public static TreeNode ToTree(this string[] arr)
        {
            if (arr == null || arr.Length <= 0)
                return null;
            return CreateTree(arr, 0);
        }

        private static TreeNode CreateTree(IList<int> arr, int index)
        {
            if (index >= arr.Count)
                return null;
            TreeNode res = new TreeNode(arr[index]);
            res.left = CreateTree(arr, 2 * index + 1);
            res.right = CreateTree(arr, 2 * index + 2);
            return res;
        }

        private static TreeNode CreateTree(string[] arr, int index)
        {
            if (index >= arr.Length)
                return null;
            string cur = arr[index].Trim();
            TreeNode res = cur == "null" ? null : new TreeNode(int.Parse(arr[index]));
            if (res == null)
                return null;

            res.left = CreateTree(arr, 2 * index + 1);
            res.right = CreateTree(arr, 2 * index + 2);
            return res;
        }

        private static void Print(string s)
        {
            //todo
            UnityEngine.Debug.LogError(s);
        }
    }
}


