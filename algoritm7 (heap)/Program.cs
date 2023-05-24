class Program
{
    static void Main(string[] args)
    {
        List<GnomeTreasure> gnomeTreasures = GetGnomeTreasures();
        HeapSort(gnomeTreasures);
        Console.WriteLine("HEAP SORT");
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
            new GnomeTreasure { Family = 1, Treasure = 7 },
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

    static void HeapSort(List<GnomeTreasure> list)
    {
        int n = list.Count;

        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(list, n, i);
        }

        for (int i = n - 1; i > 0; i--)
        {
            Swap(list, 0, i);
            Heapify(list, i, 0);
        }
    }

    static void Heapify(List<GnomeTreasure> list, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && CompareTreasure(list[left], list[largest]) > 0)
        {
            largest = left;
        }

        if (right < n && CompareTreasure(list[right], list[largest]) > 0)
        {
            largest = right;
        }

        if (largest != i)
        {
            Swap(list, i, largest);
            Heapify(list, n, largest);
        }
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


