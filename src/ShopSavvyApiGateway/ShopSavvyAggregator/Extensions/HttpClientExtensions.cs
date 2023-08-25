﻿namespace ShopSavvyAggregator.Extensions;
public static class HttpClientExtensions
{
    public static async Task<T> ReadContentAsAsync<T>(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(
                $"Something went wrong calling the API: {response.ReasonPhrase}");
        }

        var dataAsString = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}
