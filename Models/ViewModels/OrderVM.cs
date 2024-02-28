using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Stripe.Climate;

namespace Projekt.Models.ViewModels
{
    public class OrderVM
    {
        public IEnumerable<Order> OrderDetail { get; set; }

        public OrderHeader OrderHeader { get; set; }

    }
}