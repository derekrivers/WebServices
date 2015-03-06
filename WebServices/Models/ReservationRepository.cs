using System;
using System.Collections.Generic;
using System.Linq;


namespace WebServices.Models
{
    public class ReservationRepository
    {
        private static readonly ReservationRepository _Repo = new ReservationRepository();

        public static ReservationRepository Current
        {
            get { return _Repo; }
        }

        private List<Reservation> data = new List<Reservation>
        {
            new Reservation {ReservationId = 1, ClientName = "Andy", Location = "Board Room"},
            new Reservation {ReservationId = 2, ClientName = "Derek", Location = "Meeting Room 1"},
            new Reservation {ReservationId = 3, ClientName = "Mark", Location = "Meeting Room 2"}
        };

        public IEnumerable<Reservation> GetAll()
        {
            return data;
        }

        public Reservation Get(int id)
        {
            return data.FirstOrDefault(p => p.ReservationId == id);
        }

        public Reservation Add(Reservation item)
        {
            item.ReservationId = data.Count + 1;
            data.Add(item);

            return item;
        }

        public void Remove(int id)
        {
            Reservation item = Get(id);

            if (item != null)
            {
                data.Remove(item);
            }

        }

        public bool Update(Reservation item)
        {
            Reservation storedItem = Get(item.ReservationId);

            if (storedItem != null)
            {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            }

            return false;

        }
    }
}