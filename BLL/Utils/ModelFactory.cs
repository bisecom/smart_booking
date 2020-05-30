using smart_booking.BLL.DataTransferModels;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public static class ModelFactory
    {

        public static CalendarSetting changeFromDTM(CalendarSettingDTM settingDtm)
        {

            return null;
        }

        public static CalendarSettingDTM changeToDTM(CalendarSetting setting)
        {
            CalendarSettingDTM cSetting = new CalendarSettingDTM();
            cSetting.EmployeeId = setting.EmployeeId;
            cSetting.View = setting.View;
            cSetting.FirstHour = setting.FirstHour;
            cSetting.WorkingDayDuration = setting.WorkingDayDuration;
            cSetting.SlotDuration = setting.SlotDuration;
            return cSetting;
        }

        public static CustomerNotificationDTM changeToDTM(CustomerNotification cNotification)
        {
            CustomerNotificationDTM customerNotificationDTM = new CustomerNotificationDTM();
            customerNotificationDTM.EmployeeId = cNotification.EmployeeId;
            customerNotificationDTM.AfterBooked = cNotification.AfterBooked;
            customerNotificationDTM.AfterRescheduled = cNotification.AfterRescheduled;
            customerNotificationDTM.AfterCancelled = cNotification.AfterCancelled;
            return customerNotificationDTM;
        }

        public static TeamNotificationDTM changeToDTM(TeamNotification tNotification)
        {
            TeamNotificationDTM tNotificationDTM = new TeamNotificationDTM();
            tNotificationDTM.EmployeeId = tNotification.EmployeeId;
            tNotificationDTM.AfterBooked = tNotification.AfterBooked;
            tNotificationDTM.AfterRescheduled = tNotification.AfterRescheduled;
            tNotificationDTM.Collegue = tNotification.Collegue;
            tNotificationDTM.CollegueAndOwner = tNotification.CollegueAndOwner;
            tNotificationDTM.Owner = tNotification.Owner;
            return tNotificationDTM;
        }

        public static PermissionDTM changeToDTM(Permission permission)
        {
            PermissionDTM permissionDtm = new PermissionDTM();
            permissionDtm.EmployeeId = permission.EmployeeId;
            permissionDtm.IsSummary = permission.IsSummary;
            permissionDtm.IsOthersCalendar = permission.IsOthersCalendar;
            permissionDtm.IsClients = permission.IsClients;
            permissionDtm.IsServices = permission.IsServices;
            permissionDtm.IsReports = permission.IsReports;
            return permissionDtm;
        }

        public static WorkingHourDTM changeToDTM(WorkingHour workingHour)
        {
            WorkingHourDTM workingHourDTM = new WorkingHourDTM();
            workingHourDTM.EmployeeId = workingHour.EmployeeId;
            workingHourDTM.MondayStart = workingHour.MondayStart;
            workingHourDTM.MondayStop = workingHour.MondayStop;
            workingHourDTM.TuesdayStart = workingHour.TuesdayStart;
            workingHourDTM.TuesdayStop = workingHour.TuesdayStop;
            workingHourDTM.WednesdayStart = workingHour.WednesdayStart;
            workingHourDTM.WednesdayStop = workingHour.WednesdayStop;
            workingHourDTM.ThursdayStart = workingHour.ThursdayStart;
            workingHourDTM.ThursdayStop = workingHour.ThursdayStop;
            workingHourDTM.FridayStart = workingHour.FridayStart;
            workingHourDTM.FridayStop = workingHour.FridayStop;
            workingHourDTM.SaturdayStart = workingHour.SaturdayStart;
            workingHourDTM.SaturdayStop = workingHour.SaturdayStop;
            workingHourDTM.SundayStart = workingHour.SundayStart;
            workingHourDTM.SundayStop = workingHour.SundayStop;

            return workingHourDTM;
        }

        public static WorkingBreakDTM changeToDTM(WorkingBreak workingBreak)
        {
            WorkingBreakDTM workingBreakDTM = new WorkingBreakDTM();
            workingBreakDTM.Id = workingBreak.Id;
            workingBreakDTM.WeekDay = workingBreak.WeekDay;
            workingBreakDTM.BreakStart = workingBreak.BreakStart;
            workingBreakDTM.BreakStop = workingBreak.BreakStop;

            return workingBreakDTM;
        }

        public static SlotDTM changeToDTM(Slot slot)
        {
            SlotDTM slotDtm = new SlotDTM();
            slotDtm.Id = slot.Id;
            slotDtm.SlotDateTime = slot.SlotDateTime;
            slotDtm.Duration = slot.Duration;
            slotDtm.IsPadding = slot.IsPadding;
            slotDtm.PaddingAfter = slot.PaddingAfter;
            slotDtm.Reiteration = slot.Reiteration;
            slotDtm.Price = slot.Price;
            slotDtm.Note = slot.Note;
            slotDtm.Status = slot.Status;
            slotDtm.IsTimeBlock = slot.IsTimeBlock;
            slotDtm.IsReminderNeeded = slot.IsReminderNeeded;
            slotDtm.ReminderInterval = slot.ReminderInterval;

            slotDtm.EmployeeId = slot.EmployeeId;
            slotDtm.ResponsibleId = slot.ResponsibleId;
            slotDtm.CountryId = slot.CountryId;
            slotDtm.ServiceId = slot.ServiceId;
            return slotDtm;
        }

        public static UserDTM changeToDTM(User user)
        {
            UserDTM userDtm = new UserDTM();
            userDtm.Id = user.Id;
            userDtm.FirstName = user.FirstName;
            userDtm.SecondName = user.SecondName;
            userDtm.PhoneMobile = user.PhoneMobile;
            userDtm.PhoneOffice = user.PhoneOffice;
            userDtm.UserPicture = user.UserPicture;
            userDtm.Address = user.Address;
            userDtm.City = user.City;
            userDtm.State = user.State;
            userDtm.ZipCode = user.ZipCode;
            userDtm.PlanId = user.PlanId;
            userDtm.PaymentOverdue = user.PaymentOverdue;
            userDtm.IsMale = user.IsMale;
            userDtm.Birthdate = user.Birthdate;

            if (user.Country != null)
            {
                CountryDTM country = new CountryDTM();
                country.Id = user.Country.Id;
                country.Code = user.Country.Code;
                country.Name = user.Country.Name;
                country.Native = user.Country.Native;
                country.PhonePrefix = user.Country.PhonePrefix;
                country.Capital = user.Country.Capital;
                country.Currency_ = user.Country.Currency_;
                country.Emoji = user.Country.Emoji;
                country.EmojiU = user.Country.EmojiU;
                userDtm.Country = country;
            }
            
            if (user.Time_zone != null)
            {
                Time_zoneDTM tz = new Time_zoneDTM();
                tz.Id = user.Time_zone.Id;
                tz.Zone = user.Time_zone.Zone;
                tz.CountryCode = user.Time_zone.CountryCode;
                tz.UTC_Jan_1_2020 = user.Time_zone.UTC_Jan_1_2020;
                tz.DST_Jul_1_2020 = user.Time_zone.DST_Jul_1_2020;
                userDtm.Time_zone = tz;
            }
            return userDtm;
        }

        public static BusinessDTM changeToDTM(Business business)
        {
            BusinessDTM bDtm = new BusinessDTM();
            bDtm.Id = business.Id;
            bDtm.Name = business.Name;
            bDtm.Phone = business.Phone;
            bDtm.Logo = business.Logo;
            bDtm.Webpage = business.Webpage;
            bDtm.Address = business.Address;
            bDtm.City = business.City;
            bDtm.State = business.State;
            bDtm.ZipCode = business.ZipCode;
            bDtm.RegistrationNumber = business.RegistrationNumber;

            if (business.Country != null)
            {
                CountryDTM country = new CountryDTM();
                country.Id = business.Country.Id;
                country.Code = business.Country.Code;
                country.Name = business.Country.Name;
                country.Native = business.Country.Native;
                country.PhonePrefix = business.Country.PhonePrefix;
                country.Capital = business.Country.Capital;
                country.Currency_ = business.Country.Currency_;
                country.Emoji = business.Country.Emoji;
                country.EmojiU = business.Country.EmojiU;
                bDtm.Country = country;
                bDtm.CountryId = business.Country.Id;
            }
            if (business.Currency != null)
            {
                CurrencyDTM currency = new CurrencyDTM();
                currency.Id = business.Currency.Id;
                currency.Name = business.Currency.Name;
                bDtm.Currency = currency;
                bDtm.CurrencyId = business.Currency.Id;
            }
            if (business.Time_zone != null)
            {
                Time_zoneDTM tz = new Time_zoneDTM();
                tz.Id = business.Time_zone.Id;
                tz.Zone = business.Time_zone.Zone;
                tz.CountryCode = business.Time_zone.CountryCode;
                tz.UTC_Jan_1_2020 = business.Time_zone.UTC_Jan_1_2020;
                tz.DST_Jul_1_2020 = business.Time_zone.DST_Jul_1_2020;
                bDtm.Time_zone = tz;
                bDtm.Time_zoneId = business.Time_zone.Id;
            }
            return bDtm;
        }

        public static EmployeeDTM changeToDTM(Employee employee)
        {
            EmployeeDTM employeeDtm = new EmployeeDTM();

            if (employee.Business != null)
            {
                employeeDtm.Business = changeToDTM(employee.Business);
                employeeDtm.BusinessId = employee.Business.Id;
            }
            if (employee.User != null)
            {
                employeeDtm.User = changeToDTM(employee.User);
                employeeDtm.UserId = employee.User.Id;
            }
            employeeDtm.IsOwner = employee.IsOwner;

            if(employee.CalendarSetting != null)
            {
                employeeDtm.CalendarSetting = changeToDTM(employee.CalendarSetting);
            }

            if(employee.CustomerNotification != null)
            {
                employeeDtm.CustomerNotification = changeToDTM(employee.CustomerNotification);
            }
            if (employee.TeamNotification != null)
            {
                employeeDtm.TeamNotification = changeToDTM(employee.TeamNotification);
            }
            if (employee.Permission != null)
            {
                employeeDtm.Permission = changeToDTM(employee.Permission);
            }
            if (employee.WorkingHour != null)
            {
                employeeDtm.WorkingHour = changeToDTM(employee.WorkingHour);
            }
            if (employee.Slot != null)
            {
                employeeDtm.Slot = changeToDTM(employee.Slot);
            }

            return employeeDtm;
        }
    }
}
