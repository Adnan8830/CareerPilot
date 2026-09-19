using CareerPilot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPilot.Application.DTOs
{
    public class JobApplicationDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string JobUrl { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public ApplicationStatus Status { get; set; }
        public string? ReferralName { get; set; }
        public string? ReferralLinkedInUrl { get; set; }
        public Guid ResumeId { get; set; }
    }
}
