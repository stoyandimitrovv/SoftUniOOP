namespace DatabaseExtended.Tests
{
    using System;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(16)]
        public void Ctor_Add_Range_Up_To_16_People_To_Th_eDb(int peopleCount)
        {
            Person[] people = new Person[peopleCount];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            Database database = new Database(people);

            Assert.AreEqual(peopleCount, database.Count);
        }

        [Test]
        public void Ctor_AddRange_ArrayCapacity_Exceeded_ThrowsEx()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            Assert.Throws<ArgumentException>(() => new Database(people),
                "Provided data length should be in range [0..16]!");
        }

        [Test]
        [TestCase("Ivan")]
        public void Add_User_With_Same_Name_Throws_Ex(string name)
        {
            Database database = new Database();
            Person person1 = new Person(1, name);
            Person person2 = new Person(2, name);

            database.Add(person1);

            Assert.Throws<InvalidOperationException>(() => database.Add(person2),
                "There is already user with this username!");
        }

        [Test]
        [TestCase(1)]
        public void Add_User_With_Same_Id_Throws_Ex(int id)
        {
            Database database = new Database();
            Person person1 = new Person(id, "Ivan");
            Person person2 = new Person(id, "Stoyan");

            database.Add(person1);

            Assert.Throws<InvalidOperationException>(() => database.Add(person2),
                "There is already user with this Id!");
        }

        [Test]
        public void Add_More_Than_16_People_Throws_Ex()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            Database database = new Database(people);

            Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(17, "Name17")),
                "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Remove_Last_Added_Person()
        {
            Database database = new Database(new Person(1, "Ivan"));

            database.Remove();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void Remove_From_Empty_Array_Throws_Ex()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(()
                => database.Remove());
        }

        [Test]
        [TestCase("Ivan")]
        [TestCase("Petkan")]
        [TestCase("Dragan")]
        public void Find_By_User_Name(string name)
        {
            Database database = new Database(new Person(1, name));

            Assert.IsTrue(name == database.FindByUsername(name).UserName);
        }

        [Test]
        public void Find_By_User_Name_Empty_Name_Throws_Ex()
        {
            Assert.Throws<ArgumentNullException>(()=> new Database(new Person(1, "Ivan"))
                .FindByUsername(""),
                "Username parameter is null!");
        }

        [Test]
        public void Find_By_User_Name_Name_Not_Found_Throws_Ex()
        {
            Assert.Throws<InvalidOperationException>(()
                => new Database(new Person(1, "Ivan"))
                .FindByUsername("Pesho"),
                "No user is present by this username!");
        }

        [Test]
        [TestCase(12)]
        [TestCase(123123123)]
        [TestCase(1)]
        public void Find_By_Id_Returns_Person_With_Id(long id)
        {
            Database database = new Database(new Person(id, "Ivan"));

            Assert.IsTrue(id == database.FindById(id).Id);
        }

        [Test]
        public void Find_By_Id_Not_Found_Throws_Ex()
        {
            Assert.Throws<InvalidOperationException>(()
                => new Database(new Person(1, "Ivan"))
                .FindById(2),
                "No user is present by this ID!");
        }

        [Test]
        public void Find_By_Id_Negative_Id_Throws_Ex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => new Database(new Person(1, "Ivan"))
                .FindById(-1),
                "Id should be a positive number!");
        }
    }
}