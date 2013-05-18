using System;


class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());        
        int[] Cats = new int[11];
        int mostvotes = 0,
            temp2 = 0,
            temp1 = 0,
            temp = 0;

        int input = 0;
        for (int i = 1; i <= n; i++)
        {
            input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:                    
                    Cats[1]++;
                    break;
                case 2:                    
                    Cats[2]++;
                    break;
                case 3:
                    Cats[3]++;
                    break;
                case 4:
                    Cats[4]++;
                    break;
                case 5:
                    Cats[5]++;
                    break;
                case 6:
                    Cats[6]++;
                    break;
                case 7:
                    Cats[7]++;
                    break;
                case 8:
                    Cats[8]++;
                    break;
                case 9:
                    Cats[9]++;
                    break;
                case 10:
                    Cats[10]++;
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
        for (int i = 0; i < Cats.Length; i++)
        {
            
            if (Cats[i] > mostvotes)
            {
                mostvotes = Cats[i];
                temp1 = i;
            }
            
        }

        if(mostvotes == Cats[0] || mostvotes == Cats[1] || mostvotes == Cats[2] || mostvotes == Cats[3] || 
            mostvotes == Cats[4] || mostvotes == Cats[5] || mostvotes == Cats[6] || mostvotes == Cats[7] || 
            mostvotes == Cats[8] || mostvotes == Cats[9] || mostvotes == Cats[10])
        {
            temp2 = Array.IndexOf(Cats, mostvotes);
            temp = Math.Min(temp2, temp1);
        }
        
        Console.WriteLine(temp);
        

    }
}

