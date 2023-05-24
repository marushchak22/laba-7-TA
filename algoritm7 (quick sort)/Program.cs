class Program
{
    static void Main(string[] args)
    {
        List<GnomeTreasure> gnomeTreasures = GetGnomeTreasures();

        QuickSort(gnomeTreasures, 0, gnomeTreasures.Count - 1);

        Console.WriteLine("QUICK SORT");
        Console.WriteLine();

        foreach (var treasure in gnomeTreasures)
        {
            Console.WriteLine($"Родина: {treasure.Family}, Скарб: {treasure.Treasure}");
        }
    }
    class GnomeTreasure
    {
        public int Family { get; set; }
        public int Treasure { get; set; }
    }

    static List<GnomeTreasure> GetGnomeTreasures()
    {
        List<GnomeTreasure> gnomeTreasures = new List<GnomeTreasure>
        {
            new GnomeTreasure { Family = 7, Treasure = 9 },
            new GnomeTreasure { Family = 2, Treasure = -4 },
            new GnomeTreasure { Family = 3, Treasure = 9 },
            new GnomeTreasure { Family = 3, Treasure = 3 },
            new GnomeTreasure { Family = 5, Treasure = 6 },
            new GnomeTreasure { Family = 1, Treasure = 26 },
            new GnomeTreasure { Family = 2, Treasure = 5 },
            new GnomeTreasure { Family = 4, Treasure = 7 },
            new GnomeTreasure { Family = 2, Treasure = 4 },
            new GnomeTreasure { Family = 3, Treasure = 96 },
            new GnomeTreasure { Family = 4, Treasure = 3 },
            new GnomeTreasure { Family = 5, Treasure = 67 },
            new GnomeTreasure { Family = 1, Treasure = 2 },
            new GnomeTreasure { Family = 5, Treasure = -5 }
        };

        return gnomeTreasures;
    }

    static void QuickSort(List<GnomeTreasure> list, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(list, low, high);

            QuickSort(list, low, partitionIndex - 1);
            QuickSort(list, partitionIndex + 1, high);
        }
    }

    static int Partition(List<GnomeTreasure> list, int low, int high)
    {
        GnomeTreasure pivot = list[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (CompareTreasure(list[j], pivot) <= 0)
            {
                i++;
                Swap(list, i, j);
            }
        }

        Swap(list, i + 1, high);

        return i + 1;
    }

    static int CompareTreasure(GnomeTreasure treasure1, GnomeTreasure treasure2)
    {
        if (treasure1.Family.CompareTo(treasure2.Family) != 0)
        {
            return treasure1.Family.CompareTo(treasure2.Family);
        }
        else
        {
            return treasure1.Treasure.CompareTo(treasure2.Treasure);
        }
    }

    static void Swap(List<GnomeTreasure> list, int i, int j)
    {
        GnomeTreasure temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
