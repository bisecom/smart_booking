using BLL.Interfaces;
using BLL.Utils;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookingDTMServiceRepo : IServiceRepository<BookingDTM>
    {
        IUnitOfWork Database { get; set; }

        public BookingDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<BookingDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingDTM> Get(int id)
        {
            int firstBookingId = 1;
            if (id < firstBookingId)
                throw new ValidationException("Booking id is not specified correctly", "");
            var booking = await Database.Bookings.Get(id);
            if (booking == null)
                throw new ValidationException("Booking is not found", "");

            BookingDTM bDtm = new BookingDTM();
            bDtm.BusinessId = booking.BusinessId;
            bDtm.WebpageLink = booking.WebpageLink;
            bDtm.IsEntityLogoRemoved = booking.IsEntityLogoRemoved;
            bDtm.IsMemberSelecting = booking.IsMemberSelecting;
            bDtm.SlotDuration = booking.SlotDuration;
            bDtm.PageLanguageId = booking.PageLanguageId;
            bDtm.BannerPicture = booking.BannerPicture;
            bDtm.SklypeLink = booking.SklypeLink;
            bDtm.FacebookLink = booking.FacebookLink;
            bDtm.TwitterLink = booking.TwitterLink;
            bDtm.InstagramkLink = booking.InstagramkLink;
            bDtm.YoutubeLink = booking.YoutubeLink;
            bDtm.PageOverview = booking.PageOverview;
            bDtm.IsContactsAvailable = booking.IsContactsAvailable;
            bDtm.IsServicesAvailable = booking.IsServicesAvailable;
            bDtm.IsPriceAvailable = booking.IsPriceAvailable;
            bDtm.IsDurationAvailable = booking.IsDurationAvailable;
            bDtm.IsDescriptionAvailable = booking.IsDescriptionAvailable;

            if (booking.Business != null)
            {
                BusinessDTM businessDtm = new BusinessDTM();
                businessDtm.Name = booking.Business.Name;
                businessDtm.Phone = booking.Business.Phone;
                businessDtm.Logo = booking.Business.Logo;
                businessDtm.Webpage = booking.Business.Webpage;
                businessDtm.Address = booking.Business.Address;
                businessDtm.City = booking.Business.City;
                businessDtm.State = booking.Business.State;
                businessDtm.ZipCode = booking.Business.ZipCode;
                businessDtm.RegistrationNumber = booking.Business.RegistrationNumber;
                businessDtm.Country = null;
                businessDtm.Currency = null;
                businessDtm.Time_zone = null;
                businessDtm.Booking = null;
                businessDtm.Services = null;
                businessDtm.Clients = null;
                businessDtm.Employees = null;
                bDtm.Business = businessDtm;
            }

            return bDtm;
        }

        public IQueryable<BookingDTM> Find(Func<BookingDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int>Create(BookingDTM item)
        {
            try
            {
                Booking booking = new Booking();
                booking.BusinessId = item.BusinessId;
                booking.WebpageLink = item.WebpageLink;
                booking.IsEntityLogoRemoved = item.IsEntityLogoRemoved;
                booking.IsMemberSelecting = item.IsMemberSelecting;
                booking.SlotDuration = item.SlotDuration;
                booking.PageLanguageId = item.PageLanguageId;
                booking.BannerPicture = item.BannerPicture;
                booking.SklypeLink = item.SklypeLink;
                booking.FacebookLink = item.FacebookLink;
                booking.TwitterLink = item.TwitterLink;
                booking.InstagramkLink = item.InstagramkLink;
                booking.YoutubeLink = item.YoutubeLink;
                booking.PageOverview = item.PageOverview;
                booking.IsContactsAvailable = item.IsContactsAvailable;
                booking.IsServicesAvailable = item.IsServicesAvailable;
                booking.IsPriceAvailable = item.IsPriceAvailable;
                booking.IsDurationAvailable = item.IsDurationAvailable;
                booking.IsDescriptionAvailable = item.IsDescriptionAvailable;

                if (item.Business != null)
                {
                    Business business = new Business();
                    business.Id = item.Business.Id;
                    business.Name = item.Business.Name;
                    business.Phone = item.Business.Phone;
                    business.Logo = item.Business.Logo;
                    business.Webpage = item.Business.Webpage;
                    business.Address = item.Business.Address;
                    business.City = item.Business.City;
                    business.State = item.Business.State;
                    business.ZipCode = item.Business.ZipCode;
                    business.RegistrationNumber = item.Business.RegistrationNumber;
                    business.Country = null;
                    business.Currency = null;
                    business.Time_zone = null;
                    business.Booking = null;
                    business.Services = null;
                    business.Clients = null;
                    business.Employees = null;
                    booking.Business = business;
                }
                await Database.Bookings.Create(booking);
                return booking.BusinessId;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(BookingDTM item)
        {
            try
            {
                Booking booking = new Booking();
                booking.BusinessId = item.BusinessId;
                booking.WebpageLink = item.WebpageLink;
                booking.IsEntityLogoRemoved = item.IsEntityLogoRemoved;
                booking.IsMemberSelecting = item.IsMemberSelecting;
                booking.SlotDuration = item.SlotDuration;
                booking.PageLanguageId = item.PageLanguageId;
                booking.BannerPicture = item.BannerPicture;
                booking.SklypeLink = item.SklypeLink;
                booking.FacebookLink = item.FacebookLink;
                booking.TwitterLink = item.TwitterLink;
                booking.InstagramkLink = item.InstagramkLink;
                booking.YoutubeLink = item.YoutubeLink;
                booking.PageOverview = item.PageOverview;
                booking.IsContactsAvailable = item.IsContactsAvailable;
                booking.IsServicesAvailable = item.IsServicesAvailable;
                booking.IsPriceAvailable = item.IsPriceAvailable;
                booking.IsDurationAvailable = item.IsDurationAvailable;
                booking.IsDescriptionAvailable = item.IsDescriptionAvailable;

                if (item.Business != null)
                {
                    booking.Business.Name = item.Business.Name;
                    booking.Business.Phone = item.Business.Phone;
                    booking.Business.Logo = item.Business.Logo;
                    booking.Business.Webpage = item.Business.Webpage;
                    booking.Business.Address = item.Business.Address;
                    booking.Business.City = item.Business.City;
                    booking.Business.State = item.Business.State;
                    booking.Business.ZipCode = item.Business.ZipCode;
                    booking.Business.RegistrationNumber = item.Business.RegistrationNumber;
                    booking.Business.Country = null;
                    booking.Business.Currency = null;
                    booking.Business.Time_zone = null;
                    booking.Business.Booking = null;
                    booking.Business.Services = null;
                    booking.Business.Clients = null;
                    booking.Business.Employees = null;
                }

                return await Database.Bookings.Update(booking) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                Database.Bookings.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
