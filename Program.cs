
    //❤❤❤❤❤❤❤❤♡♡♡♡♡♡♡♥♥♥♥
    string name_user;
    int energy;
    int  energy_monster, skill_monster;
    int stage = 1, final_stage = 11;
    int random_luck_atk, random_luck_def;
    int total_energy;
    int damage = 0;
    string luck_you_atk = "", luck_you_def = "";
    string name_monster;
    string response = "";
    var result = (name_monster = "", skill_monster = 0, energy_monster = 0);

    First();

    void text(string write) {

        for (int i =  0; i < write.Length; i++) 
        {
            Console.Write(write[i]); 
        }
    }

    void First (){

        text("Sejá Bem-Vindo a Masmorra");

        Console.WriteLine();

        Console.WriteLine("Escreva seu nome: ");
        name_user = Console.ReadLine()!;

        if (name_user != "")
        {
            Console.WriteLine($"{result}");
        }

      
    }

    void Action (){

        Console.WriteLine("[A] Para atacar [D] para defender");
        Console.WriteLine("Você deseja tentar a sorte?");
        response = Console.ReadLine()!;

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
       int skill = rdskill.Next(1, 6)+6;

       Random rdluck = new Random();
       int luck = rdluck.Next(1, 6)+12 + rdluck.Next(1, 6)+12;

       Random rdenergy = new Random();
       int energy = rdenergy.Next(1, 6)+6;
    }


    void RafflingLuck(int luck) {

        if (response == "A") 
        {
            Random tryluck_atk = new Random();
            random_luck_atk = tryluck_atk.Next(2, 6);
            
        }
        else if (random_luck_atk <= luck)
        {
            string luck_you_atk = "Sortudo";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            text("Sortudo");
            Console.ResetColor();
        }
        else 
        {
            string luck_you_atk = "Azarado";
            Console.ForegroundColor = ConsoleColor.Red;
            text("Azarado");
            Console.ResetColor();
        }

        // --- Caso o usuário escolha diminuir o dano recebido ---

        if (response == "D") 
        {
            Random tryluck_def = new Random();
            random_luck_def = tryluck_def.Next(2, 6);
            
        }
        else if (random_luck_atk <= luck)
        {
            string luck_you_def = "Sortudo";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            text("Sortudo");
            Console.ResetColor();
        }
        else 
        {
            string luck_you_def = "Azarado";
            Console.ForegroundColor = ConsoleColor.Red;
            text("Azarado");
            Console.ResetColor();
        }
    }

    void Damage(string luck_you_atk, string luck_you_def)
    {
        if(luck_you_atk == "Sortudo") 
        {
            damage = 4;
            total_energy = energy - 2;
        }
        else if (luck_you_atk == "Azarado")
        {
            damage = 1;
            total_energy = energy - 2;
        }

        // Caso o usuário tenha tentado defender
        if (luck_you_def == "Sortudo")
        {
            damage = 2;
            total_energy = energy - 1;
          
        }

        else if (luck_you_def == "Azarado")
        {
            damage = 2;
            total_energy = energy - 3;
           
        }
    }
    
    void Turn (){
        if (energy_monster <= 0)
        {
            stage ++;
        }
    }

    void StatsPlayer (int skill, int luck, int energy) {
        Console.WriteLine($"Energia{energy} Habilidade {skill} Sorte {luck}");
    }