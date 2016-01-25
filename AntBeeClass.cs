using AntMe.English;
using AntMe.SharedComponents.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntMe.Player.AntBee
{
    [Player(
        ColonyName = "AntBee",
        FirstName = "",
        LastName = ""
    )]
    [Caste(
        Name = "default",
        AttackModifier = -1,
        EnergyModifier = 0,
        LoadModifier = 0,
        RangeModifier = 1,
        RotationSpeedModifier = -1,
        SpeedModifier = 0,
        ViewRangeModifier = 1
    )]
    [Caste(
        Name = "fighter",
        AttackModifier = 2,
        EnergyModifier = 0,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = 0,
        SpeedModifier = 0,
        ViewRangeModifier = 0
        )]
    [Caste(
        Name = "searcher",
        AttackModifier = -1,
        EnergyModifier = 0,
        LoadModifier = -1,
        RangeModifier = 0,
        RotationSpeedModifier = 0,
        SpeedModifier = 0,
        ViewRangeModifier = 2
        )]
    [Caste(
        Name = "stand",
        AttackModifier = 2,
        EnergyModifier = -1,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = 2,
        SpeedModifier = -1,
        ViewRangeModifier = 0
        )]
    [Caste(
        Name = "sugar",
        AttackModifier = -1,
        EnergyModifier = 0,
        LoadModifier = 1,
        RangeModifier = 0,
        RotationSpeedModifier = 0,
        SpeedModifier = 1,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "fighter2",
        AttackModifier = 2,
        EnergyModifier = 0,
        LoadModifier = -1,
        RangeModifier = 0,
        RotationSpeedModifier = -1,
        SpeedModifier = 0,
        ViewRangeModifier = 0
        )]


    public class AntBeeClass : BaseAnt
    {
        public static bool[] erlaubt = null;
        public static Bug[] buggy = new Bug[101];
        public static int zahler = 0;
        public static long timer = 0;
        public static Bug[] aimedbug = new Bug[300];
        public static Sugar[] zucker = new Sugar[4];
        public static bool spawned = false;
        public static Ant standed;
        public static Anthill hill = null;
        public static double[,] aimedposition = new double[300, 2];
        public static double[,] aimedsugar = new double[4, 2] { { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 } };
        public static Fruit[] apple = new Fruit[5];
        public static double[,] aimedapple = new double[5, 2] { { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 } };
        public static List<AntBeeClass> Ameisenliste = new List<AntBeeClass>();
        public static int[] wirdangegriffen = new int[3000]; //Position: Welche Ameise; Wert: Welche Wanze
        public static int[,] verfugbar = new int[300, 300];
        public static decimal time = 0;
        public static decimal[] lastact = new decimal[1000];
        public static int[,] enemyant = new int[10000, 3]; //Ist es, wer greift an, wie viele greifen an

        #region Caste

        /// <summary>
        /// Every time that a new ant is born, its job group must be set. You can 
        /// do so with the help of the value returned by this method.
        /// Read more: "http://wiki.antme.net/en/API1:ChooseCaste"
        /// </summary>
        /// <param name="typeCount">Number of ants for every caste</param>
        /// <returns>Caste-Name for the next ant</returns>
        public override string ChooseCaste(Dictionary<string, int> typeCount)
        {
            if (hill == null)
            {
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
            Ameisenliste.Add(this);
            int r = RandomNumber.Number(0, 20);
            if (spawned)
            {
                if (r < 0)
                    return "stand";
                else if (r < 0)
                    return "default";
                else if (r < 0)
                    return "sugar";
                else if (r < 5)
                    return "fighter2";
                else
                    return "fighter";
            }
            else
            {
                spawned = true;
                return "stand";
            }
        }

        #endregion

        #region Movement

        /// <summary>
        /// If the ant has no assigned tasks, it waits for new tasks. This method 
        /// is called to inform you that it is waiting.
        /// Read more: "http://wiki.antme.net/en/API1:Waiting"
        /// </summary>
        public override void Waiting()
        {
            if (hill == null)
            {
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
            if (CurrentLoad > 5 && Destination != hill)
                GoToDestination(hill);
            else
            {
                TurnByDegrees(RandomNumber.Number(20));
                GoForward();
            }
            if (wirdangegriffen[Ameisenliste.IndexOf(this)] != 0)
            {
                for (int i = 0; i < 300; i++)
                {
                    if (/*aimedbug[i].Id == wirdangegriffen[Ameisenliste.IndexOf(this)] && */verfugbar[i, 0] == wirdangegriffen[Ameisenliste.IndexOf(this)])
                    {
                        Think(i + "Vergessen weil unbeschäftigt");
                        aimedbug[i] = null;
                        for (int u = 2; u < 300; u++)
                        {
                            verfugbar[i, u] = 0;
                        }
                        verfugbar[i, 1] = 0;
                        verfugbar[i, 0] = 0;
                        aimedposition[i, 0] = 0;
                        aimedposition[i, 1] = 0;
                    }
                }
                wirdangegriffen[Ameisenliste.IndexOf(this)] = 0;
            }
            if (Caste == "fighter" || Caste == "fighter2" && ForeignAntsInViewrange == 0)
            {
                /*for (int i = 0; i < 300; i++)
                {
                    if (aimedposition[i, 0] < 5 && aimedposition[i, 0] > -5 && aimedposition[i, 1] < 5 && aimedposition[i, 1] > -5 && aimedbug[i] != null && time - lastact[i] < 1000 && aimedposition[i, 0] != 0 && aimedposition[i, 1] != 0 && Destination == null)
                    {
                        Think("Homerun");
                        GoToDestination(hill);
                        return;
                    }
                }*/
                TurnByDegrees(RandomNumber.Number(180));
                GoForward();
                double x, y;
                double direction, distance;
                int highestamount = 0;
                int angreifen = 0;
                getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                for (int i = 0; i < 300; i++)
                {
                    getdistance(x, y, aimedposition[i, 0], aimedposition[i, 1], out distance);
                    if ((verfugbar[i, 1] >= 10 || FriendlyAntsFromSameCasteInViewrange > 15) && aimedbug[i] != null && distance < 500 && time - lastact[i] < 5000 && distance > 5)
                    {
                                Think("Angriff weil beschlossen " + i);
                                getdirection(x, y, aimedposition[i, 0], aimedposition[i, 1], out direction);
                                TurnToDirection(Convert.ToInt32(direction));
                                GoForward(Convert.ToInt32(distance / 5));
                                return;
                    }
                }
                for (int i = 0; i < 300; i++)
                {
                    for (int u = 2; u < 300; u++)
                    {
                        if (verfugbar[i, u] == Ameisenliste.IndexOf(this)) return;
                    }
                }
                for (int i = 0; i < 300; i++)
                {
                    if (verfugbar[i, 1] > highestamount && aimedbug[i] != null && verfugbar[i, 1] < 21)
                    {
                        highestamount = verfugbar[i, 1];
                        angreifen = i;
                    }
                }
                for (int i = 2; i < 300; i++)
                {
                    if (verfugbar[angreifen, i] == 0)
                    {
                        verfugbar[angreifen, i] = Ameisenliste.IndexOf(this);
                        verfugbar[angreifen, 1]++;
                        getdistance(x, y, aimedposition[i, 0], aimedposition[i, 1], out distance);
                        if (verfugbar[angreifen, 1] >= 10 && aimedbug[i] != null && distance < 500 && time - lastact[i] < 5000 && distance > 5)
                        {
                            getdirection(x, y, aimedposition[i, 0], aimedposition[i, 1], out direction);
                            TurnToDirection(Convert.ToInt32(direction));
                            GoForward(Convert.ToInt32(distance / 5));
                        }
                        return;
                    }
                }
            }
            if (Caste == "sugar")
            {
                double x, y;
                double direction, distance;
                int nearest = 0;
                double lowestdistance = 3000000000000000;
                getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                for (int i = 0; i < 4; i++)
                {
                    if (zucker[i] != null)
                    {
                        getdistance(x, y, aimedsugar[i, 0], aimedsugar[i, 1], out distance);
                        if (distance < lowestdistance)
                        {
                            lowestdistance = distance;
                            nearest = i;
                        }
                    }
                }
                if (lowestdistance < this.Range / 3 && zucker[nearest] != null)
                {
                    //Think(nearest.ToString());
                    getdirection(x, y, aimedsugar[nearest, 0], aimedsugar[nearest, 1], out direction);
                    TurnToDirection(Convert.ToInt32(direction));
                    GoForward();
                }
                else
                {
                    TurnByDegrees(RandomNumber.Number(20));
                    GoForward();
                }
            }
            else if (Caste == "default")
            {
                double x, y;
                double direction, distance;
                int nearest = 0;
                double lowestdistance = 3000000000000000;
                getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                for (int i = 0; i < 5; i++)
                {
                    if (apple[i] != null)
                    {
                        getdistance(x, y, aimedapple[i, 0], aimedapple[i, 1], out distance);
                        if (distance < lowestdistance)
                        {
                            lowestdistance = distance;
                            nearest = i;
                        }
                    }
                }
                if (lowestdistance < this.Range / 3 && apple[nearest] != null)
                {
                    //Think("go" + nearest.ToString());
                    getdirection(x, y, aimedapple[nearest, 0], aimedapple[nearest, 1], out direction);
                    TurnToDirection(Convert.ToInt32(direction));
                    GoForward();
                }
                else
                {
                    TurnByDegrees(RandomNumber.Number(180));
                    GoForward();
                }
            }
            else if (Caste == "stand")
            {
                GoToDestination(hill);
            }
            else
            {
                TurnByDegrees(RandomNumber.Number(180));
                GoForward();
            }
        }

        /// <summary>
        /// This method is called when an ant has travelled one third of its 
        /// movement range.
        /// Read more: "http://wiki.antme.net/en/API1:GettingTired"
        /// </summary>
        public override void GettingTired()
        {
            if(Caste != "fighter" || Destination == null)
            GoToDestination(hill);
        }

        /// <summary>
        /// This method is called if an ant dies. It informs you that the ant has 
        /// died. The ant cannot undertake any more actions from that point forward.
        /// Read more: "http://wiki.antme.net/en/API1:HasDied"
        /// </summary>
        /// <param name="kindOfDeath">Kind of Death</param>
        public override void HasDied(KindOfDeath kindOfDeath)
        {
            if(Caste == "fighter")
            {
                for (int i = 0; i < 300; i++)
                {
                    for (int u = 2; u < 300; u++)
                    {
                        if(verfugbar[i, u] == Ameisenliste.IndexOf(this))
                        {
                            verfugbar[i, u] = 0;
                            verfugbar[i, 1]--;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method is called in every simulation round, regardless of additional 
        /// conditions. It is ideal for actions that must be executed but that are not 
        /// addressed by other methods.
        /// Read more: "http://wiki.antme.net/en/API1:Tick"
        /// </summary>
        public override void Tick()
        {
            if (hill == null)
            {
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
            if (CurrentLoad > 5 && Destination != hill)
                GoToDestination(hill);
            if (CarryingFruit != null && Destination != hill)
                GoToDestination(hill);
            time++;
            if (hill != null)
            {
                for (int i = 0; i < 300; i++)
                {
                    double distance, x, y;
                    getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                    getdistance(x, y, aimedposition[i, 0], aimedposition[i, 1], out distance);
                    if ((time - lastact[i] > 5000/* || distance < 10 && BugsInViewrange == 0*/) && aimedbug[i] != null)
                    {
                        Think(i + "vergessen " + Convert.ToInt32(distance));
                        Stop();
                        aimedbug[i] = null;
                        for (int u = 2; u < 300; u++)
                        {
                            verfugbar[i, u] = 0;
                        }
                        verfugbar[i, 1] = 0;
                        verfugbar[i, 0] = 0;
                        aimedposition[i, 0] = 0;
                        aimedposition[i, 1] = 0;
                        wirdangegriffen[Ameisenliste.IndexOf(this)] = 0;
                    }
                }
            }
            if (hill == null)
            {
                GoToDestination(hill);
                hill = Destination as Anthill;
                Stop();
            }
            timer++;
            if (CarryingFruit != null && timer > 10)
            {
            
                timer = 0;
            }
            if (Caste == "fighter" && Destination == null)
            {
            }
            for (int i = 0; i < 4; i++)
            {
                if (zucker[i] != null)
                    if (zucker[i].Amount == 0)
                    {
                        zucker[i] = null;
                        aimedsugar[i, 0] = 3000000;
                        aimedsugar[i, 1] = 3000000;
                    }
            }
            if (CarryingFruit != null)
            {
                double x, y, xa, ya;
                getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                getapplecords(CarryingFruit, out xa, out ya);
                for (int i = 0; i < 5; i++)
                {
                    if (apple[i] != null)
                        if (apple[i].Id == CarryingFruit.Id)
                        {
                            if (xa < 5 && xa > -5 && ya < 5 && ya > -5)
                            {
                                /*Think(i.ToString() + "weg");
                                apple[i] = null;
                                aimedapple[i, 0] = 3000000;
                                aimedapple[i, 1] = 3000000;*/
                            }
                            else
                            {
                                //Think(i.ToString() + "akt");
                                aimedapple[i, 0] = x;
                                aimedapple[i, 1] = y;
                            }
                        }
                }
            }
            else
            {
                double x, y;
                getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                for (int i = 0; i < 5; i++)
                {
                    if (aimedapple[i, 0] > x - 1 && aimedapple[i, 0] < x + 1 && aimedapple[i, 1] > y - 1 && aimedapple[i, 1] < y + 1)
                    {
                        //Think(i.ToString() + "weg");
                        apple[i] = null;
                        aimedapple[i, 0] = 3000000;
                        aimedapple[i, 1] = 3000000;
                    }
                }
            }
        }

        #endregion

        #region Food

        /// <summary>
        /// This method is called as soon as an ant sees an apple within its 360° 
        /// visual range. The parameter is the piece of fruit that the ant has spotted.
        /// Read more: "http://wiki.antme.net/en/API1:Spots(Fruit)"
        /// </summary>
        /// <param name="fruit">spotted fruit</param>
        public override void Spots(Fruit fruit)
        {
            if (!IsTired && Destination == null && CarryingFruit == null && Caste == "default")
            {
                GoToDestination(fruit);
            }
            double x, y;
            getapplecords(fruit, out x, out y);
            for (int i = 0; i < 5; i++)
            {
                if (apple[i] != null)
                    if (fruit.Id == apple[i].Id)
                    {
                        //Think(i.ToString() + "akt");
                        aimedapple[i, 0] = x;
                        aimedapple[i, 1] = y;
                        return;
                    }
            }
            for (int i = 0; i < 5; i++)
            {
                if (apple[i] == null)
                {
                    //Think("ist" + i.ToString());
                    aimedapple[i, 0] = x;
                    aimedapple[i, 1] = y;
                    apple[i] = fruit;
                    apple[i] = fruit;
                    return;
                }
            }
        }

        /// <summary>
        /// This method is called as soon as an ant sees a mound of sugar in its 360° 
        /// visual range. The parameter is the mound of sugar that the ant has spotted.
        /// Read more: "http://wiki.antme.net/en/API1:Spots(Sugar)"
        /// </summary>
        /// <param name="sugar">spotted sugar</param>
        public override void Spots(Sugar sugar)
        {
            double x, y;
            getcordss(sugar, out x, out y);
            for (int i = 0; i < 4; i++)
            {
                if (x > aimedsugar[i, 0] - 1 && x < aimedsugar[i, 0] + 1 && y > aimedsugar[i, 1] - 1 && y < aimedsugar[i, 1] + 1)
                    break;
                else if (zucker[i] == null)
                {
                    aimedsugar[i, 0] = x;
                    aimedsugar[i, 1] = y;
                    zucker[i] = sugar;
                    break;
                }
            }
            if (!IsTired && Destination == null && CarryingFruit == null && Destination == null && Caste == "sugar")
            {
                GoToDestination(sugar);
            }
        }

        /// <summary>
        /// If the ant’s destination is a piece of fruit, this method is called as soon 
        /// as the ant reaches its destination. It means that the ant is now near enough 
        /// to its destination/target to interact with it.
        /// Read more: "http://wiki.antme.net/en/API1:DestinationReached(Fruit)"
        /// </summary>
        /// <param name="fruit">reached fruit</param>
        public override void DestinationReached(Fruit fruit)
        {
            Take(fruit);
            GoToDestination(hill);
            double x, y;
            getapplecords(fruit, out x, out y);
            for (int i = 0; i < 5; i++)
            {
                if (apple[i] != null)
                    if (fruit.Id == apple[i].Id)
                    {
                        //Think(i.ToString() + "akt");
                        aimedapple[i, 0] = x;
                        aimedapple[i, 1] = y;
                        return;
                    }
            }
            for (int i = 0; i < 5; i++)
            {
                if (apple[i] == null)
                {
                    //Think("ist" + i.ToString());
                    aimedapple[i, 0] = x;
                    aimedapple[i, 1] = y;
                    apple[i] = fruit;
                    return;
                }
            }
        }

        /// <summary>
        /// If the ant’s destination is a mound of sugar, this method is called as soon 
        /// as the ant has reached its destination. It means that the ant is now near 
        /// enough to its destination/target to interact with it.
        /// Read more: "http://wiki.antme.net/en/API1:DestinationReached(Sugar)"
        /// </summary>
        /// <param name="sugar">reached sugar</param>
        public override void DestinationReached(Sugar sugar)
        {
            if (Caste != "searcher" || FriendlyAntsFromSameCasteInViewrange > 1)
            {
                Take(sugar);
                GoToDestination(hill);
                //MakeMark(0, 300);
            }
            else if (Caste == "searcher" && FriendlyAntsFromSameCasteInViewrange <= 1)
            {
                //MakeMark(0, 700);
            }
        }

        #endregion

        #region Communication

        /// <summary>
        /// Friendly ants can detect markers left by other ants. This method is called 
        /// when an ant smells a friendly marker for the first time.
        /// Read more: "http://wiki.antme.net/en/API1:DetectedScentFriend(Marker)"
        /// </summary>
        /// <param name="marker">marker</param>
        public override void DetectedScentFriend(Marker marker)
        {
            /*if (Destination == null && Caste == "sugar" && marker.Information == 0)
                GoToDestination(marker);
            else if (Destination == null && (Caste == "fighter" || Caste == "fighter2" && ForeignAntsInViewrange == 0) && marker.Information == 1 && FriendlyAntsFromSameCasteInViewrange > 15)
                GoToDestination(marker);
            else if (Destination == null && Caste == "fighter2" && marker.Information == 2 && FriendlyAntsFromSameCasteInViewrange > 5)
                GoToDestination(marker);*/
        }

        /// <summary>
        /// Just as ants can see various types of food, they can also visually detect 
        /// other game elements. This method is called if the ant sees an ant from the 
        /// same colony.
        /// Read more: "http://wiki.antme.net/en/API1:SpotsFriend(Ant)"
        /// </summary>
        /// <param name="ant">spotted ant</param>
        public override void SpotsFriend(Ant ant)
        {

        }

        /// <summary>
        /// Just as ants can see various types of food, they can also visually detect 
        /// other game elements. This method is called if the ant detects an ant from a 
        /// friendly colony (an ant on the same team).
        /// Read more: "http://wiki.antme.net/en/API1:SpotsTeammate(Ant)"
        /// </summary>
        /// <param name="ant">spotted ant</param>
        public override void SpotsTeammate(Ant ant)
        {
        }

        #endregion

        #region Fight

        /// <summary>
        /// Just as ants can see various types of food, they can also visually detect 
        /// other game elements. This method is called if the ant detects an ant from an 
        /// enemy colony.
        /// Read more: "http://wiki.antme.net/en/API1:SpotsEnemy(Ant)"
        /// </summary>
        /// <param name="ant">spotted ant</param>
        public override void SpotsEnemy(Ant ant)
        {
            if (((Caste == "fighter2") && !IsTired || Caste == "stand" && DistanceToAnthill < 300) && (enemyant[ant.Id, 1] == Ameisenliste.IndexOf(this) || enemyant[ant.Id, 2] < 1))
            {
                if (enemyant[ant.Id, 0] != 1)
                    enemyant[ant.Id, 0] = 1;
                enemyant[ant.Id, 1] = Ameisenliste.IndexOf(this);
                enemyant[ant.Id, 2]++;
                Think("j");
                Attack(ant);
            }
            else if (Coordinate.GetDistanceBetween(this, ant) < 10 && CarryingFruit == null && CurrentEnergy > MaximumEnergy / 3) GoAwayFrom(ant, 10);
        }

        /// <summary>
        /// Just as ants can see various types of food, they can also visually detect 
        /// other game elements. This method is called if the ant sees a bug.
        /// Read more: "http://wiki.antme.net/en/API1:SpotsEnemy(Bug)"
        /// </summary>
        /// <param name="bug">spotted bug</param>
        public override void SpotsEnemy(Bug bug)
        {
            if (Caste == "default")
            {
                double directiona = Coordinate.GetDegreesBetween(this, hill);
                double directionb = Coordinate.GetDegreesBetween(bug, hill);
                if (CarryingFruit == null)
                    GoAwayFrom(bug, 50);
            }
            else if (Caste == "searcher")
            {
                double directiona = Coordinate.GetDegreesBetween(this, hill);
                double directionb = Coordinate.GetDegreesBetween(bug, hill);
                if(CarryingFruit == null)
                GoAwayFrom(bug, 50);
            }
            if(Caste == "fighter" && (Coordinate.GetDistanceBetween(this, bug) < 5 || bug.CurrentEnergy < ((FriendlyAntsFromSameCasteInViewrange) * 30)))
            {
                Attack(bug);
            }
            if (Caste == "fighter" && FriendlyAntsFromSameCasteInViewrange < 8)
            {
                for (int i = 0; i < 300; i++)
                {
                    if (aimedbug[i] != null)
                    {
                        if (aimedbug[i] == bug)
                        {
                            lastact[i] = time;
                            Think(i + "act");
                            double x, y;
                            getcordsb(bug, out x, out y);
                            aimedposition[i, 0] = x;
                            aimedposition[i, 1] = y;
                            for (int u = 2; u < 300; u++)
                            {
                                if (verfugbar[i, u] == Ameisenliste.IndexOf(this)) return;
                            }
                            return;
                        }

                    }
                }

                for (int i = 0; i < 300; i++)
                {
                    double distance, xa, ya;
                    getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out xa, out ya);
                    getdistance(xa, ya, aimedposition[i, 0], aimedposition[i, 1], out distance);
                    if (aimedbug[i] == null && verfugbar[i, 0] == 0)
                    {
                        lastact[i] = time;
                        Think(i + "act");
                        double x, y;
                        getcordsb(bug, out x, out y);
                        aimedposition[i, 0] = x;
                        aimedposition[i, 1] = y;
                        aimedbug[i] = bug;
                        verfugbar[i, 0] = bug.Id;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == Ameisenliste.IndexOf(this)) return;
                        }
                        verfugbar[i, 1]++;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == 0 && verfugbar[i, 1] < 21)
                            {
                                verfugbar[i, u] = Ameisenliste.IndexOf(this);
                                return;
                            }
                        }
                        return;
                    }
                }
                for (int i = 0; i < 300; i++)
                {
                    if (aimedbug[i] == null && verfugbar[i, 0] == 0)
                    {
                        lastact[i] = time;
                        Think(i + "gefunden 1");
                        double x, y;
                        getcordsb(bug, out x, out y);
                        aimedposition[i, 0] = x;
                        aimedposition[i, 1] = y;
                        aimedbug[i] = bug;
                        verfugbar[i, 0] = bug.Id;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == Ameisenliste.IndexOf(this)) return;
                        }
                        return;
                    }
                }
            }
            if (Caste == "fighter" && !IsTired && FriendlyAntsFromSameCasteInViewrange > 7)
            {
                Think(bug.Id + "Angriff weil gesehen");
                lastact[bug.Id] = time;
            
                Think("j");
                Attack(bug);
                wirdangegriffen[Ameisenliste.IndexOf(this)] = bug.Id;
                for (int i = 0; i < 300; i++)
                {
                    if (aimedbug[i] == bug)
                    {
                        lastact[i] = time;
                        Think(i + "act");
                        double x, y;
                        getcordsb(bug, out x, out y);
                        aimedposition[i, 0] = x;
                        aimedposition[i, 1] = y;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == Ameisenliste.IndexOf(this)) return;
                        }
                        return;
                    }
                }
                for (int i = 0; i < 300; i++)
                {
                    if (aimedbug[i] == null && verfugbar[i, 0] == 0)
                    {
                        lastact[i] = time;
                        Think(i + "gefunden 2");
                        double x, y;
                        getcordsb(bug, out x, out y);
                        aimedposition[i, 0] = x;
                        aimedposition[i, 1] = y;
                        aimedbug[i] = bug;
                        verfugbar[i, 0] = bug.Id;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == Ameisenliste.IndexOf(this)) return;
                        }
                        return;
                    }
                }
                for (int i = 0; i < 300; i++)
                {
                    double distance, xa, ya;
                    getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out xa, out ya);
                    getdistance(xa, ya, aimedposition[i, 0], aimedposition[i, 1], out distance);
                    if (aimedbug[i] == null && verfugbar[i, 0] == 0)
                    {
                        lastact[i] = time;
                        Think(i + "act");
                        double x, y;
                        getcordsb(bug, out x, out y);
                        aimedposition[i, 0] = x;
                        aimedposition[i, 1] = y;
                        aimedbug[i] = bug;
                        verfugbar[i, 0] = bug.Id;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == Ameisenliste.IndexOf(this)) return;
                        }
                        verfugbar[i, 1]++;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == 0 && verfugbar[i, 1] < 21)
                            {
                                verfugbar[i, u] = Ameisenliste.IndexOf(this);
                                return;
                            }
                        }
                        return;
                    }
                }
            }
            else if (Caste == "stand" && DistanceToAnthill < 300)
            {
            
                Think("j");
                Attack(bug);
            }
            else
            {
                double directiona = Coordinate.GetDegreesBetween(this, hill);
                double directionb = Coordinate.GetDegreesBetween(bug, hill);
                if (CarryingFruit == null)
                    GoAwayFrom(bug, 50);
            }
            //(1, 400);
            for (int i = 0; i < 300; i++)
            {
                if (aimedbug[i] != null)
                {
                    if (aimedbug[i] == bug)
                    {
                        lastact[i] = time;
                        Think(i + "act diff");
                        double x, y;
                        getcordsb(bug, out x, out y);
                        aimedposition[i, 0] = x;
                        aimedposition[i, 1] = y;
                        return;
                    }
                }
            }
            for (int i = 0; i < 300; i++)
            {
                if (aimedbug[i] == null && verfugbar[i, 0] == 0)
                {
                    lastact[i] = time;
                    Think(i + "gefunden diff");
                    double x, y;
                    getcordsb(bug, out x, out y);
                    aimedposition[i, 0] = x;
                    aimedposition[i, 1] = y;
                    aimedbug[i] = bug;
                    verfugbar[i, 0] = bug.Id;
                    return;
                }
            }
        }

        /// <summary>
        /// Enemy creatures may actively attack the ant. This method is called if an 
        /// enemy ant attacks; the ant can then decide how to react.
        /// Read more: "http://wiki.antme.net/en/API1:UnderAttack(Ant)"
        /// </summary>
        /// <param name="ant">attacking ant</param>
        public override void UnderAttack(Ant ant)
        {
            if (Caste == "fighter" || Caste == "fighter2" || Caste == "stand" )
            {
                Think("j");
                Attack(ant);
            }
        }

        /// <summary>
        /// Enemy creatures may actively attack the ant. This method is called if a 
        /// bug attacks; the ant can decide how to react.
        /// Read more: "http://wiki.antme.net/en/API1:UnderAttack(Bug)"
        /// </summary>
        /// <param name="bug">attacking bug</param>
        public override void UnderAttack(Bug bug)
        {            
            if (Caste == "fighter")
            {
                Think(bug.Id + "Angriff weil angegriffen");
            
                Think("j");
                Attack(bug);
                wirdangegriffen[Ameisenliste.IndexOf(this)] = bug.Id;
                for (int i = 0; i < 300; i++)
                {
                    if (aimedbug[i] == bug)
                    {
                        lastact[i] = time;
                        Think(i + "act");
                        double x, y;
                        getcordsb(bug, out x, out y);
                        aimedposition[i, 0] = x;
                        aimedposition[i, 1] = y;
                        verfugbar[i, 1]++;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == Ameisenliste.IndexOf(this)) return;
                        }
                        return;
                    }
                }
                for (int i = 0; i < 300; i++)
                {
                    double distance, xa, ya;
                    getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out xa, out ya);
                    getdistance(xa, ya, aimedposition[i, 0], aimedposition[i, 1], out distance);
                    if (aimedbug[i] == null && verfugbar[i, 0] == 0)
                    {
                        lastact[i] = time;
                        Think(i + "act");
                        double x, y;
                        getcordsb(bug, out x, out y);
                        aimedposition[i, 0] = x;
                        aimedposition[i, 1] = y;
                        aimedbug[i] = bug;
                        verfugbar[i, 0] = bug.Id;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == Ameisenliste.IndexOf(this)) return;
                        }
                        verfugbar[i, 1]++;
                        for (int u = 2; u < 300; u++)
                        {
                            if (verfugbar[i, u] == 0 && verfugbar[i, 1] < 21)
                            {
                                verfugbar[i, u] = Ameisenliste.IndexOf(this);
                                return;
                            }
                        }
                        return;
                    }
                }
            }
            else
            {
                double directiona = Coordinate.GetDegreesBetween(this, hill);
                double directionb = Coordinate.GetDegreesBetween(bug, hill);
                if (CarryingFruit == null)
                    GoAwayFrom(bug, 50);
            }
            for (int i = 0; i < 300; i++)
            {
                if (aimedbug[i] != null)
                {
                    if (aimedbug[i] == bug)
                    {
                        lastact[i] = time;
                        Think(i + "act diff");
                        double x, y;
                        getcordsb(bug, out x, out y);
                        aimedposition[i, 0] = x;
                        aimedposition[i, 1] = y;
                        return;
                    }
                }
            }
            for (int i = 0; i < 300; i++)
            {
                if (aimedbug[i] == null && verfugbar[i, 0] == 0)
                {
                    lastact[i] = time;
                    Think(i + "gefunden diff");
                    double x, y;
                    getcordsb(bug, out x, out y);
                    aimedposition[i, 0] = x;
                    aimedposition[i, 1] = y;
                    aimedbug[i] = bug;
                    verfugbar[i, 0] = bug.Id;
                    return;
                }
            }
            //MakeMark(1, 400);
        }

        public static void getcordsb(Bug bugp, out double x, out double y)
        {
            double distance = Coordinate.GetDistanceBetween(bugp, hill);
            double anglet = Coordinate.GetDegreesBetween(bugp, hill);
            double anglec = anglet * (Math.PI / 180);
            double angleb = anglec;
            if (anglet > 90 && anglet < 180)
            {
                angleb = anglec - 90 * (Math.PI / 180);
                x = Math.Sin(angleb) * distance;
                y = Math.Cos(angleb) * distance;
            }
            else if (anglet > 0 && anglet < 90)
            {
                angleb = anglec;
                x = (-1) * Math.Cos(angleb) * distance;
                y = Math.Sin(angleb) * distance;
            }
            else if (anglet > 270 && anglet < 360)
            {
                angleb = anglec - 270 * (Math.PI / 180);
                x = (-1) * Math.Sin(angleb) * distance;
                y = (-1) * Math.Cos(angleb) * distance;
            }
            else if (anglet > 180 && anglet < 270)
            {
                angleb = anglec - 180 * (Math.PI / 180);
                x = Math.Cos(angleb);
                y = (-1) * Math.Sin(angleb);
            }
            else if (anglet == 90)
            {
                x = 0;
                y = distance;
            }
            else if (anglet == 270)
            {
                x = 0;
                y = (-1) * distance;
            }
            else if (anglet == 180)
            {
                x = distance;
                y = 0;
            }
            else if (anglet == 0 || anglet == 360)
            {
                x = (-1) * distance;
                y = 0;
            }
            else
            {
                x = 0;
                y = 0;
            }
        }
        public static void getcordss(Sugar sugarp, out double x, out double y)
        {
            double distance = Coordinate.GetDistanceBetween(sugarp, hill);
            double anglet = Coordinate.GetDegreesBetween(sugarp, hill);
            double anglec = anglet * (Math.PI / 180);
            double angleb = anglec;
            if (anglet > 90 && anglet < 180)
            {
                angleb = anglec - 90 * (Math.PI / 180);
                x = Math.Sin(angleb) * distance;
                y = Math.Cos(angleb) * distance;
            }
            else if (anglet > 0 && anglet < 90)
            {
                angleb = anglec;
                x = (-1) * Math.Cos(angleb) * distance;
                y = Math.Sin(angleb) * distance;
            }
            else if (anglet > 270 && anglet < 360)
            {
                angleb = anglec - 270 * (Math.PI / 180);
                x = (-1) * Math.Sin(angleb) * distance;
                y = (-1) * Math.Cos(angleb) * distance;
            }
            else if (anglet > 180 && anglet < 270)
            {
                angleb = anglec - 180 * (Math.PI / 180);
                x = Math.Cos(angleb);
                y = (-1) * Math.Sin(angleb);
            }
            else if (anglet == 90)
            {
                x = 0;
                y = distance;
            }
            else if (anglet == 270)
            {
                x = 0;
                y = (-1) * distance;
            }
            else if (anglet == 180)
            {
                x = distance;
                y = 0;
            }
            else if (anglet == 0 || anglet == 360)
            {
                x = (-1) * distance;
                y = 0;
            }
            else
            {
                x = 0;
                y = 0;
            }
        }

        public static void getapplecords(Fruit applep, out double x, out double y)
        {
            double distance = Coordinate.GetDistanceBetween(applep, hill);
            double anglet = Coordinate.GetDegreesBetween(applep, hill);
            double anglec = anglet * (Math.PI / 180);
            double angleb = anglec;
            if (anglet > 90 && anglet < 180)
            {
                angleb = anglec - 90 * (Math.PI / 180);
                x = Math.Sin(angleb) * distance;
                y = Math.Cos(angleb) * distance;
            }
            else if (anglet > 0 && anglet < 90)
            {
                angleb = anglec;
                x = (-1) * Math.Cos(angleb) * distance;
                y = Math.Sin(angleb) * distance;
            }
            else if (anglet > 270 && anglet < 360)
            {
                angleb = anglec - 270 * (Math.PI / 180);
                x = (-1) * Math.Sin(angleb) * distance;
                y = (-1) * Math.Cos(angleb) * distance;
            }
            else if (anglet > 180 && anglet < 270)
            {
                angleb = anglec - 180 * (Math.PI / 180);
                x = Math.Cos(angleb);
                y = (-1) * Math.Sin(angleb);
            }
            else if (anglet == 90)
            {
                x = 0;
                y = distance;
            }
            else if (anglet == 270)
            {
                x = 0;
                y = (-1) * distance;
            }
            else if (anglet == 180)
            {
                x = distance;
                y = 0;
            }
            else if (anglet == 0 || anglet == 360)
            {
                x = (-1) * distance;
                y = 0;
            }
            else
            {
                x = 0;
                y = 0;
            }
        }

        public static void getcordsa(double distance, double anglet, out double x, out double y)
        {
            double anglec = anglet * (Math.PI / 180);
            double angleb = anglec;
            if (anglet > 90 && anglet < 180)
            {
                angleb = anglec - 90 * (Math.PI / 180);
                x = Math.Sin(angleb) * distance;
                y = Math.Cos(angleb) * distance;
            }
            else if (anglet > 0 && anglet < 90)
            {
                angleb = anglec;
                x = (-1) * Math.Cos(angleb) * distance;
                y = Math.Sin(angleb) * distance;
            }
            else if (anglet > 270 && anglet < 360)
            {
                angleb = anglec - 270 * (Math.PI / 180);
                x = (-1) * Math.Sin(angleb) * distance;
                y = (-1) * Math.Cos(angleb) * distance;
            }
            else if (anglet > 180 && anglet < 270)
            {
                angleb = anglec - 180 * (Math.PI / 180);
                x = Math.Cos(angleb);
                y = (-1) * Math.Sin(angleb);
            }
            else if (anglet == 90)
            {
                x = 0;
                y = distance;
            }
            else if (anglet == 270)
            {
                x = 0;
                y = (-1) * distance;
            }
            else if (anglet == 180)
            {
                x = distance;
                y = 0;
            }
            else if (anglet == 0 || anglet == 360)
            {
                x = (-1) * distance;
                y = 0;
            }
            else
            {
                x = 0;
                y = 0;
            }
        }

        public static void getdirection(double x1, double y1, double x2, double y2, out double direction)
        {
            double angleb, anglea;
            anglea = 90;
            angleb = Math.Atan((y2 - y1) / (x2 - x1));
            angleb = angleb * (180 / Math.PI);
            if (y2 > y1)
            {
                if (x2 > x1)
                {
                    anglea = 360 - angleb;
                }
                else if (x2 < x1)
                {
                    anglea = 180 + angleb * (-1);
                }
                else
                    anglea = 270;
            }
            else if (y2 < y1)
            {
                if (x2 > x1)
                {
                    anglea = angleb * (-1);
                }
                else if (x2 < x1)
                {
                    anglea = 180 - angleb;
                }
                else
                    anglea = 90;
            }
            else if (y2 == y1)
            {
                if (x2 > x1)
                    anglea = 0;
                else if (x2 < x1)
                    anglea = 180;
                else if (x2 == x1)
                    anglea = 0;
            };
            direction = anglea;
        }

        public static void getdistance(double x1, double y1, double x2, double y2, out double distance)
        {
            double dx = x1 + x2;
            double dy = y1 + y2;
            distance = Math.Sqrt(dx * dx + dy * dy);
        }
        #endregion
    }
}
