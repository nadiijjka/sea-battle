using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    //клас, що описує ігрове поле
    //реалізує шаблон "Одиночка"
    public class FieldModel
    {

        //об'єкт данного класу
        private static FieldModel mFieldModel = null;

        private FieldModel()
        {

        }

        //отримання екземпляру класу
        public static FieldModel getInstance()
        {

            if (mFieldModel != null)
            {
                return mFieldModel;
            }
            else
            {
                mFieldModel = new FieldModel();
                return mFieldModel;
            }
        }


        //поле для гравця
        int[,] StateCellPlayer = new int[10, 10];
        //поле для комп'ютера
        int[,] StateCellComputer = new int[10, 10];

        //отримання поля гравця
        public int[,] getStateCellPlayer()
        {
            return StateCellPlayer;
        }

        //отриманная поля комп'ютера
        public int[,] getStateCellComputer()
        {
            return StateCellComputer;
        }

        //встановлення кораблів випадковим чином
        public void SetShip()
        {
            
            StateCellPlayer = new int[10, 10];
            StateCellComputer = new int[10, 10];
            Random rand = new Random();

            //встановлення 4-х палубного
            SetShip4(rand, StateCellPlayer);

            //встановлення 3-х палубних
            SetShip3(rand, StateCellPlayer);
            SetShip3(rand, StateCellPlayer);


            //встановлення 2-х палубних
            SetShip2(rand, StateCellPlayer);
            SetShip2(rand, StateCellPlayer);
            SetShip2(rand, StateCellPlayer);


            //встановлення 1 палубних
            SetShip1(rand, StateCellPlayer);
            SetShip1(rand, StateCellPlayer);
            SetShip1(rand, StateCellPlayer);
            SetShip1(rand, StateCellPlayer);



            //так само і для комп'ютера
            SetShip4(rand, StateCellComputer);

            SetShip3(rand, StateCellComputer);
            SetShip3(rand, StateCellComputer);

            SetShip2(rand, StateCellComputer);
            SetShip2(rand, StateCellComputer);
            SetShip2(rand, StateCellComputer);

            SetShip1(rand, StateCellComputer);
            SetShip1(rand, StateCellComputer);
            SetShip1(rand, StateCellComputer);
            SetShip1(rand, StateCellComputer);

            k = 19;
            s = 9;
        }

        //всиановлення 4-х палубного корабля
        private void SetShip4(Random rand, int[,] StateCell) 
        {
            int posX, posY;
            //поворот 0, чи 1
            int direction = rand.Next(2);


            switch (direction)
            {
                //якщо не повертаємо
                case 0:
                    //то Х у межах від 0 до 6
                    posX = rand.Next(7);
                    //а ігрик довільний від 0 до 9
                    posY = rand.Next(10);
                    //тобто корабель розташовано вертикально

                    for (int i = 0; i < 4; i++)
                    {
                        StateCell[posX + i, posY] = 4;
                        for (int q = -1; q <= 1; q++)
                        {
                            for (int p = -1; p <= 1; p++)
                            {
                                if (posX + i + p >= 0 && posX + i + p <= 9 && posY + q >= 0 && posY + q <= 9)
                                {
                                    //встановлюємо навколо корабля 9 - це означає що не можна втановити інший корабель поруч (щоб доторкалися)
                                    if (StateCell[posX + i + p, posY + q] != 4)
                                        StateCell[posX + i + p, posY + q] = 9;
                                }
                            }
                        }
                    }

                    break;

                    //горизонтальне розміщення по тому самому принципу
                case 1:
                    posX = rand.Next(10);
                    posY = rand.Next(7);

                    for (int i = 0; i < 4; i++)
                    {
                        StateCell[posX, posY + i] = 4;
                        for (int q = -1; q <= 1; q++)
                        {
                            for (int p = -1; p <= 1; p++)
                            {
                                if (posX + p >= 0 && posX + p <= 9 && posY + i + q >= 0 && posY + i + q <= 9)
                                {
                                    if (StateCell[posX + p, posY + i + q] != 4)
                                        StateCell[posX + p, posY + i + q] = 9;
                                }
                            }
                        }
                    }

                    break;
            }
        }

        int k = 19;
        private void SetShip3(Random rand, int[,] StateCell)  // установка 3 палубного корабля
        {
            k += 1;
            int posX, posY;
            int direction = rand.Next(2);
            bool b = false;

            switch (direction)
            {
                case 0:
                    while (b == false)
                    {
                        posX = rand.Next(8);
                        posY = rand.Next(10);
                        if (StateCell[posX, posY] == 0 && StateCell[posX + 1, posY] == 0 && StateCell[posX + 2, posY] == 0)
                            b = true;

                        if (b == true)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                StateCell[posX + i, posY] = k;
                                for (int q = -1; q <= 1; q++)
                                {
                                    for (int p = -1; p <= 1; p++)
                                    {
                                        if (posX + i + p >= 0 && posX + i + p <= 9 && posY + q >= 0 && posY + q <= 9)
                                        {
                                            if (StateCell[posX + i + p, posY + q] != k)
                                                StateCell[posX + i + p, posY + q] = 9;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;

                case 1:
                    while (b == false)
                    {
                        posX = rand.Next(10);
                        posY = rand.Next(8);
                        if (StateCell[posX, posY] == 0 && StateCell[posX, posY + 1] == 0 && StateCell[posX, posY + 2] == 0)
                            b = true;

                        if (b == true)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                StateCell[posX, posY + i] = k;
                                for (int q = -1; q <= 1; q++)
                                {
                                    for (int p = -1; p <= 1; p++)
                                    {
                                        if (posX + p >= 0 && posX + p <= 9 && posY + i + q >= 0 && posY + i + q <= 9)
                                        {
                                            if (StateCell[posX + p, posY + i + q] != k)
                                                StateCell[posX + p, posY + i + q] = 9;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        int s = 9;
        private void SetShip2(Random rand, int[,] StateCell)  //установка 2 палубного корабля
        {
            s += 1;
            int posX, posY;
            int direction = rand.Next(2);
            bool b = false;

            switch (direction)
            {
                case 0:
                    while (b == false)
                    {
                        posX = rand.Next(9);
                        posY = rand.Next(10);
                        if (StateCell[posX, posY] == 0 && StateCell[posX + 1, posY] == 0)
                            b = true;

                        if (b == true)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                StateCell[posX + i, posY] = s;
                                for (int q = -1; q <= 1; q++)
                                {
                                    for (int p = -1; p <= 1; p++)
                                    {
                                        if (posX + i + p >= 0 && posX + i + p <= 9 && posY + q >= 0 && posY + q <= 9)
                                        {
                                            if (StateCell[posX + i + p, posY + q] != s)
                                                StateCell[posX + i + p, posY + q] = 9;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;

                case 1:
                    while (b == false)
                    {
                        posX = rand.Next(10);
                        posY = rand.Next(9);
                        if (StateCell[posX, posY] == 0 && StateCell[posX, posY + 1] == 0)
                            b = true;

                        if (b == true)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                StateCell[posX, posY + i] = s;
                                for (int q = -1; q <= 1; q++)
                                {
                                    for (int p = -1; p <= 1; p++)
                                    {
                                        if (posX + p >= 0 && posX + p <= 9 && posY + i + q >= 0 && posY + i + q <= 9)
                                        {
                                            if (StateCell[posX + p, posY + i + q] != s)
                                                StateCell[posX + p, posY + i + q] = 9;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private void SetShip1(Random rand, int[,] StateCell) // установка 1 палубного корабля
        {
            int posX, posY;
            bool b = false;

            while (b == false)
            {
                posX = rand.Next(10);
                posY = rand.Next(10);
                if (StateCell[posX, posY] == 0)
                    b = true;

                if (b == true)
                {
                    StateCell[posX, posY] = 1;
                    for (int q = -1; q <= 1; q++)
                    {
                        for (int p = -1; p <= 1; p++)
                        {
                            if (posX + p >= 0 && posX + p <= 9 && posY + q >= 0 && posY + q <= 9)
                            {
                                if (StateCell[posX + p, posY + q] != 1)
                                    StateCell[posX + p, posY + q] = 9;
                            }
                        }
                    }
                }
            }
        }
    }
}
