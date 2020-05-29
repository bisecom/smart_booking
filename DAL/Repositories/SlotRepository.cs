using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class SlotRepository : IRepository<Slot>
    {
        private SBContext db;

        public SlotRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Slot item)
        {
            try
            {
                db.Slots.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Slot slot = db.Slots.Find(id);
                if (slot != null)
                {
                    db.Slots.Remove(slot);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<Slot> Find(Func<Slot, bool> predicate)
        {
            return db.Slots.AsQueryable();
        }

        public async Task<Slot> Get(int id)
        {
            return await db.Slots.FindAsync(id);
        }

        public IQueryable<Slot> GetAll()
        {
            return db.Slots.AsQueryable();
        }

        public async Task<bool> Update(Slot slot)
        {
            try
            {
                var initialSlot = await db.Slots.FindAsync(slot.Id);
                if (initialSlot != null)
                {
                    initialSlot.SlotDateTime = slot.SlotDateTime;
                    initialSlot.Duration = slot.Duration;
                    initialSlot.IsPadding = slot.IsPadding;
                    initialSlot.PaddingAfter = slot.PaddingAfter;
                    initialSlot.Reiteration = slot.Reiteration;
                    initialSlot.Price = slot.Price;
                    initialSlot.Note = slot.Note;
                    initialSlot.Status = slot.Status;
                    initialSlot.IsTimeBlock = slot.IsTimeBlock;
                    initialSlot.IsReminderNeeded = slot.IsReminderNeeded;
                    initialSlot.ReminderInterval = slot.ReminderInterval;

                    if (initialSlot.Employee.Id != slot.Employee.Id)
                    {
                        db.Entry(initialSlot.Employee).State = EntityState.Deleted;
                        initialSlot.Employee = db.Employees.Find(slot.Employee.Id);
                    }

                    if (initialSlot.Country.Id != slot.Country.Id)
                    {
                        //db.Entry(initialSlot.Country).State = EntityState.Deleted;
                        //initialSlot.Country = db.Countries.Find(slot.Country.Id);
                        var country = db.Countries.Include("Slots").Single(s => s.Id == initialSlot.Country.Id);
                        var slotToDelete = country.Slots.FirstOrDefault(ol => ol.Id == initialSlot.Id);
                        if (slotToDelete != null)
                            country.Slots.Remove(slotToDelete);
                        initialSlot.Country = slot.Country;
                    }
                    
                    if (initialSlot.Responsible.Id != slot.Responsible.Id)
                    {
                        db.Entry(initialSlot.Responsible).State = EntityState.Deleted;
                        initialSlot.Responsible = db.Employees.Find(slot.Responsible.Id);
                    }

                    if (initialSlot.Service.Id != slot.Service.Id)
                    {
                        db.Entry(initialSlot.Service).State = EntityState.Deleted;
                        initialSlot.Service = db.Services.Find(slot.Service.Id);
                    }

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}
