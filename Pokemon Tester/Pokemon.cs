namespace Pokemon_Tester
{
    internal class Pokemon
    {
        private int hp_base;
        private int attack_base;
        private int defense_base;
        private int specialattack_base;
        private int specialdefense_base;
        private int speed_base;
        private int level;

        public int HP_Base
        {
            get { return hp_base; }
            set { hp_base = value; }
        }

        public int Attack_Base
        {
            get { return attack_base; }
            set { attack_base = value; }
        }

        public int Defense_Base
        {
            get { return defense_base; }
            set { defense_base = value; }
        }

        public int SpecialAttack_Base
        {
            get { return specialattack_base; }
            set { specialattack_base = value; }
        }

        public int SpecialDefense_Base
        {
            get { return specialdefense_base; }
            set { specialdefense_base = value; }
        }

        public int Speed_Base
        {
            get { return speed_base; }
            set { speed_base = value; }
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Type2 { get; set; }
        public int Number { get; set; }
        public int Average { get { return (HP_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefense_Base + Speed_Base) / 6; } }
        public int Total { get { return HP_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefense_Base + Speed_Base; } }

        public int HP_Full { get { return (((HP_Base + 50) * Level) / 50) + 10; } }
        public int Attack_Full { get { return ((Attack_Base * Level) / 50) + 5; } }
        public int Defense_Full { get { return ((Defense_Base * Level) / 50) + 5; } }
        public int SpecialAttack_Full { get { return ((SpecialAttack_Base * Level) / 50) + 5; } }
        public int SpecialDefense_Full { get { return ((SpecialDefense_Base * Level) / 50) + 5; } }
        public int Speed_Full { get { return ((Speed_Base * Level) / 50) + 5; } }
        public int Average_Full { get { return (HP_Full + Attack_Full + Defense_Full + SpecialAttack_Full + SpecialDefense_Full + Speed_Full) / 6; } }
        public int Total_Full { get { return HP_Full + Attack_Full + Defense_Full + SpecialAttack_Full + SpecialDefense_Full + Speed_Full; } }

        public int Level
        {
            get { return level; }
            private set { level = value; }
        }

        public int BattlesWon { get; set; }
        public int hpCurrent;

        public int HP_Current
        {
            get { return hpCurrent; }
            set { hpCurrent = value; }
        }


        //Methods

        public void LevelUp()
        {
            if (Level < 100)
            {
                Level++;
            }
        }

        public void TakeDamage(int damage)
        {
            HP_Current -= damage;
        }

        public void WinBattle()
        {
            BattlesWon++;
        }

        public string PrintDexInfo()
        {
            return
                $"{Number}|{Name}|{Type}|{Type2}|{Total}|{HP_Base}|{Attack_Base}|{Defense_Base}|{SpecialAttack_Base}|{SpecialDefense_Base}|{Speed_Base}|{Average}|";
        }

        public string PrintFullPokemonInfo()
        {
            return
            $"#{Number} | {Name} ({Level}) | {Type}{Type2} | Battles Won:{BattlesWon}" +
                $"\nBase stats:" +
                $"\n\t* Total           = {Total}" +
                $"\n\t* Average         = {Average}" +
                $"\n\t* Health          = {HP_Base}" +
                $"\n\t* Attack          = {Attack_Base}" +
                $"\n\t* Defense         = {Defense_Base}" +
                $"\n\t* Special Attack  = {SpecialAttack_Base}" +
                $"\n\t* Special Defense = {SpecialDefense_Base}" +
                $"\n\t* Speed           = {Speed_Base}" +
                $"\nFull stats:" +
                $"\n\t* Total           = {Total_Full}" +
                $"\n\t* Average         = {Average_Full}" +
                $"\n\t* Health          = {HP_Full}" +
                $"\n\t* Attack          = {Attack_Full}" +
                $"\n\t* Defense         = {Defense_Full}" +
                $"\n\t* Special Attack  = {SpecialAttack_Full}" +
                $"\n\t* Special Defense = {SpecialDefense_Full}" +
                $"\n\t* Speed           = {Speed_Full}";
        }

        public string PrintMyPokeInfo()
        {
            return $"#{Number}|{Name}|{Level}|{Type}|{Type2}|Battles won: {BattlesWon}|{HP_Base}|{Attack_Base}|{Defense_Base}|{SpecialAttack_Base}|{SpecialDefense_Base}|{Speed_Base}";
        }

        public string PrintBasicInfo()
        {
            if (Name is null)
            {
                return "No data";
            }
            else
            {
                return $"#{Number}|{Name}({Level})|{Type}|{Type2}|Average stats: {Average_Full}|Battles won: {BattlesWon}";
            }
        }
    }
}