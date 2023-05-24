class Program
{
    static void Main(string[] args)
    {
        List<GnomeTreasure> gnomeTreasures = GetGnomeTreasures();

        MergeSort(gnomeTreasures, 0, gnomeTreasures.Count - 1);
        Console.WriteLine("MERGING METHOD");
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
            new GnomeTreasure { Family = 1, Treasure = 50 },
            new GnomeTreasure { Family = 2, Treasure = 4 },
            new GnomeTreasure { Family = 3, Treasure = 8 },
            new GnomeTreasure { Family = 49, Treasure = 8 },
            new GnomeTreasure { Family = 5, Treasure = 6 },
            new GnomeTreasure { Family = 1, Treasure = 2 },
            new GnomeTreasure { Family = 2, Treasure =-95},
            new GnomeTreasure { Family = 3, Treasure = 7 },
            new GnomeTreasure { Family = 4, Treasure = 4 },
            new GnomeTreasure { Family = 5, Treasure = 9 },
            new GnomeTreasure { Family = 1, Treasure = 300 },
            new GnomeTreasure { Family = 2, Treasure = 6 },
            new GnomeTreasure { Family = 3, Treasure = 2 },
            new GnomeTreasure { Family = 4, Treasure = -95 },
            new GnomeTreasure { Family = 5, Treasure = 7 }
        };

        return gnomeTreasures;
    }

    static void MergeSort(List<GnomeTreasure> list, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            MergeSort(list, left, middle);
            MergeSort(list, middle + 1, right);

            Merge(list, left, middle, right);
        }
    }

    static void Merge(List<GnomeTreasure> list, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        List<GnomeTreasure> leftList = new List<GnomeTreasure>();
        List<GnomeTreasure> rightList = new List<GnomeTreasure>();

        for (int i = 0; i < n1; ++i)
            leftList.Add(list[left + i]);

        for (int j = 0; j < n2; ++j)
            rightList.Add(list[middle + 1 + j]);

        int x = 0, y = 0;
        int k = left;

        while (x < n1 && y < n2)
        {
            if (leftList[x].Family.CompareTo(rightList[y].Family) < 0 ||
                (leftList[x].Family.CompareTo(rightList[y].Family) == 0 && leftList[x].Treasure < rightList[y].Treasure))
            {
                list[k] = leftList[x];
                x++;
            }
            else
            {
                list[k] = rightList[y];
                y++;
            }
            k++;
        }

        while (x < n1)
        {
            list[k] = leftList[x];
            x++;
            k++;
        }

        while (y < n2)
        {
            list[k] = rightList[y];
            y++;
            k++;
        }
    }
}
