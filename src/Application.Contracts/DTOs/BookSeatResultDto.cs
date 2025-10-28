using System;

namespace Application.Contracts.DTOs
{
    public class BookSeatResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
    }
}
