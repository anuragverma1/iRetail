﻿namespace iRetail.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public int telephone { get; set; }
        public string address { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
    }
}