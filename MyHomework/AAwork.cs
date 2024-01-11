using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
/*A++) 인벤토리 구현(아이템 얻기, 아이템 버리기)
*/
namespace MyHomeWork
{
    
    class Store
    {
        private string name;

        public string Name { get { return name; } }

        public Store()
        {
            Console.WriteLine("상점에 들어갔습니다.");
        }
        
        public Store(int n,Player owner) 
        {
            switch(n)
            {
                case 1:
                    Console.WriteLine($"{n}번 선택. 작은무기 장착");
                    this.name = "작은무기";
                    owner.MyItem.Add(this.name);
                    break;
                case 2:
                    Console.WriteLine($"{n}번 선택. 큰 무기 장착");
                    this.name = "큰 무기";
                    owner.MyItem.Add(this.name);
                    break;
                case 3:
                    Console.WriteLine($"{n}번 선택. 완전 큰 무기 장착");
                    this.name = "완전 큰 무기";
                    owner.MyItem.Add(this.name);
                    break;
                default:
                    Console.WriteLine("잘못 선택함.");
                    break;

            }
        }
    }
    class Player
    {
        private string name = "주인공";
        private string item = "";
        public List<string> MyItem = new List<string>();

        public Player()
        {
            
        }

        public Player(Store store)
        {
            Console.WriteLine($"{this.name}은 현재 {store.Name} 장착 중입니다.");

        }
        public void Buy()  //구입 함수 
        {
            Console.WriteLine(" 1 : 작은 총 2: 중간 총 3: 큰 총 ");
            string input=Console.ReadLine();
            int number=int.Parse(input);
            
            switch(number)
            {
                case 1: this.item = "작은 총";
                    Console.WriteLine($"{item}구입함!");
                    MyItem.Add(this.item);
                    break;
                case 2: this.item = " 중간 총";
                    Console.WriteLine($"{item}구입함!");
                    MyItem.Add(this.item);
                    break;
                case 3: this.item = "큰 총";
                    Console.WriteLine($"{item}구입함!");
                    MyItem.Add(this.item);
                    break;
                default:
                    Console.WriteLine("");
                    break;

            }
        }
        public void ThrowAway(int n)
        {
            MyItem.RemoveAt(n);
        }
        
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            int count = 1;
            Store store = new Store();
            Console.WriteLine("구입 할 아이템을 선택해주세요");
            Console.WriteLine(" 1 : 작은무기  2: 큰 무기  3: 완전 큰 무기");
            string input= Console.ReadLine();
            Player player = new Player();
            int number=int.Parse(input);
            Store stores = new Store(number,player);

            Console.WriteLine("구입 할 무기를 선택해 주세요.");
            player.Buy();
            Console.WriteLine("버릴 무기를 선택해 주세요.");
            Console.WriteLine();
            Console.WriteLine("버릴 무기 목록 ");
            foreach (string i in player.MyItem)
            {
                
                Console.WriteLine($"{count} : {i}");
                count++;
                
            }

            Console.WriteLine();
            Console.Write("버릴 무기 선택 :: ");
            string input2=Console.ReadLine();
            int num=int.Parse(input2);

            player.ThrowAway(num-1);

            Console.WriteLine("남은 무기");
            Console.WriteLine();

            foreach (string i in player.MyItem)
            {
                Console.WriteLine(i);
            }

        }
    }
}
