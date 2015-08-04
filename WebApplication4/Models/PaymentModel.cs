using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using WebApplication4.Binders;

namespace WebApplication4.Models
{
    [ModelBinder(typeof(FormModelBinder))]
    public class PaymentModel
    {
        public PaymentModel()
        {
            content = new List<SampleModel>();
        }
        public string communication_id { get; set; }
        public string content_size { get; set; }
        public List<SampleModel> content { get; set; }
    }
}
