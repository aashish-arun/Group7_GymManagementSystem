using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group7_GymManagementSystem.Data
{
    // You can basically have the values EightToTenAM, TenToTwelvePM, TwelveToTwoPM, FourToSixPM, SixToEightPM for ScheduledTime property
    // Will use a Utility method named GetDisplayName to get display name for a ScheduledTime enum value using Display attribute metadata.
    public enum ScheduledTime
    {
        [Display(Name = "8:00 AM - 10:00 AM")]
        EightToTenAM,

        [Display(Name = "10:00 AM - 12:00 PM")]
        TenToTwelvePM,

        [Display(Name = "12:00 PM - 2:00 PM")]
        TwelveToTwoPM,

        [Display(Name = "2:00 PM - 4:00 PM")]
        TwoToFourPM,

        [Display(Name = "4:00 PM - 6:00 PM")]
        FourToSixPM,

        [Display(Name = "6:00 PM - 8:00 PM")]
        SixToEightPM
    }
}
