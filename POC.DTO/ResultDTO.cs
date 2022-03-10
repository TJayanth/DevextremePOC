using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.DTO
{
    public class ResultDTO<T> : IResultDTO<T>
    {
        public Exception Exception { get; set; }

        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public string Id { get; set; }
    }

    public interface IResultDTO<T>
    {
        Exception Exception { get; set; }

        T Data { get; set; }

        bool IsSuccess { get; set; }

        string Message { get; set; }

        List<string> Errors { get; set; }
        string Id { get; set; }
    }
}
