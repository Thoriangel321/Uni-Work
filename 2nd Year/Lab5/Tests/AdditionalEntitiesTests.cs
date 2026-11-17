using Lab5.BLL.Entities;
using Xunit;

namespace Lab5.Tests
{
    public class AdditionalEntitiesTests
    {
        [Fact]
        public void Librarian_StudyOnline_WithInternet_ReturnsSuccess()
        {
            var librarian = new Librarian { Name = "Olena" };

            string result = librarian.StudyOnline(true);

            Assert.Equal("Librarian Olena studies online", result);
        }

        [Fact]
        public void Librarian_StudyOnline_WithoutInternet_ReturnsError()
        {
            var librarian = new Librarian { Name = "Olena" };

            string result = librarian.StudyOnline(false);

            Assert.Equal("No Internet connection for studying", result);
        }

        [Fact]
        public void Librarian_RideBicycle_ReturnsExpectedString()
        {
            var librarian = new Librarian { Name = "Olena" };

            string result = librarian.RideBicycle();

            Assert.Equal("Librarian Olena rides a bicycle", result);
        }

        [Fact]
        public void SoftwareDeveloper_StudyOnline_WithInternet_ReturnsSuccess()
        {
            var dev = new SoftwareDeveloper { Name = "Max" };

            string result = dev.StudyOnline(true);

            Assert.Equal("SD Max studies online", result);
        }

        [Fact]
        public void SoftwareDeveloper_StudyOnline_WithoutInternet_ReturnsError()
        {
            var dev = new SoftwareDeveloper { Name = "Max" };

            string result = dev.StudyOnline(false);

            Assert.Equal("No Internet connection for studying", result);
        }

        [Fact]
        public void SoftwareDeveloper_RideBicycle_ReturnsExpectedString()
        {
            var dev = new SoftwareDeveloper { Name = "Max" };

            string result = dev.RideBicycle();

            Assert.Equal("SD Max rides a bicycle", result);
        }
    }
}