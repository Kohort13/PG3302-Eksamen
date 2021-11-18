using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using NUnit.Framework;
using Wardrobe_Program;

namespace UnitTests
{
    public class UtilsTest
    {
        [SetUp]
        public void Setup() {

        }

        [Test]
        public void TestPickOne() {
            for (int i = 0; i < 100; i++) {
                Collection<string> strings = new() { "One", "Two" };
                var stringResult = Utils.PickOne(strings);
                Collection<int> ints = new() { 1, 2 };
                var intResult = Utils.PickOne(ints);

                Assert.That(strings, Has.Exactly(1).Matches<string>(s => s == stringResult));
                Assert.That(ints, Has.Exactly(1).Matches<int>(i => i == intResult));
            }
            
        }

        [Test]
        public void TestListToStringWithSeparator() {
            List<string> strings = new() { "One", "Two", "Three", "Four" };
            Assert.That(Utils.ListToStringWithSeparator(strings, ","), Is.EqualTo("One, Two, Three, Four"));
            Assert.That(Utils.ListToStringWithSeparator(strings, "Ø"), Is.EqualTo("OneØ TwoØ ThreeØ Four"));
        }
    }
}