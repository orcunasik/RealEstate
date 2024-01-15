﻿namespace RealEstate.WebUI.Dtos.ContactDtos;

public class LastContactResultDto
{
    public int ContactId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime SendDate { get; set; }
}