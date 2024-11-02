using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class MyProgram
    {
        //static void Main()
        //{
        // Room room = new Room(2);
        //    room.RoomSoldOutEvent += onRoomSoldOut;
        //    room.BookRoom();
        //    room.BookRoom();
        //    room.BookRoom();

        //}

        static void onRoomSoldOut(object sender, EventArgs e)
        {
            System.Console.WriteLine("Room sold out");
        }
    }

    class Room
    {
        int numberOfRooms { get; set; }

        private int roomsUsed = 0;
        public Room(int numberofRooms)
        {
            numberOfRooms = numberofRooms;
        }

        public void BookRoom()
        {
            roomsUsed++;
            if (roomsUsed >= numberOfRooms)
            {
                onRoomSoldOut(EventArgs.Empty);
            }
            else
            {
                System.Console.WriteLine("Room booked");
            }

           
            
        }

        public event EventHandler RoomSoldOutEvent;

        protected virtual void onRoomSoldOut(EventArgs e)
        {
            RoomSoldOutEvent?.Invoke(this, e);
        }


    }
}
