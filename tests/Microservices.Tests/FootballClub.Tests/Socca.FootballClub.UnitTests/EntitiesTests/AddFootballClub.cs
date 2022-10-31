using System;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace Socca.FootballClub.UnitTests.EntitiesTests
{

    public class AddFootballClub
    {

        private string _name = "Chelsea";
        private string _location = "Chelsea City";
        private string _description = "Chelsea club has 10 000 000 fans";
        private string _image = "";


        [Fact]
        public void AddsBlogIfNotPresent()
        {
            var footballClub = new Socca.FootballClub.Domain.Entities.FootballClub(_name, _location, _description,_image);
            Assert.Equal(_name, footballClub.Name);
            Assert.Equal(_location, footballClub.Location);
            Assert.Equal(_description, footballClub.Description);
            Assert.Equal(_image, footballClub.Image);
        }
    }
}

