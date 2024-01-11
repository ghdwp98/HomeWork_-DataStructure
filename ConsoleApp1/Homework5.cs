using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*사용자의 입력을 받아서 없는 데이터면 추가, 있던 데이터면 삭제하는 리스트
ex) 1, 6, 7, 8, 3 들고 있던 상황이면
2 입력하면 없던 경우니까 1, 6, 7, 8, 3, 2
7 입력하면 있던 경우니까 1, 6, 8, 3*/

namespace HomeWORK5
{
    class MainApp
    {
        static void Main(string[] args)
        {
            List<int> list = [1, 3, 4, 7, 9, 10];
            // 1~10 중 일부의 숫자를 가지고 있음. 

            Console.WriteLine("1~10 사이의 숫자를 입력해주세요.");
            string input=Console.ReadLine();
            int number=int.Parse(input);

            if (!list.Contains(number))  //리스트에 없으면 추가 
            {
                list.Add(number);
            }
            else
            {
                list.Remove(number);  // 리스트에 있으면 제거 
            }
            foreach (int i in list) { Console.WriteLine(i); }
        }
    }
}
