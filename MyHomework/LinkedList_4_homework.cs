using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{/*
  * 
  * 요세푸스 순열 문제

    요세푸스 문제는 다음과 같다.
    1번부터 N번까지 N명의 사람이 원을 이루면서 앉아있고, 양의 정수 K(≤ N)가 주어진다. 
    이제 순서대로 K번째 사람을 제거한다. 
    한 사람이 제거되면 남은 사람들로 이루어진 원을 따라 이 
    과정을 계속해 나간다. 
    이 과정은 N명의 사람이 모두 제거될 때까지 계속된다. 
    원에서 사람들이 제거되는 순서를 (N, K)-요세푸스 순열이라고 한다. 
    예를 들어 (7, 3)-요세푸스 순열은 <3, 6, 2, 7, 5, 1, 4>이다.
    N과 K가 주어지면 (N, K)-요세푸스 순열을 구하는 프로그램을 작성하시오.

*/
    /*  A+) 풍선터트리기 문제

    1번부터 N번까지 N개의 풍선이 원형으로 놓여 있고. 
        i번 풍선의 오른쪽에는 i+1번 풍선이 있고, 왼쪽에는 i-1번 풍선이 있다.
        단, 1번 풍선의 왼쪽에 N번 풍선이 있고,
        N번 풍선의 오른쪽에 1번 풍선이 있다. 
        각 풍선 안에는 종이가 하나 들어있고, 
        종이에는 -N보다 크거나 같고, N보다 
        작거나 같은 정수가 하나 적혀있다. 이 풍선들을 다음과 같은 규칙으로 터뜨린다.
    우선, 제일 처음에는 1번 풍선을 터뜨린다.
        다음에는 풍선 안에 있는 종이를 꺼내어 그 종이에 적혀있는 값만큼 이동하여 
        다음 풍선을 터뜨린다. 양수가 적혀 있을 경우에는 오른쪽으로, 
        음수가 적혀 있을 때는 왼쪽으로 이동한다. 
        이동할 때에는 이미 터진 풍선은 빼고 이동한다.
    예를 들어 다섯 개의 풍선 안에 차례로 3, 2, 1, -3, -1이 적혀 있었다고 하자.
        이 경우 3이 적혀 있는 1번 풍선, -3이 적혀 있는 4번 풍선, -1이 적혀 있는 5번 풍선,
        1이 적혀 있는 3번 풍선, 2가 적혀 있는 2번 풍선의 순서대로 터지게 된다.

*/
    public class Yose
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList= new LinkedList<int>();
            int n=7; int k = 3;

            for (int i = 1; i <= n;i++)
            {
                linkedList.AddLast(i);
            }
            while(linkedList.Count > 0)  //남아 있을 때 까지 반복 
            {
                for(int i=1;i<=k;i++)
                {
                    //node 이용 해야 함 
                    LinkedListNode<int> node = linkedList.First;
                    if(i==k)  //k의 배수 빠지기 
                    {
                        //linkedList.Remove(node); 여기서는 둘이 같음 
                        linkedList.RemoveFirst();
                        Console.WriteLine($"{node.Value}");
                    }
                    else  //안 빠지고 뒤로 다시 들어감  
                    {
                        linkedList.RemoveFirst();
                        linkedList.AddLast(node); //node로 다뤄야함
                        
                    }
                }
            }
            //순환구조 node를 이용해서 접근해야함 
        }
    }
}
