using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPilot.Application.Interfaces;

public interface IJwtTokenGenerator
{
    void GenerateToken(Guid userId, string email);
}
