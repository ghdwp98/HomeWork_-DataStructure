using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*<작업 프로세스>
배열로 각 작업이 몇시간이 걸리는지 있다.
예시 : [4, 4, 12, 10, 2, 10]

하루에 8시간씩 일할 수 있는 회사가 있음.
남는시간없이 주어진 일을 계속한다고 했을때.
각각의 작업이 끝나는 날짜를 결과 배열로 출력

int[] ProcessJob(int[] jobList) {}

결과 : [1, 1, 3, 4, 4, 6]
*/

namespace MyHomeWork
{
   public class StackHomeWork3
    {
        public const int WorkTime = 8;

        public static int[] ProcessJob(int[] jobList)
        {
            Queue<int> queue = new Queue<int>();
            int remainTime = 8;
            int day = 1; //완료 날짜 
            List<int> days = new List<int>();
            for(int i = 0; i < jobList.Length; i++)

            {
                queue.Enqueue(jobList[i]);
            }
            while(queue.Count > 0)  //작업이 남아 있을 때 까지 작업 반복 
            {
                int workTime = queue.Dequeue();

                while(true) //작업 끝날 때 까지 반복 
                {
                    if (workTime <= remainTime)
                    {
                        remainTime -= workTime; //작업완료 작업시간만큼 남은시간에서 빼기
                        days.Add(day);
                        break;
                    }
                    else
                    {
                        workTime -= remainTime;
                        day++; //날짜추가 (다음날로)
                        remainTime = 8; //다시 8시간 복귀 
                    }
                }
               
                
            }
            return days.ToArray(); //작업 끝내 날들 추가 
        }


        static void Main(string[] args)
        {
            int[] arr = [4, 4, 12, 10, 2, 10];

            foreach(int i in ProcessJob(arr))
            {
                Console.WriteLine(i);
            }
 
        }
    }


}
