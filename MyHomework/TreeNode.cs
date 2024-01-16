using System;
using System.Linq;


namespace DataStructure  //트리 구현 
{
    public class TreeNode<T>  //트리 노드 필요 
    {
        public T item;

        public TreeNode<T> parent;  //부모 노드 
        public List<TreeNode<T>> children;  //자식 노드
        //노드가 몇 개 있는지 파악하기 힘들기 때문에
        //모든 트리는 이진트리로 변환가능 --> 그냥 이진트리 사용합시다.
        //이진트리는 노드가 최대2개 이기 때문에 관리가 쉬움 
        //대부분 이진트리로 구현하는 경우가 보통이다. 
    }
    public class BinaryNode<T>
    {
        public T item; //가지고 있는 값 

        public BinaryNode<T> parent;
        public BinaryNode<T> left;  //왼쪽 , 오른쪽 자식 
        public BinaryNode<T> right;
    }

}