using Population_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Population_Simulator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // NOTE: change defaults to get a correct answer :)
            Settings.Delay = 5;
            Settings.StartingPopulationAge = Settings.MinChildBearingAge - Settings.Delay;

            Header.Content = $"Year\t\tTotal\t\tMilitary\tChild Bearing Age{ Environment.NewLine }";

            var persons = CreatePersons(Settings.StartingPopulation, Settings.StartingPopulationAge);

            var year = Settings.StartYear;
            while (year < Settings.StartYear + Settings.Delay)
            {
                Print(year, persons);
                year++;
                persons = persons.Select(x => new Person { Age = x.Age + 1 }).ToList();
            }

            DisplayText.Text += $"---   END OF DELAY   ---{ Environment.NewLine }";

            while (year < Settings.EndYear)
            {
                Print(year, persons);
                year++;
                persons = AddYear(persons);
            }
            Print(year, persons);
        }

        private List<Person> AddYear(List<Person> persons)
        {
            var noOfPossibleParents = NoOfChildBearingAge(persons);

            var noOfChildren = Convert.ToInt32(noOfPossibleParents / Settings.ChildFrequency * Settings.Multiplier);
            var children = CreatePersons(noOfChildren);

            var livingPersons = persons.Where(x => x.Age <= Settings.AgeOfDeath).Select(x => new Person { Age = x.Age + 1 });
            return livingPersons.Concat(children).ToList();
        }

        private List<Person> CreatePersons(int number, int age = 0) => Enumerable.Range(0, number).Select(_ => new Person { Age = age }).ToList();

        private int NoOfChildBearingAge(List<Person> persons) => persons.Count(x =>
                x.Age >= Settings.MinChildBearingAge &&
                x.Age <= Settings.MaxChildBearingAge);

        private void Print(int year, List<Person> persons)
        {
            var noOfPersons = persons.Count;
            var noOfMilitary = persons.Count(x => x.Age >= Settings.MinMilitaryAge && x.Age <= Settings.MaxMilitaryAge);
            var noOfPossibleParents = NoOfChildBearingAge(persons);

            DisplayText.Text += $"{ year }{ StringWithTabs(noOfPersons) }{ StringWithTabs(noOfMilitary) }{ StringWithTabs(noOfPossibleParents) }{ Environment.NewLine }";
        }

        private string StringWithTabs(int value) =>
            value switch
            {
                0 => $"\t\t{ value }",
                var x when x < 10.000 => $"\t\t\t{ value }",
                _ => $"\t\t{ value }"
            };
    }
}
