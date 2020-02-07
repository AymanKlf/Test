using Domain.Exceptions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.UnitTests.ValueObjects
{
    public class CoordinatePointTests
    {
        [Fact]
        public void ShouldThrowInvalidCoordinatePointException()
        {
            Assert.Throws<InvalidCoordinatePointException>(() => CoordinatePoint.For(1000,1000));
        }
    }
}
