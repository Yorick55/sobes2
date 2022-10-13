using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sobes2
{
    enum CarType { passenger, track, sport };
    class Cars
    {
        protected CarType typical;
        protected double averageGasConsuption;
        protected double tankSize;
        protected double speed;
        protected double decreaseKilometersInPercent;
        public Cars()
        {
            decreaseKilometersInPercent = 1;
        }
        public void showInfo ()
        {
            Console.WriteLine("Car type= " + typical);
            Console.WriteLine("Average gas consuption = " + averageGasConsuption);
            Console.WriteLine("Tank size= " + tankSize);
            Console.WriteLine("Speed= " + speed);
            Console.WriteLine("Can ride in km= " + kilometersEstimatedWithLoad());
        }
        public double kilometersEstimated(double amountOfGasNow)
        {
            return 100/averageGasConsuption*amountOfGasNow;
        }
        public double kilometersEstimated()
        {
            return 100/averageGasConsuption * tankSize;
        }
        public double howFastWillGo(double length)
        {
            return  length/speed;
        }
        public double kilometersEstimatedWithLoad()
        {
            return kilometersEstimated() * decreaseKilometersInPercent;
        }
        public double kilometersEstimatedWithLoad(double amountOfGasNow)
        {
            return kilometersEstimated(amountOfGasNow) * decreaseKilometersInPercent;
        }


    }

    class PassengerCar: Cars
    {
        protected int passengersAmount;
        protected int maxAmountOfPassengers;
        public PassengerCar(int maxAmountOfPassengers, double averageGasConsuption, double tankSize, double speed)
        {
            this.typical = CarType.passenger;
            this.maxAmountOfPassengers = maxAmountOfPassengers;
            this.averageGasConsuption = averageGasConsuption;
            this.tankSize=tankSize;
            this.speed=speed;
        }
        public void addPassengers(int passengersAmount)
        {
            try
            {
                if (maxAmountOfPassengers < passengersAmount)
                    throw new Exception();
                this.passengersAmount = passengersAmount;
                for (int i=0; i<passengersAmount; i++)
                    decreaseKilometersInPercent=decreaseKilometersInPercent*0.01*(100-6);
                Console.WriteLine("Added passengers= " + passengersAmount);
            }
            catch (Exception)
            {
                Console.WriteLine("Too many passengers");
            }
        }
    }

    class TrackCar : Cars
    {
        protected int maxLoad;
        protected int loadAmount;
        public TrackCar(int maxLoad, double averageGasConsuption, double tankSize, double speed)
        {
            this.typical = CarType.track;
            this.maxLoad = maxLoad;
            this.averageGasConsuption = averageGasConsuption;
            this.tankSize = tankSize;
            this.speed = speed;
        }
        public void addLoad(int loadAmount)
        {
            try
            {
                if (maxLoad < loadAmount)
                    throw new Exception();
                this.loadAmount = loadAmount;
                for (int i = 0; i < loadAmount/200; i++)
                    decreaseKilometersInPercent = decreaseKilometersInPercent * 0.01*(100-4);
                Console.WriteLine("Added in kg= " + loadAmount);
            }
            catch (Exception)
            {
                Console.WriteLine("Too much load");
            }
        }
    }

    class SportCar : Cars
    {
        public SportCar(double averageGasConsuption, double tankSize, double speed)
        {
            this.typical = CarType.sport;
            this.averageGasConsuption = averageGasConsuption;
            this.tankSize = tankSize;
            this.speed = speed;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SportCar sportCr = new SportCar(15, 60, 200);
            sportCr.showInfo();
            Console.WriteLine();

            double tank = 30;
            double lenghtOfRide = 300;
            PassengerCar passengerCr = new PassengerCar(5, 10, 90, 100);
            passengerCr.showInfo();
            Console.WriteLine("How fast in hours will go= "+passengerCr.howFastWillGo(lenghtOfRide));
            Console.WriteLine("Can ride with current tank fillment= " +passengerCr.kilometersEstimated(tank));
            Console.WriteLine("Can ride with current tank fillment and passengers= " + passengerCr.kilometersEstimatedWithLoad(tank));
            passengerCr.addPassengers(3);
            Console.WriteLine("Can ride with current tank fillment and passengers= " + passengerCr.kilometersEstimatedWithLoad(tank));
            Console.WriteLine();

            tank = 30;
            lenghtOfRide = 100;
            TrackCar trackCr = new TrackCar(10000, 30, 100, 90);
            trackCr.showInfo();
            Console.WriteLine("How fast in hours will go= " + trackCr.howFastWillGo(lenghtOfRide));
            Console.WriteLine("Can ride with current tank fillment= " + trackCr.kilometersEstimated(tank));
            Console.WriteLine("Can ride with current tank fillment and load= " + trackCr.kilometersEstimatedWithLoad(tank));
            trackCr.addLoad(8000);
            Console.WriteLine("Can ride with current tank fillment and load= " + trackCr.kilometersEstimatedWithLoad(tank));
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
