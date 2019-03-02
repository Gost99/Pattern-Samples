using System;
using System.Collections.Generic;

namespace StudyPatterns
{
    #region Factory Method Data
    public abstract class CommandCreator
    {
        public abstract ITeam Create(string name);
    }

    public class FootballTeamCreator : CommandCreator
    {
        public override ITeam Create(string name)
        {
            return new FootballTeam() { Name = name };
        }
    }

    public class HockeyTeamCreator : CommandCreator
    {
        public override ITeam Create(string name)
        {
            return new HockeyTeam() { Name = name };
        }
    }

    public interface ITeam
    {
        string Name { get; set; }
    }

    public class FootballTeam : ITeam
    {
        public string Name { get; set; }
        
    }

    public class HockeyTeam : ITeam
    {
        public string Name { get; set; }
    }
    #endregion

    #region Test
    public class FactoryMethodTest
    {
        public static void MainProgram()
        {
            var testList = new List<ITeam>
            {
                new FootballTeamCreator().Create("Barcelona"),
                new HockeyTeamCreator().Create("Canada Warriors")
            };

            Console.WriteLine($"We have {testList.Count} teams: ");
            foreach (var c in testList)
            {
                Console.WriteLine($"{c.GetType().Name} - {c.Name}");
            }
        }
    }
    #endregion
}