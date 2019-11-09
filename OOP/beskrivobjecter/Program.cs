using System;

namespace beskrivobjecter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Goal
    {
        public double width;
        public double height;
        public double depth;
        public int color;
        public int scoredGoals;
        public string goalKeeper;
        public string location;
        //Initialize object with variables
        public Goal(double width, double height, double depth, int color, string goalKeeper, string location)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
            this.color = color;
            this.goalKeeper = goalKeeper;
            this.location = location;
        }

        //Add a goal to scoregoals when a user scores
        public int scoreGoal()
        {
            scoredGoals++;
            return scoredGoals;
        }

        //Assign a new keeper to the goal (Could later be a goalkeeper objects)
        public void switchKeeper(string newKepper)
        {
            goalKeeper = newKepper;
        }

        //Han in goal, which sadly ruins the goal and makes it collapse a little.
        public double hangInGoal()
        {
            height -= 4.65;
            return height;
        }
        public void colorGoal(int newColor)
        {
            color = newColor;
        }
        public string moveGoal(string newLocation)
        {
            location = newLocation;
            return "The goal has been moved to " + location;
        }
    }




    class Car
    {
        public string manufactor;
        public int doorCount;
        public double rangePerLiter;
        public int color;
        public string currentLocation;
        //Private da vi kun ville kunne ændre den her via vores funktioner.
        private double fuelLeft;
        private double blinkerFluidLeft; //Pranked

        public double checkFuel()
        {
            return fuelLeft;
        }
        public double addFuel(double fuelAmount)
        {
            fuelLeft += fuelAmount;
            return fuelLeft;
        }
        public string driveTo(string destination, int driveLength)
        {
            string oldDest = currentLocation;
            currentLocation = destination;
            fuelLeft -= driveLength / rangePerLiter;

            return "You drove to " + destination + " from " + oldDest + ". You now have " + fuelLeft + " fuel left.";
        }

        public double wipeWindow()
        {
            blinkerFluidLeft -= 10;
            return blinkerFluidLeft;
        }
        public void fillBlinkerFluid(double fluidAdd)
        {
            blinkerFluidLeft += fluidAdd;
        }
    }

    class Soda
    {
        public string brand;
        public int capacityInMl;
        public int color;
        public string contents;
        public int mlLeft;
        public int price;
        public bool bought;

        public Soda(string brand, int capacityInMl, int color, string contents, int mlLeft, int price)
        {
            this.brand = brand;
            this.capacityInMl = capacityInMl;
            this.color = color;
            this.contents = contents;
            this.mlLeft = mlLeft;
            this.price = price;
            this.bought = false;
        }

        public string refillInSink()
        {
            if(mlLeft > 50)
            {
                return "You still have quite a bit of drink left, you don't wonna ruin that with water...";
            }
            else
            {
                contents = "water";
                mlLeft = capacityInMl;
                return "You now have " + mlLeft + "ml of " + contents;
            }
        }
        public void buySoda() {
            bought = true;
        }
        public string drink(int amountDrank)
        {
            if(mlLeft > amountDrank)
            {
                mlLeft -= amountDrank;
            }
            else if(mlLeft > 0)
            {
                amountDrank -= mlLeft;
                mlLeft = 0;
            }
            else
            {
                return "Your soda is empty";
            }
            
            return "You drank " + amountDrank + " and there now is " + mlLeft + "ml left.";
        }
        public string spillSoda()
        {
            mlLeft = 0;
            return "Well that was stupid, no more soda left now";
        }
        public string shakeSoda()
        {
            mlLeft -= new Random().Next(20);

            return "Well big stupido, you opened it after and now only have " + mlLeft + "ml left";
        }
    }
}
