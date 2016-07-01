using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class BirthdayDistanceQuerier
    {
        private readonly List<Person> _people;

        public BirthdayDistanceQuerier(List<Person> people)
        {
            _people = people;
        }

        public BirthdayResult Find(BirthdayDistanceComparer birthdayDistanceComparer)
        {
            var query = (
                from x in _people
                from y in _people
                where x != y
                select new BirthdayResult(x, y)
            ).OrderBy(x => x.AgeDifference);

            var result = BirthdayDistanceComparer.Closest == birthdayDistanceComparer
                ? query.FirstOrDefault()
                : query.LastOrDefault();

            return result ?? new BirthdayResult();
        }
    }
}