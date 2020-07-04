namespace Population_Simulator.Models
{
    public class Settings
    {
        public static int StartYear { get; set; } = -1728;          // the Israelites actually lived in Egypt 215 years (1728-1513 B.C.E.)
        public static int EndYear { get; set; } = -1513;            // the Israelites actually lived in Egypt 215 years (1728-1513 B.C.E.)
        public static int Delay { get; set; } = 25;                 // not beginning to father children until 25 years after their entry into Egypt
        public static int StartingPopulation { get; set; } = 50;    // the original 50 who became family heads
        public static int StartingPopulationAge { get; set; } = 0; // TODO: find a good default
        public static int MinChildBearingAge { get; set; } = 20;    // during the period of life between 20 and 40 years of age
        public static int MaxChildBearingAge { get; set; } = 40;    // during the period of life between 20 and 40 years of age 
        public static int MaxNoOfChildren { get; set; } = 5;        // ten children (about half being boys)
        public static double Multiplier { get; set; } = 0.80;       // reduce by 20 percent the number of males born who became fathers
        public static int MinMilitaryAge { get; set; } = 20;        // men of military age, between 20 and 50 years old
        public static int MaxMilitaryAge { get; set; } = 50;        // men of military age, between 20 and 50 years old
        public static int AgeOfDeath { get; set; } = 120;           // Joseph 110; Moses 120

        public static double ChildFrequency => (MaxChildBearingAge - MinChildBearingAge) / MaxNoOfChildren;
    }
}
