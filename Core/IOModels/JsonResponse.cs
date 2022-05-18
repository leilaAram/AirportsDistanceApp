using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IOModels
{
    public class JsonResponse
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public int PageSize { get; set; }
        public int TotlaCount { get; set; }
        public int PageIndex { get; set; }
        public ErrorCodes ErrorCode { get; set; }
    }
}
