using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure
{
    public class BinarySearchTree<T> where T : IComparable<T>
        //비교할 수 없는 값이 오면 이진트리 사용 불가능
        //where를 통해서 비교가 가능한 값들만 쓸 수 있도록 자료형 제약 
        //이진탐색트리는 count에 따라 동작의 변화가 없음
        //count 추가 구현 할 필요는 x (간소화) 
    {
        private Node<T> root;  //루트노드

        public BinarySearchTree()  //이진트리 생성 --> 아직 데이터가 없음
        {
            this.root = null; 
        }

        public bool Add(T item)  //중복 추가를 무시하므로 반환형이 bool
            //추가 성공 t // 실패 f 
        {
            Node<T> newNode = new Node<T>(item, null, null, null);  //새로운 노드 생성 

            if (root == null)  //루트 노드가 없는 상황이면 
            {
                root = newNode; //삽입하는 노드가 루트노드(맨 처음 추가 이므로)
                return true; //반환형 bool 
            }

            Node<T> current = root;  //루트부터 빈자리가 아닐때 까지 반복 

            while(current!=null)  
            { 
                if (item.CompareTo(current.item) < 0)  //삽입하려는 item과 지금(current)비교하는 노드 
                    // 왼쪽으로 가게 된다 (item이 current보다 더 작음 )
                {
                    if (current.left != null) //왼쪽이 있으면 
                    {
                        current = current.left; //다음 비교할 노드를 변화
                        //왼쪽으로 이동했기 때문에 왼쪽 노드와 새롭게 또 비교 
                    }
                    else  //왼쪽으로 내려갔는데 그 왼쪽 자식이 없는 경우
                    // 이 자리가 Add 될 원소의 자리가 된다.
                    {
                        current.left = newNode;  //그 위치가 newNode의 위치가 된다. 
                        newNode.parent = current;  //current가 newNode의 부모가된다. 
                        //방금 비교했던 current 
                        break; //Add를 멈추고 탈출 
                    }
                }
                else if (item.CompareTo(current.item) > 0)  //ADD하는 원소가 더 크면
                    // 오른쪽으로 이동 
                {
                    if (current.right != null) //오른쪽 자식이 있는 경우
                    {
                        current = current.right;  //하강 작업 반복 (비교반복)
                    }
                    else
                    {
                        current.right = newNode;
                        newNode.parent = current;
                        break;

                    }
                }
                else //똑같은 값을 찾았을 경우 --> 중복 무기 -->fALSE;
                // if (item.CompareTo(current.item) == 0)
                //item과 current의 값이 같은 경우 
                {
                    return false;
                }
                
            }
            return true;
        }

        public bool Remove(T item)  //반환형 bool 
        {
            Node<T> findNode = FindNode(item);  //findNode를 메서드를 이용한다. 
            //있는지 확인 
            if (findNode != null)
            {
                EraseNode(findNode);
                return true;
            }
            else   //해당 노드가 없음
            {
                return false;
            }
        }
        
        private void EraseNode(Node<T> node)  //지우는 상황 3가지 
            //(자식이 ) 하나도 없는 경우 / 하나인 경우 / 두 개인 경우
        {
            if (node.HasNoChild)
            {       //자식이 없는 경우
                if (node.IsLeftChild)  //왼쪽자식이면 
                {
                    node.parent.left = null;  //서로 연결 끊어버림 
                    //node의 부모의 왼쪽자식을 null로
                }
                else if (node.IsRightChild)
                {
                    node.parent.right = null;
                }
                else  //나 자신이 루트 노드 인경우 그 root를 null로 만들어줌 
                {
                    root = null;
                }
            }
            else if (node.HasLeftChild || node.HasRightChild)
            {  //자식이 하나만 있는 경우
                //(삭제하려는 노드의) 부모와 자식을 연결해 주고 삭제 
                Node<T> parent = node.parent;
                Node<T> child = node.HasLeftChild ? node.left : node.right;
                //왼쪽이면 왼쪽 아니면 오른쪽 으로 차일드 주면 됨 

                if (node.IsLeftChild) //부모와 자식을 연결해주고 이 노드를 삭제하면된다. 
                {
                    parent.left = child;  //삭제하려는 노드가 부모의 왼쪽이면
                    //그 위치의 자신(삭제하려는 노드) 의 child를 연결해주고  
                    child.parent = parent; //그 부모를 (삭제하려는 노드)의 부모로 변경 
                }
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else // if (node.IsRootNode) //삭제하려는 노드가 루트노드인 경우
                {
                    root = child; //루트 위치를 자신의 차일드에게 물려줌
                    child.parent = null; //root이므로 부모는 null로 변경 
                }

            }
            else         //if (node.HasBothChild) 
            
            {   // 삭제하려는 노드가 자식이 둘 다 있는 경우 
                //<<오른쪽 자식 중 가장 작은 값과 위치를 교체>>하고
                //그 위치로 이동한 후에 삭제 

                Node<T> nextNode = node.right;  //일단 오른쪽으로 한 칸 이동한 이후에 
                //왼쪽 자식이 없으면 그 값이 가장 작은 상태
                //왼쪽 자식이 있으면 그 왼쪽 값이 더 작기 때문에 
                while (nextNode.left != null)
                {
                    nextNode = nextNode.left; //계속 왼쪽 값을 탐색한다. 
                    //더 이상 왼쪽 값이 없을 때 까지 
                }
                node.item = nextNode.item; //찾은 노드와 위치를 교체
                EraseNode(nextNode);  //그 위치를 삭제 

            }
        }

        private Node<T> FindNode(T item)  //현재의 노드 반환 
        {
            if (root == null) return null; //빈 트리
            Node<T> current= root; //root 부터 차근차근 비교시작
            while (current!=null)
            {
                if (root == null)
                {
                    return null; //루트가 비어있음 --> 빈 트리
                }
                

                if (item.CompareTo(current.item) < 0) //작으면 왼쪽
                {
                    current = current.left;
                }
                else if (item.CompareTo(current.item) > 0)
                {
                    current = current.right;
                }
                else //if (item.CompareTo(current.item) == 0)
                {
                    return current;
                }
            }
           
            return null; //모든 반복 끝날 때 까지 못찾음
        }
    }



    public class Node<T>  //이진 탐색 트리의 노드 클래스 
    {
        public T item; //노드의 실질적인 값 데이터
        public Node<T> parent;
        public Node<T> left;
        public Node<T> right;

        public Node(T item, Node<T> parent, Node<T> left, Node<T> right)
        {
            this.item = item;
            this.parent = parent;
            this.left = left;
            this.right = right;
        }

        public bool IsRootNode { get { return parent == null; } }  //루트노드 체크
        //parent가 null이면 루트노드
        public bool IsLeftChild { get { return parent != null && parent.left == this; } }
        //부모가 있으면서 부모의 왼쪽이 this (자기자신) 이면 왼쪽아이노드
        public bool IsRightChild { get { return parent != null && parent.right == this; } }

        public bool HasNoChild { get { return left == null && right == null; } }
        //아이가 없는지 체크 왼쪽 오른쪽 자식 모두 null 이면 아이없음
        public bool HasLeftChild { get { return left != null && right == null; } }
        //왼쪽만 자식이 있음
        public bool HasRightChild { get { return left != null && right != null; } }
        //오른쪽만 자식이 있음
        public bool HasBothChild { get { return left != null && right != null; } }
        // 자식을 둘 다 가지고 있음 (둘다 null이 아님 )



    }
}
