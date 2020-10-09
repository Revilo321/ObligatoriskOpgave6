using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatoriskOpgave6
{
    public class FanOutPut
    {
        private string _name;
        private int _temp;
        private int _fugt;
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                CheckId(value);
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                CheckName(value);
                _name = value;
            }

        }

        public int Temp
        {
            get { return _temp; }
            set
            {
                CheckTemp(value);
                _temp = value;
            }
        }

        public int Fugt
        {
            get { return _fugt; }
            set
            {
                CheckFugt(value);
                _fugt = value;
            }
        }


        public FanOutPut(int id, string name, int temp, int fugt)
        {
            Id = id;
            Name = name;
            Temp = temp;
            Fugt = fugt;
            CheckTemp(temp);
            CheckFugt(fugt);
            CheckName(name);
            CheckId(id);
        }






        public static void CheckTemp(int temp)
        {
            if (temp < 15 || temp > 25)
            {
                throw new Exception("Temperatur skal være mellem 15 og 25!");
            }
        }


        public static void CheckFugt(int fugt)
        {
            if (fugt < 30 || fugt > 80)
            {
                throw new Exception("Fugt skal være mellem 30 og 80!");
            }
        }



        public static void CheckName(string name)
        {
            if (name.Length < 2)
            {
                throw new ArgumentException("Name skal være længere end to karakterer!");
            }

        }

        public static void CheckId(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id kan ikke være 0");
            }
        }





    }
}

