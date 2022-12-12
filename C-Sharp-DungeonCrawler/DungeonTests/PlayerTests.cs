using Xunit;
using DungeonClassLibrary;

namespace DungeonTests
{
    public class PlayerTests
    {
        [Fact]
        public void TestHealth()
        {
            //arrange
            Player testPlayer = new Player("Johny Test", new byte[] { 10, 10, 10, 10, 10, 10 }, Races.Dwarf, Proffessions.Fighter);
            int expectedHealth = 11;

            //Assert
            Assert.Equal(expectedHealth, testPlayer.MaxHealth);
        }


        [Fact]
        public void TestAc()
        {
            Player testPlayer = new Player("Johny Test", new byte[] { 10, 10, 10, 10, 10, 10 }, Races.Dwarf, Proffessions.Fighter);
            int expectedAc = 13;

            Assert.Equal(expectedAc, testPlayer.ArmorClass);
        }

        [Fact]
        public void TestLevelUp()
        {
            //arrange
            Player testPlayer = new Player("Johny Test", new byte[] { 10, 10, 10, 10, 10, 10 }, Races.Dwarf, Proffessions.Fighter);
            testPlayer.Experience += 48000;
            int expectedHealth = 99;
            //act
            while (testPlayer.HasLevelUp())
            {
                //empty loop to iterate until all xp is used
            }
            //assert
            Assert.Equal(expectedHealth, testPlayer.MaxHealth);


        }

        [Fact]
        public void TestAlive()
        {
            Player testPlayer = new Player("Johny Test", new byte[] { 10, 10, 10, 10, 10, 10 }, Races.Dwarf, Proffessions.Fighter);
            int expectedAttacks = 11;
            int actualAttacks = 0;
            while (testPlayer.IsAlive())
            {
                testPlayer.CurrentHealth--;
                actualAttacks++;
            }
            Assert.Equal(expectedAttacks, actualAttacks);
        }
    }
}