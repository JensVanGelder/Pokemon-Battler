namespace Pokemon_Tester
{
    internal class TypeAdvantages
    {
        public double GetTypeMultiplier(string type, Pokemon poke2)
        {
            switch (type)
            {
                case "Normal":
                    return Normal(poke2);

                case "Fire":
                    return Fire(poke2);

                case "Water":
                    return Water(poke2);

                case "Electric":
                    return Electric(poke2);

                case "Grass":
                    return Grass(poke2);

                case "Ice":
                    return Ice(poke2);

                case "Fighting":
                    return Fighting(poke2);

                case "Poison":
                    return Poison(poke2);

                case "Ground":
                    return Ground(poke2);

                case "Flying":
                    return Flying(poke2);

                case "Psychic":
                    return Psychic(poke2);

                case "Bug":
                    return Bug(poke2);

                case "Rock":
                    return Rock(poke2);

                case "Ghost":
                    return Ghost(poke2);

                case "Dragon":
                    return Dragon(poke2);

                case "Dark":
                    return Dark(poke2);

                case "Steel":
                    return Steel(poke2);

                case "Fairy":
                    return Fairy(poke2);

                default:
                    return 1;
            }
        }
        public double Fire(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Water":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Fire":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Grass":
                        dmgMultTotal *= 2;
                        break;

                    case "Ice":
                        dmgMultTotal *= 2;
                        break;

                    case "Bug":
                        dmgMultTotal *= 2;
                        break;

                    case "Rock":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Dragon":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Steel":
                        dmgMultTotal *= 2;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Normal(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Rock":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Ghost":
                        dmgMultTotal = 0;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Water(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Water":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Fire":
                        dmgMultTotal *= 2;
                        break;

                    case "Grass":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Ground":
                        dmgMultTotal *= 2;
                        break;

                    case "Rock":
                        dmgMultTotal *= 2;
                        break;

                    case "Dragon":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Electric(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Water":
                        dmgMultTotal *= 2;
                        break;

                    case "Electric":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Grass":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Ground":
                        dmgMultTotal = 0;
                        break;

                    case "Flying":
                        dmgMultTotal *= 2;
                        break;

                    case "Dragon":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Grass(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Fire":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Water":
                        dmgMultTotal *= 2;
                        break;

                    case "Grass":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Poison":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Ground":
                        dmgMultTotal *= 2;
                        break;

                    case "Flying":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Bug":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Rock":
                        dmgMultTotal *= 2;
                        break;

                    case "Dragon":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Ice(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Fire":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Water":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Grass":
                        dmgMultTotal *= 2;
                        break;

                    case "Ice":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Ground":
                        dmgMultTotal *= 2;
                        break;

                    case "Flying":
                        dmgMultTotal *= 2;
                        break;

                    case "Dragon":
                        dmgMultTotal *= 2;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Fighting(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Normal":
                        dmgMultTotal *= 2;
                        break;

                    case "Ice":
                        dmgMultTotal *= 2;
                        break;

                    case "Poison":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Flying":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Psychic":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Bug":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Rock":
                        dmgMultTotal *= 2;
                        break;

                    case "Ghost":
                        dmgMultTotal = 0;
                        break;

                    case "Dark":
                        dmgMultTotal *= 2;
                        break;

                    case "Steel":
                        dmgMultTotal *= 2;
                        break;

                    case "Fairy":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Poison(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Grass":
                        dmgMultTotal *= 2;
                        break;

                    case "Poison":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Ground":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Rock":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Ghost":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Steel":
                        dmgMultTotal = 0;
                        break;

                    case "Fairy":
                        dmgMultTotal *= 2;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Ground(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Fire":
                        dmgMultTotal *= 2;
                        break;

                    case "Electric":
                        dmgMultTotal *= 2;
                        break;

                    case "Grass":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Poison":
                        dmgMultTotal *= 2;
                        break;

                    case "Flying":
                        dmgMultTotal = 0;
                        break;

                    case "Bug":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Rock":
                        dmgMultTotal *= 2;
                        break;

                    case "Steel":
                        dmgMultTotal *= 2;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Flying(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Electric":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Grass":
                        dmgMultTotal *= 2;
                        break;

                    case "Fighting":
                        dmgMultTotal *= 2;
                        break;

                    case "Bug":
                        dmgMultTotal *= 2;
                        break;

                    case "Rock":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Psychic(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Fighting":
                        dmgMultTotal *= 2;
                        break;

                    case "Poison":
                        dmgMultTotal *= 2;
                        break;

                    case "Psychic":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Dark":
                        dmgMultTotal = 0;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Bug(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Fire":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Grass":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Fighting":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Poison":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Flying":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Psychic":
                        dmgMultTotal *= 2;
                        break;

                    case "Ghost":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Dark":
                        dmgMultTotal *= 2;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Fairy":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Rock(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Fire":
                        dmgMultTotal *= 2;
                        break;

                    case "Ice":
                        dmgMultTotal *= 2;
                        break;

                    case "Fighting":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Ground":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Flying":
                        dmgMultTotal *= 2;
                        break;

                    case "Bug":
                        dmgMultTotal *= 2;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Ghost(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Normal":
                        dmgMultTotal = 0;
                        break;

                    case "Psychic":
                        dmgMultTotal *= 2;
                        break;

                    case "Ghost":
                        dmgMultTotal *= 2;
                        break;

                    case "Dark":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Dragon(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Dragon":
                        dmgMultTotal *= 2;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Fairy":
                        dmgMultTotal = 0;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Dark(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Fighting":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Psychic":
                        dmgMultTotal *= 2;
                        break;

                    case "Ghost":
                        dmgMultTotal *= 2;
                        break;

                    case "Dark":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Fairy":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Steel(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Fire":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Water":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Electric":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Ice":
                        dmgMultTotal *= 2;
                        break;

                    case "Rock":
                        dmgMultTotal *= 2;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Fairy":
                        dmgMultTotal *= 2;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }

        public double Fairy(Pokemon poke)
        {
            string[] type = { poke.Type, poke.Type2 };
            double dmgMultTotal = 1;
            foreach (var item in type)
            {
                switch (item)
                {
                    case "Fire":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Fighting":
                        dmgMultTotal *= 2;
                        break;

                    case "Poison":
                        dmgMultTotal *= 0.5;
                        break;

                    case "Dragon":
                        dmgMultTotal *= 2;
                        break;

                    case "Dark":
                        dmgMultTotal *= 2;
                        break;

                    case "Steel":
                        dmgMultTotal *= 0.5;
                        break;

                    default:
                        dmgMultTotal *= 1;
                        break;
                }
            }
            return dmgMultTotal;
        }
    }
}