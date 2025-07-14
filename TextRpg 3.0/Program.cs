using System;
using System.Collections.Generic;

namespace TextRpg_3
{
    class Item
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Description { get; set; }
        public bool IsEquipped { get; set; }

        public Item(string name, string effect, string description)
        {
            Name = name;
            Effect = effect;
            Description = description;
            IsEquipped = false;
        }
    }
    class ShopItem
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsPurchased { get; set; }

        public ShopItem(string name, string effect, string description, int price, bool isPurchased = false)
        {
            Name = name;
            Effect = effect;
            Description = description;
            Price = price;
            IsPurchased = isPurchased;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int playerGold = 800;
            Item[] inventory = new Item[]
            {
                new Item("무쇠갑옷", "방어력 +5", "무쇠로 만들어져 튼튼한 갑옷입니다."),
                new Item("스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다."),
                new Item("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검입니다.")
            };

            var shopItems = new List<ShopItem>()
            {
                new ShopItem("수련자 갑옷", "방어력 +5", "수련에 도움을 주는 갑옷입니다.", 1000),
                new ShopItem("무쇠갑옷", "방어력 +9", "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, true),
                new ShopItem("스파르타의 갑옷", "방어력 +15", "스파르타 전사들이 사용했다는 전설의 갑옷입니다.", 3500),
                new ShopItem("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다.", 600),
                new ShopItem("청동 도끼", "공격력 +5", "어디선가 사용됐던거 같은 도끼입니다.", 1500),
                new ShopItem("스파르타의 창", "공격력 +7", "스파르타 전사들이 사용했다는 전설의 창입니다.", 2500, true)
            };

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();

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

                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                string input = Console.ReadLine();

                Console.Clear();

                if (input == "1")
                {

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

                    string subinput = Console.ReadLine();

                    if (subinput == "0")
                    {
                        Console.Clear();

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
                        Console.WriteLine("인벤토리");
                        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("[아이템 목록]");
                        Console.WriteLine();
                        Console.WriteLine();
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            var item = inventory[i];
                            string equipMark = item.IsEquipped ? "[ E ] " : "";
                            Console.WriteLine($"- {equipMark} {item.Name,-10} | {item.Effect,-8} | {item.Description}");
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("1. 장착관리");
                        Console.WriteLine();
                        Console.WriteLine("2. 아이템 삭제");
                        Console.WriteLine();
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                        string subinput = Console.ReadLine();

                        if (subinput == "0")
                        {
                            Console.Clear();
                            break;
                        }

                        else if (subinput == "1")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("인벤토리 - 장착 관리");
                                Console.WriteLine();
                                Console.WriteLine("보유 중인 아이템을 관리 할 수 있습니다.");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("[아이템 목록]");
                                for (int i = 0; i < inventory.Length; i++)
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
                                else if (int.TryParse(equipInput, out int idx) && idx >= 1 && idx <= inventory.Length)
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
                        else if (subinput == "2")
                        {
                            Console.Write("삭제할 아이템 번호를 입력하세요.\n>> ");
                            string delInput = Console.ReadLine();
                            if (int.TryParse(delInput, out int delidx) && delidx >= 1 && delidx <= inventory.Length)
                            {
                                int deleteIndex = delidx - 1;
                                Item[] newInventory = new Item[inventory.Length - 1];
                                int newidx = 0;
                                for (int i = 0; i < inventory.Length; i++)
                                {
                                    if (i == deleteIndex) continue;
                                    newInventory[newidx++] = inventory[i];
                                }
                                inventory = newInventory;
                                Console.WriteLine("아이템이 삭제되었습니다.");
                            }

                            else
                            {
                                Console.WriteLine("잘못된 번호입니다.");
                            }
                            Console.WriteLine("엔터를 누르면 계속합니다.");
                            Console.ReadLine();
                            Console.Clear();
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
                        Console.Clear();
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
                        Console.WriteLine();
                        Console.WriteLine("2. 아이템 판매");
                        Console.WriteLine();
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
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("상점 - 아이템 구매");
                                Console.WriteLine();
                                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                                Console.WriteLine();
                                Console.WriteLine("[보유 골드]");
                                Console.WriteLine($"{playerGold} G");
                                Console.WriteLine();
                                for (int i = 0; i < shopItems.Count; i++)
                                {
                                    string priceOrStatus = shopItems[i].IsPurchased ? "구매완료" : $"{shopItems[i].Price} G";
                                    Console.WriteLine($"- {i + 1} {shopItems[i].Name,-12} | {shopItems[i].Effect,-10} | {shopItems[i].Description,-40} | {priceOrStatus}");
                                }
                                Console.WriteLine();
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
                                    bool isDuplicate = false;
                                    for (int i = 0; i < inventory.Length; i++)
                                    {
                                        if (inventory[i].Name == selected.Name)
                                        {
                                            isDuplicate = true;
                                            break;
                                        }
                                    }

                                    if (isDuplicate)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("이미 인벤토리에 있는 아이템입니다. 중복 구매할 수 없습니다.");
                                    }

                                    else if (selected.IsPurchased)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("이미 구매한 아이템입니다.");
                                    }

                                    else if (playerGold >= selected.Price)
                                    {
                                        playerGold = selected.Price;
                                        selected.IsPurchased = true;

                                        Item[] newInventory = new Item[inventory.Length + 1];
                                        for (int i = 0; i < inventory.Length; i++)
                                        {
                                            newInventory[i] = inventory[i];
                                        }
                                        newInventory[newInventory.Length - 1] = new Item(selected.Name, selected.Effect, selected.Description);
                                        inventory = newInventory;

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

                                    if (selected.IsPurchased)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("이미 구매한 아이템입니다.");
                                    }

                                    else if (playerGold >= selected.Price)
                                    {
                                        playerGold -= selected.Price;
                                        selected.IsPurchased = true;
                                        Item[] newInventory = new Item[inventory.Length + 1];
                                        for (int i = 0; i < inventory.Length; i++)
                                        {
                                            newInventory[i] = inventory[i];

                                        }
                                        newInventory[newInventory.Length - 1] = new Item(selected.Name, selected.Effect, selected.Description);
                                        inventory = newInventory;

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

                        else if (shopinput == "2")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("상점 - 아이템 판매");
                                Console.WriteLine();
                                Console.WriteLine("[보유 골드]");
                                Console.WriteLine($"{playerGold} G");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("[인벤토리 목록]");
                                Console.WriteLine();
                                for (int i = 0; i < inventory.Length; i++)
                                {
                                    var item = inventory[i];
                                    Console.WriteLine($"- {i + 1} {item.Name,-10} | {item.Effect,-8} | {item.Description}");
                                }
                                Console.WriteLine();
                                Console.WriteLine("0. 나가기");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.Write("판매할 아이템 번호를 입력해주세요.\n>> ");
                                string sellInput = Console.ReadLine();
                                if (sellInput == "0")
                                {
                                    Console.Clear();
                                    break;
                                }

                                else if (int.TryParse(sellInput, out int sellIdx) && sellIdx >= 1 && sellIdx <= inventory.Length)
                                {
                                    var sellItem = inventory[sellIdx - 1];
                                    int originPrice = 0;
                                    foreach (var shopItem in shopItems)
                                    {
                                        if (shopItem.Name == sellItem.Name)
                                        {
                                            originPrice = shopItem.Price;
                                            break;
                                        }
                                    }

                                    if (originPrice == 0)
                                    {
                                        Console.WriteLine("이 아이템은 판매할 수 없습니다.");
                                    }

                                    else
                                    {
                                        int sellPrice = originPrice / 3;
                                        playerGold += sellPrice;
                                        Item[] newInventory = new Item[inventory.Length - 1];
                                        int newidx = 0;
                                        for (int i = 0; i < inventory.Length; i++)
                                        {
                                            if (i == sellIdx - 1) continue;
                                            newInventory[newidx++] = inventory[i];
                                        }
                                        inventory = newInventory;
                                        Console.WriteLine($"{sellItem.Name}을(를) 판매했습니다! (+{sellPrice}G)");
                                    }
                                    Console.WriteLine("엔터를 누르면 계속합니다.");
                                    Console.ReadLine();
                                }

                                else
                                {
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
