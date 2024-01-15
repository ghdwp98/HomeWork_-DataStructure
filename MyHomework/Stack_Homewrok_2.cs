using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    /*<괄호 검사기를 구현하자>
괄호 : 괄호가 바르게 짝지어졌다는 것은 열렸으면 짝지어서 닫혀야 한다는 뜻

텍스트를 입력으로 받아서 괄호가 유효한지 판단하는 함수
bool IsOk(string text) {}

검사할 괄호 : [], {}, ()

예시 : () 완성, (() 미완성, [) 미완성, [[(){}]] 완성
*/
    class Queue
    {
        public static bool IsOk(string text)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    stack.Push(text[i]);
                }
                else if (text[i] == '{')
                {
                    stack.Push(text[i]);

                }
                else if (text[i] == '[')
                {
                    stack.Push(text[i]);  //여는 괄호는 스택에 담기 

                }
                else if (text[i] == ')')  //닫히는 모양과 일치하는지 가장 최신 괄호 
                {
                    if (stack.Count == 0)
                    {
                        return false; //스택이 이미 비어있으면 false
                    }
                    char bracket = stack.Pop();
                    if (bracket == '(')
                    {
                        //이건 괜찮은 상황 
                    }
                    else  //가장 최신에 열었던 괄호가 다른 괄호 -->무조건 실패
                    {
                        return false;
                    }
                }
                else if (text[i] == '}') //나머지도 마찬가지 
                {
                    if (stack.Count == 0)
                    {
                        return false; //스택이 이미 비어있으면 false
                    }
                    char bracket = stack.Pop();
                    if (bracket == '{')
                    {

                    }
                    else
                    {
                        return false;
                    }

                }
                else if (text[i] == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false; //스택이 이미 비어있으면 false
                    }
                    char bracket = stack.Pop();
                    if (bracket == '[')
                    {

                    }
                    else
                    {
                        return false;
                    }
                }

            }
            if (stack.Count > 0)
            {
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {


            Console.WriteLine(IsOk("(())"));
            Console.WriteLine(IsOk("{}{}()(){()}"));
        }
    }
}


