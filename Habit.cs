using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabitLogger
{
    public class Habit
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        
        public DateTime Date { get; set; }
        public int NumberOfHours { get; set; } = 0;
    }
}