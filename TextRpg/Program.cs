// 혹시 몰라서 using문을 넣음

using System;
using System.Collections.Generic; 

namespace TextRpg
{
    // 아이템 정보를 담는 클래스
    // 일종의 "아이템 하나"를 설명하는 설계도

    class Item
    {
        // [{ get; set; }]은 "자동 구현 프로퍼티(Auto-Implemented Property)"라고 함
        // get은 값을 읽을 때(가져올 때) 사용
        // set은 값을 저장(변경)할 때 사용
        // 이전 방식에는 필드와 프로퍼티를 따로 선언을 해야 했음
        // 그러나 이제는 { get; set; }만 쓰면 자동으로 내부에 값을 저장하는 공간도 만들어줌(코드 간략화, 인식 개선)
        // 외부에서 직접 변수에 접근하지 않고, 프로퍼티를 통해서만 값을 주고받게 할 수 있음(캡슐화[정보 은닉])
       
        // ex)

        // 예전 방식(직접 구현)
        
        // private string name;
        // public string Name
        // {
        //     get { return name; }
        //     set { name = value; }
        // }

        // 자동 구현 프로퍼티(간단)

        // public string Name { get; set; }


        // 아이템 이름
        public string Name { get; set; }
        // 아이템 능력
        public string Effect {  get; set; }
        // 아이템 설명
        public string Description {  get; set; }
        // 아이템 장착 유무
        public bool IsEquipped {  get; set; }

        // 아이템을 만들 때(생성할 때) 필요한 정보(이름, 효과, 설명)를 넣어주는 특별한 함수(생성자)

        public Item(string name, string effect, string description)
        {
            // 위에서 받은 name을 Name에 저장
            Name = name;
            // 위에서 받은 effect를 Effect에 저장
            Effect = effect;
            // 위에서 받은 description을 Description에 저장
            Description = description;
            // 처음에는 장착 안 한 상태(false)로 시작
            IsEquipped = false;
        }
    }

    // 상점에서 판매하는 아이템 클래스

    class ShopItem
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsPurchased { get; set; }

