﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.WebUI.Dtos.ProductDtos;
using RealEstate.WebUI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate.WebUI.ViewComponents.HomePage;

public class _DefaultWhoWeAreViewComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _DefaultWhoWeAreViewComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7201/api/WhoWeAreDetails/WhoWeAreDetailList");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultWhoWeAreDetailDto>(jsonData);
            ViewBag.Title = value.Title;
            ViewBag.Subtitle = value.Subtitle;
            ViewBag.Description1 = value.Description1;
            ViewBag.Description2 = value.Description2;

            return View();
        }
        return View();
    }
}
