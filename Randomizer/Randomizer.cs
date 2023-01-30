using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialRandomizer
{
    public class Randomizer
    {
        private readonly int start;
        private readonly int count;
        private int[] pull;
        private Queue<int> history;
        private readonly Random random;

        public int[] Pull => pull.Clone() as int[];
        public int[] History => history.ToArray().Clone() as int[];

        public Randomizer(): this(0, 7)
        {
        }
        
        public Randomizer(int start, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("count argument should be more then zero");
            }

            this.start = start;
            this.count = count;
            random = new Random();
            
            PreparePull();
            PrepareHistory();
        }

        public int GetNext()
        {
            int index = GetRandomIndexOfItemNotInHistory();   
            int item = pull[index];      
            history.Enqueue(item);
            pull[index] = history.Dequeue();

            return item;
        }

        private int GetRandomIndexOfItemNotInHistory()
        {
            int attempts = 6;
            int count = 0;
            int index;

            do
            {
                index = random.Next(0, pull.Length);                
                if (!history.Contains(pull[index]))
                {
                    break;
                }
                count++;
            } while(count < attempts);

            return index;
        }

        private void PreparePull()
        {
            int repitEmaunt = count * 5 / 7;
            pull = Enumerable.Range(start, count)
                        .SelectMany(i => Enumerable.Repeat(i, repitEmaunt))
                        .ToArray();
        }

        private void PrepareHistory()
        {
            int historyLength = count * 4 / 7;
            history = new Queue<int>(
                Enumerable.Range(0, historyLength)
                          .Select(i => random.Next(start, count))
            );
        }
    }
}
