    //❤❤❤❤❤❤❤❤♡♡♡♡♡♡♡♥♥♥♥
    string name_user;
    int hp_monster, energy_monster, skill_monster;
    int stage = 1, final_stage = 11;
    string name_monster;
    var result = (name_monster = "", skill_monster = 0, energy_monster = 0);

    void loader () {
        Console.WriteLine("Sejá Bem-Vindo a Masmorra");

        Console.WriteLine("Escreva seu nome: ");
        name_user = Console.ReadLine()!;


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
            result=(name_monster = "Troll" ,skill_monster = 8, energy_monster = 7);
            break;

            case 8:
            result=(name_monster = "Ogro" ,skill_monster = 8, energy_monster = 9);
            break;

            case 9:
            result=(name_monster = "Ogro Furioso" ,skill_monster = 10, energy_monster = 9);
            break;

            case 10:
            result=(name_monster = "Necromante Maligno" ,skill_monster = 12, energy_monster = 12);
            break;

            case 11:
            result=(name_monster = "Lobo Cinzento" ,skill_monster = 3, energy_monster = 3);
            break;
            
        }
    }


    void skills () {
       Random rdskill = new Random ();
       int skill = rdskill.Next(1, 13);

       Random rdluck = new Random ();
       int luck = rdluck.Next(1, 19);

       Random rdenergy = new Random ();
       int energy = rdenergy.Next(1, 13);
    }

    
