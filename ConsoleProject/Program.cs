namespace 콘솔프로젝트
{
    internal class Program
    {
        public struct GameData
        {
            public bool running;
            public int stageNumber;
            public char[,] map;
            public char[,] map2;
            public ConsoleKey inputKey;
            public Point playerPos;
            public Point princessPos;
            public Point reStartPos;
            public Point reStartPos2;
            public Point jombiePos;
            public PlayerState playerState;
            public Jombie jombieState;
            public Point DefenseAbility;
            public Point keyPos;
            public string[] inventory;
            public Point doorPos;
            public Point AttckAbility;
            public Point bossPos;
            public Boss bossState;
            public PlayerState OpenInventory;
        }

        public struct Point
        {
            public int x;
            public int y;
        }

        public struct PlayerState
        {
            public int attack;
            public int defense;
            public int hp;
        }

        public struct Jombie
        {
            public string name;
            public int attack;
            public int defense;
            public int hp;
        }

        public struct Boss
        {
            public string name;
            public int attack;
            public int defense;
            public int hp;
        }




        static GameData data;

        static void Main(string[] args)
        {
            Start();

            while (data.running)
            {
                Render();
                Input();
                Update();
            }

            End();
        }

        static void Start()
        {
            Console.CursorVisible = false;

            data = new GameData();

            data.running = true;
            data.map = new char[,]
            {
                {'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}, //0
                {'f','t','t','r','f','t','t','t','t','t','t','t','t','f','a','f'}, //1
                {'f','t','f','f','f','t','f','f','f','f','f','f','t','f','t','f'}, //2
                {'f','t','f','t','t','t','f','t','t','t','t','t','t','f','t','f'}, //3
                {'f','t','f','t','f','f','f','t','f','f','f','f','f','f','t','f'}, //4
                {'f','t','j','t','t','d','f','t','t','t','t','t','t','t','t','f'}, //5
                {'f','t','f','f','f','f','f','t','f','f','b','f','f','f','t','f'}, //6
                {'f','t','t','t','t','t','t','t','t','f','t','t','t','f','t','f'}, //7
                {'f','t','f','f','f','f','f','f','f','f','f','f','t','f','t','f'}, //8
                {'f','t','t','t','t','k','f','t','t','t','t','t','t','f','r','f'}, //9
                {'f','f','f','f','f','f','f','f','d','f','f','f','f','f','f','f'},
                {'f','f','f','f','f','f','f','t','t','t','f','f','f','f','f','f'},
                {'f','f','f','f','f','f','f','t','t','t','f','f','f','f','f','f'},
                {'f','f','f','f','f','f','f','t','p','t','f','f','f','f','f','f'},
                {'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}
            };
            data.playerPos = new Point() { x = 8, y = 1 };
            data.princessPos = new Point() { x = 8, y = 13 };
            data.reStartPos = new Point() { x = 3, y = 1 };
            data.reStartPos2 = new Point() { x = 14, y = 9 };
            data.jombiePos = new Point() { x = 2, y = 5 };
            data.DefenseAbility = new Point() { x = 5, y = 5 };
            data.AttckAbility = new Point() { x = 14, y = 1 };
            data.keyPos = new Point() { x = 5, y = 9 };
            data.doorPos = new Point() { x = 8, y = 10 };
            data.bossPos = new Point() { x = 10, y = 6 };

            data.playerState = new PlayerState() { attack = 10, defense = 50, hp = 20 };
            data.jombieState = new Jombie() { name = "좀비", attack = 70, defense = 30, hp = 100 };
            data.bossState = new Boss() { name = "어마무시한드래곤", attack = 1000, defense = 0, hp = 100 };
            data.inventory = new string[1];
            data.inventory[0] = " ";



            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=           공주 구하기            =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("    계속하려면 아무키나 누르세요    ");
            Console.ReadKey();
        }

        static void End()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=           게임 클리어!           =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        static void Render()
        {
            Console.Clear();
            PrintMap();
            Console.WriteLine("인벤토리창: E");
            PrintPlayer();
            PrintPrincess();
            printReStart();
            printReStart2();
            printJombie();
            printDefenseAbility();
            printKey();
            printDoor();
            PrintAttackAbility();
            PrintBoss();
        }

        static void Input()
        {
            data.inputKey = Console.ReadKey(true).Key;
        }


        static void Update()
        {
            Move();
            CheckGameClear();
            OpenInventory();
        }
        static void PrintMap()
        {
            PrintFirstStage();

        }
        static void PrintFirstStage()
        {
            for (int x = 0; x < data.map.GetLength(0); x++)
            {
                for (int y = 0; y < data.map.GetLength(1); y++)
                {
                    if (data.map[x, y] == 'f')
                    {
                        Console.Write("#");
                    }
                    else if (data.map[x, y] == 'r')
                    {
                        Console.Write(" ");
                        data.map[x, y] = data.map[8, 1];
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }


        static void PrintPlayer()
        {
            Console.SetCursorPosition(data.playerPos.x, data.playerPos.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
        }

        static void PrintPrincess()
        {
            Console.SetCursorPosition(data.princessPos.x, data.princessPos.y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("P");
            Console.ResetColor();
        }

        static void printReStart()
        {
            Console.SetCursorPosition(data.reStartPos.x, data.reStartPos.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("R");
            Console.ResetColor();
        }
        static void printReStart2()
        {
            Console.SetCursorPosition(data.reStartPos2.x, data.reStartPos2.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("R");
            Console.ResetColor();
        }
        static void printJombie()
        {
            if (data.jombieState.hp == 0)
                return;
            Console.SetCursorPosition(data.jombiePos.x, data.jombiePos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("J");
            Console.ResetColor();

        }

        static void PrintBoss()
        {
            if (data.bossState.hp == 0)
                return;
            Console.SetCursorPosition(data.bossPos.x, data.bossPos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("B");
            Console.ResetColor();
        }

        static void printDefenseAbility()
        {
            Console.SetCursorPosition(data.DefenseAbility.x, data.DefenseAbility.y);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("D");
            Console.ResetColor();

        }

        static void printKey()
        {
            if (data.inventory[0] == "Key" || data.inventory[0] == "dooropen")
                return;
            Console.SetCursorPosition(data.keyPos.x, data.keyPos.y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("k");
            Console.ResetColor();

        }

        static void printDoor()
        {
            if (data.inventory[0] == "dooropen")
                return;
            Console.SetCursorPosition(data.doorPos.x, data.doorPos.y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("D");
            Console.ResetColor();
        }

        static void PrintAttackAbility()
        {
            Console.SetCursorPosition(data.AttckAbility.x, data.AttckAbility.y);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("A");
            Console.ResetColor();
        }
        static void OpenInventory()
        {
            switch (data.inputKey)
            {
                case ConsoleKey.E:
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight - 15);
                        Console.WriteLine("현재 플레이어의 상태입니다.");
                        Console.WriteLine("체력: " + data.playerState.hp);
                        Console.WriteLine("공격력: " + data.playerState.attack);
                        Console.WriteLine("방어력: " + data.playerState.defense);
                        if (data.inventory[0] == "Key")
                            Console.WriteLine("인벤토리에는 열쇠가 들어있습니다.");
                        else
                            Console.WriteLine("인벤토리에는 아무것도 없습니다.");
                        Thread.Sleep(1000);
                        break;

                    }

            }
        }
        static void Move()
        {
            switch (data.inputKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
            }
        }

        static void CheckGameClear()
        {

            if (data.playerPos.x == data.princessPos.x &&
                data.playerPos.y == data.princessPos.y)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.Write("공주를 구출 했습니다.");
                Thread.Sleep(1000);
                data.running = false;
            }
            if (data.playerPos.x == data.reStartPos.x &&
                data.playerPos.y == data.reStartPos.y || data.playerPos.x == data.reStartPos2.x &&
                data.playerPos.y == data.reStartPos2.y)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.Write("처음 장소로 이동합니다.");
                Thread.Sleep(1000);
                data.playerPos.x = 8;
                data.playerPos.y = 1;

            }
            if (data.playerPos.x == data.jombiePos.x && data.playerPos.y == data.jombiePos.y)
            {
                MeetJombie();
            }
            if (data.playerPos.x == data.DefenseAbility.x && data.playerPos.y == data.DefenseAbility.y)
            {
                DefenceAbility();
            }
            if (data.playerPos.x == data.keyPos.x && data.playerPos.y == data.keyPos.y)
            {
                StoreKey();
            }
            if (data.playerPos.x == data.doorPos.x && data.playerPos.y == data.doorPos.y)
            {
                OpenDoor();
            }
            if (data.playerPos.x == data.AttckAbility.x && data.playerPos.y == data.AttckAbility.y)
            {
                AttakAbility();
            }
            if (data.playerPos.x == data.bossPos.x && data.playerPos.y == data.bossPos.y)
            {
                MeetBoss();
            }
        }

        static void MoveUp()
        {
            Point next = new Point() { x = data.playerPos.x, y = data.playerPos.y - 1 };
            if (data.map[next.y, next.x] != 'f')
            {
                data.playerPos = next;
            }
        }

        static void MoveDown()
        {
            Point next = new Point() { x = data.playerPos.x, y = data.playerPos.y + 1 };
            if (data.map[next.y, next.x] != 'f')
            {
                data.playerPos = next;
            }
        }

        static void MoveLeft()
        {
            Point next = new Point() { x = data.playerPos.x - 1, y = data.playerPos.y };
            if (data.map[next.y, next.x] != 'f')
            {
                data.playerPos = next;
            }
        }

        static void MoveRight()
        {
            Point next = new Point() { x = data.playerPos.x + 1, y = data.playerPos.y };
            if (data.map[next.y, next.x] != 'f')
            {
                data.playerPos = next;
            }
        }

        static void MeetJombie()
        {
            while (true)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.Write("좀비와 만났습니다! (싸운다(F)/도망친다(R))");

                if (data.jombieState.hp == 0)
                    return;
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.F)
                {
                    data.playerState.hp = data.playerState.hp + data.playerState.defense - data.jombieState.attack;
                    if (data.playerState.hp > 0)
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight - 13);
                        Console.WriteLine("좀비와 싸우는 중 ... ");
                        Thread.Sleep(1000);
                        Console.Write("방어력 버프 덕분인지 아슬아슬한 피로 벗어났습니다.");
                        Thread.Sleep(1000);
                        data.jombieState.hp = 0;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight - 13);
                        Console.Write("좀비와 싸워서 체력이 0이 되었습니다. 처음부터 다시 시작합니다.");
                        Thread.Sleep(1000);
                        data.playerPos.x = 8;
                        data.playerPos.y = 1;
                        data.playerState.hp = 20;
                        data.playerState.defense = 50;
                        data.playerState.attack = 10;
                        data.jombieState.hp = 100;
                        data.bossState.hp = 100;
                        data.inventory[0] = " ";
                        break;
                    }
                }
                else if (input == ConsoleKey.R)
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 13);
                    Console.Write("도망치는데 성공했습니다. 방어력을 높여 좀비에게 도전하세요.");
                    Thread.Sleep(1000);
                    data.playerPos.x = 3;
                    data.playerPos.y = 5;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 14);
                    Console.Write("잘못 입력하셨습니다 싸운다(F)/도망친다(R)중 선택해주세요");
                    Thread.Sleep(1000);
                }
            }
        }

        static void MeetBoss()
        {
            if (data.bossState.hp == 0)
                return;
            Console.SetCursorPosition(0, Console.WindowHeight - 15);
            Console.Write("보스와 만났습니다! (싸운다(F)/도망친다(R))");

            while (true)
            {
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.F)
                {
                    data.bossState.hp = data.bossState.hp + data.bossState.defense - data.playerState.attack;
                    if (data.playerState.attack > data.bossState.hp)
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight - 13);
                        Console.WriteLine("보스를 선빵 때렸습니다. 보스의 상태를 확인하는 중...");
                        Thread.Sleep(1000);
                        Console.Write("공격력 버프로 인해 보스가 한방에 죽어버렸습니다. 승리하셨습니다.");
                        Thread.Sleep(1000);
                        Console.Write(" ");
                        data.bossState.hp = 0;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight - 13);
                        Console.Write("보스의 어마무시한 공격력에 죽었습니다. 처음부터 다시 시작합니다.");
                        Thread.Sleep(1000);
                        data.playerPos.x = 8;
                        data.playerPos.y = 1;
                        data.playerState.hp = 20;
                        data.playerState.defense = 50;
                        data.playerState.attack = 10;
                        data.jombieState.hp = 100;
                        data.bossState.hp = 100;
                        data.inventory[0] = " ";
                        break;
                    }
                }
                else if (input == ConsoleKey.R)
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 13);
                    Console.Write("도망치는데 성공했습니다. tip)보스는 너무 강해 공격력을 높여 한방에 죽여야 합니다.");
                    Thread.Sleep(1000);
                    data.playerPos.x = 10;
                    data.playerPos.y = 5;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 14);
                    Console.Write("잘못 입력하셨습니다 싸운다(F)/도망친다(R)중 선택해주세요");
                    Thread.Sleep(1000);
                }
            }
        }


        static void DefenceAbility()
        {
            if (data.playerState.defense == 50)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.WriteLine("방어력을 버프 먹었습니다. 방어력이 10 올라갑니다.");
                data.playerPos.x = 4;
                data.playerPos.y = 5;
                data.playerState.defense += 10;
                Console.Write($"현재 방어력은 {data.playerState.defense}입니다.");
                Thread.Sleep(1000);
            }
            else
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.Write("이미 먹은 버프입니다.");
                data.playerPos.x = 4;
                data.playerPos.y = 5;
                Thread.Sleep(1000);
            }

        }

        static void AttakAbility()
        {
            if (data.playerState.attack == 10)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.WriteLine("공격력을 버프 먹었습니다. 공격력이 100 올라갑니다.");
                data.playerPos.x = 14;
                data.playerPos.y = 2;
                data.playerState.attack += 100;
                Console.Write($"현재 공격력은 {data.playerState.attack}입니다.");
                Thread.Sleep(1000);
            }
            else
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 15);
                Console.Write(" 이미 먹은 버프입니다.");
                data.playerPos.x = 14;
                data.playerPos.y = 2;
                Thread.Sleep(1000);
            }
        }

        static void StoreKey()
        {
            if (data.inventory[0] == "Key")
                return;
            Console.SetCursorPosition(0, Console.WindowHeight - 15);
            data.inventory[0] = "Key";
            Console.Write("열쇠를 주웠습니다. 인벤토리에 열쇠가 보관되었습니다.");
            Thread.Sleep(1000);
            data.playerPos.x = 4;
            data.playerPos.y = 9;
        }

        static void OpenDoor()
        {
            if (data.inventory[0] == "dooropen")
                return;
            Console.SetCursorPosition(0, Console.WindowHeight - 15);
            Console.Write("문이 잠겨있습니다. 열쇠를 사용하시겠습니까? 예(Y)/아니요(N)");
            Thread.Sleep(1000);
            while (true)
            {
                if (data.inventory[0] == "dooropen")
                    return;
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Y)
                {
                    if (data.inventory[0] == "Key")
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight - 13);
                        Console.Write("잠금을 푸는 중 ...");
                        Thread.Sleep(1000);
                        Console.Write("문이 열렸습니다.");
                        Thread.Sleep(1000);
                        data.inventory[0] = "dooropen";
                        break;
                    }
                    else if (data.inventory[0] == " ")
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight - 13);
                        Console.Write("열쇠가 없습니다. 열쇠를 찾아오세요");
                        Thread.Sleep(1000);
                        data.playerPos.x = 8;
                        data.playerPos.y = 9;
                        break;
                    }
                }
                else if (input == ConsoleKey.N)
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 13);
                    Console.Write("열쇠가 없으면 열쇠를 찾아오세요");
                    Thread.Sleep(1000);
                    data.playerPos.x = 8;
                    data.playerPos.y = 9;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.WindowHeight - 14);
                    Console.Write("잘못입력하셨습니다. 예(Y)/아니요(N)로 입력해주세요");
                    Thread.Sleep(1000);
                }
            }
        }

    }
}

