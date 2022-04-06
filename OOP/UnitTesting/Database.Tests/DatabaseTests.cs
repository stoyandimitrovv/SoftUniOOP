namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new[] {1})]
        [TestCase(new[] { 1, 10, 20, 1000 })]
        [TestCase(new[] { int.MaxValue, int.MinValue, 5 })]
        [TestCase(new int[0])]
        public void Constructor_WithValidData_ShouldPass(int[] parameters)
        {
            Database database = new Database(parameters);

            Assert.AreEqual(database.Count, parameters.Length);           
        }

        [Test]
        public void Array_Capacity_Exceeded_Throws_Ex()
        {
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(()
               => database.Add(1),
               "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new[] { 1, 2}, new[] { 10, 15}, 4)]
        public void Add_WithhValidData_SHouldPass(
            int[] ctorParams,
            int[] paramsToAdd,
            int expectedCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }
            
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new[] { 1, 2, 3, }, new[] { 10, 15, 16, 17, 18 }, 3, 5)]
        public void Remove_WithValidData_ShouldPass(
            int[] ctorParams,
            int[] paramsToAdd,
            int removeCount,
            int expectedCount)
        {
            Database database = new Database(ctorParams);

            foreach (var item in paramsToAdd)
            {
                database.Add(item);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void Remove_From_Empty_Throws_Ex()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(()
                => database.Remove(),
                "The collection is empty!");
        }

        [Test]
        public void Fetch_Should_Return_Array()
        {
            Database database = new Database();

            database.Add(1);

            database.Add(2);

            int[] result = database.Fetch();

            Assert.IsInstanceOf<Array>(result);
        }
    }
}
