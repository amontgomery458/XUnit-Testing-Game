using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Tests
{
	public class NonPlayerCharacterShould
	{
		//Data-driven Tests
		[Theory]
		[MemberData(nameof(ExternalHealthDamageTestData.TestData),
			MemberType = typeof(ExternalHealthDamageTestData))]
		public void TakeDamage(int damage, int expectedHealth)
		{
			NonPlayerCharacter _sut = new NonPlayerCharacter();

			_sut.TakeDamage(damage);

			Assert.Equal(expectedHealth, _sut.Health);
		}
	}
}
