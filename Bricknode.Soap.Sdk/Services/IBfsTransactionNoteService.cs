using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BfsApi;

namespace Bricknode.Soap.Sdk.Services
{
    public interface IBfsTransactionNoteService
    {
        Task<GetTransactionNoteResponse> GetTransactionNotesAsync(GetTransactionNoteArgs filters,
            string? bfsApiClientName = null);
    }
}
