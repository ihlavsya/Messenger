using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.Core.ResponseModels
{
    public class ErrorMessage
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
