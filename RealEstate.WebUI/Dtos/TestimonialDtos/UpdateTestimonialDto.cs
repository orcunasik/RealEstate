﻿namespace RealEstate.WebUI.Dtos.TestimonialDtos;

public class UpdateTestimonialDto
{
    public int TestimonialId { get; set; }
    public string NameSurname { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public bool Status { get; set; }
}
