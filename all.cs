using System; 
class Program
{
    static void output_mass( int[][] mass)
    {
        for (int i = 0; i < mass.Length; i++)
        {
            for (int j = 0; j < mass[i].Length; j++)
            {
                Console.Write($"{mass[i][j]}\t");
            }
            Console.WriteLine();

        }
    }
    static void input_array(ref int[][] mass, int n)
    {
        int [][] mass1 = new int [n][];

        int amm;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите количество столбцов в строке {i+1}");
            amm = int.Parse(Console.ReadLine());
            mass1[i] = new int[amm];
            for (int j = 0; j < amm; j++){
                Console.Write($"Введите {j+1}-ый элемент {i+1}-ого столбца ");
                mass1[i][j] = int.Parse(Console.ReadLine());
            }
        }
        mass = mass1;

    }
    static int[] array_of_frst(int [][] mass)
    {
        int[] res = new int[mass.Length];
        int k = 0;
        for (int i = 0; i < mass.Length; i++)
        {
            for (int j = 0; j < mass[i].Length; j++)
            {
                if (mass[i][j] % 2 == 0)
                {
                    res[k] = mass[i][j];
                    k++;
                    break;
                }
            }
        }
        return res;
    }
    static void del_zer(int [][] mass)
    {
        int zer_am = 0;
        for (int i = 0; i < mass.Length; i++)
        {
            for (int j = 0; j < mass[i].Length; j++)
            {
                if (mass[i][j] == 0) zer_am++;
                if (zer_am > (mass[i].Length / 2)) mass[i] = new int [0];
            }
            zer_am = 0;
        }
        output_mass(mass);
    }
    static void move_str(int [][] mass, int n, int n1)
    {
        int k = n1;
        output_mass(mass);
        Console.WriteLine("____________");
        for (int i = 0; i < mass.Length; i++)
        {
            for (int j = 0; j < mass[i].Length; j++)
            {
                if (i == n)
                {
                    int temp;
                    while (k > 0)
                    {
                        temp = mass[i][0];
                        for (int i1 = 1; i1 < mass[i].Length; i1++)
                        {
                            mass[i][i1 - 1] = mass[i][i1];
                        }
                        mass[i][mass[i].Length - 1] = temp;
                        k--;
                        output_mass(mass);
                        Console.WriteLine("____________");
                    }
                }
            }
        }
    }
    public static void Main()
    {
        Console.WriteLine("Введите количество строк");
        int n2 = Convert.ToInt32(Console.ReadLine());
        int[][] mass = new int [n2][];
        input_array(ref mass, n2);
        Console.WriteLine("Введите строку которую будем двигать");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите сколько раз надо подвинуть список");
        int n1 = int.Parse(Console.ReadLine());
        move_str(mass, n, n1);
        Console.WriteLine("Список первых четных элементов");
        for (int i = 0; i < array_of_frst(mass).Length; i++)
        {
            Console.Write($"{array_of_frst(mass)[i]} ");
        }
        Console.WriteLine();
        Console.WriteLine("Список без строк с нулями");
        del_zer(mass);
    }
}
