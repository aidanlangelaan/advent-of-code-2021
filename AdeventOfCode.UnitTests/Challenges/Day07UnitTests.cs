﻿using AdventOfCode.Challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdeventOfCode.UnitTests.Challenges
{
    [TestClass]
    public class Day07UnitTests
    {
        private Day07 day07;

        [TestInitialize]
        public void SetupTests()
        {
            var testInput = new[] { "" };
            day07 = new Day07(testInput);
        }

        //[TestMethod]
        //public void Example_Part1_ShouldReturn5934()
        //{
        //    // act
        //    var result = day07.SolvePart1();

        //    // assert
        //    Assert.AreEqual(5934, result);
        //}

        //[TestMethod]
        //public void Example_Part2_ShouldReturn26984457539()
        //{
        //    // act
        //    var result = day07.SolvePart2();

        //    // assert
        //    Assert.AreEqual(26984457539, result);
        //}
    }
}
