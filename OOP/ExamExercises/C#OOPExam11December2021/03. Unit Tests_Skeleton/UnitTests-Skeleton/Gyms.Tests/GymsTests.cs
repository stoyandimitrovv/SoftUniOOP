using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        //AthleteCreation
        [Test]
        public void Test_Athlete_Creation()
        {
            Athlete athlete = new Athlete("Peshkata");

            Assert.AreEqual("Peshkata", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        //GymCreation
        [Test]
        public void Test_Gym_Creation()
        {
            Gym gym = new Gym("Qki sme", 15);

            Assert.AreEqual("Qki sme", gym.Name);
            Assert.AreEqual(15, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        //GymCreation
        [Test]
        public void Test_Gym_Creation_Throws_With_Null_Name()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null , 15);
            });
        }

        //GymCreation
        [Test]
        public void Test_Gym_Creation_Throws_With_Empty_Name()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym("", 15);
            });
        }

        //GymCreation
        [Test]
        public void Test_Gym_Creation_Throws_With_Negative_Capacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Gym", -1);
            });
        }

        //AddAthlete
        [Test]
        public void Test_Gym_Add_Athlete_Works()
        {
            Gym gym = new Gym("Qki sme", 3);

            var athlete = new Athlete("Pesho Pikoto");
            var athlete2 = new Athlete("Anatoli");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(2, gym.Count);
        }

        //AddAthlete
        [Test]
        public void Test_Gym_Add_Athlete_With_Full_Capacity_Throws()
        {
            Gym gym = new Gym("Qki sme", 1);

            var athlete = new Athlete("Pesho Pikoto");
            var athlete2 = new Athlete("Anatoli");
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);
            });
        }

        //RemoveAthlete
        [Test]
        public void Test_Gym_Remove_Athlete_Works()
        {
            Gym gym = new Gym("Qki sme", 3);

            var athlete = new Athlete("Pesho Pikoto");
            var athlete2 = new Athlete("Anatoli");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.RemoveAthlete(athlete.FullName);

            Assert.AreEqual(1, gym.Count);
        }

        //RemoveAthlete
        [Test]
        public void Test_Gym_Remove_Athlete_Throws()
        {
            Gym gym = new Gym("Qki sme", 3);

            var athlete = new Athlete("Pesho Pikoto");
            var athlete2 = new Athlete("Anatoli");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Nqma me");
            });
        }

        //InjuredAthlete
        [Test]
        public void Test_Gym_Injured_Athlete_Works()
        {
            Gym gym = new Gym("Qki sme", 3);

            var athlete = new Athlete("Pesho Pikoto");
            var athlete2 = new Athlete("Anatoli");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            var returnedAthlete = gym.InjureAthlete(athlete.FullName);

            Assert.AreEqual(true, athlete.IsInjured);
            Assert.AreEqual(athlete, returnedAthlete);
        }

        //InjuredAthlete
        [Test]
        public void Test_Gym_Injured_Athlete_Trows()
        {
            Gym gym = new Gym("Qki sme", 3);

            var athlete = new Athlete("Pesho Pikoto");
            var athlete2 = new Athlete("Anatoli");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Nqma me");
            });
        }

        //Report
        [Test]
        public void Test_Gym_Report_Works()
        {
            Gym gym = new Gym("Qki sme", 3);

            var athlete = new Athlete("Pesho Pikoto");
            var athlete2 = new Athlete("Anatoli");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            var returnedAthlete = gym.InjureAthlete(athlete.FullName);

            var reprot = gym.Report();

            Assert.AreEqual("Active athletes at Qki sme: Anatoli", gym.Report());
        }

        //Report
        [Test]
        public void Test_Gym_Report_With_Empty_Works()
        {
            Gym gym = new Gym("Qki sme", 3);

            var reprot = gym.Report();

            Assert.AreEqual("Active athletes at Qki sme: ", gym.Report());
        }
    }
}
