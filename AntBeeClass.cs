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
        EnergyModifier = -1,
        LoadModifier = 1,
        RangeModifier = -1,
        RotationSpeedModifier = 1,
        SpeedModifier = 2,
        ViewRangeModifier = -1
    )]
    [Caste(
        Name = "fighter",
        AttackModifier = 2,
        EnergyModifier = 1,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = 1,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "fighter3",
        AttackModifier = 2,
        EnergyModifier = 1,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = 1,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "searcher",
        AttackModifier = -1,
        EnergyModifier = -1,
        LoadModifier = -1,
        RangeModifier = 2,
        RotationSpeedModifier = -1,
        SpeedModifier = 0,
        ViewRangeModifier = 2
        )]
    [Caste(
        Name = "stand",
        AttackModifier = 2,
        EnergyModifier = 2,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = -1,
        ViewRangeModifier = 0
        )]
    [Caste(
        Name = "sugar",
        AttackModifier = -1,
        EnergyModifier = -1,
        LoadModifier = 2,
        RangeModifier = -1,
        RotationSpeedModifier = 0,
        SpeedModifier = 2,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "fighter2",
        AttackModifier = 2,
        EnergyModifier = 1,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = 1,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "identifier1",
        AttackModifier = 2,
        EnergyModifier = 1,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = 1,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "south",
        AttackModifier = 2,
        EnergyModifier = 1,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = 1,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "west",
        AttackModifier = 2,
        EnergyModifier = 1,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = 1,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "north",
        AttackModifier = 2,
        EnergyModifier = 1,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = 1,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "east",
        AttackModifier = 2,
        EnergyModifier = 1,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = 1,
        ViewRangeModifier = -1
        )]


    public class AntBeeClass : BaseAnt
    {
        public static bool[] erlaubt = null;
        public static Bug[] buggy = new Bug[101];
        public static int zahler = 0;
        public static long timer = 0;
        public static Bug[] aimedbug = new Bug[300];
        public static Sugar[] zucker = new Sugar[4];
        public static int[] spawned = new int[4];
        public static Ant standed;
        public static Anthill hill = null;
        public static double[,] aimedposition = new double[300, 2];
        public static double[,] aimedsugar = new double[4, 2] { { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 } };
        public static Fruit[] apple = new Fruit[10];
        public static double[,] aimedapple = new double[10, 2] { { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 }, { 3000000, 3000000 } };
        public static List<AntBeeClass> Ameisenliste = new List<AntBeeClass>();
        public static int[] wirdangegriffen = new int[3000]; //Position: Welche Ameise; Wert: Welche Wanze
        public static int[,] verfugbar = new int[300, 300];
        public static decimal time = 0;
        public static decimal[] lastact = new decimal[1000];
        public static int[,] enemyant = new int[10000, 3]; //Ist es, wer greift an, wie viele greifen an
        public static int current1 = 10000;
        public static int current2 = 10000;
        public static int[,] Apfelliste = new int[10, 20];
        public static decimal[] lastacta = new decimal[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static int[,] unterwegs = new int[4, 100];
        public static List<Ant> enemies = new List<Ant>();
        public static double[,] targets = new double[100, 3]; //Anzahl, x, y
        public static int[] searcher = new int[1000];
        public static int[] entfernung = new int[4];
        public static bool[] absolute = new bool[4];

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
            bool alle = true;
            for (int i = 0; i < 4; i++)
            {
                if (!absolute[i])
                {
                    alle = false;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (spawned[i] < 2)
                {
                    spawned[i]++;
                    if (i == 0)
                        return "south";
                    else if (i == 1)
                        return "west";
                    else if (i == 2)
                        return "north";
                    else if (i == 3)
                        return "east";
                }
            }
            if (searcher[0] < 10)
            {
                searcher[0]++;
                for (int i = 1; i < 1000; i++)
                {
                    if (searcher[i] == 0)
                    {
                        searcher[i] = Ameisenliste.IndexOf(this);
                        break;
                    }
                }
                return "searcher";
            }
            if (r < 0)
                return "stand";
            else if (r < 5)
                return "default";
            else if (r < 22)
                return "sugar";
            else if (r < 22)
                return "fighter2";
            else if (r < 5)
                return "fighter";
            else
                return "fighter3";
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
            if (Caste == "north")
            {
                TurnToDirection(270);
                GoForward();
                return;
            }
            if (Caste == "east")
            {
                TurnToDirection(0);
                GoForward();
                return;
            }
            if (Caste == "south")
            {
                TurnToDirection(90);
                GoForward();
                return;
            }
            if (Caste == "west")
            {
                TurnToDirection(180);
                GoForward();
                return;
            }
            if (IsTired)
            {
                if (DistanceToAnthill > 30)
                {
                    TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 28);
                }
                else
                    GoToDestination(hill);
                return;
            }
            if (Caste == "searcher")
            {
                int distance = 0;
                for (int i = 1; i < 1000; i++)
                {
                    if (searcher[i] == Ameisenliste.IndexOf(this))
                    {
                        distance = (i - 1) * 40;
                        break;
                    }
                }
                if (DistanceToAnthill/* * Math.Cos(Coordinate.GetDegreesBetween(this, hill) * (180 / Math.PI))*/ < distance - 50)
                {
                    bool alle = true;
                    Think("falsch");
                    if (DistanceToAnthill > 5)
                        GoToAnthill();
                    else
                    {
                        Think("richte aus");
                        for (int i = 0; i < 4; i++)
                        {
                            if (!absolute[i])
                            {
                                TurnToDirection(45);
                                alle = false;
                            }
                        }
                        if (alle)
                        {
                            if (entfernung[0] > entfernung[2])
                            {
                                if (entfernung[1] > entfernung[3])
                                {
                                    TurnToDirection(315);
                                }
                                else
                                {
                                    TurnToDirection(225);
                                }
                            }
                            else
                            {
                                if (entfernung[1] > entfernung[3])
                                {
                                    TurnToDirection(45);
                                }
                                else
                                {
                                    TurnToDirection(135);
                                }
                            }
                        }
                        GoForward(distance);
                    }
                    return;
                }
                else
                {
                    Think("aufgestellt" + distance);
                    Stop();
                    if (Coordinate.GetDegreesBetween(this, hill) >= 210 && Coordinate.GetDegreesBetween(this, hill) <= 240)
                    {
                        TurnToDirection(270);
                        GoForward(Convert.ToInt32(DistanceToAnthill * 1.15 / 0.70710678118));
                    }
                    else if (Coordinate.GetDegreesBetween(this, hill) >= 120 && Coordinate.GetDegreesBetween(this, hill) <= 150)
                    {
                        TurnToDirection(180);
                        GoForward(Convert.ToInt32(DistanceToAnthill * 1.15 / 0.70710678118));
                    }
                    else if (Coordinate.GetDegreesBetween(this, hill) >= 30 && Coordinate.GetDegreesBetween(this, hill) <= 60)
                    {
                        TurnToDirection(90);
                        GoForward(Convert.ToInt32(DistanceToAnthill * 1.15 / 0.70710678118));
                    }
                    else if (Coordinate.GetDegreesBetween(this, hill) >= 300 && Coordinate.GetDegreesBetween(this, hill) <= 330)
                    {
                        TurnToDirection(0);
                        GoForward(Convert.ToInt32(DistanceToAnthill * 1.15 / 0.70710678118));
                    }
                    else
                    {
                        Think("falsch");
                        if (DistanceToAnthill > 5)
                            GoToAnthill();
                        else
                        {
                            Think("richte aus");
                            TurnToDirection(45);
                            GoForward(distance);
                        }
                    }
                    return;
                }

            }
            if (hill == null)
            {
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
            if (CurrentLoad > 5 && Direction != Coordinate.GetDegreesBetween(this, hill))
            {
                if (DistanceToAnthill > 30)
                {
                    TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 28);
                }
                else
                    GoToDestination(hill);
                return;
            }
            else
            {
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
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
            if (Caste == "fighter2")
            {
                double highest = 0;
                int aim = 1000;
                double x, y, direction, distance;
                for (int i = 0; i < 100; i++)
                {
                    if (targets[i, 0] > highest)
                    {
                        highest = targets[i, 0];
                        aim = i;
                    }
                    if (targets[i, 0] == 0 && targets[i, 1] == 0 && targets[i, 2] == 0) break;
                }
                if (aim < 101 && highest > 10 && !(targets[aim, 1] == 0 && targets[aim, 2] == 0))
                {
                    Think("aimed");
                    getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out x, out y);
                    getdirection(x, y, targets[aim, 1], targets[aim, 2], out direction);
                    getdistance(x, y, targets[aim, 1], targets[aim, 2], out distance);
                    if (distance < (double)500 && distance < Range / 3)
                    {
                        TurnToDirection(Convert.ToInt32(direction));
                        GoForward(Convert.ToInt32(distance));
                    }
                    if (distance < Viewrange && ForeignAntsInViewrange < 1)
                    {
                        Think("cleared");
                        targets[aim, 0] = 0;
                        targets[aim, 1] = 0;
                        targets[aim, 2] = 0;
                        return;
                    }
                    return;
                }
            }
            for (int i = 0; i < 100; i++)
            {
                double x, y, direction, distance;
                getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out x, out y);
                getdistance(x, y, targets[i, 1], targets[i, 2], out distance);
                if (distance < Viewrange && ForeignAntsInViewrange < 1 && targets[i, 0] != 0)
                {
                    Think("cleared");
                    targets[i, 0] = 0;
                    targets[i, 1] = 0;
                    targets[i, 2] = 0;
                    return;
                }
                else if (targets[i, 0] == 0) break;
            }
            /*if (Caste == "fighter" || Caste == "fighter2" && ForeignAntsInViewrange == 0)
            {
                for (int i = 0; i < 300; i++)
                {
                    if (aimedposition[i, 0] < 5 && aimedposition[i, 0] > -5 && aimedposition[i, 1] < 5 && aimedposition[i, 1] > -5 && aimedbug[i] != null && time - lastact[i] < 1000 && aimedposition[i, 0] != 0 && aimedposition[i, 1] != 0 && Destination == null)
                    {
                        Think("Homerun");
                        GoToDestination(hill);
                        return;
                    }
                }
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
                double x, y;
                double direction, distance;
                double lowestamount = 100000000000;
                int angreifen = 200;
                getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                for (int i = 0; i < 300; i++)
                {
                    if (aimedbug[i] != null)
                    {
                        distance = Coordinate.GetDistanceBetween(aimedbug[i], hill);
                        if (verfugbar[i, 1] > 10 && aimedbug[i] != null && distance < lowestamount && time - lastact[i] < 5000 && distance < 5000)
                        {
                            current1 = i;
                            lowestamount = distance;
                            angreifen = i;
                        }
                    }
                }
                getdistance(x, y, aimedposition[angreifen, 0], aimedposition[angreifen, 1], out distance);
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
                if ((verfugbar[angreifen, 1] >= 10 || FriendlyAntsFromSameCasteInViewrange > 15) && aimedbug[angreifen] != null && distance < 5000 && time - lastact[angreifen] < 10000)
                {
                    Think("Angriff weil beschlossen " + angreifen);
                    getdirection(x, y, aimedposition[angreifen, 0], aimedposition[angreifen, 1], out direction);
                    /*TurnToDirection(Convert.ToInt32(direction));
                    GoForward(Convert.ToInt32(distance / 5));
                    Stop();
                    Attack(aimedbug[angreifen]);
                    return;
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
                    if (aimedbug[i] != null)
                    {
                        distance = Coordinate.GetDistanceBetween(aimedbug[i], hill);
                        if (verfugbar[i, 1] > 10 && aimedbug[i] != null && distance < lowestamount && time - lastact[i] < 5000 && distance < 10000)
                        {
                            current1 = i;
                            lowestamount = distance;
                            angreifen = i;
                        }
                    }
                }
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
                for (int i = 2; i < 300; i++)
                {
                    if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                    GoForward(50);
                    if (verfugbar[angreifen, i] == 0)
                    {
                        verfugbar[angreifen, i] = Ameisenliste.IndexOf(this);
                        verfugbar[angreifen, 1]++;
                        getdistance(x, y, aimedposition[angreifen, 0], aimedposition[angreifen, 1], out distance);
                        if (verfugbar[angreifen, 1] >= 10 && aimedbug[angreifen] != null && distance < 500 && time - lastact[angreifen] < 10000 && distance > 5)
                        {
                            Think("Angriff weil beschlossen " + angreifen);
                            getdirection(x, y, aimedposition[angreifen, 0], aimedposition[angreifen, 1], out direction);
                            /*TurnToDirection(Convert.ToInt32(direction));
                            GoForward(Convert.ToInt32(distance / 5));
                            Stop();
                            Attack(aimedbug[angreifen]);
                        }
                        return;
                    }
                }
            }
            if (Caste == "fighter3")
            {
                /*for (int i = 0; i < 300; i++)
                {
                    if (aimedposition[i, 0] < 5 && aimedposition[i, 0] > -5 && aimedposition[i, 1] < 5 && aimedposition[i, 1] > -5 && aimedbug[i] != null && time - lastact[i] < 1000 && aimedposition[i, 0] != 0 && aimedposition[i, 1] != 0 && Destination == null)
                    {
                        Think("Homerun");
                        GoToDestination(hill);
                        return;
                    }
                }
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
                double x, y;
                double direction, distance;
                double lowestamount = 1000000000000000;
                int angreifen = 0;
                getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                for (int i = 0; i < 300; i++)
                {
                    if (aimedbug[i] != null)
                    {
                        distance = Coordinate.GetDistanceBetween(aimedbug[i], hill);
                        if (aimedbug[i] != null && distance < lowestamount && time - lastact[i] < 5000 && distance < 5000 && i != current1)
                        {
                            lowestamount = distance;
                            angreifen = i;
                        }
                    }
                }
                getdistance(x, y, aimedposition[angreifen, 0], aimedposition[angreifen, 1], out distance);
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
                if ((FriendlyAntsFromSameCasteInViewrange > 15) && aimedbug[angreifen] != null && distance < 5000 && time - lastact[angreifen] < 10000)
                {
                    Think("2er Angriff weil beschlossen " + angreifen + current1.ToString());
                    current2 = angreifen;
                    getdirection(x, y, aimedposition[angreifen, 0], aimedposition[angreifen, 1], out direction);
                    /*TurnToDirection(Convert.ToInt32(direction));
                    GoForward(Convert.ToInt32(distance / 5));
                    Stop();
                    Attack(aimedbug[angreifen]);
                    return;
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
                    if (aimedbug[i] != null)
                    {
                        distance = Coordinate.GetDistanceBetween(aimedbug[i], hill);
                        if (verfugbar[i, 1] > 10 && aimedbug[i] != null && distance < lowestamount && time - lastact[i] < 5000 && distance < 10000 && i != current1)
                        {
                            lowestamount = distance;
                            Think(current1.ToString());
                            angreifen = i;
                        }
                    }
                }
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
                for (int i = 2; i < 300; i++)
                {
                    if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                    GoForward(50);
                    if (verfugbar[angreifen, i] == 0)
                    {
                        verfugbar[angreifen, i] = Ameisenliste.IndexOf(this);
                        verfugbar[angreifen, 1]++;
                        getdistance(x, y, aimedposition[angreifen, 0], aimedposition[angreifen, 1], out distance);
                        if (verfugbar[angreifen, 1] >= 10 && aimedbug[angreifen] != null && distance < 500 && time - lastact[angreifen] < 10000 && distance > 5)
                        {
                            current2 = angreifen;
                            Think("2er Angriff weil beschlossen " + angreifen + current1.ToString());
                            getdirection(x, y, aimedposition[angreifen, 0], aimedposition[angreifen, 1], out direction);
                            /*TurnToDirection(Convert.ToInt32(direction));
                            GoForward(Convert.ToInt32(distance / 5));
                            Stop();
                            Attack(aimedbug[angreifen]);
                        }
                        return;
                    }
                }
            }*/
            if (Caste == "fighter" || Caste == "fighter3")
            {
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnByDegrees(RandomNumber.Number(360));
                GoForward(40);

                for (int i = 0; i < 300; i++)
                {
                    for (int u = 2; u < 300; u++)
                    {
                        if (verfugbar[i, u] == Ameisenliste.IndexOf(this) && aimedbug[i] != null)
                        {
                            if (!IsTired && WalkedRange < Range / 3)
                                Attack(aimedbug[i]);
                            else
                                GoToAnthill();
                            return;
                        }
                    }
                }

                int ld = 1000000;
                int angriff = 0;

                for (int i = 0; i < 300; i++)
                {
                    if (aimedbug[i] != null)
                        if (Coordinate.GetDistanceBetween(aimedbug[i], hill) < ld && verfugbar[i, 1] < 15)
                        {
                            ld = Coordinate.GetDistanceBetween(aimedbug[i], hill);
                            angriff = i;
                        }
                }

                if (aimedbug[angriff] != null && verfugbar[angriff, 1] < 15 && !IsTired)
                    for (int i = 2; i < 300; i++)
                    {
                        if (verfugbar[angriff, i] == 0)
                        {
                            verfugbar[angriff, i] = Ameisenliste.IndexOf(this);
                            verfugbar[angriff, 1]++;
                            if (!IsTired && WalkedRange < Range / 3)
                                Attack(aimedbug[angriff]);
                            else
                                GoToAnthill();
                            Think("Angriff" + angriff);
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
                        distance = Coordinate.GetDistanceBetween(this, zucker[i]);
                        if (distance < lowestdistance && distance < Range / 3)
                        {
                            lowestdistance = distance;
                            nearest = i;
                        }
                    }
                }
                if (lowestdistance < this.Range / 3 && zucker[nearest] != null)
                {
                    //Think(nearest.ToString());
                    if (unterwegs[nearest, 1] * MaximumLoad < zucker[nearest].Amount * 1.5 && CurrentLoad < MaximumLoad / 10)
                    {
                        if (Coordinate.GetDistanceBetween(this, zucker[nearest]) > 5 && Range > Coordinate.GetDistanceBetween(this, zucker[nearest]) * 3 && !IsTired)
                        {
                            TurnToDetination(zucker[nearest]);
                            GoForward(Convert.ToInt32(Coordinate.GetDistanceBetween(this, zucker[nearest]) / 1.1));
                            Think(Coordinate.GetDistanceBetween(this, zucker[nearest]).ToString());
                        }
                        else if (Range > Coordinate.GetDistanceBetween(this, zucker[nearest]) * 3 && !IsTired)
                            GoToDestination(zucker[nearest]);
                    }
                    else if (CurrentLoad < MaximumLoad / 10 && Range > Coordinate.GetDistanceBetween(this, zucker[nearest]) * 3 && !IsTired)
                    {
                        TurnToDetination(zucker[nearest]);
                        GoForward(Coordinate.GetDistanceBetween(this, (zucker[nearest])) / 2);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (zucker[nearest].Id == unterwegs[i, 0])
                        {
                            for (int u = 2; u < 100; u++)
                            {
                                if (unterwegs[i, u] == Ameisenliste.IndexOf(this)) return;
                                else if (unterwegs[i, u] == 0)
                                {
                                    Think("eingetragen - Unterwegs: " + unterwegs[i, 1]);
                                    unterwegs[i, u] = Ameisenliste.IndexOf(this);
                                    unterwegs[i, 1]++;
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Coordinate.GetDistanceBetween(this, hill) < 20)
                        TurnByDegrees(RandomNumber.Number(20));
                    GoForward(50);
                }
            }
            else if (Caste == "default")
            {
                if (Coordinate.GetDistanceBetween(this, hill) < 20)
                    TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
                int derapfel = 100;
                int lowestdistance = 1000000000;
                bool gefunden = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int u = 2; u < 20; u++)
                    {
                        if (Apfelliste[i, u] == Ameisenliste.IndexOf(this) && apple[i] != null)
                        {
                            if (CarryingFruit == null && Range > Coordinate.GetDistanceBetween(this, apple[i]) && !IsTired)
                            {
                                if (Coordinate.GetDistanceBetween(this, apple[i]) > 30)
                                {
                                    TurnToDetination(apple[i]);
                                    GoForward(Coordinate.GetDistanceBetween(this, apple[i]) / 2);
                                }
                                else
                                    GoToDestination(apple[i]);
                            }
                            else if (CarryingFruit == null && IsTired)
                            {
                                if (DistanceToAnthill > 30)
                                {
                                    TurnToDetination(hill);
                                    GoForward(DistanceToAnthill - 28);
                                }
                                else
                                    GoToDestination(hill);
                            }
                            return;
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    if (apple[i] != null)
                    {
                        int distance = Coordinate.GetDistanceBetween(this, apple[i]);
                        if (distance < lowestdistance && apple[i] != null && Apfelliste[i, 1] < 6)
                        {
                            lowestdistance = distance;
                            derapfel = i;
                            gefunden = true;
                        }
                    }
                }
                if (derapfel < 10 && gefunden && !IsTired)
                    if (apple[derapfel] != null)
                        for (int i = 2; i < 20; i++)
                        {
                            if (Apfelliste[derapfel, i] == 0 && Apfelliste[derapfel, 1] < 6)
                            {
                                Think(Apfelliste[derapfel, 1].ToString());
                                Apfelliste[derapfel, i] = Ameisenliste.IndexOf(this);
                                Apfelliste[derapfel, 1]++;
                                if (CarryingFruit == null)
                                {
                                    if (Coordinate.GetDistanceBetween(this, apple[derapfel]) > 30)
                                    {
                                        TurnToDetination(apple[derapfel]);
                                        GoForward(Coordinate.GetDistanceBetween(this, apple[derapfel]) / 2);
                                    }
                                    else
                                        GoToDestination(apple[derapfel]);
                                }
                                return;
                            }
                        }

                /*double x, y;
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
                    GoForward(50);
                }
                else
                {
                    if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                    GoForward(50);
                }*/
            }
            else if (Caste == "stand")
            {
                if (DistanceToAnthill > 30)
                {
                    TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 28);
                }
                else
                    GoToDestination(hill);
                return;
            }
            else
            {
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
            }
        }

        /// <summary>
        /// This method is called when an ant has travelled one third of its 
        /// movement range.
        /// Read more: "http://wiki.antme.net/en/API1:GettingTired"
        /// </summary>
        public override void GettingTired()
        {
            if (Caste != "fighter" && Caste != "fighter3" || Destination == null)
                if (DistanceToAnthill > 30)
                {
                    TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 28);
                }
                else
                {
                    GoToDestination(hill);
                    return;
                }
        }

        /// <summary>
        /// This method is called if an ant dies. It informs you that the ant has 
        /// died. The ant cannot undertake any more actions from that point forward.
        /// Read more: "http://wiki.antme.net/en/API1:HasDied"
        /// </summary>
        /// <param name="kindOfDeath">Kind of Death</param>
        public override void HasDied(KindOfDeath kindOfDeath)
        {
            if (Caste == "fighter" || Caste == "fighter3")
            {
                for (int i = 0; i < 300; i++)
                {
                    for (int u = 2; u < 300; u++)
                    {
                        if (verfugbar[i, u] == Ameisenliste.IndexOf(this))
                        {
                            verfugbar[i, u] = 0;
                            verfugbar[i, 1]--;
                        }
                    }
                }
            }
            else if (Caste == "default")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int u = 2; u < 20; u++)
                    {
                        if (Apfelliste[i, u] == Ameisenliste.IndexOf(this))
                        {
                            Apfelliste[i, u] = 0;
                            Apfelliste[i, 1]--;
                        }
                    }
                }
            }
            else if (Caste == "sugar")
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int u = 2; u < 100; u++)
                    {
                        if (verfugbar[i, u] == Ameisenliste.IndexOf(this))
                        {
                            unterwegs[i, u] = 0;
                            unterwegs[i, 1]--;
                        }
                    }
                }
            }
            if (Caste == "searcher")
            {
                for (int i = 1; i < 1000; i++)
                {
                    if (searcher[i] == Ameisenliste.IndexOf(this))
                    {
                        searcher[i] = 0;
                        searcher[0]--;
                        break;
                    }
                }
            }
            Think(Caste + Ameisenliste.IndexOf(this) + " ist tot");
        }

        /// <summary>
        /// This method is called in every simulation round, regardless of additional 
        /// conditions. It is ideal for actions that must be executed but that are not 
        /// addressed by other methods.
        /// Read more: "http://wiki.antme.net/en/API1:Tick"
        /// </summary>
        public override void Tick()
        {
            if (Caste == "searcher")
                Think("HAllo");
            if (hill == null)
            {
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
            time++;
            if (Caste == "north")
            {
                if (DistanceToAnthill > entfernung[0])
                {
                    entfernung[0] = DistanceToAnthill;
                }
                else if (DistanceToAnthill < entfernung[0] - 5)
                    absolute[0] = true;
                Think(entfernung[0].ToString() + absolute[0]);
                if (DistanceToAnthill == 0 && Direction != 270)
                {
                    TurnToDirection(270);
                    GoForward();
                }
                return;
            }
            if (Caste == "east")
            {
                if (DistanceToAnthill > entfernung[1])
                {
                    entfernung[1] = DistanceToAnthill;
                }
                else if (DistanceToAnthill < entfernung[1] - 5)
                    absolute[1] = true;
                Think(entfernung[1].ToString() + absolute[1]);
                if (DistanceToAnthill == 0 && Direction != 0)
                {
                    TurnToDirection(0);
                    GoForward();
                }
                return;
            }
            if (Caste == "south")
            {
                if (DistanceToAnthill > entfernung[2])
                {
                    entfernung[2] = DistanceToAnthill;
                }
                else if (DistanceToAnthill < entfernung[2] - 5)
                    absolute[2] = true;
                Think(entfernung[2].ToString() + absolute[2]);
                if (DistanceToAnthill == 0 && Direction != 90)
                {
                    TurnToDirection(90);
                    GoForward();
                }
                return;
            }
            if (Caste == "west")
            {
                if (DistanceToAnthill >= entfernung[3])
                {
                    entfernung[3] = DistanceToAnthill;
                }
                else if (DistanceToAnthill < entfernung[3] - 5)
                    absolute[3] = true;
                Think(entfernung[3].ToString() + absolute[3]);
                if (DistanceToAnthill == 0 && Direction != 180)
                {
                    TurnToDirection(180);
                    GoForward();
                }
                return;
            }
            if (Destination != null) Think(Destination.ToString() + "  " + (Range - WalkedRange));
            for (int i = 0; i < 100; i++)
            {
                if (hill == null)
                {
                    GoToAnthill();
                    hill = Destination as Anthill;
                    Stop();
                }
                double x, y, direction, distance;
                getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out x, out y);
                getdistance(x, y, targets[i, 1], targets[i, 2], out distance);
                if (distance < Viewrange && ForeignAntsInViewrange < 1 && targets[i, 0] != 0)
                {
                    Think("cleared");
                    targets[i, 0] = 0;
                    targets[i, 1] = 0;
                    targets[i, 2] = 0;
                }
                else if (targets[i, 0] == 0) break;
            }
            if (hill == null)
            {
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
            if (Destination is Bug)
            {
                for (int i = 0; i < aimedbug.Length; i++)
                {
                    if (Destination == aimedbug[i])
                    {
                        break;
                    }
                    else if (i == aimedbug.Length - 1 || aimedbug[i] == null)
                    {
                        GoToDestination(hill);
                        return;
                    }
                }
            }
            else if (Caste == "fighter" && (IsTired || WalkedRange > Range / 3 || DistanceToAnthill > (Range - WalkedRange) / 1.5))
            {
                GoToDestination(hill);
                return;
            }
            if (Caste == "fighter" && (IsTired || WalkedRange > Range / 3 || DistanceToAnthill > (Range - WalkedRange) / 1.5) && (Destination == null || !(Destination is Bug)))
            {
                GoToDestination(hill);
                return;
            }
            if ((((Caste != "fighter" && Caste != "default") || Destination == null && Caste != "fighter") || Caste == "sugar") && IsTired)
            {
                if (DistanceToAnthill > 30)
                {
                    TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 28);
                }
                else
                {
                    GoToDestination(hill);
                }
                return;
            }
            if (CurrentLoad > 5 && DistanceToAnthill < 30)
            {
                GoToDestination(hill);
                return;
            }
            if (CarryingFruit != null && DistanceToAnthill < 30)
            {
                GoToDestination(hill);
                return;
            }
            if (hill != null)
            {
                for (int i = 0; i < 300; i++)
                {
                    double distance, x, y;
                    getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                    getdistance(x, y, aimedposition[i, 0], aimedposition[i, 1], out distance);
                    if ((time - lastact[i] > 10000/* || distance < 10 && BugsInViewrange == 0*/) && aimedbug[i] != null)
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
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
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
                        Think("gelöscht");
                        zucker[i] = null;
                        for (int u = 0; u < 100; u++)
                        {
                            unterwegs[i, u] = 0;
                        }
                        aimedsugar[i, 0] = 3000000;
                        aimedsugar[i, 1] = 3000000;
                    }
            }
            if (CarryingFruit != null)
            {
                double x, y, xa, ya;
                getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                getapplecords(CarryingFruit, out xa, out ya);
                for (int i = 0; i < 10; i++)
                {
                    if (apple[i] != null)
                    {
                        if (apple[i].Id == CarryingFruit.Id)
                        {
                            Think(i.ToString() + "akt");
                            aimedapple[i, 0] = x;
                            aimedapple[i, 1] = y;
                            lastacta[i] = time;
                            return;
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    Apfelliste[i, 0] = CarryingFruit.Id;
                    lastacta[i] = time;
                    aimedapple[i, 0] = x;
                    aimedapple[i, 1] = y;
                    apple[i] = CarryingFruit;
                    lastacta[i] = time;
                    return;
                }
            }
            //else
            {
                double x, y;
                getcordsa(Coordinate.GetDistanceBetween(this, hill), Coordinate.GetDegreesBetween(this, hill), out x, out y);
                for (int i = 0; i < 10; i++)
                {
                    if (apple[i] != null)
                        if (Coordinate.GetDistanceBetween(apple[i], hill) < 10 || time - lastacta[i] > 1000)
                        {
                            if (Destination == apple[i])
                                Stop();
                            Think(i.ToString() + "weg");
                            lastacta[i] = 1000000;
                            apple[i] = null;
                            aimedapple[i, 0] = 3000000;
                            aimedapple[i, 1] = 3000000;
                            for (int u = 0; u < 20; u++)
                            {
                                Apfelliste[i, u] = 0;
                            }
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
            int derapfel = 100;
            int lowestdistance = 1000000000;
            double x, y;
            bool abg = false;
            getapplecords(fruit, out x, out y);
            for (int i = 0; i < 10; i++)
            {
                if (apple[i] != null && !abg)
                    if (Apfelliste[i, 0] == fruit.Id || fruit.Id == apple[i].Id)
                    {
                        Think(i + "akt");
                        Apfelliste[i, 0] = fruit.Id;
                        apple[i] = fruit;
                        derapfel = i;
                        lastacta[i] = time;
                        aimedapple[i, 0] = x;
                        aimedapple[i, 1] = y;
                        lastacta[i] = time;
                        abg = true;
                        break;
                    }
            }
            if (!abg)
                for (int i = 0; i < 10; i++)
                {
                    if (Apfelliste[i, 0] == 0 && apple[i] == null)
                    {
                        Think(i + "gefunden");
                        derapfel = i;
                        Apfelliste[i, 0] = fruit.Id;
                        lastacta[i] = time;
                        aimedapple[i, 0] = x;
                        aimedapple[i, 1] = y;
                        apple[i] = fruit;
                        lastacta[i] = time;
                        abg = true;
                        break;
                    }
                }
            if (Caste == "default")
            {
                bool gefunden = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int u = 2; u < 20; u++)
                    {
                        if (Apfelliste[i, u] == Ameisenliste.IndexOf(this) && apple[i] != null && !IsTired)
                        {
                            if (CarryingFruit == null)
                            {
                                if (Coordinate.GetDistanceBetween(this, apple[derapfel]) > 30)
                                {
                                    TurnToDetination(apple[derapfel]);
                                    GoForward(Coordinate.GetDistanceBetween(this, apple[derapfel]) / 2);
                                }
                                else
                                    GoToDestination(apple[derapfel]);
                            }
                            return;
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    if (apple[i] != null && Apfelliste[i, 0] != 0)
                    {
                        int distance = Coordinate.GetDistanceBetween(this, apple[i]);
                        if (distance < lowestdistance && apple[i] != null && Apfelliste[i, 1] < 6)
                        {
                            lowestdistance = distance;
                            derapfel = i;
                            gefunden = true;
                        }
                    }
                }
                if (derapfel < 10 && Apfelliste[derapfel, 1] < 6 && gefunden && !IsTired && apple[derapfel] != null)
                    if (apple[derapfel] != null)
                        for (int i = 2; i < 20; i++)
                        {
                            if (Apfelliste[derapfel, i] == 0)
                            {
                                Think(Apfelliste[derapfel, 1].ToString());
                                Apfelliste[derapfel, i] = Ameisenliste.IndexOf(this);
                                Apfelliste[derapfel, 1]++;
                                if (CarryingFruit == null)
                                {
                                    if (Coordinate.GetDistanceBetween(this, apple[derapfel]) > 30)
                                    {
                                        TurnToDetination(apple[derapfel]);
                                        GoForward(Coordinate.GetDistanceBetween(this, apple[derapfel]) / 2);
                                    }
                                    else
                                        GoToDestination(apple[derapfel]);
                                }
                                return;
                            }
                        }
                if (Coordinate.GetDistanceBetween(this, hill) < 20)
                    TurnToDirection(RandomNumber.Number(360));
                GoForward(50);
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
                    unterwegs[i, 0] = sugar.Id;
                    break;
                }
            }
            if (Range > DistanceToAnthill * 3 && CarryingFruit == null && Caste == "sugar" && CurrentLoad < MaximumLoad / 5 && !IsTired)
            {
                if (Destination != sugar)
                    Stop();
                GoToDestination(sugar);
                for (int i = 0; i < 4; i++)
                {
                    if (sugar.Id == unterwegs[i, 0])
                    {
                        for (int u = 2; u < 100; u++)
                        {
                            if (unterwegs[i, u] == Ameisenliste.IndexOf(this)) return;
                            else if (unterwegs[i, u] == 0)
                            {
                                Think("eingetragen");
                                unterwegs[i, u] = Ameisenliste.IndexOf(this);
                                unterwegs[i, 1]++;
                                return;
                            }
                        }
                    }
                }
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
            if (DistanceToAnthill > 30)
            {
                TurnToDetination(hill);
                GoForward(DistanceToAnthill - 28);
            }
            else
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
            if (Caste == "sugar")
            {
                Think("genommen");
                Take(sugar);
                if (DistanceToAnthill > 30)
                {
                    TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 28);
                }
                else
                    GoToDestination(hill);
                return;
                //MakeMark(0, 300);
                for (int i = 0; i < 4; i++)
                {
                    if (sugar.Id == unterwegs[i, 0])
                        for (int u = 2; u < 100; u++)
                        {
                            if (unterwegs[i, u] == Ameisenliste.IndexOf(this))
                            {
                                unterwegs[i, u] = 0;
                                unterwegs[i, 1]--;
                                Think("Ausgetragen - Unterwegs: " + unterwegs[i, 1]);
                                return;
                            }
                        }
                }
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
            if (((Caste == "fighter2") && Range > DistanceToAnthill * 3 || Caste == "stand" && DistanceToAnthill < 300) && (enemyant[ant.Id, 1] == Ameisenliste.IndexOf(this) || enemyant[ant.Id, 2] < 1) && !IsTired)
            {
                if (enemyant[ant.Id, 0] != 1)
                    enemyant[ant.Id, 0] = 1;
                enemyant[ant.Id, 1] = Ameisenliste.IndexOf(this);
                enemyant[ant.Id, 2]++;
                Think("j");
                Attack(ant);
            }
            int x, y;
            getcoordsenemytarget(ant, out x, out y);
            if (!enemies.Contains(ant))
            {
                enemies.Add(ant);
                Think("Liste erweitert");
            }
            if (ant.CurrentLoad > ant.MaximumLoad / 10 || ant.CurrentEnergy < ant.MaximumEnergy / 2 || ant.CarriedFruit != null)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (targets[i, 1] < x + 5 && targets[i, 1] > x - 5 && targets[i, 2] < y + 5 && targets[i, 2] > y - 5)
                    {
                        targets[i, 0]++;
                        Think("erweitert");
                    }
                    else if (targets[i, 0] == 0 && targets[i, 1] == 0 && targets[i, 2] == 0)
                    {
                        targets[i, 0] = 1;
                        targets[i, 1] = x;
                        targets[i, 2] = y;
                        Think("eingetragen");
                        return;
                    }
                }
            }
            //else if (Coordinate.GetDistanceBetween(this, ant) < 10 && CarryingFruit == null && CurrentEnergy > MaximumEnergy / 3) //GoAwayFrom(ant, 10);
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
                //if (CarryingFruit == null)
                //GoAwayFrom(bug, 20);
            }
            else if (Caste == "searcher")
            {
                double directiona = Coordinate.GetDegreesBetween(this, hill);
                double directionb = Coordinate.GetDegreesBetween(bug, hill);
                //if (CarryingFruit == null)
                //GoAwayFrom(bug, 20);
            }
            if ((Caste == "fighter" && (Coordinate.GetDistanceBetween(this, bug) < 5 || bug.CurrentEnergy < ((FriendlyAntsFromSameCasteInViewrange) * 30))) && !IsTired && WalkedRange < Range / 3)
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
            if (Caste == "fighter" && Range > DistanceToAnthill * 1.5 && FriendlyAntsFromSameCasteInViewrange > 7 && !IsTired && WalkedRange < Range / 3)
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
                //if (CarryingFruit == null)
                //GoAwayFrom(bug, 20);
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
            if (Caste == "fighter" || Caste == "fighter2" || Caste == "stand")
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
                //if (CarryingFruit == null)
                //GoAwayFrom(bug, 20);
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

        public static void getcoordsenemytarget(Ant ant, out int x, out int y)
        {
            double distancee, directione, distancem, directionm, xa, ya, xea, yea;
            distancee = ant.DistanceToTarget;
            directione = ant.DegreesToTarget + ant.Direction;
            if (directione >= 360) directione -= 360;
            distancem = Coordinate.GetDistanceBetween(ant, hill);
            directionm = Coordinate.GetDegreesBetween(ant, hill);
            getcordsa(distancem, directionm, out xa, out ya);
            getcordsa(distancee, directione, out xea, out yea);
            x = Convert.ToInt32(xea + xa);
            y = Convert.ToInt32(yea + ya);
        }
        #endregion
    }
}
