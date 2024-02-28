using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Utility
{
    public static class SD
    {

        public const string Role_Customer = "Kund";
        public const string Role_Company = "Företag";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Anställd";

        public const string StatusPending = "Väntande";
        public const string StatusApproved = "Godkänd";
        public const string StatusInProcess = "Bearbetar";
        public const string StatusShipped = "Skickad";
        public const string StatusCancelled = "Avbruten";
        public const string StatusRefunded = "Återbetald";

        public const string PaymentStatusPending = "Väntande";
        public const string PaymentStatusApproved = "Godkänd";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "Avvisad";



    }
}