        public ShopItem(string name, string effect, string description, int price, bool isPurchased =  false)
        {
            Name = name;
            Effect = effect;
            Description = description;
            Price = price;
            IsPurchased = isPurchased;
        }
    }

    // [internal]은 이 클래스가 같은 프로젝트(어셈블리) 안에서만 접근 가능하다는 의미.

    internal class Program
    {
        // 프로그램의 "시작점(Entry Point)"임

        static void Main(string[] args)
        {
            //플레이어 정보
            int playerGold = 800;

            //인벤토리(플레이어가 가진 아이템)
            // var는 변수의 타입(자료형)을 컴퓨터가 알아서 정해달라는 의미
            // 즉, 오른쪽에 어떤 값을 넣는지 보고 C#이 자동으로 변수의 자료형을 결정
            // 너무 남용하면 코드가 헷갈릴 수 있지만 타입이 명확할 때는 코드를 짧고 간단하게 쓸 수 있음

            var inventory = new List<Item>
            {
                new Item("무쇠갑옷", "방어력 +5", "무쇠로 만들어져 튼튼한 갑옷입니다."),
                new Item("스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다."),
                new Item("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검입니다.")
            };

            // 상점 아이템 목록
            var shopItems = new List<ShopItem>()
            {
                new ShopItem("수련자 갑옷", "방어력 +5", "수련에 도움을 주는 갑옷입니다.", 1000),
                new ShopItem("무쇠갑옷", "방어력 +9", "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, true), // 이미 구매
                new ShopItem("스파르타의 갑옷", "방어력 +15", "스파르타 전사들이 사용했다는 전설의 갑옷입니다.", 3500),
                new ShopItem("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다.", 600),
                new ShopItem("청동 도끼", "공격력 +5", "어디선가 사용됐던거 같은 도끼입니다.", 1500),
                new ShopItem("스파르타의 창", "공격력 +7", "스파르타 전사들이 사용했다는 전설의 창입니다.", 2500, true) // 이미 구매
            };

            // 프로그램 실행 여부를 제어하는 변수

            // 반복문(while)과 함께 사용
            // 프로그램이 한 번만 사용되고 끝나는 것이 아닌 메뉴를 계속 보여주고, 사용자가 원하는 행동을 반복해서 처리하려면 반복문(while, for 등)이 필요

            // 종료 조건이 필요
            // 무한 반복문(while(true))을 쓰면 프로그램이 끝나지 않고 계속 돌아감
            // 사용자가 "종료"를 선택하면 프로그램이 멈춰야 함
            // 이때 isRunning이 true일 때만 반복하도록 하면
            // 사용자가 종료(ex) 0 입력)를 선택했을 때 isRunning을 false로 바꿔서 반복문을 빠져나와 프로그램이 종료됨

            bool isRunning = true; 

            // 실행 중일 동안

            while (isRunning)
            {
                // 안내 메세지 출력

                // [Console.WriteLine()] 화면에 텍스트를 한 줄씩 출력. 안내 메세지, 선택지 등을 보여줄 떄 사용

                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();

                // 선택지 출력

                Console.WriteLine();
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine();
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine();
                Console.WriteLine("3. 상점");
                Console.WriteLine();
                Console.WriteLine("0. 종료하기");
                Console.WriteLine();
                Console.WriteLine();

                // 입력 안내 및 입력 받기

                // [Console.Write()] 텍스트를 출력하지만 줄 바꿈을 하지 않음
                // 입력 프롬프트(>>)를 만들 때 사용하면 입력 위치가 자연스럽게 이어짐
                // [\n] 프로그래밍에서 "줄 바꿈(개행, newline)"을 의미하는 특수 문자
                // \는 역슬래시로 인식됨
                // 단순이 폰트 차이임
                // 실제로는 같음
                // 단순히 "문자코드(ASCII/유니코드)에서 역슬래시와 원화 기호가 같은 위치(0x5C)"를 공유하기 때문임

                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                // 사용자 입력 확인

                // string input = Console.ReadLine() 입력받은 값을 input 변수에 저장
                // 나중에 조건문(if 등)으로 분기하거나, 입력값을 확인 할 때 사용

                string input = Console.ReadLine();

                // [Console.Clear();] 이전 화면을 지워서 깔끔하게 만듬

                Console.Clear();

                // 처음에만 if문으로 사용 후  참이 아닐시에만 else if문들이 검사를 시작함으로
                // 이러한 조건이 겹치지 않는 경우에는 if문으로만 사용하는 것이 아닌 else if문을 이용해서 불필요한 존건 검사를 방지 할 수 있음

                if (input == "1")
                {
                    // 상태 보기 출력

                    Console.WriteLine("상태 보기");
                    Console.WriteLine("캐릭터의 정보가 표시 됩니다.");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Lv. 01");
                    Console.WriteLine("LeafPuppy (전사)");
                    Console.WriteLine("공격력 : 10");
                    Console.WriteLine("방어력 : 5");
                    Console.WriteLine("체력 : 100");
                    Console.WriteLine($"Gold : {playerGold} G");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("0. 돌아가기");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                    // [subinput] 서브 메뉴에서 입력을 따로 저장하는 변수
                    // 메인 메뉴에서 input을 이미 사용중이기에 또 다시 input을 사용하면 메인 메뉴에서 사용하던 이전 input 값이 덮어쓰여서 헷갈릴 수 있음
                    // 그렇기에 각 메뉴(메인, 서브)에서 입력을 명확하게 구분하면 코드를 읽고 관리하기 쉬워짐

                    string subinput = Console.ReadLine();
                    if (subinput == "0")
                    {
                        Console.Clear();

                        // [continue;] 메인 메뉴로 돌아감
                        // continue 문은 반복문(while, for, foreach 등) 안에서 사용될 때, 형재 반복(루프)의 나머지 코드를 건너뛰고,
                        // 바로 다음 반복을 시작하게 만듬
                        // 즉, continue를 만나면 그 이후에 존재하는 코드는 실행하지 않고 while 조건을 다시 검사해서 반복문의 처음(=메인 메뉴 출력 부분)으로 이동
                        
                        continue; 
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("잘못된 입력입니다. 엔터를 누르면 메인메뉴로 돌아갑니다.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                }
                else if (input == "2")
                {
                    while (true)
                    {
                        // 인벤토리 화면 출력

                        Console.WriteLine("인벤토리");
                        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("[아이템 목록]");
                        Console.WriteLine();
                        Console.WriteLine();
                        foreach (var item in inventory)
                        {
                            // item.IsEquipped가 true면 [ E ] 표시가 붙어서 "장착 중"임을 알려줌
                            // [?]는
                            // 자료형 뒤에 붙이면 "이 변수는 값이 없을 수도 있음(null이 될 수도 있음)"이라는 뜻
                            // 조건 ? 참일때 값 : 거짓일 떄 값 이런 식으로 한줄로 if/else처럼 값을 선택할 때 사용
                            // 어떤 객체가 null이 아닐 때만 그 뒤의 속성이나 메서드를 사용하고 싶을 때 a?.b처럼 사용

                            string equipMark = item.IsEquipped ? "[ E ] " : "";

                            // 이름, 효과, 설명이 보기 좋게 정렬되어 나옴
                            // [$]은 "문자열 보간(String Interpolation)"을 사용할 때 붙임
                            // 대상 되는 문자열 안에 변수나 식을 직접 넣는다는 뜻
                            // 중괄호({})안에 변수나 계산식을 넣어서 값이 자동으로 문자열에 들어가게 해줌

                            Console.WriteLine($"- {equipMark} {item.Name,-10} | {item.Effect,-8} | {item.Description}");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("1. 장착관리");
                        Console.WriteLine();
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                        string subinput = Console.ReadLine();

                        // 인벤토리 메뉴에서 나가서 메인 메뉴로 돌아감
                        
                        if (subinput == "0")
                        {
                            Console.Clear();

                            // 인벤토리 메뉴에서 나가서 메인 메뉴로 돌아감
                            // [break]는 반복문을 완전히 종료하고 반복문 바깥(다음 코드)으로 바로 빠져나감
                            // 즉, 더 이상 반복하지 않고 반복문을 "탈출"함.
                            // 나가기를 누르면 메뉴 반복문을 완전히 종료하고 메인 메뉴로 돌아가고 싶을때 사용

                            break;
                        }
                        else if (subinput == "1")
                        {
                            // 장착 관리 메뉴로 진입

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("인벤토리 - 장착 관리");
                                Console.WriteLine();
                                Console.WriteLine("보유 중인 아이템을 관리 할 수 있습니다.");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("[아이템 목록]");
                                for (int i = 0; i < inventory.Count; i++)
                                {
                                    var item = inventory[i];
                                    string equipMark = item.IsEquipped ? "[ E ]" : "";
                                    Console.WriteLine($"- {i + 1} {equipMark}{item.Name,-10} | {item.Effect,-8} | {item.Description}");
                                }
                                Console.WriteLine();
                                Console.WriteLine("0. 나가기");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("원하시는 행동을 입력해주세요.\n>> ");

                                string equipInput = Console.ReadLine();

                                if (equipInput == "0")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else if (int.TryParse(equipInput, out int idx) && idx >= 1 && idx <= inventory.Count)
                                {
                                    var selectedItem = inventory[idx - 1];
                                    if (!selectedItem.IsEquipped)
                                    {
                                        selectedItem.IsEquipped = true;
                                        Console.WriteLine($"\n{selectedItem.Name}을(를) 장착했습니다.");
                                    }
                                    else
                                    {
                                        selectedItem.IsEquipped = false;
                                        Console.WriteLine($"\n{selectedItem.Name}의 장착을 해제했습니다.");
                                    }
                                    Console.WriteLine("엔터를 누르면 계속합니다.");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("잘못된 입력입니다. 엔터를 누르면 장착 관리로 돌아갑니다.");
                                    Console.ReadLine();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("잘못된 입력입니다. 엔터를 누르면 장착 관리로 돌아갑니다.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
                else if (input == "3")
                {
                    while (true)
                    {
                        Console.Clear ();
                        Console.WriteLine("상점");
                        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                        Console.WriteLine();
                        Console.WriteLine("[보유 골드]");
                        Console.WriteLine($"{playerGold} G");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("[아이템 목록]");
                        Console.WriteLine();
                        Console.WriteLine();
                        for (int i = 0; i < shopItems.Count; i++)
                        {
                            string priceOrStatus = shopItems[i].IsPurchased ? "구매완료" : $"{shopItems[i].Price} G";
                            Console.WriteLine($"- {shopItems[i].Name,-12} | {shopItems[i].Effect,-10} | {shopItems[i].Description,-40} | {priceOrStatus}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("1. 아이템 구매");
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("원하시는 행동을 입력해 주세요.\n>> ");

                        string shopinput = Console.ReadLine();
                        if (shopinput == "0")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (shopinput == "1")
                        {
                            // 아이템 구매 메뉴

                            while (true)
                            {
                                Console.Clear () ;
                                Console.WriteLine("상점 - 아이템 구매");
                                Console.WriteLine();
                                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                                Console.WriteLine();
                                Console.WriteLine ("[보유 골드]");
                                Console.WriteLine($"{playerGold} G");
                                Console.WriteLine();
                                for (int i = 0; i < shopItems.Count; i++)
                                {
                                    string priceOrStatus = shopItems[i].IsPurchased ? "구매완료" : $"{shopItems[i].Price} G";
                                    Console.WriteLine($"- {i + 1} {shopItems[i].Name,-12} | {shopItems[i].Effect,-10} | {shopItems[i].Description,-40} | {priceOrStatus}");
                                }
                                Console.WriteLine ();
                                Console.WriteLine("0. 나가기");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("원하시는 행동을 입력해주세요.\n>> ");

                                string buyInput = Console.ReadLine();
                                if (buyInput == "0")
                                {
                                    Console.Clear();
                                    break;
                                }
                                else if (int.TryParse(buyInput, out int idx) && idx >= 1 && idx <= shopItems.Count)
                                {
                                    var selected = shopItems[idx - 1];
                                    if (selected.IsPurchased)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("이미 구매한 아이템입니다.");
                                    }
                                    else if (playerGold >= selected.Price)
                                    {
                                        playerGold -= selected.Price;
                                        selected.IsPurchased = true;

                                        //인벤토리에 추가

                                        inventory.Add(new Item(selected.Name, selected.Effect, selected.Description));
                                        Console.WriteLine();
                                        Console.WriteLine("구매를 완료했습니다.");
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Gold가 부족합니다.");
                                    }
                                    Console.WriteLine("엔터를 누르면 계속합니다.");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("잘못된 입력입니다. 엔터를 누르면 계속합니다.");
                                    Console.ReadLine();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("잘못된 입력입니다. 엔터를 누르면 상점으로 돌아갑니다.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
                else if (input == "0")
                {

                    // 프로그램 종료

                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 엔터를 누르면 메인메뉴로 돌아갑니다.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

         
        }
    }
}
