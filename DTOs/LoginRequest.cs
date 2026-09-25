<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace TicketBookingAPI.DTOs
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "UserId is required.")]
        [StringLength(20, MinimumLength = 4,
            ErrorMessage = "UserId must be between 4 and 20 characters.")]
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 6,
            ErrorMessage = "Password must be between 6 and 50 characters.")]
=======
﻿namespace TicketBookingAPI.DTOs
{
    public class LoginRequest
    {
        public string UserId { get; set; } = string.Empty;
>>>>>>> d17e09942ae38a48299c28b5d999ae14707f4770
        public string Password { get; set; } = string.Empty;
    }
}