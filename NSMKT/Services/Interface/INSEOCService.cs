﻿namespace NSMkt.Services.Interface
{
    public interface INSEOCService
    {
        Task<List<OCIndexData>> GetOCDataAsyncFiltered(string script, string? expiry = null);


    }
}
