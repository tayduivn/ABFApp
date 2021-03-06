﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABF.Data.ABFDbModels;

namespace ABF.Data.DAO
{
    public class EventDAO
    {
        private ABFDbContext _context;

        public EventDAO()
        {
            _context = new ABFDbContext();
        }

        public Event GetEvent(int id)
        {
            IQueryable<Event> _event;

            _event = from e
                     in _context.Events
                     where e.Id == id
                     select e;

            return _event.ToList().First();
        }

        public IList<Event> GetEvents()
        {
            IQueryable<Event> _events;

            _events = from e
                      in _context.Events
                      select e;

            return _events.ToList();
        }

        public void CreateEvent(Event e)
        {
            _context.Events.Add(e);
            _context.SaveChanges();
        }

        public void UpdateEvent(Event e)
        {
            Event _event = GetEvent(e.Id);

            _event.Date = e.Date;
            _event.StartTime = e.StartTime;
            _event.EndTime = e.EndTime;
            _event.Name = e.Name;
            _event.Author = e.Author;
            _event.Details = e.Details;
            _event.Description = e.Description;
            _event.Capacity = e.Capacity;
            _event.TicketPrice = e.TicketPrice;
            _event.IsMemberOnly = e.IsMemberOnly;
            _event.LocationId = e.LocationId;
            _event.ImageId = e.ImageId;
            _event.BookUrl = e.BookUrl;
            _event.AuthorUrl = e.AuthorUrl;


            _context.SaveChanges();
        }

        public void DeleteEvent(Event e)
        {
            _context.Events.Remove(e);
            _context.SaveChanges();
        }


        // returns a list of dates on which events are happening, in DateTime format
        public List<DateTime> GetUniqueDates()
        {
            var eventlist = GetEvents();
            var datelist = new List<DateTime>();

            foreach (Event e in eventlist)
            {
                if (!datelist.Contains(e.Date))
                {
                    datelist.Add(e.Date);
                }
            }
            return datelist;
        }

    }
}
