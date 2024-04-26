using Xunit.Abstractions;

namespace GameEngine.Tests
{
	public class PlayerCharacterShould : IDisposable
	{
		private readonly PlayerCharacter _sut;
		private readonly ITestOutputHelper _output;

		public PlayerCharacterShould(ITestOutputHelper output)
		{
			_output = output;

			_output.WriteLine("Creating new PlayerCharacter");
			_sut = new PlayerCharacter();
		}

		//Boolean values
		[Fact]
		public void BeInexperiencedWhenNew()
		{
			Assert.True(_sut.IsNoob);
		}

		//String values
		[Fact]
		public void CalculateFullName()
		{
			_sut.FirstName = "Sarah";
			_sut.LastName = "Smith";

			Assert.Equal("Sarah Smith", _sut.FullName);
		}

		[Fact]
		public void HaveFullNameStartingWithFirstName()
		{
			_sut.FirstName = "Sarah";

			Assert.StartsWith("Sarah", _sut.FullName);
		}

		[Fact]
		public void HaveFullNameEndingWithFirstName()
		{
			_sut.LastName = "Smith";

			Assert.EndsWith("Smith", _sut.FullName);
		}

		[Fact]
		public void CalculateFullName_IgnoreCaseAssertExample()
		{
			_sut.FirstName = "SARAH";
			_sut.LastName = "SMITH";

			Assert.Equal("Sarah Smith", _sut.FullName, ignoreCase: true);
		}

		[Fact]
		public void CalculateFullName_SubstringAssertExample()
		{
			_sut.FirstName = "Sarah";
			_sut.LastName = "Smith";

			Assert.Contains("ah Sm", _sut.FullName);
		}


		[Fact]
		public void CalculateFullNameWithTitleCase()
		{
			_sut.FirstName = "Sarah";
			_sut.LastName = "Smith";

			Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
		}

		//Numeric Values
		[Fact]
		public void StartWithDefaultHealth()
		{
			Assert.Equal(100, _sut.Health);
		}

		[Fact]
		public void StartWithDefaultHealth_NotEqualExample()
		{
			Assert.NotEqual(0, _sut.Health);
		}

		[Fact]
		public void IncreaseHealthAfterSleeping()
		{
			_sut.Sleep();

			//Assert.True(sut.Health >= 101 && sut.Health <= 200);
			Assert.InRange(_sut.Health, 101, 200);
		}

		//Null Values
		[Fact]
		public void NotHaveNickNameByDefault()
		{
			Assert.Null(_sut.Nickname);
		}

		//Asserting with collections
		[Fact]
		public void HaveALongBow()
		{
			Assert.Contains("Long Bow", _sut.Weapons);
		}

		[Fact]
		public void NotHaveAStaffOfWonder()
		{
			Assert.DoesNotContain("Staff Of Wonder", _sut.Weapons);
		}

		//Asserting that Events are raised
		[Fact]
		public void RaiseSleptEvent()
		{
			Assert.Raises <EventArgs>(
				handler => _sut.PlayerSlept += handler,
				handler => _sut.PlayerSlept -= handler,
				() => _sut.Sleep());
		}

		[Fact]
		public void RaisePropertyChangedEvent()
		{
			Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
		}

		//Data-driven Tests
		//Sharing data to other classes and methods
		[Theory]
		[MemberData(nameof(ExternalHealthDamageTestData.TestData),
			MemberType = typeof(ExternalHealthDamageTestData))]
		public void TakeDamage(int damage, int expectedHealth)
		{
			_sut.TakeDamage(damage);

			Assert.Equal(expectedHealth, _sut.Health);
		}

		public void Dispose()
		{
			_output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");
		}
	}
}