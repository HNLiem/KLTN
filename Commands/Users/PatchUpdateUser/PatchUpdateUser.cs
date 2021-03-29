using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using WebApi.Commands.Users.Models.PatchUpdateUser;

namespace WebApi.Commands.Users.PatchUpdateUser
{
    public class PatchUpdateUser : IRequest
    {
        public int Id { get; }
        public JsonPatchDocument<PatchUpdateUserModel> JsonPatchDocument { get; }

        public PatchUpdateUser(int id, JsonPatchDocument<PatchUpdateUserModel> jsonPatchDocument)
        {
            Id = id;
            JsonPatchDocument = jsonPatchDocument;
        }
    }
}
