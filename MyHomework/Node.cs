using System.Security.Cryptography.X509Certificates;

namespace Study_LinkiedList
{  //노드 생성 링크드 리스트 노드 만들어보기 
    internal class Node
    {  //노드 -> 다른 곳으로 가는 방법을 보관 + 데이터  (참조) 


        public class LinkedListNode<T>
        {
            public T Value; //가져야 하는 자료 (데이터)

            public LinkedListNode<T> prev; //이전 노드의 위치를 가지고 있어야 함 
            public LinkedListNode<T> next; //다음 노드의 위치를 가지고 있어야 함 
                                           //다른 노드로 갈 수 있는 값을 가짐 




        }
        public class BinaryTreeNode<T>  //이진 트리 방식 노드 
        {
            public T value;

            public BinaryTreeNode<T> parent;  //부모
            public BinaryTreeNode<T> left;  //왼쪽 자식 
            public BinaryTreeNode<T> right;  //오른쪽 자식 
        }
        public class OctTreeNode<T>  //8진 트리 
        {
            public T value;

            public OctTreeNode<T> parent;
            public OctTreeNode<T>[] children = new OctTreeNode<T>[8];  //자식 8 개 


        }
        // 연결된 노드를 가지는 List를 통해 유동적인 연결구조를 가짐
        // 연결구조가 일정하지 않은 트리/그래프 등에 사용
        public class AdjacentNode<T>  //인접리스트
        {
            public T value;

            public List<AdjacentNode<T>> connect = new List<AdjacentNode<T>>();
        }

        //노드들의 개수가 안정해져 있다 --> list를 통해 구현 (연결구조가 일정하지 않음) 
    }
}

