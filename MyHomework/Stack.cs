using System;


namespace _03_Stack
{
    public class Stack<T>
    {
        private List<T> container;  //list를 이용한 스택 생성 

        public Stack()
        {
            container = new List<T>(); //스택 생성 새로운 리스트 생성 
        }
        public int Count { get { return container.Count; } } //스택의 count 확인 가능
                                                             //
        public void Push(T item)
        {
            container.Add(item); //맨 뒤에 원소 Add(push)
        }
        public T Pop()
        {
            T item = container[container.Count - 1];  //마지막 위치 item 
            container.RemoveAt(container.Count - 1); //맨 마지막에 있는 데이터 삭제 
            return item;  //리턴 받고 삭제 (값 꺼내고 공간 삭제 )
        }
        public T Peek()
        {
            return container[container.Count - 1]; //마지막 원소 리턴 (확인만 /삭제 x)
        }
    }
}
