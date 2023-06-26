//By NicholasDev
    string name_user; //Nome do player
    int energy_monster, skill_monster; //Status do monstro
    int stage = 1, final_stage = 11; //Estágio
    int damage = 0, takenDamage = 0; //Dano
    int luck, skill, energy; //hero stats
    string name_monster; //Nome do monstro
    string luck_state = ""; //Quantidade da sorte
    string response = ""; //Tentar a sorte ou não
    var result = (name_monster = "", skill_monster = 0, energy_monster = 0); //Vetor do status do monstro
    int luck_test;//Teste de sorte

    Skills();
    First();

    void text(string write) {

        for (int i =  0; i < write.Length; i++) 
        {
            Console.Write(write[i]); 
        }
        
    }

    void First (){

        Console.ForegroundColor = ConsoleColor.White;

        text("Sejá Bem-Vindo a Masmorra");

        Console.WriteLine();

        Console.WriteLine("Escreva seu nome: ");
        name_user = Console.ReadLine()!;
        Loader();
        Console.Clear();
        RafflingLuck();
    }

    void Loader () {

        switch (stage)
        {   
            case 1:
            result=(name_monster = "Lobo Cinzento" ,skill_monster = 3, energy_monster = 3);
            break;
            
            case 2:
            result=(name_monster = "Lobo Branco" ,skill_monster = 3, energy_monster = 3);
            break;

            case 3:
            result=(name_monster = "Goblin" ,skill_monster = 5, energy_monster = 4);
            break;

            case 4:
            result=(name_monster = "Orc Vesgo" ,skill_monster = 5, energy_monster = 5);
            break;

            case 5:
            result=(name_monster = "Orc Barbudo" ,skill_monster = 5, energy_monster = 5);
            break;

            case 6:
            result=(name_monster = "Zumbi Manco" ,skill_monster = 6, energy_monster = 7);
            break;

            case 7:
            result=(name_monster = "Zumbi Balofo" ,skill_monster = 6, energy_monster = 7);
            break;

            case 8:
            result=(name_monster = "Troll" ,skill_monster = 8, energy_monster = 7);
            break;

            case 9:
            result=(name_monster = "Ogro" ,skill_monster = 8, energy_monster = 9);
            break;

            case 10:
            result=(name_monster = "Ogro Furioso" ,skill_monster = 10, energy_monster = 9);
            break;

            case 11:
            result=(name_monster = "Necromante Maligno" ,skill_monster = 12, energy_monster = 12);
            break;
            
        }
    }


    void Skills () {
       Random rdskill = new Random();
       skill = rdskill.Next(1, 7)+6;

       Random rdluck = new Random();
       luck = rdluck.Next(1, 7)+rdluck.Next(1, 7)+12;

       Random rdenergy = new Random();
       energy = rdenergy.Next(1, 7)+6;
    }

    // Quando o player esta em combate
    void combat()
    {   
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Você deseja [A]tacar ou [D]efender?");
        response = Console.ReadLine()!.ToUpper();

        if (response == "A") 
        {
            Random tryAtk = new Random();
            int hero_attack_test = tryAtk.Next(1,7) + tryAtk.Next(1,7)+skill;
            int monster_attack_test = tryAtk.Next(1,7) + tryAtk.Next(1,7)+skill_monster;
            Damage();
            if (hero_attack_test > monster_attack_test)
            {
                energy_monster = energy_monster - damage;
                text($"{name_monster} perdeu {damage} HP.\n");
            }
            else if (hero_attack_test < monster_attack_test)
            {
                energy = energy - takenDamage;
                text($"{name_user} perdeu {takenDamage} HP.\n");
            }
            else
            {
                text("Ambos erram.\n");
            }
            luck_state = "";
            Thread.Sleep(360);
        }
        else if (response == "D") 
        {
            Random tryAtk = new Random();
            int hero_attack_test = tryAtk.Next(1,7) + tryAtk.Next(1,7)+skill;
            int monster_attack_test = tryAtk.Next(1,7) + tryAtk.Next(1,7)+skill_monster;
            Damage();
            if (hero_attack_test < monster_attack_test)
            {
                energy = energy - takenDamage-1;
                text($"{name_user} perdeu {takenDamage-1} HP, bloqueiou.\n");
            }
            else if (hero_attack_test > monster_attack_test)
            {
                energy_monster = energy_monster - damage-1;
                text($"{name_monster} perdeu {damage-1} HP, contra-ataca.\n");
            }
            else
            {
                text("Ambos erram.\n");
            }
            luck_state = "";
            Thread.Sleep(360);
        }
        else
        {
            RafflingLuck();
        }
    Turn();
   }

    void RafflingLuck() {
        Console.Clear();
        StatsMonster();

        Console.WriteLine();

        StatsPlayer();
        if (luck_state == "")
        {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Você deseja tentar a sorte?");
        response = Console.ReadLine()!.ToUpper();
        if (response == "S") 
        {
            Random tryluck = new Random();
            luck_test = tryluck.Next(1,7) + tryluck.Next(1,7);
            if (luck_test <= luck)
            {
            luck_state = "Sortudo";
            Console.ForegroundColor = ConsoleColor.Green;
            text("Sortudo\n");
            }
            else 
            {
            luck_state = "Azarado";
            Console.ForegroundColor = ConsoleColor.Red;
            text("Azarado\n");
            }
            luck = luck - 1;
            Console.ResetColor();
            combat();
        }
        else
        {
            combat();
        }
        }
        else
        {
            combat();
        }
    }

    void Damage()
    {
        if(luck_state == "Sortudo") 
        {
            damage = 4;
            takenDamage = 1;
        }
        else if (luck_state == "Azarado")
        {
            damage = 1;
            takenDamage = 3;
        }
        else
        {
            damage = 2;
            takenDamage = 2;
        }
    }
    

    // Loop para o jogo continuar
    void Turn (){
        if (energy_monster <= 0 && stage < final_stage && energy > 0)
        {
            stage++;
            Loader();
            RafflingLuck();
        
        }
        else if (stage == final_stage && energy_monster <= 0 && energy > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Você Venceu");
        }
        else if (energy <= 0)
        {
            Console.WriteLine("Game Over");
        }
        else{
            RafflingLuck();
        }
    }


    void StatsPlayer () {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write($"Nome: {name_user} ");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"HP: {energy} ");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Habilidade: {skill} ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Sorte: {luck}");
        Console.ResetColor();
    }
    void StatsMonster (){

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write($"Monstro: {result.Item1} ");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"HP: {energy_monster}/{result.Item3} ");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Habilidade: {skill_monster} ");

        Console.ResetColor();

    }

    Console.ResetColor();