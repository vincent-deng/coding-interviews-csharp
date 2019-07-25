# coding-interviews-csharp
> 剑指Offer——名企面试官精讲典型编程题C#版  
> 习题来源[牛客网](https://www.nowcoder.com/ta/coding-interviews?page=)

# 剑指Offer
001.数组 二维数组中的查找
> 在一个二维数组中（每个一维数组的长度相同），每一行都按照从左到右递增的顺序排序，每一列都按照从上到下递增的顺序排序。请完成一个函数，输入这样的一个二维数组和一个整数，判断数组中是否含有该整数。
>> 解题思路： 右上角解法，逐渐缩小范围

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
/// <summary>
/// 右上角解题
/// </summary>
/// <param name="array"></param>
/// <param name="target"></param>
/// <returns></returns>
public static bool FindForRight(int[,] array, int target)
{
    bool result = false;

    if (CheckIsArrayRange(array, target))
    {
        int rowLength = array.GetLength(0);
        int colLength = array.GetLength(1);

        int row = 0, col = colLength - 1;//坐标右上角
        while (row < rowLength && col >= 0)
        {
            if (array[row, col] == target)
            {
                result = true;
                break;
            }
            else if (array[row, col] > target)
            {
                col--;
            }
            else
            {
                row++;
            }
        }
    }

    return result;
}

```

</p>
</details>  

002.字符串替换空格
> 请实现一个函数，将一个字符串中的每个空格替换成“%20”。例如，当字符串为We Are Happy.则经过替换之后的字符串为We%20Are%20Happy。
>> 解题思路：移位：1. 遍历字符串，统计出空格数量；2. 再遍历一次，完成替换

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
/// <summary>
/// 赋值给另外一个
/// </summary>
/// <param name="str"></param>
/// <returns></returns>
public static string ReplaceForBS(string str) {
    StringBuilder sb = new StringBuilder();
    foreach (var item in str) {
        if (item == ' ')
        {
            sb.Append("%20");
        }
        else {
            sb.Append(item);
        }
    }
    return sb.ToString();
}
```

</p>
</details>  

003.链表:从尾到头打印链表
> 输入一个链表，按链表值从尾到头的顺序返回一个ArrayList。
>> 解题思路：“先进后出”，也就是栈的功能。

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
/// <summary>
/// 栈的方式实现
/// </summary>
/// <param name="nodes"></param>
/// <returns></returns>
public static List<int> PrintForStack(ListNode nodes)
{
    Stack<ListNode> listNodes = new Stack<ListNode>();
    ListNode node = nodes;
    while (node != null)
    {
        listNodes.Push(node);
        node = node.next;
    }

    List<int> list = new List<int>();
    foreach (var item in listNodes) {
        list.Add(item.item);
    }
    return list;
}
```

</p>
</details>  


004.树:重建二叉树
> 输入某二叉树的前序遍历和中序遍历的结果，请重建出该二叉树。假设输入的前序遍历和中序遍历的结果中都不含重复的数字。例如输入前序遍历序列{1,2,4,7,3,5,6,8}和中序遍历序列{4,7,2,1,5,3,8,6}，则重建二叉树并返回。
>> 解题思路：根据前序遍历，可以知道根节点（1），根据中序遍历可以知道左子树（4,7,2）和右子树（5,3,8,6）。递归：根>左>右。

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static TreeNode Tree(List<int> preTree, List<int> midTree)
{
    if (preTree == null || preTree.Count() == 0 || midTree == null || midTree.Count() == 0)
    {
        return null;
    }

    //根节点
    int rootTree = preTree[0];
    //移除根节点
    preTree.RemoveAt(0);
    TreeNode treeNode = new TreeNode(rootTree);

    //左右子树
    List<int> leftTree = null;
    List<int> tempList = new List<int>();
    bool isTree = false;
    foreach (var item in midTree)
    {
        tempList.Add(item);
        if (item == rootTree)
        {
            isTree = true;
            tempList.Remove(item);
            leftTree = tempList;

            tempList = new List<int>();
        }
    }
    if (!isTree) {
        Console.WriteLine("不是正确的树");
        return null;
    }
    List<int> rightTree = tempList;

    //递归左右节点
    treeNode.left = Tree(preTree, leftTree);
    treeNode.right = Tree(preTree, rightTree);

    return treeNode;
}
```

</p>
</details>  


005.栈和队列:用两个栈实现队列
> 用两个栈来实现一个队列，完成队列的Push和Pop操作。 队列中的元素为int类型。
>> 解题思路：栈：先进后出，队列：先进先出

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public class Coding005
{
    /// <summary>
    /// 出栈
    /// </summary>
    private Stack<int> dequeue;
    /// <summary>
    /// 进栈
    /// </summary>
    private Stack<int> enqueue;

    public Coding005()
    {
        dequeue = new Stack<int>();
        enqueue = new Stack<int>();
    }
    /// <summary>
    /// 出栈（优化）
    /// </summary>
    /// <returns></returns>
    public int Dequeue2()
    {
        //没有数据
        if (enqueue.Count == 0 && dequeue.Count == 0) {
            return -1;
        }

        while (enqueue.Count > 1) {
            var item = enqueue.Pop();
            dequeue.Push(item);
        }

        if (enqueue.Count == 1)
        {
            return enqueue.Pop();
        }
        else {
            return dequeue.Pop();
        }
    }

    /// <summary>
    /// 出栈
    /// </summary>
    /// <returns></returns>
    public int Dequeue()
    {
        //没有数据
        if (enqueue.Count == 0 && dequeue.Count == 0)
        {
            return -1;
        }

        while (enqueue.Count > 0)
        {
            var item = enqueue.Pop();
            dequeue.Push(item);
        }

        return dequeue.Pop();
    }

    /// <summary>
    /// 进栈
    /// </summary>
    /// <param name="item"></param>
    public void Enqueue(int item)
    {
        enqueue.Push(item);
    }

}
```

</p>
</details>  

006.查找和排序:旋转数组的最小数字
> 把一个数组最开始的若干个元素搬到数组的末尾，我们称之为数组的旋转。 输入一个非减排序的数组的一个旋转，输出旋转数组的最小元素。 例如数组{3,4,5,1,2}为{1,2,3,4,5}的一个旋转，该数组的最小值为1。 NOTE：给出的所有元素都大于0，若数组大小为0，请返回0。
>> 解题思路：查找最小值，方法很多。

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static int MinForBinary(int[] data)
{
    if (data == null) return 0;

    int left = 0;
    int right = data.Length - 1;
    var mid = 0;
    while (left < right)
    {
        mid = (left + right) / 2;
        if (data[mid] > data[right]) left = mid + 1;
        else if (data[mid] < data[right]) right = mid;
        else right = mid;
    }

    return data[left];
}
```

</p>
</details>  

007.递归和循环:斐波那契数列
> 大家都知道斐波那契数列，现在要求输入一个整数n，请你输出斐波那契数列的第n项（从0开始，第0项为0）。
n<=39
>> 解题思路：循环实现，不要动不动就递归
<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static int Fibonacci2(int n)
{
    if (n <= 1) return n;

    int first = 0;
    int second = 1;
    int result = 0;
    for (int i = 2; i <= n; i++)
    {
        result = first + second;
        first = second;
        second = result;
    }

    return result;
}
```

</p>
</details>  


008.递归和循环:跳台阶
> 一只青蛙一次可以跳上1级台阶，也可以跳上2级。求该青蛙跳上一个n级的台阶总共有多少种跳法（先后次序不同算不同的结果）。
>> 解题思路：：循环实现

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static int Jump(int n) {
    if (n <= 2) {
        return n;
    }

    int first = 1;
    int second = 2;
    int result = 0;
    for (int i = 3; i <= n; i++) {
        result = first + second;
        first = second;
        second = result;
    }

    return result;
}
```

</p>
</details>  

009.递归和循环:变态跳台阶
> 一只青蛙一次可以跳上1级台阶，也可以跳上2级……它也可以跳上n级。求该青蛙跳上一个n级的台阶总共有多少种跳法。
>> 解题思路：循环实现

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static int Jump(int n) {
    if (n <= 1) {
        return n;
    }

    int first = 1;
    int result = 0;
    for (int i = 2; i <= n; i++) {
        result = 2 * first;
        first = result;
    }

    return result;
}
```

</p>
</details>  

010.递归和循环:矩形覆盖
> 我们可以用2*1的小矩形横着或者竖着去覆盖更大的矩形。请问用n个2*1的小矩形无重叠地覆盖一个2*n的大矩形，总共有多少种方法？
>> 解题思路：循环实现

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static int Jump(int n) {
    if (n <= 2) {
        return n;
    }

    int first = 1;
    int second = 2;
    int result = 0;
    for (int i = 3; i <= n; i++) {
        result = first + second;
        first = second;
        second = result;
    }

    return result;
}
```

</p>
</details>  

011.位运算:二进制中1的个数
> 输入一个整数，输出该数二进制表示中1的个数。其中负数用补码表示。
>> 解题思路：把一个整数减去1，再和原整数做与运算，会把该整数最右边一个1变成0。

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static int NumberOf1(int n) {
    int count = 0;
    while (n != 0) {
        count++;
        n = (n - 1) & n;
    }
    return count;
}
```

</p>
</details>

012.代码的完整性:数值的整数次方
> 给定一个double类型的浮点数base和int类型的整数exponent。求base的exponent次方。
>> 解题思路：循环连乘，负数的绝对值处理之后倒数

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static double Pow(double baseData, int exponent)
{
    if (baseData == 0)
    {
        return 0;
    }

    bool isPositive = exponent > 0;//是否是正数
    exponent = isPositive ? exponent : -exponent;
    double result = 1;
    for (int i = 0; i < exponent; i++)
    {
        result = result * baseData;
    }
    result = isPositive ? result : (1 / result);
    return result;
}
```

</p>
</details>  

013.代码的完整性:调整数组顺序使奇数位于偶数前面
> 输入一个整数数组，实现一个函数来调整该数组中数字的顺序，使得所有的奇数位于数组的前半部分，所有的偶数位于数组的后半部分，并保证奇数和奇数，偶数和偶数之间的相对位置不变。
>> 解题思路：考虑相对位置，利用第三个数组；不考略相对位置，奇数和偶数前后交换

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static int[] HandleArray(int[] array) {
    if (array == null) return null;
    int[] temp = new int[array.Length];
    int i = 0;
    //奇数
    foreach (var t in array) {
        if (t % 2 == 1) {
            temp[i] = t;
            i++;
        }
    }
    //偶数
    foreach (var t in array)
    {
        if (t % 2 == 0)
        {
            temp[i] = t;
            i++;
        }
    }
    return temp;
}

/// <summary>
/// 不考略相对位置的
/// </summary>
/// <param name="array"></param>
/// <returns></returns>
public static int[] HandleArray2(int[] array)
{
    if (array == null) return null;

    int left = 0;
    int right = array.Length - 1;
    while (left < right)
    {
        //奇数
        while (array[left] % 2 == 1)
        {
            left++;
        }

        //偶数
        while (left < right && array[right] % 2 == 0)
        {
            right--;
        }

        //交换
        if (left < right)
        {
            var temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

    }
    return array;
}
```

</p>
</details>  


014.代码的鲁棒性:链表中倒数第k个结点
> 输入一个链表，输出该链表中倒数第k个结点。
>> 解题思路：双指针法，两个指针相差k-1个节点

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static ListNode FindBackKth(ListNode node, int k) {
    if (node == null || k <= 0) {
        return null;
    }

    ListNode firstNode = node;
    ListNode secondNode = node;
    for (int i = 1; i <= k - 1; i++) {
        firstNode = firstNode.next;
        if (firstNode == null) {
            return null;
        }
    }

    while (firstNode.next != null) {
        firstNode = firstNode.next;
        secondNode = secondNode.next;
    }

    return secondNode;
}
```

</p>
</details>  


015.代码的鲁棒性:反转链表
> 输入一个链表，反转链表后，输出新链表的表头。
>> 解题思路：三个指针，prev，cur，next，cur.next=prev

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
/// <summary>
/// 栈的方式实现(倒过来的链表)
/// </summary>
/// <param name="nodes"></param>
/// <returns></returns>
public static ListNode PrintForReverse(ListNode nodes)
{
    if (nodes == null) return null; 
    Stack<ListNode> listNodes = new Stack<ListNode>();
    ListNode node = nodes;
    while (node != null)
    {
        listNodes.Push(node);
        node = node.next;
    }

    ListNode reverseNode = listNodes.Pop();
    var temp = reverseNode;
    foreach (var item in listNodes)
    {
        item.next = null;
        temp.next = item;
        temp = item;
    }
    return reverseNode;
}

public static ListNode PrintForReverse2(ListNode nodes) {
    ListNode prev = null, node = nodes, next = null;
    while (node != null)
    {
        next = node.next; //保存其下一个节点,相当于临时变量
        node.next = prev; //指针指向反转

        //后移下一轮操作
        prev = node; //保存前一个指针
        node = next; //递增指针, 指向下一个结点
    }

    return prev; //最后prev指针指向的那个节点就是原来的未指针，新的头指针
}
```

</p>
</details>  


016.代码的鲁棒性:合并两个排序的链表
> 输入两个单调递增的链表，输出两个链表合成后的链表，当然我们需要合成后的链表满足单调不减规则。
>> 解题思路：创建一个新的链表，每次比较最小的插入链表中

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static ListNode Merge(ListNode node1, ListNode node2) {
    if (node1 == null) return node2;
    if (node2 == null) return node1;
    ListNode newNode = null;

    if (node1.item <= node2.item)
    {
        newNode = node1;
        newNode.next = Merge(node1.next, node2);
    }
    else {
        newNode = node2;
        newNode.next = Merge(node1, node2.next);
    }

    return newNode;
}
```

</p>
</details>  

017.代码的鲁棒性:树的子结构
> 输入两棵二叉树A，B，判断B是不是A的子结构。（ps：我们约定空树不是任意一个树的子结构）
>> 解题思路：1.查找根节点，2.比较左右节点，两个都是递归 

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
/// <summary>
/// check 左右子树是否相同
/// </summary>
/// <param name="parent"></param>
/// <param name="child"></param>
/// <returns></returns>
private static bool CheckLeftAndRightNode(TreeNode parent, TreeNode child)
{
    if (child == null) return true; //子树为NULL，那么必然是子树
    if (parent == null) return false; //子树不是空，父树为空

    if (child.val != parent.val)
    {
        return false;
    }
    else {
        return CheckLeftAndRightNode(parent.left, child.left) & CheckLeftAndRightNode(parent.right, child.right);
    }
}

/// <summary>
/// 查找子树
/// </summary>
/// <param name="parent"></param>
/// <param name="child"></param>
/// <returns></returns>
public static bool HasSubTree(TreeNode parent, TreeNode child)
{
    if (parent == null || child == null) return false;
    bool result = false;
    if (parent.val == child.val)
    {
        result = CheckLeftAndRightNode(parent, child);
    }

    if (!result)
    {
        result = HasSubTree(parent.left, child) || HasSubTree(parent.right, child);
    }
    return result;
}
```

</p>
</details>  


018.面试思路:二叉树的镜像
> 操作给定的二叉树，将其变换为源二叉树的镜像。
>> 解题思路：镜像：对称。左右节点交换，递归

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static void Mirror(TreeNode node) {
    if (node==null) return;

    var temp = node.left;
    node.left = node.right;
    node.right = temp;

    Mirror(node.left);
    Mirror(node.right);
}
```

</p>
</details>  

019.画图让抽象形象化:顺时针打印矩阵
> 输入一个矩阵，按照从外向里以顺时针的顺序依次打印出每一个数字，例如，如果输入如下4 X 4矩阵： 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 则依次打印出数字1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10.
>> 解题思路： 从左到右，从上到下，从右到左，从下到上，循环处理

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static List<int> HandleArray(int[,] array)
{
    List<int> data = new List<int>();
    if (array == null) return data;
    int row = array.GetLength(0);
    int col = array.GetLength(1);
    if (row == 0 || col == 0) return data;
    int left = 0, right = col - 1, top = 0, bottom = row - 1;
    while (left <= right && bottom >= top)
    {
        //从左到右
        for (int i = left; i <= right; i++)
        {
            data.Add(array[top, i]); //行不变列变
        }
        top++;

        //从上到下
        if (bottom >= top)
        {
            for (int i = top; i <= bottom; i++)
            {
                data.Add(array[i, right]); //行变列不变
            }
            right--;
        }

        //从右到左
        if (right >= left && bottom >= top)
        {
            for (int i = right; i >= left; i--)
            {
                data.Add(array[bottom, i]); //列变行不变
            }
            bottom--;
        }

        //从下到上
        if (right >= left && bottom >= top)
        {
            for (int i = bottom; i >= top; i--)
            {
                data.Add(array[i, left]);//行变列不变
            }
            left++;
        }
    }

    return data;
}
```

</p>
</details>  

020.举例让抽象具体化:包含min函数的栈
> 定义栈的数据结构，请在该类型中实现一个能够得到栈中所含最小元素的min函数（时间复杂度应为O（1））。
>> 解题思路：两个栈的操作，一个保存数据，一个保存最小值

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public class MinInStack
{
    public Stack<int> dataStack;
    public Stack<int> minStack;

    public MinInStack()
    {
        dataStack = new Stack<int>();
        minStack = new Stack<int>();
    }

    public int Pop()
    {
        if (dataStack.Count == 0) return -1;
        minStack.Pop();
        return dataStack.Pop();
    }

    public void Push(int item)
    {
        dataStack.Push(item);
        if (!minStack.TryPeek(out int data) || data > item) //每次放进去的都是最小值
        {
            minStack.Push(item);
        }
        else
        {
            minStack.Push(data);
        }
    }

    public int Min()
    {
        if (dataStack.Count == 0) return -1;

        return minStack.Peek();
    }
}
```

</p>
</details>  


021. 举例让抽象具体化：栈的压入、弹出序列
> 输入两个整数序列，第一个序列表示栈的压入顺序，请判断第二个序列是否可能为该栈的弹出顺序。假设压入栈的所有数字均不相等。例如序列1,2,3,4,5是某栈的压入顺序，序列4,5,3,2,1是该压栈序列对应的一个弹出序列，但4,3,5,1,2就不可能是该压栈序列的弹出序列。（注意：这两个序列的长度是相等的）
>> 解题思路：弹出的肯定是栈的最顶层，借助辅助栈操作

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static bool IsPopOrder(int[] pushOrder, int[] popOrder)
{
    bool possible = false;
    if (pushOrder != null && popOrder != null && pushOrder.Count() == popOrder.Count())
    {
        int nextPush = 0; // 指向下一个要push的元素的index
        int nextPop = 0;  // 指向下一个要pop的元素的index
        int length = pushOrder.Count();
        Stack<int> stackData = new Stack<int>();

        while (nextPush < length)
        {
            // 当辅助栈的栈顶元素不是要弹出的元素,先压入一些数字入栈
            while (stackData.Count == 0 || stackData.Peek() != popOrder[nextPop])
            {
                // 如果所有数字都压入辅助栈了，退出循环
                if (nextPush == (length - 1))
                {
                    break;
                }

                stackData.Push(pushOrder[nextPush]);
                nextPush++;
            }

            // 说明没有匹配成功
            if (stackData.Peek() != popOrder[nextPop])
            {
                break;
            }

            stackData.Pop();
            nextPop++;
        }

        if (stackData.Count == 0)
        {
            possible = true;
        }
    }

    return possible;
}
```

</p>
</details>  


022. 从上往下打印二叉树
> 从上往下打印出二叉树的每个节点，同层节点从左至右打印。
>> 解题思路：利用队列，先进先出

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
static void PrintFromTopToBottom(TreeNode root,List<int> data)
{
    if (root == null)
    {
        return;
    }

    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    while (queue.Count > 0)
    {
        TreeNode printNode = queue.Dequeue();
        data.Add(printNode.val);

        if (printNode.left != null)
        {
            queue.Enqueue(printNode.left);
        }

        if (printNode.right != null)
        {
            queue.Enqueue(printNode.right);
        }
    }
}
```

</p>
</details>  


023. 二叉搜索树的后序遍历序列
> 输入一个整数数组，判断该数组是不是某二叉搜索树的后序遍历的结果。如果是则输出Yes,否则输出No。假设输入的数组的任意两个数字都互不相同。
>> 解题思路：二叉搜索树是左边小于根，右边大于根节点， Step1.通过取出序列最后一个元素得到二叉搜索树的根节点；Step2.在二叉搜索树中左子树的结点小于根结点，因此可以遍历一次得到左子树；Step3.在二叉搜索树中右子树的结点大于根结点，因此可以继续遍历后序元素得到右子树；Step4.重复以上步骤递归判断左右子树是不是二叉搜索树，如果都是，则返回true，如果不是，则返回false;

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static bool VerifySquenceOfBST(int[] sequence, int length)
{
    if (sequence == null || length <= 0)
    {
        return false;
    }

    int root = sequence[length - 1];

    // 在二叉搜索树中左子树的结点小于根结点
    int i = 0;
    for (; i < length - 1; i++)
    {
        if (sequence[i] > root)
        {
            break;
        }
    }

    // 在二叉搜索树中右子树的结点大于根结点
    int j = i;
    for (; j < length - 1; j++)
    {
        if (sequence[j] < root)
        {
            // 如果找到小于根节点直接返回false
            return false;
        }
    }

    // 判断左子树是不是二叉搜索树
    bool leftIsBST = true;
    if (i > 0)
    {
        leftIsBST = VerifySquenceOfBST(sequence, i);
    }

    // 判断右子树是不是二叉搜索树
    bool rightIsBST = true;
    if (j < length - 1)
    {
        // C#中无法直接操作指针，在C/C++可以直接传递sequence+i
        int[] newSequence = sequence.Skip(i).ToArray();
        rightIsBST = VerifySquenceOfBST(newSequence, length - i - 1);
    }

    return leftIsBST && rightIsBST;
}
```

</p>
</details>  


024. 二叉树中和为某一值的路径
> 输入一颗二叉树的跟节点和一个整数，打印出二叉树中结点值的和为输入整数的所有路径。路径定义为从树的根结点开始往下一直到叶结点所经过的结点形成一条路径。(注意: 在返回值的list中，数组长度大的数组靠前)
>> 解题思路：画图找出规律，通过递归计算出。

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static void FindPath(TreeNode root, int expectedSum)
{
    if (root == null)
    {
        return;
    }

    int currentSum = 0;
    List<int> path = new List<int>();
    FindPath(root, expectedSum, path, ref currentSum);
}

private static void FindPath(TreeNode root, int expectedSum, List<int> path, ref int currentSum)
{
    currentSum += root.val;
    path.Add(root.val);
    // 如果是叶结点，并且路径上结点的和等于输入的值
    // 打印出这条路径
    bool isLeaf = root.left == null && root.right == null;
    if (isLeaf && currentSum == expectedSum)
    {
        foreach (int data in path)
        {
            Console.Write("{0}\t", data);
        }
        Console.WriteLine();
    }

    // 如果不是叶结点，则遍历它的子结点
    if (root.left != null)
    {
        FindPath(root.left, expectedSum, path, ref currentSum);
    }

    if (root.right != null)
    {
        FindPath(root.right, expectedSum, path, ref currentSum);
    }

    // 在返回到父结点之前，在路径上删除当前结点，
    // 并在currentSum中减去当前结点的值
    path.Remove(root.val);
    currentSum -= root.val;
}
```

</p>
</details>  


025. 复杂链表的复制
> 输入一个复杂链表（每个节点中有节点值，以及两个指针，一个指向下一个节点，另一个特殊指针指向任意一个节点），返回结果为复制后复杂链表的head。（注意，输出结果中请不要返回参数中的节点引用，否则判题程序会直接返回空）
>> 解题思路：利用辅助字典，1.先把链表通过next链接，2.通过字典找到复杂的关联

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public ListNode Clone(ListNode pHead)
{
    if (pHead == null)
    {
        return null;
    }
    Dictionary<ListNode, ListNode> nodeMap =new Dictionary<ListNode, ListNode>();

    ListNode currNode = pHead;
    ListNode newHead = null, preNode = null, newNode = null;

    ///  首先复制原链表的普通指针域, 一次遍历即可完成
    while (currNode != null)
    {
        newNode = new ListNode(currNode.item);
        nodeMap.Add(currNode, newNode);
        currNode = currNode.next;

        if (preNode == null)
        {
            newHead = newNode;
        }
        else
        {
            preNode.next = newNode;
        }

        preNode = newNode;
    }

    //  接着复制随机指针域, 需要两次遍历
    currNode = pHead;
    newNode = newHead;
    while (currNode != null && newNode != null)
    {
        ListNode randNode = currNode.random; ///随机指针域randNode
        ListNode newRandNode = nodeMap[randNode];
        newNode.random = newRandNode;

        ///  链表同步移动
        currNode = currNode.next;
        newNode = newNode.next;
    }

    return newHead;
}
```

</p>
</details>  


026. 二叉搜索树与双向链表
> 输入一棵二叉搜索树，将该二叉搜索树转换成一个排序的双向链表。要求不能创建任何新的结点，只能调整树中结点指针的指向。
>> 解题思路：中序遍历，递归

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public TreeNode Convert(TreeNode root)
{
    TreeNode lastNodeInList = null;
    ConvertNode(root, ref lastNodeInList);

    // lastNodeInList指向双向链表的尾结点，
    // 我们需要返回头结点
    TreeNode headInList = lastNodeInList;
    while (headInList != null && headInList.left != null)
    {
        headInList = headInList.left;
    }

    return headInList;
}

private void ConvertNode(TreeNode node, ref TreeNode lastNodeInList)
{
    if (node == null)
    {
        return;
    }

    TreeNode currentNode = node;
    // 转换左子树
    if (currentNode.left != null)
    {
        ConvertNode(currentNode.left, ref lastNodeInList);
    }
    // 与根节点的衔接
    currentNode.left = lastNodeInList;
    if (lastNodeInList != null)
    {
        lastNodeInList.right = currentNode;
    }
    lastNodeInList = currentNode;
    // 转换右子树
    if (currentNode.right != null)
    {
        ConvertNode(currentNode.right, ref lastNodeInList);
    }
}
```

</p>
</details>  


027. 字符串的排列
> 输入一个字符串,按字典序打印出该字符串中字符的所有排列。例如输入字符串abc,则打印出由字符a,b,c所能排列出来的所有字符串abc,acb,bac,bca,cab和cba。
>> 解题思路：递归逐步替换

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static List<string> Permutation(string str)
{
    if (str == null)
    {
        return null;
    }

    var c = str.ToCharArray();
    List<string> data = new List<string>();
    Permutation(c, c, 0, data);
    return data;
}

public static void Permutation(char[] str, char[] begin, int startIndex, List<string> data)
{
    if (startIndex == str.Length)
    {
        data.Add(new string(str));
    }
    else
    {
        for (int i = startIndex; i < str.Length; i++)
        {
            //交换
            char temp = begin[i];
            begin[i] = begin[startIndex];
            begin[startIndex] = temp;

            Permutation(str, begin, startIndex + 1, data);

            //还原
            temp = begin[i];
            begin[i] = begin[startIndex];
            begin[startIndex] = temp;
        }
    }
}
```

</p>
</details>  


028. 数组中出现次数超过一半的数字
> 数组中有一个数字出现的次数超过数组长度的一半，请找出这个数字。例如输入一个长度为9的数组{1,2,3,2,2,2,5,4,2}。由于数字2在数组中出现了5次，超过数组长度的一半，因此输出2。如果不存在则输出0。
>> 解题思路：字典操作，或者排序除以2

030. 最小的K个数
> 输入n个整数，找出其中最小的K个数。例如输入4,5,1,6,2,7,3,8这8个数字，则最小的4个数字是1,2,3,4,。
>> 解题思路：找遍历k个数，之后对比交换

031. 连续子数组的最大和
> 入一个整型数组，数组里有正数也有负数。数组中一个或连续的多个整数组成一个子数组。求所有子数组的和的最大值。要求时间复杂度为O(n)。例如输入的数组为{1,-2,3,10,-4,7,2,-5}，和最大的子数组为{3,10,-4,7,2}，因此输出为该子数组的和18。
>> 解题思路：循环累加，用一个临时变量保存累加的结果，如果累加的结构小于0，从下一个数字重新开始累加，如果累加的数据大于当前累加的和，则更新累加的结果。

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static int FindGreatestSumOfSubArray(int[] array)
{
    if (array == null || array.Length <= 0)
    {
        return 0;
    }

    int currSum = 0;
    int greatestSum = int.MinValue;

    for (int i = 0; i < array.Length; i++)
    {
        if (currSum <= 0)
        {
            currSum = array[i];
        }
        else
        {
            currSum += array[i];
        }

        if (currSum > greatestSum)
        {
            greatestSum = currSum;
        }
    }

    return greatestSum;
}
```

</p>
</details>  

032. 整数中1出现的次数（从1到n整数中1出现的次数）
> 求出1~13的整数中1出现的次数,并算出100~1300的整数中1出现的次数？为此他特别数了一下1~13中包含1的数字有1、10、11、12、13因此共出现6次,但是对于后面问题他就没辙了。ACMer希望你们帮帮他,并把问题更加普遍化,可以很快的求出任意非负整数区间中1出现的次数（从1 到 n 中1出现的次数）。
>> 解题思路：n1:数字的第一位，bit是10的次方数，利用公式计算
```
if(n1 == 1) 
     f(n) = f(10bit-1) + f(n - 10bit) + n - 10bit+ 1; 
else 
    f(n) = n1*f(10bit-1) + f(n – n1*10bit) + 10bit; 
```

033. 把数组排成最小的数
> 输入一个正整数数组，把数组里所有数字拼接起来排成一个数，打印能拼接出的所有数字中最小的一个。例如输入数组{3，32，321}，则打印出这三个数字能排成的最小数字为321323。
>> 解题思路:转换成字符串排序。

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static string PrintMinNumber(int[] numbers)
{
    string result = "";
    ///将整数转换成字符串
    List<string> strNum = numbers.Select(x => x.ToString()).ToList();
    strNum.Sort();
    strNum.ForEach(x => result = result + x);
    return result;
}
```

</p>
</details>  


034. 丑数
> 把只包含质因子2、3和5的数称作丑数（Ugly Number）。例如6、8都是丑数，但14不是，因为它包含质因子7。 习惯上我们把1当做是第一个丑数。求按从小到大的顺序的第N个丑数。
>> 解题思路:丑数：把只包含因子2、3和5的数称作丑数（Ugly Number）。1.每次取最小的丑数，2.移动相应的计算丑数索引

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public int GetUglyNumber(int index)
{
    if (index <= 0)
    {
        return 0;
    }

    int[] uglyNumbers = new int[index];
    uglyNumbers[0] = 1;
    int nextUglyIndex = 1;

    int multiply2 = 0;
    int multiply3 = 0;
    int multiply5 = 0;
    int min = 0;

    while (nextUglyIndex < index)
    {
        min = Min(uglyNumbers[multiply2] * 2, uglyNumbers[multiply3] * 3, uglyNumbers[multiply5] * 5);
        uglyNumbers[nextUglyIndex] = min;

        while (uglyNumbers[multiply2] * 2 <= uglyNumbers[nextUglyIndex])
        {
            multiply2++;
        }

        while (uglyNumbers[multiply3] * 3 <= uglyNumbers[nextUglyIndex])
        {
            multiply3++;
        }

        while (uglyNumbers[multiply5] * 5 <= uglyNumbers[nextUglyIndex])
        {
            multiply5++;
        }

        nextUglyIndex++;
    }

    int result = uglyNumbers[index - 1];
    uglyNumbers = null;

    return result;
}

private int Min(int num1, int num2, int num3)
{
    int min = num1 < num2 ? num1 : num2;
    min = min < num3 ? min : num3;

    return min;
}
```

</p>
</details>  


035. 	第一个只出现一次的字符位置
> 在一个字符串(0<=字符串长度<=10000，全部由字母组成)中找到第一个只出现一次的字符,并返回它的位置, 如果没有则返回 -1（需要区分大小写）.
>> 解题思路:利用字典，两次扫描

036. 数组中的逆序对
> 在数组中的两个数字，如果前面一个数字大于后面的数字，则这两个数字组成一个逆序对。输入一个数组,求出这个数组中的逆序对的总数P。并将P对1000000007取模的结果输出。 即输出P%1000000007
>> 解题思路:利用排序计算交换次数。简单来说就是排序算法。

037. 	两个链表的第一个公共结点
> 输入两个链表，找出它们的第一个公共结点。
>> 解题思路:两个链表有公共节点，那么公共节点的合并形成一个Y行的，利用栈，确定相同，找到公共节点。

038. 数字在排序数组中出现的次数
> 统计一个数字在排序数组中出现的次数。
>> 解题思路:用字典处理，如果只会查找一次那就用二分法查找

039. 二叉树的深度
> 输入一棵二叉树，求该树的深度。从根结点到叶结点依次经过的结点（含根、叶结点）形成树的一条路径，最长路径的长度为树的深度。
>> 解题思路: 递归二叉树的遍历

040. 平衡二叉树
> 输入一棵二叉树，判断该二叉树是否是平衡二叉树。
>> 解题思路:平衡二叉树要求对于每一个节点来说，它的左右子树的高度之差不能超过1，1.计算二叉树的深度，2.比较左右子树的深度

041. 数组中只出现一次的数字
> 一个整型数组里除了两个数字之外，其他的数字都出现了两次。请写程序找出这两个只出现一次的数字。
>> 解题思路:利用字典，两次扫描

042. 	和为S的连续正数序列
> 小明很喜欢数学,有一天他在做数学作业时,要求计算出9~16的和,他马上就写出了正确答案是100。但是他并不满足于此,他在想究竟有多少种连续的正数序列的和为100(至少包括两个数)。没多久,他就得到另一组连续正数和为100的序列:18,19,20,21,22。现在把问题交给你,你能不能也很快的找出所有和为S的连续正数序列? Good Luck!
>> 解题思路:两个索引移位操作

<details>
<summary>部分核心代码实现</summary>
<p>

```c#
public static List<string> FindContinuousSequence(int sum)
{
    List<string> list = new List<string>();
    int begin = 1;
    int end = 2;
    int mid = (sum + 1) >> 1;
    int curSum = begin + end;

    while (begin < end && end <= mid)
    {
        if (curSum == sum)
        {
            list.Add($"{begin} - {end}");
        }

        if (curSum > sum) //当前值大于sum，缩小范围
        {
            curSum -= begin;
            begin++;
        }
        else //前值小于sum，增大范围
        {

            end++;
            curSum += end;
        }

    }
    return list;
}
```

</p>
</details>  


043. 和为S的两个数字
> 输入一个递增排序的数组和一个数字S，在数组中查找两个数，使得他们的和正好是S，如果有多对数字的和等于S，输出两个数的乘积最小的。
>> 解题思路: 同上042解题思路，两个变量移动求和，保存数据。

044. 左旋转字符串
> 汇编语言中有一种移位指令叫做循环左移（ROL），现在有个简单的任务，就是用字符串模拟这个指令的运算结果。对于一个给定的字符序列S，请你把其循环左移K位后的序列输出。例如，字符序列S=”abcXYZdef”,要求输出循环左移3位后的结果，即“XYZdefabc”。是不是很简单？OK，搞定它！
>> 解题思路:旋转数组的方法，每次后移。

045. 翻转单词顺序列
> 牛客最近来了一个新员工Fish，每天早晨总是会拿着一本英文杂志，写些句子在本子上。同事Cat对Fish写的内容颇感兴趣，有一天他向Fish借来翻看，但却读不懂它的意思。例如，“student. a am I”。后来才意识到，这家伙原来把句子单词的顺序翻转了，正确的句子应该是“I am a student.”。Cat对一一的翻转这些单词顺序可不在行，你能帮助他么？
>> 解题思路:

046. 扑克牌顺子
> 大\小 王可以看成任何数字,并且A看作1,J为11,Q为12,K为13. 如果牌能组成顺子就输出true，否则就输出false。为了方便起见,你可以认为大小王是0。
>> 解题思路:

047. 	孩子们的游戏(圆圈中最后剩下的数)
> 每年六一儿童节,牛客都会准备一些小礼物去看望孤儿院的小朋友,今年亦是如此。HF作为牛客的资深元老,自然也准备了一些小游戏。其中,有个游戏是这样的:首先,让小朋友们围成一个大圈。然后,他随机指定一个数m,让编号为0的小朋友开始报数。每次喊到m-1的那个小朋友要出列唱首歌,然后可以在礼品箱中任意的挑选礼物,并且不再回到圈中,从他的下一个小朋友开始,继续0...m-1报数....这样下去....直到剩下最后一个小朋友,可以不用表演,并且拿到牛客名贵的“名侦探柯南”典藏版(名额有限哦!!。请你试着想下,哪个小朋友会得到这份礼品呢？(注：小朋友的编号是从0到n-1)
>> 解题思路:

048. 求1+2+3+...+n
> 求1+2+3+...+n，要求不能使用乘除法、for、while、if、else、switch、case等关键字及条件判断语句（A?B:C）。
>> 解题思路:

049. 不用加减乘除做加法
> 写一个函数，求两个整数之和，要求在函数体内不得使用+、-、*、/四则运算符号。
>> 解题思路:

050. 	把字符串转换成整数
> 将一个字符串转换成一个整数(实现Integer.valueOf(string)的功能，但是string不符合数字要求时返回0)，要求不能使用字符串转换整数的库函数。 数值为0或者字符串不是一个合法的数值则返回0。
>> 解题思路:

051. 	数组中重复的数字
> 在一个长度为n的数组里的所有数字都在0到n-1的范围内。 数组中某些数字是重复的，但不知道有几个数字是重复的。也不知道每个数字重复几次。请找出数组中任意一个重复的数字。 例如，如果输入长度为7的数组{2,3,1,0,2,5,3}，那么对应的输出是第一个重复的数字2。
>> 解题思路:

052. 	构建乘积数组
> 给定一个数组A[0,1,...,n-1],请构建一个数组B[0,1,...,n-1],其中B中的元素B[i]=A[0]A[1]......A[i-1]A[i+1].......A[n-1]不能使用除法。
>> 解题思路:

053. 正则表达式匹配
> 请实现一个函数用来匹配包括'.'和'*'的正则表达式。模式中的字符'.'表示任意一个字符，而'*'表示它前面的字符可以出现任意次（包含0次）。 在本题中，匹配是指字符串的所有字符匹配整个模式。例如，字符串"aaa"与模式"a.a"和"ab*ac*a"匹配，但是与"aa.a"和"ab*a"均不匹配
>> 解题思路:

054. 	表示数值的字符串
> 请实现一个函数用来判断字符串是否表示数值（包括整数和小数）。例如，字符串"+100","5e2","-123","3.1416"和"-1E-16"都表示数值。 但是"12e","1a3.14","1.2.3","+-5"和"12e+4.3"都不是。
>> 解题思路:

055. 字符流中第一个不重复的字符
> 请实现一个函数用来找出字符流中第一个只出现一次的字符。例如，当从字符流中只读出前两个字符"go"时，第一个只出现一次的字符是"g"。当从该字符流中读出前六个字符“google"时，第一个只出现一次的字符是"l"。
>> 解题思路:

056. 	链表中环的入口结点
> 给一个链表，若其中包含环，请找出该链表的环的入口结点，否则，输出null。
>> 解题思路:

057. 删除链表中重复的结点
> 在一个排序的链表中，存在重复的结点，请删除该链表中重复的结点，重复的结点不保留，返回链表头指针。 例如，链表1->2->3->3->4->4->5 处理后为 1->2->5
>> 解题思路:

058. 二叉树的下一个结点
> 给定一个二叉树和其中的一个结点，请找出中序遍历顺序的下一个结点并且返回。注意，树中的结点不仅包含左右子结点，同时包含指向父结点的指针。
>> 解题思路:

059. 	对称的二叉树
> 请实现一个函数，用来判断一颗二叉树是不是对称的。注意，如果一个二叉树同此二叉树的镜像是同样的，定义其为对称的。
>> 解题思路:

060. 按之字形顺序打印二叉树
> 请实现一个函数按照之字形打印二叉树，即第一行按照从左到右的顺序打印，第二层按照从右至左的顺序打印，第三行按照从左到右的顺序打印，其他行以此类推。
>> 解题思路:

061. 	把二叉树打印成多行
> 从上到下按层打印二叉树，同一层结点从左至右输出。每一层输出一行。
>> 解题思路:

062. 序列化二叉树
> 请实现两个函数，分别用来序列化和反序列化二叉树
>> 解题思路:

063. 二叉搜索树的第k个结点
> 给定一棵二叉搜索树，请找出其中的第k小的结点。例如， （5，3，7，2，4，6，8）    中，按结点数值大小顺序第三小结点的值为4。
>> 解题思路:

064. 数据流中的中位数
> 如何得到一个数据流中的中位数？如果从数据流中读出奇数个数值，那么中位数就是所有数值排序之后位于中间的数值。如果从数据流中读出偶数个数值，那么中位数就是所有数值排序之后中间两个数的平均值。我们使用Insert()方法读取数据流，使用GetMedian()方法获取当前读取数据的中位数。
>> 解题思路:

065. 	滑动窗口的最大值
> 给定一个数组和滑动窗口的大小，找出所有滑动窗口里数值的最大值。例如，如果输入数组{2,3,4,2,6,2,5,1}及滑动窗口的大小3，那么一共存在6个滑动窗口，他们的最大值分别为{4,4,6,6,6,5}； 针对数组{2,3,4,2,6,2,5,1}的滑动窗口有以下6个： {[2,3,4],2,6,2,5,1}， {2,[3,4,2],6,2,5,1}， {2,3,[4,2,6],2,5,1}， {2,3,4,[2,6,2],5,1}， {2,3,4,2,[6,2,5],1}， {2,3,4,2,6,[2,5,1]}。
>> 解题思路:

066. 矩阵中的路径
> 请设计一个函数，用来判断在一个矩阵中是否存在一条包含某字符串所有字符的路径。路径可以从矩阵中的任意一个格子开始，每一步可以在矩阵中向左，向右，向上，向下移动一个格子。如果一条路径经过了矩阵中的某一个格子，则之后不能再次进入这个格子。 例如 a b c e s f c s a d e e 这样的3 X 4 矩阵中包含一条字符串"bcced"的路径，但是矩阵中不包含"abcb"路径，因为字符串的第一个字符b占据了矩阵中的第一行第二个格子之后，路径不能再次进入该格子。
>> 解题思路:

067. 	机器人的运动范围
> 地上有一个m行和n列的方格。一个机器人从坐标0,0的格子开始移动，每一次只能向左，右，上，下四个方向移动一格，但是不能进入行坐标和列坐标的数位之和大于k的格子。 例如，当k为18时，机器人能够进入方格（35,37），因为3+5+3+7 = 18。但是，它不能进入方格（35,38），因为3+5+3+8 = 19。请问该机器人能够达到多少个格子？
>> 解题思路:
