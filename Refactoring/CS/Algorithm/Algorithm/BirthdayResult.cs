using System;

namespace Algorithm
{
    public class BirthdayResult
    {
        public BirthdayResult(Person mary, Person joe)
        {
            if (mary.BirthDate < joe.BirthDate)
            {
                Youngest = mary;
                Oldest = joe;
            }
            else
            {
                Youngest = joe;
                Oldest = mary;
            }

            AgeDifference = Oldest.BirthDate - Youngest.BirthDate;
        }

        public BirthdayResult() { }

        public Person Youngest { get; set; }
        public Person Oldest { get; set; }
        public TimeSpan AgeDifference { get; set; }
    }
}