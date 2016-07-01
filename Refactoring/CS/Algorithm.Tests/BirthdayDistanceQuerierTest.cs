using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Tests
{    
    public class BirthdayDistanceQuerierTest
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new BirthdayDistanceQuerier(list);

            var result = finder.Find(BirthdayDistanceComparer.Closest);

            Assert.Null(result.Youngest);
            Assert.Null(result.Oldest);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new BirthdayDistanceQuerier(list);

            var result = finder.Find(BirthdayDistanceComparer.Closest);

            Assert.Null(result.Youngest);
            Assert.Null(result.Oldest);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new BirthdayDistanceQuerier(list);

            var result = finder.Find(BirthdayDistanceComparer.Closest);

            Assert.Same(sue, result.Youngest);
            Assert.Same(greg, result.Oldest);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new BirthdayDistanceQuerier(list);

            var result = finder.Find(BirthdayDistanceComparer.Farthest);

            Assert.Same(greg, result.Youngest);
            Assert.Same(mike, result.Oldest);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new BirthdayDistanceQuerier(list);

            var result = finder.Find(BirthdayDistanceComparer.Farthest);

            Assert.Same(sue, result.Youngest);
            Assert.Same(sarah, result.Oldest);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new BirthdayDistanceQuerier(list);

            var result = finder.Find(BirthdayDistanceComparer.Closest);

            Assert.Same(sue, result.Youngest);
            Assert.Same(greg, result.Oldest);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}