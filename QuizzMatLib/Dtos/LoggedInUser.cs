using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzMatLib.Dtos
{
    public record LoggedInUser(int Id, string Name, string Email, string Token);
}
