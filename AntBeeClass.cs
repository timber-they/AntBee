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
        EnergyModifier = 0,
        LoadModifier = -1,
        RangeModifier = -1,
        RotationSpeedModifier = -1,
        SpeedModifier = 2,
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
        AttackModifier = -1,
        EnergyModifier = 2,
        LoadModifier = -1,
        RangeModifier = 0,
        RotationSpeedModifier = -1,
        SpeedModifier = 2,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "west",
        AttackModifier = -1,
        EnergyModifier = 2,
        LoadModifier = -1,
        RangeModifier = 0,
        RotationSpeedModifier = -1,
        SpeedModifier = 2,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "north",
        AttackModifier = -1,
        EnergyModifier = 2,
        LoadModifier = -1,
        RangeModifier = 0,
        RotationSpeedModifier = -1,
        SpeedModifier = 2,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "east",
        AttackModifier = -1,
        EnergyModifier = 2,
        LoadModifier = -1,
        RangeModifier = 0,
        RotationSpeedModifier = -1,
        SpeedModifier = 2,
        ViewRangeModifier = -1
        )]
    [Caste(
        Name = "star",
        AttackModifier = -1,
        EnergyModifier = -1,
        LoadModifier = -1,
        RangeModifier = 1,
        RotationSpeedModifier = -1,
        SpeedModifier = 1,
        ViewRangeModifier = 2
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
        public static List<AntBeeClass> searcher = new List<AntBeeClass>();
        public static int[] entfernung = new int[4];
        public static bool[] absolute = new bool[4];
        public static int[] stars = new int[20];
        public static Anthill ebase = null;
        public static bool listda = false;
        public static bool spotted = false;
        public static Ant verfolgen = null;
        public static double basex = 0;
        public static double basey = 0;
        public static decimal lastv = 0;
        public static AntBeeClass timera = null;
        public static int norandom = 0;

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
            if (timera == null) timera = this;
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
                if (spawned[i] < 1)
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
            if (searcher.Count < 8)
            {
                searcher.Add(this);
                listda = true;
                return "searcher";
            }
            if (stars[0] < 0)
            {
                stars[0]++;
                for (int i = 1; i < 20; i++)
                {
                    if (stars[i] == 0)
                    {
                        stars[i] = Ameisenliste.IndexOf(this);
                        break;
                    }
                }
                return "star";
            }
            if (r < 0)
                return "stand";
            else if (r < 5)
                return "default";
            else if (r < 16)
                return "sugar";
            else if (r < 22)
                return "fighter2";
            else if (r < 22)
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
            if (CurrentLoad > 5)
            {
                GoToAnthill();
                return;
            }
            if (timera == null) timera = this;
            if (hill == null)
            {
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
            if (Caste == "north")
            {
                if (Direction != 270)
                    TurnToDirection(270);
                if (!absolute[0])
                    GoForward();
                else
                    GoForward(50);
                return;
            }
            if (Caste == "east")
            {
                if (Direction != 0)
                    TurnToDirection(0);
                if (!absolute[1])
                    GoForward();
                else
                    GoForward(50);
                if (!absolute[2])
                    GoForward();
                else
                    GoForward(50);
                return;
            }
            if (Caste == "south")
            {
                if (Direction != 90)
                    TurnToDirection(90);
                if (!absolute[2])
                    GoForward();
                else
                    GoForward(50);
                return;
            }
            if (Caste == "west")
            {
                if (Direction != 180)
                    TurnToDirection(180);
                if (!absolute[3])
                    GoForward();
                else
                    GoForward(50);
                return;
            }
            if (Caste == "fighter2" && !IsTired && spotted)
            {
                double distance, direction, x, y;
                getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out x, out y);
                getdistance(x, y, basex, basey, out distance);
                //if (Range - WalkedRange - distance > Range * 2 / 3)
                if(distance > 50)
                {
                    getdirection(x, y, basex, basey, out direction);
                    TurnToDirection(Convert.ToInt32(direction));
                    GoForward(Convert.ToInt32(distance));
                    Think("Infiltrieren");
                    return;
                }
                else
                {
                }
            }
            if (IsTired && (Caste != "sugar" || (CurrentLoad > MaximumLoad / 10)) && (Caste != "fighter2" || !spotted))
            {
                if (DistanceToAnthill > 10)
                {
                    if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 5);
                }
                else
                    GoToDestination(hill);
                return;
            }
            if (Caste == "searcher")
            {
                int distance = 0;
                double x, y, lx, ly, direction, distanz, angle;
                distance = (searcher.IndexOf(this)) * Viewrange + Viewrange;
                getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out x, out y);

                if (distance == 0)
                {
                    Think("ERROR");
                    GoToDestination(hill);
                    return;
                }
                if (DistanceToAnthill/* * Math.Cos(Coordinate.GetDegreesBetween(this, hill) * (180 / Math.PI))*/ < distance - 20)
                {
                    bool alle = true;
                    Think("falsch");
                    if (DistanceToAnthill > 5)
                    {
                        Think("korrigiere" + Convert.ToInt32(distance) + " " + DistanceToAnthill);
                        if (x > 0)
                        {
                            if (y > 0)
                            {
                                angle = 135;
                            }
                            else
                            {
                                angle = 225;
                            }
                        }
                        else
                        {
                            if (y > 0)
                            {
                                angle = 45;
                            }
                            else
                            {
                                angle = 315;
                            }
                        }
                        getcordsa(distance, angle, out lx, out ly);
                        getdirection(x, y, lx, ly, out direction);
                        getdistance(x, y, lx, ly, out distanz);
                        TurnToDirection(Convert.ToInt32(direction));
                        GoForward(Convert.ToInt32(distanz) - 10);
                        return;
                    }
                    else
                    {
                        int rd = 0;
                        Think("richte aus");
                        for (int i = 0; i < 4; i++)
                        {
                            if (!absolute[i])
                            {
                                if (Direction != 45)
                                    TurnToDirection(45);
                                alle = false;
                                rd = 1;
                            }
                        }
                        if (alle)
                        {
                            double distanceh;
                            getdistance(x, y, basex, basey, out distanceh);
                            if (entfernung[0] > entfernung[2] && (basey <= 0 || distanceh > distance) || (basey < 0 && distanceh >= distance))
                            {
                                if (entfernung[1] > entfernung[3])
                                {
                                    if (Direction != 315)
                                        TurnToDirection(315);
                                    rd = 0;
                                }
                                else
                                {
                                    if (Direction != 225)
                                        TurnToDirection(225);
                                    rd = 3;
                                }
                            }
                            else
                            {
                                if (entfernung[1] > entfernung[3])
                                {
                                    if (Direction != 45)
                                        TurnToDirection(45);
                                    rd = 1;
                                }
                                else
                                {
                                    if (Direction != 135)
                                        TurnToDirection(135);
                                    rd = 2;
                                }
                            }
                        }
                        /*while(distance > entfernung[rd] / Math.Cos(Direction * Math.PI / 180) || distance > entfernung[rd] / Math.Cos((Direction - 45) * Math.PI / 180))
                        {
                            distance--;
                        }*/
                        if(alle || time > 13000)
                            GoForward(distance);
                    }
                    return;
                }
                else
                {
                    Think("aufgestellt" + distance);
                    bool r = false;
                    if (searcher.IndexOf(this) % 2 == 0)
                        r = true;
                    if (Coordinate.GetDegreesBetween(this, hill) >= 210 && Coordinate.GetDegreesBetween(this, hill) <= 240)
                    {
                        if (r)
                        {
                            if (Direction != 270)
                                TurnToDirection(270);
                        }
                        else if (Direction != 180)
                            TurnToDirection(180);
                        GoForward(Convert.ToInt32(DistanceToAnthill * 1.15 / 0.70710678118));
                        return;
                    }
                    else if (Coordinate.GetDegreesBetween(this, hill) >= 120 && Coordinate.GetDegreesBetween(this, hill) <= 150)
                    {
                        if (r)
                        {
                            if (Direction != 180)
                                TurnToDirection(180);
                        }
                        else if (Direction != 90)
                            TurnToDirection(90);
                        GoForward(Convert.ToInt32(DistanceToAnthill * 1.15 / 0.70710678118));
                        return;
                    }
                    else if (Coordinate.GetDegreesBetween(this, hill) >= 30 && Coordinate.GetDegreesBetween(this, hill) <= 60)
                    {
                        if (r)
                        {
                            if (Direction != 90)
                                TurnToDirection(90);
                        }
                        else if (Direction != 0)
                            TurnToDirection(0);
                        GoForward(Convert.ToInt32(DistanceToAnthill * 1.15 / 0.70710678118));
                        return;
                    }
                    else if (Coordinate.GetDegreesBetween(this, hill) >= 300 && Coordinate.GetDegreesBetween(this, hill) <= 330)
                    {
                        if (r)
                        {
                            if (Direction != 0)
                                TurnToDirection(0);
                        }
                        else if (Direction != 270)
                            TurnToDirection(270);
                        GoForward(Convert.ToInt32(DistanceToAnthill * 1.15 / 0.70710678118));
                        return;
                    }
                    else
                    {
                        Think("falsch");
                        if (DistanceToAnthill > 5)
                        {
                            Think("korrigiere" + Coordinate.GetDegreesBetween(this, hill));
                            getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out x, out y);
                            if (x > 0)
                            {
                                if (y > 0)
                                {
                                    angle = 135;
                                }
                                else
                                {
                                    angle = 225;
                                }
                            }
                            else
                            {
                                if (y > 0)
                                {
                                    angle = 45;
                                }
                                else
                                {
                                    angle = 315;
                                }
                            }
                            getcordsa(distance, angle, out lx, out ly);
                            getdirection(x, y, lx, ly, out direction);
                            getdistance(x, y, lx, ly, out distanz);
                            TurnToDirection(Convert.ToInt32(direction));
                            GoForward(Convert.ToInt32(distanz) - 10);
                            return;
                        }
                        else
                        {
                            bool alle = true;
                            Think("richte aus");
                            for (int i = 0; i < 4; i++)
                            {
                                if (!absolute[i])
                                {
                                    if (Direction != 45)
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
                                        if (Direction != 315)
                                            TurnToDirection(315);
                                    }
                                    else
                                    {
                                        if (Direction != 225)
                                            TurnToDirection(225);
                                    }
                                }
                                else
                                {
                                    if (entfernung[1] > entfernung[3])
                                    {
                                        if (Direction != 45)
                                            TurnToDirection(45);
                                    }
                                    else
                                    {
                                        if (Direction != 135)
                                            TurnToDirection(135);
                                    }
                                }
                            }
                            GoForward(distance);
                            return;
                        }
                    }
                }
            }
            else if (Caste == "star")
            {
                int that = 0;
                for (int i = 1; i < 20; i++)
                {
                    if (stars[i] == Ameisenliste.IndexOf(this))
                    {
                        that = i;
                    }
                }
                if (DistanceToAnthill > 5 && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)) && (Caste != "fighter2" || !spotted))
                {
                    Think("back");
                    if (DistanceToAnthill > 10)
                    {
                        if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                        GoForward(DistanceToAnthill - 5);
                    }
                    else
                        GoToDestination(hill);
                    return;
                }
                else
                {
                    if (Direction != (359 / 8) * that)
                        TurnToDirection((359 / 8) * that);
                    GoForward(Convert.ToInt32(Range / 2.1));
                    Think("Ich bin ein Star!");
                    return;
                }
            }
            if (hill == null)
            {
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
            if (IsTired && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)) && (Caste != "fighter2" || !spotted))
            {
                if (DistanceToAnthill > 10)
                {
                    if (Direction != Coordinate.GetDegreesBetween(this, hill))
                        if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 5);
                }
                else
                    GoToDestination(hill);
                return;
            }
            else if(Caste != "sugar" || CurrentLoad < MaximumLoad / 10)
            {
                if (Coordinate.GetDistanceBetween(this, hill) < 10) TurnToDirection(norandom); norandom += 5;
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
            /*if (Caste == "fighter2")
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
                if (aim < 101 && highest > 5 && !(targets[aim, 1] == 0 && targets[aim, 2] == 0))
                {
                    getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out x, out y);
                    getdirection(x, y, targets[aim, 1], targets[aim, 2], out direction);
                    getdistance(x, y, targets[aim, 1], targets[aim, 2], out distance);
                    if (distance < (double)500 && distance < Range / 3)
                    {
                        Think("aimed x: " + targets[aim, 1] + " y: " + targets[aim, 2]);
                        if (Direction != Convert.ToInt32(direction))
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
                else if(listda)
                {
                    if (enemies[0] != null)
                    {
                        Attack(enemies[0]);
                        Think("Attack by List");
                    }
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
                }
                else if (targets[i, 0] == 0) break;
            }*/
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
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection((359 / Ameisenliste.Count) * Ameisenliste.IndexOf(this));
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
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection((359 / Ameisenliste.Count) * Ameisenliste.IndexOf(this));
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
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection((359 / Ameisenliste.Count) * Ameisenliste.IndexOf(this));
                GoForward(50);
                for (int i = 2; i < 300; i++)
                {
                    if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection((359 / Ameisenliste.Count) * Ameisenliste.IndexOf(this));
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
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection((359 / Ameisenliste.Count) * Ameisenliste.IndexOf(this));
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
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection((359 / Ameisenliste.Count) * Ameisenliste.IndexOf(this));
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
                if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection((359 / Ameisenliste.Count) * Ameisenliste.IndexOf(this));
                GoForward(50);
                for (int i = 2; i < 300; i++)
                {
                    if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection((359 / Ameisenliste.Count) * Ameisenliste.IndexOf(this));
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
                        if (verfugbar[i, u] == Ameisenliste.IndexOf(this) && aimedbug[i] != null && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10 || Direction != Coordinate.GetDegreesBetween(this, hill))) && (Caste != "fighter2" || !spotted))
                        {
                            if (!IsTired && WalkedRange < Range / 3)
                                Attack(aimedbug[i]);
                            else
                                GoToDestination(hill);
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
                        if (verfugbar[angriff, i] == 0 && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)) && (Caste != "fighter2" || !spotted))
                        {
                            verfugbar[angriff, i] = Ameisenliste.IndexOf(this);
                            verfugbar[angriff, 1]++;
                            if (!IsTired && WalkedRange < Range / 3)
                                Attack(aimedbug[angriff]);
                            else
                                GoToDestination(hill);
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
                    if (unterwegs[nearest, 1] * MaximumLoad < zucker[nearest].Amount * 1.8 && CurrentLoad < MaximumLoad / 10)
                    {
                        if (Coordinate.GetDistanceBetween(this, zucker[nearest]) > 2 && Range - WalkedRange - Coordinate.GetDistanceBetween(this, zucker[nearest]) > Range * 2 / 3 && !IsTired && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)))
                        {
                            if (Direction != Coordinate.GetDegreesBetween(this, zucker[nearest]))
                                TurnToDetination(zucker[nearest]);
                            GoForward(Convert.ToInt32(Coordinate.GetDistanceBetween(this, zucker[nearest]) / 1.1));
                            return;
                            //Think(Coordinate.GetDistanceBetween(this, zucker[nearest]).ToString());
                        }
                        else if (Range - WalkedRange - Coordinate.GetDistanceBetween(this, zucker[nearest]) > Range * 2 / 3 && !IsTired)
                            GoToDestination(zucker[nearest]);
                    }
                    else if (CurrentLoad < MaximumLoad / 10 && Range - WalkedRange - Coordinate.GetDistanceBetween(this, zucker[nearest]) > Range * 2 / 3 && !IsTired)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (zucker[i] != null)
                            {
                                int distanz = Convert.ToInt32(Coordinate.GetDistanceBetween(this, zucker[i]));
                                if (zucker[i] != null && Range - WalkedRange - distanz > Range * 2 / 3)
                                {
                                    TurnToDetination(zucker[i]);
                                    GoForward(distanz);
                                    return;
                                }
                            }
                        }
                        if (Direction != Coordinate.GetDegreesBetween(this, zucker[nearest]))
                            TurnToDetination(zucker[nearest]);
                        GoForward(Coordinate.GetDistanceBetween(this, (zucker[nearest])) / 2);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (zucker[nearest].Id == unterwegs[i, 0])
                        {
                            for (int u = 2; u < 100; u++)
                            {
                                if (unterwegs[i, u] == Ameisenliste.IndexOf(this)) break;
                                else if (unterwegs[i, u] == 0)
                                {
                                    //Think("eingetragen - Unterwegs: " + unterwegs[i, 1]);
                                    unterwegs[i, u] = Ameisenliste.IndexOf(this);
                                    unterwegs[i, 1]++;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Coordinate.GetDistanceBetween(this, hill) < 20)
                    {
                        TurnToDirection(RandomNumber.Number(180));
                        GoForward(50);
                    }
                }
            }
            else if (Caste == "default")
            {
                if (Coordinate.GetDistanceBetween(this, hill) < 10)
                    TurnToDirection(norandom); norandom += 5;
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
                            if (CarryingFruit == null && Range - WalkedRange - Coordinate.GetDistanceBetween(this, apple[i]) > Range * 2 / 3 && !IsTired)
                            {
                                Think("gehzuapfel");
                                if (Coordinate.GetDistanceBetween(this, apple[i]) > 40)
                                {
                                    if (Direction != Coordinate.GetDegreesBetween(this, apple[i]))
                                        TurnToDetination(apple[i]);
                                    GoForward(Coordinate.GetDistanceBetween(this, apple[i]) / 3);
                                }
                                else
                                    GoToDestination(apple[i]);
                                return;
                            }
                            else if (IsTired && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10 || Direction != Coordinate.GetDegreesBetween(this, hill))) && (Caste != "fighter2" || !spotted))
                            {
                                if (DistanceToAnthill > 10)
                                {
                                    if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                                    GoForward(DistanceToAnthill - 5);
                                }
                                else
                                    GoToDestination(hill);
                                return;
                            }
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    if (apple[i] != null)
                    {
                        int distance = Coordinate.GetDistanceBetween(this, apple[i]);
                        if (distance < lowestdistance && apple[i] != null && Apfelliste[i, 1] < 6 && distance < Range / 3)
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
                                //Think(Apfelliste[derapfel, 1].ToString());
                                Apfelliste[derapfel, i] = Ameisenliste.IndexOf(this);
                                Apfelliste[derapfel, 1]++;
                                if (CarryingFruit == null && Range - WalkedRange - Coordinate.GetDistanceBetween(this, apple[derapfel]) > Range * 2 / 3)
                                {
                                    if (Coordinate.GetDistanceBetween(this, apple[derapfel]) > 40)
                                    {
                                        if (Direction != Coordinate.GetDegreesBetween(this, apple[derapfel]))
                                            TurnToDetination(apple[derapfel]);
                                        GoForward(Coordinate.GetDistanceBetween(this, apple[derapfel]) / 3);
                                    }
                                    else
                                        GoToDestination(apple[derapfel]);
                                    return;
                                }
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
                    if (Coordinate.GetDistanceBetween(this, hill) < 20) TurnToDirection((359 / Ameisenliste.Count) * Ameisenliste.IndexOf(this));
                    GoForward(50);
                }*/
            }
            else if (Caste == "stand" && (Caste != "fighter2" || !spotted))
            {
                if (DistanceToAnthill > 10)
                {
                    if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 5);
                }
                else
                    GoToDestination(hill);
                return;
            }
            else if ((Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)))
            {
                if (Coordinate.GetDistanceBetween(this, hill) < 10) TurnToDirection(norandom); norandom += 5;
                GoForward(50);
            }
            if(DistanceToAnthill > 10 && Caste != "default" && Caste != "fighter2" && false)
                GoToAnthill();
            else if(CurrentLoad < 5)
            {
                if(Coordinate.GetDistanceBetween(this, hill) < 10)
                TurnToDirection(norandom); norandom += 5;
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
            if (Caste == "fighter2" && spotted)
                return;
            if ((Caste != "fighter2" || !spotted) && Caste != "fighter" && Caste != "fighter3" && Caste != "north" && Caste != "south" && Caste != "west" && Caste != "east" && CurrentLoad < 5 && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10 || Direction != Coordinate.GetDegreesBetween(this, hill))) && (Caste != "fighter2" || !spotted) && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)) || Destination == null && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)))
            {
                if (Caste == "north" || Caste == "south" || Caste == "west" || Caste == "east")
                {
                    return;
                }
                if (DistanceToAnthill > 10)
                {
                    if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 5);
                }
                else
                {
                    GoToDestination(hill);
                    return;
                }
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
            Ameisenliste.Remove(this);
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
                searcher.Remove(this);
            }
            else if (Caste == "star")
            {
                for (int i = 1; i < 20; i++)
                {
                    if (stars[i] == Ameisenliste.IndexOf(this))
                    {
                        stars[i] = 0;
                        stars[0]--;
                    }
                }
            }
            //Think(Caste + Ameisenliste.IndexOf(this) + " ist tot");
        }

        /// <summary>
        /// This method is called in every simulation round, regardless of additional 
        /// conditions. It is ideal for actions that must be executed but that are not 
        /// addressed by other methods.
        /// Read more: "http://wiki.antme.net/en/API1:Tick"
        /// </summary>
        public override void Tick()
        {
            if (norandom > 360) norandom -= 360;
            if (timera == null) timera = this;
            if (Caste == "fighter2" && spotted)
            {
                double distance, x, y;
                getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out x, out y);
                getdistance(x, y, basex, basey, out distance);
                //if (Range - WalkedRange - distance > Range * 2 / 3)
                //Think(distance.ToString());
                if (distance > 50)
                {
                    //Think("haha");
                }
                else if(!(Destination is Ant) && Destination == null && CurrentSpeed > 2)
                {
                    //Think("stoped");
                    Stop();
                }
            }
            //Think(spotted.ToString());
            if (verfolgen != null)
                if (verfolgen.CurrentEnergy < verfolgen.MaximumEnergy / 2 || time - lastv > 20000)
                    verfolgen = null;
            if (verfolgen != null && !spotted)
                Think("verfolge...");
            if (verfolgen != null)
                if ((verfolgen.CurrentLoad < verfolgen.MaximumLoad / 5 && verfolgen.CarriedFruit == null) && !spotted)
                {
                    double xm, ym, xtm, ytm, x, y;
                    getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out xm, out ym);
                    getcordsa(Coordinate.GetDistanceBetween(verfolgen, this), Coordinate.GetDegreesBetween(verfolgen, this), out xtm, out ytm);
                    x = xm + xtm;
                    y = ym + ytm;
                    basex = x;
                    basey = y;
                    if (Caste == "fighter2")
                    {
                        TurnToDetination(verfolgen);
                        GoForward(Coordinate.GetDistanceBetween(this, verfolgen));
                        Think("Infiltriere");
                    }
                    Think("gefunden; X:" + Convert.ToInt32(x) + " Y: " + Convert.ToInt32(y));
                    spotted = true;
                    verfolgen = null;
                }
            if (Caste == "fighter2" && spotted) return;
            /*if (hill != null && Destination != null && DistanceToAnthill > 100 && ForeignAntsInViewrange > 5)
            {
                if (ebase == null)
                {
                    GoToAnthill();
                    if (Destination as Anthill != hill)
                    {
                        ebase = Destination as Anthill;
                    }
                    Stop();
                }
                else Think("YAAAAAY");
            }*/
            double xt, yt;
            getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out xt, out yt);
            //Think("x: " + Convert.ToInt32(xt) + " Y: " + Convert.ToInt32(yt) + " A: " + Convert.ToInt32(Coordinate.GetDegreesBetween(this, hill)) + " AH: " + Convert.ToInt32(Coordinate.GetDegreesBetween(hill, this)));
            if (Caste == "star")
                Think("star");
            if (hill == null)
            {
                GoToAnthill();
                hill = Destination as Anthill;
                Stop();
            }
            if(this == timera)
            {
                time += 50;
            }
            if (Caste == "star") return;
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
                    if (Direction != 270)
                        TurnToDirection(270);
                    if (!absolute[0])
                        GoForward();
                    else
                        GoForward(50);
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
                    if (Direction != 0)
                        TurnToDirection(0);
                    if (!absolute[1])
                        GoForward();
                    else
                        GoForward(50);
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
                    if (Direction != 90)
                        TurnToDirection(90);
                    if (!absolute[2])
                        GoForward();
                    else
                        GoForward(50);
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
                    if (Direction != 180)
                        TurnToDirection(180);
                    if (!absolute[3])
                        GoForward();
                    else
                        GoForward(50);
                }
                return;
            }
            //if (Destination != null) Think(Destination.ToString() + "  " + (Range - WalkedRange));
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
                    else if (i == aimedbug.Length - 1 || aimedbug[i] == null && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)) && (Caste != "fighter2" || !spotted))
                    {
                        GoToDestination(hill);
                        return;
                    }
                }
            }
            else if (Caste == "fighter" && (Caste != "fighter2" || !spotted) && (IsTired || WalkedRange > Range / 3 || DistanceToAnthill > (Range - WalkedRange) / 1.5) && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)) && (Caste != "fighter2" || !spotted))
            {
                if (DistanceToAnthill > 10)
                {
                    if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 5);
                }
                else
                    GoToDestination(hill);
                return;
            }
            if (Caste == "fighter" && (Caste != "fighter2" || !spotted) && (IsTired || WalkedRange > Range / 3 || DistanceToAnthill > (Range - WalkedRange) / 1.5) && (Destination == null || !(Destination is Bug)) && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)) && (Caste != "fighter2" || !spotted))
            {
                if (DistanceToAnthill > 10)
                {
                    if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 5);
                }
                else
                    GoToDestination(hill);
                return;
            }
            if ((((Caste != "fighter" && (Caste != "fighter2" || !spotted) && Caste != "default") || Destination == null && Caste != "fighter")) && IsTired && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)) && (Caste != "fighter2" || !spotted) && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)))
            {
                if (DistanceToAnthill > 10)
                {
                    if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 5);
                }
                else
                {
                    GoToDestination(hill);
                }
                return;
            }
            /*if (CurrentLoad > 5)
            {
                if (DistanceToAnthill > 10)
                {
                    if(Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 15);
                }
                else
                    GoToDestination(hill);
                return;
            }
            if (CarryingFruit != null)
            {
                if (DistanceToAnthill > 10)
                {
                    if(Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 15);
                }
                else
                    GoToDestination(hill);
                return;
            }*/
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
                            Think(i.ToString() + "akt" + Apfelliste[i, 0]);
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
                        Think(i + "akt" + Apfelliste[i, 0]);
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
                GoToDestination(fruit);
                for (int i = 0; i < 10; i++)
                {
                    if (apple[i] != null && Apfelliste[i, 0] != 0)
                    {
                        int distance = Coordinate.GetDistanceBetween(this, apple[i]);
                        if (distance < lowestdistance && apple[i] != null && Apfelliste[i, 1] < 6 && distance < Range / 3)
                        {
                            lowestdistance = distance;
                            derapfel = i;
                            gefunden = true;
                        }
                    }
                }
                if (derapfel < 10 && Apfelliste[derapfel, 1] < 100 && gefunden && !IsTired && apple[derapfel] != null)
                    if (apple[derapfel] != null)
                        for (int i = 2; i < 20; i++)
                        {
                            if (Apfelliste[derapfel, i] == 0)
                            {
                                Think(Apfelliste[derapfel, 1].ToString());
                                Apfelliste[derapfel, i] = Ameisenliste.IndexOf(this);
                                Apfelliste[derapfel, 1]++;
                                if (CarryingFruit == null && Range - WalkedRange - Coordinate.GetDistanceBetween(this, apple[derapfel]) > Range * 2 / 3)
                                {
                                    GoToDestination(apple[derapfel]);
                                }
                                else if ((Caste != "fighter2" || !spotted) && Range - WalkedRange - Coordinate.GetDistanceBetween(this, apple[derapfel]) < Range * 2 / 3 && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)) && (Caste != "sugar" || (CurrentLoad < MaximumLoad / 10)))
                                {
                                    if (DistanceToAnthill > 10)
                                    {
                                        if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                                        GoForward(DistanceToAnthill - 5);
                                    }
                                    else
                                    {
                                        GoToDestination(hill);
                                    }
                                }
                                return;
                            }
                        }
                for (int i = 0; i < 10; i++)
                {
                    for (int u = 2; u < 20; u++)
                    {
                        if (Apfelliste[i, u] == Ameisenliste.IndexOf(this) && apple[i] != null && !IsTired)
                        {
                            if (CarryingFruit == null && Range - WalkedRange - Coordinate.GetDistanceBetween(this, apple[derapfel]) > Range * 2 / 3)
                            {
                                GoToDestination(apple[derapfel]);
                            }
                            return;
                        }
                    }
                }
                if (Coordinate.GetDistanceBetween(this, hill) < 10)
                    TurnToDirection(norandom); norandom += 5;
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
                if(zucker[i] == sugar && ForeignAntsInViewrange > 5)
                {
                    aimedsugar[i, 0] = 0;
                    aimedsugar[i, 1] = 0;
                    zucker[i] = null;
                }
            }
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
            if (Range - WalkedRange - Coordinate.GetDistanceBetween(this, sugar) > Range * 2 / 3 && CarryingFruit == null && Caste == "sugar" && CurrentLoad < MaximumLoad / 5 && !IsTired)
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
            if (DistanceToAnthill > 10)
            {
                if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                GoForward(DistanceToAnthill - 5);
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
                if (DistanceToAnthill > 10)
                {
                    if (Direction != Coordinate.GetDegreesBetween(this, hill)) TurnToDetination(hill);
                    GoForward(DistanceToAnthill - 5);
                }
                else
                    GoToDestination(hill);
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
            /*if (ant.CarriedFruit != null && Caste == "default")
                if (ant.CurrentLoad > ant.CarriedFruit.Amount)
                    GoToDestination(ant.CarriedFruit);*/
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
            if (verfolgen == null && !spotted && (ant.CurrentLoad > MaximumLoad / 5 || ant.CarriedFruit != null) && ant.DistanceToTarget < ant.Range / 2)
            {
                Think("verfolge...");
                lastv = time;
                verfolgen = ant;
            }
            double xm, ym, distance;
            getcordsa(DistanceToAnthill, Coordinate.GetDegreesBetween(this, hill), out xm, out ym);
            getdistance(xm, ym, basex, basey, out distance);
            if (((Caste == "fighter2") || Caste == "stand" && DistanceToAnthill < 300) && (!IsTired || spotted) && verfolgen != ant && (distance < 50 || !spotted)/* && ant.MaximumSpeed < MaximumSpeed && ant.CurrentEnergy <= CurrentEnergy && ant.AttackStrength <= Strength*/)
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
            else if (Coordinate.GetDistanceBetween(this, ant) < 5 && CarryingFruit == null && ant.AttackStrength > 20 && Caste == "sugar") GoAwayFrom(ant, 10);
        }

        /// <summary>
        /// Just as ants can see various types of food, they can also visually detect 
        /// other game elements. This method is called if the ant sees a bug.
        /// Read more: "http://wiki.antme.net/en/API1:SpotsEnemy(Bug)"
        /// </summary>
        /// <param name="bug">spotted bug</param>
        public override void SpotsEnemy(Bug bug)
        {
            if(Caste == "sugar" && Coordinate.GetDistanceBetween(this, bug) < 10)
            {
                GoAwayFrom(bug, 10);
                return;
            }
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
            if ((Caste == "fighter" || Caste == "fighter2" || Caste == "stand") && ant != verfolgen)
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
                    GoAwayFrom(bug, 5);
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
                x = Math.Cos(angleb) * distance;
                y = (-1) * Math.Sin(angleb) * distance;
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
                x = Math.Cos(angleb) * distance;
                y = (-1) * Math.Sin(angleb) * distance;
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
                x = Math.Cos(angleb) * distance;
                y = (-1) * Math.Sin(angleb) * distance;
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
                x = -Math.Cos(angleb) * distance;
                y = Math.Sin(angleb) * distance;
            }
            else if (anglet > 270 && anglet < 360)
            {
                angleb = anglec - 270 * (Math.PI / 180);
                x = -Math.Sin(angleb) * distance;
                y = (-1) * Math.Cos(angleb) * distance;
            }
            else if (anglet > 180 && anglet < 270)
            {
                angleb = anglec - 180 * (Math.PI / 180);
                x = Math.Cos(angleb) * distance;
                y = (-1) * Math.Sin(angleb) * distance;
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
                x = -distance;
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
            double dx = x1 - x2;
            double dy = y1 - y2;
            distance = Math.Sqrt(dx * dx + dy * dy);
        }

        public static void getcoordsenemytarget(Ant ant, out int x, out int y)
        {
            double distancee, directione, distancem, directionm, xa, ya, xea, yea;
            distancee = ant.DistanceToTarget;
            directione = ant.DegreesToTarget + ant.Direction;
            if (directione < 180) directione += 180;
            else if (directione >= 180) directione -= 180;
            if (directione >= 360) directione -= 360;
            distancem = Coordinate.GetDistanceBetween(ant, hill);
            directionm = Coordinate.GetDegreesBetween(ant, hill);
            getcordsa(distancem, directionm, out xa, out ya);
            getcordsa(distancee, directione, out xea, out yea);
            x = -Convert.ToInt32(xea + xa);
            y = Convert.ToInt32(yea + ya);
        }
        #endregion
    }
}


