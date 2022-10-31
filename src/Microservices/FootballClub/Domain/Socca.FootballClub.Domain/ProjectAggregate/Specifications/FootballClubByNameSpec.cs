using System;
using Socca.FootballClub.Domain.Entities;
using Socca.FootballClub.Domain.Interfaces;
using System.Reflection.Metadata;
using Socca.Domain.Core.Abstracts;

namespace Socca.FootballClub.Domain.ProjectAggregate.Specifications
{
    public class FootballClubByNameSpec : BaseSpecification<Entities.FootballClub>
    {
        public FootballClubByNameSpec(string name)
            : base(b => b.Name.Equals(name))
        {
        }

        public FootballClubByNameSpec(int id)
            : base(b => b.Id == id)
        {
        }
    }
}

