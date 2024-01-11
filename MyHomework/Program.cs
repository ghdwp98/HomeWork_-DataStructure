namespace ConsoleApp1
{
    /* 
     * <실습>
        사용자에게 숫자를 입력 받아서
        0부터 숫자까지 가지는 리스트 만들기
        0 요소를 제거
        리스트가 가지는 모든 요소들을 출력해주는 반복문 작성

        ///////////////////////////////////////////////

        사용자의 입력을 받아서 없는 데이터면 추가, 있던 데이터면 삭제하는 보관함
        ex) 1, 6, 7, 8, 3 들고 있던 상황이면
        2 입력하면 없던 경우니까 1, 6, 7, 8, 3, 2
        7 입력하면 있던 경우니까 1, 6, 8, 3

        ///////////////////////////////////////////////

         A++) 인벤토리 구현 (아이템 얻기, 아이템 버리기)
     
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();  //1.숫자입력 받음
            int number=int.Parse(input);
            List<int> list = new List<int>();
            for(int i = 0; i <= number; i++)
            {
                list.Add(i);  //2. 0부터 숫자까지 가지는 리스트
            }
            Console.WriteLine();
            list.Remove(0);  //3. 0번째 인덱스 제거

            foreach(int i in list)
            {
                string s = string.Format("{0,5}", i);
                Console.Write(s);
                if(i%5==0)
                {
                    Console.WriteLine(); //4. 리스트가 가지는 모든요소 출력
                }    

            }
            



        }
    }
}
